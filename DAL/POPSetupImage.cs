using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using LN.DBUtility;//请先添加引用
namespace LN.DAL
{
    /// <summary>
    /// 数据访问类POPSetupImage。
    /// </summary>
    public class POPSetupImage
    {
        public POPSetupImage()
        { }
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
        /// 增加一条数据
        /// </summary>
        public int Add(LN.Model.POPSetupImage model)
        {
            int _return = 0;
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into POPSetupImage(");
            strSql.Append("i_POPID,i_ShopId,i_SupplierID,i_POPinfoID,i_PhotoUrl,i_OperatorID,i_ExamUserID,i_Score,i_ExamRemarks,i_Additional)");
            strSql.Append(" values (");
            strSql.Append("(SELECT TOP 1 [POPID] FROM [POPLaunch] ORDER BY ID DESC),@i_ShopId,@i_SupplierID,@i_POPinfoID,@i_PhotoUrl,@i_OperatorID,@i_ExamUserID,@i_Score,@i_ExamRemarks,'常规')");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@i_ShopId", SqlDbType.Int,4),
					new SqlParameter("@i_SupplierID", SqlDbType.Int,4),
					new SqlParameter("@i_POPinfoID", SqlDbType.Int,4),
					new SqlParameter("@i_PhotoUrl", SqlDbType.VarChar,100),
					new SqlParameter("@i_OperatorID", SqlDbType.Int,4),
					new SqlParameter("@i_ExamUserID", SqlDbType.Int,4),
					new SqlParameter("@i_Score", SqlDbType.Int,4),
					new SqlParameter("@i_ExamRemarks", SqlDbType.VarChar,1000)};
            parameters[0].Value = model.i_ShopId;
            parameters[1].Value = model.i_SupplierID;
            parameters[2].Value = model.i_POPinfoID;
            parameters[3].Value = model.i_PhotoUrl;
            parameters[4].Value = model.i_OperatorID;
            parameters[5].Value = model.i_ExamUserID;
            parameters[6].Value = model.i_Score;
            parameters[7].Value = model.i_ExamRemarks;

            object obj = DbHelperSQL.GetSingle(DbHelperSQL.connectionString(), strSql.ToString(), parameters);
            if (obj != null)
            {
                _return = Convert.ToInt32(obj);
            }
            return _return;
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public int Update(LN.Model.POPSetupImage model)
        {
            int _return = 0;
            StringBuilder strSql = new StringBuilder(); //i_POPID
            strSql.Append("update POPSetupImage set ");
            strSql.Append("i_ExamUserID=@i_ExamUserID,");
            strSql.Append("i_Score=@i_Score,");
            strSql.Append("i_ExamRemarks=@i_ExamRemarks");
            strSql.Append(" where i_POPID=@i_POPID and i_ShopId=@i_ShopId and i_SupplierID=@i_SupplierID ");
            strSql.Append(";select @@ROWCOUNT");
            SqlParameter[] parameters = {
					new SqlParameter("@i_POPID", SqlDbType.VarChar,100),
					new SqlParameter("@i_ShopId", SqlDbType.Int,4),
					new SqlParameter("@i_SupplierID", SqlDbType.Int,4),
					new SqlParameter("@i_ExamUserID", SqlDbType.Int,4),
					new SqlParameter("@i_Score", SqlDbType.Int,4),
					new SqlParameter("@i_ExamRemarks", SqlDbType.VarChar,1000)};
            parameters[0].Value = model.i_POPID;
            parameters[1].Value = model.i_ShopId;
            parameters[2].Value = model.i_SupplierID;
            parameters[3].Value = model.i_ExamUserID;
            parameters[4].Value = model.i_Score;
            parameters[5].Value = model.i_ExamRemarks;

            object obj = DbHelperSQL.GetSingle(DbHelperSQL.connectionString(), strSql.ToString(), parameters);
            if (obj != null)
            {
                _return = Convert.ToInt32(obj);
            }
            return _return;
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void Delete(int i_Id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from POPSetupImage ");
            strSql.Append(" where i_Id=@i_Id ");
            SqlParameter[] parameters = {
					new SqlParameter("@i_Id", SqlDbType.Int,4)};
            parameters[0].Value = i_Id;

            DbHelperSQL.ExecuteSql(DbHelperSQL.connectionString(), strSql.ToString(), parameters);
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public LN.Model.POPSetupImage GetModel(int i_ShopId, int i_SupplierID, string i_POPID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 i_Id,i_POPID,i_ShopId,i_SupplierID,i_POPinfoID,i_PhotoUrl,i_OperatorID,i_ExamUserID,i_Score,i_ExamRemarks,i_POPID,i_Additional from POPSetupImage ");
            strSql.Append(" where i_ShopId=@i_ShopId and i_SupplierID=@i_SupplierID and i_POPID=@i_POPID ");
            SqlParameter[] parameters = {
					new SqlParameter("@i_ShopId", SqlDbType.Int,4),
                    new SqlParameter("@i_SupplierID", SqlDbType.Int,4),
                    new SqlParameter("@i_POPID", SqlDbType.VarChar,100)};
            parameters[0].Value = i_ShopId;
            parameters[1].Value = i_SupplierID;
            parameters[2].Value = i_POPID;
            LN.Model.POPSetupImage model = null;
            DataSet ds = DbHelperSQL.Query(DbHelperSQL.connectionString(), strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                model = new LN.Model.POPSetupImage();
                if (ds.Tables[0].Rows[0]["i_Id"].ToString() != "")
                {
                    model.i_Id = int.Parse(ds.Tables[0].Rows[0]["i_Id"].ToString());
                }
                if (ds.Tables[0].Rows[0]["i_ShopId"].ToString() != "")
                {
                    model.i_ShopId = int.Parse(ds.Tables[0].Rows[0]["i_ShopId"].ToString());
                }
                if (ds.Tables[0].Rows[0]["i_SupplierID"].ToString() != "")
                {
                    model.i_SupplierID = int.Parse(ds.Tables[0].Rows[0]["i_SupplierID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["i_POPinfoID"].ToString() != "")
                {
                    model.i_POPinfoID = int.Parse(ds.Tables[0].Rows[0]["i_POPinfoID"].ToString());
                }
                model.i_PhotoUrl = ds.Tables[0].Rows[0]["i_PhotoUrl"].ToString();
                if (ds.Tables[0].Rows[0]["i_OperatorID"].ToString() != "")
                {
                    model.i_OperatorID = int.Parse(ds.Tables[0].Rows[0]["i_OperatorID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["i_ExamUserID"].ToString() != "")
                {
                    model.i_ExamUserID = int.Parse(ds.Tables[0].Rows[0]["i_ExamUserID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["i_Score"].ToString() != "")
                {
                    model.i_Score = int.Parse(ds.Tables[0].Rows[0]["i_Score"].ToString());
                }
                model.i_ExamRemarks = ds.Tables[0].Rows[0]["i_ExamRemarks"].ToString();
                model.i_POPID = ds.Tables[0].Rows[0]["i_POPID"].ToString();
                model.i_Additional = ds.Tables[0].Rows[0]["i_Additional"].ToString();
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
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select i_Id,i_POPID,i_ShopId,i_SupplierID,i_POPinfoID,i_PhotoUrl,i_OperatorID,i_ExamUserID,i_Score,i_ExamRemarks,i_Additional ");
            strSql.Append(" FROM POPSetupImage ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(DbHelperSQL.connectionString(), strSql.ToString());
        }

        #endregion  成员方法
    }
}

