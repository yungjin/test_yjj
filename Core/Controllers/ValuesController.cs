using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using Core.Modules;

namespace Core.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        [HttpGet]
        public ActionResult<ArrayList> Get()
        {
            MYsql my = new MYsql();
            string sql = "select * from test;";
            ArrayList list = new ArrayList();
            MySqlDataReader sdr = my.Reader(sql);
            while(sdr.Read()) // 행 반복
            {
                Hashtable ht = new Hashtable(); // 열 담기
                for(int i = 0; i < sdr.FieldCount; i++)
                {
                    ht.Add(sdr.GetName(i), sdr.GetValue(i));
                }
                list.Add(ht);
            }
            return list;
        }

        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

    }
}
