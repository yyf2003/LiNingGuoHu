using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using LN.DBUtility;//请先添加引用
namespace LN.DAL
{
    /// <summary>
    /// 数据访问类UserAreaMange。
    /// </summary>
    public class UserAreaMange
    {
        public UserAreaMange()
        { }
        #region  成员方法

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperSQL.GetMaxID(DbHelperSQL.connectionString(), "ID", "UserAreaMange");
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from UserAreaMange");
            strSql.Append(" where ID=@ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)};
            parameters[0].Value = ID;

            return DbHelperSQL.Exists(DbHelperSQL.connectionString(), strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(LN.Model.UserAreaMange model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into UserAreaMange(");
            strSql.Append("UserID,AreaID,ProvinceID,CityID,TownID)");
            strSql.Append(" values (");
            strSql.Append("@UserID,@AreaID,@ProvinceID,@CityID,@TownID)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@UserID", SqlDbType.Int,4),
					new SqlParameter("@AreaID", SqlDbType.Int,4),
					new SqlParameter("@ProvinceID", SqlDbType.Int,4),
					new SqlParameter("@CityID", SqlDbType.Int,4),
					new SqlParameter("@TownID", SqlDbType.Int,4) 
            };
            parameters[0].Value = model.UserID;
            parameters[1].Value = model.AreaID;
            parameters[2].Value = model.ProvinceID;
            parameters[3].Value = model.CityID;
            parameters[4].Value = model.TownID;
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
        public void Update(LN.Model.UserAreaMange model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update UserAreaMange set ");
            strSql.Append("UserID=@UserID,");
            strSql.Append("AreaID=@AreaID,");
            strSql.Append("ProvinceID=@ProvinceID,");
            strSql.Append("CityID=@CityID, ");
            strSql.Append("TownID=@TownID, "); 
            strSql.Append(" where ID=@ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4),
					new SqlParameter("@UserID", SqlDbType.Int,4),
					new SqlParameter("@AreaID", SqlDbType.Int,4),
					new SqlParameter("@ProvinceID", SqlDbType.Int,4),
					new SqlParameter("@CityID", SqlDbType.Int,4),
					new SqlParameter("@TownID", SqlDbType.Int,4)
            
            };
            parameters[0].Value = model.ID;
            parameters[1].Value = model.UserID;
            parameters[2].Value = model.AreaID;
            parameters[3].Value = model.ProvinceID;
            parameters[4].Value = model.CityID;
            parameters[5].Value = model.TownID;
            DbHelperSQL.ExecuteSql(DbHelperSQL.connectionString(), strSql.ToString(), parameters);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void Delete(int ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete UserAreaMange ");
            strSql.Append(" where ID=@ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)};
            parameters[0].Value = ID;

            DbHelperSQL.ExecuteSql(DbHelperSQL.connectionString(), strSql.ToString(), parameters);
        }

        /// <summary>
        /// 删除用户的数据
        /// </summary>
        /// <param name="UserID"></param>
        public void DeleteUserData(int UserID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete UserAreaMange ");
            strSql.Append(" where UserID=@ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)};
            parameters[0].Value = UserID;
            DbHelperSQL.ExecuteSql(DbHelperSQL.connectionString(), strSql.ToString(), parameters);
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public LN.Model.UserAreaMange GetModel(int ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 ID,UserID,AreaID,ProvinceID,CityID,TownID from UserAreaMange ");
            strSql.Append(" where ID=@ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)};
            parameters[0].Value = ID;

            LN.Model.UserAreaMange model = new LN.Model.UserAreaMange();
            DataSet ds = DbHelperSQL.Query(DbHelperSQL.connectionString(), strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["ID"].ToString() != "")
                {
                    model.ID = int.Parse(ds.Tables[0].Rows[0]["ID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["UserID"].ToString() != "")
                {
                    model.UserID = int.Parse(ds.Tables[0].Rows[0]["UserID"].ToString());
                }
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
                if (ds.Tables[0].Rows[0]["TownID"].ToString() != "")
                {
                    model.TownID = int.Parse(ds.Tables[0].Rows[0]["TownID"].ToString());
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
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ID,UserID,AreaID,ProvinceID,CityID,TownID ");
            strSql.Append(" FROM UserAreaMange ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(DbHelperSQL.connectionString(), strSql.ToString());
        }


        /// <summary>
        /// 得到分配的区域信息
        /// </summary>
        /// <param name="UID"></param>
        /// <returns></returns>
        public DataSet GetUserAssginArea(int UID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select distinct AreaID  ");
            strSql.Append(" FROM UserAreaMange   where UserID =" + UID + " ");
            return DbHelperSQL.Query(DbHelperSQL.connectionString(), strSql.ToString());
        }

        /// <summary>
        /// 得到分配的城市信息
        /// </summary>
        /// <param name="UID"></param>
        /// <returns></returns>
        public DataSet GetUserAssginCity(int UID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select distinct CityID  ");
            strSql.Append(" FROM UserAreaMange   where UserID =" + UID + " ");
            return DbHelperSQL.Query(DbHelperSQL.connectionString(), strSql.ToString());
        }


        /// <summary>
        /// 得到分配的省份信息
        /// </summary>
        /// <param name="UID"></param>
        /// <returns></returns>
        public DataSet GetUserAssginProvice(int UID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select distinct ProvinceID  ");
            strSql.Append(" FROM UserAreaMange   where UserID =" + UID + " ");
            return DbHelperSQL.Query(DbHelperSQL.connectionString(), strSql.ToString());
        }

        /// <summary>
        /// 得到分配的城镇信息
        /// </summary>
        /// <param name="UID"></param>
        /// <returns></returns>
        public DataSet GetUserAssginTown(int UID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select distinct TownID  ");
            strSql.Append(" FROM UserAreaMange   where UserID =" + UID + " ");
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
            parameters[0].Value = "UserAreaMange";
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

