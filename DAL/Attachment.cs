using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using LN.DBUtility;
using System.Data;

namespace LN.DAL
{
    public class Attachment
    {
        public Attachment() { }

        public int Add(LN.Model.Attachment model)
        {
            string sql = "insert into Attachment(ItemId,ItemTypeId,Title,FileCode,FileType,FilePath,SmallImgUrl,AddDate,AddUserId,IsDelete,FileNumber) values(@ItemId,@ItemTypeId,@Title,@FileCode,@FileType,@FilePath,@SmallImgUrl,@AddDate,@AddUserId,@IsDelete,@FileNumber); select @@identity";
            SqlParameter[] parameters = new SqlParameter[] { 
              new SqlParameter("@ItemId",model.ItemId),
              new SqlParameter("@ItemTypeId",model.ItemTypeId),
              new SqlParameter("@Title",model.Title),
              new SqlParameter("@FileCode",model.FileCode),
              new SqlParameter("@FileType",model.FileType),
              new SqlParameter("@FilePath",model.FilePath),
              new SqlParameter("@SmallImgUrl",model.SmallImgUrl),
              new SqlParameter("@AddDate",model.AddDate),
              new SqlParameter("@AddUserId",model.AddUserId),
              new SqlParameter("@IsDelete",model.IsDelete),
              new SqlParameter("@FileNumber",model.FileNumber)
            };
            return DbHelperSQL.ExecuteSql(DbHelperSQL.connectionString(), sql, parameters);
           
        }

        public bool Update(LN.Model.Attachment model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Attachment set ");
            strSql.Append("ItemId=@ItemId,");
            strSql.Append("ItemTypeId=@ItemTypeId,");
            strSql.Append("Title=@Title,");
            strSql.Append("FileCode=@FileCode,");
            strSql.Append("FileType=@FileType,");
            strSql.Append("FilePath=@FilePath,");
            strSql.Append("SmallImgUrl=@SmallImgUrl,");
            strSql.Append("IsDelete=@IsDelete");
            strSql.Append(" where Id=@Id");
            SqlParameter[] parameters = new SqlParameter[] { 
              new SqlParameter("@ItemId",model.ItemId),
              new SqlParameter("@ItemTypeId",model.ItemTypeId),
              new SqlParameter("@Title",model.Title),
              new SqlParameter("@FileCode",model.FileCode),
              new SqlParameter("@FileType",model.FileType),
              new SqlParameter("@FilePath",model.FilePath),
              new SqlParameter("@SmallImgUrl",model.SmallImgUrl),
              new SqlParameter("@IsDelete",model.IsDelete),
              new SqlParameter("@Id",model.Id)
            };
            int rows = DbHelperSQL.ExecuteSql(DbHelperSQL.connectionString(),strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public LN.Model.Attachment GetModel(int id)
        {

            LN.Model.Attachment model = new LN.Model.Attachment();
            DataSet ds = GetList(string.Format(" Id={0}", id));
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["Title"] != null && ds.Tables[0].Rows[0]["Title"].ToString() != "")
                {
                    model.Title = ds.Tables[0].Rows[0]["Title"].ToString();
                }

                if (ds.Tables[0].Rows[0]["Id"] != null && ds.Tables[0].Rows[0]["Id"].ToString() != "")
                {
                    model.Id = int.Parse(ds.Tables[0].Rows[0]["Id"].ToString());
                }
                if (ds.Tables[0].Rows[0]["ItemId"] != null && ds.Tables[0].Rows[0]["ItemId"].ToString() != "")
                {
                    model.ItemId = ds.Tables[0].Rows[0]["ItemId"].ToString();
                }
                if (ds.Tables[0].Rows[0]["ItemTypeId"] != null && ds.Tables[0].Rows[0]["ItemTypeId"].ToString() != "")
                {
                    model.ItemTypeId = ds.Tables[0].Rows[0]["ItemTypeId"].ToString();
                }
                if (ds.Tables[0].Rows[0]["FileCode"] != null && ds.Tables[0].Rows[0]["FileCode"].ToString() != "")
                {
                    model.FileCode = ds.Tables[0].Rows[0]["FileCode"].ToString();
                }
                if (ds.Tables[0].Rows[0]["FileType"] != null && ds.Tables[0].Rows[0]["FileType"].ToString() != "")
                {
                    model.FileType = ds.Tables[0].Rows[0]["FileType"].ToString();
                }
                if (ds.Tables[0].Rows[0]["FilePath"] != null && ds.Tables[0].Rows[0]["FilePath"].ToString() != "")
                {
                    model.FilePath = ds.Tables[0].Rows[0]["FilePath"].ToString();
                }
                if (ds.Tables[0].Rows[0]["SmallImgUrl"] != null && ds.Tables[0].Rows[0]["SmallImgUrl"].ToString() != "")
                {
                    model.SmallImgUrl = ds.Tables[0].Rows[0]["SmallImgUrl"].ToString();
                }
                
                if (ds.Tables[0].Rows[0]["AddDate"] != null && ds.Tables[0].Rows[0]["AddDate"].ToString() != "")
                {
                    model.AddDate = DateTime.Parse(ds.Tables[0].Rows[0]["AddDate"].ToString());
                }
                if (ds.Tables[0].Rows[0]["AddUserId"] != null && ds.Tables[0].Rows[0]["AddUserId"].ToString() != "")
                {
                    model.AddUserId = int.Parse(ds.Tables[0].Rows[0]["AddUserId"].ToString());
                }
                if (ds.Tables[0].Rows[0]["IsDelete"] != null && ds.Tables[0].Rows[0]["IsDelete"].ToString() != "")
                {
                    model.IsDelete = int.Parse(ds.Tables[0].Rows[0]["IsDelete"].ToString());
                }
                if (ds.Tables[0].Rows[0]["FileNumber"] != null && ds.Tables[0].Rows[0]["FileNumber"].ToString() != "")
                {
                    model.FileNumber = ds.Tables[0].Rows[0]["FileNumber"].ToString();
                }
                return model;
            }
            else
            {
                return null;
            }
        }


        public DataSet GetList(string whereStr)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * ");
            strSql.Append(" FROM Attachment ");
            if (whereStr.Trim() != "")
            {
                strSql.Append(" where " + whereStr);
            }
            return DbHelperSQL.Query(DbHelperSQL.connectionString(),strSql.ToString());
        }

        public DataSet GetPageList(string where, int currPage, int pageSize)
        {
            string sql = "select * from (select row_number() over(order by Id desc) row,* from Attachment where 1=1 " + where + ") as temp where row between ((@currPage-1)*@pageSize+1) and (@currPage*@pageSize)";
            SqlParameter[] paras = new SqlParameter[] { 
               new SqlParameter("@currPage",currPage),
               new SqlParameter("@pageSize",pageSize)
            };
            return DbHelperSQL.Query(DbHelperSQL.connectionString(), sql, paras);
        }

        public int PageCount(string where)
        {
            string sql = "select count(1) from Attachment where 1=1 " + where;
            object i = DbHelperSQL.GetSingle(DbHelperSQL.connectionString(), sql);
            return i != null ? int.Parse(i.ToString()) : 0;
        }
    }
}
