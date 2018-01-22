using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using LN.DBUtility;//请先添加引用

namespace LN.DAL
{
    public class RackInfo
    {
        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperSQL.GetMaxID(DbHelperSQL.connectionString(), "Id", "RackInfo");
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from RackInfo");
            strSql.Append(" where Id=@id ");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
            parameters[0].Value = id;

            return DbHelperSQL.Exists(DbHelperSQL.connectionString(), strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(LN.Model.RackInfo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into RackInfo(");
            strSql.Append("PositionId,RackType,RackName,Size,Texture,Specification,Units,Category,StoryBagId,IsDelete,RackCode,Price)");
            strSql.Append(" values (");
            strSql.Append("@PositionId,@RackType,@RackName,@Size,@Texture,@Specification,@Units,@Category,@StoryBagId,@IsDelete,@RackCode,@Price)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@PositionId",model.PositionId),
                    new SqlParameter("@RackType",model.RackType),
                    new SqlParameter("@RackName",model.RackName),
                    new SqlParameter("@Size",model.Size),
                    new SqlParameter("@Texture",model.Texture),
                    new SqlParameter("@Specification",model.Specification),
                    new SqlParameter("@Units",model.Units),
                    new SqlParameter("@Category",model.Category),
                    new SqlParameter("@StoryBagId",model.StoryBagId),
                    new SqlParameter("@IsDelete",model.IsDelete),
                    new SqlParameter("@RackCode",model.RackCode),
                    new SqlParameter("@Price",model.Price)
                    
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
            strSql.Append("delete RackInfo ");
            strSql.Append(" where Id=@Id ");
            SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4)};
            parameters[0].Value = id;

            DbHelperSQL.ExecuteSql(DbHelperSQL.connectionString(), strSql.ToString(), parameters);
        }

        public int Update(LN.Model.RackInfo model)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append(@"update RackInfo set 
                         PositionId=@PositionId,
                         RackType=@RackType,
                         RackName=@RackName,
                         Size=@Size,
                         Texture=@Texture,
                         Specification=@Specification,
                         Units=@Units,
                         Category=@Category,
                         StoryBagId=@StoryBagId,
                         IsDelete=@IsDelete,
                         RackCode=@RackCode,
                         Price=@Price
                        
                         where Id=@Id
                       ");
           
            SqlParameter[] parameters = {
					new SqlParameter("@PositionId",model.PositionId),
                    new SqlParameter("@RackType",model.RackType),
                    new SqlParameter("@RackName",model.RackName),
                    new SqlParameter("@Size",model.Size),
                    new SqlParameter("@Texture",model.Texture),
                    new SqlParameter("@Specification",model.Specification),
                    new SqlParameter("@Units",model.Units),
                    new SqlParameter("@Category",model.Category),
                    new SqlParameter("@StoryBagId",model.StoryBagId),
                    new SqlParameter("@IsDelete",model.IsDelete),
                    new SqlParameter("@RackCode",model.RackCode),
                    new SqlParameter("@Price",model.Price),
                   
                    new SqlParameter("@Id",model.Id),
                    
            };
            return DbHelperSQL.ExecuteSql(DbHelperSQL.connectionString(), sql.ToString(), parameters);
            
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public LN.Model.RackInfo GetModel(int id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 Id,PositionId,RackType,RackName,Size,Texture,Specification,Units,Category,StoryBagId,IsDelete,RackCode,Price from RackInfo ");
            strSql.Append(" where Id=@Id ");
            SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4)};
            parameters[0].Value = id;

            LN.Model.RackInfo model = new LN.Model.RackInfo();
            DataSet ds = DbHelperSQL.Query(DbHelperSQL.connectionString(), strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["Id"].ToString() != "")
                {
                    model.Id = int.Parse(ds.Tables[0].Rows[0]["Id"].ToString());
                }
                model.PositionId = int.Parse(ds.Tables[0].Rows[0]["PositionId"].ToString());
                model.RackType = ds.Tables[0].Rows[0]["RackType"].ToString();
                model.RackName = ds.Tables[0].Rows[0]["RackName"].ToString();
                model.Size = ds.Tables[0].Rows[0]["Size"].ToString();
                model.Texture = ds.Tables[0].Rows[0]["Texture"].ToString();
                model.Specification = ds.Tables[0].Rows[0]["Specification"].ToString();
                model.Units = ds.Tables[0].Rows[0]["Units"].ToString();
                model.Category = ds.Tables[0].Rows[0]["Category"].ToString();
                model.StoryBagId = int.Parse(ds.Tables[0].Rows[0]["StoryBagId"].ToString());
                model.IsDelete = int.Parse(ds.Tables[0].Rows[0]["IsDelete"].ToString());
                model.RackCode = ds.Tables[0].Rows[0]["RackCode"].ToString();
                if (ds.Tables[0].Rows[0]["Price"].ToString() != "")
                    model.Price = decimal.Parse(ds.Tables[0].Rows[0]["Price"].ToString());
                
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
            strSql.Append("select Id,PositionId,RackType,RackName,Size,Texture,Specification,Units,Category,StoryBagId,IsDelete,RackCode,Price ");
            strSql.Append(" FROM RackInfo ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(DbHelperSQL.connectionString(), strSql.ToString());
        }

        public DataSet GetJoinList(string where)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select RackInfo.Id,RackInfo.PositionId,RackInfo.RackType,RackInfo.RackName,RackInfo.Size,RackInfo.Texture,RackInfo.Specification,RackInfo.Units,RackInfo.Category,RackInfo.StoryBagId,POPSeat.seat,RackInfo.IsDelete,RackInfo.RackCode,RackInfo.Price,PromotionStoryBag.StoryBagName");
            strSql.Append(" FROM RackInfo join POPSeat on POPSeat.SeatID=RackInfo.PositionId join PromotionStoryBag on PromotionStoryBag.Id=RackInfo.StoryBagId");
            if (where.Trim()!="")
            {
                strSql.Append(" where " + where);
            }
            strSql.Append(" order by RackInfo.StoryBagId,RackInfo.PositionId");
            return DbHelperSQL.Query(DbHelperSQL.connectionString(), strSql.ToString());
        }

        public DataSet GetJoinListPage(string where,int currPage,int pageSize)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from (select row_number() over(order by RackInfo.StoryBagId,RackInfo.PositionId) row,");
            strSql.Append(" RackInfo.Id,RackInfo.PositionId,RackInfo.RackType,RackInfo.RackName,RackInfo.Size,RackInfo.Texture,RackInfo.Specification,RackInfo.Units,RackInfo.Category,RackInfo.StoryBagId,POPSeat.seat,PromotionStoryBag.StoryBagName,RackInfo.IsDelete,RackInfo.RackCode,RackInfo.Price ");
            strSql.Append(" FROM RackInfo join POPSeat on POPSeat.SeatID=RackInfo.PositionId join PromotionStoryBag on PromotionStoryBag.Id=RackInfo.StoryBagId ");
            strSql.Append(" where 1=1 " + where);
            strSql.Append(") temp where row between ((@currPage-1)*@pageSize+1) and (@currPage*@pageSize)");
            SqlParameter[] paras = new SqlParameter[] { 
                new SqlParameter("@currPage",currPage),
                new SqlParameter("@pageSize",pageSize)
            };
            return DbHelperSQL.Query(DbHelperSQL.connectionString(), strSql.ToString(), paras);
        }

        public int GetPageCount(string where)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(*) from RackInfo join POPSeat on POPSeat.SeatID=RackInfo.PositionId join PromotionStoryBag on PromotionStoryBag.Id=RackInfo.StoryBagId");
            strSql.Append(" where 1=1 " + where);
            object obj = DbHelperSQL.GetSingle(DbHelperSQL.connectionString(), strSql.ToString());
            return obj != null ? int.Parse(obj.ToString()) : 0;
        }

        public DataSet GetPropType()
        {
            string sql = "select distinct RackType from RackInfo where IsDelete=0";
            return DbHelperSQL.Query(DbHelperSQL.connectionString(), sql);
        }

        public List<LN.Model.RackInfo> GetRackList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select Id,PositionId,RackType,RackName,Size,Texture,Specification,Units,Category,StoryBagId,IsDelete,RackCode,Price ");
            strSql.Append(" FROM RackInfo ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            SqlDataReader reader = DbHelperSQL.ExecuteReader(DbHelperSQL.connectionString(), strSql.ToString());
            List<LN.Model.RackInfo> list = new List<Model.RackInfo>();
            LN.Model.RackInfo model;
            while (reader.Read())
            {
                model = new Model.RackInfo();
                if (!string.IsNullOrWhiteSpace(reader["Id"].ToString()))
                {
                    model.Id = int.Parse(reader["Id"].ToString());
                }
                if (!string.IsNullOrWhiteSpace(reader["PositionId"].ToString()))
                {
                    model.PositionId = int.Parse(reader["PositionId"].ToString());
                }
                if (!string.IsNullOrWhiteSpace(reader["RackType"].ToString()))
                {
                    model.RackType = reader["RackType"].ToString();
                }
                if (!string.IsNullOrWhiteSpace(reader["RackName"].ToString()))
                {
                    model.RackName = reader["RackName"].ToString();
                }
                if (!string.IsNullOrWhiteSpace(reader["Size"].ToString()))
                {
                    model.Size = reader["Size"].ToString();
                }
                if (!string.IsNullOrWhiteSpace(reader["Texture"].ToString()))
                {
                    model.Texture = reader["Texture"].ToString();
                }
                if (!string.IsNullOrWhiteSpace(reader["Specification"].ToString()))
                {
                    model.Specification = reader["Specification"].ToString();
                }
                if (!string.IsNullOrWhiteSpace(reader["Units"].ToString()))
                {
                    model.Units = reader["Units"].ToString();
                }
                if (!string.IsNullOrWhiteSpace(reader["Category"].ToString()))
                {
                    model.Category = reader["Category"].ToString();
                }
                if (!string.IsNullOrWhiteSpace(reader["StoryBagId"].ToString()))
                {
                    model.StoryBagId = int.Parse(reader["StoryBagId"].ToString());
                }
                if (!string.IsNullOrWhiteSpace(reader["IsDelete"].ToString()))
                {
                    model.IsDelete = int.Parse(reader["IsDelete"].ToString());
                }
                if (!string.IsNullOrWhiteSpace(reader["RackCode"].ToString()))
                {
                    model.RackCode = reader["RackCode"].ToString();
                }
                if (!string.IsNullOrWhiteSpace(reader["Price"].ToString()))
                {
                    model.Price = decimal.Parse(reader["Price"].ToString());
                }
                list.Add(model);
            }
            reader.Close();
            reader.Dispose();
            return list;
        }
    }
}
