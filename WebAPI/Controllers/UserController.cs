using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        private readonly IEmailSender _emailSender;
        public UserController(IEmailSender emailSender)
        {
            _emailSender = emailSender;
        }

        [HttpGet("Public")]
        public IActionResult Public ()
        {
            return Ok("Hi, you are in public property !");
        }


        [HttpGet("Admins")]
        [Authorize(Roles = "Administrator")]
        public IActionResult AdminsEndpoint()
        {
            var currentUser = GetCurrentUser();
            //string email = _emailSender.SendEmail("send an Email");
            return Ok($"you are {currentUser.UserName}" +
                $" and your role is {currentUser.Role} and the" +
                $" message is "); // add email here
        }

        [HttpGet("Sellers")]
        [Authorize(Roles = "Student")]
        public IActionResult SellersEndpoint()
        {
            var currentUser = GetCurrentUser();
            return Ok($"you are {currentUser.UserName} and your role is " +
                $"{currentUser.Role} and your given name is {currentUser.GivenName}" +
                $" and your sure name is {currentUser.SureName} and " +
                $"your email is {currentUser.EmailAddress}");
        }

        //another endpoint for admin & seller together
        [HttpGet("Admins&Teachers")]
        [Authorize(Roles = "Administrator,Teacher")]
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
                    ClaimTypes.NameIdentifier)?.Value,
                    EmailAddress = userClaim.FirstOrDefault(u => u.Type ==
                    ClaimTypes.Email)?.Value,
                    GivenName = userClaim.FirstOrDefault(u => u.Type ==
                    ClaimTypes.GivenName)?.Value,
                    SureName = userClaim.FirstOrDefault(u => u.Type ==
                    ClaimTypes.Surname)?.Value,
                    Role = userClaim.FirstOrDefault(u => u.Type ==
                    ClaimTypes.Role)?.Value,



                };
            }

            return null;
        }





    }
}
