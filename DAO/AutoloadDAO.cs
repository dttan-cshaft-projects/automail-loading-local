using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data; // DataTable
using MySql.Data.MySqlClient;
using DTO;

namespace DAO
{
    public class AutoloadDAO : DBConnect
    {
        private static string _Table = "autoload_log";
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
                Console.WriteLine(ex.ToString());
            }
            finally
            {
                if (_conn.State == ConnectionState.Open)
                    _conn.Close(); // close connection
            }

            return dt;
        }

        // read all data
        public DataTable ReadItem()
        {
            if (_conn.State != ConnectionState.Open)
                _conn.Open();

            DataTable dt = new DataTable();
            try
            {
                var sql = "SELECT * FROM " + _Table + " WHERE FUNC = 'AUTOMAIL' ORDER BY ID DESC LIMIT 1;";
                MySqlCommand Sqlcmd = new MySqlCommand(sql, _conn);
                dt.Load(Sqlcmd.ExecuteReader());
            }
            catch (Exception ex)
            {
                // xử lý lỗi tại đây
                Console.WriteLine(ex.ToString());
            }
            finally
            {
                if (_conn.State == ConnectionState.Open)
                    _conn.Close(); // close connection
            }

            return dt;
        }

        // add item
        public bool Add(AutoloadDTO Autoload)
        {
            try
            {
                // connecting
                _conn.Open();

                // Query string 
                string sql = "INSERT INTO " + _Table + "(DATE_YMD, TIME_HH, STATUS, LOGDATA, FUNC, EMPTY) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}')";
                string Query = string.Format(sql, Autoload.autoloadDateYMD, Autoload.autoloadTimeHH, Autoload.autoloadStatus, Autoload.autoloadLogData, Autoload.autoloadFunc, Autoload.autoloadEmpty);
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

        public bool Edit(AutoloadDTO Autoload)
        {
            try
            {
                // connecting
                _conn.Open();

                // Query string 
                string sql = "UPDATE " + _Table + " SET DATE_YMD={0}, TIME_HH={1}, STATUS={2}, LOGDATA={3}, FUNC={4}, EMPTY={5} WHERE ID={6} ";
                string Query = string.Format(sql, Autoload.autoloadDateYMD, Autoload.autoloadTimeHH, Autoload.autoloadStatus, Autoload.autoloadLogData, Autoload.autoloadFunc, Autoload.autoloadEmpty, Autoload.autoloadID);
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

        public bool Delete(AutoloadDTO Autoload)
        {
            try
            {
                // connecting
                _conn.Open();

                // Query string 
                string sql = "DELETE FROM " + _Table + " WHERE ID={0} ";
                string Query = string.Format(sql, Autoload.autoloadID);
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


    }
}
