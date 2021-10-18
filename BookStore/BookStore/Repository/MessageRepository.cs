using BookStore.Models;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Repository
{
    public class MessageRepository : IMessageRepository
    {

        private NewBookAlertConfig _newBookAlertConfiguration;
        public MessageRepository(IOptionsMonitor<NewBookAlertConfig> newBookAlertConfiguration)
        {
            _newBookAlertConfiguration = newBookAlertConfiguration.CurrentValue;
            newBookAlertConfiguration.OnChange(config =>
            {
                _newBookAlertConfiguration = config;
            });
        }

        public string GetName()
        {
            return _newBookAlertConfiguration.BookName;
        }
    }
}
