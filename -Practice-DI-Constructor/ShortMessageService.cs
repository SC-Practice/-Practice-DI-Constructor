using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _Practice_DI_Constructor
{
    public class ShortMessageService
    {
        public void Send(User user, string msg)
        {
            // 發送簡訊給指定的user (略)
            Console.WriteLine(" 發送 **簡訊** 給使用者，訊息內容：" + msg);
        }
    }
}
