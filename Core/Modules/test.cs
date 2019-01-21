using System;
using MySql.Data.MySqlClient;
using System.Collections;

namespace Core.Modules 
{
    public class Test {
        public string nTitle { set; get; }
        public string nContents { set; get; }
        public string mName { set; get; }
        public int nNo { set; get; }
    }
    public static class Query 
    {

        public static ArrayList GetInsert(Test test)
        {
            MYsql my = new MYsql();
            string sql = string.Format("INSERT into Notice(mNo,nTitle,nContents)VALUES(5,'{0}','{1}')", test.nTitle, test.nContents);
            if(my.NonQuery(sql)){
                return GetSelect();
            }
            else
            {
                return new ArrayList();
            }
        }

        public static ArrayList inSelect()
        {
            MYsql my = new MYsql();
            string sql = "SELECT mNo From Member WHERE mName LIKE '%영진%';";
            MySqlDataReader sdr = my.Reader(sql);
            // string result = "";
            ArrayList list = new ArrayList();
            while(sdr.Read())
            {
                Hashtable ht = new Hashtable();
                for(int i = 0; i < sdr.FieldCount; i++)
                {
                    //result += string.Format("{0} : {1} ", sdr.GetName(i), sdr.GetValue(i));
                    ht.Add(sdr.GetName(i), sdr.GetValue(i));
                }
                //result += "\n";
                list.Add(ht);
            }
            return list;
        }

        public static ArrayList GetSelect()
        {
            MYsql my = new MYsql();
            string sql = "select n.nNo,n.nTitle,n.nContents,m.mName,DATE_FORMAT(n.regDate, '%Y-%m-%d') as regDate,DATE_FORMAT(n.modDate, '%Y-%m-%d') as modDate from Notice as n inner join Member as m on (n.mNo = m.mNo and m.delYn = 'N') where n.delYn = 'N';";
            MySqlDataReader sdr = my.Reader(sql);
            // string result = "";
            ArrayList list = new ArrayList();
            while(sdr.Read())
            {
                Hashtable ht = new Hashtable();
                for(int i = 0; i < sdr.FieldCount; i++)
                {
                    //result += string.Format("{0} : {1} ", sdr.GetName(i), sdr.GetValue(i));
                    ht.Add(sdr.GetName(i), sdr.GetValue(i));
                }
                //result += "\n";
                list.Add(ht);
            }
            return list;
        }

        public static ArrayList GetDelete(Test test)
        {
            MYsql my = new MYsql();
            string sql = string.Format("update Notice set delYn = 'Y' where nNo = {0}",test.nNo);
            if(my.NonQuery(sql))
            {
                return GetSelect();
            }
            else 
            {
                return new ArrayList();
            }
        }

        public static ArrayList GetUpdate(Test test)
        {
            MYsql my = new MYsql();
            string sql = string.Format("update Notice set nTitle = '{0}' ,nContents = '{1}' where nNo = {2}", test.nTitle, test.nContents,test.nNo);
            if(my.NonQuery(sql))
            {
                return GetSelect();
            }
            else 
            {
                return new ArrayList();
            }
        }

        // public static ArrayList LvClick(Test test)
        // {
        //     MYsql my = new MYsql();
        //     string sql = string.Format("update test set YN = 'Y' wher {0}",test.nNo);
        //     if(my.NonQuery(sql))
        //     {
        //         return GetSelect();
        //     }
        //     else 
        //     {
        //         return new ArrayList();
        //     }
        // }
    }
}