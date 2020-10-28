using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using API.Models.Models;
using API.Services;
using IdentityModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using src.Models;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        public UserManager<ApplicationUser> _userManager;
        public SignInManager<ApplicationUser> _signInManager;
        public IUserRepo _userRepo;
        private IConfiguration _configuration;
        string PhotoPath = AppDomain.CurrentDomain.BaseDirectory + "images\\";

        public UsersController(UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager, IUserRepo userRepo,
            IConfiguration configuration)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _userRepo = userRepo;
            _configuration = configuration;
        }

        [HttpPost("PostNewUser")]
        public async Task<IActionResult> PostNewUser([FromBody]UserModel model)
        {
            if (model == null)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return new UnprocessableEntityObjectResult(ModelState);
            }

            var appUser = new ApplicationUser()
            {
                UserName = model.UserName,
                Email = model.Email,
                PhoneNumber = model.PhoneNumber,
                FirstName = model.FirstName,
                LastName = model.LastName,
                MiddleName = model.MiddleName,
                BirthDate = model.BirthDate
            };

            IdentityResult result = await _userManager.CreateAsync(appUser, model.Password);

            if (result.Succeeded)
            {
                var claims = new List<Claim>
                {
                    new Claim(JwtClaimTypes.WebSite, appUser.Id.ToString()),
                    new Claim(JwtClaimTypes.FamilyName, appUser.FirstName),
                    new Claim(JwtClaimTypes.GivenName, appUser.LastName),
                    new Claim("Email", appUser.Email)
                };

                await _userManager.AddClaimsAsync(appUser, claims);
            }

            return Ok(model);
        }
    }
}
