using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using System.Collections.Generic;
using LN.DBUtility;//请先添加引用

namespace LN.DAL
{
    /// <summary>
    /// 数据访问类tb_POPInfo_Img。
    /// </summary>
    public class tb_POPInfo_Img
    {
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(LN.Model.tb_POPInfo_Img model)
        {
            int _return = 0;
            StringBuilder strSql = new StringBuilder();
            strSql.Append("INSERT INTO tb_POPInfo_Img(");
            strSql.Append("Img_ShopID,Img_POPInfoID,Img_URL,Img_Describe,Img_CreateTime)");
            strSql.Append(" VALUES (");
            strSql.Append("@Img_ShopID,@Img_POPInfoID,@Img_URL,@Img_Describe,@Img_CreateTime)");
            strSql.Append(";SELECT @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@Img_ShopID", SqlDbType.Int,4),
					new SqlParameter("@Img_POPInfoID", SqlDbType.Int,4),
					new SqlParameter("@Img_URL", SqlDbType.NVarChar,150),
					new SqlParameter("@Img_Describe", SqlDbType.NVarChar,200),
					new SqlParameter("@Img_CreateTime", SqlDbType.DateTime)};
            parameters[0].Value = model.Img_ShopID;
            parameters[1].Value = model.Img_POPInfoID;
            parameters[2].Value = model.Img_URL;
            parameters[3].Value = model.Img_Describe;
            parameters[4].Value = model.Img_CreateTime;

            object obj = DbHelperSQL.GetSingle(DbHelperSQL.connectionString(), strSql.ToString(), parameters);
            if (obj != null)
                _return = Convert.ToInt32(obj);

            return _return;
        }

        /// <summary>
        /// 判断指定POP是否上传图片
        /// </summary>
        /// <param name="POPInfoID">指定POP编号</param>
        /// <returns>返回是否上传图片</returns>
        public int IsExistByPOPInfoID(int POPInfoID)
        {
            int _return = 0;
            string strSql = "SELECT COUNT(Img_ID) FROM tb_POPInfo_Img WHERE Img_POPInfoID=@Img_POPInfoID";

             SqlParameter[] parameters = {
					new SqlParameter("@Img_POPInfoID", SqlDbType.Int,4)};
            parameters[0].Value = POPInfoID;

            object obj = DbHelperSQL.GetSingle(DbHelperSQL.connectionString(), strSql.ToString(), parameters);
            if (obj != null)
                _return = Convert.ToInt32(obj);

            return _return;


        }

        /// <summary>
        /// 根据指定条件获取相关图片信息
        /// </summary>
        /// <param name="strWhere">搜索条件</param>
        /// <returns>返回获取相关图片信息</returns>
        public IList<LN.Model.tb_POPInfo_Img> GetList(string strWhere)
        {
            IList<LN.Model.tb_POPInfo_Img> list = new List<LN.Model.tb_POPInfo_Img>();
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT Img_ID,Img_ShopID,Img_POPInfoID,Img_URL,Img_Describe,Img_CreateTime ");
            strSql.Append(" FROM tb_POPInfo_Img ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" WHERE " + strWhere);
            }
            SqlDataReader reader = DbHelperSQL.ExecuteReader(DbHelperSQL.connectionString(), strSql.ToString());
            while (reader.Read())
            {
                LN.Model.tb_POPInfo_Img model = new LN.Model.tb_POPInfo_Img();
                if (!string.IsNullOrEmpty(reader.GetInt32(0).ToString()))
                    model.Img_ID = reader.GetInt32(0);

                if (!string.IsNullOrEmpty(reader.GetInt32(1).ToString()))
                    model.Img_ShopID = reader.GetInt32(1);

                if (!string.IsNullOrEmpty(reader.GetInt32(2).ToString()))
                    model.Img_POPInfoID = reader.GetInt32(2);

                if (!string.IsNullOrEmpty(reader.GetString(3)))
                    model.Img_URL = reader.GetString(3);

                if (!string.IsNullOrEmpty(reader.GetString(4)))
                    model.Img_Describe = reader.GetString(4);

                if (!string.IsNullOrEmpty(reader.GetDateTime(5).ToString()))
                    model.Img_CreateTime = reader.GetDateTime(5);

                list.Add(model);
            }
            reader.Close();
            return list;
        }
    }
}
