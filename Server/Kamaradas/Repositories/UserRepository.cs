using Kamaradas.Data;
using Kamaradas.Models;
using Kamaradas.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Kamaradas.Repositories
{
    public class UserRepository(KamaradasDBContext kamaradasDBContext) : IUserRepository
    {
        readonly KamaradasDBContext _dbContext = kamaradasDBContext;

        public async Task<List<UserModel>> FindAllUsers()
        {
            return await _dbContext.Users.ToListAsync();
        }

        public async Task<UserModel> FindPerCPF(string cpf)
        {
            var user = await _dbContext.Users.FirstOrDefaultAsync(x => x.CPF == cpf);

            if (user == null || string.IsNullOrEmpty(user.CPF))
            {
                throw new Exception("Usuário não encontrado");
            }

            return user;
        }

        public async Task<UserModel> FindPerID(int id)
        {
            var user = await _dbContext.Users.FirstOrDefaultAsync(x => x.ID == id);

            if (user == null || string.IsNullOrEmpty(user.CPF))
            {
                throw new Exception("Usuário não encontrado");
            }

            return user;
        }

        public async Task<UserModel> Register(string cpf, string password, string username)
        {
            UserModel oldUser = await _dbContext.Users.FirstOrDefaultAsync(x => x.CPF == cpf);

            if(oldUser != null)
            {
                throw new Exception("Usuário já registrado!");
            }

            UserModel user = new()
            {
                CPF = cpf,
                Code = "",
                Password = password,
                Username = username,
                Score = 0,
                ScoreToWithdraw = 0,
                LicenceID = 0,
                Dad_1 = "",
                Dad_2 = "",
                Dad_3 = "",
                Dad_4 = "",
                Dad_5 = "",
                Dad_6 = "",
                Dad_7 = ""
            };

            await _dbContext.Users.AddAsync(user);
            await _dbContext.SaveChangesAsync();

            string code = await GenereteCode(cpf);
            user.Code = code;

            _dbContext.Users.Update(user);
            await _dbContext.SaveChangesAsync();

            return user;
        }

        public async Task<UserModel> Login(string cpf, string password)
        {
            UserModel user = await FindPerCPF(cpf);

            if(user.Password == password)
            {
                return user;
            }

            throw new Exception("A senha informada não coincide com a registrada no servidor");
        }

        public async Task<UserModel> EnterInviteCode(string cpf, string code)
        {
            UserModel user = await FindPerCPF(cpf);
            UserModel dadUser = await FindPerCPF(await GetCPFPerCode(code));

            if(dadUser.LicenceID <= 0)
            {
                throw new Exception($"Não é possível adicionar o código de {dadUser.Username}");
            }

            user.Dad_1 = dadUser.CPF;
            user.Dad_2 = dadUser.Dad_1;
            user.Dad_3 = dadUser.Dad_2;
            user.Dad_4 = dadUser.Dad_3;
            user.Dad_5 = dadUser.Dad_4;
            user.Dad_6 = dadUser.Dad_5;
            user.Dad_7 = dadUser.Dad_6;

            _dbContext.Users.Update(user);
            await _dbContext.SaveChangesAsync();

            return user;
        }

        public async Task<string> GenereteCode(string cpf)
        {
            UserModel user = await FindPerCPF(cpf);

            string code = $"{(user.ID * 21)}{user.CPF.Substring(0, 3)}";

            return code;
        }

        public async Task<string> GetCPFPerCode(string code)
        {
            string idPart = code.Substring(0, code.Length - 3);
            int.TryParse(idPart, out int multipliedId);
            int id = multipliedId / 21;

            UserModel user = await FindPerID(id);

            return user.CPF;
        }

        public async Task<UserModel> TryPurchaseLicence(string cpf, int licenceID)
        {
            UserModel user = await FindPerCPF(cpf);

            if (user == null)
            {
                throw new Exception("Usuário não encontrado");
            }

            int licencePrice = GetLicencePricePerID(licenceID);

            if (user.Score < licencePrice)
            {
                throw new Exception("Dinheiro insuficiente");
            }

            if (user.LicenceID >= licenceID)
            {
                throw new Exception("Licença igual ou inferior a sua licença atual");
            }

            user.Score -= licencePrice;
            user.LicenceID = licenceID;

            if (!string.IsNullOrEmpty(user.Dad_1))
            {
                var dad = await FindPerCPF(user.Dad_1);

                if (dad != null)
                {
                    dad.Score += (int)Math.Round(licencePrice * 0.3);
                    _dbContext.Users.Update(dad);
                }
            }

            if (!string.IsNullOrEmpty(user.Dad_2))
            {
                var dad = await FindPerCPF(user.Dad_2);

                if (dad != null)
                {
                    dad.Score += (int)Math.Round(licencePrice * 0.12);
                    _dbContext.Users.Update(dad);
                }
            }

            if (!string.IsNullOrEmpty(user.Dad_3))
            {
                var dad = await FindPerCPF(user.Dad_3);

                if (dad != null)
                {
                    dad.Score += (int)Math.Round(licencePrice * 0.06);
                    _dbContext.Users.Update(dad);
                }
            }

            if (!string.IsNullOrEmpty(user.Dad_4))
            {
                var dad = await FindPerCPF(user.Dad_4);

                if (dad != null)
                {
                    dad.Score += (int)Math.Round(licencePrice * 0.03);
                    _dbContext.Users.Update(dad);
                }
            }

            if (!string.IsNullOrEmpty(user.Dad_5))
            {
                var dad = await FindPerCPF(user.Dad_5);

                if (dad != null)
                {
                    dad.Score += (int)Math.Round(licencePrice * 0.02);
                    _dbContext.Users.Update(dad);
                }
            }

            if (!string.IsNullOrEmpty(user.Dad_6))
            {
                var dad = await FindPerCPF(user.Dad_6);

                if (dad != null)
                {
                    dad.Score += (int)Math.Round(licencePrice * 0.01);
                    _dbContext.Users.Update(dad);
                }
            }

            if (!string.IsNullOrEmpty(user.Dad_7))
            {
                var dad = await FindPerCPF(user.Dad_7);

                if (dad != null)
                {
                    dad.Score += (int)Math.Round(licencePrice * 0.01);
                    _dbContext.Users.Update(dad);
                }
            }

            _dbContext.Users.Update(user);
            await _dbContext.SaveChangesAsync();

            return user;
        }

        int GetLicencePricePerID(int licenceID)
        {
            switch (licenceID)
            {
                case 1:
                    return 1990;   // R$ 19,90 (entrada mais fácil)
                case 2:
                    return 3990;   // R$ 39,90 (sensação de upgrade barato)
                case 3:
                    return 7990;   // R$ 79,90 (quebra do 100)
                case 4:
                    return 19990;  // R$ 199,90 (ancoragem forte)
                case 5:
                    return 39990;  // R$ 399,90 (premium mais realista)
                default:
                    return 0;
            }
        }
    }
}