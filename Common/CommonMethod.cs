using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.ComponentModel;
using System.Data;
using System.Web;

namespace Common
{
    public class CommonMethod
    {
        /// <summary>
        /// 获取枚举的名称
        /// </summary>
        /// <typeparam name="T">类型</typeparam>
        /// <param name="vaule">vaule</param>
        /// <returns></returns>
        public static string GeEnumName<T>(string vaule)
        {
            string strName = string.Empty;
            foreach (int myCode in Enum.GetValues(typeof(T)))
            {
                if (vaule == myCode.ToString())
                {
                    strName = Enum.GetName(typeof(T), myCode);
                    break;
                }
            }
            return strName;
        }
        /// <summary>
        /// 获取枚举属性
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string GetEnumDescription<T>(string value)
        {
            string description = string.Empty;
            foreach (int myCode in Enum.GetValues(typeof(T)))
            {
                if (value == myCode.ToString())
                {
                    string name = Enum.GetName(typeof(T), myCode);
                    if (name != null)
                    {
                        FieldInfo field = typeof(T).GetField(name);
                        if (field != null)
                        {
                            DescriptionAttribute attr = Attribute.GetCustomAttribute(field, typeof(DescriptionAttribute), false) as DescriptionAttribute;
                            description = attr != null ? attr.Description : "";
                        }
                    }
                }
            }
            return description;
        }

        /// <summary>
        /// 检查字典中的值是不是为空，并返回值为空KeyName
        /// </summary>
        /// <param name="ht"></param>
        /// <param name="emptyNames"></param>
        /// <returns></returns>
        public static bool CheckArrayValueIsEmpty(Dictionary<string, string> dic, out string emptyNames)
        {
            StringBuilder sb = new StringBuilder();
            bool flag = true;
            if (dic != null)
            {
                foreach (KeyValuePair<string,string> item in dic)
                {
                    if (string.IsNullOrWhiteSpace(item.Value))
                    {
                        sb.Append(item.Key+",");
                        flag = false;
                    }

                }
            }
            emptyNames = sb.ToString();
            return flag;
        }

        /// <summary>
        /// 判断DataSet的行中指定列的值是否为空，为空返回列名
        /// </summary>
        /// <param name="colNames"></param>
        /// <param name="dr"></param>
        /// <param name="emptyNames"></param>
        /// <returns></returns>
        public static bool CheckDsRowValueIsEmpty(ArrayList colNames, DataRow dr, out string emptyNames)
        {
            StringBuilder sb = new StringBuilder();
            bool flag = false;
            if (colNames.Count > 0 && dr != null)
            {
                foreach (string colName in colNames)
                {
                    if (string.IsNullOrWhiteSpace(dr[colName].ToString()))
                    {
                        sb.Append(colName + "，");
                        flag = true;
                    }
                }
            }
            emptyNames = sb.ToString();
            return flag;
        }

        /// <summary>
        /// 导出excel
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="title"></param>
        public static void DownLoadToExcel(DataTable dt, string title)
        {
            
            System.IO.StringWriter sw = new System.IO.StringWriter();
            sw.Write(title);
            sw.Write("\n");
            //字段名称
            for (int i = 0; i < dt.Columns.Count; i++)
            {
                sw.Write(dt.Columns[i]);
                sw.Write("\t");
            }
            sw.Write("\n");
            //数据
            object[] arr = new object[dt.Columns.Count];
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                arr = dt.Rows[i].ItemArray;
                for (int j = 0; j < arr.Length; j++)
                {
                    sw.Write(arr[j].ToString().Trim().Replace("<br/>", "").Replace("\r\n", "").Replace("\"", "").Replace("\'", ""));
                    //sw.Write(arr[j].ToString().Replace("<br/>", "").Replace("\r\n", "").Replace("\"", "").Replace("\'", ""));

                    sw.Write("\t");
                }
                sw.Write("\n");
            }
            sw.Flush();
            sw.Dispose();
            HttpContext.Current.Response.Clear();
            HttpContext.Current.Response.Buffer = true;
            HttpContext.Current.Response.Charset = "GB2312";
            HttpContext.Current.Response.ContentEncoding = System.Text.Encoding.GetEncoding("GB18030");
            HttpContext.Current.Response.AddHeader("Content-Disposition", string.Format("attachment;filename={0}.xls", System.Web.HttpUtility.UrlEncode(title, System.Text.Encoding.UTF8)));
            HttpContext.Current.Response.ContentType = "application/ms-excel";
            HttpContext.Current.Response.Write(sw);
            HttpContext.Current.Response.End();

        }

        /// <summary>
        /// datatable 分页
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="PageIndex"></param>
        /// <param name="PageSize"></param>
        /// <returns></returns>
        public static DataTable SplitDataTable(DataTable dt, int PageIndex, int PageSize)
        {
            if (PageIndex == 0)
                return dt;
            DataTable newdt = dt.Clone();
            //newdt.Clear();
            int rowbegin = (PageIndex - 1) * PageSize;
            int rowend = PageIndex * PageSize;

            if (rowbegin >= dt.Rows.Count)
                return newdt;

            if (rowend > dt.Rows.Count)
                rowend = dt.Rows.Count;
            for (int i = rowbegin; i <= rowend - 1; i++)
            {
                DataRow newdr = newdt.NewRow();
                DataRow dr = dt.Rows[i];
                foreach (DataColumn column in dt.Columns)
                {
                    newdr[column.ColumnName] = dr[column.ColumnName];
                }
                newdt.Rows.Add(newdr);
            }

            return newdt;
        }
    }
}
