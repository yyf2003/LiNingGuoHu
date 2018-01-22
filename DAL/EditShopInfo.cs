using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using System.Collections.Generic;
using LN.DBUtility;//请先添加引用
namespace LN.DAL
{
	/// <summary>
	/// 数据访问类EditShopInfo。
	/// </summary>
	public class EditShopInfo
	{
		public EditShopInfo()
		{}
		#region  成员方法

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from EditShopInfo");
			strSql.Append(" where ID=@ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)};
			parameters[0].Value = ID;

            return DbHelperSQL.Exists(DbHelperSQL.connectionString(), strSql.ToString(), parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(LN.Model.EditShopInfo model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into EditShopInfo(");
            strSql.Append("ShopID,PosID,Shopname,ShopAddress,ShopOpenDate,ShopCloseDate,CloseUserID,ProvinceID,CityID,TownID,ShopLevelID,SaleTypeID,LinkMan,LinkPhone,ShopMaster,ShopMasterPhone,Email,PostAddress,PostCode,FaxNumber,Boolinstall,DealerID,FXID,CustomerGroupID,CustomerGroupName,ShopState,ExamState,VMMaster,VMMasterPhone,DSRMaster,DSRMasterPhone,ShopArea,ShopVI,ShopType,ShopPhone,areaid,shopsamplename,shopownership,customercard)");
			strSql.Append(" values (");
            strSql.Append("@ShopID,@PosID,@Shopname,@ShopAddress,@ShopOpenDate,@ShopCloseDate,@CloseUserID,@ProvinceID,@CityID,@TownID,@ShopLevelID,@SaleTypeID,@LinkMan,@LinkPhone,@ShopMaster,@ShopMasterPhone,@Email,@PostAddress,@PostCode,@FaxNumber,@Boolinstall,@DealerID,@FXID,@CustomerGroupID,@CustomerGroupName,@ShopState,@ExamState,@VMMaster,@VMMasterPhone,@DSRMaster,@DSRMasterPhone,@ShopArea,@ShopVI,@ShopType,@ShopPhone,@areaid,@shopsamplename,@shopownership,@customercard)");
			strSql.Append(";select @@IDENTITY");

			SqlParameter[] parameters = {
					new SqlParameter("@ShopID", SqlDbType.Int,4),
					new SqlParameter("@PosID", SqlDbType.VarChar,50),
					new SqlParameter("@Shopname", SqlDbType.NVarChar,300),
					new SqlParameter("@ShopAddress", SqlDbType.NVarChar,300),
					new SqlParameter("@ShopOpenDate", SqlDbType.VarChar,50),
					new SqlParameter("@ShopCloseDate", SqlDbType.VarChar,50),
					new SqlParameter("@CloseUserID", SqlDbType.Int,4),
					new SqlParameter("@ProvinceID", SqlDbType.Int,4),
					new SqlParameter("@CityID", SqlDbType.Int,4),
					new SqlParameter("@TownID", SqlDbType.Int,4),
					new SqlParameter("@ShopLevelID", SqlDbType.Int,4),
					new SqlParameter("@SaleTypeID", SqlDbType.Int,4),
					new SqlParameter("@LinkMan", SqlDbType.VarChar,20),
					new SqlParameter("@LinkPhone", SqlDbType.VarChar,80),
					new SqlParameter("@ShopMaster", SqlDbType.VarChar,50),
					new SqlParameter("@ShopMasterPhone", SqlDbType.VarChar,50),
					new SqlParameter("@Email", SqlDbType.VarChar,50),
					new SqlParameter("@PostAddress", SqlDbType.VarChar,500),
					new SqlParameter("@PostCode", SqlDbType.VarChar,50),
					new SqlParameter("@FaxNumber", SqlDbType.VarChar,50),
					new SqlParameter("@Boolinstall", SqlDbType.Int,4),
					new SqlParameter("@DealerID", SqlDbType.VarChar,50),
					new SqlParameter("@FXID", SqlDbType.VarChar,50),
					new SqlParameter("@CustomerGroupID", SqlDbType.VarChar,50),
					new SqlParameter("@CustomerGroupName", SqlDbType.VarChar,300),
					new SqlParameter("@ShopState", SqlDbType.Int,4),
					new SqlParameter("@ExamState", SqlDbType.Int,4),
					new SqlParameter("@VMMaster", SqlDbType.VarChar,50),
					new SqlParameter("@VMMasterPhone", SqlDbType.VarChar,50),
					new SqlParameter("@DSRMaster", SqlDbType.VarChar,50),
					new SqlParameter("@DSRMasterPhone", SqlDbType.VarChar,50),
					new SqlParameter("@ShopArea", SqlDbType.Float,8),
					new SqlParameter("@ShopVI", SqlDbType.Int,4),
					new SqlParameter("@ShopType", SqlDbType.Int,4),
					new SqlParameter("@ShopPhone", SqlDbType.VarChar,50),
					new SqlParameter("@areaid", SqlDbType.Int,4),
                    new SqlParameter("@Shopsamplename",SqlDbType.NVarChar,50),
                    new SqlParameter("@ShopOwnerShip",SqlDbType.NVarChar,50),
                    new SqlParameter("@CustomerCard",SqlDbType.NVarChar,50)};
			parameters[0].Value = model.ShopID;
			parameters[1].Value = model.PosID;
			parameters[2].Value = model.Shopname;
			parameters[3].Value = model.ShopAddress;
			parameters[4].Value = model.ShopOpenDate;
			parameters[5].Value = model.ShopCloseDate;
			parameters[6].Value = model.CloseUserID;
			parameters[7].Value = model.ProvinceID;
			parameters[8].Value = model.CityID;
			parameters[9].Value = model.TownID;
			parameters[10].Value = model.ShopLevelID;
			parameters[11].Value = model.SaleTypeID;
			parameters[12].Value = model.LinkMan;
			parameters[13].Value = model.LinkPhone;
			parameters[14].Value = model.ShopMaster;
			parameters[15].Value = model.ShopMasterPhone;
			parameters[16].Value = model.Email;
			parameters[17].Value = model.PostAddress;
			parameters[18].Value = model.PostCode;
			parameters[19].Value = model.FaxNumber;
			parameters[20].Value = model.Boolinstall;
			parameters[21].Value = model.DealerID;
			parameters[22].Value = model.FXID;
			parameters[23].Value = model.CustomerGroupID;
			parameters[24].Value = model.CustomerGroupName;
			parameters[25].Value = model.ShopState;
			parameters[26].Value = model.ExamState;
			parameters[27].Value = model.VMMaster;
			parameters[28].Value = model.VMMasterPhone;
			parameters[29].Value = model.DSRMaster;
			parameters[30].Value = model.DSRMasterPhone;
			parameters[31].Value = model.ShopArea;
			parameters[32].Value = model.ShopVI;
			parameters[33].Value = model.ShopType;
			parameters[34].Value = model.ShopPhone;
			parameters[35].Value = model.areaid;
            parameters[36].Value = model.ShopSampleName;
            parameters[37].Value = model.ShopOwnerShip;
            parameters[38].Value = model.CustomerCard;
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
		public void Update(LN.Model.EditShopInfo model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update EditShopInfo set ");
			strSql.Append("ShopID=@ShopID,");
			strSql.Append("PosID=@PosID,");
			strSql.Append("Shopname=@Shopname,");
			strSql.Append("ShopAddress=@ShopAddress,");
			strSql.Append("ShopOpenDate=@ShopOpenDate,");
			strSql.Append("ShopCloseDate=@ShopCloseDate,");
			strSql.Append("CloseUserID=@CloseUserID,");
			strSql.Append("ProvinceID=@ProvinceID,");
			strSql.Append("CityID=@CityID,");
			strSql.Append("TownID=@TownID,");
			strSql.Append("ShopLevelID=@ShopLevelID,");
			strSql.Append("SaleTypeID=@SaleTypeID,");
			strSql.Append("LinkMan=@LinkMan,");
			strSql.Append("LinkPhone=@LinkPhone,");
			strSql.Append("ShopMaster=@ShopMaster,");
			strSql.Append("ShopMasterPhone=@ShopMasterPhone,");
			strSql.Append("Email=@Email,");
			strSql.Append("PostAddress=@PostAddress,");
			strSql.Append("PostCode=@PostCode,");
			strSql.Append("FaxNumber=@FaxNumber,");
			strSql.Append("Boolinstall=@Boolinstall,");
			strSql.Append("DealerID=@DealerID,");
			strSql.Append("FXID=@FXID,");
			strSql.Append("CustomerGroupID=@CustomerGroupID,");
			strSql.Append("CustomerGroupName=@CustomerGroupName,");
			strSql.Append("ShopState=@ShopState,");
			strSql.Append("ExamState=@ExamState,");
			strSql.Append("VMMaster=@VMMaster,");
			strSql.Append("VMMasterPhone=@VMMasterPhone,");
			strSql.Append("DSRMaster=@DSRMaster,");
			strSql.Append("DSRMasterPhone=@DSRMasterPhone,");
			strSql.Append("ShopArea=@ShopArea,");
			strSql.Append("ShopVI=@ShopVI,");
			strSql.Append("ShopType=@ShopType,");
			strSql.Append("ShopPhone=@ShopPhone,");
			strSql.Append("areaid=@areaid");
			strSql.Append(" where ID=@ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4),
					new SqlParameter("@ShopID", SqlDbType.Int,4),
					new SqlParameter("@PosID", SqlDbType.VarChar,50),
					new SqlParameter("@Shopname", SqlDbType.NVarChar,300),
					new SqlParameter("@ShopAddress", SqlDbType.NVarChar,300),
					new SqlParameter("@ShopOpenDate", SqlDbType.VarChar,50),
					new SqlParameter("@ShopCloseDate", SqlDbType.VarChar,50),
					new SqlParameter("@CloseUserID", SqlDbType.Int,4),
					new SqlParameter("@ProvinceID", SqlDbType.Int,4),
					new SqlParameter("@CityID", SqlDbType.Int,4),
					new SqlParameter("@TownID", SqlDbType.Int,4),
					new SqlParameter("@ShopLevelID", SqlDbType.Int,4),
					new SqlParameter("@SaleTypeID", SqlDbType.Int,4),
					new SqlParameter("@LinkMan", SqlDbType.VarChar,20),
					new SqlParameter("@LinkPhone", SqlDbType.VarChar,80),
					new SqlParameter("@ShopMaster", SqlDbType.VarChar,50),
					new SqlParameter("@ShopMasterPhone", SqlDbType.VarChar,50),
					new SqlParameter("@Email", SqlDbType.VarChar,50),
					new SqlParameter("@PostAddress", SqlDbType.VarChar,500),
					new SqlParameter("@PostCode", SqlDbType.VarChar,50),
					new SqlParameter("@FaxNumber", SqlDbType.VarChar,50),
					new SqlParameter("@Boolinstall", SqlDbType.Int,4),
					new SqlParameter("@DealerID", SqlDbType.VarChar,50),
					new SqlParameter("@FXID", SqlDbType.VarChar,50),
					new SqlParameter("@CustomerGroupID", SqlDbType.VarChar,50),
					new SqlParameter("@CustomerGroupName", SqlDbType.VarChar,300),
					new SqlParameter("@ShopState", SqlDbType.Int,4),
					new SqlParameter("@ExamState", SqlDbType.Int,4),
					new SqlParameter("@VMMaster", SqlDbType.VarChar,50),
					new SqlParameter("@VMMasterPhone", SqlDbType.VarChar,50),
					new SqlParameter("@DSRMaster", SqlDbType.VarChar,50),
					new SqlParameter("@DSRMasterPhone", SqlDbType.VarChar,50),
					new SqlParameter("@ShopArea", SqlDbType.Float,8),
					new SqlParameter("@ShopVI", SqlDbType.Int,4),
					new SqlParameter("@ShopType", SqlDbType.Int,4),
					new SqlParameter("@ShopPhone", SqlDbType.VarChar,50),
					new SqlParameter("@areaid", SqlDbType.Int,4)};
			parameters[0].Value = model.ID;
			parameters[1].Value = model.ShopID;
			parameters[2].Value = model.PosID;
			parameters[3].Value = model.Shopname;
			parameters[4].Value = model.ShopAddress;
			parameters[5].Value = model.ShopOpenDate;
			parameters[6].Value = model.ShopCloseDate;
			parameters[7].Value = model.CloseUserID;
			parameters[8].Value = model.ProvinceID;
			parameters[9].Value = model.CityID;
			parameters[10].Value = model.TownID;
			parameters[11].Value = model.ShopLevelID;
			parameters[12].Value = model.SaleTypeID;
			parameters[13].Value = model.LinkMan;
			parameters[14].Value = model.LinkPhone;
			parameters[15].Value = model.ShopMaster;
			parameters[16].Value = model.ShopMasterPhone;
			parameters[17].Value = model.Email;
			parameters[18].Value = model.PostAddress;
			parameters[19].Value = model.PostCode;
			parameters[20].Value = model.FaxNumber;
			parameters[21].Value = model.Boolinstall;
			parameters[22].Value = model.DealerID;
			parameters[23].Value = model.FXID;
			parameters[24].Value = model.CustomerGroupID;
			parameters[25].Value = model.CustomerGroupName;
			parameters[26].Value = model.ShopState;
			parameters[27].Value = model.ExamState;
			parameters[28].Value = model.VMMaster;
			parameters[29].Value = model.VMMasterPhone;
			parameters[30].Value = model.DSRMaster;
			parameters[31].Value = model.DSRMasterPhone;
			parameters[32].Value = model.ShopArea;
			parameters[33].Value = model.ShopVI;
			parameters[34].Value = model.ShopType;
			parameters[35].Value = model.ShopPhone;
			parameters[36].Value = model.areaid;

            DbHelperSQL.ExecuteSql(DbHelperSQL.connectionString(), strSql.ToString(), parameters);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(int ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from EditShopInfo ");
			strSql.Append(" where ID=@ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)};
			parameters[0].Value = ID;

            DbHelperSQL.ExecuteSql(DbHelperSQL.connectionString(), strSql.ToString(), parameters);
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public LN.Model.EditShopInfo GetModel(int ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 ID,ShopID,PosID,Shopname,ShopAddress,ShopOpenDate,ShopCloseDate,CloseUserID,ProvinceID,CityID,TownID,ShopLevelID,SaleTypeID,LinkMan,LinkPhone,ShopMaster,ShopMasterPhone,Email,PostAddress,PostCode,FaxNumber,Boolinstall,DealerID,FXID,CustomerGroupID,CustomerGroupName,ShopState,ExamState,VMMaster,VMMasterPhone,DSRMaster,DSRMasterPhone,ShopArea,ShopVI,ShopType,ShopPhone,areaid from EditShopInfo ");
			strSql.Append(" where ID=@ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)};
			parameters[0].Value = ID;

			LN.Model.EditShopInfo model=new LN.Model.EditShopInfo();
            DataSet ds = DbHelperSQL.Query(DbHelperSQL.connectionString(), strSql.ToString(), parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["ID"].ToString()!="")
				{
					model.ID=int.Parse(ds.Tables[0].Rows[0]["ID"].ToString());
				}
				if(ds.Tables[0].Rows[0]["ShopID"].ToString()!="")
				{
					model.ShopID=int.Parse(ds.Tables[0].Rows[0]["ShopID"].ToString());
				}
				model.PosID=ds.Tables[0].Rows[0]["PosID"].ToString();
				model.Shopname=ds.Tables[0].Rows[0]["Shopname"].ToString();
				model.ShopAddress=ds.Tables[0].Rows[0]["ShopAddress"].ToString();
				model.ShopOpenDate=ds.Tables[0].Rows[0]["ShopOpenDate"].ToString();
				model.ShopCloseDate=ds.Tables[0].Rows[0]["ShopCloseDate"].ToString();
				if(ds.Tables[0].Rows[0]["CloseUserID"].ToString()!="")
				{
					model.CloseUserID=int.Parse(ds.Tables[0].Rows[0]["CloseUserID"].ToString());
				}
				if(ds.Tables[0].Rows[0]["ProvinceID"].ToString()!="")
				{
					model.ProvinceID=int.Parse(ds.Tables[0].Rows[0]["ProvinceID"].ToString());
				}
				if(ds.Tables[0].Rows[0]["CityID"].ToString()!="")
				{
					model.CityID=int.Parse(ds.Tables[0].Rows[0]["CityID"].ToString());
				}
				if(ds.Tables[0].Rows[0]["TownID"].ToString()!="")
				{
					model.TownID=int.Parse(ds.Tables[0].Rows[0]["TownID"].ToString());
				}
				if(ds.Tables[0].Rows[0]["ShopLevelID"].ToString()!="")
				{
					model.ShopLevelID=int.Parse(ds.Tables[0].Rows[0]["ShopLevelID"].ToString());
				}
				if(ds.Tables[0].Rows[0]["SaleTypeID"].ToString()!="")
				{
					model.SaleTypeID=int.Parse(ds.Tables[0].Rows[0]["SaleTypeID"].ToString());
				}
				model.LinkMan=ds.Tables[0].Rows[0]["LinkMan"].ToString();
				model.LinkPhone=ds.Tables[0].Rows[0]["LinkPhone"].ToString();
				model.ShopMaster=ds.Tables[0].Rows[0]["ShopMaster"].ToString();
				model.ShopMasterPhone=ds.Tables[0].Rows[0]["ShopMasterPhone"].ToString();
				model.Email=ds.Tables[0].Rows[0]["Email"].ToString();
				model.PostAddress=ds.Tables[0].Rows[0]["PostAddress"].ToString();
				model.PostCode=ds.Tables[0].Rows[0]["PostCode"].ToString();
				model.FaxNumber=ds.Tables[0].Rows[0]["FaxNumber"].ToString();
				if(ds.Tables[0].Rows[0]["Boolinstall"].ToString()!="")
				{
					model.Boolinstall=int.Parse(ds.Tables[0].Rows[0]["Boolinstall"].ToString());
				}
				model.DealerID=ds.Tables[0].Rows[0]["DealerID"].ToString();
				model.FXID=ds.Tables[0].Rows[0]["FXID"].ToString();
				model.CustomerGroupID=ds.Tables[0].Rows[0]["CustomerGroupID"].ToString();
				model.CustomerGroupName=ds.Tables[0].Rows[0]["CustomerGroupName"].ToString();
				if(ds.Tables[0].Rows[0]["ShopState"].ToString()!="")
				{
					model.ShopState=int.Parse(ds.Tables[0].Rows[0]["ShopState"].ToString());
				}
				if(ds.Tables[0].Rows[0]["ExamState"].ToString()!="")
				{
					model.ExamState=int.Parse(ds.Tables[0].Rows[0]["ExamState"].ToString());
				}
				model.VMMaster=ds.Tables[0].Rows[0]["VMMaster"].ToString();
				model.VMMasterPhone=ds.Tables[0].Rows[0]["VMMasterPhone"].ToString();
				model.DSRMaster=ds.Tables[0].Rows[0]["DSRMaster"].ToString();
				model.DSRMasterPhone=ds.Tables[0].Rows[0]["DSRMasterPhone"].ToString();
				if(ds.Tables[0].Rows[0]["ShopArea"].ToString()!="")
				{
					model.ShopArea=decimal.Parse(ds.Tables[0].Rows[0]["ShopArea"].ToString());
				}
				if(ds.Tables[0].Rows[0]["ShopVI"].ToString()!="")
				{
					model.ShopVI=int.Parse(ds.Tables[0].Rows[0]["ShopVI"].ToString());
				}
				if(ds.Tables[0].Rows[0]["ShopType"].ToString()!="")
				{
					model.ShopType=int.Parse(ds.Tables[0].Rows[0]["ShopType"].ToString());
				}
				model.ShopPhone=ds.Tables[0].Rows[0]["ShopPhone"].ToString();
				if(ds.Tables[0].Rows[0]["areaid"].ToString()!="")
				{
					model.areaid=int.Parse(ds.Tables[0].Rows[0]["areaid"].ToString());
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
            strSql.Append("SELECT [ShopID],[PosID],[Shopname],[ShopAddress],[ShopOpenDate],[ShopCloseDate],[CloseUserID],[ProvinceID],[CityID],[ShopLevelID],[SaleTypeID],[LinkMan],[LinkPhone],[Email],[PostAddress],[PostCode],[FaxNumber],[Boolinstall],[DealerID],[ShopState],[ExamState],[cityname],[cityLevel],ProvinceName,[DealerName],[ShopLevel],[ShopMaster],[ShopMasterPhone],[TownID],[townName],[TownLevel],[ShopType],[ShopVI],[ShopArea],[DSRMasterPhone] ,[DSRMaster],[VMMasterPhone],[VMMaster],[FXID],[ShopPhone],[FXName],[areaid],[CustomerGroupID],[CustomerGroupName],[ShopOwnerShip],[CustomerCard],[Shopsamplename],[AreaName],[DepartMent],[Department_Master],[department_MasterPhone],[SupplierID]");
            strSql.Append(" FROM View_EditShopInfo ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(DbHelperSQL.connectionString(), strSql.ToString());
		}

		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ");
			if(Top>0)
			{
				strSql.Append(" top "+Top.ToString());
			}
			strSql.Append(" ID,ShopID,PosID,Shopname,ShopAddress,ShopOpenDate,ShopCloseDate,CloseUserID,ProvinceID,CityID,TownID,ShopLevelID,SaleTypeID,LinkMan,LinkPhone,ShopMaster,ShopMasterPhone,Email,PostAddress,PostCode,FaxNumber,Boolinstall,DealerID,FXID,CustomerGroupID,CustomerGroupName,ShopState,ExamState,VMMaster,VMMasterPhone,DSRMaster,DSRMasterPhone,ShopArea,ShopVI,ShopType,ShopPhone,areaid ");
			strSql.Append(" FROM EditShopInfo ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			strSql.Append(" order by " + filedOrder);
            return DbHelperSQL.Query(DbHelperSQL.connectionString(), strSql.ToString());
		}

        /// <summary>
        /// 更新部分数据
        /// </summary>
        public int UpdateSub(LN.Model.EditShopInfo model)
        {
            int _return = 0;
            SqlParameter[] parameters = {
					new SqlParameter("@ShopID", SqlDbType.Int,4),
					new SqlParameter("@PosID", SqlDbType.VarChar,50),
					new SqlParameter("@Shopname", SqlDbType.NVarChar,300),
					new SqlParameter("@Shopsamplename", SqlDbType.NVarChar,300),
					new SqlParameter("@ShopOpenDate", SqlDbType.VarChar,50),
					new SqlParameter("@ShopLevelID", SqlDbType.Int,4),
					new SqlParameter("@SaleTypeID", SqlDbType.Int,4),
					new SqlParameter("@LinkMan", SqlDbType.VarChar,20),
					new SqlParameter("@LinkPhone", SqlDbType.VarChar,80),
					new SqlParameter("@ShopMaster", SqlDbType.VarChar,50),
					new SqlParameter("@ShopMasterPhone", SqlDbType.VarChar,50),
					new SqlParameter("@Email", SqlDbType.VarChar,50),
					new SqlParameter("@PostAddress", SqlDbType.VarChar,500),
					new SqlParameter("@PostCode", SqlDbType.VarChar,50),
					new SqlParameter("@FaxNumber", SqlDbType.VarChar,50),
					new SqlParameter("@Boolinstall", SqlDbType.Int,4),
					new SqlParameter("@DealerID", SqlDbType.VarChar,50),
					new SqlParameter("@FXID", SqlDbType.VarChar,50),
					new SqlParameter("@CustomerGroupID", SqlDbType.VarChar,50),
					new SqlParameter("@CustomerGroupName", SqlDbType.VarChar,300),
					new SqlParameter("@ShopState", SqlDbType.Int,4),
					new SqlParameter("@ExamState", SqlDbType.Int,4),    //0
					new SqlParameter("@VMMaster", SqlDbType.VarChar,50),
					new SqlParameter("@VMMasterPhone", SqlDbType.VarChar,50),
					new SqlParameter("@DSRMaster", SqlDbType.VarChar,50),
					new SqlParameter("@DSRMasterPhone", SqlDbType.VarChar,50),
					new SqlParameter("@ShopArea", SqlDbType.Float,8),
					new SqlParameter("@ShopVI", SqlDbType.Int,4),
					new SqlParameter("@ShopType", SqlDbType.Int,4),
					new SqlParameter("@ShopPhone", SqlDbType.VarChar,50),
					new SqlParameter("@ShopOwnerShip", SqlDbType.NVarChar,50),
					new SqlParameter("@CustomerCard", SqlDbType.NVarChar,50),
					new SqlParameter("@VMExamState", SqlDbType.Int,4),
					new SqlParameter("@VMExamUserID", SqlDbType.Int,4),

                    //add by mhj 2012.12.13
                    new SqlParameter("@ACL_Id", SqlDbType.Int,4),
                    new SqlParameter("@TCL_Id", SqlDbType.Int,4),

                    //add by mhj 2012.12.13
                    new SqlParameter("@areaid", SqlDbType.Int,4),
                    new SqlParameter("@ProvinceID", SqlDbType.Int,4),
                    new SqlParameter("@CityID", SqlDbType.Int,4),
                    new SqlParameter("@TownID", SqlDbType.Int,4)
            };

            parameters[0].Value = model.ShopID;
            parameters[1].Value = model.PosID;
            parameters[2].Value = model.Shopname;
            parameters[3].Value = model.ShopSampleName;
            parameters[4].Value = model.ShopOpenDate;
            parameters[5].Value = model.ShopLevelID;
            parameters[6].Value = model.SaleTypeID;
            parameters[7].Value = model.LinkMan;
            parameters[8].Value = model.LinkPhone;
            parameters[9].Value = model.ShopMaster;
            parameters[10].Value = model.ShopMasterPhone;
            parameters[11].Value = model.Email;
            parameters[12].Value = model.PostAddress;
            parameters[13].Value = model.PostCode;
            parameters[14].Value = model.FaxNumber;
            parameters[15].Value = model.Boolinstall;
            parameters[16].Value = model.DealerID;
            parameters[17].Value = model.FXID;
            parameters[18].Value = model.CustomerGroupID;
            parameters[19].Value = model.CustomerGroupName;
            parameters[20].Value = model.ShopState;
            parameters[21].Value = 0;
            parameters[22].Value = model.VMMaster;
            parameters[23].Value = model.VMMasterPhone;
            parameters[24].Value = model.DSRMaster;
            parameters[25].Value = model.DSRMasterPhone;
            parameters[26].Value = model.ShopArea;
            parameters[27].Value = model.ShopVI;
            parameters[28].Value = model.ShopType;
            parameters[29].Value = model.ShopPhone;
            parameters[30].Value = model.ShopOwnerShip;
            parameters[31].Value = model.CustomerCard;
            parameters[32].Value = 0;
            parameters[33].Value = 0;

            //add by mhj 2012.12.13
            parameters[34].Value = model.ACL_Id;
            parameters[35].Value = model.TCL_Id;

            //add by mhj 2013.03.26
            parameters[36].Value = model.areaid;
            parameters[37].Value = model.ProvinceID;
            parameters[38].Value = model.CityID;
            parameters[39].Value = model.TownID;


            //string sql1 = "update shopinfo set linkman='" + model.LinkMan + "',LinkPhone='" + model.LinkPhone + "' where shopid=" + model.ShopID;
            //string sql2 = "update userinfo set username='" + model.LinkMan + "' where username='" + oldman + "'";
            //string sql3 = "delete Editshopinfo where ExamState=0 and shopid =" + model.ShopID;
            //List<string> strlist = new List<string>();
            //strlist.Add(sql1);
            //strlist.Add(sql2);
            //DbHelperSQL.ExecuteSql(sql3); 
            //copyshopinfo(model.ShopID.ToString());
            //DbHelperSQL.ExecuteSqlTran(strlist);

            object obj = DbHelperSQL.RunProcedure(DbHelperSQL.connectionString(), "UP_EditShopInfo_Update", parameters, out _return);
            if (obj != null)
                _return = Convert.ToInt32(obj);

            return _return;

        }

        /// <summary>
        /// 部门经理更新修改店铺的审核状态
        /// </summary>
        /// <param name="StrWhere"></param>
        public void UpdateExamState(int examState, string IDList)
        {
            List<string> sqllist = new List<string>();
            string strState = string.Format("update Editshopinfo set ExamState={0} where ExamState=0 and ShopID in ({1}) ", examState.ToString(), IDList);

            StringBuilder updateSql = new StringBuilder();
            updateSql.Append("UPDATE [ShopInfo] SET [ShopID] = e.ShopID");
            updateSql.Append(",[PosID] = e.PosID");
            updateSql.Append(",[Shopname] = e.Shopname");
            updateSql.Append(",[Shopsamplename] = e.Shopsamplename");
            updateSql.Append(",[ShopAddress] = e.ShopAddress");
            updateSql.Append(",[ShopOpenDate] = e.ShopOpenDate");
            updateSql.Append(",[ShopCloseDate] = e.ShopCloseDate");
            updateSql.Append(",[CloseUserID] = e.CloseUserID");
            updateSql.Append(",[ProvinceID] = e.ProvinceID");
            updateSql.Append(",[CityID] = e.CityID");
            updateSql.Append(",[TownID] = e.TownID");
            updateSql.Append(",[ShopLevelID] = e.ShopLevelID");
            updateSql.Append(",[SaleTypeID] = e.SaleTypeID");
            updateSql.Append(",[LinkMan] = e.LinkMan");
            updateSql.Append(",[LinkPhone] = e.LinkPhone");
            updateSql.Append(",[ShopMaster] = e.ShopMaster");
            updateSql.Append(",[ShopMasterPhone] = e.ShopMasterPhone");
            updateSql.Append(",[Email] = e.Email");
            updateSql.Append(",[PostAddress] = e.PostAddress");
            updateSql.Append(",[PostCode] = e.PostCode");
            updateSql.Append(",[FaxNumber] = e.FaxNumber");
            updateSql.Append(",[Boolinstall] = e.Boolinstall");
            updateSql.Append(",[DealerID] = e.DealerID");
            updateSql.Append(",[FXID] = e.FXID");
            updateSql.Append(",[CustomerGroupID] = e.CustomerGroupID");
            updateSql.Append(",[CustomerGroupName] = e.CustomerGroupName");
            updateSql.Append(",[ShopState] = e.ShopState");
            updateSql.Append(",[ExamState] = e.ExamState");
            updateSql.Append(",[VMMaster] = e.VMMaster");
            updateSql.Append(",[VMMasterPhone] = e.VMMasterPhone");
            updateSql.Append(",[DSRMaster] = e.DSRMaster");
            updateSql.Append(",[DSRMasterPhone] = e.DSRMasterPhone");
            updateSql.Append(",[ShopArea] = e.ShopArea");
            updateSql.Append(",[ShopVI] = e.ShopVI");
            updateSql.Append(",[ShopType] = e.ShopType");
            updateSql.Append(",[ShopPhone] = e.ShopPhone");
            updateSql.Append(",[areaid] = e.areaid");
            updateSql.Append(",[ShopOwnerShip] = e.ShopOwnerShip");
            updateSql.Append(",[CustomerCard] = e.CustomerCard");
            updateSql.Append(",[VMExamState] = e.VMExamState");
            updateSql.Append(",[VMExamUserID] = e.VMExamUserID");
            updateSql.Append(",[VMExamDate] = e.VMExamDate ");
            updateSql.Append(" FROM [ShopInfo] s ,EditShopInfo e ");
            updateSql.AppendFormat(" WHERE s.[ShopID] = e.[ShopID] AND e.ExamState=1 AND e.ShopID IN ({0});", IDList);


            sqllist.Add(strState);
            sqllist.Add(updateSql.ToString());
            DbHelperSQL.ExecuteSqlTran(DbHelperSQL.connectionString(), sqllist);
        }
        /// <summary>
        /// 省区VM更改店铺的审核状态
        /// </summary>
        /// <param name="examState"></param>
        /// <param name="StrWhere"></param>
        public void VMUpdateExamState(int examState, string UserID, string IDList)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("update Editshopinfo set VMExamState=" + examState + ",VMExamUserID=" + UserID + ",VMExamDate=CONVERT(varchar(30), GETDATE(), 20) where ExamState=0 and ");
            sb.AppendFormat(" shopid in ({0})", IDList);
            DbHelperSQL.ExecuteSql(DbHelperSQL.connectionString(), sb.ToString());
        }

        /// <summary>
        /// 获取店铺的审核状态
        /// </summary>
        /// <param name="ShopID">店铺编号</param>
        public DataTable GetExamState(string ShopID)
        {
            DataTable dt = null;
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("SELECT ISNULL([ExamState],'') AS ExamState,ISNULL([VMExamState],'') AS VMExamState FROM [EditShopInfo] WHERE ShopID={0}", ShopID);

            DataSet ds = DbHelperSQL.Query(DbHelperSQL.connectionString(), strSql.ToString());

            if (ds != null)
                dt = ds.Tables[0];

            return dt;

        }

		#endregion  成员方法
	}
}

