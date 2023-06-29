using MemoI.Recursos.Application.Dtos.Users;

namespace Memo1.Recursos.Application.Contracts.Services;

public interface IUserService
{
    Task<List<UserDto>> GetUsers();
}