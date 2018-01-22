using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using LN.DBUtility;
using System.Data;

namespace LN.DAL
{
    public class PromotionSonStoryBag
    {
        public int Add(LN.Model.PromotionSonStoryBag model)
        {
            string sql = "insert into PromotionSonStoryBag(PromotionId,ParentStoryBagId,StoryBagName,IsSon) values(@PromotionId,@ParentStoryBagId,@StoryBagName,@IsSon); select @@identity";
            SqlParameter[] parameters = new SqlParameter[] { 
              new SqlParameter("@PromotionId",model.PromotionId),
              new SqlParameter("@ParentStoryBagId",model.ParentStoryBagId),
              new SqlParameter("@StoryBagName",model.StoryBagName),
              new SqlParameter("@IsSon",model.IsSon)
            };
            return DbHelperSQL.ExecuteSql(DbHelperSQL.connectionString(), sql, parameters);

        }

        public DataSet GetList(int promotionId)
        {
            //string sql = "select PromotionSonStoryBag.Id,PromotionSonStoryBag.PromotionId,PromotionSonStoryBag.ParentStoryBagId,PromotionSonStoryBag.StoryBagName,PromotionStoryBag.StoryBagName+'-'+PromotionSonStoryBag.StoryBagName FullStoryBagName from PromotionSonStoryBag join PromotionStoryBag on PromotionStoryBag.Id=PromotionSonStoryBag.ParentStoryBagId where PromotionId=" + promotionId;
            //return DbHelperSQL.Query(DbHelperSQL.connectionString(), sql);
            StringBuilder sql = new StringBuilder();
            sql.Append(@"
                       select 
                        case 
                        when PromotionSonStoryBag.IsSon=1 then PromotionStoryBag.StoryBagName+'-'+PromotionSonStoryBag.StoryBagName
                        else PromotionStoryBag.StoryBagName 
                        end FullStoryBagName,PromotionSonStoryBag.Id,PromotionSonStoryBag.PromotionId,PromotionSonStoryBag.ParentStoryBagId
                        from PromotionSonStoryBag join dbo.PromotionStoryBag on PromotionStoryBag.Id =PromotionSonStoryBag.ParentStoryBagId
                       ");
            sql.Append(" where PromotionId=" + promotionId);
            return DbHelperSQL.Query(DbHelperSQL.connectionString(), sql.ToString());
        }

        public DataSet GetList(string where)
        {
            string sql = "select PromotionSonStoryBag.Id,PromotionSonStoryBag.PromotionId,PromotionSonStoryBag.ParentStoryBagId,PromotionSonStoryBag.StoryBagName,PromotionStoryBag.StoryBagName+'-'+PromotionSonStoryBag.StoryBagName FullStoryBagName from PromotionSonStoryBag join PromotionStoryBag on PromotionStoryBag.Id=PromotionSonStoryBag.ParentStoryBagId";
            if (!string.IsNullOrWhiteSpace(where))
            {
                sql += " where " + where;
            }
            return DbHelperSQL.Query(DbHelperSQL.connectionString(), sql);
        }

        public bool DeleteByPromotionId(int promotionId)
        {
            string sql = "delete from PromotionSonStoryBag where PromotionId=" + promotionId;
            return DbHelperSQL.ExecuteSql(DbHelperSQL.connectionString(), sql)>=0;
        }

        public Model.PromotionSonStoryBag GetModel(int id)
        {
            string sql = "select * from PromotionSonStoryBag where Id=" + id;
            SqlDataReader reader=DbHelperSQL.ExecuteReader(DbHelperSQL.connectionString(),sql);
            LN.Model.PromotionSonStoryBag model=null;
            if(reader.Read())
            {
                model = new Model.PromotionSonStoryBag();
                model.Id = id;
                if (!string.IsNullOrEmpty(reader["PromotionId"].ToString()))
                {
                    model.PromotionId = int.Parse(reader["PromotionId"].ToString());
                }
                if (!string.IsNullOrEmpty(reader["ParentStoryBagId"].ToString()))
                {
                    model.ParentStoryBagId = int.Parse(reader["ParentStoryBagId"].ToString());
                }
                if (!string.IsNullOrEmpty(reader["StoryBagName"].ToString()))
                {
                    model.StoryBagName = reader["StoryBagName"].ToString();
                }
                if (!string.IsNullOrEmpty(reader["IsSon"].ToString()))
                {
                    model.IsSon =int.Parse(reader["IsSon"].ToString());
                }
            }
            return model;
        }

        public List<Model.PromotionSonStoryBag> GetDataList(string whereStr)
        {
            List<Model.PromotionSonStoryBag> list = new List<Model.PromotionSonStoryBag>();
            string sql = "select * from PromotionSonStoryBag ";
            if (!string.IsNullOrWhiteSpace(whereStr))
            {
                sql += " where " + whereStr;
            }
            SqlDataReader reader = DbHelperSQL.ExecuteReader(DbHelperSQL.connectionString(), sql);
            LN.Model.PromotionSonStoryBag model = null;
            while (reader.Read())
            {
                model = new Model.PromotionSonStoryBag();
                if (!string.IsNullOrEmpty(reader["Id"].ToString()))
                {
                    model.Id = int.Parse(reader["Id"].ToString());
                }
                if (!string.IsNullOrEmpty(reader["PromotionId"].ToString()))
                {
                    model.PromotionId = int.Parse(reader["PromotionId"].ToString());
                }
                if (!string.IsNullOrEmpty(reader["ParentStoryBagId"].ToString()))
                {
                    model.ParentStoryBagId = int.Parse(reader["ParentStoryBagId"].ToString());
                }
                if (!string.IsNullOrEmpty(reader["StoryBagName"].ToString()))
                {
                    model.StoryBagName = reader["StoryBagName"].ToString();
                }
                if (!string.IsNullOrEmpty(reader["IsSon"].ToString()))
                {
                    model.IsSon = int.Parse(reader["IsSon"].ToString());
                }
                list.Add(model);
            }
            reader.Close();
            return list;
        }
    }
}
