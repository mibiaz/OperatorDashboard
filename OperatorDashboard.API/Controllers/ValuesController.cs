using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OperatorDashboard.API.Data;

namespace OperatorDashboard.API.Controllers
{
    // http://localhost:5000/api/values
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly DataContext _context;
        public ValuesController(DataContext context)
        {
            _context = context;

        }
        // GET api/values
        // DATEADD(HH, ROUND(DATEDIFF(n, CameraActions.StartTime, CameraActions.EndTime) / 60.1, 0), CameraActions.ReqStartTime) between '2018-11-05 18:00:00' and  '2018-11-06 05:59:00'
        // ca.ReqStartTime.AddHours(Math.Round(SqlServerDbFunctionsExtensions.DateDiffMinute(dfunc, ca.StartTime, ca.EndTime) / 60.1, 0))
        [HttpGet]
        public async Task<IActionResult> GetValues()
        {
            DbFunctions dfunc = null;
            DateTime dt1 = new DateTime(2018, 11, 09, 18, 00, 00);
            DateTime dt2 = new DateTime(2018, 11, 09, 19, 00, 00);
            var values = await (from ca in _context.CameraActions
                                join cl in _context.ClientsLog on ca.Session equals cl.Session         
                                where ca.StartTime.AddHours(Math.Round(SqlServerDbFunctionsExtensions.DateDiffMinute(dfunc, ca.StartTime, ca.EndTime) / 60.1, 0)) >= dt1 && ca.StartTime.AddHours(Math.Round(SqlServerDbFunctionsExtensions.DateDiffMinute(dfunc, ca.StartTime, ca.EndTime) / 60.1, 0)) <= dt2                                                           
                                select new { cl.Username, ca.Action} into x
                                group x by new {x.Username} into g
                                select new 
                                {
                                    Username = g.Key.Username,
                                    AlarmsReceived = g.Sum(x => x.Action == 4 ? 1 : 0),
                                    AlarmsProcessed = g.Sum(x => x.Action == 3 ? 1 : 0)
                                }).ToListAsync();
            return Ok(values);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetValue(int id)
        {
            var value = await _context.ClientsLog.FirstOrDefaultAsync(x => x.Session == id);

            return Ok(value);
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
