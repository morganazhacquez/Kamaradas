using Kamaradas.Data;
using Kamaradas.Models;
using Kamaradas.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Kamaradas.Repositories
{
    public class MoneyRepository(KamaradasDBContext kamaradasDBContext) : IMoneyRepository
    {
        readonly KamaradasDBContext _dbContext = kamaradasDBContext;

        public async Task<List<MoneyModel>> FindAllMonies()
        {
            return await _dbContext.Monies.ToListAsync();
        }

        public async Task<List<MoneyModel>> FindAllMoniesByCPF(string cpf)
        {
            return await _dbContext.Monies.Where(x => x.OwnerCPF == cpf).ToListAsync();
        }

        public async Task<MoneyModel> FindMoneyByID(int ID)
        {
            var money = await _dbContext.Monies.FirstOrDefaultAsync(x => x.ID == ID);

            if (money == null || string.IsNullOrEmpty(money.OwnerCPF))
            {
                throw new Exception("Tarefa não encontrada");
            }

            return money;
        }

        public async Task<List<MoneyModel>> FindMoniesByPrice(int score)
        {
            return await _dbContext.Monies.Where(x => x.Score == score && x.Finished == false).ToListAsync();
        }

        public async Task<MoneyModel> FindMoneyByPrice(int score)
        {
            List<MoneyModel> Monies = await FindMoniesByPrice(score);

            var money = Monies.Where(x => !string.IsNullOrEmpty(x.RequestDate)).OrderBy(x => x.RequestDate).FirstOrDefault();

            if(money == null)
            {
                throw new Exception("Nenhum registro encontrado");
            }

            return money;
        }

        public async Task<MoneyModel> AddMoneyRequest(string ownerCPF, int score, int type)
        {
            var user = await _dbContext.Users.FirstOrDefaultAsync(x => x.CPF == ownerCPF);

            if (user == null || string.IsNullOrEmpty(user.CPF))
            {
                throw new Exception("Usuário não encontrado");
            }

            if (type == 1)
            {
                if(user.Score < score)
                {
                    throw new Exception("Dinheiro para saque insuficiente");
                }
                else
                {
                    user.Score -= score;
                    user.ScoreToWithdraw += score;
                }
            }

            MoneyModel money = new()
            {
                OwnerCPF = ownerCPF,
                Score = score,
                Type = type,
                RequestDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                FinishDate = "Em andamento",
                Finished = false
            };

            _dbContext.Users.Update(user);
            await _dbContext.Monies.AddAsync(money);
            await _dbContext.SaveChangesAsync();

            return money;
        }

        public async Task<MoneyModel> UpdateMoneyRequest(int ID, int score, bool finished, bool sucess)
        {
            MoneyModel money = await FindMoneyByID(ID);
            UserModel user = await _dbContext.Users.FirstOrDefaultAsync(x => x.CPF == money.OwnerCPF);

            money.Score = score;
            money.Finished = finished;

            if (finished)
            {
                money.FinishDate = DateTime.Now.ToString();
            }

            if (sucess)
            {
                if(money.Type == 0) //deposito
                {
                    user.Score += score;
                }
                else if(money.Type == 1) //saque
                {
                    user.ScoreToWithdraw -= score;
                }
            }
            else
            {
                if(money.Type == 1)
                {
                    user.Score += score;
                    user.ScoreToWithdraw -= score;
                }
            }

            _dbContext.Users.Update(user);
            _dbContext.Monies.Update(money);
            await _dbContext.SaveChangesAsync();

            return money;
        }
    }
}