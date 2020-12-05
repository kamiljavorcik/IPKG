using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcerciseTwo
{
    public class Before
    {

        public void function(object message)
        {
            if (message is MessageA)
            {
                var messageA = message as MessageA;
                messageA?.MyCustomMethodOnA();
            }
            else if (message is MessageB)
            {
                var messageB = message as MessageB;
                messageB?.MyCustomMethodOnB();
                messageB?.SomeAdditionaMethodOnB();
            }
            else if (message is MessageC)
            {
                var messageC = message as MessageC;
                messageC?.MyCustomMethodOnC();
            }
        }

    }
}
