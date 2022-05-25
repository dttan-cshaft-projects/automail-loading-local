using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace DAO
{
    public class DBConnect
    {

        // // 147.121.56.227 (AU_AVERY)
        protected MySqlConnection _conn = new MySqlConnection("server=147.121.56.227;user=autoload_data;pwd=DATAELS&Auto@{2022};database=au_avery;Connect Timeout=10000;charset=utf8;convertzerodatetime=true;");

        //protected MySqlConnection _conn = new MySqlConnection("server=147.121.73.3;user=planning;pwd=PELS&Auto@{2020};database=avery;Connect Timeout=10000;charset=utf8;convertzerodatetime=true;");

    }
}