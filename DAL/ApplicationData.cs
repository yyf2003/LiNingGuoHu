using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using LN.DBUtility;//请先添加引用
namespace LN.DAL
{
	/// <summary>
	/// 数据访问类ApplicationData。
	/// </summary>
	public class ApplicationData
	{
		public ApplicationData()
		{}
		#region  成员方法

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
            return DbHelperSQL.GetMaxID(DbHelperSQL.connectionString(), "ID", "ApplicationData"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from ApplicationData");
			strSql.Append(" where ID=@ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)};
			parameters[0].Value = ID;

            return DbHelperSQL.Exists(DbHelperSQL.connectionString(), strSql.ToString(), parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(LN.Model.ApplicationData model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into ApplicationData(");
			strSql.Append("ShopID,POSCode,POPSeatNum,SeatDesc,POPHeight,POPWith,POPArea,POPMaterial,ProductLineID,Sexarea,TwoSided,Glass,PlatformWith,PlatformHeight,PlatformLong,ApplyUserID,ApplyType,ApplyDesc,ApplyDate,PhotoPath,AreaVMExamState,AreaVMExamDesc,AreaVMExamUseID)");
			strSql.Append(" values (");
			strSql.Append("@ShopID,@POSCode,@POPSeatNum,@SeatDesc,@POPHeight,@POPWith,@POPArea,@POPMaterial,@ProductLineID,@Sexarea,@TwoSided,@Glass,@PlatformWith,@PlatformHeight,@PlatformLong,@ApplyUserID,@ApplyType,@ApplyDesc,@ApplyDate,@PhotoPath,@AreaVMExamState,@AreaVMExamDesc,@AreaVMExamUseID)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@ShopID", SqlDbType.Int,4),
					new SqlParameter("@POSCode", SqlDbType.VarChar,20),
					new SqlParameter("@POPSeatNum", SqlDbType.VarChar,20),
					new SqlParameter("@SeatDesc", SqlDbType.VarChar,50),
					new SqlParameter("@POPHeight", SqlDbType.Float,8),
					new SqlParameter("@POPWith", SqlDbType.Float,8),
					new SqlParameter("@POPArea", SqlDbType.Float,8),
					new SqlParameter("@POPMaterial", SqlDbType.NVarChar,100),
					new SqlParameter("@ProductLineID", SqlDbType.Int,4),
					new SqlParameter("@Sexarea", SqlDbType.VarChar,10),
					new SqlParameter("@TwoSided", SqlDbType.Int,4),
					new SqlParameter("@Glass", SqlDbType.Int,4),
					new SqlParameter("@PlatformWith", SqlDbType.Float,8),
					new SqlParameter("@PlatformHeight", SqlDbType.Float,8),
					new SqlParameter("@PlatformLong", SqlDbType.Float,8),
					new SqlParameter("@ApplyUserID", SqlDbType.Int,4),
					new SqlParameter("@ApplyType", SqlDbType.VarChar,20),
					new SqlParameter("@ApplyDesc", SqlDbType.NChar,10),
					new SqlParameter("@ApplyDate", SqlDbType.VarChar,30),
					new SqlParameter("@PhotoPath", SqlDbType.VarChar,500),
					new SqlParameter("@AreaVMExamState", SqlDbType.Int,4),
					new SqlParameter("@AreaVMExamDesc", SqlDbType.VarChar,200),
					new SqlParameter("@AreaVMExamUseID", SqlDbType.Int,4)};
			parameters[0].Value = model.ShopID;
			parameters[1].Value = model.POSCode;
			parameters[2].Value = model.POPSeatNum;
			parameters[3].Value = model.SeatDesc;
			parameters[4].Value = model.POPHeight;
			parameters[5].Value = model.POPWith;
			parameters[6].Value = model.POPArea;
			parameters[7].Value = model.POPMaterial;
			parameters[8].Value = model.ProductLineID;
			parameters[9].Value = model.Sexarea;
			parameters[10].Value = model.TwoSided;
			parameters[11].Value = model.Glass;
			parameters[12].Value = model.PlatformWith;
			parameters[13].Value = model.PlatformHeight;
			parameters[14].Value = model.PlatformLong;
			parameters[15].Value = model.ApplyUserID;
			parameters[16].Value = model.ApplyType;
			parameters[17].Value = model.ApplyDesc;
			parameters[18].Value = model.ApplyDate;
			parameters[19].Value = model.PhotoPath;
			parameters[20].Value = model.AreaVMExamState;
			parameters[21].Value = model.AreaVMExamDesc;
			parameters[22].Value = model.AreaVMExamUseID;

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
		public void Update(LN.Model.ApplicationData model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update ApplicationData set ");
			strSql.Append("ShopID=@ShopID,");
			strSql.Append("POSCode=@POSCode,");
			strSql.Append("POPSeatNum=@POPSeatNum,");
			strSql.Append("SeatDesc=@SeatDesc,");
			strSql.Append("POPHeight=@POPHeight,");
			strSql.Append("POPWith=@POPWith,");
			strSql.Append("POPArea=@POPArea,");
			strSql.Append("POPMaterial=@POPMaterial,");
			strSql.Append("ProductLineID=@ProductLineID,");
			strSql.Append("Sexarea=@Sexarea,");
			strSql.Append("TwoSided=@TwoSided,");
			strSql.Append("Glass=@Glass,");
			strSql.Append("PlatformWith=@PlatformWith,");
			strSql.Append("PlatformHeight=@PlatformHeight,");
			strSql.Append("PlatformLong=@PlatformLong,");
			strSql.Append("ApplyUserID=@ApplyUserID,");
			strSql.Append("ApplyType=@ApplyType,");
			strSql.Append("ApplyDesc=@ApplyDesc,");
			strSql.Append("ApplyDate=@ApplyDate,");
			strSql.Append("PhotoPath=@PhotoPath,");
			strSql.Append("AreaVMExamState=@AreaVMExamState,");
			strSql.Append("AreaVMExamDesc=@AreaVMExamDesc,");
			strSql.Append("AreaVMExamUseID=@AreaVMExamUseID");
			strSql.Append(" where ID=@ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4),
					new SqlParameter("@ShopID", SqlDbType.Int,4),
					new SqlParameter("@POSCode", SqlDbType.VarChar,20),
					new SqlParameter("@POPSeatNum", SqlDbType.VarChar,20),
					new SqlParameter("@SeatDesc", SqlDbType.VarChar,50),
					new SqlParameter("@POPHeight", SqlDbType.Float,8),
					new SqlParameter("@POPWith", SqlDbType.Float,8),
					new SqlParameter("@POPArea", SqlDbType.Float,8),
					new SqlParameter("@POPMaterial", SqlDbType.NVarChar,100),
					new SqlParameter("@ProductLineID", SqlDbType.Int,4),
					new SqlParameter("@Sexarea", SqlDbType.VarChar,10),
					new SqlParameter("@TwoSided", SqlDbType.Int,4),
					new SqlParameter("@Glass", SqlDbType.Int,4),
					new SqlParameter("@PlatformWith", SqlDbType.Float,8),
					new SqlParameter("@PlatformHeight", SqlDbType.Float,8),
					new SqlParameter("@PlatformLong", SqlDbType.Float,8),
					new SqlParameter("@ApplyUserID", SqlDbType.Int,4),
					new SqlParameter("@ApplyType", SqlDbType.VarChar,20),
					new SqlParameter("@ApplyDesc", SqlDbType.NChar,10),
					new SqlParameter("@ApplyDate", SqlDbType.VarChar,30),
					new SqlParameter("@PhotoPath", SqlDbType.VarChar,500),
					new SqlParameter("@AreaVMExamState", SqlDbType.Int,4),
					new SqlParameter("@AreaVMExamDesc", SqlDbType.VarChar,200),
					new SqlParameter("@AreaVMExamUseID", SqlDbType.Int,4)};
			parameters[0].Value = model.ID;
			parameters[1].Value = model.ShopID;
			parameters[2].Value = model.POSCode;
			parameters[3].Value = model.POPSeatNum;
			parameters[4].Value = model.SeatDesc;
			parameters[5].Value = model.POPHeight;
			parameters[6].Value = model.POPWith;
			parameters[7].Value = model.POPArea;
			parameters[8].Value = model.POPMaterial;
			parameters[9].Value = model.ProductLineID;
			parameters[10].Value = model.Sexarea;
			parameters[11].Value = model.TwoSided;
			parameters[12].Value = model.Glass;
			parameters[13].Value = model.PlatformWith;
			parameters[14].Value = model.PlatformHeight;
			parameters[15].Value = model.PlatformLong;
			parameters[16].Value = model.ApplyUserID;
			parameters[17].Value = model.ApplyType;
			parameters[18].Value = model.ApplyDesc;
			parameters[19].Value = model.ApplyDate;
			parameters[20].Value = model.PhotoPath;
			parameters[21].Value = model.AreaVMExamState;
			parameters[22].Value = model.AreaVMExamDesc;
			parameters[23].Value = model.AreaVMExamUseID;

            DbHelperSQL.ExecuteSql(DbHelperSQL.connectionString(), strSql.ToString(), parameters);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(int ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from ApplicationData ");
			strSql.Append(" where ID=@ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)};
			parameters[0].Value = ID;

            DbHelperSQL.ExecuteSql(DbHelperSQL.connectionString(), strSql.ToString(), parameters);
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public LN.Model.ApplicationData GetModel(int ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 ID,ShopID,POSCode,POPSeatNum,SeatDesc,POPHeight,POPWith,POPArea,POPMaterial,ProductLineID,Sexarea,TwoSided,Glass,PlatformWith,PlatformHeight,PlatformLong,ApplyUserID,ApplyType,ApplyDesc,ApplyDate,PhotoPath,AreaVMExamState,AreaVMExamDesc,AreaVMExamUseID from ApplicationData ");
			strSql.Append(" where ID=@ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)};
			parameters[0].Value = ID;

			LN.Model.ApplicationData model=new LN.Model.ApplicationData();
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
				model.POSCode=ds.Tables[0].Rows[0]["POSCode"].ToString();
				model.POPSeatNum=ds.Tables[0].Rows[0]["POPSeatNum"].ToString();
				model.SeatDesc=ds.Tables[0].Rows[0]["SeatDesc"].ToString();
				if(ds.Tables[0].Rows[0]["POPHeight"].ToString()!="")
				{
					model.POPHeight=decimal.Parse(ds.Tables[0].Rows[0]["POPHeight"].ToString());
				}
				if(ds.Tables[0].Rows[0]["POPWith"].ToString()!="")
				{
					model.POPWith=decimal.Parse(ds.Tables[0].Rows[0]["POPWith"].ToString());
				}
				if(ds.Tables[0].Rows[0]["POPArea"].ToString()!="")
				{
					model.POPArea=decimal.Parse(ds.Tables[0].Rows[0]["POPArea"].ToString());
				}
				model.POPMaterial=ds.Tables[0].Rows[0]["POPMaterial"].ToString();
				if(ds.Tables[0].Rows[0]["ProductLineID"].ToString()!="")
				{
					model.ProductLineID=int.Parse(ds.Tables[0].Rows[0]["ProductLineID"].ToString());
				}
				model.Sexarea=ds.Tables[0].Rows[0]["Sexarea"].ToString();
				if(ds.Tables[0].Rows[0]["TwoSided"].ToString()!="")
				{
					model.TwoSided=int.Parse(ds.Tables[0].Rows[0]["TwoSided"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Glass"].ToString()!="")
				{
					model.Glass=int.Parse(ds.Tables[0].Rows[0]["Glass"].ToString());
				}
				if(ds.Tables[0].Rows[0]["PlatformWith"].ToString()!="")
				{
					model.PlatformWith=decimal.Parse(ds.Tables[0].Rows[0]["PlatformWith"].ToString());
				}
				if(ds.Tables[0].Rows[0]["PlatformHeight"].ToString()!="")
				{
					model.PlatformHeight=decimal.Parse(ds.Tables[0].Rows[0]["PlatformHeight"].ToString());
				}
				if(ds.Tables[0].Rows[0]["PlatformLong"].ToString()!="")
				{
					model.PlatformLong=decimal.Parse(ds.Tables[0].Rows[0]["PlatformLong"].ToString());
				}
				if(ds.Tables[0].Rows[0]["ApplyUserID"].ToString()!="")
				{
					model.ApplyUserID=int.Parse(ds.Tables[0].Rows[0]["ApplyUserID"].ToString());
				}
				model.ApplyType=ds.Tables[0].Rows[0]["ApplyType"].ToString();
				model.ApplyDesc=ds.Tables[0].Rows[0]["ApplyDesc"].ToString();
				model.ApplyDate=ds.Tables[0].Rows[0]["ApplyDate"].ToString();
				model.PhotoPath=ds.Tables[0].Rows[0]["PhotoPath"].ToString();
				if(ds.Tables[0].Rows[0]["AreaVMExamState"].ToString()!="")
				{
					model.AreaVMExamState=int.Parse(ds.Tables[0].Rows[0]["AreaVMExamState"].ToString());
				}
				model.AreaVMExamDesc=ds.Tables[0].Rows[0]["AreaVMExamDesc"].ToString();
				if(ds.Tables[0].Rows[0]["AreaVMExamUseID"].ToString()!="")
				{
					model.AreaVMExamUseID=int.Parse(ds.Tables[0].Rows[0]["AreaVMExamUseID"].ToString());
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
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ID,ShopID,POSCode,POPSeatNum,SeatDesc,POPHeight,POPWith,POPArea,POPMaterial,ProductLineID,Sexarea,TwoSided,Glass,PlatformWith,PlatformHeight,PlatformLong,ApplyUserID,ApplyType,ApplyDesc,ApplyDate,PhotoPath,AreaVMExamState,AreaVMExamDesc,AreaVMExamUseID ");
			strSql.Append(" FROM ApplicationData ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
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
			strSql.Append(" ID,ShopID,POSCode,POPSeatNum,SeatDesc,POPHeight,POPWith,POPArea,POPMaterial,ProductLineID,Sexarea,TwoSided,Glass,PlatformWith,PlatformHeight,PlatformLong,ApplyUserID,ApplyType,ApplyDesc,ApplyDate,PhotoPath,AreaVMExamState,AreaVMExamDesc,AreaVMExamUseID ");
			strSql.Append(" FROM ApplicationData ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			strSql.Append(" order by " + filedOrder);
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
			parameters[0].Value = "ApplicationData";
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

