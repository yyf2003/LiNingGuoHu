using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using LN.DBUtility;//请先添加引用
namespace LN.DAL
{
	/// <summary>
	/// 数据访问类GoodsConfirm。
	/// </summary>
	public class GoodsConfirm
	{
		public GoodsConfirm()
		{}
		#region  成员方法

		/// <summary>
		/// 操作数据
		/// </summary>
		public int Operate(LN.Model.GoodsConfirm model)
		{
            int _return = 0;
			SqlParameter[] parameters = {
					new SqlParameter("@GoodsOrderNO", SqlDbType.VarChar,100),
					new SqlParameter("@ReceiveUserID", SqlDbType.Int,4),
					new SqlParameter("@receiveState", SqlDbType.Int,4),
					new SqlParameter("@ReceiveDate", SqlDbType.DateTime),
					new SqlParameter("@Remarks", SqlDbType.VarChar,1000)};
            parameters[0].Value = model.g_GoodsOrderNO;
            parameters[1].Value = model.g_ReceiveUserID;
            parameters[2].Value = model.g_receiveState;
            parameters[3].Value = model.g_ReceiveDate;
            parameters[4].Value = model.g_Remarks;

            object obj = DbHelperSQL.RunProcedure(DbHelperSQL.connectionString(), "UP_OperateGoodsConfirm", parameters, out _return);
			if (obj != null)
                _return = Convert.ToInt32(obj);

            return _return;
			

		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(int ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete GoodsConfirm ");
            strSql.Append(" where g_ID=@g_ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@g_ID", SqlDbType.Int,4)};
			parameters[0].Value = ID;

            DbHelperSQL.ExecuteSql(DbHelperSQL.connectionString(), strSql.ToString(), parameters);
		}


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public LN.Model.GoodsConfirm GetModel(int g_ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 g_ID,g_GoodsOrderNO,g_ReceiveUserID,g_receiveState,g_ReceiveDate,g_Remarks from GoodsConfirm ");
            strSql.Append(" where g_ID=@g_ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@g_ID", SqlDbType.Int,4)};
            parameters[0].Value = g_ID;

            LN.Model.GoodsConfirm model = new LN.Model.GoodsConfirm();
            DataSet ds = DbHelperSQL.Query(DbHelperSQL.connectionString(), strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["g_ID"].ToString() != "")
                {
                    model.g_ID = int.Parse(ds.Tables[0].Rows[0]["g_ID"].ToString());
                }
                model.g_GoodsOrderNO = ds.Tables[0].Rows[0]["g_GoodsOrderNO"].ToString();
                if (ds.Tables[0].Rows[0]["g_ReceiveUserID"].ToString() != "")
                {
                    model.g_ReceiveUserID = int.Parse(ds.Tables[0].Rows[0]["g_ReceiveUserID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["g_receiveState"].ToString() != "")
                {
                    model.g_receiveState = int.Parse(ds.Tables[0].Rows[0]["g_receiveState"].ToString());
                }
                if (ds.Tables[0].Rows[0]["g_ReceiveDate"].ToString() != "")
                {
                    model.g_ReceiveDate = DateTime.Parse(ds.Tables[0].Rows[0]["g_ReceiveDate"].ToString());
                }
                model.g_Remarks = ds.Tables[0].Rows[0]["g_Remarks"].ToString();
                return model;
            }
            else
            {
                return null;
            }
        }

		#endregion  成员方法
	}
}

