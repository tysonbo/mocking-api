using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CodeJellyApi.Models;
using CodeJellyApi.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CodeJellyApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MocksController : ControllerBase
    {
        // GET: api/Mocks
        [HttpGet]
        public List<Mock> Get()
        {
            List<Mock> mock = new List<Mock>();
            MockService mockService = new MockService();
            mock = mockService.GetAllMocks();

            return mock;
        }

        // GET: api/Mocks/Fred
        [HttpGet("{name}", Name = "Get")]
        public ActionResult Get([FromRoute] string name)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            Mock mock = new Mock();
            MockService mockService = new MockService();
            mock = mockService.GetMockbyName(name);

            if (mock == null)
            {
                return NotFound();
            }

            return Ok(mock);
        }

        // POST: api/Mocks
        [HttpPost]
        public ActionResult PostMock(Mock mock)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            MockService mockService = new MockService();
            mockService.AddMock(mock);

            return CreatedAtAction("GetMock", new { id = mock.Name }, mock);
        }

        //    // PUT: api/Mocks/5
        //    [HttpPut("{id}")]
        //    public void Put(int id, [FromBody] string value)
        //    {
        //    }

        //    // DELETE: api/ApiWithActions/mike
        [HttpDelete("{name}")]
        public ActionResult DeleteMock([FromRoute] string name)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Mock mock = new Mock();
            MockService mockService = new MockService();
            mock = mockService.GetMockbyName(name);
            if (mock == null)
            {
                return NotFound();
            }

            mockService.DeleteEntryFromDatabase(name);

            return Ok(mock);
        }
    }
}
