namespace smartpos.wpos.App.Components.UserDefined.MessageBox
{
    /// <summary>
    /// Message Code
    /// </summary>
    public enum MessageBoxCodes
    {
        #region Common
        /// <summary>
        /// 初始化数据库链接失败，请检查网络连接。
        /// </summary>
        COMMON001,
        /// <summary>
        /// 获取已安装产品信息时失败，请检查SystemConfig文件是否存在。
        /// </summary>
        COMMON002,
        /// <summary>
        ///  {0}成功
        /// </summary>
        COMMON006,
        /// <summary>
        ///  {0}失败
        /// </summary>
        COMMON007,
        /// <summary>
        ///  请输入正确的{0}
        /// </summary>
        COMMON008,
        /// <summary>
        ///  查无数据
        /// </summary>
        COMMON009,
        /// <summary>
        /// 有效期至应该大于有效期起
        /// </summary>
        COMMON010,
        /// <summary>
        /// 无需进行此操作。
        /// </summary>
        COMMON011,
        /// <summary>
        /// 网络连接异常，无法进行该操作。
        /// </summary>
        COMMON012,
        /// <summary>
        /// 保存数据失败
        /// </summary>
        COMMON013,
        /// <summary>
        /// 您确定作废此笔数据？
        /// </summary>
        COMMON014,
        /// <summary>
        /// 侦查中...
        /// </summary>
        COMMON020,
        /// <summary>
        /// 未连接打印机。
        /// </summary>
        COMMON021,
        /// <summary>
        /// 未打开电源。
        /// </summary>
        COMMON022,
        /// <summary>
        /// 打印机正忙。
        /// </summary>
        COMMON023,
        /// <summary>
        /// 出纸。
        /// </summary>
        COMMON024,

        #endregion

        #region Authentication
        /// <summary>
        /// {0}不能为空。
        /// </summary>
        AUTH001,
        /// <summary>
        /// 登录失败。
        /// </summary>
        AUTH002,
        /// <summary>
        /// 必填项
        /// </summary>
        AUTH003,
        /// <summary>
        /// 两次密码输入不一样
        /// </summary>
        AUTH004,
        /// <summary>
        /// 编辑失败
        /// </summary>
        AUTH005,
        /// <summary>
        ///  注册失败。
        /// </summary>
        AUTH006,
        /// <summary>
        ///  POS系统注册成功
        /// </summary>
        AUTH007,
        /// <summary>
        ///  {0} --用于提问 todo
        /// </summary>
        AUTH009,
        /// <summary>
        ///  用户密码不正确。
        /// </summary>
        AUTH011,
        /// <summary>
        ///  无效的用户名。
        /// </summary>
        AUTH012,
        /// <summary>
        ///  无效的企业标识。
        /// </summary>
        AUTH013,
        /// <summary>
        ///  无法访问惠管家云后台。
        /// </summary>
        AUTH014,
        /// <summary>
        /// 无法登录至惠管家，您确定切换至离线模式？
        /// </summary>
        AUTH015,
        /// <summary>
        /// 数据同步失败，你确定继续登录吗？
        /// </summary>
        AUTH016,
        /// <summary>
        /// 无法连接惠管家，您检查网络或联系管理员？
        /// </summary>
        AUTH017,
        /// <summary>
        /// 您确定退出系统？
        /// </summary>
        AUTH018,
        /// <summary>
        /// 您确定退出系统并切换用户？
        /// </summary>
        AUTH019,
        /// <summary>
        /// 启动主画面失败
        /// </summary>
        AUTH020,
        #endregion

        #region Main
        /// <summary>
        /// 主程序运行时发生错误：{0}
        /// </summary>
        MAIN001,
        /// <summary>
        /// 致命错误，Main画面运行异常：{0}
        /// </summary>
        MAIN002,
        /// <summary>
        /// 你确定要关闭所有已经打开的{0}个工具么?
        /// </summary>
        MAIN003,



        #endregion

        #region Configuration

        #region Config Part
        /// <summary>
        /// 打开配置画面时发生错误：{0}
        /// </summary>
        CONFIG001,
        /// <summary>
        /// 保存配置项目时发生错误：{0}
        /// </summary>
        CONFIG002,

        #endregion
        #region UserView


        #endregion

        #endregion

        #region Components

        #region AccessControl
        /// <summary>
        /// 权限验证失败
        /// </summary>
        ACCESS001,
        /// <summary>
        /// 授权验证失败
        /// </summary>
        ACCESS002,
        /// <summary>
        /// 授权失败
        /// </summary>
        ACCESS003,
        #endregion

        #region Query Component
        /// <summary>
        /// 检索错误：{0}
        /// </summary>
        QUERY001,
        #endregion --Query Component

        #region Retail
        /// <summary>
        /// 打开收银台失败
        /// </summary>
        RETAIL001,
        /// <summary>
        /// 无法取得条码：{0}
        /// </summary>
        RETAIL002,
        /// <summary>
        /// 单品打折失败
        /// </summary>
        RETAIL003,
        /// <summary>
        /// 设为赠品失败
        /// </summary>
        RETAIL004,
        /// <summary>
        /// 删除单品失败
        /// </summary>
        RETAIL005,
        /// <summary>
        /// 输入的折扣率不正确
        /// </summary>
        RETAIL006,
        /// <summary>
        /// 输入的折扣额不正确
        /// </summary>
        RETAIL007,
        /// <summary>
        /// 您确定删除此销售单吗?
        /// </summary>
        RETAIL008,
        /// <summary>
        /// 请选择商品！
        /// </summary>
        RETAIL009,
        /// <summary>
        /// 数据存储失败！
        /// </summary>
        RETAIL010,
        /// <summary>
        /// 请处理完当前销售单方可退出。
        /// </summary>
        RETAIL011,
        /// <summary>
        /// 请收款完毕方可退出。
        /// </summary>
        RETAIL012,
        /// <summary>
        /// 退出收银台失败
        /// </summary>
        RETAIL013,
        /// <summary>
        /// 收银台按键失败
        /// </summary>
        RETAIL014,
        /// <summary>
        /// 有{0}笔销售单处于挂单状态，你确定退出收银台吗？
        /// </summary>
        RETAIL015,
        /// <summary>
        /// 查询销售单失败
        /// </summary>
        RETAIL016,
        /// <summary>
        /// 查询销售单明细失败
        /// </summary>
        RETAIL017,
        /// <summary>
        /// 查询收款明细失败
        /// </summary>
        RETAIL018,
        /// <summary>
        /// 添加商品失败
        /// </summary>
        RETAIL019,
        /// <summary>
        /// 更新商品列表失败
        /// </summary>
        RETAIL020,
        /// <summary>
        /// 更新收款信息失败
        /// </summary>
        RETAIL021,
        /// <summary>
        /// 挂单失败
        /// </summary>
        RETAIL022,
        /// <summary>
        /// 解挂失败
        /// </summary>
        RETAIL023,
        /// <summary>
        /// 整单打折失败
        /// </summary>
        RETAIL024,
        /// <summary>
        /// 收款失败
        /// </summary>
        RETAIL025,
        /// <summary>
        /// 选择{0}数据
        /// </summary>
        RETAIL026,
        /// <summary>
        /// 打印失败
        /// </summary>
        RETAIL027,
        /// <summary>
        /// {0}应小于或等于{1}。
        /// </summary>
        RETAIL028,
        /// <summary>
        /// {0}应大于或等于{1}。
        /// </summary>
        RETAIL029,
        /// <summary>
        /// 更改商品数量失败。
        /// </summary>
        RETAIL030,
        /// <summary>
        /// {0}
        /// </summary>
        RETAIL031,
        /// <summary>
        /// 请查询确认订金信息。
        /// </summary>
        RETAIL032,
        /// <summary>
        /// 您确定收款吗？
        /// </summary>
        RETAIL033,
        /// <summary>
        /// 查询订金信息失败
        /// </summary>
        RETAIL034,
        /// <summary>
        /// 订金支付失败
        /// </summary>
        RETAIL035,
        /// <summary>
        /// 此订金单据已被使用。
        /// </summary>
        RETAIL036,
        /// <summary>
        /// 未录入营业员，您是否需要录入？
        /// </summary>
        RETAIL037,
        /// <summary>
        /// 更改商品销售价格失败。
        /// </summary>
        RETAIL038,

        /// <summary>
        /// 存在赠品数量不足。
        /// </summary>
        RETAIL039,
        #endregion

        #region Return
        /// <summary>
        /// 
        /// </summary>
        RETURN001,

        #endregion

        #region Product Component
        /// <summary>
        /// 无法载入商品的配置信息
        /// </summary>
        PRODUCT001,
        /// <summary>
        /// 检索商品信息出错
        /// </summary>
        PRODUCT002,
        #endregion -- Product Component

        #region Price Component
        /// <summary>
        /// 无法取得折扣价格。{0}
        /// </summary>
        PRICE000,
        /// <summary>
        /// 无法载入价格的配置信息
        /// </summary>
        PRICE001,
        /// <summary>
        /// 更新价格方案失败：{0}。
        /// </summary>
        PRICE002,
        /// <summary>
        /// 打开价格画面失败：{0}。
        /// </summary>
        PRICE003,
        /// <summary>
        /// 选择数据已经作废:{0}
        /// </summary>
        PRICE004,

        /// <summary>
        /// 请查询确认礼券信息
        /// </summary>
        VOUCHER001,
        /// <summary>
        /// 此礼券单据已被使用
        /// </summary>
        VOUCHER002,
        /// <summary>
        /// 礼券支付失败
        /// </summary>
        VOUCHER003,
        /// <summary>
        /// 查询礼券信息失败
        /// </summary>
        VOUCHER004,
        /// <summary>
        /// 礼券不在有效期内。
        /// </summary>
        VOUCHER005,
        #endregion -- Price Component

        #region System Setting
        /// <summary>
        /// 无法打开钱箱
        /// </summary>
        SETTING001,
        /// <summary>
        /// 打印小票失败
        /// </summary>
        SETTING002,
        /// <summary>
        /// 读取系统配置文件失败
        /// </summary>
        SETTING003,
        /// <summary>
        /// 保存系统配置文件失败
        /// </summary>
        SETTING004,
        /// <summary>
        /// 读取快捷键配置文件失败
        /// </summary>
        SETTING005,
        /// <summary>
        /// 保存快捷键配置文件失败
        /// </summary>
        SETTING006,
        /// <summary>
        /// 该系统目前处于{0}模式操作，你确定要切换到{1}模式下操作吗?
        /// </summary>
        SETTING007,
        /// <summary>
        /// 设备未连接
        /// </summary>
        SETTING010,
        #endregion

        #region Member
        /// <summary>
        /// 会员帐号不存在！
        /// </summary>
        MEMBER001,
        /// <summary>
        /// 会员卡密码错误！
        /// </summary>
        MEMBER002,
        /// <summary>
        /// 会员卡发行完毕！
        /// </summary>
        MEMBER003,
        /// <summary>
        /// 读卡正确
        /// </summary>
        MEMBER010,
        /// <summary>
        /// 读卡错误
        /// </summary>
        MEMBER011,
        /// <summary>
        /// 写卡正确
        /// </summary>
        MEMBER012,
        /// <summary>
        /// 写卡错误
        /// </summary>
        MEMBER013,
        /// <summary>
        /// 所选串行口打不开
        /// </summary>
        MEMBER014,
        /// <summary>
        /// 串口设置错误
        /// </summary>
        MEMBER015,



        /// <summary>
        /// 请选择待发行的会员
        /// </summary>
        MEMBER100,
        /// <summary>
        /// 该会员卡处于{0},无法使用。
        /// </summary>
        MEMBER101,

        #endregion

        #region Points
        /// <summary>
        /// 当前会员级别的积分规则已设置，您确定继续保存当前数据？
        /// </summary>
        POINTS001,
        /// <summary>
        /// 积分规则设置画面初始化失败
        /// </summary>
        POINTS002,
        /// <summary>
        /// 积分规则保存成功
        /// </summary>
        POINTS003,
        /// <summary>
        /// 积分规则保存失败
        /// </summary>
        POINTS004,
        /// <summary>
        /// 请输入积分规则
        /// </summary>
        POINTS005,
        /// <summary>
        /// 当前会员级别的积分规则已启用
        /// </summary>
        POINTS006,
        #endregion
        #endregion -- Components

        #region POS
        /// <summary>
        /// 画面初始化失败
        /// </summary>
        POS001,
        #endregion

        #region DAL

        Def,

        #region Web Service
        /// <summary>
        /// 数据库打开失败
        /// </summary>
        OpenFaild,
        /// <summary>
        /// 无此数据
        /// </summary>
        Empty,
        /// <summary>
        /// 企业Flag不存在
        /// </summary>
        EnterpriseFlagEmpty,
        /// <summary>
        /// 用户名不存在
        /// </summary>
        LoginNameEmpty,
        /// <summary>
        /// 用户密码错误
        /// </summary>
        PWDError,
        /// <summary>
        /// 数据重复
        /// </summary>
        Duplication,
        /// <summary>
        /// 数据已被修改
        /// </summary>
        Modified,
        /// <summary>
        /// 数据库异常
        /// </summary>
        DBError,
        /// <summary>
        /// 无权限
        /// </summary>
        NoPermission,
        /// <summary>
        /// 企业许可无效
        /// </summary>
        EnterLicenseInvalid,
        /// <summary>
        /// 用户许可无效
        /// </summary>
        EmpLicenseInvalid,
        /// <summary>
        /// POS机不可用。
        /// </summary>
        PosDisabled,
        /// <summary>
        /// POS系统版本需要更新
        /// </summary>
        NeedUpdateSystem,

        #endregion

        #region HTTP

        /// <summary>
        /// 无法连接网络
        /// </summary>
        ConnectFailure,
        /// <summary>
        /// 连接网络超时
        /// </summary>
        Timeout,
        /// <summary>
        /// 发送数据失败
        /// </summary>
        SendFailed,

        #endregion

        #region Transition exe

        /// <summary>
        /// DataAccess通讯失败
        /// </summary>
        CommunicationFailed,

        #endregion

        #region Sqlite


        #endregion

        #endregion

    }
}
