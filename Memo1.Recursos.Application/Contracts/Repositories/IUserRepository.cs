using Memo1.Recursos.Domain;

namespace Memo1.Recursos.Application.Contracts.Repositories;

public interface IUserRepository
{
    Task Add(User ticket);
}