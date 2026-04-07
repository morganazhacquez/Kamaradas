using Kamaradas.Models;

namespace Kamaradas.Repositories.Interfaces
{
    public interface IMoneyRepository
    {
        Task<List<MoneyModel>> FindAllMonies();
        Task<List<MoneyModel>> FindAllMoniesByCPF(string cpf);
        Task<MoneyModel> FindMoneyByID(int ID);
        Task<MoneyModel> FindMoneyByPrice(int score);
        Task<List<MoneyModel>> FindMoniesByPrice(int score);
        Task<MoneyModel> AddMoneyRequest(string ownerCPF, int score, int type);
        Task<MoneyModel> UpdateMoneyRequest(int ID, int score, bool finished, bool sucess);
    }
}