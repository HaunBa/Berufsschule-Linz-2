using Arztpraxis.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Arztpraxis.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiagnoseController : ControllerBase
    {
        public DiagnoseController(ApplicationDbContext db)
        {
            Db = db;
        }

        public ApplicationDbContext Db { get; }

        [HttpGet("{svnr}/{startdate}/{enddate}")]
        public async Task GetTerminData(int svnr, DateTime startdate, DateTime enddate)
        {
            var termine = Db.Termine.Include(x => x.Patient).Include(x => x.Diagnose).Where(x => x.Patient.svnr == svnr && x.Beginn >= startdate && x.Ende <= enddate).ToList();
            await HttpContext.Response.WriteAsJsonAsync(termine);
        }
    }
}
