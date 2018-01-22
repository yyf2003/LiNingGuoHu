using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using LN.DBUtility;//请先添加引用
namespace LN.DAL
{
	/// <summary>
	/// 数据访问类POPLaunch。
	/// </summary>
	public class POPLaunch
	{
		public POPLaunch()
		{}
		#region  成员方法

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
            return DbHelperSQL.GetMaxID(DbHelperSQL.connectionString(), "ID", "POPLaunch"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from POPLaunch");
			strSql.Append(" where ID=@ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)};
			parameters[0].Value = ID;

            return DbHelperSQL.Exists(DbHelperSQL.connectionString(), strSql.ToString(), parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(LN.Model.POPLaunch model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into POPLaunch(");
            strSql.Append("POPID,BeginDate,EndDate,POPTitle,OrganigerID,ProductLineDatas,InputDate,LaunchDesc,UploadFileUrl,steps,boolprice)");
			strSql.Append(" values (");
            strSql.Append("@POPID,@BeginDate,@EndDate,@POPTitle,@OrganigerID,@ProductLineDatas,Getdate(),@LaunchDesc,@UploadFileUrl,@steps,@boolprice)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@POPID", SqlDbType.VarChar,30),
					new SqlParameter("@BeginDate", SqlDbType.DateTime),
					new SqlParameter("@EndDate", SqlDbType.DateTime),
					new SqlParameter("@POPTitle", SqlDbType.VarChar,100),
					new SqlParameter("@OrganigerID", SqlDbType.Int,4),
					new SqlParameter("@ProductLineDatas", SqlDbType.VarChar,500),
					new SqlParameter("@LaunchDesc", SqlDbType.VarChar,500),
                    new SqlParameter("@UploadFileUrl", SqlDbType.VarChar,200),
                    new SqlParameter("@steps", SqlDbType.Int,4),
                    new SqlParameter("@boolprice", SqlDbType.Bit,4),
            };
			parameters[0].Value = model.POPID;
			parameters[1].Value = model.BeginDate;
			parameters[2].Value = model.EndDate;
			parameters[3].Value = model.POPTitle;
			parameters[4].Value = model.OrganigerID;
			parameters[5].Value = model.ProductLineDatas;
			parameters[6].Value = model.LaunchDesc;
            parameters[7].Value = model.UploadFileUrl;
            parameters[8].Value = model.steps;
            parameters[9].Value = model.BoolPrice;

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
		public void Update(LN.Model.POPLaunch model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update POPLaunch set ");
			strSql.Append("POPID=@POPID,");
			strSql.Append("BeginDate=@BeginDate,");
			strSql.Append("EndDate=@EndDate,");
			strSql.Append("POPTitle=@POPTitle,");
			strSql.Append("OrganigerID=@OrganigerID,");
			strSql.Append("ProductLineDatas=@ProductLineDatas,");
			strSql.Append("InputDate=@InputDate,");
			strSql.Append("LaunchDesc=@LaunchDesc");
			strSql.Append(" where ID=@ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4),
					new SqlParameter("@POPID", SqlDbType.VarChar,30),
					new SqlParameter("@BeginDate", SqlDbType.DateTime),
					new SqlParameter("@EndDate", SqlDbType.DateTime),
					new SqlParameter("@POPTitle", SqlDbType.VarChar,100),
					new SqlParameter("@OrganigerID", SqlDbType.NChar,10),
					new SqlParameter("@ProductLineDatas", SqlDbType.VarChar,500),
					new SqlParameter("@InputDate", SqlDbType.DateTime),
					new SqlParameter("@LaunchDesc", SqlDbType.VarChar,500)};
			parameters[0].Value = model.ID;
			parameters[1].Value = model.POPID;
			parameters[2].Value = model.BeginDate;
			parameters[3].Value = model.EndDate;
			parameters[4].Value = model.POPTitle;
			parameters[5].Value = model.OrganigerID;
			parameters[6].Value = model.ProductLineDatas;
			parameters[7].Value = model.InputDate;
			parameters[8].Value = model.LaunchDesc;

            DbHelperSQL.ExecuteSql(DbHelperSQL.connectionString(), strSql.ToString(), parameters);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(int ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete POPLaunch ");
			strSql.Append(" where ID=@ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)};
			parameters[0].Value = ID;

            DbHelperSQL.ExecuteSql(DbHelperSQL.connectionString(), strSql.ToString(), parameters);
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public LN.Model.POPLaunch GetModel(string popID)
		{
			
			StringBuilder strSql=new StringBuilder();
            strSql.Append("select  top 1 p.ID,p.POPID,p.BeginDate,p.EndDate,p.POPTitle,p.OrganigerID, p.ProductLineDatas,p.InputDate,p.LaunchDesc,p.UploadFileUrl,p.steps,(SELECT [Username] FROM [UserInfo] WHERE [UserID] = p.OrganigerID) AS OrganigerName from POPLaunch AS p ");
            strSql.Append(" where p.POPID=@POPID ");
			SqlParameter[] parameters = {
					new SqlParameter("@POPID", SqlDbType.VarChar,50)};
            parameters[0].Value = popID;

            LN.Model.POPLaunch model = null;
            SqlDataReader reader = DbHelperSQL.ExecuteReader(DbHelperSQL.connectionString(), strSql.ToString(), parameters);
            if (reader.Read())
            {
                model = new LN.Model.POPLaunch();
                if (!string.IsNullOrEmpty(reader.GetInt32(0).ToString()))
                    model.ID = reader.GetInt32(0);

                if (!string.IsNullOrEmpty(reader.GetString(1)))
                    model.POPID = reader.GetString(1);

                if (!string.IsNullOrEmpty(reader.GetDateTime(2).ToString()))
                    model.BeginDate = reader.GetDateTime(2);

                if (!string.IsNullOrEmpty(reader.GetDateTime(3).ToString()))
                    model.EndDate = reader.GetDateTime(3);

                if (!string.IsNullOrEmpty(reader.GetString(4)))
                    model.POPTitle = reader.GetString(4);

                if (!string.IsNullOrEmpty(reader.GetInt32(5).ToString()))
                    model.OrganigerID = reader.GetInt32(5);

                if (!string.IsNullOrEmpty(reader.GetString(6)))
                    model.ProductLineDatas = reader.GetString(6);

                if (!string.IsNullOrEmpty(reader.GetDateTime(7).ToString()))
                    model.InputDate = reader.GetDateTime(7);

                if (!string.IsNullOrEmpty(reader.GetString(8)))
                    model.LaunchDesc = reader.GetString(8);

                if (!string.IsNullOrEmpty(reader.GetString(9)))
                    model.UploadFileUrl = reader.GetString(9);

                if (!string.IsNullOrEmpty(reader.GetInt32(10).ToString()))
                    model.steps = reader.GetInt32(10);

                if (!string.IsNullOrEmpty(reader.GetString(11)))
                    model.OrganigerName = reader.GetString(11);
            }
            reader.Close();
            return model;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public IList<LN.Model.POPLaunch> GetList(string strWhere)
		{
            IList<LN.Model.POPLaunch> list = new List<LN.Model.POPLaunch>();
			StringBuilder strSql=new StringBuilder();
            strSql.Append("SELECT p.ID,p.POPID,p.BeginDate,p.EndDate,p.POPTitle,p.OrganigerID,p.ProductLineDatas,p.InputDate,p.LaunchDesc,p.UploadFileUrl,(SELECT [Username] FROM [UserInfo] WHERE [UserID] = p.OrganigerID) AS OrganigerName,steps ");
			strSql.Append(" FROM POPLaunch AS p ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" WHERE "+strWhere);
			}
            strSql.Append(" ORDER BY p.ID DESC");
            SqlDataReader reader = DbHelperSQL.ExecuteReader(DbHelperSQL.connectionString(), strSql.ToString());
            while (reader.Read())
            {
                LN.Model.POPLaunch model = new LN.Model.POPLaunch();
                if (!string.IsNullOrEmpty(reader.GetInt32(0).ToString()))
                    model.ID = reader.GetInt32(0);

                if (!string.IsNullOrEmpty(reader.GetString(1)))
                    model.POPID = reader.GetString(1);

                if (!string.IsNullOrEmpty(reader.GetDateTime(2).ToString()))
                    model.BeginDate = reader.GetDateTime(2);

                if (!string.IsNullOrEmpty(reader.GetDateTime(3).ToString()))
                    model.EndDate = reader.GetDateTime(3);

                if (!string.IsNullOrEmpty(reader.GetString(4)))
                    model.POPTitle = reader.GetString(4);

                if (!string.IsNullOrEmpty(reader.GetInt32(5).ToString()))
                    model.OrganigerID = reader.GetInt32(5);

                if (!string.IsNullOrEmpty(reader.GetString(6)))
                    model.ProductLineDatas = reader.GetString(6);

                if (!string.IsNullOrEmpty(reader.GetDateTime(7).ToString()))
                    model.InputDate = reader.GetDateTime(7);

                if (!string.IsNullOrEmpty(reader.GetString(8)))
                    model.LaunchDesc = reader.GetString(8);

                if (!string.IsNullOrEmpty(reader.GetString(9)))
                    model.UploadFileUrl = reader.GetString(9);

                if (!string.IsNullOrEmpty(reader.GetString(10)))
                    model.OrganigerName = reader.GetString(10);
                if (!string.IsNullOrEmpty(reader.GetInt32(11).ToString()))
                    model.steps = reader.GetInt32(11);
                list.Add(model);
            }
            reader.Close();
            return list;
		}
        /// <summary>
        /// 得到发起pop所涉及到的故事包
        /// </summary>
        /// <param name="popid"></param>
        /// <returns></returns>
        public string GetProline(string popid)
        {
            StringBuilder strsql = new StringBuilder();
            strsql.Append("select  ProductLineDatas from POPLaunch ");
                strsql.Append(" where POPID='"+popid+"'");
                object obj = DbHelperSQL.GetSingle(DbHelperSQL.connectionString(), strsql.ToString());
                if (obj != null)
                {
                    return obj.ToString();
                }
                else
                {
                    return "";
                }
        }
        /// <summary>
        /// 更新完成的步骤
        /// </summary>
        /// <param name="step"></param>
        /// <param name="POPID"></param>
        public void Updatesteps(int step,string POPID)
        {
            string strsql = "update POPLaunch set steps=" + step + " where POPID='" + POPID + "' ";
            DbHelperSQL.Query(DbHelperSQL.connectionString(), strsql);
        }
        /// <summary>
        /// 得到摸个POP完成的步骤
        /// </summary>
        /// <param name="POPID"></param>
        /// <returns></returns>
        public int getsetps(string POPID)
        {
            string strsql = "select steps from POPLaunch where POPID='" + POPID + "' ";
            object obj = DbHelperSQL.GetSingle(DbHelperSQL.connectionString(), strsql);
           if (obj != null)
           {
               return (int)obj;
           }
           else
           {
               return 0;
           }
        }
        /// <summary>
        /// 得到全部的ＰＯＰＩＤ
        /// </summary>
        /// <returns></returns>
        public List<string> GetPOPID()
        {
            string strsql = "select POPID from POPlaunch where steps=0 order by ID desc";

            SqlDataReader reader = DbHelperSQL.ExecuteReader(DbHelperSQL.connectionString(), strsql);
           List<string> POPIDlist = new List<string>();
           while (reader.Read())
           {
               POPIDlist.Add(reader.GetString(0));
           }
           reader.Close();
           return POPIDlist;
        }

        /// <summary>
        /// 得到全部的ＰＯＰＩＤ
        /// </summary>
        /// <returns></returns>
        public IList<LN.Model.POPLaunch> GetPOPIDList()
        {
            IList<LN.Model.POPLaunch> list = new List<LN.Model.POPLaunch>();
            string strSql = "select POPID,POPTitle from POPlaunch where steps=0 order by ID desc";

            LN.Model.POPLaunch model = null;
            SqlDataReader reader = DbHelperSQL.ExecuteReader(DbHelperSQL.connectionString(), strSql.ToString());
            while (reader.Read())
            {
                model = new LN.Model.POPLaunch();

                if (!string.IsNullOrEmpty(reader.GetString(0)))
                    model.POPID = reader.GetString(0);

                if (!string.IsNullOrEmpty(reader.GetString(1)))
                    model.POPTitle = reader.GetString(1);

                list.Add(model);
            }
            reader.Close();
            return list;
        }

        /// <summary>
        /// 得到最新的ＰＯＰＩＤ
        /// </summary>
        /// <returns></returns>
        public DataTable GetNewPOPID()
        {
            DataTable dt = null;
            string strsql = "select POPID,POPTitle from POPlaunch where BeginDate<=getdate() and EndDate>=getdate() and steps=0 order by ID desc";

            DataSet ds = DbHelperSQL.Query(DbHelperSQL.connectionString(), strsql);

            if (ds != null)
                dt = ds.Tables[0];

            return dt;
        }

        /// <summary>
        /// pop 分析 按照店铺
        /// </summary>
        /// <param name="ht"></param>
        /// <returns></returns>
        public DataSet POPAnalysis(Hashtable ht,string Procedurename,out int totalnum)
        {
            SqlParameter[] paras ={ 
                new SqlParameter("@POPID",SqlDbType.VarChar,50),
                new SqlParameter("@PosCode",SqlDbType.VarChar,10),
                new SqlParameter("@Shopname",SqlDbType.VarChar,200),
                new SqlParameter("@SupplierID",SqlDbType.Int,4),
                new SqlParameter("@DealerID",SqlDbType.VarChar,50),
                new SqlParameter("@areaID",SqlDbType.Int,4),
                new SqlParameter("@ProvinceID",SqlDbType.Int,4),
                new SqlParameter("@CityID",SqlDbType.Int,4),
                new SqlParameter("@OrderField",SqlDbType.VarChar,50),
                new SqlParameter("@pageSize",SqlDbType.Int,4),
                new SqlParameter("@pageIndex",SqlDbType.Int,4),
                new SqlParameter("@TotalRecord",SqlDbType.Int,4),
                new SqlParameter("@year",SqlDbType.Int,4),
                new SqlParameter("@FXID",SqlDbType.VarChar,20),
                new SqlParameter ("@department",SqlDbType.VarChar,10)

               // new SqlParameter("@Prolines",SqlDbType.VarChar,50)
            };

            paras[0].Value = ht["POPID"].ToString();
            paras[1].Value = ht["PosCode"].ToString();
            paras[2].Value = ht["Shopname"].ToString();
            paras[3].Value =int.Parse(ht["SupplierID"].ToString());
            paras[4].Value = ht["DealerID"].ToString();
            paras[5].Value = int.Parse(ht["areaID"].ToString());
            paras[6].Value = int.Parse(ht["ProvinceID"].ToString());
            paras[7].Value = int.Parse(ht["CityID"].ToString());
            paras[8].Value = ht["OrderField"].ToString();
            paras[9].Value = int.Parse(ht["pageSize"].ToString());
            paras[10].Value = int.Parse(ht["pageIndex"].ToString());
            paras[11].Direction =ParameterDirection.Output;
            paras[12].Value = int.Parse(ht["year"].ToString());
            paras[13].Value = ht["FXID"].ToString();
            paras[14].Value = ht["department"].ToString();

           // paras[12].Value = ht["prolines"].ToString();
            DataSet ds = DbHelperSQL.RunProcedure(DbHelperSQL.connectionString(), Procedurename, paras, "dt");
            totalnum = (int)paras[11].Value;

            return ds;
        }
        /// <summary>
        /// 根据产品大类与产品系列进行分析
        /// </summary>
        /// <param name="ht"></param>
        /// <returns></returns>
        public DataSet POPAnalysisByPro(Hashtable ht)
        {
            SqlParameter[] paras ={ 
                new SqlParameter("@POPID",SqlDbType.VarChar,50),
                new SqlParameter("@PosCode",SqlDbType.VarChar,10),
                new SqlParameter("@Shopname",SqlDbType.VarChar,200),
                new SqlParameter("@SupplierID",SqlDbType.Int,4),
                new SqlParameter("@DealerID",SqlDbType.VarChar,50),
                new SqlParameter("@areaID",SqlDbType.Int,4),
                new SqlParameter("@ProvinceID",SqlDbType.Int,4),
                new SqlParameter("@CityID",SqlDbType.Int,4),
                new SqlParameter("@OrderField",SqlDbType.VarChar,50),
                new SqlParameter("@pageSize",SqlDbType.Int,4),
                new SqlParameter("@pageIndex",SqlDbType.Int,4),
                new SqlParameter("@year",SqlDbType.Int,4),
                new SqlParameter("@FXID",SqlDbType.VarChar,20),
                new SqlParameter("@Protype",SqlDbType.VarChar,50),
                new SqlParameter("@Prolines",SqlDbType.VarChar,50),
                new SqlParameter ("@department",SqlDbType.VarChar,10)
            };

            paras[0].Value = ht["POPID"].ToString();
            paras[1].Value = ht["PosCode"].ToString();
            paras[2].Value = ht["Shopname"].ToString();
            paras[3].Value = int.Parse(ht["SupplierID"].ToString());
            paras[4].Value = ht["DealerID"].ToString();
            paras[5].Value = int.Parse(ht["areaID"].ToString());
            paras[6].Value = int.Parse(ht["ProvinceID"].ToString());
            paras[7].Value = int.Parse(ht["CityID"].ToString());
            paras[8].Value = ht["OrderField"].ToString();
            paras[9].Value = int.Parse(ht["pageSize"].ToString());
            paras[10].Value = int.Parse(ht["pageIndex"].ToString());
           
            paras[11].Value = int.Parse(ht["year"].ToString());
            paras[12].Value = ht["FXID"].ToString();
            paras[13].Value = ht["protype"].ToString();
            paras[14].Value = ht["proline"].ToString();
            paras[15].Value = ht["department"].ToString();
            // paras[12].Value = ht["prolines"].ToString();
            DataSet ds = DbHelperSQL.RunProcedure(DbHelperSQL.connectionString(), "POPpriceAnalysisByProduct", paras, "dt");

            return ds;
        }
        /// <summary>
        /// 材料和故事包分析 得到每个店铺所产生的POP
        /// </summary>
        /// <param name="ht"></param>
        /// <param name="totalnum"></param>
        /// <returns></returns>
        public DataTable EveryShopPOP(Hashtable ht, out int totalnum)
        {
            SqlParameter[] paras ={ 
                new SqlParameter("@POPID",SqlDbType.VarChar,50),
                new SqlParameter("@PosCode",SqlDbType.VarChar,10),
                new SqlParameter("@Shopname",SqlDbType.VarChar,200),
                new SqlParameter("@SupplierID",SqlDbType.Int,4),
                new SqlParameter("@DealerID",SqlDbType.VarChar,50),
                new SqlParameter("@areaID",SqlDbType.Int,4),
                new SqlParameter("@ProvinceID",SqlDbType.Int,4),
                new SqlParameter("@CityID",SqlDbType.Int,4),
                new SqlParameter("@OrderField",SqlDbType.VarChar,50),
                new SqlParameter("@pageSize",SqlDbType.Int,4),
                new SqlParameter("@pageIndex",SqlDbType.Int,4),
                new SqlParameter("@TotalRecord",SqlDbType.Int,4),
                new SqlParameter("@Prolines",SqlDbType.VarChar,50),
                new SqlParameter("@cailiao",SqlDbType.VarChar,100),
                new SqlParameter("@year",SqlDbType.VarChar,4),
                new SqlParameter("@FXID",SqlDbType.VarChar,20)
            };

            paras[0].Value = ht["POPID"].ToString();
            paras[1].Value = ht["PosCode"].ToString();
            paras[2].Value = ht["Shopname"].ToString();
            paras[3].Value = int.Parse(ht["SupplierID"].ToString());
            paras[4].Value = ht["DealerID"].ToString();
            paras[5].Value = int.Parse(ht["areaID"].ToString());
            paras[6].Value = int.Parse(ht["ProvinceID"].ToString());
            paras[7].Value = int.Parse(ht["CityID"].ToString());
            paras[8].Value = ht["OrderField"].ToString();
            paras[9].Value = int.Parse(ht["pageSize"].ToString());
            paras[10].Value = int.Parse(ht["pageIndex"].ToString());
            paras[11].Direction = ParameterDirection.Output;
            paras[12].Value = ht["prolines"].ToString();
            paras[13].Value = ht["cailiao"].ToString();
            paras[14].Value = ht["year"].ToString();
            paras[15].Value=ht["fxid"].ToString();
            DataSet ds = DbHelperSQL.RunProcedure(DbHelperSQL.connectionString(), "AnalysisEveryShopCountPOP", paras, "dt");
            totalnum = (int)paras[11].Value;

            return ds.Tables[0];
        }
        /// <summary>
        /// 查看上一期POP是否结束
        /// </summary>
        /// <returns></returns>
        public string GetLastEndDate()
        {
            string sqlstr = "select top 1 EndDate from poplaunch  where Enddate>getdate() and steps=0 order by ID desc";
            object obj = DbHelperSQL.GetSingle(DbHelperSQL.connectionString(), sqlstr);
           if (obj == null)
           {
               return "";
           }
           else
           {
               return obj.ToString();
           }

        }

        /// <summary>
        /// 得到最新发起的POP
        /// </summary>
        public LN.Model.POPLaunch GetNewestModel()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 p.ID,p.POPID,p.BeginDate,p.EndDate,p.POPTitle,p.OrganigerID, p.ProductLineDatas,p.InputDate,p.LaunchDesc,p.UploadFileUrl,p.steps,(SELECT [Username] FROM [UserInfo] WHERE [UserID] = p.OrganigerID) AS OrganigerName from POPLaunch AS p where p.steps=0");
            strSql.Append(" ORDER BY ID DESC ");

            LN.Model.POPLaunch model = null;
            SqlDataReader reader = DbHelperSQL.ExecuteReader(DbHelperSQL.connectionString(), strSql.ToString());
            if (reader.Read())
            {
                model = new LN.Model.POPLaunch();
                if (!string.IsNullOrEmpty(reader.GetInt32(0).ToString()))
                    model.ID = reader.GetInt32(0);

                if (!string.IsNullOrEmpty(reader.GetString(1)))
                    model.POPID = reader.GetString(1);

                if (!string.IsNullOrEmpty(reader.GetDateTime(2).ToString()))
                    model.BeginDate = reader.GetDateTime(2);

                if (!string.IsNullOrEmpty(reader.GetDateTime(3).ToString()))
                    model.EndDate = reader.GetDateTime(3);

                if (!string.IsNullOrEmpty(reader.GetString(4)))
                    model.POPTitle = reader.GetString(4);

                if (!string.IsNullOrEmpty(reader.GetInt32(5).ToString()))
                    model.OrganigerID = reader.GetInt32(5);

                if (!string.IsNullOrEmpty(reader.GetString(6)))
                    model.ProductLineDatas = reader.GetString(6);

                if (!string.IsNullOrEmpty(reader.GetDateTime(7).ToString()))
                    model.InputDate = reader.GetDateTime(7);

                if (!string.IsNullOrEmpty(reader.GetString(8)))
                    model.LaunchDesc = reader.GetString(8);

                if (!string.IsNullOrEmpty(reader.GetString(9)))
                    model.UploadFileUrl = reader.GetString(9);

                if (!string.IsNullOrEmpty(reader.GetInt32(10).ToString()))
                    model.steps = reader.GetInt32(10);

                if (!string.IsNullOrEmpty(reader.GetString(11)))
                    model.OrganigerName = reader.GetString(11);
            }
            reader.Close();
            return model;
        }
        /// <summary>
        /// 得到每期发起POP的数量和总面积
        /// </summary>
        /// <param name="POPID">pop发起ID</param>
        /// <param name="sid">供应商ID</param>
        /// <returns></returns>
        public DataTable GetTotalPOPList(string POPID,string sid,string prolist)
        {
            SqlParameter[] paras ={ 
            
                new SqlParameter("@POPID",SqlDbType.VarChar,50),
                new SqlParameter("@prolist",SqlDbType.VarChar,2000),
                new SqlParameter("@SupplierID",SqlDbType.Int,4)
            };
            paras[0].Value = POPID;
            paras[1].Value = prolist;
            paras[2].Value = int.Parse(sid);

            DataSet ds = DbHelperSQL.RunProcedure(DbHelperSQL.connectionString(), "GetTotalPOPList", paras, "a");
            return ds.Tables[0];
        }
        /// <summary>
        /// 得到最新的POPID
        /// </summary>
        /// <returns></returns>
        public string GetLastPOPID()
        {
            string strsql = "select top 1 POPID from POPLaunch   where steps=0  order by ID desc";

            object obj = DbHelperSQL.GetSingle(DbHelperSQL.connectionString(), strsql);

            string returnstr = "";
            if (obj != null)
            {
                returnstr = obj.ToString();
            }
            return returnstr;
        }
        /// <summary>
        /// 得到每次发起pop每个店铺的pop数量面积
        /// </summary>
        /// <param name="POPID"></param>
        /// <param name="sid"></param>
        /// <param name="prolist"></param>
        /// <returns></returns>
        public DataTable GetPOPlaunchshopPOPlist(string POPID, string sid, string prolist,int pageindex,int pagesize,out int TotalNumber)
        {
            SqlParameter[] paras ={ 
            
                new SqlParameter("@POPID",SqlDbType.VarChar,50),
                new SqlParameter("@prolist",SqlDbType.VarChar,2000),
                new SqlParameter("@SupplierID",SqlDbType.Int,4),
                new SqlParameter("@OrderField",SqlDbType.VarChar,100),
                new SqlParameter("@pageSize",SqlDbType.Int,4),
                new SqlParameter("@pageIndex",SqlDbType.Int,4),
                new SqlParameter("@TotalRecord",SqlDbType.Int,4),
            };
            paras[0].Value = POPID;
            paras[1].Value = prolist;
            paras[2].Value = int.Parse(sid);
            paras[3].Value = "totalnum desc";
            paras[4].Value = pagesize;
            paras[5].Value = pageindex;
            paras[6].Direction = ParameterDirection.Output;
            DataSet ds = DbHelperSQL.RunProcedure(DbHelperSQL.connectionString(), "GetEveryShopPOPList", paras, "a");
            TotalNumber = (int)paras[6].Value;
            return ds.Tables[0];
        }
        /// <summary>
        /// 如果需要报价 则进行报价 
        /// </summary>
        /// <param name="POPID"></param>
        /// <param name="userID"></param>
        public void SetPOPprice(string POPID,string userID)
        {
            //先得到相应的供应商
            //string sqlsupplier = "select supplierID,SupplierName from dbo.SupplierInfo where supplierState=1";

            //SqlDataReader reader = DbHelperSQL.ExecuteReader(sqlsupplier);
            List<string> sqllist = new List<string>();
            //while (reader.Read())
            //{
                string strsql = "insert into popprice select  '" + POPID + "',supplierid,POPMaterial,POPprice,1,'','" + userID + "','" + DateTime.Now.ToString() + "','" + userID + "' from POPMaterialPrice";
                string setupsql = "insert into supplier_POPIDsetupPrice select '" + POPID + "',supplierid,setupMoney from suppliersetupprice";
            sqllist.Add(strsql);
            sqllist.Add(setupsql);
            //}
            //reader.Close();

            DbHelperSQL.ExecuteSqlTran(DbHelperSQL.connectionString(), sqllist);
        }

        /// <summary>
        /// 删除为发起完成的POP
        /// </summary>
        /// <param name="popid"></param
        public void delpoplaunch(string popid)
        {
            List<string> strlist = new List<string>();

            strlist.Add("delete POPLaunch where POPID='"+popid+"'");
            strlist.Add("delete POPImageData  where POPID='"+popid+"'");
            strlist.Add("delete POPChangeSet where POPID='" + popid + "'");
            strlist.Add("delete POPPrice where POPID='" + popid + "'");

            DbHelperSQL.ExecuteSqlTran(DbHelperSQL.connectionString(), strlist);
        }
		
        #endregion  成员方法
	}
}

