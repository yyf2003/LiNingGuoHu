using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using LN.DBUtility;//请先添加引用
namespace LN.DAL
{
    /// <summary>
    /// 数据访问类sysFunction。
    /// </summary>
    public class sysFunction
    {
        public sysFunction()
        { }
        #region  成员方法

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(LN.Model.sysFunction model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into sysFunction(");
            strSql.Append("funcName,callFormClass,upId,FolderName,LevelNum)");
            strSql.Append(" values (");
            strSql.Append("@funcName,@callFormClass,@upId,@FolderName,@LevelNum)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@funcName", SqlDbType.VarChar,100),
					new SqlParameter("@callFormClass", SqlDbType.VarChar,100),
					new SqlParameter("@upId", SqlDbType.Int,4),
					new SqlParameter("@FolderName", SqlDbType.VarChar,100),
					new SqlParameter("@LevelNum", SqlDbType.Int,4)};
            parameters[0].Value = model.funcName;
            parameters[1].Value = model.callFormClass;
            parameters[2].Value = model.upId;
            parameters[3].Value = model.FolderName;
            parameters[4].Value = model.LevelNum;

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
        /// 更新一条数据
        /// </summary>
        public void Update(LN.Model.sysFunction model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update sysFunction set ");
            strSql.Append("funcName=@funcName,");
            strSql.Append("callFormClass=@callFormClass,");
            strSql.Append("upId=@upId,");
            strSql.Append("FolderName=@FolderName,");
            strSql.Append("LevelNum=@LevelNum");
            strSql.Append(" where id=@id ");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4),
					new SqlParameter("@funcName", SqlDbType.VarChar,100),
					new SqlParameter("@callFormClass", SqlDbType.VarChar,100),
					new SqlParameter("@upId", SqlDbType.Int,4),
					new SqlParameter("@FolderName", SqlDbType.VarChar,100),
					new SqlParameter("@LevelNum", SqlDbType.Int,4)};
            parameters[0].Value = model.id;
            parameters[1].Value = model.funcName;
            parameters[2].Value = model.callFormClass;
            parameters[3].Value = model.upId;
            parameters[4].Value = model.FolderName;
            parameters[5].Value = model.LevelNum;

            DbHelperSQL.ExecuteSql(DbHelperSQL.connectionString(), strSql.ToString(), parameters);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void Delete(int id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from sysFunction ");
            strSql.Append(" where id=@id ");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
            parameters[0].Value = id;

            DbHelperSQL.ExecuteSql(DbHelperSQL.connectionString(), strSql.ToString(), parameters);
        }

        /// <summary>
        /// 获取上级功能编号
        /// </summary>
        /// <param name="strWhere">查询条件</param>
        /// <returns>返回编号集合</returns>
        public IList<int> GetupIdGroup(string strWhere)
        {
            IList<int> list = new List<int>();
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT distinct upId FROM sysFunction");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" WHERE " + strWhere);
            }
            StringBuilder sb = new StringBuilder();
            sb.Append("select ID from sysFunction where ID in (");
            sb.Append(strSql.ToString());
            sb.Append(") order by orderID");
            SqlDataReader reader = DbHelperSQL.ExecuteReader(DbHelperSQL.connectionString(), sb.ToString());
            while (reader.Read())
            {
                if (!string.IsNullOrEmpty(reader.GetInt32(0).ToString()))
                {
                    list.Add(reader.GetInt32(0));
                }
            }
            reader.Close();
            return list;
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public LN.Model.sysFunction GetModel(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 id,funcName,callFormClass,upId,FolderName,LevelNum from sysFunction ");
            strSql.Append(" where id=@id ");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
            parameters[0].Value = id;

            LN.Model.sysFunction model = null;
            SqlDataReader reader = DbHelperSQL.ExecuteReader(DbHelperSQL.connectionString(), strSql.ToString(), parameters);
            if (reader.Read())
            {
                model = new LN.Model.sysFunction();
                if (!string.IsNullOrEmpty(reader.GetInt32(0).ToString()))
                    model.id = reader.GetInt32(0);

                if (!string.IsNullOrEmpty(reader.GetString(1)))
                    model.funcName = reader.GetString(1);

                if (!string.IsNullOrEmpty(reader.GetString(2)))
                    model.callFormClass = reader.GetString(2);

                if (!string.IsNullOrEmpty(reader.GetInt32(3).ToString()))
                    model.upId = reader.GetInt32(3);

                if (!string.IsNullOrEmpty(reader.GetString(4)))
                    model.FolderName = reader.GetString(4);

                if (!string.IsNullOrEmpty(reader.GetInt32(5).ToString()))
                    model.LevelNum = reader.GetInt32(5);
            }
            reader.Close();
            return model;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public IList<LN.Model.sysFunction> GetList(string strWhere)
        {
            IList<LN.Model.sysFunction> list = new List<LN.Model.sysFunction>();
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT s.id,s.funcName,s.callFormClass,s.upId,s.FolderName,s.LevelNum");
            strSql.Append(" FROM sysFunction AS s ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" WHERE " + strWhere);
            }
            SqlDataReader reader = DbHelperSQL.ExecuteReader(DbHelperSQL.connectionString(), strSql.ToString());
            while (reader.Read())
            {
                LN.Model.sysFunction model = new LN.Model.sysFunction();
                if (!string.IsNullOrEmpty(reader.GetInt32(0).ToString()))
                    model.id = reader.GetInt32(0);

                if (!string.IsNullOrEmpty(reader.GetString(1)))
                    model.funcName = reader.GetString(1);

                if (!string.IsNullOrEmpty(reader.GetString(2)))
                    model.callFormClass = reader.GetString(2);

                if (!string.IsNullOrEmpty(reader.GetInt32(3).ToString()))
                    model.upId = reader.GetInt32(3);

                if (!string.IsNullOrEmpty(reader.GetString(4)))
                    model.FolderName = reader.GetString(4);

                if (!string.IsNullOrEmpty(reader.GetInt32(5).ToString()))
                    model.LevelNum = reader.GetInt32(5);
                list.Add(model);
            }
            reader.Close();
            return list;
        }

        #endregion  成员方法
    }
}