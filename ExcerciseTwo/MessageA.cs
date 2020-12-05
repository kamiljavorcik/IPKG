using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcerciseTwo
{
    public abstract class MessageA : IMessage
    {
        public void MyCustomMethod()
        {
            this.MyCustomMethodOnA();
        }

        public abstract void MyCustomMethodOnA();


    }
}
