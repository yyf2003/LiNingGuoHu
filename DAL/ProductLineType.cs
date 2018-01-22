using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using LN.DBUtility;//请先添加引用
namespace LN.DAL
{
    /// <summary>
    /// 数据访问类ProductLineType。
    /// </summary>
    public class ProductLineType
    {
        public ProductLineType()
        { }
        #region  成员方法

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(string typeName,int isDelete)
        {
            int _return = 0;
            StringBuilder strSql = new StringBuilder();

            SqlParameter[] parameters = {
					new SqlParameter("@ProductTypeName", SqlDbType.VarChar,100),
                    new SqlParameter("@IsDelete", SqlDbType.Int,4)};
            parameters[0].Value = typeName;
            parameters[1].Value = isDelete;
            object obj = DbHelperSQL.RunProcedure(DbHelperSQL.connectionString(), "P_AddProductLineType", parameters, out _return);
            if (obj == null)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(_return);
            }
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public void Update(LN.Model.ProductLineType model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update ProductLineType set ");
            strSql.Append("ProductTypeName=@ProductTypeName");
            strSql.Append(" where ProductTypeID=@ProductTypeID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ProductTypeID", SqlDbType.Int,4),
					new SqlParameter("@ProductTypeName", SqlDbType.VarChar,50)};
            parameters[0].Value = model.ProductTypeID;
            parameters[1].Value = model.ProductTypeName;

            DbHelperSQL.ExecuteSql(DbHelperSQL.connectionString(), strSql.ToString(), parameters);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void Delete(int ProductTypeID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from ProductLineType ");
            strSql.Append(" where ProductTypeID=@ProductTypeID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ProductTypeID", SqlDbType.Int,4)};
            parameters[0].Value = ProductTypeID;

            DbHelperSQL.ExecuteSql(DbHelperSQL.connectionString(), strSql.ToString(), parameters);
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public LN.Model.ProductLineType GetModel(int ProductTypeID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 ProductTypeID,ProductTypeName from ProductLineType ");
            strSql.Append(" where ProductTypeID=@ProductTypeID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ProductTypeID", SqlDbType.Int,4)};
            parameters[0].Value = ProductTypeID;

            LN.Model.ProductLineType model = new LN.Model.ProductLineType();
            DataSet ds = DbHelperSQL.Query(DbHelperSQL.connectionString(), strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["ProductTypeID"].ToString() != "")
                {
                    model.ProductTypeID = int.Parse(ds.Tables[0].Rows[0]["ProductTypeID"].ToString());
                }
                model.ProductTypeName = ds.Tables[0].Rows[0]["ProductTypeName"].ToString();
                return model;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public IList<LN.Model.ProductLineType> GetList(string strWhere)
        {
            IList<LN.Model.ProductLineType> list = new List<LN.Model.ProductLineType>();
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT ProductTypeID,ProductTypeName,IsDelete ");
            strSql.Append(" FROM ProductLineType ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" WHERE " + strWhere);
            }
            SqlDataReader reader = DbHelperSQL.ExecuteReader(DbHelperSQL.connectionString(), strSql.ToString());
            while (reader.Read())
            {
                LN.Model.ProductLineType model = new LN.Model.ProductLineType();
                if (!string.IsNullOrEmpty(reader.GetInt32(0).ToString()))
                    model.ProductTypeID = reader.GetInt32(0);

                if (!string.IsNullOrEmpty(reader.GetString(1)))
                    model.ProductTypeName = reader.GetString(1);

                if (!string.IsNullOrEmpty(reader.GetInt32(2).ToString()))
                    model.IsDelete = reader.GetInt32(2);

                list.Add(model);
            }
            reader.Close();
            return list;
        }

        #endregion  成员方法
    }
}
