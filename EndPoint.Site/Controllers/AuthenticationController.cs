using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Tasnim_Loan.Common.Dto;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Tasnim_Loan.Application.Services.Customers.Commands.RegisterUser;
using Tasnim_Loan.Application.Services.Customers.Commands.UserLogin;
using EndPoint.Site.Models.ViewModels.AuthenticationViewModel;
using Tasnim_Loan.Application.Singletons;

namespace EndPoint.Site.Controllers
{
    public class AuthenticationController : Controller
    {

        private readonly IRegisterCustomerService _registerUserService;
        private readonly IUserLoginService _userLoginService;

        public AuthenticationController(IRegisterCustomerService registerUserService, IUserLoginService userLoginService)
        {
            _registerUserService = registerUserService;
            _userLoginService = userLoginService;
        }

        [HttpGet]
        public IActionResult Signup()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Signup(SignupViewModel request)
        {
  


            if (string.IsNullOrWhiteSpace(request.FullName) ||
                string.IsNullOrWhiteSpace(request.Password) ||
                string.IsNullOrWhiteSpace(request.RePassword)||
                string.IsNullOrWhiteSpace(request.National_Number))
            {
                return Json(new ResultDto { IsSuccess = false, Message = "لطفا تمامی موارد رو ارسال نمایید" });
            }

            if (User.Identity.IsAuthenticated == true)
            {
                return Json(new ResultDto { IsSuccess = false, Message = "شما به حساب کاربری خود وارد شده اید! و در حال حاضر نمیتوانید ثبت نام مجدد نمایید" });
            }
            if (request.Password != request.RePassword)
            {
                return Json(new ResultDto { IsSuccess = false, Message = "رمز عبور و تکرار آن برابر نیست" });
            }
            if (request.Password.Length < 4)
            {
                return Json(new ResultDto { IsSuccess = false, Message = "رمز عبور باید حداقل 4 کاراکتر باشد" });
            }



            var signeupResult = _registerUserService.Execute(new RequestRegisterCustomerDto
            {

                FullName = request.FullName,
                Password = request.Password,
                RePasword = request.RePassword,
                National_Number = request.National_Number,
               // Unique_Payment_Identifier = 0,
                roles = new List<RolesInRegisterUserDto>()
                {
                    new RolesInRegisterUserDto { Id = 3},
                }

            });

            if (signeupResult.IsSuccess == true)
            {
                var claims = new List<Claim>()
                {
                 new Claim(ClaimTypes.NameIdentifier,signeupResult.Data.UserId.ToString()),
                 new Claim("NationalNumber", request.National_Number),
                 new Claim(ClaimTypes.Name, request.FullName),
                 new Claim(ClaimTypes.Role, "Customer"),
                };


                var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var principal = new ClaimsPrincipal(identity);
                var properties = new AuthenticationProperties()
                {
                    IsPersistent = true
                };
                HttpContext.SignInAsync(principal, properties);

                // Store the user ID using UserIdSingleton
                UserIdSingleton.Instance.SetUserId(signeupResult.Data.UserId);

            }
            return Json(signeupResult);
        }


        public IActionResult Signin(string ReturnUrl = "/")
        {
            ViewBag.url = ReturnUrl;
            return View();
        }

        [HttpPost]
        public IActionResult Signin(string Fullname, string Password,string url = "/")
        {
            var signupResult = _userLoginService.Execute(Fullname, Password);
            if (signupResult.IsSuccess == true)
            {
                var claims = new List<Claim>()
               {
                  new Claim(ClaimTypes.NameIdentifier,signupResult.Data.ID.ToString()),
                   new Claim("Fullname", Fullname),

               };
                var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var principal = new ClaimsPrincipal(identity);
                var properties = new AuthenticationProperties()
                {
                    IsPersistent = true,
                    ExpiresUtc = DateTime.Now.AddDays(5),
                };
                HttpContext.SignInAsync(principal, properties);

                // Store the user ID using UserIdSingleton
                UserIdSingleton.Instance.SetUserId(signupResult.Data.ID);

            }
            return Json(signupResult);
        }


        public IActionResult SignOut()
        {
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            return RedirectToAction("Index", "Home");
        }

    }
}
