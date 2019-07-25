using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using client.common;
using System.Configuration;

namespace client.web
{
    public class TelRecordService
    {
        /// <summary>
        /// 获取返回的通话记录
        /// </summary>
        /// <param name="postData"></param>
        /// <returns></returns>
        public telRecordResult getTelRecordResult(string postData)
        {
            //string postData = "{\"startDate\":\"2017-06-01\",\"endDate\":\"2017-06-07\"}"; -------eg
            return Tools.JsonToObject<telRecordResult>(web.PosService.WebPost(postData, ConfigurationManager.AppSettings["telRecordUrl"]));
        }
    }
}
