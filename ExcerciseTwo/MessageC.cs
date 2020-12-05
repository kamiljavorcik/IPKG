using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcerciseTwo
{
    public abstract class MessageC : IMessage
    {
        public void MyCustomMethod()
        {
            this.MyCustomMethodOnC();
        }

        public abstract void MyCustomMethodOnC();
    }
}
