using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _Practice_DI_Constructor
{
    class Program
    {
        static void Main(string[] args)
        {
            Login("", "", messageSendType: "Email"); //messageSendType: 1.Email 2.簡訊

            Console.Read();
        }

        public static void Login(string userId, string password, string messageSendType)
        {
            // 非 DI 版本用 new 的方式 new 出物件
            // var authService = new AuthenticationService();


            IMessageService msgService = null;

            // 這裡可以輕易抽換, 有實作 IMessageService 的類別
            switch (messageSendType)
            {
                case "Email":
                    msgService = new EmailService();
                    break;
                case "簡訊":
                    msgService = new ShortMessageService();
                    break;


                default:
                    throw new ArgumentException(" 無效的訊息服務型別!");
            }


            var authService = new AuthenticationService(msgService);

            #region 使用 authService 物件進行驗證判斷
            if (authService.TwoFactorLogin(userId, password))
            {
                if (authService.VerifyToken("123456"))
                {
                    // 登入成功。
                    Console.WriteLine("登入成功");
                    return;

                }
            }

            // 登入失敗。
            Console.WriteLine("登入失敗");
            #endregion            
        }    
    }
}
