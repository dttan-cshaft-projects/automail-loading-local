using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data; // DataTable
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using System.IO;
using MySql.Data.MySqlClient;
using DTO;


namespace DAO
{
    public class VnsoDAO : DBConnect
    {
        private static string _Table = "vnso";

        public int CountAll()
        {
            if (_conn.State != ConnectionState.Open)
                _conn.Open();
            var count = 0;
            DataTable dt = new DataTable();
            try
            {
                var sql = "SELECT count(*) FROM " + _Table + " ORDER BY ID DESC;";
                MySqlCommand Sqlcmd = new MySqlCommand(sql, _conn);
                //dt.Load(Sqlcmd.ExecuteReader());
                count = Convert.ToInt32(Sqlcmd.ExecuteScalar());
            }
            catch (Exception ex)
            {
                // xử lý lỗi tại đây
                Console.WriteLine("Count All Data Error: ");
                Console.WriteLine(ex.ToString());
            }
            finally
            {
                if (_conn.State == ConnectionState.Open)
                {
                    _conn.Close(); // close connection
                }
            }

            return count;
        }

        public int checkEmpty()
        {
            if (_conn.State != ConnectionState.Open)
                _conn.Open();
            var countAll = 0;
            var countEmpty = 0;
            var result = 0;
            DataTable dt = new DataTable();
            try
            {
                var sql = "SELECT count(*) FROM " + _Table + " ORDER BY ID DESC;";
                MySqlCommand Sqlcmd = new MySqlCommand(sql, _conn);
                //dt.Load(Sqlcmd.ExecuteReader());
                countAll = Convert.ToInt32(Sqlcmd.ExecuteScalar());

                var sql2 = "SELECT count(*) FROM " + _Table + " WHERE PACKING_INSTRUCTIONS='' AND VIRABLE_BREAKDOWN_INSTRUCTIONS='';";
                MySqlCommand Sqlcmd2 = new MySqlCommand(sql, _conn);
                //dt.Load(Sqlcmd.ExecuteReader());
                countEmpty = Convert.ToInt32(Sqlcmd2.ExecuteScalar());
                if ( (double)countEmpty > ((double)countAll / 2))
                {
                    result = 1;
                }

            }
            catch (Exception ex)
            {
                // xử lý lỗi tại đây
                Console.WriteLine("Count All Data Error: ");
                Console.WriteLine(ex.ToString());
            }
            finally
            {
                if (_conn.State == ConnectionState.Open)
                {
                    _conn.Close(); // close connection
                }
            }

            return result;
        }

        // read all data
        public DataTable ReadAll()
        {
            if (_conn.State != ConnectionState.Open)
                _conn.Open();

            DataTable dt = new DataTable();
            try
            {
                var sql = "SELECT * FROM "+ _Table + " ORDER BY ID DESC;";
                MySqlCommand Sqlcmd = new MySqlCommand(sql, _conn);
                dt.Load(Sqlcmd.ExecuteReader());
            }
            catch (Exception ex)
            {
                // xử lý lỗi tại đây
                Console.WriteLine("Read All Data Error: ");
                Console.WriteLine(ex.ToString());
            }
            finally
            {
                if (_conn.State == ConnectionState.Open)
                {
                    _conn.Close(); // close connection
                }
            }

            return dt;
        }

        // add item
        public int Add(string AutomailFile )
        {
            var count = 0;
            try
            {
                // connecting
                if (_conn.State != ConnectionState.Open)
                    _conn.Open();

                Console.Write("VNSO..."); // 5

                var check = true;
                
                // Kiểm tra nếu có dữ liệu thì xóa hết
                if (CountAll() > 0)
                {
                    //Console.Write("Deleting old data... ");
                    // delete all data in vnso talbe before This be insert
                    check = Truncate();

                    //Console.Write(check+"...");
                }

                
                // check is true, get data and insert
                if (check)
                {
                    Console.Write("updating..."); // 6
                    // Insert data ... 
                    MySqlBulkLoader Loader = new MySqlBulkLoader(_conn);
                    Loader.CharacterSet = "utf8";
                    Loader.TableName = _Table; // Vị trí bảng cần lưu
                    Loader.FieldTerminator = "\t"; // tách cột bằng ký tự "\t" (ký tự tab)
                    Loader.LineTerminator = "\n"; // tách dòng bằng ký tự "\n" (ký tự xuống dòng)
                    Loader.FileName = AutomailFile;
                    Loader.NumberOfLinesToSkip = 0;
                    Loader.Local = true;
                    count = Loader.Load();

                    return count;
                    // xóa file sau khi hoàn thành
                    // File.Delete(DataFile);
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: ");
                Console.WriteLine(ex.ToString()); // xử lý ngoại lệ
            }
            finally
            {
                if (_conn.State == ConnectionState.Open)
                    _conn.Close(); // Close connect
            }

            return count;

        }

        // delete item
        public bool Delete(AutomailDTO Automail)
        {
            try
            {
                // connecting
                if (_conn.State != ConnectionState.Open)
                    _conn.Open();

                // Query string 
                string sql = "DELETE FROM " + _Table + " WHERE ORDER_NUMBER={0} AND LINE_NUMBER={1} ;";
                string Query = string.Format(sql, Automail.OrderNumber, Automail.LineNumber);
                MySqlCommand Sqlcmd = new MySqlCommand(Query, _conn);

                // Query and check
                if (Sqlcmd.ExecuteNonQuery() > 0)
                    return true;

            }
            catch (Exception ex)
            {
                // xử lý ngoại lệ
                Console.WriteLine(ex.ToString());
            }
            finally
            {
                // Close connect
                _conn.Close();
            }

            return false;
        }

        // delete all data 
        public bool Truncate()
        {
            MySqlTransaction myTrans = null;
            try
            {
                // connecting
                if (_conn.State != ConnectionState.Open)
                    _conn.Open();

                // Start a local transaction
                myTrans = _conn.BeginTransaction();

                MySqlCommand SqlCmd = new MySqlCommand();
                SqlCmd.Connection = _conn;
                SqlCmd.Transaction = myTrans; // khai báo transaction cho mysql command
                SqlCmd.CommandText = "TRUNCATE TABLE " + _Table + ";";
                SqlCmd.CommandType = CommandType.Text;
                SqlCmd.ExecuteNonQuery();

                // The Transaction was successfull
                myTrans.Commit();

                return true;

            }
            catch (Exception e)
            {
                try
                {
                    myTrans.Rollback();
                }
                catch (SqlException ex)
                {
                    if (myTrans.Connection != null)
                    {
                        Console.WriteLine("An exception of type " + ex.GetType() +
                        " was encountered while attempting to roll back the transaction.");
                    }
                }
                Console.WriteLine("An exception of type " + e.GetType() + " was encountered while inserting the data.");
                Console.WriteLine("Neither record was written to database.");
            }
            finally
            {
                // Close connect
                if (_conn.State == ConnectionState.Open)
                    _conn.Close();
            }

            return false;
        }


    }
}
