using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;

namespace Core
{
    public abstract class ModelBase
    {
        public static List<string> FieldNames = null;
        static Type objType;
        public abstract Type GetDataType();
        protected int MaxFields;
        public object[] ValueData;

        public ModelBase()
        {
            Setup();
            #region tối ưu
            //if (FieldNames == null)
            //{
            //    objType = GetDataType();
            //    FieldNames = new List<string>();
            //    PropertyInfo[] Fields = objType.GetProperties();
            //    foreach (PropertyInfo item in Fields)
            //    {
            //        FieldNames.Add(item.Name);
            //    }
            //}
            #endregion
            objType = GetDataType();
            FieldNames = new List<string>();
            PropertyInfo[] Fields = objType.GetProperties();
            foreach (PropertyInfo item in Fields)
            {
                FieldNames.Add(item.Name);
            }
        }
        public abstract void Setup();
        public void SetData(int pos, object val)
        {
            ValueData[pos] = val;
        }
        public int GetINT(int pos)
        {
            return (int)ValueData[pos];
        }
        public string GetSTR(int pos)
        {
            return ValueData[pos].ToString();
        }
        public double GetDOU(int pos)
        {
            return double.Parse(ValueData[pos].ToString());
        }
        public float GetFLO(int pos)
        {
            return float.Parse(ValueData[pos].ToString());
        }
        public DateTime GetDateTime(int pos)
        {
            return DateTime.Parse(ValueData[pos].ToString());
        }
    }
}