using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using LN.DBUtility;
namespace LN.DAL
{
    /// <summary>
    /// 数据访问类UpLoadEffectImg。
    /// </summary>
    public class UpLoadEffectImg
    {
        public UpLoadEffectImg(){ }

        #region  成员方法

        /// <summary>
        /// 批量操作数据
        /// </summary>
        public int Operate(List<string> strSql)
        {
            int _return = 0;

            object obj = DbHelperSQL.ExecuteSqlTran(DbHelperSQL.connectionString(), strSql);
            if (obj != null)
            {
                _return = Convert.ToInt32(obj);
            }

            return _return;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public IList<LN.Model.UpLoadEffectImg> GetList(string strWhere)
        {
            IList<LN.Model.UpLoadEffectImg> list = new List<LN.Model.UpLoadEffectImg>();
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT ID,SupplierID,POPID,ImgURL,UserID,CreateDate ");
            strSql.Append(" FROM UpLoadEffectImg ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" WHERE " + strWhere);
            }
            SqlDataReader reader = DbHelperSQL.ExecuteReader(DbHelperSQL.connectionString(), strSql.ToString());
            while (reader.Read())
            {
                LN.Model.UpLoadEffectImg model = new LN.Model.UpLoadEffectImg();
                if (!string.IsNullOrEmpty(reader.GetInt32(0).ToString()))
                    model.ID = reader.GetInt32(0);

                if (!string.IsNullOrEmpty(reader.GetInt32(1).ToString()))
                    model.SupplierID = reader.GetInt32(1);

                if (!string.IsNullOrEmpty(reader.GetString(2)))
                    model.POPID = reader.GetString(2);

                if (!string.IsNullOrEmpty(reader.GetString(3)))
                    model.ImgURL = reader.GetString(3);

                if (!string.IsNullOrEmpty(reader.GetInt32(4).ToString()))
                    model.UserID = reader.GetInt32(4);

                if (!string.IsNullOrEmpty(reader.GetDateTime(5).ToString()))
                    model.CreateDate = reader.GetDateTime(5);
                list.Add(model);
            }
            reader.Close();
            return list;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataTable GetListName(string strWhere)
        {
            DataTable dt = null;
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT i.ID,i.SupplierID,i.POPID,i.ImgURL,i.UserID,i.CreateDate,(SELECT UserName FROM UserInfo WHERE UserID=i.UserID) AS UserName, (SELECT SupplierName FROM SupplierInfo WHERE SupplierID=i.SupplierID) AS SupplierName ");
            strSql.Append(" FROM UpLoadEffectImg AS i ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" WHERE " + strWhere);
            }
            DataSet ds = DbHelperSQL.Query(DbHelperSQL.connectionString(), strSql.ToString());

            if (ds != null)
                dt = ds.Tables[0];

            return dt;
        }

        #endregion  成员方法
    }
}
