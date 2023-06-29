using Memo1.Recursos.Application.Contracts.Services;
using MemoI.Recursos.Application.Dtos.Users;
using Microsoft.AspNetCore.Mvc;

namespace Memo1.Recursos.API.Controllers.V1;

[Route("api/v1/users")]
[ApiController]
public class UserController : Controller
{
    private readonly IUserService _userService;

    public UserController(IUserService commentService)
    {
        _userService = commentService;
    }
    
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<List<UserDto>>> GetUsers()
    {
        return await _userService.GetUsers();
    }
}