

using Microsoft.AspNetCore.Mvc;
using Models.Dtos;



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

    [ProducesResponseType(typeof(NotFoundResult), 404)]
    public IActionResult GetAll()
    {
        IQueryable<UserDto>? users = _context
                        .Users?
                        .Select(ob => new UserDto { Email = ob.Email, Id = ob.Id, Name = ob.Name });

        if (users == null)
            return NotFound();

        return Ok(users);
    }


    [HttpPost]
    [Route("Save")]
    public async Task<IActionResult> Save(User user)
    {

        bool alreadyPresent = _context.Users.Any(u => u.Email.Equals(user.Email));

        if (alreadyPresent)
        {
            return BadRequest($"User with email : {user.Email} already exists.");
            // return await Task.FromResult(BadRequest($"User with email : {user.Email} already exists."));
        }

        _context.Users.Add(user);
        int result = await _context.SaveChangesAsync();
        return Ok(result);

    }
}