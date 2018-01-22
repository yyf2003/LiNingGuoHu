using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using System.Collections.Generic;
using LN.DBUtility;//请先添加引用
namespace LN.DAL
{
	/// <summary>
	/// 数据访问类tb_FOSPOP。
	/// </summary>
	public class tb_FOSPOP
	{
		public tb_FOSPOP(){}

		#region  成员方法

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(LN.Model.tb_FOSPOP model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into tb_FOSPOP(");
			strSql.Append("FOS_POPSeat,FOS_POPMateria,FOS_POPRealHeight,FOS_POPRealWith,FOS_POPHeight,FOS_POPWith)");
			strSql.Append(" values (");
			strSql.Append("@FOS_POPSeat,@FOS_POPMateria,@FOS_POPRealHeight,@FOS_POPRealWith,@FOS_POPHeight,@FOS_POPWith)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@FOS_POPSeat", SqlDbType.NVarChar,100),
					new SqlParameter("@FOS_POPMateria", SqlDbType.NVarChar,100),
					new SqlParameter("@FOS_POPRealHeight", SqlDbType.Float,8),
					new SqlParameter("@FOS_POPRealWith", SqlDbType.Float,8),
					new SqlParameter("@FOS_POPHeight", SqlDbType.Float,8),
					new SqlParameter("@FOS_POPWith", SqlDbType.Float,8)};
			parameters[0].Value = model.FOS_POPSeat;
			parameters[1].Value = model.FOS_POPMateria;
			parameters[2].Value = model.FOS_POPRealHeight;
			parameters[3].Value = model.FOS_POPRealWith;
			parameters[4].Value = model.FOS_POPHeight;
			parameters[5].Value = model.FOS_POPWith;

            object obj = DbHelperSQL.GetSingle(DbHelperSQL.connectionString(), strSql.ToString(), parameters);
			if (obj == null)
			{
				return 0;
			}
			else
			{
				return Convert.ToInt32(obj);
			}
		}
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public int Update(LN.Model.tb_FOSPOP model)
		{
            int _return = 0;
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update tb_FOSPOP set ");
			strSql.Append("FOS_POPSeat=@FOS_POPSeat,");
			strSql.Append("FOS_POPMateria=@FOS_POPMateria,");
			strSql.Append("FOS_POPRealHeight=@FOS_POPRealHeight,");
			strSql.Append("FOS_POPRealWith=@FOS_POPRealWith,");
			strSql.Append("FOS_POPHeight=@FOS_POPHeight,");
			strSql.Append("FOS_POPWith=@FOS_POPWith");
			strSql.Append(" where FOS_ID=@FOS_ID; ");
            strSql.Append(" select @@ROWCOUNT; ");
			SqlParameter[] parameters = {
					new SqlParameter("@FOS_ID", SqlDbType.Int,4),
					new SqlParameter("@FOS_POPSeat", SqlDbType.NVarChar,100),
					new SqlParameter("@FOS_POPMateria", SqlDbType.NVarChar,100),
					new SqlParameter("@FOS_POPRealHeight", SqlDbType.Float,8),
					new SqlParameter("@FOS_POPRealWith", SqlDbType.Float,8),
					new SqlParameter("@FOS_POPHeight", SqlDbType.Float,8),
					new SqlParameter("@FOS_POPWith", SqlDbType.Float,8)};
			parameters[0].Value = model.FOS_ID;
			parameters[1].Value = model.FOS_POPSeat;
			parameters[2].Value = model.FOS_POPMateria;
			parameters[3].Value = model.FOS_POPRealHeight;
			parameters[4].Value = model.FOS_POPRealWith;
			parameters[5].Value = model.FOS_POPHeight;
			parameters[6].Value = model.FOS_POPWith;

            object obj = DbHelperSQL.GetSingle(DbHelperSQL.connectionString(), strSql.ToString(), parameters);
            if (obj != null)
                _return = Convert.ToInt32(obj);

            return _return;
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public int Delete(int FOS_ID)
		{
            int _return = 0;
			StringBuilder strSql=new StringBuilder();
            strSql.Append("update tb_FOSPOP set FOS_IsDelete=1 ");
			strSql.Append(" where FOS_ID=@FOS_ID; ");
            strSql.Append(" select @@ROWCOUNT; ");
			SqlParameter[] parameters = {
					new SqlParameter("@FOS_ID", SqlDbType.Int,4)};
			parameters[0].Value = FOS_ID;

            object obj = DbHelperSQL.GetSingle(DbHelperSQL.connectionString(), strSql.ToString(), parameters);
            if (obj != null)
                _return = Convert.ToInt32(obj);

            return _return;
        }


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
        public LN.Model.tb_FOSPOP GetModel(string FOS_POPSeat)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 FOS_ID,FOS_POPSeat,FOS_POPMateria,FOS_POPRealHeight,FOS_POPRealWith,FOS_POPHeight,FOS_POPWith from tb_FOSPOP ");
            strSql.Append(" where FOS_POPSeat=@FOS_POPSeat ");
			SqlParameter[] parameters = {
					new SqlParameter("@FOS_POPSeat", SqlDbType.NVarChar,100)};
            parameters[0].Value = FOS_POPSeat;

            LN.Model.tb_FOSPOP model = null;
            SqlDataReader reader = DbHelperSQL.ExecuteReader(DbHelperSQL.connectionString(), strSql.ToString(), parameters);
            if (reader.Read())
			{
                model = new LN.Model.tb_FOSPOP();
                if (!string.IsNullOrEmpty(reader["FOS_ID"].ToString()))
                    model.FOS_ID = int.Parse(reader["FOS_ID"].ToString());

                model.FOS_POPSeat = reader["FOS_POPSeat"].ToString();
                model.FOS_POPMateria = reader["FOS_POPMateria"].ToString();

                if (!string.IsNullOrEmpty(reader["FOS_POPRealHeight"].ToString()))
                    model.FOS_POPRealHeight = Convert.ToDecimal(reader["FOS_POPRealHeight"]);

                if (!string.IsNullOrEmpty(reader["FOS_POPRealWith"].ToString()))
                    model.FOS_POPRealWith = Convert.ToDecimal(reader["FOS_POPRealWith"]);

                if (!string.IsNullOrEmpty(reader["FOS_POPHeight"].ToString()))
                    model.FOS_POPHeight = Convert.ToDecimal(reader["FOS_POPHeight"]);

                if (!string.IsNullOrEmpty(reader["FOS_POPWith"].ToString()))
                    model.FOS_POPWith = Convert.ToDecimal(reader["FOS_POPWith"]);
			}
            reader.Close();
            return model;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
        public IList<LN.Model.tb_FOSPOP> GetList(string strWhere)
		{
            IList<LN.Model.tb_FOSPOP> modelList = new List<LN.Model.tb_FOSPOP>();
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select FOS_ID,FOS_POPSeat,FOS_POPMateria,FOS_POPRealHeight,FOS_POPRealWith,FOS_POPHeight,FOS_POPWith ");
			strSql.Append(" FROM tb_FOSPOP ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
            SqlDataReader reader = DbHelperSQL.ExecuteReader(DbHelperSQL.connectionString(), strSql.ToString());
            while (reader.Read())
            {
                LN.Model.tb_FOSPOP model = new LN.Model.tb_FOSPOP();
                if (!string.IsNullOrEmpty(reader["FOS_ID"].ToString()))
                    model.FOS_ID = int.Parse(reader["FOS_ID"].ToString());

                model.FOS_POPSeat = reader["FOS_POPSeat"].ToString();
                model.FOS_POPMateria = reader["FOS_POPMateria"].ToString();

                if (!string.IsNullOrEmpty(reader["FOS_POPRealHeight"].ToString()))
                    model.FOS_POPRealHeight = Convert.ToDecimal(reader["FOS_POPRealHeight"]);

                if (!string.IsNullOrEmpty(reader["FOS_POPRealWith"].ToString()))
                    model.FOS_POPRealWith = Convert.ToDecimal(reader["FOS_POPRealWith"]);

                if (!string.IsNullOrEmpty(reader["FOS_POPHeight"].ToString()))
                    model.FOS_POPHeight = Convert.ToDecimal(reader["FOS_POPHeight"]);

                if (!string.IsNullOrEmpty(reader["FOS_POPWith"].ToString()))
                    model.FOS_POPWith = Convert.ToDecimal(reader["FOS_POPWith"]);

                modelList.Add(model);
            }
            reader.Close();
            return modelList;
		}

		#endregion  成员方法
	}
}

