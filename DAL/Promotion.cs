using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using LN.DBUtility;


namespace LN.DAL
{
    public class Promotion
    {
        public int Add(LN.Model.Promotion model)
        {
            string sql = "insert into Promotion(PromotionId,PromotionName,BeginDate,EndDate,PromotionDesc,AddDate,AddUserId,IsDelete,UploadFileUrl,BoolPrice,ProductLineDatas,State,IsConfirmOrder) values(@PromotionId,@PromotionName,@BeginDate,@EndDate,@PromotionDesc,@AddDate,@AddUserId,@IsDelete,@UploadFileUrl,@BoolPrice,@ProductLineDatas,@State,@IsConfirmOrder);select @@identity";
            SqlParameter[] parameters = new SqlParameter[] { 
               new SqlParameter("@PromotionId",model.PromotionId),
               new SqlParameter("@PromotionName",model.PromotionName),
               new SqlParameter("@BeginDate",model.BeginDate),
               new SqlParameter("@EndDate",model.EndDate),
               new SqlParameter("@PromotionDesc",model.PromotionDesc),
               new SqlParameter("@AddDate",model.AddDate),
               new SqlParameter("@AddUserId",model.AddUserId),
               new SqlParameter("@IsDelete",model.IsDelete),
               new SqlParameter("@UploadFileUrl",model.UploadFileUrl),
               new SqlParameter("@BoolPrice",model.BoolPrice),
               new SqlParameter("@ProductLineDatas",model.ProductLineDatas),
               new SqlParameter("@State",model.State),
               new SqlParameter("@IsConfirmOrder",model.IsConfirmOrder)
            };
            object obj = DbHelperSQL.GetSingle(DbHelperSQL.connectionString(), sql, parameters);
            return obj != null ? int.Parse(obj.ToString()) : 0;
            
        }

        public bool Update(LN.Model.Promotion model)
        {
            StringBuilder sql = new System.Text.StringBuilder();
            sql.Append("update Promotion set ");
            List<SqlParameter> paraList = new List<SqlParameter>();
            if (model != null)
            {
                if (model.PromotionId != null)
                {
                    sql.Append(" PromotionId=@PromotionId,");
                    paraList.Add(new SqlParameter("@PromotionId", model.PromotionId));
                }
                if (model.PromotionName != null)
                {
                    sql.Append(" PromotionName=@PromotionName,");
                    paraList.Add(new SqlParameter("@PromotionName", model.PromotionName));
                }
                //if (model.PromotionName != null)
                //{
                //    sql.Append(" PromotionName=@PromotionName,");
                //    paraList.Add(new SqlParameter("@PromotionName", model.PromotionName));
                //}
                if (model.BeginDate != null)
                {
                    sql.Append(" BeginDate=@BeginDate,");
                    paraList.Add(new SqlParameter("@BeginDate", model.BeginDate));
                }
                if (model.EndDate != null)
                {
                    sql.Append(" EndDate=@EndDate,");
                    paraList.Add(new SqlParameter("@EndDate", model.EndDate));
                }
                if (model.PromotionDesc != null)
                {
                    sql.Append(" PromotionDesc=@PromotionDesc,");
                    paraList.Add(new SqlParameter("@PromotionDesc", model.PromotionDesc));
                }
                if (model.AddDate != null)
                {
                    sql.Append(" AddDate=@AddDate,");
                    paraList.Add(new SqlParameter("@AddDate", model.AddDate));
                }
                if (model.AddUserId != null)
                {
                    sql.Append(" AddUserId=@AddUserId,");
                    paraList.Add(new SqlParameter("@AddUserId", model.AddUserId));
                }
                if (model.IsDelete != null)
                {
                    sql.Append(" IsDelete=@IsDelete,");
                    paraList.Add(new SqlParameter("@IsDelete", model.IsDelete));
                }
                if (model.State != null)
                {
                    sql.Append(" State=@State,");
                    paraList.Add(new SqlParameter("@State", model.State));
                }
                if (model.IsConfirmOrder != null)
                {
                    sql.Append(" IsConfirmOrder=@IsConfirmOrder,");
                    paraList.Add(new SqlParameter("@IsConfirmOrder", model.IsConfirmOrder));
                }
                if (model.UpdateFileNames != null)
                {
                    sql.Append(" UpdateFileNames=@UpdateFileNames,");
                    paraList.Add(new SqlParameter("@UpdateFileNames", model.UpdateFileNames));
                }
                string sql1 = sql.ToString().Substring(0, sql.Length - 1);
                if (model.Id != null)
                {
                    sql1 += " where Id=@Id ";
                    paraList.Add(new SqlParameter("@Id", model.Id));
                    return DbHelperSQL.ExecuteSql(DbHelperSQL.connectionString(), sql1, paraList.ToArray()) > 0;
                }
                else
                    return false;
            }
            else
                return false;
        }

        public void Delete(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete Promotion ");
            strSql.Append(" where Id=@Id ");
            SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4)};
            parameters[0].Value = id;
            DbHelperSQL.ExecuteSql(DbHelperSQL.connectionString(), strSql.ToString(), parameters);
        }

        public DataSet GetList(string whereStr)
        {
            string sql = "select * from Promotion ";
            if (!string.IsNullOrEmpty(whereStr))
            {
                sql += " where " + whereStr;
            }
            return DbHelperSQL.Query(DbHelperSQL.connectionString(), sql);
        }

        public DataSet GetList(string whereStr, int currPage, int pageSize)
        {
            string sql = "select * from (select row_number() over(order by PromotionId desc) row,* from Promotion where 1=1 " + whereStr + ") temp where row between ((@currPage-1)*@pageSize+1) and (@currPage*@pageSize)";
            SqlParameter[] paras = new SqlParameter[] { 
                new SqlParameter("@currPage",currPage),
                new SqlParameter("@pageSize",pageSize)
            };
            return DbHelperSQL.Query(DbHelperSQL.connectionString(), sql, paras); 
        }

        public int GetPageCount(string whereStr)
        {
            string sql = "select count(*) from Promotion where 1=1 " + whereStr;
            object obj = DbHelperSQL.GetSingle(DbHelperSQL.connectionString(),sql);
            return obj != null ? int.Parse(obj.ToString()) : 0;
        }

        public LN.Model.Promotion GetModel(int id)
        {
            DataSet ds = GetList(string.Format(" Id={0}",id));
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                LN.Model.Promotion model = new Model.Promotion();
                DataRow dr = ds.Tables[0].Rows[0];
                model.Id = id;
                if (!string.IsNullOrEmpty(dr["PromotionId"].ToString()))
                {
                    model.PromotionId = dr["PromotionId"].ToString();
                }
                if (!string.IsNullOrEmpty(dr["PromotionName"].ToString()))
                {
                    model.PromotionName = dr["PromotionName"].ToString();
                }
                if (!string.IsNullOrEmpty(dr["BeginDate"].ToString()))
                {
                    model.BeginDate = DateTime.Parse(dr["BeginDate"].ToString());
                }
                if (!string.IsNullOrEmpty(dr["EndDate"].ToString()))
                {
                    model.EndDate = DateTime.Parse(dr["EndDate"].ToString());
                }
                if (!string.IsNullOrEmpty(dr["PromotionDesc"].ToString()))
                {
                    model.PromotionDesc = dr["PromotionDesc"].ToString();
                }
                if (!string.IsNullOrEmpty(dr["AddDate"].ToString()))
                {
                    model.AddDate = DateTime.Parse(dr["AddDate"].ToString());
                }
                if (!string.IsNullOrEmpty(dr["AddUserId"].ToString()))
                {
                    model.AddUserId = int.Parse(dr["AddUserId"].ToString());
                }
                if (!string.IsNullOrEmpty(dr["IsDelete"].ToString()))
                {
                    model.IsDelete = int.Parse(dr["IsDelete"].ToString());
                }
                if (!string.IsNullOrEmpty(dr["BoolPrice"].ToString()))
                {
                    model.BoolPrice = int.Parse(dr["BoolPrice"].ToString());
                }
                if (!string.IsNullOrEmpty(dr["ProductLineDatas"].ToString()))
                {
                    model.ProductLineDatas = dr["ProductLineDatas"].ToString();
                }
                if (!string.IsNullOrEmpty(dr["State"].ToString()))
                {
                    model.State =int.Parse(dr["State"].ToString());
                }
                return model;
            }
            else
                return null;
        }

        public DataSet GetRackInfo(int promotionId,int? storyBagId=null)
        {
            //string sql1 = "select rack.Id rackId, story.StoryBagName,POPSeat.seat,rack.rackType,rack.RackName,rack.Size,rack.Category from PromotionStorySeat seat join RackInfo rack on rack.PositionId = seat.SeatId join dbo.PromotionStoryBag story on story.Id=seat.StoryBagId join POPSeat on POPSeat.SeatID=seat.SeatId  where  seat.PromotionId=" + promotionId + " and rack.StoryBagId=seat.StoryBagId order by seat.StoryBagId";
            StringBuilder sql = new StringBuilder();
            sql.Append("select rack.Id rackId,rack.RackCode, story.StoryBagName,POPSeat.seat,rack.rackType,rack.RackName,rack.Size,rack.Category,rack.Texture,rack.Specification,rack.Units from PromotionStorySeat seat join RackInfo rack on rack.PositionId = seat.SeatId join dbo.PromotionStoryBag story on story.Id=seat.StoryBagId join POPSeat on POPSeat.SeatID=seat.SeatId  where  seat.PromotionId=" + promotionId);
            if (storyBagId != null && storyBagId > 0)
            {
                sql.Append(" and seat.StoryBagId=" + storyBagId);
            }
            sql.Append(" and rack.StoryBagId=seat.StoryBagId and (rack.IsDelete=0 or rack.IsDelete is null) order by seat.StoryBagId,rack.RackType");
            return DbHelperSQL.Query(DbHelperSQL.connectionString(), sql.ToString()); 
        }

        public DataSet GetRackInfo(string where)
        {
            //string sql1 = "select rack.Id rackId, story.StoryBagName,POPSeat.seat,rack.rackType,rack.RackName,rack.Size,rack.Category from PromotionStorySeat seat join RackInfo rack on rack.PositionId = seat.SeatId join dbo.PromotionStoryBag story on story.Id=seat.StoryBagId join POPSeat on POPSeat.SeatID=seat.SeatId  where  seat.PromotionId=" + promotionId + " and rack.StoryBagId=seat.StoryBagId order by seat.StoryBagId";
            StringBuilder sql = new StringBuilder();
            sql.Append("select rack.Id rackId,story.Id StoryBagId,story.StoryBagName,POPSeat.seat,rack.rackType,rack.RackName,rack.Size,rack.Category,rack.Texture,rack.Specification,rack.Units from PromotionStorySeat seat join RackInfo rack on rack.PositionId = seat.SeatId join dbo.PromotionStoryBag story on story.Id=seat.StoryBagId join POPSeat on POPSeat.SeatID=seat.SeatId  ");
            if (!string.IsNullOrWhiteSpace(where))
            {
                sql.Append(" where "+where);
            }
            sql.Append(" and rack.StoryBagId=seat.StoryBagId order by seat.StoryBagId");
            return DbHelperSQL.Query(DbHelperSQL.connectionString(), sql.ToString());
        }

        /// <summary>
        /// 只获取上传了效果图的道具
        /// </summary>
        /// <param name="promotionId"></param>
        /// <param name="storyBagId"></param>
        /// <returns></returns>
        public DataSet GetExportRackInfo(int promotionId, int storyBagId)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append("select rack.Id rackId, story.StoryBagName,POPSeat.seat,rack.rackType,rack.RackName,rack.Size,rack.Category,rack.Texture,rack.Specification,rack.Units from PromotionStorySeat seat join RackInfo rack on rack.PositionId = seat.SeatId join dbo.PromotionStoryBag story on story.Id=seat.StoryBagId join POPSeat on POPSeat.SeatID=seat.SeatId   where  seat.PromotionId=" + promotionId);
            sql.Append("and seat.StoryBagId=" + storyBagId+" and rack.StoryBagId=seat.StoryBagId ");
            sql.Append(" and ((POPSeat.seat='陈列桌') or (POPSeat.seat!='陈列桌' and rack.Id in (select ItemId from Attachment where ItemTypeId=" + promotionId + " and FileCode=5 and IsDelete=0)))");
            
            sql.Append(" order by seat.StoryBagId");
            return DbHelperSQL.Query(DbHelperSQL.connectionString(), sql.ToString()); 
        }

        public DataSet GetExportRackInfo(int promotionId, string storyBagIds)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append("select rack.Id rackId,seat.StoryBagId,story.StoryBagName,POPSeat.seat,rack.rackType,rack.RackName,rack.StoryBagName,rack.Size,rack.Category,rack.Texture,rack.Specification,rack.Units from PromotionStorySeat seat join RackInfo rack on rack.PositionId = seat.SeatId join dbo.PromotionStoryBag story on story.Id=seat.StoryBagId join POPSeat on POPSeat.SeatID=seat.SeatId  where  seat.PromotionId=" + promotionId);
            sql.Append("and seat.StoryBagId in(" + storyBagIds + ") and rack.StoryBagId=seat.StoryBagId ");
            //sql.Append(" and rack.Id in (select ItemId from Attachment where ItemTypeId=" + promotionId + " and FileCode=5 and IsDelete=0)");
            sql.Append(" and ((POPSeat.seat='陈列桌') or (POPSeat.seat!='陈列桌' and rack.Id in (select ItemId from Attachment where ItemTypeId=" + promotionId + " and FileCode=5 and IsDelete=0)))");

            sql.Append(" order by seat.StoryBagId,POPSeat.seat desc");
            return DbHelperSQL.Query(DbHelperSQL.connectionString(), sql.ToString());
        }
    }
}
