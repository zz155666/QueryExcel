using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace client.common
{
#pragma warning disable 1591
    public class StringUtil
    {
        public static List<byte[]> SplitByte(byte[] data, uint len, int dataSeekByte, byte[] split, bool bReturnEmpty)
        {
            List<byte[]> ret = new List<byte[]>();
            MemoryStream ms = new MemoryStream();
            try
            {
                for (int i = 0; i < len; i += dataSeekByte)
                {
                    //check
                    bool bCheck = false;
                    if (data.Length - i >= split.Length)
                    {
                        bCheck = true;
                        for (int j = 0; j < split.Length; j++)
                        {
                            if (!data[i + j].Equals(split[j]))
                            {
                                bCheck = false;
                                break;
                            }
                        }
                    }

                    if (bCheck)
                    {
                        byte[] w = ms.ToArray();
                        ms.Seek(split.Length, SeekOrigin.Current);
                        if (bReturnEmpty || w.Length > 0)
                        {
                            ret.Add(w);
                        }
                        ms = new MemoryStream();
                    }
                    else
                    {
                        ms.Write(data, i, dataSeekByte);
                    }
                }
                byte[] w2 = ms.ToArray();
                if (bReturnEmpty || w2.Length > 0)
                {
                    ret.Add(w2);
                }
                return ret;
            }
            catch (Exception)
            {
                throw new Exception("SplitByte failed!");
            }
        }

        /// <summary>
        /// Add Seperator to string list
        /// </summary>
        /// <param name="sep">Splitor</param>
        /// <param name="items">string list</param>
        /// <returns>Formatted string</returns>
        public static string AddSpliterToString(string[] items, string sep)
        {
            if (! (items ==null || items.Length == 0))
            {
                StringBuilder itemInfo = new StringBuilder();
                for (int i = 0; i < items.Length; i++)
                {
                    itemInfo.Append(items[i] + sep);
                }
                itemInfo.Remove(itemInfo.Length - 1, 1);
                return itemInfo.ToString();
            }
            else
            {
                return string.Empty;
            }
        }

        public static List<string> Split(string str, string sep, StringSplitOptions splitOption)
        {
            List<string> ret = Split(str, sep);
            if (splitOption == StringSplitOptions.RemoveEmptyEntries)
            {
                List<int> del = new List<int>();
                for (int cnt = 0; cnt < ret.Count; cnt++)
                {
                    if (string.IsNullOrEmpty(ret[cnt]))
                    {
                        del.Add(cnt);
                    }
                }
                for (int cnt = del.Count - 1; cnt >= 0; cnt--)
                {
                    ret.RemoveAt(del[cnt]);
                }
            }
            return ret;
        }

        public static List<string> Split(string str, string sep)
        {
            List<string> ret = new List<string>();
            if (sep.Length == 0)
            {
                ret.Add(str);
            }
            string workStr = str;
            while (true)
            {
                int idx = workStr.IndexOf(sep);
                if (idx < 0)
                {
                    ret.Add(workStr);
                    break;
                }
                ret.Add(workStr.Substring(0, idx));
                workStr = workStr.Remove(0, idx + 1);
            }
            return ret;
        }

        public static string listStr2Str(List<string> list)
        {
            return listStr2Str(list.ToArray());
        }


        public static string listStr2Str(string[] list)
        {
            if (list == null || list.Length == 0)
            {
                return "(Empty)";
            }
            string ret = "[";
            for (int cnt = 0; cnt < list.Length; cnt++)
            {
                if (cnt > 0)
                {
                    ret += "][";
                }
                ret += list[cnt];
            }
            ret += "]";
            return ret;
        }

        public static string ConnectString(string sep, params string[] items)
        {
            if (items == null || items.Length <= 0)
            {
                return string.Empty;
            }
            else if (items.Length == 1)
            {
                return items[0];
            }
            else
            {
                StringBuilder itemInfo = new StringBuilder();
                for (int i = 0; i < items.Length; i++)
                {
                    itemInfo.Append(items[i] + sep);
                }
                itemInfo.Remove(itemInfo.Length - 1, 1);
                return itemInfo.ToString();
            }
        }
    }

}
