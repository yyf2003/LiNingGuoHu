using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using LN.DBUtility;//请先添加引用
namespace LN.DAL
{
    /// <summary>
    /// 数据访问类POPReprotDamage。
    /// </summary>
    public class POPReprotDamage
    {
        public POPReprotDamage()
        { }
        #region  成员方法

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperSQL.GetMaxID(DbHelperSQL.connectionString(), "ID", "POPReprotDamage");
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from POPReprotDamage");
            strSql.Append(" where ID=@ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)};
            parameters[0].Value = ID;

            return DbHelperSQL.Exists(DbHelperSQL.connectionString(), strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(LN.Model.POPReprotDamage model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into POPReprotDamage(");
            strSql.Append("ShopID,SupplierID,UpUserID,PhotoPath,ShopDesc,DSRState,DSRDesc,DSRDate)");
            strSql.Append(" values (");
            strSql.Append("@ShopID,@SupplierID,@UpUserID,@PhotoPath,@ShopDesc,@DSRState,@DSRDesc,@DSRDate)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@ShopID", SqlDbType.Int,4),
					new SqlParameter("@SupplierID", SqlDbType.Int,4),
					new SqlParameter("@UpUserID", SqlDbType.Int,4),
					new SqlParameter("@PhotoPath", SqlDbType.VarChar,200),
					new SqlParameter("@ShopDesc", SqlDbType.VarChar,500),
					new SqlParameter("@DSRState", SqlDbType.Int,4),
					new SqlParameter("@DSRDesc", SqlDbType.VarChar,500),
					new SqlParameter("@DSRDate", SqlDbType.VarChar,20)};
            parameters[0].Value = model.ShopID;
            parameters[1].Value = model.SupplierID;
            parameters[2].Value = model.UpUserID;
            parameters[3].Value = model.PhotoPath;
            parameters[4].Value = model.ShopDesc;
            parameters[5].Value = model.DSRState;
            parameters[6].Value = model.DSRDesc;
            parameters[7].Value = model.DSRDate;
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
        public void Update(LN.Model.POPReprotDamage model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update POPReprotDamage set ");
            strSql.Append("ShopID=@ShopID,");
            strSql.Append("SupplierID=@SupplierID,");
            strSql.Append("UpUserID=@UpUserID,");
            strSql.Append("UpPOPDate=@UpPOPDate,");
            strSql.Append("PhotoPath=@PhotoPath,");
            strSql.Append("ShopDesc=@ShopDesc,");
            strSql.Append("DSRState=@DSRState,");
            strSql.Append("DSRDesc=@DSRDesc,");
            strSql.Append("DSRDate=@DSRDate,");
            strSql.Append("VMState=@VMState,");
            strSql.Append("VMDate=@VMDate,");
            strSql.Append("VMDesc=@VMDesc");
            strSql.Append(" where ID=@ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4),
					new SqlParameter("@ShopID", SqlDbType.Int,4),
					new SqlParameter("@SupplierID", SqlDbType.Int,4),
					new SqlParameter("@UpUserID", SqlDbType.Int,4),
					new SqlParameter("@UpPOPDate", SqlDbType.DateTime),
					new SqlParameter("@PhotoPath", SqlDbType.VarChar,200),
					new SqlParameter("@ShopDesc", SqlDbType.VarChar,500),
					new SqlParameter("@DSRState", SqlDbType.Int,4),
					new SqlParameter("@DSRDesc", SqlDbType.VarChar,500),
					new SqlParameter("@DSRDate", SqlDbType.VarChar,20),
					new SqlParameter("@VMState", SqlDbType.Int,4),
					new SqlParameter("@VMDate", SqlDbType.VarChar,20),
					new SqlParameter("@VMDesc", SqlDbType.VarChar,500)};
            parameters[0].Value = model.ID;
            parameters[1].Value = model.ShopID;
            parameters[2].Value = model.SupplierID;
            parameters[3].Value = model.UpUserID;
            parameters[4].Value = model.UpPOPDate;
            parameters[5].Value = model.PhotoPath;
            parameters[6].Value = model.ShopDesc;
            parameters[7].Value = model.DSRState;
            parameters[8].Value = model.DSRDesc;
            parameters[9].Value = model.DSRDate;
            parameters[10].Value = model.VMState;
            parameters[11].Value = model.VMDate;
            parameters[12].Value = model.VMDesc;
            DbHelperSQL.ExecuteSql(DbHelperSQL.connectionString(), strSql.ToString(), parameters);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void Delete(int ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete POPReprotDamage ");
            strSql.Append(" where ID=@ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)};
            parameters[0].Value = ID;

            DbHelperSQL.ExecuteSql(DbHelperSQL.connectionString(), strSql.ToString(), parameters);
        }

        /// <summary>
        /// VM检查报损坏
        /// </summary>
        /// <param name="UserID">VM UserID</param>
        /// <param name="VMDesc">描述</param>
        /// <param name="date">检查日期</param>
        public void VMCheckReprotDamage(int UserID, string VMDesc, string date, int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update  POPReprotDamage ");
            strSql.Append("set   VMState =1 , ");
            strSql.Append("VMDesc=@VMDesc , ");
            strSql.Append("VMDate=@VMDate , ");
            strSql.Append("VMUserID=@VMUserID ");
            strSql.Append(" where ID=@ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@VMDesc", SqlDbType.VarChar ,500),
					new SqlParameter("@VMDate", SqlDbType.VarChar,20),
					new SqlParameter("@VMUserID", SqlDbType.Int,4),
					new SqlParameter("@ID", SqlDbType.Int,4), 
            };
            parameters[0].Value = VMDesc;
            parameters[1].Value = date;
            parameters[2].Value = UserID;
            parameters[3].Value = ID;
            DbHelperSQL.ExecuteSql(DbHelperSQL.connectionString(), strSql.ToString(), parameters);

        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public LN.Model.POPReprotDamage GetModel(int ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 ID,ShopID,SupplierID,UpUserID,UpPOPDate,PhotoPath,ShopDesc,DSRState,DSRDesc,DSRDate,VMState,VMDate,VMDesc from POPReprotDamage ");
            strSql.Append(" where ID=@ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)};
            parameters[0].Value = ID;

            LN.Model.POPReprotDamage model = new LN.Model.POPReprotDamage();
            DataSet ds = DbHelperSQL.Query(DbHelperSQL.connectionString(), strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["ID"].ToString() != "")
                {
                    model.ID = int.Parse(ds.Tables[0].Rows[0]["ID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["ShopID"].ToString() != "")
                {
                    model.ShopID = int.Parse(ds.Tables[0].Rows[0]["ShopID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["SupplierID"].ToString() != "")
                {
                    model.SupplierID = int.Parse(ds.Tables[0].Rows[0]["SupplierID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["UpUserID"].ToString() != "")
                {
                    model.UpUserID = int.Parse(ds.Tables[0].Rows[0]["UpUserID"].ToString());
                }
                model.UpPOPDate = ds.Tables[0].Rows[0]["UpPOPDate"].ToString();
                model.PhotoPath = ds.Tables[0].Rows[0]["PhotoPath"].ToString();
                model.ShopDesc = ds.Tables[0].Rows[0]["ShopDesc"].ToString();
                if (ds.Tables[0].Rows[0]["DSRState"].ToString() != "")
                {
                    model.DSRState = int.Parse(ds.Tables[0].Rows[0]["DSRState"].ToString());
                }
                model.DSRDesc = ds.Tables[0].Rows[0]["DSRDesc"].ToString();

                model.DSRDate = ds.Tables[0].Rows[0]["DSRDate"].ToString();

                if (ds.Tables[0].Rows[0]["VMState"].ToString() != "")
                {
                    model.VMState = int.Parse(ds.Tables[0].Rows[0]["VMState"].ToString());
                }
                model.VMDate = ds.Tables[0].Rows[0]["VMDate"].ToString();
                model.VMDesc = ds.Tables[0].Rows[0]["VMDesc"].ToString();
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
            strSql.Append("select ID,ShopID,SupplierID,UpUserID,UpPOPDate,PhotoPath,ShopDesc,DSRState,DSRDesc,DSRDate,VMState,VMDate,VMDesc ");
            strSql.Append(" FROM POPReprotDamage ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
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
            parameters[0].Value = "POPReprotDamage";
            parameters[1].Value = "ID";
            parameters[2].Value = PageSize;
            parameters[3].Value = PageIndex;
            parameters[4].Value = 0;
            parameters[5].Value = 0;
            parameters[6].Value = strWhere;	
            return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
        }*/

        /// <summary>
        /// 得到POP报损数据
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataTable GetPopReportDamageData(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("  select supplierid, shopid, upuserid,count(shopid) as num ");
            strSql.Append(" FROM POPReprotDamage ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" group by upuserid,shopid,supplierid ");

            return DbHelperSQL.Query(DbHelperSQL.connectionString(), strSql.ToString()).Tables[0];
        }

        #endregion  成员方法
    }
}

