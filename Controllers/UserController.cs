

using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{

    DevNotesContext _context;

    public UserController(DevNotesContext context)
    {
        this._context = context;
    }
    [HttpGet]
    [Route("GetAll")]

    [ProducesResponseType(typeof(NotFoundResult),404)]
    public IActionResult GetAll()
    {
        var users = _context.Users;
        if(users == null)
            return NotFound();
        
        return Ok(users);
    }
}