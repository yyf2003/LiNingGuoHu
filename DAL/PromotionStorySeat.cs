using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using LN.DBUtility;//请先添加引用

namespace LN.DAL
{
    public class PromotionStorySeat
    {
        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperSQL.GetMaxID(DbHelperSQL.connectionString(), "Id", "PromotionStorySeat");
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from PromotionStorySeat");
            strSql.Append(" where Id=@id ");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
            parameters[0].Value = id;

            return DbHelperSQL.Exists(DbHelperSQL.connectionString(), strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(LN.Model.PromotionStorySeat model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into PromotionStorySeat(");
            strSql.Append("PromotionId,StoryBagId,SeatId,AddDate,AddUserId)");
            strSql.Append(" values (");
            strSql.Append("@PromotionId,@StoryBagId,@SeatId,@AddDate,@AddUserId)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@PromotionId",model.PromotionId),
                    new SqlParameter("@StoryBagId",model.StoryBagId),
                    new SqlParameter("@SeatId",model.SeatId),
                    new SqlParameter("@AddDate",model.AddDate),
                    new SqlParameter("@AddUserId",model.AddUserId)
                    
            };

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
        /// 删除一条数据
        /// </summary>
        public void Delete(int id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete PromotionStorySeat ");
            strSql.Append(" where Id=@Id ");
            SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4)};
            parameters[0].Value = id;

            DbHelperSQL.ExecuteSql(DbHelperSQL.connectionString(), strSql.ToString(), parameters);
        }

        public void DeleteByPromotionId(int pid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete PromotionStorySeat ");
            strSql.Append(" where PromotionId=@PromotionId ");
            SqlParameter[] parameters = {
					new SqlParameter("@PromotionId", SqlDbType.Int,4)};
            parameters[0].Value = pid;
            DbHelperSQL.ExecuteSql(DbHelperSQL.connectionString(), strSql.ToString(), parameters);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public LN.Model.PromotionStorySeat GetModel(int id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 Id,PromotionId,StoryBagId,SeatId,AddDate,AddUserId from PromotionStorySeat ");
            strSql.Append(" where Id=@Id ");
            SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4)};
            parameters[0].Value = id;

            LN.Model.PromotionStorySeat model = new LN.Model.PromotionStorySeat();
            DataSet ds = DbHelperSQL.Query(DbHelperSQL.connectionString(), strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["Id"].ToString() != "")
                {
                    model.Id = int.Parse(ds.Tables[0].Rows[0]["Id"].ToString());
                }
                model.PromotionId = int.Parse(ds.Tables[0].Rows[0]["PromotionId"].ToString());
                model.StoryBagId = int.Parse(ds.Tables[0].Rows[0]["StoryBagId"].ToString());
                model.SeatId = int.Parse(ds.Tables[0].Rows[0]["SeatId"].ToString());
                model.AddDate = DateTime.Parse(ds.Tables[0].Rows[0]["AddDate"].ToString());
                model.AddUserId = int.Parse(ds.Tables[0].Rows[0]["AddUserId"].ToString());
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
            strSql.Append("select PromotionStorySeat.Id,PromotionStorySeat.PromotionId,PromotionStorySeat.StoryBagId,PromotionStorySeat.SeatId,PromotionStorySeat.AddDate,PromotionStorySeat.AddUserId,PromotionStoryBag.StoryBagName,POPSeat.seat ");
            strSql.Append(" FROM PromotionStorySeat join PromotionStoryBag on PromotionStoryBag.Id=PromotionStorySeat.StoryBagId join POPSeat on POPSeat.SeatID=PromotionStorySeat.SeatId ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by PromotionStorySeat.StoryBagId");
            return DbHelperSQL.Query(DbHelperSQL.connectionString(), strSql.ToString());
        }

        public DataSet GetStoryBags(int promotionId)
        {
            string sql = "select distinct storybag.Id,storybag.StoryBagName from PromotionStorySeat storySeat join PromotionStoryBag storybag on storybag.Id = storySeat.StoryBagId where storySeat.PromotionId=" + promotionId;
            return DbHelperSQL.Query(DbHelperSQL.connectionString(), sql);
        }
    }
}
