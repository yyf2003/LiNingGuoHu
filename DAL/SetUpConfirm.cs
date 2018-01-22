using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using LN.DBUtility;//请先添加引用
namespace LN.DAL
{
    /// <summary>
    /// 数据访问类SetUpConfirm。
    /// </summary>
    public class SetUpConfirm
    {
        public SetUpConfirm()
        { }
        #region  成员方法

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperSQL.GetMaxID(DbHelperSQL.connectionString(), "ID", "SetUpConfirm");
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from SetUpConfirm");
            strSql.Append(" where ID=@ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)};
            parameters[0].Value = ID;

            return DbHelperSQL.Exists(DbHelperSQL.connectionString(), strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(LN.Model.SetUpConfirm model)
        {
            int _return = 0;
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into SetUpConfirm(");
            strSql.Append("DealerID,Shopid,SupplierID,FXID,POPID,SetUpCount,SetUpState,OperatorID,SetUpDesc,PicUrl,Boolinstall)");
            strSql.Append(" values (");
            strSql.Append("@DealerID,@Shopid,@SupplierID,@FXID,@POPID,@SetUpCount,@SetUpState,@OperatorID,@SetUpDesc,@PicUrl,@Boolinstall)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@DealerID", SqlDbType.VarChar,50),
					new SqlParameter("@Shopid", SqlDbType.Int,4),
					new SqlParameter("@SupplierID", SqlDbType.Int,4),
                    new SqlParameter("@FXID", SqlDbType.VarChar,50),
					new SqlParameter("@POPID", SqlDbType.VarChar,50),
					new SqlParameter("@SetUpCount", SqlDbType.Int,4),
					new SqlParameter("@SetUpState", SqlDbType.Int,4),
					new SqlParameter("@OperatorID", SqlDbType.Int,4),
					new SqlParameter("@SetUpDesc", SqlDbType.VarChar,500),
					new SqlParameter("@PicUrl", SqlDbType.VarChar,500) ,
					new SqlParameter("@Boolinstall", SqlDbType.Int,4) 

            };
            parameters[0].Value = model.DealerID;
            parameters[1].Value = model.Shopid;
            parameters[2].Value = model.SupplierID;
            parameters[3].Value = model.FXID;
            parameters[4].Value = model.POPID;
            parameters[5].Value = model.SetUpCount;
            parameters[6].Value = 1;
            parameters[7].Value = model.OperatorID;
            parameters[8].Value = model.SetUpDesc;
            parameters[9].Value = model.PicUrl;
            parameters[10].Value = model.Boolinstall;

            object obj = DbHelperSQL.GetSingle(DbHelperSQL.connectionString(), strSql.ToString(), parameters);
            if (obj != null)
                _return = Convert.ToInt32(obj);

            return _return;
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public void Update(LN.Model.SetUpConfirm model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update SetUpConfirm set ");
            strSql.Append("DealerID=@DealerID,");
            strSql.Append("Shopid=@Shopid,");
            strSql.Append("SupplierID=@SupplierID,");
            strSql.Append("FXID=@FXID,");
            strSql.Append("POPID=@POPID,");
            strSql.Append("SetUpCount=@SetUpCount,");
            strSql.Append("SetUpState=@SetUpState,");
            strSql.Append("OperatorID=@OperatorID,");
            strSql.Append("OperatorDate=@OperatorDate,");
            strSql.Append("SetUpDesc=@SetUpDesc");
            strSql.Append(" where ID=@ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4),
					new SqlParameter("@DealerID", SqlDbType.VarChar,50),
					new SqlParameter("@Shopid", SqlDbType.Int,4),
					new SqlParameter("@SupplierID", SqlDbType.Int,4),
                    new SqlParameter("@FXID", SqlDbType.VarChar,50),
					new SqlParameter("@POPID", SqlDbType.VarChar,50),
					new SqlParameter("@SetUpCount", SqlDbType.Int,4),
					new SqlParameter("@SetUpState", SqlDbType.Int,4),
					new SqlParameter("@OperatorID", SqlDbType.Int,4),
					new SqlParameter("@OperatorDate", SqlDbType.DateTime),
					new SqlParameter("@SetUpDesc", SqlDbType.VarChar,500)};
            parameters[0].Value = model.ID;
            parameters[1].Value = model.DealerID;
            parameters[2].Value = model.Shopid;
            parameters[3].Value = model.SupplierID;
            parameters[4].Value = model.FXID;
            parameters[5].Value = model.POPID;
            parameters[6].Value = model.SetUpCount;
            parameters[7].Value = model.SetUpState;
            parameters[8].Value = model.OperatorID;
            parameters[9].Value = model.OperatorDate;
            parameters[10].Value = model.SetUpDesc;

            DbHelperSQL.ExecuteSql(DbHelperSQL.connectionString(), strSql.ToString(), parameters);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void Delete(int ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete SetUpConfirm ");
            strSql.Append(" where ID=@ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)};
            parameters[0].Value = ID;

            DbHelperSQL.ExecuteSql(DbHelperSQL.connectionString(), strSql.ToString(), parameters);
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public LN.Model.SetUpConfirm GetModel(int ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 ID,DealerID,Shopid,SupplierID,FXID,POPID,SetUpCount,SetUpState,OperatorID,OperatorDate,SetUpDesc,PicUrl,Boolinstall from SetUpConfirm ");
            strSql.Append(" where ID=@ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)};
            parameters[0].Value = ID;

            LN.Model.SetUpConfirm model = new LN.Model.SetUpConfirm();
            DataSet ds = DbHelperSQL.Query(DbHelperSQL.connectionString(), strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["ID"].ToString() != "")
                {
                    model.ID = int.Parse(ds.Tables[0].Rows[0]["ID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["DealerID"].ToString() != "")
                {
                    model.DealerID = ds.Tables[0].Rows[0]["DealerID"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Shopid"].ToString() != "")
                {
                    model.Shopid = int.Parse(ds.Tables[0].Rows[0]["Shopid"].ToString());
                }
                if (ds.Tables[0].Rows[0]["SupplierID"].ToString() != "")
                {
                    model.SupplierID = int.Parse(ds.Tables[0].Rows[0]["SupplierID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["FXID"].ToString() != "")
                {
                    model.FXID = ds.Tables[0].Rows[0]["FXID"].ToString();
                }
                if (ds.Tables[0].Rows[0]["POPID"].ToString() != "")
                {
                    model.POPID = ds.Tables[0].Rows[0]["POPID"].ToString();
                }
                if (ds.Tables[0].Rows[0]["SetUpCount"].ToString() != "")
                {
                    model.SetUpCount = int.Parse(ds.Tables[0].Rows[0]["SetUpCount"].ToString());
                }
                if (ds.Tables[0].Rows[0]["SetUpState"].ToString() != "")
                {
                    model.SetUpState = int.Parse(ds.Tables[0].Rows[0]["SetUpState"].ToString());
                }
                if (ds.Tables[0].Rows[0]["OperatorID"].ToString() != "")
                {
                    model.OperatorID = int.Parse(ds.Tables[0].Rows[0]["OperatorID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Boolinstall"].ToString() != "")
                {
                    model.Boolinstall = int.Parse(ds.Tables[0].Rows[0]["Boolinstall"].ToString());
                }
                model.OperatorDate = ds.Tables[0].Rows[0]["OperatorDate"].ToString();
                model.SetUpDesc = ds.Tables[0].Rows[0]["SetUpDesc"].ToString();
                model.PicUrl = ds.Tables[0].Rows[0]["PicUrl"].ToString();

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
            strSql.Append("select ID,DealerID,Shopid,SupplierID,FXID,POPID,SetUpCount,SetUpState,OperatorID,OperatorDate,SetUpDesc,PicUrl,Boolinstall ");
            strSql.Append(" FROM SetUpConfirm ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(DbHelperSQL.connectionString(), strSql.ToString());
        }

        /// <summary>
        /// 从视图里返回数据结果
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataTable GetListFromView(string strWhere)
        {
            DataTable dt = new DataTable();
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ID, DealerName,DealerID,Shopname,Shopid,POPTitle,POPID,SupplierID,SupplierName,OperatorID,Username,OperatorDate,SetUpDesc,PicUrl,SetUpCount,posid,shopmaster,shopmasterphone ");
            strSql.Append(" FROM View_SetUpConfirmList ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            dt = DbHelperSQL.Query(DbHelperSQL.connectionString(), strSql.ToString()).Tables[0];
            if (dt.Rows.Count > 0)
            {
                dt.Columns.Add("Num");
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    dt.Rows[i]["Num"] = i + 1;
                }
            }
            return dt;
        }

        /// <summary>
        /// 返回查询的安装店铺数量
        /// </summary>
        /// <param name="SupplierID">供应商ID</param>
        /// <param name="DealerID">一级客户ID</param>
        /// <param name="AreaID">区域ID</param>
        /// <param name="ProviceID">省份ID</param>
        /// <param name="CityID">市ID</param>
        /// <param name="Boolinstall">是否支持安装  1 支持 0 ，不支持，自主安装</param>
        /// <returns></returns>
        public DataTable GetSetUpConfirmSearch(int SupplierID, string DealerID, string FXID, int AreaID, int ProviceID, int CityID, string popid, string begindate, string enddate, string department, int boolinstall)
        {
            SqlParameter[] parm ={
                new SqlParameter ("@SupplierID",SqlDbType.Int ,4),
                new SqlParameter ("@DealerID",SqlDbType.VarChar ,50),
                new SqlParameter ("@AreaID",SqlDbType.Int ,4),
                new SqlParameter ("@ProviceID",SqlDbType.Int ,4),
                new SqlParameter ("@CityID",SqlDbType.Int ,4),
                new SqlParameter ("@FXID",SqlDbType.VarChar ,50),
                new SqlParameter ("@popid",SqlDbType.VarChar ,50),
                new SqlParameter("@boolinstall",SqlDbType.Int ,4),
                new SqlParameter ("@begindate",SqlDbType.VarChar ,40),
                new SqlParameter ("@enddate",SqlDbType.VarChar ,40),
                new SqlParameter ("@department",SqlDbType.VarChar ,10)
     };
            parm[0].Value = SupplierID;
            parm[1].Value = DealerID;
            parm[2].Value = AreaID;
            parm[3].Value = ProviceID;
            parm[4].Value = CityID;
            parm[5].Value = FXID;
            parm[6].Value = popid;
            parm[7].Value = boolinstall;
            parm[8].Value = begindate;
            parm[9].Value = enddate;
            parm[10].Value = department;
            DataSet ds = DbHelperSQL.RunProcedure(DbHelperSQL.connectionString(), "GetSetUpConfirmFun", parm, "dt");
            return ds.Tables[0];

        }

        /// <summary>
        /// 查询已经完成安装的数据
        /// </summary>
        /// <param name="DealerID">一级客户ID</param>
        /// <param name="SupplierID">供应商ID</param>
        /// <param name="POPID">POPID</param>
        /// <param name="Boolinstall">安装类型</param>
        /// <returns></returns>
        public DataTable GetSetUpConfirmSearch2(string DealerID, int SupplierID, string POPID, int Boolinstall)
        {
            SqlParameter[] parm ={
                new SqlParameter ("@DealerID",SqlDbType.VarChar ,50),
                new SqlParameter ("@SupplierID",SqlDbType.Int ,4),
                new SqlParameter ("@POPID",SqlDbType.VarChar ,50),
                new SqlParameter ("@Boolinstall",SqlDbType.Int ,4)
     };
            parm[0].Value = DealerID;
            parm[1].Value = SupplierID;
            parm[2].Value = POPID;
            parm[3].Value = Boolinstall;
            DataSet ds = DbHelperSQL.RunProcedure(DbHelperSQL.connectionString(), "GetSetUpConfirmFun2", parm, "dt");
            return ds.Tables[0];
        }

        #endregion  成员方法
    }
}

