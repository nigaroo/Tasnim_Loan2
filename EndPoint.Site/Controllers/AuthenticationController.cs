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
using Tasnim_Loan.Application.Services.Customers.Commands.UserLogin;
using Tasnim_Loan.Application.Sevices.Customers.Commands.RegisterUser;

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
        /*
                [HttpGet]
                public IActionResult Signup()
                {
                    return View();
                }

                [HttpPost]
                public IActionResult Signup(SignupViewModel request)
                {
                    if (string.IsNullOrWhiteSpace(request.Name) ||
                        string.IsNullOrWhiteSpace(request.Password) ||
                        string.IsNullOrWhiteSpace(request.RePassword))
                    {
                        return Json(new ResultDto { IsSuccess = false, Message = "لطفا تمامی موارد رو ارسال نمایید" });
                    }

                    if (User.Identity.IsAuthenticated == true)
                    {
                        return Json(new ResultDto { IsSuccess = false, Message = "شما به حساب کاربری خود وارد شده اید! و در حال حاضر نمیتوانید ثبت نام مجدد نمایید" });
                    }
                    if (request.Pass != request.RePassword)
                    {
                        return Json(new ResultDto { IsSuccess = false, Message = "رمز عبور و تکرار آن برابر نیست" });
                    }
                    if (request.Pass.Length < 8)
                    {
                        return Json(new ResultDto { IsSuccess = false, Message = "رمز عبور باید حداقل 8 کاراکتر باشد" });
                    }



                    var signeupResult = _registerUserService.Execute(new RequestRegisterCustomerDto
                    {

                        Name = request.Name,
                        Password = request.Password,
                        RePasword = request.RePassword,

                    });

                    if (signeupResult.IsSuccess == true)
                    {
                        var claims = new List<Claim>()
                    {

                        new Claim(ClaimTypes.Username, request.Username),
                        new Claim(ClaimTypes.Pass, request.Pass),

                    };


                        var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                        var principal = new ClaimsPrincipal(identity);
                        var properties = new AuthenticationProperties()
                        {
                            IsPersistent = true
                        };
                       HttpContext.SignInAsync(principal, properties);

                    }
                    return Json(signeupResult);
                }

        */
        public IActionResult Signin(string ReturnUrl = "/")
        {
            ViewBag.url = ReturnUrl;
            return View();
        }

        [HttpPost]
        public IActionResult Signin(string Username, string Pass, string url = "/")
        {
            var signupResult = _userLoginService.Execute(Username, Pass);
            if (signupResult.IsSuccess == true)
            {
                var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.NameIdentifier,signupResult.Data.ID.ToString()),
                new Claim("Username", Username),
              
            };
                var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var principal = new ClaimsPrincipal(identity);
                var properties = new AuthenticationProperties()
                {
                    IsPersistent = true,
                    ExpiresUtc = DateTime.Now.AddDays(5),
                };
               HttpContext.SignInAsync(principal, properties);
            
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
