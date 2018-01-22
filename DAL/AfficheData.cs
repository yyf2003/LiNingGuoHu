using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using LN.DBUtility;//请先添加引用
namespace LN.DAL
{
	/// <summary>
	/// 数据访问类AfficheData。
	/// </summary>
	public class AfficheData
	{
		public AfficheData()
		{}
		#region  成员方法

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
            return DbHelperSQL.GetMaxID(DbHelperSQL.connectionString(), "ID", "AfficheData"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from AfficheData");
			strSql.Append(" where ID=@ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)};
			parameters[0].Value = ID;

            return DbHelperSQL.Exists(DbHelperSQL.connectionString(), strSql.ToString(), parameters);
		}
        /// <summary>
        /// 更新点击率
        /// </summary>
        /// <param name="ID"></param>
        public void UpdateClick(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update AfficheData  set  ");
            strSql.Append("Click=Click+1 ");
            strSql.Append(" where ID=@ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)};
            parameters[0].Value = ID;
            DbHelperSQL.ExecuteSql(DbHelperSQL.connectionString(), strSql.ToString(), parameters);

        }

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(LN.Model.AfficheData model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into AfficheData(");
			strSql.Append("UserID,TypeID,Title,Main,FileUrl)");
			strSql.Append(" values (");
			strSql.Append("@UserID,@TypeID,@Title,@Main,@FileUrl)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@UserID", SqlDbType.NVarChar,20),
					new SqlParameter("@TypeID", SqlDbType.NVarChar,20),
					new SqlParameter("@Title", SqlDbType.NVarChar,50),
					new SqlParameter("@Main", SqlDbType.Text),
					new SqlParameter("@FileUrl", SqlDbType.NVarChar,800)};
            if (string.IsNullOrEmpty(model.UserID))
            {
                parameters[0].Value = "";
            }
            else
            {
                parameters[0].Value = model.UserID;
            }
            if (string.IsNullOrEmpty(model.TypeID))
            {
                parameters[1].Value = "";
            }
            else
            {
                parameters[1].Value = model.TypeID;
            }
            if (string.IsNullOrEmpty(model.Title))
            {
                parameters[2].Value = "";
            }
            else
            {
                parameters[2].Value = model.Title;
            }
            if (string.IsNullOrEmpty(model.Main))
            {
                parameters[3].Value = "";
            }
            else
            {
                parameters[3].Value = model.Main;
            } 
       
            if (string.IsNullOrEmpty(model.FileUrl))
            {
                parameters[4].Value ="";
            }
            else
            {
                parameters[4].Value = model.FileUrl;
            }
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
		public void Update(LN.Model.AfficheData model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update AfficheData set ");
			strSql.Append("TypeID=@TypeID,");
			strSql.Append("Title=@Title,");
			strSql.Append("Main=@Main,");
			strSql.Append("FileUrl=@FileUrl ");
			strSql.Append(" where ID=@ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4),
					new SqlParameter("@TypeID", SqlDbType.NVarChar,20),
					new SqlParameter("@Title", SqlDbType.NVarChar,50),
					new SqlParameter("@Main", SqlDbType.Text),
					new SqlParameter("@FileUrl", SqlDbType.NVarChar,800)};
			parameters[0].Value = model.ID;
      
            if (string.IsNullOrEmpty(model.TypeID))
            {
                parameters[1].Value = "";
            }
            else
            {
                parameters[1].Value = model.TypeID;
            }
            if (string.IsNullOrEmpty(model.Title))
            {
                parameters[2].Value = "";
            }
            else
            {
                parameters[2].Value = model.Title;
            }
            if (string.IsNullOrEmpty(model.Main))
            {
                parameters[3].Value = "";
            }
            else
            {
                parameters[3].Value = model.Main;
            } 
          
            if (string.IsNullOrEmpty(model.FileUrl))
            {
                parameters[4].Value = "";
            }
            else
            {
                parameters[4].Value = model.FileUrl;
            }

            DbHelperSQL.ExecuteSql(DbHelperSQL.connectionString(), strSql.ToString(), parameters);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(int ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update  AfficheData ");
            strSql.Append("set  IsDel =1  "); 
			strSql.Append(" where ID=@ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)};
			parameters[0].Value = ID;

            DbHelperSQL.ExecuteSql(DbHelperSQL.connectionString(), strSql.ToString(), parameters);
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public LN.Model.AfficheData GetModel(int ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 ID,UserID,TypeID,Title,Main,Click,IsScroll,IsDel,FileUrl,Time from AfficheData ");
			strSql.Append(" where ID=@ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)};
			parameters[0].Value = ID;

			LN.Model.AfficheData model=new LN.Model.AfficheData();
            DataSet ds = DbHelperSQL.Query(DbHelperSQL.connectionString(), strSql.ToString(), parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["ID"].ToString()!="")
				{
					model.ID=int.Parse(ds.Tables[0].Rows[0]["ID"].ToString());
				}
				model.UserID=ds.Tables[0].Rows[0]["UserID"].ToString();
				model.TypeID=ds.Tables[0].Rows[0]["TypeID"].ToString();
				model.Title=ds.Tables[0].Rows[0]["Title"].ToString();
				model.Main=ds.Tables[0].Rows[0]["Main"].ToString();
				if(ds.Tables[0].Rows[0]["Click"].ToString()!="")
				{
					model.Click=int.Parse(ds.Tables[0].Rows[0]["Click"].ToString());
				}
				if(ds.Tables[0].Rows[0]["IsScroll"].ToString()!="")
				{
					model.IsScroll=int.Parse(ds.Tables[0].Rows[0]["IsScroll"].ToString());
				}
				if(ds.Tables[0].Rows[0]["IsDel"].ToString()!="")
				{
					model.IsDel=int.Parse(ds.Tables[0].Rows[0]["IsDel"].ToString());
				}
				model.FileUrl=ds.Tables[0].Rows[0]["FileUrl"].ToString();
				model.Time=ds.Tables[0].Rows[0]["Time"].ToString();
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
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ID,UserID,TypeID,Title,Main,Click,IsScroll,IsDel,FileUrl,Time ");
			strSql.Append(" FROM AfficheData ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
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
			parameters[0].Value = "AfficheData";
			parameters[1].Value = "ID";
			parameters[2].Value = PageSize;
			parameters[3].Value = PageIndex;
			parameters[4].Value = 0;
			parameters[5].Value = 0;
			parameters[6].Value = strWhere;	
			return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
		}*/
        /// <summary>
        /// 设置前台滚动
        /// </summary>
        public void SetScroll(int ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("update AfficheData set IsScroll=1 ");
            strSql.Append(" where ID=@ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)};
            parameters[0].Value = ID;
            DbHelperSQL.ExecuteSql(DbHelperSQL.connectionString(), strSql.ToString(), parameters);
        }
        /// <summary>
        /// 取消前台滚动
        /// </summary>
        public void DelScroll(int ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("update AfficheData set IsScroll=0 ");
            strSql.Append(" where ID=@ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)};
            parameters[0].Value = ID;
            DbHelperSQL.ExecuteSql(DbHelperSQL.connectionString(), strSql.ToString(), parameters);
        }


        /// <summary>
        /// 得到分页页数
        /// </summary>
        /// <returns></returns>
        public int GetPageNumWithTypeID(string typeid)
        {
            double pageSize = 10;
            string selectcmm = "select count(*) from AfficheData  where typeid = '" + typeid + "' and IsDel =0 ";
          //  object oo = DbHelperSQL.ExecuteReader (selectcmm,.ExecuteScalar(ConnString.GetConString, CommandType.Text, selectcmm.ToString());
            object oo = DbHelperSQL.GetSingle(DbHelperSQL.connectionString(), selectcmm);
            int count = int.Parse(oo.ToString());
            double d = Math.Ceiling(count / pageSize);
            int i = int.Parse(d.ToString());
            return i;
        }
        /// <summary>
        /// 根据页数返回DataTable
        /// </summary>
        /// <param name="pageNum">页数</param>
        /// <param name="typeid">类别</param>
        /// <returns></returns>
        public DataTable GetPageWithNumWithTypeID(int pageNum, string typeid)
        {
            int pageSize = 10;
            string selectcm = "select count(*) from AfficheData  where typeid = '" + typeid + "'  and IsDel =0 ";
            object oo = DbHelperSQL.GetSingle(DbHelperSQL.connectionString(), selectcm);
            int allcount = int.Parse(oo.ToString());
            DataTable dt = new DataTable();
            if (allcount > 0)
            {
                string selectcmm = "select * from AfficheData as bt where ID in (select top " + pageSize + " ID from (select top " +
                    pageSize * pageNum + " ID  from AfficheData where typeid = '" + typeid + "'  and IsDel =0    order by  ID DESC) as tt order by ID ASC )  order by  ID desc";
                double ps = 10;
                double d = Math.Ceiling(allcount / ps);
                int PageCount = int.Parse(d.ToString());
                if (pageNum == PageCount)
                {
                    int lastcount = allcount - pageSize * (pageNum - 1);
                    selectcmm = "select *  from (select top " + lastcount + " * from AfficheData  where typeid = '" + typeid + "'  and IsDel =0    order by ID asc) as tt order by ID DESC";
                }
                dt = DbHelperSQL.Query(DbHelperSQL.connectionString(), selectcmm).Tables[0];
                //.ExecuteDataset(ConnString.GetConString, CommandType.Text, selectcmm).Tables[0];
                return dt;
            }
            return dt;
        }

        /// <summary>
        /// 获得数据列表前6条
        /// </summary>
        public DataSet GetTop6List(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 6 ID,UserID,TypeID,Title,Main,Click,FileUrl,Time ");
            strSql.Append(" FROM AfficheData     ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere + "  and IsDel =0 order by ID desc");
            }
            return DbHelperSQL.Query(DbHelperSQL.connectionString(), strSql.ToString());
        }



        /// <summary>
        /// 获得最新前６条滚动数据
        /// </summary>
        public DataSet GetTop6ScrollList()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 10 ID,UserID,TypeID,Title,Main,Click,FileUrl,Time ");
            strSql.Append(" FROM AfficheData  where TypeID=1 and IsDel =0 order by id desc     ");
            return DbHelperSQL.Query(DbHelperSQL.connectionString(), strSql.ToString());
        }



		#endregion  成员方法
	}
}

