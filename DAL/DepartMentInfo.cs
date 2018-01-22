using System;
using System.Data;
using System.Text;
using System.Collections.Generic;
using System.Data.SqlClient;
using LN.DBUtility;//请先添加引用
namespace LN.DAL
{
	/// <summary>
	/// 数据访问类DepartMentInfo。
	/// </summary>
	public class DepartMentInfo
	{
		public DepartMentInfo()
		{}
		#region  成员方法

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
            return DbHelperSQL.GetMaxID(DbHelperSQL.connectionString(), "ID", "DepartMentInfo"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from DepartMentInfo");
			strSql.Append(" where ID=@ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)};
			parameters[0].Value = ID;

            return DbHelperSQL.Exists(DbHelperSQL.connectionString(), strSql.ToString(), parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(LN.Model.DepartMentInfo model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into DepartMentInfo(");
            strSql.Append("department,Department_Master,department_MasterPhone,State)");
			strSql.Append(" values (");
            strSql.Append("@department,@Department_Master,@department_MasterPhone,@State)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@department", SqlDbType.VarChar,50),
					new SqlParameter("@Department_Master", SqlDbType.VarChar,50),
					new SqlParameter("@department_MasterPhone", SqlDbType.VarChar,50),
                    new SqlParameter("@State", SqlDbType.Int,4)
                   
                                        };
			parameters[0].Value = model.department;
			parameters[1].Value = model.Department_Master;
			parameters[2].Value = model.department_MasterPhone;
            parameters[3].Value = model.State;
            
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
		public void Update(LN.Model.DepartMentInfo model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update DepartMentInfo set ");
			strSql.Append("department=@department,");
			strSql.Append("Department_Master=@Department_Master,");
			strSql.Append("department_MasterPhone=@department_MasterPhone,");
            strSql.Append("State=@State");
          
			strSql.Append(" where ID=@ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4),
					new SqlParameter("@department", SqlDbType.VarChar,50),
					new SqlParameter("@Department_Master", SqlDbType.VarChar,50),
					new SqlParameter("@department_MasterPhone", SqlDbType.VarChar,50),
                    new SqlParameter("@State", SqlDbType.Int,4)
                    
                                        };
			parameters[0].Value = model.ID;
			parameters[1].Value = model.department;
			parameters[2].Value = model.Department_Master;
			parameters[3].Value = model.department_MasterPhone;
            parameters[4].Value = model.State;
           
            DbHelperSQL.ExecuteSql(DbHelperSQL.connectionString(), strSql.ToString(), parameters);
		}


        public void NewUpdate(LN.Model.DepartMentInfo model)
        {
            if (model != null && model.ID != null)
            {
                StringBuilder sql = new StringBuilder();
                List<SqlParameter> paraList = new List<SqlParameter>();
                sql.Append("update DepartMentInfo set ");
                if (model.Department_Master != null)
                {
                    sql.Append(" Department_Master=@Department_Master,");
                    paraList.Add(new SqlParameter("@Department_Master", model.Department_Master));
                }
                if (model.department_MasterPhone != null)
                {
                    sql.Append(" department_MasterPhone=@department_MasterPhone");
                    paraList.Add(new SqlParameter("@department_MasterPhone", model.department_MasterPhone));
                }
                sql.Append(" where ID=@ID");
                paraList.Add(new SqlParameter("@ID", model.ID));
                DbHelperSQL.ExecuteSql(DbHelperSQL.connectionString(), sql.ToString(), paraList.ToArray());
            }
        }

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(int ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from DepartMentInfo ");
			strSql.Append(" where ID=@ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)};
			parameters[0].Value = ID;

            DbHelperSQL.ExecuteSql(DbHelperSQL.connectionString(), strSql.ToString(), parameters);
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public LN.Model.DepartMentInfo GetModel(int ID)
		{
			
			StringBuilder strSql=new StringBuilder();
            strSql.Append("select  top 1 ID,department,Department_Master,department_MasterPhone,State from DepartMentInfo ");
			strSql.Append(" where ID=@ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)};
			parameters[0].Value = ID;

			LN.Model.DepartMentInfo model=new LN.Model.DepartMentInfo();
            DataSet ds = DbHelperSQL.Query(DbHelperSQL.connectionString(), strSql.ToString(), parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["ID"].ToString()!="")
				{
					model.ID=int.Parse(ds.Tables[0].Rows[0]["ID"].ToString());
				}
				model.department=ds.Tables[0].Rows[0]["department"].ToString();
				model.Department_Master=ds.Tables[0].Rows[0]["Department_Master"].ToString();
				model.department_MasterPhone=ds.Tables[0].Rows[0]["department_MasterPhone"].ToString();
                if (ds.Tables[0].Rows[0]["State"].ToString() != "")
                {
                    model.State = int.Parse(ds.Tables[0].Rows[0]["State"].ToString());
                }
               
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
		public DataSet GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
            strSql.Append("select ID,department,Department_Master,department_MasterPhone,State ");
			strSql.Append(" FROM DepartMentInfo ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
            return DbHelperSQL.Query(DbHelperSQL.connectionString(), strSql.ToString());
		}

		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ");
			if(Top>0)
			{
				strSql.Append(" top "+Top.ToString());
			}
            strSql.Append(" ID,department,Department_Master,department_MasterPhone,State ");
			strSql.Append(" FROM DepartMentInfo ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			strSql.Append(" order by " + filedOrder);
            return DbHelperSQL.Query(DbHelperSQL.connectionString(), strSql.ToString());
		}
        
		/*
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		{
			SqlParameter[] parameters = {
					new SqlParameter("@tblName", SqlDbType.VarChar, 255),
					new SqlParameter("@fldName", SqlDbType.VarChar, 255),
					new SqlParameter("@PageSize", SqlDbType.Int),
					new SqlParameter("@PageIndex", SqlDbType.Int),
					new SqlParameter("@IsReCount", SqlDbType.Bit),
					new SqlParameter("@OrderType", SqlDbType.Bit),
					new SqlParameter("@strWhere", SqlDbType.VarChar,1000),
					};
			parameters[0].Value = "DepartMentInfo";
			parameters[1].Value = "ID";
			parameters[2].Value = PageSize;
			parameters[3].Value = PageIndex;
			parameters[4].Value = 0;
			parameters[5].Value = 0;
			parameters[6].Value = strWhere;	
			return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
		}*/


        public void ClearUserData(string userName)
        {
            string sql = string.Format("update DepartMentInfo set Department_Master='',department_MasterPhone='' where Department_Master='{0}';",userName);
            //sql += string.Format("update DepartMentInfo set Department_Master='',department_MasterPhone='' where ID={0} or Department_Master='{0}';", departId, userName);
            DbHelperSQL.ExecuteSql(DbHelperSQL.connectionString(), sql);
        }

		#endregion  成员方法
	}
}

