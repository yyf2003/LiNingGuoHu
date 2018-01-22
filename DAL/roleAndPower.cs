using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using LN.DBUtility;//请先添加引用
namespace LN.DAL
{
    /// <summary>
    /// 数据访问类roleAndPower。
    /// </summary>
    public class roleAndPower
    {
        public roleAndPower()
        { }
        #region  成员方法

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(LN.Model.roleAndPower model)
        {
            int _return = 0;
            StringBuilder strSql = new StringBuilder();
            strSql.Append("DELETE roleAndPower WHERE roleId=@roleId; ");
            strSql.Append("INSERT INTO roleAndPower(");
            strSql.Append("roleId,functionId)");
            strSql.Append(" VALUES (");
            strSql.Append("@roleId,@functionId); ");
            strSql.Append(";SELECT @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@roleId", SqlDbType.Int,4),
					new SqlParameter("@functionId", SqlDbType.VarChar,300)};
            parameters[0].Value = model.roleId;
            parameters[1].Value = model.functionId;

            object obj = DbHelperSQL.GetSingle(DbHelperSQL.connectionString(), strSql.ToString(), parameters);
            if (obj != null)
                _return = Convert.ToInt32(obj);

            return _return;
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public int Update(LN.Model.roleAndPower model)
        {
            int _return = 0;
            StringBuilder strSql = new StringBuilder();
            strSql.Append("UPDATE roleAndPower set ");
            strSql.Append("roleId=@roleId,");
            strSql.Append("functionId=@functionId");
            strSql.Append(" WHERE id=@id; ");
            strSql.Append(" SELECT @@ROWCOUNT; ");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4),
					new SqlParameter("@roleId", SqlDbType.Int,4),
					new SqlParameter("@functionId", SqlDbType.VarChar,300)};
            parameters[0].Value = model.id;
            parameters[1].Value = model.roleId;
            parameters[2].Value = model.functionId;

            object obj = DbHelperSQL.GetSingle(DbHelperSQL.connectionString(), strSql.ToString(), parameters);
            if (obj != null)
                _return = Convert.ToInt32(obj);

            return _return;
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void Delete(int id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from roleAndPower ");
            strSql.Append(" where id=@id ");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
            parameters[0].Value = id;

            DbHelperSQL.ExecuteSql(DbHelperSQL.connectionString(), strSql.ToString(), parameters);
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public LN.Model.roleAndPower GetModel(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT  top 1 id,roleId,functionId FROM roleAndPower ");
            strSql.Append(" WHERE roleId=@id ");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
            parameters[0].Value = id;

            LN.Model.roleAndPower model = null;
            SqlDataReader reader = DbHelperSQL.ExecuteReader(DbHelperSQL.connectionString(), strSql.ToString(), parameters);
            if (reader.Read())
            {
                model = new LN.Model.roleAndPower();
                if (!string.IsNullOrEmpty(reader.GetInt32(0).ToString()))
                    model.id = reader.GetInt32(0);

                if (!string.IsNullOrEmpty(reader.GetInt32(1).ToString()))
                    model.roleId = reader.GetInt32(1);

                if (!string.IsNullOrEmpty(reader.GetString(2)))
                    model.functionId = reader.GetString(2);
            }
            reader.Close();
            return model;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public IList<LN.Model.roleAndPower> GetList(string strWhere)
        {
            IList<LN.Model.roleAndPower> list = new List<LN.Model.roleAndPower>();
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT id,roleId,functionId ");
            strSql.Append(" FROM roleAndPower ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" WHERE " + strWhere);
            }
            SqlDataReader reader = DbHelperSQL.ExecuteReader(DbHelperSQL.connectionString(), strSql.ToString());
            while (reader.Read())
            {
                LN.Model.roleAndPower model = new LN.Model.roleAndPower();
                if (!string.IsNullOrEmpty(reader.GetInt32(0).ToString()))
                    model.id = reader.GetInt32(0);

                if (!string.IsNullOrEmpty(reader.GetInt32(1).ToString()))
                    model.roleId = reader.GetInt32(1);

                if (!string.IsNullOrEmpty(reader.GetString(2)))
                    model.functionId = reader.GetString(2);
                list.Add(model);
            }
            reader.Close();
            return list;
        }

        #endregion  成员方法
    }
}

