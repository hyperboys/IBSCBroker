using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBSC.Common
{
    public static class DataCommon
    {
        public static object Get(string keyName)
        {
            Dictionary<string, object> data = DataInterface.DataController;
            string sectionKey = keyName + "^" + keyName;

            if (data.ContainsKey(sectionKey) == false)
            {
                throw new Exception("ไม่มีคีย์ " + keyName + " ในระบบ");
            }

            return data[sectionKey];
        }

        /// <summary>
        /// ลบข้อมูลจาก DataController
        /// </summary>
        /// <param name="keyName">คีย์ที่ต้องการ</param>
        public static void Remove(string keyName)
        {
            DataInterface.Remove(keyName, keyName);
        }

        /// <summary>
        /// จัดเก็บข้อมูลใน DataController
        /// </summary>
        /// <param name="keyName">คีย์ที่ต้องการ</param>
        /// <param name="obj">ค่าที่ต้องการ</param>
        public static void Set(string keyName, object obj)
        {
            //DataInterface.Set(keyName, keyName, obj);

            Dictionary<string, object> data = DataInterface.DataController;
            string key = keyName + "^" + keyName;

            if (data.ContainsKey(key) == true)
            {
                data[key] = obj;
            }
            else
            {
                data.Add(key, obj);
            }
        }

        /// <summary>
        /// ตรวจสอบว่าใน DataController มีคีย์นี้หรือไม่
        /// </summary>
        /// <param name="keyName">คีย์ที่ต้องการตรวจสอบ</param>
        /// <returns>ผลกานตรวจสอบ</returns>
        public static bool Exists(string keyName)
        {
            return DataInterface.Exist(keyName, keyName);
        }
    }
}
