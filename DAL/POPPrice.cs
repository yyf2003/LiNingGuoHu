using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using LN.DBUtility;//请先添加引用
namespace LN.DAL
{
	/// <summary>
	/// 数据访问类POPPrice。
	/// </summary>
	public class POPPrice
	{
		public POPPrice()
		{}
		#region  成员方法

		/// <summary>
        /// 操作数据（增加，修改）
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
		/// 删除一条数据
		/// </summary>
		public void Delete(int PriceID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete POPPrice ");
			strSql.Append(" where PriceID=@PriceID ");
			SqlParameter[] parameters = {
					new SqlParameter("@PriceID", SqlDbType.Int,4)};
			parameters[0].Value = PriceID;

            DbHelperSQL.ExecuteSql(DbHelperSQL.connectionString(), strSql.ToString(), parameters);
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public LN.Model.POPPrice GetModel(int PriceID)
		{
			
			StringBuilder strSql=new StringBuilder();
            strSql.Append("SELECT  top 1 p.PriceID,p.POPID,p.SupplierID,p.POPMaterial,p.POPprice,p.ExamState,p.Remark,(SELECT [SupplierName] FROM [NewLiNing].[dbo].[SupplierInfo] WHERE  [SupplierID] = p.SupplierID) AS SupplierName,(SELECT [MateriaPro] FROM [POPMateriaData] WHERE [MateriaID]=p.POPMaterial) AS POPMaterialName,UserID FROM POPPrice AS p ");
			strSql.Append(" WHERE PriceID=@PriceID ");
			SqlParameter[] parameters = {
					new SqlParameter("@PriceID", SqlDbType.Int,4)};
			parameters[0].Value = PriceID;

            LN.Model.POPPrice model = null;
            SqlDataReader reader = DbHelperSQL.ExecuteReader(DbHelperSQL.connectionString(), strSql.ToString(), parameters);
            if (reader.Read())
			{
                model = new LN.Model.POPPrice();
				if(!string.IsNullOrEmpty(reader.GetInt32(0).ToString()))
                    model.PriceID = reader.GetInt32(0);

                if (!string.IsNullOrEmpty(reader.GetString(1)))
                    model.POPID = reader.GetString(1);

                if (!string.IsNullOrEmpty(reader.GetInt32(2).ToString()))
                    model.SupplierID = reader.GetInt32(2);

                if (!string.IsNullOrEmpty(reader.GetInt32(3).ToString()))
                    model.POPMaterial = reader.GetInt32(3);

                if (!string.IsNullOrEmpty(reader.GetDecimal(4).ToString()))
                    model.POPprice = reader.GetDecimal(4);

                if (!string.IsNullOrEmpty(reader.GetInt32(5).ToString()))
                    model.ExamState = reader.GetInt32(5);

                if (!string.IsNullOrEmpty(reader.GetString(6)))
                    model.Remark = reader.GetString(6);

                if (!string.IsNullOrEmpty(reader.GetString(7)))
                    model.SupplierName = reader.GetString(7);

                if (!string.IsNullOrEmpty(reader.GetInt32(8).ToString()))
                    model.UserID = reader.GetInt32(8);
			}
            reader.Close();
            return model;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public IList<LN.Model.POPPrice> GetList(string strWhere)
        {
            IList<LN.Model.POPPrice> list = new List<LN.Model.POPPrice>();
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT p.PriceID,p.POPID,p.SupplierID,p.POPMaterial,p.POPprice,p.ExamState,p.Remark,(SELECT [SupplierName] FROM [SupplierInfo] WHERE  [SupplierID] = p.SupplierID) AS SupplierName,(SELECT [MateriaPro] FROM [POPMateriaData] WHERE [MateriaID]=p.POPMaterial) AS POPMaterialName,UserID ");
            strSql.Append(" FROM POPPrice AS p ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" WHERE " + strWhere);
            }
            SqlDataReader reader = DbHelperSQL.ExecuteReader(DbHelperSQL.connectionString(), strSql.ToString());
            while (reader.Read())
            {
                LN.Model.POPPrice model = new LN.Model.POPPrice();
                if(!string.IsNullOrEmpty(reader.GetInt32(0).ToString()))
                    model.PriceID = reader.GetInt32(0);

                if (!string.IsNullOrEmpty(reader.GetString(1)))
                    model.POPID = reader.GetString(1);

                if (!string.IsNullOrEmpty(reader.GetInt32(2).ToString()))
                    model.SupplierID = reader.GetInt32(2);

                if (!string.IsNullOrEmpty(reader.GetInt32(3).ToString()))
                    model.POPMaterial = reader.GetInt32(3);

                if (!string.IsNullOrEmpty(reader.GetDecimal(4).ToString()))
                    model.POPprice = reader.GetDecimal(4);

                if (!string.IsNullOrEmpty(reader.GetInt32(5).ToString()))
                    model.ExamState = reader.GetInt32(5);

                if (!string.IsNullOrEmpty(reader.GetString(6)))
                    model.Remark = reader.GetString(6);

                if (!string.IsNullOrEmpty(reader.GetString(7)))
                    model.SupplierName = reader.GetString(7);

                if (!string.IsNullOrEmpty(reader.GetString(8)))
                    model.POPMaterialName = reader.GetString(8);

                if (!string.IsNullOrEmpty(reader.GetInt32(9).ToString()))
                    model.UserID = reader.GetInt32(9);
                list.Add(model);
            }
            reader.Close();
            return list;
        }

        /// <summary>
        /// 审批供应商价格操作
        /// </summary>
        /// <param name="list"></param>
        public void ExamPrice(List<string> list)
        {
            DbHelperSQL.ExecuteSqlTran(DbHelperSQL.connectionString(), list);
        }

        /// <summary>
        /// 指定用户是否有新POP发起，需要提交材料报价
        /// </summary>
        /// <param name="userid">用户编号</param>
        /// <returns>返回POPID，SupplierID</returns>
        public IList<string> IsSubmitPrice(int userid)
        {
            IList<string> list = new List<string>();
            SqlParameter[] parameters = {
					new SqlParameter("@UserID", SqlDbType.Int,4)};
            parameters[0].Value = userid;
            SqlDataReader reader = DbHelperSQL.RunProcedure(DbHelperSQL.connectionString(), "P_IsExistLaunch", parameters);
            if (reader.Read())
            {
                list.Add(reader.GetString(0));
                list.Add(reader.GetInt32(1).ToString());
            }
            reader.Close();
            return list;
        }

        /// <summary>
        /// 指定用户是否有新POP发起，需要提交材料报价
        /// </summary>
        /// <param name="userid">用户编号</param>
        /// <returns>返回POPID</returns>
        public string IsSetMPrice(int userid)
        {
            string POPID = String.Empty;
            SqlParameter[] parameters = {
					new SqlParameter("@UserID", SqlDbType.Int,4)};
            parameters[0].Value = userid;
            SqlDataReader reader = DbHelperSQL.RunProcedure(DbHelperSQL.connectionString(), "VM_IsExistLaunch", parameters);
            if (reader.Read())
            {
                POPID = reader.GetString(0);
            }
            reader.Close();
            return POPID;
        }

        /// <summary>
        /// 得到某期要审批的材料报价
        /// </summary>
        /// <param name="supplierID"></param>
        /// <returns></returns>
        public DataSet GetExamPriceList(int supplierID)
        {
            SqlParameter[] paras ={
                new SqlParameter("@supplierID",SqlDbType.Int,4)
            };

            paras[0].Value = supplierID;

            DataSet ds = DbHelperSQL.RunProcedure(DbHelperSQL.connectionString(), "GetNewNoExamPrice", paras, "tb");
            return ds;
        }

		#endregion  成员方法
	}
}

