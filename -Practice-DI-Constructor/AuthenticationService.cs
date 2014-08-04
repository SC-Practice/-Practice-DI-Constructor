using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _Practice_DI_Constructor
{
    class AuthenticationService
    {
        //private EmailService msgService;
        private ShortMessageService msgService;
        public AuthenticationService()
        {
            //msgService = new EmailService(); // 建立用來發送驗證碼的物件
            msgService = new ShortMessageService(); // 修改使用簡訊類別來建立類別
        }

        #region 驗證的副程式
        public bool TwoFactorLogin(string userId, string pwd)
        {
            // 檢查帳號密碼，若正確，則傳回一個包含使用者資訊的物件。
            User user = CheckPassword(userId, pwd);
            if (user != null)
            {
                // 接著發送驗證碼給使用者，假設隨機產生的驗證碼為"123456"。
                this.msgService.Send(user, " 您的登入驗證碼為 123456");
                return true;
            }

            return false;
        }

        public bool VerifyToken(string verifyToken)
        {
            if (verifyToken == "123456")
            {
                return true;
            }

            return false;
        }

        private User CheckPassword(string userId, string pwd)
        {
            if (true)
            {
                return new User();
            }
        }
        #endregion
    }
}
