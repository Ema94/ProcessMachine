using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Standar.ProcessMachine_V2.Process.Message.Implementations.Configuration
{
    public static class MessagerRandomConfig
    {
        public static IConfigurable<RandomMessageConfig> AddRandomMessage(this IConfigurable<RandomMessageConfig> service, string messages)
        {
            RandomMessageConfig result = service.AsConfigurable();
            if (result.MessageResult == null)
            {
                result.MessageResult = new List<Standar.Message>();
            }
            result.MessageResult.Add(new Standar.Message()
            {
                Value = messages,
            });
            return service;
        }
    }
}
