using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ExitMemoComments.Services;
using ExitMemoComments.ViewModels;
using Microsoft.AspNetCore.Authorization;
using ExitMemoComments.Models;



// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace ExitMemoComments.API
{
    [Route("api/[controller]")]
    public class ExitMemoCommentsController : Controller
    {
        private ExitMemoCommentService _exitMemoCommentService;
        
        public ExitMemoCommentsController(ExitMemoCommentService exitMemoCommentService)
        {
            _exitMemoCommentService = exitMemoCommentService;
        } 

        // GET: api/values
        [HttpGet]
        public IList<ExitMemoCommentVM> Get()
        {
            return _exitMemoCommentService.ListAllExitMemoComments();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public IList<ExitMemoCommentVM> Get(string id)
        {
            return _exitMemoCommentService.ListExitMemoComments(id);
        }

        // POST api/values
        [HttpPost("{id}")]
        public IActionResult Post(string id, [FromBody]ExitMemoComment newExitMemoComment)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(this.ModelState);
            }

            if (newExitMemoComment.Narrative == "")
            {
                return NotFound();
            }

            else
            {
                _exitMemoCommentService.AddNewExitMemoComment(id, newExitMemoComment);
                return Ok(newExitMemoComment);
            }

        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
