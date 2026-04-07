using Kamaradas.Models;
using Kamaradas.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Kamaradas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoneyController(IMoneyRepository moneyRepository) : ControllerBase
    {
        IMoneyRepository _moneyRepository = moneyRepository;

        [HttpGet("Find All Monies")]
        public async Task<ActionResult<List<MoneyModel>>> FindAllMonies()
        {
            return Ok(await _moneyRepository.FindAllMonies());
        }

        [HttpGet("Find All Monies By CPF")]
        public async Task<ActionResult<List<MoneyModel>>> FindAllMoniesByCPF(string cpf)
        {
            return Ok(await _moneyRepository.FindAllMoniesByCPF(cpf));
        }

        [HttpGet("Find Money By ID")]
        public async Task<ActionResult<MoneyModel>> FindMoneyByID(int ID)
        {
            return Ok(await _moneyRepository.FindMoneyByID(ID));
        }

        [HttpGet("Find Monies By Price")]
        public async Task<ActionResult<List<MoneyModel>>> FindMoniesByPrice(int score)
        {
            return Ok(await _moneyRepository.FindMoniesByPrice(score));
        }

        [HttpGet("Find Money By Price")]
        public async Task<ActionResult<MoneyModel>> FindMoneyByPrice(int score)
        {
            return Ok(await _moneyRepository.FindMoneyByPrice(score));
        }

        [HttpGet("Add Money Request")]
        public async Task<ActionResult<MoneyModel>> AddMoneyRequest(string ownerCPF, int score, int type)
        {
            return Ok(await _moneyRepository.AddMoneyRequest(ownerCPF, score, type));
        }

        [HttpGet("Update Money Request")]
        public async Task<ActionResult<MoneyModel>> UpdateMoneyRequest(int ID, int score, bool finished, bool sucess)
        {
            return Ok(await _moneyRepository.UpdateMoneyRequest(ID, score, finished, sucess));
        }
    }
}
