using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using LN.DBUtility;//请先添加引用
namespace LN.DAL
{
	/// <summary>
	/// 数据访问类POPSeat。
	/// </summary>
	public class POPSeat
	{
		public POPSeat()
		{}
		#region  成员方法

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int SeatID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from POPSeat");
			strSql.Append(" where SeatID=@SeatID ");
			SqlParameter[] parameters = {
					new SqlParameter("@SeatID", SqlDbType.Int,4)};
			parameters[0].Value = SeatID;

            return DbHelperSQL.Exists(DbHelperSQL.connectionString(), strSql.ToString(), parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(LN.Model.POPSeat model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into POPSeat(");
			strSql.Append("seat)");
			strSql.Append(" values (");
			strSql.Append("@seat)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@seat", SqlDbType.VarChar,50)};
			parameters[0].Value = model.seat;

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
		public void Update(LN.Model.POPSeat model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update POPSeat set ");
			strSql.Append("seat=@seat");
			strSql.Append(" where SeatID=@SeatID ");
			SqlParameter[] parameters = {
					new SqlParameter("@SeatID", SqlDbType.Int,4),
					new SqlParameter("@seat", SqlDbType.VarChar,50)};
			parameters[0].Value = model.SeatID;
			parameters[1].Value = model.seat;

            DbHelperSQL.ExecuteSql(DbHelperSQL.connectionString(), strSql.ToString(), parameters);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(int SeatID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete POPSeat ");
			strSql.Append(" where SeatID=@SeatID ");
			SqlParameter[] parameters = {
					new SqlParameter("@SeatID", SqlDbType.Int,4)};
			parameters[0].Value = SeatID;

            DbHelperSQL.ExecuteSql(DbHelperSQL.connectionString(), strSql.ToString(), parameters);
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public LN.Model.POPSeat GetModel(int SeatID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 SeatID,seat from POPSeat ");
			strSql.Append(" where SeatID=@SeatID ");
			SqlParameter[] parameters = {
					new SqlParameter("@SeatID", SqlDbType.Int,4)};
			parameters[0].Value = SeatID;

			LN.Model.POPSeat model=new LN.Model.POPSeat();
            DataSet ds = DbHelperSQL.Query(DbHelperSQL.connectionString(), strSql.ToString(), parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["SeatID"].ToString()!="")
				{
					model.SeatID=int.Parse(ds.Tables[0].Rows[0]["SeatID"].ToString());
				}
				model.seat=ds.Tables[0].Rows[0]["seat"].ToString();
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
        public List<LN.Model.POPSeat> GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  SeatID,seat ");
			strSql.Append(" FROM POPSeat ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
            SqlDataReader reader = DbHelperSQL.ExecuteReader(DbHelperSQL.connectionString(), strSql.ToString());
            List<LN.Model.POPSeat> modelList = new List<LN.Model.POPSeat>();
            while (reader.Read())
            {
                LN.Model.POPSeat model = new LN.Model.POPSeat();
                if (!string.IsNullOrEmpty(reader.GetInt32(0).ToString()))
                {
                    model.SeatID = reader.GetInt32(0);
                }
                if (!string.IsNullOrEmpty(reader.GetString(1)))
                {
                    model.seat = reader.GetString(1);
                }
                modelList.Add(model);
            }
            reader.Close();
            return modelList;
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
			parameters[0].Value = "POPSeat";
			parameters[1].Value = "ID";
			parameters[2].Value = PageSize;
			parameters[3].Value = PageIndex;
			parameters[4].Value = 0;
			parameters[5].Value = 0;
			parameters[6].Value = strWhere;	
			return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
		}*/

		#endregion  成员方法
	}
}

