using client.common;
using client.common.SystemSettings;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using static client.common.CommonOp;

namespace client.controll
{
    public   class StartingUtil
    {
        public static void InitSystemSettings()
        {
            try
            {
                //ServiceLocator.SystemSettings = XMLUtil.XmlDeserialize<SystemSettingsInfo>(
                //    ConfigureFile.GetXML(SystemFilePath.FilePathSystemSetting),
                //    "SystemSettings");

                string currentDirectory = System.IO.Directory.GetCurrentDirectory();

                DirectoryInfo currentFolder = new DirectoryInfo(currentDirectory);
                FileInfo[] files = currentFolder.GetFiles();
                if (files.Length>0)
                {
                    foreach (var file in files)
                    {
                        if (".xlsx".Equals(file.Extension,StringComparison.OrdinalIgnoreCase) || ".xls".Equals(file.Extension, StringComparison.OrdinalIgnoreCase))
                        {
                            string message = "";
                            DataSet dataSet = ExcelToDataSet(file.FullName, out message);
                            DataTable dataTable = dataSet.Tables[0];

                            string name = dataTable.Rows[2]["A"].ToString();
                        }
                    }
                }
              
            }
            catch (Exception ex)
            {
                WXLog.Error("读取系统参数配置文件失败", ex);
                throw new Exception(ex.Message);
            }
        }

        public static DataSet ExcelToDataSet(string filePath, out string strMsg)
        {
            strMsg = "";
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            string fileType = Path.GetExtension(filePath).ToLower();
            string fileName = Path.GetFileName(filePath).ToLower();
            try
            {
                ISheet sheet = null;
                int sheetNumber = 0;
                FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read);
                if (fileType == ".xlsx")
                {
                    // 2007版本
                    XSSFWorkbook workbook = new XSSFWorkbook(fs);
                    sheetNumber = workbook.NumberOfSheets;
                    if (sheetNumber > 0)
                    {
                        string sheetName = workbook.GetSheetName(0);
                        sheet = workbook.GetSheet(sheetName);
                        if (sheet != null)
                        {
                            dt = GetSheetDataTable(sheet, out strMsg);
                            if (dt != null)
                            {
                                dt.TableName = sheetName.Trim();
                                ds.Tables.Add(dt);
                            }
                            else
                            {
                                // MessageBox.Show("Sheet数据获取失败，原因：" + strMsg);
                            }
                        }
                    }
                }
                else if (fileType == ".xls")
                {
                    // 2003版本
                    HSSFWorkbook workbook = new HSSFWorkbook(fs);
                    sheetNumber = workbook.NumberOfSheets;
                    for (int i = 0; i < sheetNumber; i++)
                    {
                        string sheetName = workbook.GetSheetName(i);
                        sheet = workbook.GetSheet(sheetName);
                        if (sheet != null)
                        {
                            dt = GetSheetDataTable(sheet, out strMsg);
                            if (dt != null)
                            {
                                dt.TableName = sheetName.Trim();
                                ds.Tables.Add(dt);
                            }
                            else
                            {
                               // MessageBox.Show("Sheet数据获取失败，原因：" + strMsg);
                            }
                        }
                    }
                }
                return ds;
            }
            catch (Exception ex)
            {
                strMsg = ex.Message;
                return null;
            }
        }

        private static DataTable GetSheetDataTable(ISheet sheet, out string strMsg)
        {
            strMsg = "";
            DataTable dt = new DataTable();
            string sheetName = sheet.SheetName;
            int startIndex = 0;// sheet.FirstRowNum;
            int lastIndex = sheet.LastRowNum;
            //最大列数
            int cellCount = 0;
            IRow maxRow = sheet.GetRow(0);
            for (int i = startIndex; i <= lastIndex; i++)
            {
                IRow row = sheet.GetRow(i);
                if (row != null && cellCount < row.LastCellNum)
                {
                    cellCount = row.LastCellNum;
                    maxRow = row;
                }
            }
            //列名设置
            try
            {
                for (int i = 0; i < maxRow.LastCellNum; i++)//maxRow.FirstCellNum
                {
                    dt.Columns.Add(Convert.ToChar(((int)'A') + i).ToString());
                    //DataColumn column = new DataColumn("Column" + (i + 1).ToString());
                    //dt.Columns.Add(column);
                }
            }
            catch
            {
                strMsg = "工作表" + sheetName + "中无数据";
                return null;
            }
            //数据填充
            for (int i = startIndex; i <= lastIndex; i++)
            {
                IRow row = sheet.GetRow(i);
                DataRow drNew = dt.NewRow();
                if (row != null)
                {
                    for (int j = row.FirstCellNum; j < row.LastCellNum; ++j)
                    {
                        if (row.GetCell(j) != null)
                        {
                            ICell cell = row.GetCell(j);
                            switch (cell.CellType)
                            {
                                case CellType.Blank:
                                    drNew[j] = "";
                                    break;
                                case CellType.Numeric:
                                    short format = cell.CellStyle.DataFormat;
                                    //对时间格式（2015.12.5、2015/12/5、2015-12-5等）的处理
                                    if (format == 14 || format == 31 || format == 57 || format == 58)
                                        drNew[j] = cell.DateCellValue;
                                    else
                                        drNew[j] = cell.NumericCellValue;
                                    if (cell.CellStyle.DataFormat == 177 || cell.CellStyle.DataFormat == 178 || cell.CellStyle.DataFormat == 188)
                                        drNew[j] = cell.NumericCellValue.ToString("#0.00");
                                    break;
                                case CellType.String:
                                    drNew[j] = cell.StringCellValue;
                                    break;
                                case CellType.Formula:
                                    try
                                    {
                                        drNew[j] = cell.NumericCellValue;
                                        if (cell.CellStyle.DataFormat == 177 || cell.CellStyle.DataFormat == 178 || cell.CellStyle.DataFormat == 188)
                                            drNew[j] = cell.NumericCellValue.ToString("#0.00");
                                    }
                                    catch
                                    {
                                        try
                                        {
                                            drNew[j] = cell.StringCellValue;
                                        }
                                        catch { }
                                    }
                                    break;
                                default:
                                    drNew[j] = cell.StringCellValue;
                                    break;
                            }
                        }
                    }
                }
                dt.Rows.Add(drNew);
            }
            return dt;
        }

        public bool SaveSystemSettinsConfig()
        {
            bool bReturn = false;
            try
            {
                bReturn =SaveXML(XMLUtil.XmlSerialize<SystemSettingsInfo>(ServiceLocator.SystemSettings, "SystemSettings"),
                    SystemFilePath.FilePathSystemSetting);
            }
            catch (Exception ex)
            {
                WXLog.Error("保存系统配置失败", ex);
                throw new Exception("保存系统配置失败");
            }
            return bReturn;
        }
        public static bool SaveXML(string xml, string filePath)
        {
            //todo
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(xml);
            doc.Save(filePath);
            return true;
        }
        public static void CheckDbVersion()//检查数据库版本
        {
            int currentVersion = 1;
            int lastVersion = Convert.ToInt32(ServiceLocator.SystemSettings.ProxyInfo.DBVersion);
            if (lastVersion < currentVersion)
            {
                bool isSuccess = true;
            }
        }

        private static bool AddTable(string sql, string tablename)
        {
            bool isSuccess = true;
            try
            {
                int a = SQLiteHelper.ExecuteNonQuery(sql);
            }
            catch (System.Data.SQLite.SQLiteException ex)
            {
                string a = ex.Message;
                if (a.Contains("already exists"))
                {
                    isSuccess = true;
                    WXLog.Info(tablename + "已添加");
                }
                else if (a.Contains("duplicate"))
                {
                    isSuccess = true;
                    WXLog.Info(tablename + "已添加");
                }
                else
                {
                    isSuccess = false;
                    WXLog.Info("添加" + tablename + "失败,发生错误" + a);
                }
            }
            catch (Exception e)
            {
                isSuccess = false;
                WXLog.Info("添加" + tablename + "失败");
            }
            if (isSuccess)
            {
                WXLog.Info("添加" + tablename + "完成");
            }
            return isSuccess;
        }
        public static bool CheckActivte()
        {
            if (ServiceLocator.SystemSettings.ProxyInfo.DeviceCode == StringSecurity.MD5Encrypt(StringSecurity.RSAEncrypt(ServiceLocator.SystemSettings.ProxyInfo.Corpid) + "EC" + StringSecurity.RSAEncrypt(ServiceLocator.SystemSettings.ProxyInfo.CorpSrecret) + DateTime.Now.Year))
            {
                return true;
            }else
            {
                return false;
            }
        }
    }
}
