using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

namespace client.web
{
  public  class TokenInfo
    {
      private static TokenInfo _instance = null;
      private Token _token = null;

      public static Token TokenEd
      {
          get { return GetInstance()._token; }
          set { GetInstance()._token = value; }
      }
        private string _app_id;
        public static string app_id
        {
            get { return GetInstance()._app_id; }
            set { GetInstance()._app_id = value; }
        }
        private string _app_secret;
        public static string app_secret
        {
            get { return GetInstance()._app_secret; }
            set { GetInstance()._app_secret = value; }
        }
        private DateTime _tokenDateTime;

      public static DateTime TokenDateTime
      {
          get { return GetInstance()._tokenDateTime; }
          set { GetInstance()._tokenDateTime = value; }
      }

         /// <summary>
         /// 取得实例
         /// </summary>
         /// <returns>实例</returns>
         [MethodImpl(MethodImplOptions.Synchronized)]
         public static TokenInfo GetInstance()
         {
             if (_instance == null)
             {
                 _instance = new TokenInfo();
             }
             return _instance;
         }
    }
}
