using API.DAL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Modules
{
    [Route("back/api/[controller]")]
    [ApiController]
    public class DatabaseController : ControllerBase
    {
        private readonly DataContext dataContext;

        public DatabaseController(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }

        [HttpPost]
        public ActionResult RecreateDb()
        {
            dataContext.Init();

            return NoContent();
        }
    }
}
