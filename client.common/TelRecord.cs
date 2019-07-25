using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace client.common
{
    [Serializable]
    public class TelRecord
    {
        private DateTime _starttime;
        private string _calltono;
        private int _calltime;
        private int _crmId;
        private int _type;
        private int _userId;
        private string _path;
        private string _customerName;
        private string _customerCompany;
        private string _md5;

        /// <summary>
        /// 开始时间
        /// </summary>
        public DateTime starttime
        {
            get { return _starttime; }
            set { _starttime = value; }
        }

        /// <summary>
        /// 通话号码
        /// </summary>
        public string calltono
        {
            get { return _calltono; }
            set { _calltono = value; }
        }

        /// <summary>
        /// 通话时长
        /// </summary>
        public int calltime
        {
            get { return _calltime; }
            set { _calltime = value; }
        }

        /// <summary>
        /// crmId
        /// </summary>
        public int crmId
        {
            get { return _crmId; }
            set { _crmId = value; }
        }

        /// <summary>
        /// 通话类型
        /// </summary>
        public int type
        {
            get { return _type; }
            set { _type = value; }
        }

        /// <summary>
        /// 用户Id
        /// </summary>
        public int userId
        {
            get { return _userId; }
            set { _userId = value; }
        }

        /// <summary>
        /// 路径
        /// </summary>
        public string path
        {
            get { return _path; }
            set { _path = value; }
        }

        /// <summary>
        /// 客户名称
        /// </summary>
        public string customerName
        {
            get { return _customerName; }
            set { _customerName = value; }
        }

        /// <summary>
        /// 客户单位
        /// </summary>
        public string customerCompany
        {
            get { return _customerCompany; }
            set { _customerCompany = value; }
        }

        /// <summary>
        /// MD5
        /// </summary>
        public string md5
        {
            get { return _md5; }
            set { _md5 = value; }
        }
    }

    /// <summary>
    /// telRecord数据
    /// </summary>
    public class telRecordData
    {
        private int _pageSize;
        private int _pageNo;
        private int _total;
        private int _maxPageNo;
        private int _startRow;
        private List<TelRecord> _result;

        /// <summary>
        /// 每页行数
        /// </summary>
        public int pageSize
        {
            get { return _pageSize; }
            set { _pageSize = value; }
        }


        /// <summary>
        /// 页码
        /// </summary>
        public int pageNo
        {
            get { return _pageNo; }
            set { _pageNo = value; }
        }

        /// <summary>
        /// 合计
        /// </summary>
        public int total
        {
            get { return _total; }
            set { _total = value; }
        }

        /// <summary>
        /// 最大页码
        /// </summary>
        public int maxPageNo
        {
            get { return _maxPageNo; }
            set { _maxPageNo = value; }
        }

        /// <summary>
        /// 开始行
        /// </summary>
        public int startRow
        {
            get { return _startRow; }
            set { _startRow = value; }
        }

        /// <summary>
        /// 结果集
        /// </summary>
        public List<TelRecord> result
        {
            get { return _result; }
            set { _result = value; }
        }
    }

    /// <summary>
    /// 返回结果
    /// </summary>
    public class telRecordResult
    {
        private string _errCode;
        private string _errMsg;
        private telRecordData _data;

        /// <summary>
        /// MD5
        /// </summary>
        public string errCode
        {
            get { return _errCode; }
            set { _errCode = value; }
        }

        /// <summary>
        /// MD5
        /// </summary>
        public string errMsg
        {
            get { return _errMsg; }
            set { _errMsg = value; }
        }

        /// <summary>
        /// MD5
        /// </summary>
        public telRecordData data
        {
            get { return _data; }
            set { _data = value; }
        }
    }
}
