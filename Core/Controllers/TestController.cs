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
    
    [ApiController]
    public class TestController : ControllerBase
    {
        [Route("api/Select")]
        [HttpPost]
        public ActionResult<ArrayList> Select([FromForm] Test test)
        {
            return Query.GetSelect();
        }

        [Route("api/InSelect")]
        [HttpPost]
        public ActionResult<ArrayList> InSelect([FromForm] Test test)
        {
            return Query.inSelect();
        }

        // [Route("api/LvClick")]
        // [HttpPost]
        // public ActionResult<ArrayList> LvClick([FromForm] Test test)
        // {
        //     return Query.LvClick(test);
        // }

        
        [Route("api/Insert")]
        [HttpPost]
        public ActionResult<ArrayList> Insert([FromForm] Test test)
        {
            return Query.GetInsert(test);
        }

        [Route("api/Update")]
        [HttpPost]
        public ActionResult<ArrayList> Update([FromForm] Test test)
        {
            test.nNo = Convert.ToInt32(test.nNo);
            return Query.GetUpdate(test);
        }
        
        [Route("api/Delete")]
        [HttpPost]
        public ActionResult<ArrayList> Delete([FromForm] Test test)
        {
            test.nNo = Convert.ToInt32(test.nNo);
            return Query.GetDelete(test);
        }

    }
}
