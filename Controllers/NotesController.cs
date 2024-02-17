using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class NotesController : ControllerBase
    {
        private DevNotesContext _context;
        public NotesController(DevNotesContext notesContext) => this._context = notesContext;

        [HttpPost]
        [Route("Save")]
        public async Task<IActionResult> Save(Note note)
        {

            bool userExists = _context.Users.Any(user => user.Id == note.UserId);
            if (userExists == false)
                return BadRequest("Invalid User..");

            _context.Notes.Add(note);
            try
            {
                int result = await _context.SaveChangesAsync();
                return Ok(result);
            }
            catch (System.Exception e)
            {
                StringBuilder sb = new StringBuilder();
                var curr = e;
                while (curr != null)
                {
                    sb.AppendLine(curr.Message);
                    curr = curr.InnerException;
                }
                return BadRequest(sb.ToString());

            }

        }

        [HttpGet]
        [Route("GetAll")]
        public async Task<IActionResult> GetAll(int UserId)
        {
            bool userExists = _context.Users.Any(user => user.Id == UserId);

            if (userExists == false)
                return BadRequest("Invalid User");

            var notes =
               _context
              .Notes
              .Where(note => note.UserId == UserId);

            return Ok(notes);

        }
    }


}