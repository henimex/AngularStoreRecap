using Microsoft.AspNetCore.Mvc;
using Repo.Data;

namespace API.Controllers
{
    public class BuggyController : BaseApiController
    {
        private readonly StoreContext _context;
        public BuggyController(StoreContext context)
        {
            _context = context;
        }

        [HttpGet("not-found")]
        public ActionResult GetNotFound()
        {
            var thing = _context.Products.Find(60);
            if (thing == null)
            {
                return NotFound();
            }
            return Ok();
        }

        [HttpGet("server-error")]
        public ActionResult GetServerError()
        {
            var thing = _context.Products.Find(60);
            var returnVal = thing.ToString();
            return Ok();
        }

        [HttpGet("bad-request")]
        public ActionResult GetBadRequest()
        {
            return BadRequest();
        }

        [HttpGet("bad-request/{id}")]
        public ActionResult ValidateBadRequest(int id)
        {
            return Ok();
        }
    }
}