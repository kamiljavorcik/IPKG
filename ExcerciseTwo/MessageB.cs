using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcerciseTwo
{
    public abstract class MessageB : IMessage
    {
        public void MyCustomMethod()
        {
            this.MyCustomMethodOnB();
            this.SomeAdditionaMethodOnB();
        }

        public abstract void MyCustomMethodOnB();
        public abstract void SomeAdditionaMethodOnB();

    }
}
