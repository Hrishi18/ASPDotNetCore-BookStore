using BookStore.Models;
using BookStore.Repository;
using BookStore.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Controllers
{
    public class HomeController : Controller
    {
        private readonly NewBookAlertConfig _newBookAlertConfiguration;
        private readonly NewBookAlertConfig _thirdPartyBookConfiguration;
        private readonly IMessageRepository _messageRepository;
        private readonly IUserService _userService;
        private readonly IEmailService _emailService;

        public HomeController(IOptionsSnapshot<NewBookAlertConfig> newBookAlertConfiguration, IMessageRepository messageRepository, IUserService userService, IEmailService emailService)
        {
            _newBookAlertConfiguration = newBookAlertConfiguration.Get("InternalBook");
            _thirdPartyBookConfiguration = newBookAlertConfiguration.Get("ThirdPartyBook");
            _messageRepository = messageRepository;
            _userService = userService;
            _emailService = emailService;
        }
        public async Task<ViewResult> Index()
        {
            UserEmailOptions options = new UserEmailOptions
            {
                ToEmails = new List<string>() { "test@gmail.com" },
                PlaceHolders = new List<KeyValuePair<string, string>>()
                {
                    new KeyValuePair<string, string>("{{UserName}}", "John")
                }
            };
            await _emailService.SendTestEmail(options);
            /* var userID = _userService.GetUserID();
             var isLoggedIn = _userService.IsAuthenticated();
             bool isDisplay = _newBookAlertConfiguration.DisplayNewBookAlert;
             bool isDisplay1 = _thirdPartyBookConfiguration.DisplayNewBookAlert;*/
            // var value = _messageRepository.GetName();

            /*var newBook = configuration.GetSection("NewBookAlert");
            var result = newBook.GetValue<bool>("DisplayNewBookAlert");
            var bookName = newBook.GetValue<string>("BookName");*/


            //var result = configuration["AppName"];
            //var key1 = configuration["infoObj:key1"];
            //var key2 = configuration["infoObj:key2"];
            //var key3 = configuration["infoObj:key3:key3obj1"];
            return View();
        }

        public ViewResult AboutUs()
        {
            return View();
        }

        [Authorize(Roles = "Admin")]
        public ViewResult ContactUs()
        {
            return View();
        }



    }
}
