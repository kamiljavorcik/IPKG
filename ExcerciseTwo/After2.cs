using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcerciseTwo
{
    public class After2
    {
        /*
         * added interface to cover same behavior
         */
        public void function(object message)
        {
            if (message is IMessage)
            {
                (message as IMessage).MyCustomMethod();
            }
        }

        public void function2(object message)
        {
            (message as IMessage)?.MyCustomMethod();   
        }

        public void function3(IMessage message)
        {
            message?.MyCustomMethod();
        }
    }
}
