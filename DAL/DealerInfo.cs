using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using LN.DBUtility;//请先添加引用
namespace LN.DAL
{
    /// <summary>
    /// 数据访问类DealerInfo。
    /// </summary>
    public class DealerInfo
    {
        public DealerInfo()
        { }
        #region  成员方法

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperSQL.GetMaxID(DbHelperSQL.connectionString(), "ID", "DealerInfo");
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from DealerInfo");
            strSql.Append(" where ID=@ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)};
            parameters[0].Value = ID;

            return DbHelperSQL.Exists(DbHelperSQL.connectionString(), strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(LN.Model.DealerInfo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into DealerInfo(");
            strSql.Append("DealerID,DealerName,AreaID,ProvinceID,CityID,Contactor,ContactorPhone,Address,PostAddress,DealerChannel,ExamState)");
            strSql.Append(" values (");
            strSql.Append("@DealerID,@DealerName,@AreaID,@ProvinceID,@CityID,@Contactor,@ContactorPhone,@Address,@PostAddress,@DealerChannel,@ExamState)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@DealerID", SqlDbType.VarChar,50),
					new SqlParameter("@DealerName", SqlDbType.VarChar,100),
					new SqlParameter("@AreaID", SqlDbType.VarChar,30),
					new SqlParameter("@ProvinceID", SqlDbType.Int,4),
					new SqlParameter("@CityID", SqlDbType.Int,4),
					new SqlParameter("@Contactor", SqlDbType.VarChar,20),
					new SqlParameter("@ContactorPhone", SqlDbType.VarChar,20),
					new SqlParameter("@Address", SqlDbType.VarChar,500),
					new SqlParameter("@PostAddress", SqlDbType.VarChar,500),
					new SqlParameter("@DealerChannel", SqlDbType.NChar,10),
                    new SqlParameter("@ExamState", SqlDbType.Int,4)
            };
            parameters[0].Value = model.DealerID;
            parameters[1].Value = model.DealerName;
            parameters[2].Value = model.AreaID;
            parameters[3].Value = model.ProvinceID;
            parameters[4].Value = model.CityID;
            parameters[5].Value = model.Contactor;
            parameters[6].Value = model.ContactorPhone;
            parameters[7].Value = model.Address;
            parameters[8].Value = model.PostAddress;
            parameters[9].Value = model.DealerChannel;
            parameters[10].Value = model.ExamState;
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
        public void Update(LN.Model.DealerInfo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update DealerInfo set ");
            strSql.Append("DealerID=@DealerID,");
            strSql.Append("DealerName=@DealerName,");
            strSql.Append("AreaID=@AreaID,");
            strSql.Append("ProvinceID=@ProvinceID,");
            strSql.Append("CityID=@CityID,");
            strSql.Append("Contactor=@Contactor,");
            strSql.Append("ContactorPhone=@ContactorPhone,");
            strSql.Append("Address=@Address,");
            strSql.Append("PostAddress=@PostAddress,");
            strSql.Append("DealerChannel=@DealerChannel");
            strSql.Append(" where ID=@ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4),
					new SqlParameter("@DealerID", SqlDbType.VarChar,30),
					new SqlParameter("@DealerName", SqlDbType.VarChar,100),
					new SqlParameter("@AreaID", SqlDbType.Int,4),
					new SqlParameter("@ProvinceID", SqlDbType.Int,4),
					new SqlParameter("@CityID", SqlDbType.Int,4),
					new SqlParameter("@Contactor", SqlDbType.VarChar,20),
					new SqlParameter("@ContactorPhone", SqlDbType.VarChar,20),
					new SqlParameter("@Address", SqlDbType.VarChar,500),
					new SqlParameter("@PostAddress", SqlDbType.VarChar,500),
					new SqlParameter("@DealerChannel", SqlDbType.NChar,10)};
            parameters[0].Value = model.ID;
            parameters[1].Value = model.DealerID;
            parameters[2].Value = model.DealerName;
            parameters[3].Value = model.AreaID;
            parameters[4].Value = model.ProvinceID;
            parameters[5].Value = model.CityID;
            parameters[6].Value = model.Contactor;
            parameters[7].Value = model.ContactorPhone;
            parameters[8].Value = model.Address;
            parameters[9].Value = model.PostAddress;
            parameters[10].Value = model.DealerChannel;

            DbHelperSQL.ExecuteSql(DbHelperSQL.connectionString(), strSql.ToString(), parameters);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void Delete(int ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete DealerInfo ");
            strSql.Append(" where ID=@ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)};
            parameters[0].Value = ID;

            DbHelperSQL.ExecuteSql(DbHelperSQL.connectionString(), strSql.ToString(), parameters);
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public LN.Model.DealerInfo GetModel(int ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 ID,DealerID,DealerName,AreaID,ProvinceID,CityID,Contactor,ContactorPhone,Address,PostAddress,DealerChannel from DealerInfo ");
            strSql.Append(" where ID=@ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)};
            parameters[0].Value = ID;

            LN.Model.DealerInfo model = new LN.Model.DealerInfo();
            DataSet ds = DbHelperSQL.Query(DbHelperSQL.connectionString(), strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["ID"].ToString() != "")
                {
                    model.ID = int.Parse(ds.Tables[0].Rows[0]["ID"].ToString());
                }
                model.DealerID = ds.Tables[0].Rows[0]["DealerID"].ToString();
                model.DealerName = ds.Tables[0].Rows[0]["DealerName"].ToString();
                if (ds.Tables[0].Rows[0]["AreaID"].ToString() != "")
                {
                    model.AreaID = int.Parse(ds.Tables[0].Rows[0]["AreaID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["ProvinceID"].ToString() != "")
                {
                    model.ProvinceID = int.Parse(ds.Tables[0].Rows[0]["ProvinceID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["CityID"].ToString() != "")
                {
                    model.CityID = int.Parse(ds.Tables[0].Rows[0]["CityID"].ToString());
                }
                model.Contactor = ds.Tables[0].Rows[0]["Contactor"].ToString();
                model.ContactorPhone = ds.Tables[0].Rows[0]["ContactorPhone"].ToString();
                model.Address = ds.Tables[0].Rows[0]["Address"].ToString();
                model.PostAddress = ds.Tables[0].Rows[0]["PostAddress"].ToString();
                model.DealerChannel = ds.Tables[0].Rows[0]["DealerChannel"].ToString();
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
            strSql.Append("select ID,DealerID,DealerName,DealerInfo.AreaID, areaname,department, ProvinceID,isnull((select top 1 ProvinceName from ProvinceData where ProvinceID=DealerInfo.ProvinceID),'') ProvinceName, CityID,isnull((select top 1 cityname from CityData where CItyID=DealerInfo.cityid ),'') cityname,Contactor,ContactorPhone,Address,PostAddress,DealerChannel ,[Time] ");
            strSql.Append(" FROM DealerInfo ,areadata where dealerinfo.areaID=areadata.AreaID ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(strWhere);
            }
            strSql.Append(" order by DealerName asc");
            return DbHelperSQL.Query(DbHelperSQL.connectionString(), strSql.ToString());
        }

        /// <summary>
        /// 得到一级客户的列表
        /// </summary>
        /// <param name="StrWhere"></param>
        /// <returns></returns>
        public DataTable GetDealerInfoList(string StrWhere)
        {
            StringBuilder Strsql = new StringBuilder();
            Strsql.Append("select ROW_NUMBER() OVER (ORDER BY DealerName ASC) AS SNumberID,* ");
            Strsql.Append(" From DealerInfo ");
            if (StrWhere.Trim() != "")
            {
                Strsql.Append(" where " + StrWhere);
            }
            Strsql.Append(" order by DealerName asc");
            return DbHelperSQL.Query(DbHelperSQL.connectionString(), Strsql.ToString()).Tables[0];
        }




        /// <summary>
        /// 从店铺表中城市的ID筛选得到一级客户的列表
        /// </summary>
        /// <param name="StrWhere"></param>
        /// <returns></returns>
        public DataTable GetDealerInfoListBy(string CityID)
        {
            StringBuilder Strsql = new StringBuilder();
            Strsql.AppendFormat("select [DealerID],[DealerName] from DealerInfo where DealerID in(select distinct DealerId from ShopInfo where CityID='{0}' ) ", CityID);
            Strsql.Append(" order by DealerName asc");
            return DbHelperSQL.Query(DbHelperSQL.connectionString(), Strsql.ToString()).Tables[0];
        }



        /// <summary>
        /// 得到一级客户ID和一级客户名称
        /// </summary>
        /// <param name="StrWhere"></param>
        /// <returns></returns>
        public DataTable GetDealerName(string StrWhere)
        {
            StringBuilder Strsql = new StringBuilder();
            Strsql.Append("select DealerID,DealerName ");
            Strsql.Append(" From DealerInfo ");
            if (StrWhere.Trim() != "")
            {
                Strsql.Append(" where " + StrWhere);
            }
            Strsql.Append(" order by DealerName asc");
            return DbHelperSQL.Query(DbHelperSQL.connectionString(), Strsql.ToString()).Tables[0];
        }
        /// <summary>
        /// 得到一级客户ID和一级客户名称通过登录人名称
        /// </summary>
        /// <param name="StrWhere"></param>
        /// <returns></returns>
        public DataTable GetDealerByUserName(string StrWhere)
        {
            StringBuilder Strsql = new StringBuilder();
            Strsql.Append("select top 1 DealerID,DealerName ");
            Strsql.Append(" From DealerInfo ");
            if (StrWhere.Trim() != "")
            {
                Strsql.Append(" where " + StrWhere);
            }
            return DbHelperSQL.Query(DbHelperSQL.connectionString(), Strsql.ToString()).Tables[0];
        }
        /// <summary>
        /// 获取指定供应商所供应的一级客户集合
        /// </summary>
        /// <param name="SupplierID">供应商编号</param>
        /// <returns></returns>
        public DataTable GetDealerNameBySupplierID(string SupplierID)
        {
            DataTable dt = null;
            StringBuilder Strsql = new StringBuilder();
            Strsql.Append("SELECT [DealerID],[DealerName] FROM [DealerInfo] WHERE [DealerID] IN ");
            Strsql.Append(" (SELECT [DealerID] FROM [ShopInfo] WHERE ShopID IN ");
            Strsql.AppendFormat(" (SELECT DISTINCT [AssignShopID] FROM [SupplierAssignRecord] WHERE SupplierID = {0}) ", SupplierID);
            Strsql.Append(" GROUP BY [DealerID]) ");

            DataSet ds = DbHelperSQL.Query(DbHelperSQL.connectionString(), Strsql.ToString());
            if (ds != null)
                dt = ds.Tables[0];

            return dt;
        }
        /// <summary>
        /// 省区VM审核新增一级客户
        /// </summary>
        /// <param name="examState"></param>
        /// <param name="UserID"></param>
        /// <param name="StrWhere"></param>
        public void ExamNewdealer(int examState, int UserID, string StrWhere)
        {
            StringBuilder sb = new StringBuilder();
            if (examState == 1)
            {
                sb.Append("INSERT INTO [UserInfo] ([Username],[Sex],[Usertype],[UserPassword],[UserEmail],[UserAddress],[UserPhone],[UserMobel],[UserState],[UserDesc],[userofarea]) ");
                sb.Append("SELECT DealerID,'',5,'000000','',DealerName,ContactorPhone,ContactorPhone,1,'',AreaID FROM DealerInfo WHERE " + StrWhere + " ;");
            }
            sb.Append("update DealerInfo set ExamState=" + examState + ",examUserID=" + UserID + ",ExamTime=CONVERT(varchar(30), GETDATE(), 20)  where ");
            sb.Append(StrWhere);

            DbHelperSQL.ExecuteSql(DbHelperSQL.connectionString(), sb.ToString());
        }
        /// <summary>
        /// 大区VM经理审核新增一级客户
        /// </summary>
        /// <param name="examstate"></param>
        /// <param name="UserID"></param>
        /// <param name="StrWhere"></param>
        public void VMExamNewDealer(int examState, int UserID, string StrWhere)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("update DealerInfo set VMExamState=" + examState + ",VMexamUserID=" + UserID + ",VMExamTime=CONVERT(varchar(30), GETDATE(), 20)  where ");
            sb.Append(StrWhere);

            DbHelperSQL.ExecuteSql(DbHelperSQL.connectionString(), sb.ToString());
        }

        #endregion  成员方法
    }
}

