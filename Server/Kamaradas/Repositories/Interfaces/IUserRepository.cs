using Kamaradas.Models;

namespace Kamaradas.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task<List<UserModel>> FindAllUsers();
        Task<UserModel> FindPerCPF(string cpf);

        Task<UserModel> Register(string cpf, string password, string username);
        Task<UserModel> Login(string cpf, string password);
        Task<UserModel> EnterInviteCode(string cpf, string code);
        Task<UserModel> TryPurchaseLicence(string cpf, int licenceID);
    }
}
