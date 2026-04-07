using Kamaradas.Models;
using Kamaradas.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Kamaradas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController(IUserRepository userRepository) : ControllerBase
    {
        IUserRepository _userRepository = userRepository;

        [HttpGet("Find All Users")]
        public async Task<ActionResult<List<UserModel>>> FindAllUsers()
        {
            return Ok(await _userRepository.FindAllUsers());
        }

        [HttpGet("Find Per CPF")]
        public async Task<ActionResult<UserModel>> FindPerCPF(string cpf)
        {
            return Ok(await _userRepository.FindPerCPF(cpf));
        }

        [HttpGet("Register")]
        public async Task<ActionResult<UserModel>> Register(string cpf, string password, string username)
        {
            return Ok(await _userRepository.Register(cpf, password, username));
        }

        [HttpGet("Login")]
        public async Task<ActionResult<UserModel>> Login(string cpf, string password)
        {
            return Ok(await _userRepository.Login(cpf, password));
        }

        [HttpGet("Enter Invite Code")]
        public async Task<ActionResult<UserModel>> EnterInviteCode(string cpf, string inviteCode)
        {
            return Ok(await _userRepository.EnterInviteCode(cpf, inviteCode));
        }

        [HttpGet("Try Purchase Licence")]
        public async Task<ActionResult<UserModel>> TryPurchaseLicence(string cpf, int licenceID)
        {
            return Ok(await _userRepository.TryPurchaseLicence(cpf, licenceID));
        }
    }
}
