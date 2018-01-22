using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using LN.DBUtility;//�����������
namespace LN.DAL
{
	/// <summary>
	/// ���ݷ�����NewAddPOP��
	/// </summary>
	public class NewAddPOP
	{
		public NewAddPOP()
		{}
		#region  ��Ա����

		/// <summary>
		/// �Ƿ���ڸü�¼
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
		/// ����һ������
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
		/// ����һ������
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
		/// ɾ��һ������
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
		/// �õ�һ������ʵ��
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
		/// ��������б�
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
		/// ���ǰ��������
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
        /// �õ�����POP�Ķ���
        /// </summary>
        /// <param name="strwhere"></param>
        /// <returns></returns>
        public DataTable GetNewList(string strwhere)
        {
            StringBuilder sb = new StringBuilder();

            sb.Append(" SELECT ");
            sb.Append("[PosID] ���̱�� ,[Shopname] ��������,[Shopsamplename] ���̼�� ,[PostAddress] ����������ַ,[PostCode] �����ʱ�,[ShopPhone] ���̶̹��绰,[LinkMan] �곤,[LinkPhone] �곤�ƶ��绰,[Email] �곤email,[FaxNumber] ���̴������ ");
            sb.Append(",[Boolinstall] �Ƿ�������˾ͳһ֧�ְ�װ,[DealerID] һ���ͻ����,[DealerName] һ���ͻ���,(select shopstate from shopstateinfo where id=view_shopinfo.shopstate) as ����״̬,[DepartMent] �������� ");
            sb.Append(",[AreaName] ��������,[ProvinceName] ʡ����,[cityname] �ؼ���������,[cityLevel] ���м����м���_�г�����,[townName] ���ؼ���������,TownLevel ���ؼ����м���_�г����� ,[ShopMaster] �������۸����� ");
            sb.Append(",[ShopMasterPhone] �������۸������ƶ��绰,(select shoptypename from shoptype where id=view_shopinfo.shoptype) as  �������� ");
            sb.Append(",shoplevel ���̼���,[ShopVI] ������������,[ShopArea] Ӫҵ���,[DSRMaster] ����DSR������,[DSRMasterPhone] ����DSR�����˵绰,[VMMaster] ����ʡ��VM������,[VMMasterPhone] ����ʡ��VM�����˵绰,Department_Master ��������VM����,department_MasterPhone ��������VM����绰,[FXID] ֱ���ͻ����,[FXName] ֱ���ͻ��� ");
            sb.Append(",[CustomerGroupID] �ϼ��ͻ����ű��,[CustomerGroupName] �ϼ��ͻ�����,[ShopOwnerShip] ���̲�Ȩ��ϵ,[CustomerCard] �ͻ����, ");
            sb.Append("(select supplierName from supplierinfo where supplierID=view_shopinfo.supplierID) as ��Ӧ�� , ");
            sb.Append("[SeatNum] POP���,[POPseat] POP����,[SeatDesc] λ������");
            sb.Append(",producttypename ���°�����,View_ProductLine.productline POP���°�,[RealHeight] POPʵ��������,[RealWith] POPʵ��������,[POPHeight] POP���ӻ����,[POPWith] POP���ӻ����,[POPPlwz] POP���ӻ���λ��,[POPPljd] POP���ӻ���ƫ��Ƕ�,[POPArea] POP���,[POPMaterial] POP����,[Sexarea] ��Ů����,[TwoSided] �Ƿ�Ϊ˫�� ");
            sb.Append(",[Glass] �Ƿ�ճ���ڲ�����,[PlatformWith] �����ռ����mm,[PlatformHeight] �����ռ䳤��mm,[PlatformLong] �����ռ����  ");
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
		/// ��ҳ��ȡ�����б�
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

		#endregion  ��Ա����
	}
}

