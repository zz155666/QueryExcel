using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace client.web
{
    public class PosServiceConfig
    {
        public static string PosHome { get; set; }
        public static string PosPicHome { get; set; }
        public static string PosServicePort { get; set; }

        /// <summary>
        /// 设备注册接口
        /// </summary>
        public static string PosRegisterUrl
        {
            get { return PosHome + PosServicePort + "/register"; }
        }

        /// <summary>
        /// 获取token接口
        /// </summary>
        public static string GetTokenUrl
        {
            get { return "http://open.workec.com/auth/accesstoken/"; }
        }

        public static string PosUpload = "upload";
        public static string PosCheck = "check";
        public static string PosDownload = "download";
        public static string PosSimuDownload = "simuDownload";
        public static string PosChange = "change";

        public static string PosApiVersionCheckUrl
        {
            get { return PosHome + PosServicePort + "/api/app"; }
        }

        public static string PosApiDataUrl
        {
            get { return PosHome + PosServicePort + "/api/data"; }
        }

        /// <summary>
        /// 保存订单接口
        /// </summary>
        public static string SaveTakeoutOrderByTelPosUrl
        {
            get { return PosHome + PosServicePort + "/o2o/saveTakeoutOrderByTelPOS"; }
        }

        /// <summary>
        /// 获取一定时间范围的订单
        /// </summary>
        public static string ListOrderInfoByTelPosUrl
        {
            get { return PosHome + PosServicePort + "/o2o/listOrderInfoByTelPOS"; }
        }

        /// <summary>
        /// 显示订单详情接口
        /// </summary>
        public static string ShowOrderDetailByTelPosUrl
        {
            get { return PosHome + PosServicePort + "/o2o/showOrderDetailByTelPOS"; }
        }

        /// <summary>
        /// 修改订单状态接口
        /// </summary>
        public static string ChangeOrderStatusByTelPosUrl
        {
            get { return PosHome + PosServicePort + "/o2o/changeOrderStatusByTelPOS"; }
        }

        /// <summary>
        /// 修改订单支付状态
        /// </summary>
        public static string ChangePayStatusByTelPosUrl
        {
            get { return PosHome + PosServicePort + "/o2o/changePayStatusByTelPOS"; }
        }


        public static string PosPayUrl
        {
            get { return PosHome + PosServicePort + "/api/pay"; }
        }

        public static string PosBranchUrl
        {
            get { return PosHome + PosServicePort + "/api/branch"; }
        }

        public static string PosVipUrl
        {
            get
            {
                return PosHome + PosServicePort + "/api/vip";
            }
        }

        public static string PosApiMessageUrl
        {
            get { return PosHome + PosServicePort + "/api/message"; }
        }

        public static string VipStoreUrl
        {
            get { return PosHome + PosServicePort + "/o2o/vipStore"; }
        }

        public static string QryVipByIdUrl
        {
            get { return PosHome + PosServicePort + "/o2o/qryVipById"; }
        }

        public static string QryStoreRuleUrl
        {
            get { return PosHome + PosServicePort + "/o2o/qryStoreRule"; }
        }

        public static string UploadVipGlideUrl
        {
            get { return PosHome + PosServicePort + "/o2o/uploadVipGlide"; }
        }

        public static int OrderStatusOrdered = 1;
        public static int OrderStatusHaveOrder = 2;
        public static int OrderStatusDelivering = 3;
        public static int OrderStatusDelivered = 4;
        public static int OrderStatusServed = 5;
        public static int OrderStatusFinish = 6;
        public static int OrderStatusSelfPickup = 7;
        public static int OrderStatusQueue = 8;
        public static int OrderStatusRefuse = 9;
        /// <summary>
        /// 日志上传
        /// </summary>
        public static string PosApiLogUrl
        {
            get { return PosHome + PosServicePort + "/api/log"; }
        }

        public static string PosSetUrl
        {
            get { return PosHome + PosServicePort + "/api/set"; }
        }

        public static string RsaUrl
        {
            get { return PosHome + PosServicePort + "/api/ic"; }
        }

        public static string SmsUrl
        {
            get { return PosHome + PosServicePort + "/api/sms"; }
        }
        /// <summary>
        /// POS服务转发地址
        /// </summary>
        public static string PosServices
        {
            get { return PosHome + PosServicePort + "/api/proxy"; }
        }

        public static string RedisSet
        {
            get { return PosHome + PosServicePort + "/api/cache/set"; }
        }

        public static string RedisGet
        {
            get { return PosHome + PosServicePort + "/api/cache/get"; }
        }
    }
}
