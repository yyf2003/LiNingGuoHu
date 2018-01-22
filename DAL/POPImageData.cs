using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using System.Collections;
using System.Collections.Generic;
using LN.DBUtility;//请先添加引用
namespace LN.DAL
{
	/// <summary>
	/// 数据访问类POPImageData。
	/// </summary>
	public class POPImageData
	{
		public POPImageData()
		{}
		#region  成员方法

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
            return DbHelperSQL.GetMaxID(DbHelperSQL.connectionString(), "ImageID", "POPImageData"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int ImageID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from POPImageData");
			strSql.Append(" where ImageID=@ImageID ");
			SqlParameter[] parameters = {
					new SqlParameter("@ImageID", SqlDbType.Int,4)};
			parameters[0].Value = ImageID;

            return DbHelperSQL.Exists(DbHelperSQL.connectionString(), strSql.ToString(), parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(LN.Model.POPImageData model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into POPImageData(");
            strSql.Append("POPID,ShopLevelID,ProductLine,ImageUrl,ImageLevel,SmallImageUrl,POPScaleData,ImageDesc,UploadDate)");
			strSql.Append(" values (");
            strSql.Append("@POPID,@ShopLevelID,@ProductLine,@ImageUrl,@ImageLevel,@SmallImageUrl,@POPScaleData,@ImageDesc,@UploadDate)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
                    new SqlParameter("@POPID", SqlDbType.VarChar,50),
					new SqlParameter("@ShopLevelID", SqlDbType.Int,4),
					new SqlParameter("@ProductLine", SqlDbType.VarChar,20),
					new SqlParameter("@ImageUrl", SqlDbType.VarChar,200),
					new SqlParameter("@ImageLevel", SqlDbType.NVarChar,20),
                    new SqlParameter("@SmallImageUrl", SqlDbType.VarChar,200),
					new SqlParameter("@POPScaleData", SqlDbType.VarChar,50),
					new SqlParameter("@ImageDesc", SqlDbType.VarChar,500),
					new SqlParameter("@UploadDate", SqlDbType.VarChar,50)};
            parameters[0].Value = model.POPID;
			parameters[1].Value = model.ShopLevelID;
			parameters[2].Value = model.ProductLine;
			parameters[3].Value = model.ImageUrl;
			parameters[4].Value = model.ImageLevel;
            parameters[5].Value = model.SmallImageUrl;
			parameters[6].Value = model.POPScaleData;
			parameters[7].Value = model.ImageDesc;
			parameters[8].Value = model.UploadDate;

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
        public void Update(LN.Model.POPImageData model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update POPImageData set ");
            strSql.Append("ShopLevelID=@ShopLevelID,");
            strSql.Append("ProductLine=@ProductLine,");
            strSql.Append("ImageUrl=@ImageUrl,");
            strSql.Append("ImageLevel=@ImageLevel,");
            strSql.Append("POPScaleData=@POPScaleData,");
            strSql.Append("ImageDesc=@ImageDesc,");
            strSql.Append("UploadDate=@UploadDate,");
            strSql.Append("AreaIDs=@AreaIDs,");
            strSql.Append("ACL_IDs=@ACL_IDs");
            strSql.Append(" where ImageID=@ImageID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ImageID", SqlDbType.Int,4),
					new SqlParameter("@ShopLevelID", SqlDbType.Int,4),
					new SqlParameter("@ProductLine", SqlDbType.VarChar,20),
					new SqlParameter("@ImageUrl", SqlDbType.VarChar,200),
					new SqlParameter("@ImageLevel", SqlDbType.NVarChar,20),
					new SqlParameter("@POPScaleData", SqlDbType.VarChar,50),
					new SqlParameter("@ImageDesc", SqlDbType.VarChar,500),
					new SqlParameter("@UploadDate", SqlDbType.VarChar,50),
                    new SqlParameter("@AreaIDs", SqlDbType.VarChar,500),
                    new SqlParameter("@ACL_IDs", SqlDbType.VarChar,50),
                                        };
            parameters[0].Value = model.ImageID;
            parameters[1].Value = model.ShopLevelID;
            parameters[2].Value = model.ProductLine;
            parameters[3].Value = model.ImageUrl;
            parameters[4].Value = model.ImageLevel;
            parameters[5].Value = model.POPScaleData;
            parameters[6].Value = model.ImageDesc;
            parameters[7].Value = model.UploadDate;
            parameters[8].Value = model.AreaIDs;
            parameters[9].Value = model.ACL_IDs;

            DbHelperSQL.ExecuteSql(DbHelperSQL.connectionString(), strSql.ToString(), parameters);
        }

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(int ImageID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete POPImageData ");
			strSql.Append(" where ImageID=@ImageID ");
			SqlParameter[] parameters = {
					new SqlParameter("@ImageID", SqlDbType.Int,4)};
			parameters[0].Value = ImageID;

            DbHelperSQL.ExecuteSql(DbHelperSQL.connectionString(), strSql.ToString(), parameters);
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public LN.Model.POPImageData GetModel(int ImageID)
		{
			
			StringBuilder strSql=new StringBuilder();
            strSql.Append("select  top 1 ImageID,POPID,ShopLevelID,ProductLine,ImageUrl,ImageLevel,SmallImageUrl,POPScaleData,ImageDesc,UploadDate,AreaIDs,ACL_IDs from POPImageData ");
			strSql.Append(" where ImageID=@ImageID ");
			SqlParameter[] parameters = {
					new SqlParameter("@ImageID", SqlDbType.Int,4)};
			parameters[0].Value = ImageID;

            LN.Model.POPImageData model = null;
            SqlDataReader reader = DbHelperSQL.ExecuteReader(DbHelperSQL.connectionString(), strSql.ToString(), parameters);
            if (reader.Read())
			{
                model = new LN.Model.POPImageData();
                if (!string.IsNullOrEmpty(reader["POPID"].ToString()))
                {
                    model.POPID =reader["POPID"].ToString();
                }
				if(!string.IsNullOrEmpty(reader["ImageID"].ToString()))
				{
                    model.ImageID = int.Parse(reader["ImageID"].ToString());
				}
                if (!string.IsNullOrEmpty(reader["ShopLevelID"].ToString()))
				{
                    model.ShopLevelID = int.Parse(reader["ShopLevelID"].ToString());
				}
                if (!string.IsNullOrEmpty(reader["ProductLine"].ToString()))
				{
                    model.ProductLine =reader["ProductLine"].ToString();
				}
				model.ImageUrl=reader["ImageUrl"].ToString();
                if (!string.IsNullOrEmpty(reader["ImageLevel"].ToString()))
				{
                    model.ImageLevel =reader["ImageLevel"].ToString();
				}
                model.SmallImageUrl = reader["SmallImageUrl"].ToString();
                model.POPScaleData = reader["POPScaleData"].ToString();
                model.ImageDesc = reader["ImageDesc"].ToString();
                model.UploadDate = reader["UploadDate"].ToString();

                if (!string.IsNullOrEmpty(reader["AreaIDs"].ToString()))
                {
                    model.AreaIDs = reader["AreaIDs"].ToString();
                }
                if (!string.IsNullOrEmpty(reader["ACL_IDs"].ToString()))
                {
                    model.ACL_IDs = reader["ACL_IDs"].ToString();
                }
			}
            reader.Close();
            return model;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<LN.Model.POPImageData> GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
            strSql.Append("select ImageID,POPID,ShopLevelID,ProductLine,ImageUrl , productlevel,ImageLevel,SmallImageUrl,POPScaleData,ImageDesc,UploadDate,Productlinename,ProductTypeName,AreaIDs,ACL_IDs ");
            strSql.Append(" FROM View_POPImageData ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
            SqlDataReader reader = DbHelperSQL.ExecuteReader(DbHelperSQL.connectionString(), strSql.ToString());
            List<LN.Model.POPImageData> modellist = new List<LN.Model.POPImageData>();
            LN.Model.POPImageData model = null;
            while (reader.Read())
            {
                model = new LN.Model.POPImageData();

                if (!string.IsNullOrEmpty(reader["POPID"].ToString()))
                {
                    model.POPID = reader["POPID"].ToString();
                }
                if (!string.IsNullOrEmpty(reader["ImageID"].ToString()))
                {
                    model.ImageID = int.Parse(reader["ImageID"].ToString());
                }
                if (!string.IsNullOrEmpty(reader["ShopLevelID"].ToString()))
                {
                    model.ShopLevelID = int.Parse(reader["ShopLevelID"].ToString());
                }
                if (!string.IsNullOrEmpty(reader["ProductLine"].ToString()))
                {
                    model.ProductLine =reader["ProductLine"].ToString();
                }
                model.ImageUrl = reader["ImageUrl"].ToString();
                if (!string.IsNullOrEmpty(reader["productlevel"].ToString()))
                {
                    model.productlevel = int.Parse(reader["productlevel"].ToString());
                }
                if (!string.IsNullOrEmpty(reader["ImageLevel"].ToString()))
                {
                    model.ImageLevel = reader["ImageLevel"].ToString();
                }
                model.SmallImageUrl = reader["SmallImageUrl"].ToString();
                model.POPScaleData = reader["POPScaleData"].ToString();
                model.ImageDesc = reader["ImageDesc"].ToString();
                model.UploadDate = reader["UploadDate"].ToString();
                model.ProductLineName = reader["ProductLineName"].ToString();
                model.ProductTypeName = reader["ProductTypeName"].ToString();

                if (!string.IsNullOrEmpty(reader["AreaIDs"].ToString()))
                {
                    model.AreaIDs = reader["AreaIDs"].ToString();
                }
                if (!string.IsNullOrEmpty(reader["ACL_IDs"].ToString()))
                {
                    model.ACL_IDs = reader["ACL_IDs"].ToString();
                }

                modellist.Add(model);
            }

            reader.Close();
            return modellist;
		}

        /// <summary>
        /// 根据指定条件获取
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public IList<string> GetImageLevel(string strWhere)
        {
            IList<string> imgList = new List<string>();
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT DISTINCT ImageLevel FROM POPImageData ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" WHERE " + strWhere);
            }
            SqlDataReader reader = DbHelperSQL.ExecuteReader(DbHelperSQL.connectionString(), strSql.ToString());
            while (reader.Read())
            {
                imgList.Add(reader["ImageLevel"].ToString());
            }
            reader.Close();
            return imgList;
        }


        /// <summary>
        /// 对上传图片进行设置
        /// </summary>
        /// <param name="htlist"></param>
        public void UpdateImgDesc(List<Hashtable> htlist)
        {
            if (htlist.Count > 0)
            {
                List<string> strlist = new List<string>();
                foreach (Hashtable  ht in htlist)
                {
                    StringBuilder str = new StringBuilder();
                  string imgremark=  ht["imgRemark"].ToString();
                  string imglevel = ht["imglevel"].ToString();
                  string prolevel = ht["prolevel"].ToString();
                  int imgid = int.Parse(ht["imgid"].ToString()); 
                  str.Append("update POPImageData " );
                  str.Append(" set ImageDesc='"+imgremark+"',");
                  str.Append("ProductLevel=" + prolevel + ",");
                  str.Append("ImageLevel='" + imglevel+"'");
                  str.Append(" where ImageID="+imgid);
                  strlist.Add(str.ToString());
                }

                DbHelperSQL.ExecuteSqlTran(DbHelperSQL.connectionString(), strlist);
            }
        }
        /// <summary>
        /// 得到设置图片的POP大类
        /// </summary>
        /// <param name="popid"></param>
        /// <returns></returns>
        public DataTable GetSetProtype(string popid)
        {
            string str = string.Format("select distinct productTypeName from view_popimagedata where POPID='{0}'",popid);
            DataSet ds = DbHelperSQL.Query(DbHelperSQL.connectionString(), str);
            return ds.Tables[0];
        }

        public DataTable GetLineByType(string popid, string protype)
        {
            string str = string.Format("select distinct productlinename from view_popimagedata where popid='{0}'" ,popid);
            if (protype != "0")
                str += string.Format(" and ProductTypeName='{0}'",protype);
            DataSet ds = DbHelperSQL.Query(DbHelperSQL.connectionString(), str);
            return ds.Tables[0];
        }

        /// <summary>
        /// 设置画面使用范围
        /// </summary>
        /// <param name="imageId"></param>
        /// <param name="AreaIDs"></param>
        /// <param name="ACL_IDs"></param>
        /// <returns></returns>
        public int SetPOPImageUseRange(int imageId, string AreaIDs, string ACL_IDs)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete POPImageUseRange ");
            strSql.Append(" where ImageID=@ImageID ");
            strSql.Append(";insert into POPImageUseRange(ImageID,AreaIDs,ACL_IDs) values(@ImageID,@AreaIDs,@ACL_IDs)");
            SqlParameter[] parameters = {
					new SqlParameter("@imageId", SqlDbType.Int,4),
                    new SqlParameter("@AreaIDs", SqlDbType.NVarChar),
                    new SqlParameter("@ACL_IDs", SqlDbType.NVarChar)
                                        };
            parameters[0].Value = imageId;
            parameters[1].Value = AreaIDs;
            parameters[2].Value = ACL_IDs;

            return DbHelperSQL.ExecuteSql(DbHelperSQL.connectionString(), strSql.ToString(), parameters);
        }

        /// <summary>
        /// 获取画面使用范围
        /// </summary>
        /// <param name="imageId"></param>
        /// <returns></returns>
        public DataSet GetPOPImageUseRange(int imageId)
        {
            string strSql = "select * from POPImageUseRange where ImageID=@ImageID ";
            SqlParameter[] parameters = {
					new SqlParameter("@imageId", SqlDbType.Int,4)
                                        };
            parameters[0].Value = imageId;

            return DbHelperSQL.Query(DbHelperSQL.connectionString(), strSql, parameters);
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
			parameters[0].Value = "POPImageData";
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

