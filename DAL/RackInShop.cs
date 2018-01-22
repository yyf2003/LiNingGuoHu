using System;
using System.Data;
using System.Text;
using System.Collections.Generic;
using System.Data.SqlClient;
using LN.DBUtility;//请先添加引用

namespace LN.DAL
{
    public class RackInShop
    {
        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperSQL.GetMaxID(DbHelperSQL.connectionString(), "Id", "RackInShop");
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from RackInShop");
            strSql.Append(" where Id=@id ");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
            parameters[0].Value = id;

            return DbHelperSQL.Exists(DbHelperSQL.connectionString(), strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(LN.Model.RackInShop model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into RackInShop(");
            strSql.Append("ShopId,PosId,RackId,Size,RackCount,StoryBagId)");
            strSql.Append(" values (");
            strSql.Append("@ShopId,@PosId,@RackId,@Size,@RackCount,@StoryBagId)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@ShopId",model.ShopId),
                    new SqlParameter("@PosId",model.PosId),
                    new SqlParameter("@RackId",model.RackId),
                    new SqlParameter("@Size",model.Size),
                    new SqlParameter("@RackCount",model.RackCount),
                    new SqlParameter("@StoryBagId",model.StoryBagId)
                   
                   
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
            strSql.Append("delete RackInShop ");
            strSql.Append(" where Id=@Id ");
            SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4)};
            parameters[0].Value = id;

            DbHelperSQL.ExecuteSql(DbHelperSQL.connectionString(), strSql.ToString(), parameters);
        }

        public void Delete(string whereStr)
        {
            if (!string.IsNullOrWhiteSpace(whereStr))
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("delete RackInShop ");
                strSql.Append(" where ");
                strSql.Append(whereStr);
                DbHelperSQL.ExecuteSql(DbHelperSQL.connectionString(), strSql.ToString());
            }
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public LN.Model.RackInShop GetModel(int id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 Id,ShopId,PosId,RackId,Size,RackCount from RackInShop ");
            strSql.Append(" where Id=@Id ");
            SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4)};
            parameters[0].Value = id;

            LN.Model.RackInShop model = new LN.Model.RackInShop();
            DataSet ds = DbHelperSQL.Query(DbHelperSQL.connectionString(), strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["Id"].ToString() != "")
                {
                    model.Id = int.Parse(ds.Tables[0].Rows[0]["Id"].ToString());
                }
                model.ShopId = int.Parse(ds.Tables[0].Rows[0]["ShopId"].ToString());
                model.PosId = ds.Tables[0].Rows[0]["PosId"].ToString();
                model.RackId = int.Parse(ds.Tables[0].Rows[0]["RackId"].ToString());
                model.Size = ds.Tables[0].Rows[0]["Size"].ToString();
                model.RackCount = int.Parse(ds.Tables[0].Rows[0]["RackCount"].ToString());
               
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
            strSql.Append("select Id,ShopId,PosId,RackId,Size,RackCount ");
            strSql.Append(" FROM RackInShop ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(DbHelperSQL.connectionString(), strSql.ToString());
        }

        public DataSet GetJoinList(int PromotionId,int StoryBagId,string where)
        {
            StringBuilder strSql = new StringBuilder();

            strSql.Append(@"select RackInShop.Id,RackInShop.ShopId,RackInShop.PosId,RackInShop.RackId,RackInShop.Size,RackInShop.RackCount from RackInShop
                            join RackInfo on RackInfo.Id=RackId 
                              where  ShopId in 
                              (
                                select PromotionShops.ShopId from PromotionShops 
                                join PromotionShopInfo on PromotionShopInfo.ID =PromotionShops.ShopId 
                                where PromotionShops.PromotionId=" + PromotionId + "" + where + " ) and RackInfo.StoryBagId=" + StoryBagId
                               
                            );
           
            return DbHelperSQL.Query(DbHelperSQL.connectionString(), strSql.ToString());
        }

//        public DataSet GetJoinList1(int PromotionId, string StoryBagIds, string where)
//        {
//            StringBuilder strSql = new StringBuilder();

//            strSql.Append(@"select RackInShop.Id,RackInShop.ShopId,RackInShop.PosId,RackInShop.RackId,RackInShop.Size,RackInShop.RackCount from RackInShop
//                            join RackInfo on RackInfo.Id=RackId 
//                              where  ShopId in 
//                              (
//                                select PromotionShops.ShopId from PromotionShops 
//                                join PromotionShopInfo on PromotionShopInfo.ID =PromotionShops.ShopId 
//                                where PromotionShops.PromotionId=" + PromotionId + "" + where + " ) and RackInfo.StoryBagId in(" + StoryBagIds+")"

//                            );

//            return DbHelperSQL.Query(DbHelperSQL.connectionString(), strSql.ToString());
//        }


        public DataSet GetJoinList1(int PromotionId, string StoryBagIds, int shopLevelId)
        {
            StringBuilder strSql = new StringBuilder();

            strSql.Append(@"select RackInShop.Id,RackInShop.ShopId,RackInShop.PosId,RackInShop.RackId,RackInShop.Size,RackInShop.RackCount,RackInfo.RackType,POPSeat.seat PositionName from RackInShop
                            join RackInfo on RackInfo.Id=RackId 
                             join POPSeat on POPSeat.SeatID=RackInfo.PositionId
                              where  ShopId in 
                              (
                                select PromotionShops.ShopId from PromotionShops 
                                where PromotionShops.PromotionId=" + PromotionId + " and PromotionShops.ShopLevelId=" + shopLevelId + ") and RackInfo.StoryBagId in(" + StoryBagIds + ")"

                            );

            return DbHelperSQL.Query(DbHelperSQL.connectionString(), strSql.ToString());
        }


        public DataSet GetJoinList2(int PromotionId, string StoryBagIds)
        {
            StringBuilder strSql = new StringBuilder();

            strSql.Append(@"select RackInShop.Id,RackInShop.ShopId,RackInShop.PosId,RackInShop.RackId,RackInShop.Size,RackInShop.RackCount,RackInfo.RackType,POPSeat.seat PositionName from RackInShop
                            join RackInfo on RackInfo.Id=RackId 
                             join POPSeat on POPSeat.SeatID=RackInfo.PositionId
                              where  ShopId in 
                              (
                                select PromotionShops.ShopId from PromotionShops 
                                where PromotionShops.PromotionId=" + PromotionId + ") and RackInShop.ShopId>0  and RackInShop.RackId>0 and RackInShop.RackCount>0  and RackInfo.StoryBagId in(" + StoryBagIds + ")"

                            );

            return DbHelperSQL.Query(DbHelperSQL.connectionString(), strSql.ToString());
        }

        public DataSet GetFinalRackList(int PromotionId, int StoryBagId, string where)
        {
            StringBuilder strSql = new StringBuilder();

            strSql.Append(@"select RackInShop.Id,RackInShop.ShopId,RackInShop.PosId,RackInShop.RackId,RackInShop.Size,RackInShop.RackCount from RackInShop
                            join RackInfo on RackInfo.Id=RackId 
                              where  ShopId in 
                              (
                                select FinalPromotionShops.ShopId from FinalPromotionShops 
                                join PromotionShopInfo on PromotionShopInfo.ID =FinalPromotionShops.ShopId 
                                where FinalPromotionShops.PromotionId=" + PromotionId + " and (FinalPromotionShops.IsDelete is null or FinalPromotionShops.IsDelete=0)" + where + " ) and RackInfo.StoryBagId=" + StoryBagId

                            );

            return DbHelperSQL.Query(DbHelperSQL.connectionString(), strSql.ToString());
        }


//        public DataSet GetFinalRackList1(int PromotionId, string StoryBagIds, string where,string rackIds=null)
//        {
//            StringBuilder strSql = new StringBuilder();

//            strSql.Append(@"select RackInShop.Id,RackInShop.ShopId,RackInShop.PosId,RackInShop.RackId,RackInShop.Size,isnull(RackInShop.RackCount,0) RackCount,
//                            POPSeat.seat Position,
//                            RackInfo.RackCode,
//                            RackInfo.RackType,
//                            RackInfo.RackName,
//                            RackInfo.Size RackSize,
//                            RackInfo.Texture,
//                            RackInfo.Specification,
//                            RackInfo.Category,
//                            isnull(RackInfo.Price,0) Price
//                            from RackInShop
//                            join RackInfo on RackInfo.Id=RackId 
//                            join POPSeat on POPSeat.SeatID = RackInfo.PositionId
//                              where  ShopId in 
//                              (
//                                select FinalPromotionShops.ShopId from FinalPromotionShops 
//                                join PromotionShopInfo on PromotionShopInfo.ID =FinalPromotionShops.ShopId 
//                                where FinalPromotionShops.PromotionId=" + PromotionId + " and (FinalPromotionShops.IsDelete is null or FinalPromotionShops.IsDelete=0)" + where + " ) and RackInfo.StoryBagId in(" + StoryBagIds+")"

//                            );
//            if (!string.IsNullOrWhiteSpace(rackIds))
//            {
//                strSql.Append(" and RackInShop.RackId in (" + rackIds + ")");
//            }
//            return DbHelperSQL.Query(DbHelperSQL.connectionString(), strSql.ToString());
//        }

        public DataSet GetFinalRackList1(int PromotionId, string StoryBagIds, string where, string rackIds = null)
        {
            StringBuilder strSql = new StringBuilder();

            strSql.Append(@"select RackInShop.Id,RackInShop.ShopId,RackInShop.PosId,RackInShop.RackId,RackInShop.Size,isnull(RackInShop.RackCount,0) RackCount,
                            POPSeat.seat Position,
                            RackInfo.RackCode,
                            RackInfo.RackType,
                            RackInfo.RackName,
                            RackInfo.Size RackSize,
                            RackInfo.Texture,
                            RackInfo.Specification,
                            RackInfo.Category,
                            isnull(RackInfo.Price,0) Price
                            from RackInShop
                            join RackInfo on RackInfo.Id=RackId 
                            join POPSeat on POPSeat.SeatID = RackInfo.PositionId
                              where  ShopId in 
                              (
                                select FinalPromotionShops.ShopId from FinalPromotionShops 
                                join PromotionShops on PromotionShops.ShopId =FinalPromotionShops.ShopId 
                                where FinalPromotionShops.PromotionId=" + PromotionId + " and PromotionShops.PromotionId=" + PromotionId + " and (FinalPromotionShops.IsDelete is null or FinalPromotionShops.IsDelete=0)" + where + " ) and RackInfo.StoryBagId in(" + StoryBagIds + ")"

                            );
            if (!string.IsNullOrWhiteSpace(rackIds))
            {
                strSql.Append(" and RackInShop.RackId in (" + rackIds + ")");
            }
            return DbHelperSQL.Query(DbHelperSQL.connectionString(), strSql.ToString());
        }

        public DataSet GetPomosionRackList(int PromotionId, string StoryBagIds, string rackIds)
        {
            StringBuilder strSql = new StringBuilder();

            strSql.Append(@"select RackInShop.Id,RackInShop.ShopId,RackInShop.PosId,RackInShop.RackId,RackInShop.Size,isnull(RackInShop.RackCount,0) RackCount,
                            POPSeat.seat Position,
                            RackInfo.RackCode,
                            RackInfo.RackType,
                            RackInfo.RackName,
                            RackInfo.Size RackSize,
                            RackInfo.Texture,
                            RackInfo.Specification,
                            RackInfo.Category,
                            isnull(RackInfo.Price,0) Price
                            from RackInShop
                            join RackInfo on RackInfo.Id=RackId 
                            join POPSeat on POPSeat.SeatID = RackInfo.PositionId
                              where  ShopId in 
                              (
                                select FinalPromotionShops.ShopId from FinalPromotionShops 
                                join PromotionShopInfo on PromotionShopInfo.ID =FinalPromotionShops.ShopId 
                                where FinalPromotionShops.PromotionId=" + PromotionId + " and (FinalPromotionShops.IsDelete is null or FinalPromotionShops.IsDelete=0)) and RackInfo.StoryBagId in(" + StoryBagIds + ") and RackInShop.RackId in(" + rackIds + ")"
                      

                            );

            return DbHelperSQL.Query(DbHelperSQL.connectionString(), strSql.ToString());
        }


        public List<LN.Model.RackInShop> GetRackList(string where)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select Id,ShopId,PosId,RackId,Size,RackCount ");
            strSql.Append(" FROM RackInShop ");
            if (where.Trim() != "")
            {
                strSql.Append(" where " + where);
            }
            List<LN.Model.RackInShop> list = new List<Model.RackInShop>();
            LN.Model.RackInShop model;
            SqlDataReader reader = DbHelperSQL.ExecuteReader(DbHelperSQL.connectionString(), strSql.ToString());
            while (reader.Read())
            {
                model = new Model.RackInShop();
                if (!string.IsNullOrWhiteSpace(reader["Id"].ToString()))
                {
                    model.Id = int.Parse(reader["Id"].ToString());
                }
                if (!string.IsNullOrWhiteSpace(reader["ShopId"].ToString()))
                {
                    model.ShopId = int.Parse(reader["ShopId"].ToString());
                }
                if (!string.IsNullOrWhiteSpace(reader["PosId"].ToString()))
                {
                    model.PosId = reader["PosId"].ToString();
                }
                if (!string.IsNullOrWhiteSpace(reader["RackId"].ToString()))
                {
                    model.RackId = int.Parse(reader["RackId"].ToString());
                }
                if (!string.IsNullOrWhiteSpace(reader["Size"].ToString()))
                {
                    model.Size = reader["Size"].ToString();
                }
                if (!string.IsNullOrWhiteSpace(reader["RackCount"].ToString()))
                {
                    model.RackCount = int.Parse(reader["RackCount"].ToString());
                }
                list.Add(model);
            }
            reader.Close();
            reader.Dispose();
            return list;
        }


        public DataSet GetJoinRackList(string where)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat(@"
                   select RackInfo.RackName,RackInfo.RackType,POPSeat.Seat,sum(RackInShop.RackCount) RackCount 
                   from RackInShop 
                   join RackInfo on RackInfo.Id=RackInShop.RackId 
                   left join PopSeat on PopSeat.SeatId=RackInfo.PositionId
                   where 1=1 {0} group by RackInfo.RackType,RackInfo.RackName,RackInfo.PositionId,POPSeat.Seat
            ", where);
            strSql.Append(" order by RackInfo.PositionId");
            return DbHelperSQL.Query(DbHelperSQL.connectionString(), strSql.ToString());
        }
    }
}
