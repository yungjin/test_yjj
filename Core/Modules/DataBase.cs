using System;
using MySql.Data.MySqlClient;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Core.Modules
{
    public class MYsql 
    {
        private MySqlConnection conn;

        public MYsql()
        {
            this.conn = GetConnection();
        }
        public MySqlConnection GetConnection()
        {

            try
            {
                MySqlConnection conn = new MySqlConnection();

                string path = "/public/DBInfo.json";
                string result = new StreamReader(File.OpenRead(path)).ReadToEnd();
                JObject jo = JsonConvert.DeserializeObject<JObject>(result);
                Hashtable map = new Hashtable();
                foreach (JProperty col in jo.Properties())
                {
                    Console.WriteLine("{0} : {1}", col.Name, col.Value);
                    map.Add(col.Name, col.Value);
                }

                string strConnection
                    = string.Format("server={0};user={1};password={2};database={3};", map["server"], map["user"], map["password"], map["database"]);
                conn.ConnectionString = strConnection;
                conn.Open();

                return conn;
            }
            catch (MySqlException e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }
        public bool ConnectionClose()
        {
            try
            {
                conn.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool NonQuery(string sql)
        {
            try
            {
                if (conn != null)
                {
                    MySqlCommand comm = new MySqlCommand(sql, conn);
                    comm.ExecuteNonQuery();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }

        public MySqlDataReader Reader(string sql)
        {
            try
            {
                if (conn != null)
                {
                    MySqlCommand comm = new MySqlCommand(sql, conn);
                    return comm.ExecuteReader();
                }
                else
                {
                    return null;
                }
            }
            catch
            {
                return null;
            }
        }

        public void ReaderClose(MySqlDataReader reader)
        {
            reader.Close();
        }
    }
}