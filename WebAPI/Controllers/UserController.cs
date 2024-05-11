using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using WebAPI.Models;
using WebAPI.Services;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        private readonly IEmailSenderService _emailSender;
        public UserController(IEmailSenderService emailSender)
        {
            _emailSender = emailSender;
        }

        [HttpGet("Public")]
        public IActionResult Public ()
        {
            return Ok("Hi, you are in public area !");
        }


        [HttpGet("Admins")]
        [Authorize(Roles = "Administrator")]
        public IActionResult AdminsEndpoint()
        {
            var currentUser = GetCurrentUser();
            string email = _emailSender.SendEmail("send an Email");
            return Ok($"you are {currentUser.UserName}" +
                $" and your role is {currentUser.Role} and the" +
                $" message is {email}"); 
        }

        [HttpGet("Sellers")]
        [Authorize(Roles = "Seller")]
        public IActionResult SellersEndpoint()
        {
            var currentUser = GetCurrentUser();
            return Ok($"you are {currentUser.UserName} and your role is " +
                $"{currentUser.Role} and your given name is {currentUser.GivenName}" +
                $" and your sure name is {currentUser.SureName} and " +
                $"your email is {currentUser.EmailAddress}");
        }

        //another endpoint for admin & seller together
        [HttpGet("Admins&Sellers")]
        [Authorize(Roles = "Administrator,Seller")]
        public IActionResult AdminsAndSellersEndpoin()
        {
            var currentUser = GetCurrentUser();
            return Ok($"you are a {currentUser.Role} and your name is " +
                $"{currentUser.UserName}");
        }




        private UserModel GetCurrentUser()
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;

            if (identity != null)
            {
                var userClaim = identity.Claims;

                return new UserModel
                {

                    UserName = userClaim.FirstOrDefault(u => u.Type ==
                    ClaimTypes.NameIdentifier)?.Value ?? "Schahraad",
                    EmailAddress = userClaim.FirstOrDefault(u => u.Type ==
                    ClaimTypes.Email)?.Value ?? "schahrad@gmail.com",
                    GivenName = userClaim.FirstOrDefault(u => u.Type ==
                    ClaimTypes.GivenName)?.Value ?? "schahrad",
                    SureName = userClaim.FirstOrDefault(u => u.Type ==
                    ClaimTypes.Surname)?.Value ?? "mahidan",
                    Role = userClaim.FirstOrDefault(u => u.Type ==
                    ClaimTypes.Role)?.Value ?? "Administrator",

                };
            }

            return null;
        }





    }
}
