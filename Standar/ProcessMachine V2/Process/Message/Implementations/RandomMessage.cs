using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Standar;
namespace Standar.ProcessMachine_V2.Process.Message
{
    public class RandomMessage : MessageProcess<RandomMessageConfig>
    {
       
        public override MessageResult Execute()
        {
            MessageResult result = new MessageResult();
            RandomMessageConfig config = new RandomMessageConfig();
            if (configuration != null)
            {
                config = configuration.AsConfigurable();
            }
            else
            {
                config = parameters;
            }
            Random random = new Random();
            int index = random.Next(config.MessageResult.Count() - 1);
            result.Message = config.MessageResult.ToArray()[index];
            result.Delivered = config.canDeliver;
            return result;
        }
    }


    public class RandomMessageConfig
    {
        public List<Standar.Message>? MessageResult { get; set; }
        public bool canDeliver { get; set; }

    }
}
