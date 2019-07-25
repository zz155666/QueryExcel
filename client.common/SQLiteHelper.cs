using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SQLite;
using System.Reflection;
using System.IO;
using System.ComponentModel;

namespace client.common
{
    /// <summary>
    /// <para>概要：SQLite数据库访问类</para>
    /// </summary>
    public static class SQLiteHelper
    {    
        /// <summary> 
        /// 返回数据库链接字符串 YunJi.UI.dll 若加密需使用pwd
        /// </summary> 
        internal static string ConnString
        {

            //get { return string.Format("Data Source =\"{0}\";Password=\"{1}\";", DBPath, pwd); }
            get
            {
                //SystemInfo info = WanXiang.Common.Locator.ServiceLocator.CurrentSystemInfo;
                //if (info != null)
                //{
                //    if (info.Publish == SystemPublish.Dev)
                //    {
                //        return string.Format("Data Source =\"{0}\";", DBPath);
                //    }
                //    else
                //    {
                //        return string.Format("Data Source =\"{0}\";Password=\"{1}\";", DBPath, pwd);
                //    }
                //}
                //else
                //{
                //    return string.Format("Data Source =\"{0}\";Password=\"{1}\";", DBPath, pwd);
                //}

                return string.Format("Data Source =\"{0}\";", DBPathDebug);
            }
        }

        internal static string DBPath
        {
            get { return SystemFilePath.FilePathSqliteDB; }
        }

        internal static string DBPathDebug
        {
            get { return SystemFilePath.FilePathSqliteDBDebug; }
        }

        /**/
        /// <summary> 
        /// 执行SQL语句,返回受影响的行数 
        /// </summary> 
        /// <param name="cmdText">需要被执行的SQL语句</param> 
        /// <returns>受影响的行数</returns> 
        public static int ExecuteNonQuery(string cmdText)
        {
            return ExecuteNonQuery(ConnString, cmdText);
        }
        /**/
        /// <summary>
        /// 执行SQL语句,返回受影响的行数 
        /// </summary>
        /// <param name="cmdText">SQL语句</param>
        /// <param name="parameters">SQL的参数</param>
        /// <returns>受影响的行数</returns>
        internal static int ExecuteNonQuery(string cmdText, params SQLiteParameter[] parameters)
        {
            using (SQLiteConnection conn = new SQLiteConnection(ConnString))
            {
                return ExecuteNonQuery(conn, cmdText, parameters);
            }
        }       
        /// <summary> 
        /// 执行带有事务的SQL语句 
        /// </summary> 
        /// <param name="trans">事务</param> 
        /// <param name="cmdText">SQL语句</param> 
        /// <param name="parameters">SQL的参数</param> 
        /// <returns>受影响的行数</returns> 
        internal static int ExecuteNonQuery(SQLiteTransaction trans, string cmdText, params SQLiteParameter[] parameters)
        {
            int val = 0;
            using (SQLiteCommand cmd = new SQLiteCommand())
            {
                PrepareCommand(cmd, (SQLiteConnection)trans.Connection, trans, cmdText, parameters);
                val = cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();
            }
            return val;
        }
        /**/
        /// <summary> 
        /// 执行SQL语句,返回受影响的行数 
        /// </summary> 
        /// <param name="connString">连接字符串</param> 
        /// <param name="cmdText">SQL语句</param> 
        /// <param name="parameters">SQL的参数</param> 
        /// <returns>受影响的行数</returns> 
        internal static int ExecuteNonQuery(string connString, string cmdText, params SQLiteParameter[] parameters)
        {
            using (SQLiteConnection conn = new SQLiteConnection(connString))
            {
                return ExecuteNonQuery(conn, cmdText, parameters);
            }
        }
        /**/
        /// <summary> 
        /// 执行SQL语句,返回受影响的行数 
        /// </summary> 
        /// <param name="connection">数据库链接</param> 
        /// <param name="cmdText">SQL语句</param> 
        /// <param name="parameters">参数</param> 
        /// <returns>受影响的行数</returns> 
        internal static int ExecuteNonQuery(SQLiteConnection connection, string cmdText, params SQLiteParameter[] parameters)
        {
            int val = 0;
            using (SQLiteCommand cmd = new SQLiteCommand())
            {
                PrepareCommand(cmd, connection, null, cmdText, parameters);
                val = cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();
            }
            return val;
        }

         /// <summary>
         /// 批量处理方法
         /// </summary>
         /// <typeparam name="T"></typeparam>
         /// <param name="list"></param>
         /// <param name="cmdText"></param>
         /// <param name="isTran">true 失败回滚，false 保存成功笔数</param>
         /// <param name="parameters">参数，需和类属性一致</param>
         /// <returns></returns>
        internal static int ExecuteNonQueryBatch<T>(List<T> list, string cmdText,bool isTran, params SQLiteParameter[] parameters)
        {
            int val = 0;
            SQLiteConnection conn = null;
            SQLiteCommand cmd = null;
            SQLiteTransaction trans = null;
            string str = string.Empty;
            Type t = null;
            object value = null;
            NullableConverter nullableConverter = null;
            try
            {
                conn = new SQLiteConnection(ConnString);
                cmd = new SQLiteCommand();              
                PrepareCommand(cmd, conn, null , cmdText, null);
                trans = conn.BeginTransaction();
                foreach (T obj in list)
                {
                    try
                    {
                        t = obj.GetType(); 
                        if (null != parameters && parameters.Length > 0)
                        {
                            for (int i = 0; i < parameters.Length; i++)
                            {
                                str = parameters[i].ParameterName.Substring(1);
                                if (t.GetProperty(str).PropertyType.IsGenericType
                                    && t.GetProperty(str).PropertyType.GetGenericTypeDefinition() == typeof(Nullable<>))
                                {
                                    value = t.GetProperty(str).GetValue(obj, null);
                                    if (value != null)
                                    {
                                        nullableConverter = new NullableConverter(t.GetProperty(str).PropertyType);
                                        parameters[i].Value = Convert.ChangeType(value, nullableConverter.UnderlyingType);
                                    }
                                    else
                                    {
                                        parameters[i].Value = null;
                                    }
                                }
                                else
                                {
                                    switch (t.GetProperty(str).PropertyType.Name)
                                    {
                                        case "Guid":
                                            parameters[i].Value = new Guid(t.GetProperty(str).GetValue(obj, null).ToString());
                                            break;
                                        case "Boolean":
                                            if (t.GetProperty(str).GetValue(obj, null).ToString() == "True")
                                            {
                                                parameters[i].Value = 1;
                                            }
                                            else
                                            {
                                                parameters[i].Value = 0;
                                            }
                                            break;
                                        case "DateTime":
                                            object objDate = t.GetProperty(str).GetValue(obj, null);
                                            if (objDate != null)
                                            {
                                                parameters[i].Value = Convert.ToDateTime(objDate);
                                                //WXLog.Debug("ExecuteNonQueryBatch<T> ###DateTime for failed:" + objDate.ToString());
                                            }
                                            else
                                            {
                                                parameters[i].Value = DateTime.Now;
                                            }
                                            break;
                                        default:
                                            if (t.GetProperty(str).GetValue(obj, null) == null)
                                            {
                                                parameters[i].Value = "";
                                            }
                                            else
                                            {
                                                parameters[i].Value = t.GetProperty(str).GetValue(obj, null).ToString();
                                            }
                                            break;
                                    }
                                }
                            }
                            cmd.Parameters.AddRange(parameters);
                        }
                        val += cmd.ExecuteNonQuery();                     
                    }
                    catch(Exception ex)
                    {
                        WXLog.Error("ExecuteNonQueryBatch<T> for failed:", ex);
                        WXLog.Debug(cmdText + "**********" + str );
                       if(isTran)
                       {
                           trans.Rollback();
                       }
                    }
                }
                trans.Commit();
            }
            catch(Exception ex)
            {
                WXLog.Error("ExecuteNonQueryBatch<T> failed:", ex);
                WXLog.Debug(cmdText + "**********" + str);
                if (isTran)
                {
                    trans.Rollback();
                }              
                throw ex;
            }
            finally
            {
                if (conn != null) conn.Close();
            } 
            return val;
        }



        /**/
        /// <summary> 
        /// 执行查询,并返回结果集的第一行的第一列.其他所有的行和列被忽略. 
        /// </summary> 
        /// <param name="cmdText">SQL 语句</param> 
        /// <returns>第一行的第一列的值</returns> 
        internal static object ExecuteScalar(string cmdText)
        {
            return ExecuteScalar(ConnString, cmdText);
        }
        /**/
        /// <summary> 
        /// 执行查询,并返回结果集的第一行的第一列.其他所有的行和列被忽略. 
        /// </summary> 
        /// <param name="connString">连接字符串</param> 
        /// <param name="cmdText">SQL 语句</param> 
        /// <returns>第一行的第一列的值</returns> 
        internal static object ExecuteScalar(string connString, string cmdText)
        {
            using (SQLiteConnection conn = new SQLiteConnection(connString))
            {
                return ExecuteScalar(conn, cmdText);
            }
        }

        internal static object ExecuteScalar(string cmdText, params SQLiteParameter[] parameters)
        {
            using (SQLiteConnection conn = new SQLiteConnection(ConnString))
            {
                return ExecuteScalar(conn, cmdText, parameters);
            }
        }


        /**/
        /// <summary> 
        /// 执行查询,并返回结果集的第一行的第一列.其他所有的行和列被忽略. 
        /// </summary> 
        /// <param name="connection">数据库链接</param> 
        /// <param name="cmdText">SQL 语句</param> 
        /// <returns>第一行的第一列的值</returns> 
        /// <param name="parameters"></param>
        internal static object ExecuteScalar(SQLiteConnection connection, string cmdText, params SQLiteParameter[] parameters)
        {
            object val;
            using (SQLiteCommand cmd = new SQLiteCommand())
            {
                PrepareCommand(cmd, connection, null, cmdText, parameters);
                val = cmd.ExecuteScalar();
            }
            return val;
        }
        /**/
        /// <summary> 
        /// 执行SQL语句,返回结果集的DataReader 
        /// </summary> 
        /// <param name="cmdText">SQL语句</param> 
        /// <param name="parameters">参数</param> 
        /// <returns>结果集的DataReader</returns> 
        internal static SQLiteDataReader ExecuteReader(string cmdText, params SQLiteParameter[] parameters)
        {
            return ExecuteReader(ConnString, cmdText, parameters);
        }
        /**/
        /// <summary> 
        /// 执行SQL语句,返回结果集的DataReader 
        /// </summary> 
        /// <param name="connString">连接字符串</param> 
        /// <param name="cmdText">SQL语句</param> 
        /// <param name="parameters">参数</param> 
        /// <returns>结果集的DataReader</returns> 
        internal static SQLiteDataReader ExecuteReader(string connString, string cmdText, params SQLiteParameter[] parameters)
        {
            WXLog.Debug("性能Log，ExecuteReader Start");
            SQLiteConnection conn = null;
            SQLiteCommand cmd = null;
            SQLiteDataReader rdr = null;
            try
            {
                conn = new SQLiteConnection(connString);
                cmd = new SQLiteCommand();
                PrepareCommand(cmd, conn, null, cmdText, parameters);
                rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                cmd.Parameters.Clear();                
                return rdr;
            }
            catch (Exception ex)
            {
                conn.Close();
                WXLog.Error("ExecuteReader failed", ex);
                throw new Exception("ExecuteReader失败");
            }
            finally
            {
                WXLog.Debug("性能Log，ExecuteReader End");
            }
        }

        /// <summary>
        /// 执行查询
        /// </summary>
        /// <typeparam name="T">实体类</typeparam>        
        /// <param name="sql">查询语句</param>
        /// <param name="parameters">参数</param>
        /// <returns>查询结果</returns>
        public static List<T> Query<T>(string sql, params SQLiteParameter[] parameters)
        {
            WXLog.Debug("性能Log，Query<T> Start");
            List<T> list = new List<T>();
            SQLiteConnection conn = null;
            SQLiteCommand cmd = null;           
            SQLiteDataReader sdr = null;
            DataTable dtSchema = null;
            DataRow[] drs = null;
            object value = null;
            NullableConverter nullableConverter = null;
            T obj = default(T);
            PropertyInfo[] pinfo = null;

            try
            {
                conn = new SQLiteConnection(ConnString);
                cmd = new SQLiteCommand(); 
                PrepareCommand(cmd, conn, null, sql, parameters);
                sdr = cmd.ExecuteReader();
                dtSchema = sdr.GetSchemaTable(); 
                while (sdr.Read())
                {
                    obj = Activator.CreateInstance<T>(); //根据泛型实例化类对象
                    pinfo = typeof(T).GetProperties(BindingFlags.Public|BindingFlags.Instance);//甴類对象获得实体类的属性typeof(T).GetProperties()返回属性数组（PropertyInfo[]）                                
                    foreach (PropertyInfo pi in pinfo)
                    {
                        //1.根据薮据库查询的值给实体类属性赋值（pi.SetValue()）
                        drs = dtSchema.Select("ColumnName='" + pi.Name + "'");
                        if (drs.Length > 0)
                        {
                            int iOrdinal = Convert.ToInt32(drs[0][1]);                           
                            if (pi.PropertyType.IsGenericType
                                  && pi.PropertyType.GetGenericTypeDefinition() == typeof(Nullable<>))
                            {
                                //value = pi.GetValue(obj, null);  
                                if (sdr[pi.Name] is DBNull)
                                {
                                    pi.SetValue(obj, null, null);  
                                }
                                else
                                {
                                    value = sdr[pi.Name];
                                    if (value != null)
                                    {
                                        nullableConverter = new NullableConverter(pi.PropertyType);
                                        pi.SetValue(obj, Convert.ChangeType(value, nullableConverter.UnderlyingType), null);
                                    }
                                    else
                                    {
                                        pi.SetValue(obj, null, null);
                                    }
                                }                                 
                            }
                            else
                            {
                                if (pi.PropertyType.BaseType.Equals(typeof(System.Enum)))
                                {
                                    if (!sdr.IsDBNull(iOrdinal))
                                    {
                                        pi.SetValue(obj, Enum.Parse(pi.PropertyType, sdr[pi.Name].ToString()), null);
                                    }
                                }
                                else if (pi.PropertyType.Equals(typeof(System.Guid)))
                                {
                                    if (!sdr.IsDBNull(iOrdinal))
                                    {
                                        pi.SetValue(obj, new Guid(sdr[pi.Name].ToString()), null);
                                    }
                                    else
                                    {
                                        pi.SetValue(obj, Guid.Empty, null);
                                    }
                                }
                                else
                                {
                                    if (!sdr.IsDBNull(iOrdinal))
                                    {
                                        pi.SetValue(obj, Convert.ChangeType(sdr[pi.Name], pi.PropertyType), null);
                                    }
                                }
                            }                           
                        }
                    }
                    list.Add(obj);
                }
            }
            catch (Exception ex)
            {
                conn.Close();
                WXLog.Error("Query<T> failed", ex);
                throw new Exception("Query<T>失败");
            }            
            finally
            {
                if (conn != null) conn.Close();
                WXLog.Debug("性能Log，Query<T> End");
            }
            return list;
        }

        public static List<T> QueryMasterSub<T, U>(string sqlMaster, string sqlSub, string subpara, params SQLiteParameter[] parameters)
        {
            WXLog.Debug("性能Log，Query<T> Start");
            List<T> list = new List<T>();
            SQLiteConnection conn = null;
            SQLiteCommand cmd = null;
            SQLiteDataReader sdr = null;
            DataTable dtSchema = null;
            try
            {
                conn = new SQLiteConnection(ConnString);
                cmd = new SQLiteCommand();
                PrepareCommand(cmd, conn, null, sqlMaster, parameters);
                sdr = cmd.ExecuteReader();
                dtSchema = sdr.GetSchemaTable();
                while (sdr.Read())
                {
                    T obj = Activator.CreateInstance<T>(); //根据泛型实例化类对象
                    PropertyInfo[] pinfo = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);//甴類对象获得实体类的属性typeof(T).GetProperties()返回属性数组（PropertyInfo[]）                                
                    foreach (PropertyInfo pi in pinfo)
                    {
                        //1.根据薮据库查询的值给实体类属性赋值（pi.SetValue()）
                        if (dtSchema.Select("ColumnName='" + pi.Name + "'").Length > 0)
                        {
                            if (sdr[pi.Name] is DBNull)
                            { }
                            else
                            {
                                if (pi.PropertyType.BaseType.Equals(typeof(System.Enum)))
                                {
                                    pi.SetValue(obj, Enum.Parse(pi.PropertyType, sdr[pi.Name].ToString()), null);
                                }
                                else if (pi.PropertyType.Equals(typeof(System.Guid)))
                                {
                                    pi.SetValue(obj, new Guid(sdr[pi.Name].ToString()), null);
                                }
                                else
                                {
                                    pi.SetValue(obj, Convert.ChangeType(sdr[pi.Name], pi.PropertyType), null);
                                }


                                if (sdr[pi.Name].ToString() == "ID")
                                {
 
                                }
                            }
                        }
                    }

                    SQLiteDataReader sdrsub = null;
                    DataTable dtSchemasub = null;
                    SQLiteParameter para = new SQLiteParameter();
                    para.ParameterName = subpara;
                    para.Value = sdr["ID"].ToString();

                    PrepareCommand(cmd, conn, null, sqlSub, para);
                    sdrsub = cmd.ExecuteReader();
                    dtSchemasub = sdr.GetSchemaTable();
                    while (sdrsub.Read())
                    {
                        U objsub = Activator.CreateInstance<U>(); //根据泛型实例化类对象
                        PropertyInfo[] pinfosub = typeof(U).GetProperties(BindingFlags.Public | BindingFlags.Instance);
                        //甴類对象获得实体类的属性typeof(T).GetProperties()返回属性数组（PropertyInfo[]）                                
                        foreach (PropertyInfo pisub in pinfosub)
                        {
                            //1.根据薮据库查询的值给实体类属性赋值（pi.SetValue()）
                            if (dtSchemasub.Select("ColumnName='" + pisub.Name + "'").Length > 0)
                            {
                                if (sdrsub[pisub.Name] is DBNull)
                                { }
                                else
                                {
                                    if (pisub.PropertyType.BaseType.Equals(typeof(System.Enum)))
                                    {
                                        pisub.SetValue(obj, Enum.Parse(pisub.PropertyType, sdrsub[pisub.Name].ToString()), null);
                                    }
                                    else if (pisub.PropertyType.Equals(typeof(System.Guid)))
                                    {
                                        pisub.SetValue(obj, new Guid(sdrsub[pisub.Name].ToString()), null);
                                    }
                                    else
                                    {
                                        pisub.SetValue(obj, Convert.ChangeType(sdrsub[pisub.Name], pisub.PropertyType), null);
                                    }
                                }
                            }

                        }
                    }
                    

                    list.Add(obj);
                }
            }
            catch (Exception ex)
            {
                conn.Close();
                WXLog.Error("Query<T> failed", ex);
                throw new Exception("Query<T>失败");
            }
            finally
            {
                if (conn != null) conn.Close();
                WXLog.Debug("性能Log，Query<T> End");
            }
            return list;
        }

        /// <summary>
        /// 执行查询
        /// </summary>        
        /// <param name="sql">查询语句</param>
        /// <param name="parameters">参数</param>
        /// <returns>查询结果</returns>
        public static List<Dictionary<string, object>> Query(string sql,params SQLiteParameter[] parameters)
        {
            WXLog.Debug("性能Log，Query Start");
            List<Dictionary<string, object>> lst = new List<Dictionary<string, object>>();
            SQLiteConnection conn = null;
            SQLiteCommand cmd = null;           
            SQLiteDataReader reader = null;
            try
            {
                conn = new SQLiteConnection(ConnString);
                cmd = new SQLiteCommand(); 
                PrepareCommand(cmd, conn, null, sql, parameters);
                reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);               
                while (reader.Read())
                {
                    Dictionary<string, object> table = new Dictionary<string, object>();
                    for (int i = 0; i < reader.FieldCount; i++)
                    { 
                        table.Add(reader.GetName(i), reader[i]);
                    }
                    lst.Add(table);
                }
                return lst;
            }
            catch (Exception ex)
            {
                reader.Close();
                WXLog.Error("Query failed", ex);
                throw new Exception("Query失败");
            }      
            finally
            {
                if (conn != null) reader.Close();
                WXLog.Debug("性能Log，Query End");
            }
        }


        /**/
        /// <summary> 
        /// 预处理Command对象,数据库链接,事务,需要执行的对象,参数等的初始化 
        /// </summary> 
        /// <param name="cmd">Command对象</param> 
        /// <param name="conn">Connection对象</param> 
        /// <param name="trans">Transcation对象</param> 
        /// <param name="cmdText">SQL Text</param> 
        /// <param name="parameters">参数实例</param> 
        private static void PrepareCommand(SQLiteCommand cmd, SQLiteConnection conn, SQLiteTransaction trans, string cmdText, params SQLiteParameter[] parameters)
        {
            if (conn.State != ConnectionState.Open)
                conn.Open();
            cmd.Connection = conn;
            cmd.CommandText = cmdText;
            if (trans != null)
                cmd.Transaction = trans;
            if (null != parameters && parameters.Length > 0)
            {
                cmd.Parameters.AddRange(parameters);
            }
        }


         /// <summary> 
         /// 通用分页查询方法
         /// </summary>        
         /// <param name="tableName">表名</param> 
         /// <param name="strColumns">查询字段名</param> 
         /// <param name="strWhere">where条件</param>
         /// <param name="strOrder">排序条件</param>
         /// <param name="pageSize">每页数据数量</param> 
         /// <param name="currentIndex">当前页数</param> 
         /// <param name="recordOut">数据总量</param>  
         /// <returns>DataTable数据表</returns>  
        public static DataTable SelectPaging(string tableName, string strColumns, string strWhere, string strOrder, int pageSize, int currentIndex, out int recordOut)
        {
            DataTable dt = new DataTable();
            recordOut = Convert.ToInt32(ExecuteScalar("select count(*) from " + tableName));
            string pagingTemplate = "select {0} from {1} where {2} order by {3} limit {4} offset {5} ";
            int offsetCount = (currentIndex - 1) * pageSize;
            string commandText = String.Format(pagingTemplate, strColumns, tableName, strWhere, strOrder, pageSize.ToString(), offsetCount.ToString());
            using (SQLiteDataReader reader = ExecuteReader(commandText))
            {
                if (reader != null)
                {
                    dt.Load(reader);
                }
            }
            return dt;
        }
        /// <summary>
        /// 创建数据库
        /// </summary>
        /// <param name="datasource"></param>
        /// <param name="pwd"></param>
        public static void CreateDB(string datasource,string pwd)
        {
            //创建一个数据库文件
            //string datasource = @"F:\Source\Solution_Wanxiang2011\WinAppTestSQLite\bin\Debug\test1234.db";
            System.Data.SQLite.SQLiteConnection.CreateFile(datasource);
            //连接数据库
            System.Data.SQLite.SQLiteConnection conn = new System.Data.SQLite.SQLiteConnection();
            System.Data.SQLite.SQLiteConnectionStringBuilder connstr = new System.Data.SQLite.SQLiteConnectionStringBuilder();
            connstr.DataSource = datasource;
            connstr.Password = pwd;         // "adminwx";//设置密码，SQLite ADO.NET实现了数据库密码保护
            conn.ConnectionString = connstr.ToString();
            conn.Open();
            //创建表
           
        
        }
        /// <summary>
        /// 创建表
        /// </summary>
        /// <param name="connection"></param>
        /// <param name="cmdText"></param>
        private static void CreateTable(SQLiteConnection connection, string cmdText)
        {
            System.Data.SQLite.SQLiteCommand cmd = new System.Data.SQLite.SQLiteCommand();         
            cmd.CommandText = cmdText;
            cmd.Connection = connection;
            cmd.ExecuteNonQuery();
        }      

    }
}
