using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using LN.DBUtility;//请先添加引用

namespace LN.DAL
{
    public class PromotionStoryBag
    {
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(LN.Model.PromotionStoryBag model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into PromotionStoryBag(");
            strSql.Append("StoryBagName)");
            strSql.Append(" values (");
            strSql.Append("@StoryBagName)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@StoryBagName",model.StoryBagName),
                   
            };

            object obj = DbHelperSQL.GetSingle(DbHelperSQL.connectionString(), strSql.ToString(), parameters);
            if (obj == null)
            {
                return 1;
            }
            else
            {
                return Convert.ToInt32(obj);
            }
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select Id,StoryBagName ");
            strSql.Append(" FROM PromotionStoryBag ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(DbHelperSQL.connectionString(), strSql.ToString());
        }
    }
}
