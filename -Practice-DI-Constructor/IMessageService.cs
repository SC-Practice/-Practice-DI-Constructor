using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _Practice_DI_Constructor
{
    public interface IMessageService
    {
        void Send(User user, string msg);
    }
}
