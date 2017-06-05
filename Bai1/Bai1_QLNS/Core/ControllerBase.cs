using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using API;
using Core;
using System.Data.SqlClient;
using System.Reflection;

namespace Core
{
    public class ControllerBase<T> where T : ModelBase, new()
    {
        SqlConnection con = new SqlConnection(@"server=MONCRIS-PC\SQLEXPRESS;database=QLNhanSu;integrated security=SSPI");
        static string QueryAll = "select * from {0}";
        static string InsertCommand = "procAdd{0}";
        static string EditCommand = "procEdit{0}";
        static string DeleteCommand = "procDelete{0}";
        List<T> lstData = new List<T>();
        public static string TableName;
        T temp = new T();
        public ControllerBase()
        {
            API.DataAccess.con = con;
            TableName = temp.GetType().Name;
            QueryAll = string.Format(QueryAll, TableName);
            InsertCommand = string.Format(InsertCommand, TableName);
            EditCommand = string.Format(EditCommand, TableName);
            DeleteCommand = string.Format(DeleteCommand, TableName);
        }
        public List<T> GetAllData()
        {
            lstData.Clear();
            con.Open();
            SqlCommand sc = new SqlCommand(QueryAll, con);
            sc.CommandType = CommandType.Text;
            SqlDataReader dr = sc.ExecuteReader();
            while (dr.Read())
            {
                T objT = new T();
                dr.GetValues(objT.ValueData);
                lstData.Add(objT);
            }
            con.Close();
            return lstData;
        }
        public DataTable ToDataTable(string query)
        {
            DataTable dt = DataAccess.Query(query);
            return dt;
        }
        public int Insert(T objT)
        {
            List<string> lstName = ModelBase.FieldNames;
            SqlParameter[] sp = new SqlParameter[objT.ValueData.Length - 1];
            for (int i = 1; i < objT.ValueData.Length; i++)
            {
                sp[i - 1] = new SqlParameter("@" + lstName[i], objT.ValueData[i]);
            }
            DataTable dt = DataAccess.Query(InsertCommand, sp);
            int ret = int.Parse(dt.Rows[0][0].ToString());
            return ret;
        }
        public int Edit(T objT)
        {
            List<string> lstName = ModelBase.FieldNames;
            SqlParameter[] sp = new SqlParameter[objT.ValueData.Length];
            for (int i = 0; i < objT.ValueData.Length; i++)
            {
                sp[i] = new SqlParameter("@" + lstName[i], objT.ValueData[i]);
            }
            DataTable dt = DataAccess.Query(EditCommand, sp);
            int ret = int.Parse(dt.Rows[0][0].ToString());
            return ret;
        }
        public int Delete(T objT)
        {
            List<string> lstName = ModelBase.FieldNames;
            SqlParameter sp = new SqlParameter();
            sp = new SqlParameter("@" + lstName[0], objT.ValueData[0]);
            DataTable dt = DataAccess.Query(DeleteCommand, sp);
            int ret = int.Parse(dt.Rows[0][0].ToString());
            return ret;
        }

        List<string> lstNObj = new List<string>();
        public List<string> GetNameObj(int vitri)
        {
            lstNObj.Clear();
            for (int i = 0; i < GetAllData().Count; i++)
            {
                lstNObj.Add(GetAllData()[i].ValueData[vitri].ToString());
            }
            return lstNObj;
        }

    }
}