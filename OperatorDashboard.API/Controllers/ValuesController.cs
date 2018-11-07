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
        [HttpGet]
        public async Task<IActionResult> GetValues()
        {
            var values = await _context.ClientsLog.FromSql("select ClientsLog.Username,COUNT(CASE WHEN Action=4 then 1 end) AS AlarmsReceived, COUNT(CASE WHEN Action=3 then 1 end) AS AlarmsProcessed FROM CameraActions join ClientsLog on ClientsLog.Session=CameraActions.Session where DATEADD(HH, ROUND(DATEDIFF(n, CameraActions.StartTime, CameraActions.EndTime) / 60.1, 0), CameraActions.StartTime) between '2018-11-05 18:00:00' and  '2018-11-06 19:00:00' GROUP BY ClientsLog.Username").ToListAsync();

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
