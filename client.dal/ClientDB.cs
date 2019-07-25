#region Auto-generated classes for clientdb database on 2017-06-11 19:38:26Z

//
//  ____  _     __  __      _        _
// |  _ \| |__ |  \/  | ___| |_ __ _| |
// | | | | '_ \| |\/| |/ _ \ __/ _` | |
// | |_| | |_) | |  | |  __/ || (_| | |
// |____/|_.__/|_|  |_|\___|\__\__,_|_|
//
// Auto-generated from clientdb on 2017-06-11 19:38:26Z
// Please visit http://linq.to/db for more information

#endregion

using System;
using System.Data;
using System.Data.Linq.Mapping;
using System.Diagnostics;
using System.Reflection;
using DbLinq.Data.Linq;
using DbLinq.Vendor;
using System.ComponentModel;

namespace client.dal
{
	public partial class ClientDb : DataContext
	{
		public ClientDb(IDbConnection connection)
		: base(connection, new DbLinq.Sqlite.SqliteVendor())
		{
		}

		public ClientDb(IDbConnection connection, IVendor vendor)
		: base(connection, vendor)
		{
		}

		public Table<ConFig> ConFig { get { return GetTable<ConFig>(); } }
		public Table<Record> Record { get { return GetTable<Record>(); } }
		public Table<User> User { get { return GetTable<User>(); } }

	}

	[Table(Name = "main.config")]
	public partial class ConFig : INotifyPropertyChanged
	{
		#region INotifyPropertyChanged handling

		public event PropertyChangedEventHandler PropertyChanged;

		protected virtual void OnPropertyChanged(string propertyName)
		{
			if (PropertyChanged != null)
			{
				PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}

		#endregion

		#region string ID

		private string _id;
		[DebuggerNonUserCode]
		[Column(Storage = "_id", Name = "id", DbType = "TEXT(50)", IsPrimaryKey = true, CanBeNull = false)]
		public string ID
		{
			get
			{
				return _id;
			}
			set
			{
				if (value != _id)
				{
					_id = value;
					OnPropertyChanged("ID");
				}
			}
		}

		#endregion

		#region string Key

		private string _key;
		[DebuggerNonUserCode]
		[Column(Storage = "_key", Name = "key", DbType = "TEXT(50)")]
		public string Key
		{
			get
			{
				return _key;
			}
			set
			{
				if (value != _key)
				{
					_key = value;
					OnPropertyChanged("Key");
				}
			}
		}

		#endregion

		#region string Value

		private string _value;
		[DebuggerNonUserCode]
		[Column(Storage = "_value", Name = "value", DbType = "TEXT(500)")]
		public string Value
		{
			get
			{
				return _value;
			}
			set
			{
				if (value != _value)
				{
					_value = value;
					OnPropertyChanged("Value");
				}
			}
		}

		#endregion

		#region ctor

		public ConFig()
		{
		}

		#endregion

	}

	[Table(Name = "main.record")]
	public partial class Record : INotifyPropertyChanged
	{
		#region INotifyPropertyChanged handling

		public event PropertyChangedEventHandler PropertyChanged;

		protected virtual void OnPropertyChanged(string propertyName)
		{
			if (PropertyChanged != null)
			{
				PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}

		#endregion

		#region string CallTTnO

		private string _callTtNO;
		[DebuggerNonUserCode]
		[Column(Storage = "_callTtNO", Name = "callttno", DbType = "TEXT(50)")]
		public string CallTTnO
		{
			get
			{
				return _callTtNO;
			}
			set
			{
				if (value != _callTtNO)
				{
					_callTtNO = value;
					OnPropertyChanged("CallTTnO");
				}
			}
		}

		#endregion

		#region DateTime? Downtime

		private DateTime? _downtime;
		[DebuggerNonUserCode]
		[Column(Storage = "_downtime", Name = "downtime", DbType = "DATETIME(50)")]
		public DateTime? Downtime
		{
			get
			{
				return _downtime;
			}
			set
			{
				if (value != _downtime)
				{
					_downtime = value;
					OnPropertyChanged("Downtime");
				}
			}
		}

		#endregion

		#region string ID

		private string _id;
		[DebuggerNonUserCode]
		[Column(Storage = "_id", Name = "id", DbType = "TEXT(30)", IsPrimaryKey = true, CanBeNull = false)]
		public string ID
		{
			get
			{
				return _id;
			}
			set
			{
				if (value != _id)
				{
					_id = value;
					OnPropertyChanged("ID");
				}
			}
		}

		#endregion

		#region string MD5

		private string _md5;
		[DebuggerNonUserCode]
		[Column(Storage = "_md5", Name = "md5", DbType = "TEXT(50)")]
		public string MD5
		{
			get
			{
				return _md5;
			}
			set
			{
				if (value != _md5)
				{
					_md5 = value;
					OnPropertyChanged("MD5");
				}
			}
		}

		#endregion

		#region string Path

		private string _path;
		[DebuggerNonUserCode]
		[Column(Storage = "_path", Name = "path", DbType = "TEXT(500)")]
		public string Path
		{
			get
			{
				return _path;
			}
			set
			{
				if (value != _path)
				{
					_path = value;
					OnPropertyChanged("Path");
				}
			}
		}

		#endregion

		#region string StartTime

		private string _startTime;
		[DebuggerNonUserCode]
		[Column(Storage = "_startTime", Name = "starttime", DbType = "TEXT(50)")]
		public string StartTime
		{
			get
			{
				return _startTime;
			}
			set
			{
				if (value != _startTime)
				{
					_startTime = value;
					OnPropertyChanged("StartTime");
				}
			}
		}

		#endregion

		#region string URL

		private string _url;
		[DebuggerNonUserCode]
		[Column(Storage = "_url", Name = "url", DbType = "TEXT(500)")]
		public string URL
		{
			get
			{
				return _url;
			}
			set
			{
				if (value != _url)
				{
					_url = value;
					OnPropertyChanged("URL");
				}
			}
		}

		#endregion

		#region ctor

		public Record()
		{
		}

		#endregion

	}

	[Table(Name = "main.\"user\"")]
	public partial class User : INotifyPropertyChanged
	{
		#region INotifyPropertyChanged handling

		public event PropertyChangedEventHandler PropertyChanged;

		protected virtual void OnPropertyChanged(string propertyName)
		{
			if (PropertyChanged != null)
			{
				PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}

		#endregion

		#region string Account

		private string _account;
		[DebuggerNonUserCode]
		[Column(Storage = "_account", Name = "account", DbType = "TEXT(50)")]
		public string Account
		{
			get
			{
				return _account;
			}
			set
			{
				if (value != _account)
				{
					_account = value;
					OnPropertyChanged("Account");
				}
			}
		}

		#endregion

		#region int ID

		private int _id;
		[DebuggerNonUserCode]
		[Column(Storage = "_id", Name = "id", DbType = "INTEGER", IsPrimaryKey = true, IsDbGenerated = true, CanBeNull = false)]
		public int ID
		{
			get
			{
				return _id;
			}
			set
			{
				if (value != _id)
				{
					_id = value;
					OnPropertyChanged("ID");
				}
			}
		}

		#endregion

		#region string PwD

		private string _pwD;
		[DebuggerNonUserCode]
		[Column(Storage = "_pwD", Name = "pwd", DbType = "TEXT(50)")]
		public string PwD
		{
			get
			{
				return _pwD;
			}
			set
			{
				if (value != _pwD)
				{
					_pwD = value;
					OnPropertyChanged("PwD");
				}
			}
		}

		#endregion

		#region ctor

		public User()
		{
		}

		#endregion

	}
}
