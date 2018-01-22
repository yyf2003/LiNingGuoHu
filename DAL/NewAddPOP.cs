using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using LN.DBUtility;//请先添加引用
namespace LN.DAL
{
	/// <summary>
	/// 数据访问类NewAddPOP。
	/// </summary>
	public class NewAddPOP
	{
		public NewAddPOP()
		{}
		#region  成员方法

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from NewAddPOP");
			strSql.Append(" where ID=@ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)};
			parameters[0].Value = ID;

            return DbHelperSQL.Exists(DbHelperSQL.connectionString(), strSql.ToString(), parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(LN.Model.NewAddPOP model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into NewAddPOP(");
			strSql.Append("shopid,POPID,POPinfoID,imageID)");
			strSql.Append(" values (");
			strSql.Append("@shopid,@POPID,@POPinfoID,@imageID)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@shopid", SqlDbType.Int,4),
					new SqlParameter("@POPID", SqlDbType.VarChar,50),
					new SqlParameter("@POPinfoID", SqlDbType.Int,4),
					new SqlParameter("@imageID", SqlDbType.Int,4)};
			parameters[0].Value = model.shopid;
			parameters[1].Value = model.POPID;
			parameters[2].Value = model.POPinfoID;
			parameters[3].Value = model.imageID;

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
		public void Update(LN.Model.NewAddPOP model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update NewAddPOP set ");
			strSql.Append("shopid=@shopid,");
			strSql.Append("POPID=@POPID,");
			strSql.Append("POPinfoID=@POPinfoID,");
			strSql.Append("imageID=@imageID");
			strSql.Append(" where ID=@ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4),
					new SqlParameter("@shopid", SqlDbType.Int,4),
					new SqlParameter("@POPID", SqlDbType.VarChar,50),
					new SqlParameter("@POPinfoID", SqlDbType.Int,4),
					new SqlParameter("@imageID", SqlDbType.Int,4)};
			parameters[0].Value = model.ID;
			parameters[1].Value = model.shopid;
			parameters[2].Value = model.POPID;
			parameters[3].Value = model.POPinfoID;
			parameters[4].Value = model.imageID;

            DbHelperSQL.ExecuteSql(DbHelperSQL.connectionString(), strSql.ToString(), parameters);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(int ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from NewAddPOP ");
			strSql.Append(" where ID=@ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)};
			parameters[0].Value = ID;

            DbHelperSQL.ExecuteSql(DbHelperSQL.connectionString(), strSql.ToString(), parameters);
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public LN.Model.NewAddPOP GetModel(int ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 ID,shopid,POPID,POPinfoID,imageID from NewAddPOP ");
			strSql.Append(" where ID=@ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)};
			parameters[0].Value = ID;

			LN.Model.NewAddPOP model=new LN.Model.NewAddPOP();
            DataSet ds = DbHelperSQL.Query(DbHelperSQL.connectionString(), strSql.ToString(), parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["ID"].ToString()!="")
				{
					model.ID=int.Parse(ds.Tables[0].Rows[0]["ID"].ToString());
				}
				if(ds.Tables[0].Rows[0]["shopid"].ToString()!="")
				{
					model.shopid=int.Parse(ds.Tables[0].Rows[0]["shopid"].ToString());
				}
				model.POPID=ds.Tables[0].Rows[0]["POPID"].ToString();
				if(ds.Tables[0].Rows[0]["POPinfoID"].ToString()!="")
				{
					model.POPinfoID=int.Parse(ds.Tables[0].Rows[0]["POPinfoID"].ToString());
				}
				if(ds.Tables[0].Rows[0]["imageID"].ToString()!="")
				{
					model.imageID=int.Parse(ds.Tables[0].Rows[0]["imageID"].ToString());
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
			strSql.Append("select ID,shopid,POPID,POPinfoID,imageID ");
			strSql.Append(" FROM NewAddPOP ");
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
			strSql.Append(" ID,shopid,POPID,POPinfoID,imageID ");
			strSql.Append(" FROM NewAddPOP ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			strSql.Append(" order by " + filedOrder);
            return DbHelperSQL.Query(DbHelperSQL.connectionString(), strSql.ToString());
		}
        /// <summary>
        /// 得到新增POP的订单
        /// </summary>
        /// <param name="strwhere"></param>
        /// <returns></returns>
        public DataTable GetNewList(string strwhere)
        {
            StringBuilder sb = new StringBuilder();

            sb.Append(" SELECT ");
            sb.Append("[PosID] 店铺编号 ,[Shopname] 店铺名称,[Shopsamplename] 店铺简称 ,[PostAddress] 店铺邮政地址,[PostCode] 店铺邮编,[ShopPhone] 店铺固定电话,[LinkMan] 店长,[LinkPhone] 店长移动电话,[Email] 店长email,[FaxNumber] 店铺传真号码 ");
            sb.Append(",[Boolinstall] 是否李宁公司统一支持安装,[DealerID] 一级客户编号,[DealerName] 一级客户名,(select shopstate from shopstateinfo where id=view_shopinfo.shopstate) as 店铺状态,[DepartMent] 部门名称 ");
            sb.Append(",[AreaName] 区域名称,[ProvinceName] 省名称,[cityname] 地级城市名称,[cityLevel] 地市级城市级别_市场定义,[townName] 区县级城市名称,TownLevel 区县级城市级别_市场定义 ,[ShopMaster] 店铺零售负责人 ");
            sb.Append(",[ShopMasterPhone] 店铺零售负责人移动电话,(select shoptypename from shoptype where id=view_shopinfo.shoptype) as  店铺类型 ");
            sb.Append(",shoplevel 店铺级别,[ShopVI] 店铺形象属性,[ShopArea] 营业面积,[DSRMaster] 李宁DSR负责人,[DSRMasterPhone] 李宁DSR负责人电话,[VMMaster] 李宁省区VM负责人,[VMMasterPhone] 李宁省区VM负责人电话,Department_Master 李宁大区VM经理,department_MasterPhone 李宁大区VM经理电话,[FXID] 直属客户编号,[FXName] 直属客户名 ");
            sb.Append(",[CustomerGroupID] 上级客户集团编号,[CustomerGroupName] 上级客户级别,[ShopOwnerShip] 店铺产权关系,[CustomerCard] 客户身份, ");
            sb.Append("(select supplierName from supplierinfo where supplierID=view_shopinfo.supplierID) as 供应商 , ");
            sb.Append("[SeatNum] POP编号,[POPseat] POP类型,[SeatDesc] 位置描述");
            sb.Append(",producttypename 故事包大类,View_ProductLine.productline POP故事包,[RealHeight] POP实际制作高,[RealWith] POP实际制作宽,[POPHeight] POP可视画面高,[POPWith] POP可视画面宽,[POPPlwz] POP可视画面位置,[POPPljd] POP可视画面偏离角度,[POPArea] POP面积,[POPMaterial] POP材质,[Sexarea] 男女区域,[TwoSided] 是否为双面 ");
            sb.Append(",[Glass] 是否粘贴于玻璃上,[PlatformWith] 橱窗空间进深mm,[PlatformHeight] 橱窗空间长度mm,[PlatformLong] 橱窗空间面积  ");
            sb.Append("FROM  (((View_ShopInfo inner join popinfo on View_ShopInfo.shopid=popinfo.shopid) ");
            sb.Append("left join View_ProductLine on POPInfo.ProductLineID = dbo.View_ProductLine.ProductLineID) ");
            sb.Append(" inner join NewAddPOP on NewAddPOP.popinfoid=popinfo.ID) ");

            if (strwhere.Length > 0)
            {
                sb.Append(" where ");
                sb.Append(strwhere);
            }
            DataSet ds = DbHelperSQL.Query(DbHelperSQL.connectionString(), sb.ToString());
            return ds.Tables[0];
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
			parameters[0].Value = "NewAddPOP";
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

