using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Apiuniversidade.DTO;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using Microsoft.Extensions.Logging;

namespace Apiuniversidade.Controllers
{
    [Route("[controller]")]
    public class AutorizaController : Controller
    {
        private readonly UserManager<IdentityUser> _useManager;
        private readonly SignInManager<IdentityUser> _signInManager;

        public AutorizaController(UserManager<IdentityUser> userManager, 
        SignInManager<IdentityUser> signInManager)
        {
            _useManager = userManager;
            _signInManager = signInManager;
        }
        
        [HttpGet]
            public ActionResult<string> Get(){
                return "AutorizaController :: Acessado em :"
                    + DateTime.Now.ToLongDateString();
            }

        [HttpPost("register")]
            public async Task<ActionResult> RegisterUser([FromBody]UsuarioDT0 model){
                var user = new IdentityUser{
                    UserName = model.Email,
                    Email = model.Email,
                    EmailConfirmed = true
                };

                var result = await _useManager.CreateAsync(user, model.Password);
                if(!result.Succeeded)
                    return BadRequest(result.Errors);

                await _signInManager.SignInAsync(user, false);
            }

        [HttpPost("login")]
            public async Task<ActionResult> Longin([FromBody]UsuarioDT0 userInfo){
                
                var result = await _signInManager.PasswordSignInAsync(userInfo.Email, userInfo.Password, isPersistent: false, lockoutOnFailure: false);
                
                if(result.Succeeded)
                    return Ok();

                else {
                    ModelState.AddModelError(string.Empty, "Login Inválido...");
                    return BadRequest(ModelState);
                }
        }

        private UsuarioToken GeraToken(UsuarioDT0 userInfo){

            var claims = new[]{
                new Claim(System.IdentityModel.Tokens.Jwt.JwtRegisteredClaimNames.UniqueName, userInfo.Email),
                new Claim("IFRN", "TecInfo"),
                new Claim(Microsoft.IdentityModel.JsonWebTokens.JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };
        }

    }
}