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
    public class VnsoTotalDAO : DBConnect
    {
        private static string _Table = "vnso_total";

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

        // read all data
        public DataTable ReadAll()
        {
            if (_conn.State != ConnectionState.Open)
                _conn.Open();

            DataTable dt = new DataTable();
            try
            {
                var sql = "SELECT * FROM " + _Table + " ORDER BY ID DESC;";
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
        public int Add(string AutomailFile)
        {
            var count = 0;
            try
            {
                // connecting
                if (_conn.State != ConnectionState.Open)
                    _conn.Open();

                // (1st). Delete Duplicate Data in vn_so_total (sử dụng vòng lặp chạy 2 lần để xóa, có thể tăng hoặc giảm)
                for (int i = 0; i < 2; i++) DeleteDuplicate();
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

                // (2nd). After Insert. Delete Duplicate Data in vn_so_total (sử dụng vòng lặp chạy 2 lần để xóa, có thể tăng hoặc giảm)
                DeleteDuplicate();

                return count;
                // xóa file sau khi hoàn thành
                // File.Delete(DataFile);

            }
            catch (Exception e)
            {
                Console.WriteLine("An exception of type " + e.GetType() + " was encountered while inserting (1) the data " + _Table);
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
        public bool DeleteDuplicate()
        {
            MySqlTransaction myTrans = null;
            try
            {
                if (_conn.State != ConnectionState.Open)
                    _conn.Open();
                
                DataTable DuplicateTable = new DataTable();

                // Start a local transaction
                myTrans = _conn.BeginTransaction();
                
                MySqlCommand SqlCmd = new MySqlCommand();
                SqlCmd.Connection = _conn;

                SqlCmd.Transaction = myTrans; // khai báo transaction cho mysql command

                SqlCmd.CommandType = CommandType.Text;
                
                // Lấy tất cả các dữ liệu bị TRÙNG bằng Group by & Having (Chỉ lấy 1 ID trùng)
                string sql = "SELECT MIN(ID) AS ID FROM " + _Table + " GROUP BY ORDER_NUMBER, LINE_NUMBER, SHIPMENT_NUMBER HAVING COUNT(ID) > 1;";
                MySqlDataAdapter da = new MySqlDataAdapter(sql, _conn);
                da.Fill(DuplicateTable);

                // check trường hợp nếu không có dữ liệu trùng thì trả về true
                if (DuplicateTable.Rows.Count <= 0) return true;

                // Chuyển các ID trùng vào danh sách
                int index = 0;
                List<string> DuplicateList = new List<string>();
                foreach (DataRow data in DuplicateTable.Rows)
                {
                    index++;
                    // Đảm bảo danh sách < 1500 dòng (*)
                    if (DuplicateList.Count < 1500)
                    {
                        DuplicateList.Add(data["ID"].ToString()); // Thêm các ID vào danh sách để xóa
                    } 
                    else // Trường hợp danh sách vượt quá 1500 dòng thì xóa 1500 dòng hiện tại trong danh sách (**)
                    {
                        DuplicateList.Add(data["ID"].ToString()); // Thêm vào dòng thứ 1500
                        SqlCmd.CommandText = "DELETE FROM " + _Table + " WHERE ID IN ('" + String.Join("','", DuplicateList) + "');";

                        SqlCmd.Transaction = myTrans;

                        SqlCmd.ExecuteNonQuery(); // thực thi
                        DuplicateList.Clear(); // xóa danh sách hiện có (đã hoàn thành)
                    }
                }

                // Xóa trường hợp danh sách các ID trùng  < 1500 (*)
                if (DuplicateList.Count > 0)
                {
                    SqlCmd.CommandText = "DELETE FROM "  + _Table + " WHERE ID IN ('" + String.Join("','", DuplicateList) + "');";
                    SqlCmd.ExecuteNonQuery(); // thực thi
                    DuplicateList.Clear(); // xóa danh sách hiện có (đã hoàn thành)
                }

                //Console.Write(index.ToString() + " Duplicate lines deleted in VNSO_TOTAL...");

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
                        Console.WriteLine("An exception of type " + ex.GetType() + " was encountered while attempting to roll back the transaction.");
                    }
                }
                Console.WriteLine("An exception of type " + e.GetType() + " was encountered while deleting the data "+_Table);
                Console.WriteLine("Neither record was written to database.");
            }
            finally
            {
                // Close connect
                if (_conn.State == ConnectionState.Open)
                    _conn.Close();
            }

            return false; // Trường hợp không hoàn thành
        }

        


    }
}
