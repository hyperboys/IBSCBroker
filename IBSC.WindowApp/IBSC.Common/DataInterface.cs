using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace IBSC.Common
{
    public class DataInterface
    {
        ///================================================== ส่วนนี้เอามาจาก Web นะ ==================================================
        // Convert an object to a byte array
        private static byte[] ObjectToByteArray(Object obj)
        {
            BinaryFormatter bf = new BinaryFormatter();
            MemoryStream ms = new MemoryStream();

            try
            {
                if (obj == null)
                    return null;

                bf.Serialize(ms, obj);
            }
            catch
            {
                throw;
            }

            return ms.ToArray();
        }
        // Convert a byte array to an Object
        private static Object ByteArrayToObject(byte[] arrBytes)
        {
            MemoryStream memStream = new MemoryStream();
            BinaryFormatter binForm = new BinaryFormatter();
            Object obj;

            try
            {
                memStream.Write(arrBytes, 0, arrBytes.Length);
                memStream.Seek(0, SeekOrigin.Begin);
                obj = (Object)binForm.Deserialize(memStream);
            }
            catch
            {
                throw;
            }

            return obj;
        }

        #region DataController_Reference
        private static Dictionary<string, object> dataDictionary = new Dictionary<string, object>();
        public static Dictionary<string, object> DataController
        {
            get { return dataDictionary; }
        }

        public static void Set(string section, string keyName, object obj)
        {
            string key = section + "^" + keyName;

            if (dataDictionary.ContainsKey(key) == true)
            {
                dataDictionary[key] = obj;
            }
            else
            {
                dataDictionary.Add(key, obj);
            }
        }

        public static object Get(string section, string keyName)
        {
            string sectionKey = section + "^" + keyName;

            if (dataDictionary.ContainsKey(sectionKey) == false)
            {
                throw new Exception("ไม่มีคีย์ " + keyName + " ในระบบ");
            }

            object obj;

            obj = dataDictionary[sectionKey];
            return obj;
        }

        public static void Remove(string section, string keyName)
        {
            string sectionKey = section + "^" + keyName;

            if (dataDictionary.ContainsKey(sectionKey) == false)
            {
                //กรณีไม่มีข้อมูล ไม่ทำอะไรทั้งสิ้น
                //throw new Exception("ไม่มีคีย์นี้ ในระบบ");
            }
            else
            {
                dataDictionary.Remove(sectionKey);
            }
        }

        public static void RemoveBySection(string section)
        {
            IEnumerable<KeyValuePair<string, object>> lstData
                = dataDictionary.Where(check => check.Key.StartsWith(section + "^"));

            if (lstData != null)
            {
                //กรณีไม่มีข้อมูล ไม่ทำอะไรทั้งสิ้น
                //throw new Exception("ไม่มีคีย์นี้ ในระบบ");
            }
            else
            {
                foreach (KeyValuePair<string, object> obj in lstData)
                {
                    dataDictionary.Remove(obj.Key);
                }
            }
        }

        public static void Clear()
        {
            dataDictionary.Clear();
        }

        public static bool Exist(string section, string keyName)
        {
            string sectionKey = section + "^" + keyName;

            return (dataDictionary.ContainsKey(sectionKey));
        }
        #endregion

        #region DataController_NotReference
        private static Dictionary<string, byte[]> _dataCloneDictionary = new Dictionary<string, byte[]>();
        public static Dictionary<string, byte[]> CloneDictionary
        {
            get { return _dataCloneDictionary; }
        }

        public static void SetClone(string section, string keyName, object obj)
        {
            if (obj is XmlDocument)
            {
                CustomData cd = new CustomData();
                cd.InnerXML = ((XmlDocument)obj).InnerXml;

                obj = cd;
            }

            byte[] byteArr = ObjectToByteArray(obj);

            string key = section + "^" + keyName;

            if (_dataCloneDictionary.ContainsKey(key) == true)
            {
                _dataCloneDictionary[key] = byteArr;
            }
            else
            {
                _dataCloneDictionary.Add(key, byteArr);
            }
        }

        public static object GetClone(string section, string keyName)
        {
            string sectionKey = section + "^" + keyName;

            if (_dataCloneDictionary.ContainsKey(sectionKey) == false)
            {
                throw new Exception("ไม่มีคีย์ " + keyName + " ในระบบ");
            }

            byte[] objStored; //= _objClient.Get(section, keyName);
            object obj;

            objStored = _dataCloneDictionary[sectionKey];

            if (objStored == null)
            {
                obj = null;
            }
            else
            {
                obj = ByteArrayToObject(objStored);
            }

            if (obj is CustomData)
            {
                XmlDocument doc = new XmlDocument();

                doc.InnerXml = ((CustomData)obj).InnerXML;
                obj = doc;
            }

            return obj;
        }

        public static void RemoveClone(string section, string keyName)
        {
            string sectionKey = section + "^" + keyName;

            if (_dataCloneDictionary.ContainsKey(sectionKey) == false)
            {
                //กรณีไม่มีข้อมูล ไม่ทำอะไรทั้งสิ้น
                //throw new Exception("ไม่มีคีย์นี้ ในระบบ");
            }
            else
            {
                _dataCloneDictionary.Remove(sectionKey);
            }
        }

        public static void RemoveCloneBySection(string section)
        {
            IEnumerable<KeyValuePair<string, byte[]>> lstData
                = _dataCloneDictionary.Where(check => check.Key.StartsWith(section + "^"));

            if (lstData != null)
            {
                //กรณีไม่มีข้อมูล ไม่ทำอะไรทั้งสิ้น
                //throw new Exception("ไม่มีคีย์นี้ ในระบบ");
            }
            else
            {
                foreach (KeyValuePair<string, byte[]> obj in lstData)
                {
                    _dataCloneDictionary.Remove(obj.Key);
                }
            }
        }

        public static void ClearClone()
        {
            _dataCloneDictionary.Clear();
        }

        public static bool ExistClone(string section, string keyName)
        {
            string sectionKey = section + "^" + keyName;

            return (_dataCloneDictionary.ContainsKey(sectionKey));
        }

        #endregion
    }
}
