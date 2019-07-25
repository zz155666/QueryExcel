using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace client.common
{
  public  class Tools
    {
        public static string ObjectToJson(object obj)
        {
            return JsonConvert.SerializeObject(obj);
        }
        /// <summary>
        /// 将Json转对象
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="jsonstring"></param>
        /// <returns></returns>
        public static T JsonToObject<T>(string jsonstring)
        {
            return JsonConvert.DeserializeObject<T>(jsonstring);
        }
        /// <summary>
        /// 直接取出json某一节点的值
        /// </summary>
        /// <param name="jsonStr"></param>
        /// <returns></returns>
        public static JObject JsonToJobject(string jsonStr)
        {
            return JObject.Parse(jsonStr);
        }
    }
}
