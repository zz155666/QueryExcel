using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace client.common
{
    /// <summary>
    /// <para>概要：XML工具</para>
    /// </summary>
    public class XMLUtil
    {
        #region Const
        /// <summary>
        /// Default DateTime Format——CultureInfo("zh-CN", false)
        /// </summary>
        public static IFormatProvider DefaultDateTimeFormat = new System.Globalization.CultureInfo("zh-CN", false);

        #endregion

        #region 属性

        /// <summary>
        /// 默认简单类型
        /// </summary>
        public static readonly string[] DefaultSimpleTypes = { "String" };

        /// <summary>
        /// 简单类型
        /// </summary>
        public string[] SimpleTypes { get; set; }

        /// <summary>
        /// 复数字段分隔符，默认为“,”
        /// </summary>
        public string Separator = ",";

        /// <summary>
        /// 日期转字符串的格式
        /// </summary>
        public IFormatProvider DateTimeFormat { get; set; }
        /// <summary>
        /// Default Assembly
        /// </summary>
        public Assembly DefaultAssembly { get; set; }
        /// <summary>
        /// Calling Assembly
        /// </summary>
        public Assembly CallingAssembly { get; set; }
        /// <summary>
        /// Executing Assembly
        /// </summary>
        public Assembly ExecutingAssembly { get; set; }
        /// <summary>
        /// Entry Assembly
        /// </summary>
        public Assembly EntryAssembly { get; set; }

        #endregion

        /// <summary>
        /// 构造
        /// </summary>
        /// <remarks>对于默认数组，将调用ToString不再递归；否则将继续构造子树。</remarks>
        /// <param name="simpleTypes">作为简单类型的结构，将直接调用ToString</param>
        /// <param name="dateFormat">日期类型格式</param>
        private XMLUtil(string[] simpleTypes, IFormatProvider dateFormat)
        {
            if (simpleTypes == null) simpleTypes = DefaultSimpleTypes;
            SimpleTypes = simpleTypes;
            DateTimeFormat = dateFormat;
        }

        #region 公共方法

        /// <summary>
        /// 取得默认实例
        /// </summary>
        public static XMLUtil Instance
        {
            get
            {
                return new XMLUtil(XMLUtil.DefaultSimpleTypes, XMLUtil.DefaultDateTimeFormat);
            }
        }

        /// <summary>
        /// 转换成String
        /// </summary>
        /// <param name="obj">obj</param>
        /// <returns>String</returns>
        public static string ConvertToString(object obj)
        {
            if (obj is DateTime)
            {
                return ((DateTime)obj).ToString(DefaultDateTimeFormat);
            }
            else if (obj is Color)
            {
                return System.Drawing.ColorTranslator.ToHtml((Color)obj);
            }
            else
            {
                return obj.ToString();
            }
        }

        /// <summary>
        /// 转换string
        /// </summary>
        /// <param name="type">type</param>
        /// <param name="txt">txt</param>
        /// <returns>object</returns>
        public static object ConvertToTypeofProperty(Type type, string txt)
        {
            // DateTime
            if (type.Name.Equals("DateTime"))
            {
                return DateTime.Parse(txt, DefaultDateTimeFormat);
            }
            else if (type.BaseType.Equals(typeof(Enum)))
            {
                return Enum.Parse(type, txt);
            }
            else if (type.Name.Equals("Color"))
            {
                return System.Drawing.ColorTranslator.FromHtml(txt);
            }
            else
            {
                return typeof(Convert).InvokeMember("To" + type.Name,
                    BindingFlags.InvokeMethod, null, null, new object[] { txt });
            }
        }

        /// <summary>
        /// 转换string
        /// </summary>
        /// <param name="property">property</param>
        /// <param name="txt">txt</param>
        /// <returns>转换string</returns>
        public static object ConvertToTypeofProperty(PropertyInfo property, string txt)
        {
            return ConvertToTypeofProperty(property.PropertyType, txt);
        }

        /// <summary>
        /// 为Entity生成XML
        /// </summary>
        /// <param name="obj">Entity</param>
        /// <param name="rootName">XElement根名称，为Null时取类名</param>
        /// <returns>XML</returns>
        public string GenerateXElementFromEntity(object obj, string rootName)
        {
            if (obj == null) return null;
            if (string.IsNullOrEmpty(rootName)) rootName = obj.GetType().Name;
            XmlDocument doc = new XmlDocument();
            XmlElement root = doc.CreateElement(rootName);
            doc.AppendChild(root);

            PropertyInfo[] properties = obj.GetType().GetProperties();
            List<XmlAttribute> attris = new List<XmlAttribute>();
            List<XmlNode> childElements = new List<XmlNode>();

            //可以读的属性
            List<PropertyInfo> validQuery = new List<PropertyInfo>();
            foreach (PropertyInfo valid in properties)
            {
                if (valid.CanRead == true && valid.MemberType == MemberTypes.Property
                             && valid.PropertyType.IsVisible == true)
                    validQuery.Add(valid);
            }

            foreach (PropertyInfo property in validQuery)
            {
                //是数组
                if (property.PropertyType.IsArray)
                {
                    Array values;
                    try
                    {
                        values = property.GetValue(obj, null) as Array;

                        //没有数据，则继续下一个属性
                        if (values == null || values.Length == 0) continue;

                        foreach (object v in values)
                        {
                            //是简单类型,或者是复杂类型，但是作为简单类型，直接调用ToString[]
                            if (IsSimpleDataType(v))
                            {
                                try
                                {
                                    //转换成功，拼一个字串，继续下个属性
                                    XmlAttribute att = doc.CreateAttribute(property.Name);
                                    att.Value = StringUtil.ConnectString(Separator,
                                        Array.ConvertAll<object, string>(ConvertToObjectArray(values), t => ConvertToString(t)));
                                    attris.Add(att);
                                    break;
                                }
                                catch
                                {
                                    //转换失败，则赋值为""，继续下个属性
                                    XmlAttribute att = doc.CreateAttribute(property.Name);
                                    att.Value = string.Empty;
                                    attris.Add(att);
                                    break;
                                }
                            }
                            //是复杂类型
                            else
                            {
                                try
                                {
                                    string elementString = GenerateXElementFromEntity(v, property.Name);                                    
                                    XmlDocument doc2 = new XmlDocument();
                                    doc2.LoadXml(elementString);
                                    childElements.Add(doc2.DocumentElement);
                                }
                                catch
                                {
                                    //若生成失败，则继续下一个object
                                    continue;
                                }
                            }
                        }
                    }
                    catch
                    {
                        //若转换失败，则继续下一个属性
                        continue;
                    }

                }
                //单值
                else
                {
                    //是简单类型，或者是复杂类型，但是作为简单类型，直接调用ToString
                    if (IsSimpleDataType(property))
                    {
                        try
                        {
                            XmlAttribute att = doc.CreateAttribute(property.Name);
                            att.Value = ConvertToString(property.GetValue(obj, null));
                            attris.Add(att);
                        }
                        catch
                        {
                            //若异常，则增加属性值为""
                            XmlAttribute att = doc.CreateAttribute(property.Name);
                            att.Value = string.Empty;
                            attris.Add(att);
                            continue;
                        }
                    }
                    //是复杂类型，需要继续取得Element
                    else
                    {
                        try
                        {
                            string elementString = GenerateXElementFromEntity(property.GetValue(obj, null), property.Name);
                            XmlDocument doc2 = new XmlDocument();
                            doc2.LoadXml(elementString);

                            childElements.Add(doc2.DocumentElement);
                        }
                        catch
                        {
                            //若异常，则继续
                            continue;
                        }
                    }
                }
            }

            foreach (XmlAttribute attri in attris)
            {
                root.Attributes.Append(attri);                
            }
            XmlNode tempNode = null;
            foreach (XmlElement childElement in childElements)
            {
                //root.AppendChild(childElement);   
                tempNode = doc.ImportNode(childElement, true);
                root.AppendChild(tempNode);
            }

            return root.OuterXml;
        }

        /// <summary>
        /// 将XML读入Entity
        /// </summary>
        /// <typeparam name="T">对象类型</typeparam>
        /// <param name="root">XElement根</param>
        /// <returns>Entity对象</returns>
        public T GenerateObjectFromXElement<T>(string rootString)
        {
            RecordAssembly(typeof(T));

            //简单值类型
            if (typeof(T).IsValueType || rootString == null) return default(T);
            T obj = Activator.CreateInstance<T>();
            PropertyInfo[] properties = obj.GetType().GetProperties();
            //可以写的属性
            List<PropertyInfo> validQuery = new List<PropertyInfo>();
            foreach (var valid in properties)
            {
                if (valid.CanWrite == true && valid.MemberType == MemberTypes.Property
                             && valid.PropertyType.IsVisible == true)
                    validQuery.Add(valid);
            }

            XmlDocument doc = new XmlDocument();
            
            doc.LoadXml(rootString);
            XmlNode root = doc.ChildNodes[0];

            foreach (PropertyInfo property in validQuery)
            {
                //是数组
                if (property.PropertyType.IsArray)
                {
                    Type type = GetType(property.PropertyType.FullName.Remove(property.PropertyType.FullName.IndexOf("[]")));
                    if (type == null) continue;
                    //是简单类型，或者是复杂类型，但是作为简单类型，取Attribute的值
                    if (IsSimpleDataType(property))
                    {
                        try
                        {
                            string[] values = StringUtil.Split(GetAttributeValue(root,property.Name), this.Separator).ToArray();
                            MethodInfo ConvertToTypeofPropertyGenericMethod =
                                 this.GetType().GetMethod("ConvertToTypeofPropertyGeneric").MakeGenericMethod(type);
                            property.SetValue(obj, ConvertToTypeofPropertyGenericMethod.Invoke(this, new object[] { type, values }), null);
                        }
                        catch
                        {

                        }

                    }
                    //是复杂类型，循环Elements
                    else
                    {
                        MethodInfo GenerateObjectFromXElementMethod =
                            this.GetType().GetMethod("GenerateObjectFromXElement").MakeGenericMethod(type);
                        List<object> values = new List<object>();

                        foreach (XmlNode childElement in GetNodesByName(root,property.Name))
                        {
                            try
                            {
                                values.Add(GenerateObjectFromXElementMethod.Invoke(this, new object[] { childElement.OuterXml }));
                            }
                            catch
                            { }
                        }
                        MethodInfo ConvertToTypeofPropertyGeneric2Method =
                                 this.GetType().GetMethod("ConvertToTypeofPropertyGeneric2").MakeGenericMethod(new Type[] { type, typeof(object) });

                        property.SetValue(obj, ConvertToTypeofPropertyGeneric2Method.Invoke(this, new object[] { type, values.ToArray() }), null);
                    }
                }
                //单值
                else
                {
                    try
                    {
                        //是简单类型，或者是复杂类型，但是作为简单类型，直接赋值
                        if (IsSimpleDataType(property))
                        {
                            property.SetValue(obj, ConvertToTypeofProperty(property, GetAttributeValue(root, property.Name)), null);
                        }
                        //是复杂类型，需要继续设置Element
                        else
                        {
                            MethodInfo GenerateObjectFromXElementMethod =
                                 this.GetType().GetMethod("GenerateObjectFromXElement").MakeGenericMethod(property.PropertyType);
                            object value = GenerateObjectFromXElementMethod.Invoke(this, new object[] {GetElementByName(root, property.Name) });

                            property.SetValue(obj, value, null);
                        }
                    }
                    catch
                    {
                        //错误时，继续下一个属性
                        continue;
                    }
                }

            }
            return obj;
        }

        /// <summary>
        /// 转换S数组为T数组
        /// </summary>
        /// <typeparam name="T">T</typeparam>
        /// <typeparam name="S">S</typeparam>
        /// <param name="type">Type</param>
        /// <param name="s">S数组</param>
        /// <returns>T数组</returns>
        public T[] ConvertToTypeofPropertyGeneric2<T, S>(Type type, S[] s)
        {
            List<T> lst = new List<T>(s.Length);

            lst.AddRange(Array.ConvertAll<S, T>(s, delegate(S item)
            {
                return (T)((object)item);
            }));

            return lst.ToArray();
        }

        /// <summary>
        /// 转换string数组为T数组
        /// </summary>
        /// <typeparam name="T">T</typeparam>
        /// <param name="type">type</param>
        /// <param name="txt">string数组</param>
        /// <returns>T数组</returns>
        public T[] ConvertToTypeofPropertyGeneric<T>(Type type, string[] txt)
        {
            List<T> lst = new List<T>(txt.Length);

            lst.AddRange(Array.ConvertAll<string, T>(txt, delegate(string item)
            {
                return (T)ConvertToTypeofProperty(type, item);
            }));
            return lst.ToArray();
        }

        #endregion

        #region 私有方法

        private void RecordAssembly(Type type)
        {
            if (DefaultAssembly == null)
            {
                DefaultAssembly = type.Assembly;
                CallingAssembly = Assembly.GetCallingAssembly();
                ExecutingAssembly = Assembly.GetExecutingAssembly();
                EntryAssembly = Assembly.GetEntryAssembly();
            }
        }

        /// <summary>
        /// 取得类型
        /// </summary>
        /// <returns>类型</returns>
        private Type GetType(string typeName)
        {
            Type type = Type.GetType(typeName);
            if (type == null) type = DefaultAssembly.GetType(typeName);
            if (type == null) type = CallingAssembly.GetType(typeName);
            if (type == null) type = ExecutingAssembly.GetType(typeName);
            if (type == null) type = EntryAssembly.GetType(typeName);
            return type;
        }
        /// <summary>
        /// 判断当前属性信息是否是简单类型
        /// </summary>
        /// <param name="property">属性信息</param>
        /// <returns>结果</returns>
        private bool IsSimpleDataType(PropertyInfo property)
        {
            //Array
            if (property.PropertyType.IsArray)
            {
                try
                {
                    Type type = GetType(property.PropertyType.FullName.Remove(property.PropertyType.FullName.IndexOf("[]")));

                    if (type.IsValueType) return true;
                    foreach (string t in SimpleTypes)
                    {
                        if (type.Name.ToUpper() == t.ToUpper()) return true;
                    }
                    return false;                    
                }
                catch
                {
                    return false;
                }
            }
            //单值
            else
            {
                if (property.PropertyType.IsValueType) return true;

                foreach (string t in SimpleTypes)
                {
                    if (property.PropertyType.Name.ToUpper() == t.ToUpper()) return true;
                }
                return false;
            }
        }

        /// <summary>
        /// 判断对象是否是简单类型
        /// </summary>
        /// <param name="obj">对象</param>
        /// <returns>结果</returns>
        private bool IsSimpleDataType(object obj)
        {
            Type type = obj.GetType();
            if (type.IsValueType) return true;
            foreach (string t in SimpleTypes)
            {
                if (type.Name.ToUpper() == t.ToUpper()) return true;
            }
            return false;
        }

        private static object[] ConvertToObjectArray<T>(T[] arary)
        {
            return Array.ConvertAll<T, object>(arary, delegate(T item)
            {
                return item;
            });
        }
        private static object[] ConvertToObjectArray(Array arary)
        {
            if (arary == null) return null;
            object[] obj = new object[arary.Length];
            int i = 0;
            foreach (object o in arary)
            {
                obj[i] = o;
                i++;
            }
            return obj;
        }


        private string GetAttributeValue(XmlNode node, string attributeName)
        {
            foreach (XmlAttribute att in node.Attributes)
            {
                if (att.Name == attributeName)
                    return att.Value;
            }
            return string.Empty;
        }

        private XmlNode[] GetNodesByName(XmlNode root, string elementName)
        {
            List<XmlNode> elements = new List<XmlNode>();
            foreach (XmlNode childNode in root.ChildNodes)
            {
                if (childNode.NodeType == XmlNodeType.Element && childNode.Name == elementName)
                    elements.Add(childNode);
            }
            return elements.ToArray();
        }

        private XmlElement GetElementByName(XmlNode root, string elementName)
        {
            foreach (XmlNode childNode in root.ChildNodes)
            {
                if (childNode.NodeType == XmlNodeType.Element && childNode.Name == elementName)
                    return (XmlElement)childNode;
            }
            return null;
        }
        #endregion

        #region "XmlSerialize"

        /// <summary>
        /// 序列化对象为XML 无XmlDec 无Namespace
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>     
        /// <returns></returns>
        public static string XmlSerialize<T>(T obj)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
            StringBuilder stringBuilder = new StringBuilder();
            XmlSerializerNamespaces xmlSerializerNamespaces = new XmlSerializerNamespaces();
            xmlSerializerNamespaces.Add("", "");
            XmlWriterSettings xmlWriterSettings = new XmlWriterSettings();
            xmlWriterSettings.OmitXmlDeclaration = true;
            using (XmlWriter xmlWriter = XmlWriter.Create(stringBuilder, xmlWriterSettings))
            {
                xmlSerializer.Serialize(xmlWriter, obj, xmlSerializerNamespaces);
                return stringBuilder.ToString();
            } 
        }

        /// <summary>
        /// 反序列化XML为对象
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="xmlOfObject"></param>     
        /// <returns></returns>
        public static T XmlDeserialize<T>(string xmlOfObject) where T : class
        {
            using (MemoryStream ms = new MemoryStream())
            {  
                using (StreamWriter sr = new StreamWriter(ms, Encoding.UTF8))
                {
                    sr.Write(xmlOfObject);
                    sr.Flush();
                    ms.Seek(0, SeekOrigin.Begin);
                    XmlSerializer serializer = new XmlSerializer(typeof(T));
                    return serializer.Deserialize(ms) as T;
                }
            }
        }

        /// <summary>
        /// 序列化对象为XML
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <param name="strname"></param>
        /// <returns></returns>
        public static string XmlSerialize<T>(T obj, string strname)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                XmlRootAttribute xRoot = new XmlRootAttribute();
                xRoot.ElementName = strname;
                xRoot.Namespace = "";
                xRoot.IsNullable = true;

                XmlSerializer serializer = new XmlSerializer(typeof(T), xRoot);
                serializer.Serialize(ms, obj);
                ms.Seek(0, SeekOrigin.Begin);
                using (StreamReader reader = new StreamReader(ms, Encoding.UTF8))
                {
                    return reader.ReadToEnd();
                }
            }
        }
        /// <summary>
        /// 反序列化XML为对象
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="xmlOfObject"></param>
        /// <param name="strname"></param>
        /// <returns></returns>
        public static T XmlDeserialize<T>(string xmlOfObject, string strname) where T : class
        {
            using (MemoryStream ms = new MemoryStream())
            {
                XmlRootAttribute xRoot = new XmlRootAttribute();
                xRoot.ElementName = strname;
                xRoot.Namespace = "";
                xRoot.IsNullable = true;

                using (StreamWriter sr = new StreamWriter(ms, Encoding.UTF8))
                {
                    sr.Write(xmlOfObject);
                    sr.Flush();
                    ms.Seek(0, SeekOrigin.Begin);
                    XmlSerializer serializer = new XmlSerializer(typeof(T), xRoot);
                    return serializer.Deserialize(ms) as T;
                }
            }
        }
        #endregion

    }
}
