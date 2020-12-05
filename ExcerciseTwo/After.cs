using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcerciseTwo
{
    public class After
    {
        /*
         * passing multiple types is against single responsibility
         * it would be good to provide in MessageABC one interface
         * with call dedicated to this situation
         */
        public void function(object message)
        {
            if (message is MessageA)
            {
                process(message as MessageA);
            }
            else if (message is MessageB)
            {
                process(message as MessageB);
            }
            else if (message is MessageC)
            {
                process(message as MessageC);
            }
        }

        /*
         * Nullable is not necessary but in other situation should be good
         */
        public void process(MessageA message)
        {
            message?.MyCustomMethodOnA();
        }

        /*
         * calling separate methods is unintuitive
         * maybe chaining will be better
         * message?.MyCustomMethodOnB().SomeAdditionaMethodOnB();
         */
        public void process(MessageB message)
        {
            message?.MyCustomMethodOnB();
            message?.SomeAdditionaMethodOnB();
        }

        public void process(MessageC message)
        {
            message?.MyCustomMethodOnC();
        }
    }
}
