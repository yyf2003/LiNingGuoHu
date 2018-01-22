using System;
using System.Data;
using System.Text;
using System.Collections.Generic;
using System.Data.SqlClient;
using LN.DBUtility;//�����������
namespace LN.DAL
{
    /// <summary>
    /// ���ݷ�����AssignRecord��
    /// </summary>
    public class SupplierAssignRecord
    {
        public SupplierAssignRecord()
        { }
        #region  ��Ա����

        /// <summary>
        /// �õ����ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperSQL.GetMaxID(DbHelperSQL.connectionString(), "ID", "AssignRecord");
        }

        /// <summary>
        /// �Ƿ���ڸü�¼
        /// </summary>
        public bool Exists(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from SupplierAssignRecord");
            strSql.Append(" where ID=@ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)};
            parameters[0].Value = ID;

            return DbHelperSQL.Exists(DbHelperSQL.connectionString(), strSql.ToString(), parameters);
        }

        /// <summary>
        /// �Ƿ���ڸü�¼
        /// </summary>
        public bool Exists(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from SupplierAssignRecord");
            strSql.Append(" where ");
            strSql.Append(strWhere);


            return DbHelperSQL.Exists(DbHelperSQL.connectionString(), strSql.ToString());
        }


        /// <summary>
        /// ����һ������
        /// </summary>
        public int Add(LN.Model.SupplierAssignRecord model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into SupplierAssignRecord(");
            strSql.Append("SupplierID,AssignRuleID,AssignProID,AssignCityID,AssignShopID,Remarks)");
            strSql.Append(" values (");
            strSql.Append("@SupplierID,@AssignRuleID,@AssignProID,@AssignCityID,@AssignShopID,@Remarks)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@SupplierID", SqlDbType.Int,4),
					new SqlParameter("@AssignRuleID", SqlDbType.Int,4),
					new SqlParameter("@AssignProID", SqlDbType.Int,4),
					new SqlParameter("@AssignCityID", SqlDbType.Int,4),
					new SqlParameter("@AssignShopID", SqlDbType.Int,4),
					new SqlParameter("@Remarks", SqlDbType.VarChar,500)};
            parameters[0].Value = model.SupplierID;
            parameters[1].Value = model.AssignRuleID;
            parameters[2].Value = model.AssignProID;
            parameters[3].Value = model.AssignCityID;
            parameters[4].Value = model.AssignShopID;
            parameters[5].Value = model.Remarks;

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
        public void Update(LN.Model.SupplierAssignRecord model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update SupplierAssignRecord set ");
            strSql.Append("SupplierID=@SupplierID,");
            strSql.Append("AssignRuleID=@AssignRuleID,");
            strSql.Append("AssignProID=@AssignProID,");
            strSql.Append("AssignCityID=@AssignCityID,");
            strSql.Append("AssignShopID=@AssignShopID,");
            strSql.Append("Remarks=@Remarks");
            strSql.Append(" where ID=@ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4),
					new SqlParameter("@SupplierID", SqlDbType.Int,4),
					new SqlParameter("@AssignRuleID", SqlDbType.Int,4),
					new SqlParameter("@AssignProID", SqlDbType.Int,4),
					new SqlParameter("@AssignCityID", SqlDbType.Int,4),
					new SqlParameter("@AssignShopID", SqlDbType.Int,4),
					new SqlParameter("@Remarks", SqlDbType.VarChar,500)};
            parameters[0].Value = model.ID;
            parameters[1].Value = model.SupplierID;
            parameters[2].Value = model.AssignRuleID;
            parameters[3].Value = model.AssignProID;
            parameters[4].Value = model.AssignCityID;
            parameters[5].Value = model.AssignShopID;
            parameters[6].Value = model.Remarks;

            DbHelperSQL.ExecuteSql(DbHelperSQL.connectionString(), strSql.ToString(), parameters);
        }

        /// <summary>
        /// ɾ��һ������
        /// </summary>
        public void Delete(int ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete SupplierAssignRecord ");
            strSql.Append(" where ID=@ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)};
            parameters[0].Value = ID;

            DbHelperSQL.ExecuteSql(DbHelperSQL.connectionString(), strSql.ToString(), parameters);
        }


        /// <summary>
        /// �õ�һ������ʵ��
        /// </summary>
        public LN.Model.SupplierAssignRecord GetModel(int ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 ID,SupplierID,AssignRuleID,AssignProID,AssignCityID,AssignShopID,Remarks from SupplierAssignRecord ");
            strSql.Append(" where ID=@ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)};
            parameters[0].Value = ID;

            LN.Model.SupplierAssignRecord model = new LN.Model.SupplierAssignRecord();
            DataSet ds = DbHelperSQL.Query(DbHelperSQL.connectionString(), strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["ID"].ToString() != "")
                {
                    model.ID = int.Parse(ds.Tables[0].Rows[0]["ID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["SupplierID"].ToString() != "")
                {
                    model.SupplierID = int.Parse(ds.Tables[0].Rows[0]["SupplierID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["AssignRuleID"].ToString() != "")
                {
                    model.AssignRuleID = int.Parse(ds.Tables[0].Rows[0]["AssignRuleID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["AssignProID"].ToString() != "")
                {
                    model.AssignProID = int.Parse(ds.Tables[0].Rows[0]["AssignProID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["AssignCityID"].ToString() != "")
                {
                    model.AssignCityID = int.Parse(ds.Tables[0].Rows[0]["AssignCityID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["AssignShopID"].ToString() != "")
                {
                    model.AssignShopID = int.Parse(ds.Tables[0].Rows[0]["AssignShopID"].ToString());
                }
                model.Remarks = ds.Tables[0].Rows[0]["Remarks"].ToString();
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
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ID,SupplierID,AssignRuleID,AssignProID,AssignCityID,AssignShopID,Remarks ");
            strSql.Append(" FROM SupplierAssignRecord ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(DbHelperSQL.connectionString(), strSql.ToString());
        }

        /// <summary>
        /// ���ݷ���ĳ��� �����ڳ��еĵ���ID �ŵ� SupplierAssignRecord ����
        /// </summary>
        /// <param name="gid"></param>
        /// <param name="cityIDlist"></param>
        /// <returns></returns>
        public bool allotshop(string gid, string PosIDlist, string dept, string areaIDlist, string Prolist)
        {
            List<string> list = new List<string>();
            StringBuilder delsql = new StringBuilder();
            delsql.Append("delete SupplierAssignRecord where SupplierID=" + gid);

            list.Add(delsql.ToString());
            StringBuilder strSql = new StringBuilder();
            strSql.Append("INSERT INTO [SupplierAssignRecord]");
            strSql.Append("([SupplierID]");
            strSql.Append(",[AssignRuleID]");
            strSql.Append(",[AssignProID]");
            strSql.Append(",[AssignCityID]");
            strSql.Append(",[AssignShopID]");
            strSql.Append(",[Remarks])");
            strSql.Append("SELECT ");
            strSql.Append(gid);
            strSql.Append(",0");
            strSql.Append(",provinceID");
            strSql.Append(",Cityid");
            strSql.Append(",Shopid");
            strSql.Append(",areaid ");
            strSql.Append("FROM view_shopinfo WHERE 1=1 ");
            if (dept.Length > 0)
            {
                strSql.Append(" AND department in (" + dept + ") ");
            }
            if (areaIDlist.Length > 0)
            {
                strSql.Append(" AND areaid in (" + areaIDlist + ") ");
            }
            if (Prolist.Length > 0)
            {
                strSql.Append(" AND provinceID in (" + Prolist + ") ");

            }
            if (PosIDlist.Length > 0)
            {
                strSql.Append(" AND shopid in (" + PosIDlist + ") ");
            }
            
            list.Add(strSql.ToString());
            try
            {
                DbHelperSQL.ExecuteSqlTran(DbHelperSQL.connectionString(), list);
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }

        ///// <summary>
        ///// ���ݷ���ĳ��� �����ڳ��еĵ���ID �ŵ� SupplierAssignRecord ����
        ///// </summary>
        ///// <param name="gid"></param>
        ///// <param name="cityIDlist"></param>
        ///// <returns></returns>
        //public bool allotshop(string gid, string PosIDlist, string dept, string areaIDlist, string Prolist)
        //{
        //    List<string> list = new List<string>();
        //    StringBuilder delsql = new StringBuilder();
        //    delsql.Append("delete SupplierAssignRecord where SupplierID=" + gid);

        //    list.Add(delsql.ToString());
        //    StringBuilder strSql = new StringBuilder();
        //    strSql.Append("insert into SupplierAssignRecord (SupplierID,AssignShopID,AssignRuleID,AssignProID,AssignCityID,Remarks)");
        //    if (PosIDlist.Length > 0)
        //    {
        //        strSql.Append(" select '" + gid + "' ,Shopid,0,provinceID,Cityid,areaid from view_shopinfo where shopid in (" + PosIDlist + ") ");
        //    }
        //    else if (Prolist.Length>0)
        //    {
        //        strSql.Append(" select '" + gid + "' ,Shopid,0,provinceID,Cityid,areaid from view_shopinfo where provinceID in (" + Prolist + ") ");

        //    }
        //    else if (areaIDlist.Length > 0)
        //    {
        //        strSql.Append(" select '" + gid + "' ,Shopid,0,provinceID,Cityid,areaid from view_shopinfo where areaid in (" + areaIDlist + ") ");
        //    }
        //    else if (dept.Length > 0)
        //    {
        //        strSql.Append(" select '" + gid + "' ,Shopid,0,provinceID,Cityid,areaid from view_shopinfo where department in (" + dept + ") ");
        //    }
        //    list.Add(strSql.ToString());
        //    try
        //    {
        //        DbHelperSQL.ExecuteSqlTran(list);
        //        return true;
        //    }
        //    catch (Exception)
        //    {
        //        return false;
        //    }

        //}
        /// <summary>
        /// �õ����������Ĺ�Ӧ��
        /// </summary>
        /// <param name="shopid"></param>
        /// <returns></returns>
        public string GetSuplierID(string shopid)
        {
            string returnstr = "";
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top 1 SupplierID from SupplierAssignRecord where shopid=" + shopid);

            object obj = DbHelperSQL.GetSingle(DbHelperSQL.connectionString(), strSql.ToString());
            if (obj != null)
            {
                returnstr = (string)obj;
            }
            return returnstr;

        }

      /// <summary>
      /// 
      /// </summary>
      /// <param name="strWhere"></param>
      /// <returns></returns>
        public string GetSuplierIDbyArea(string strWhere)
        {
            string returnstr = "";
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select distinct top 1 SupplierID from SupplierAssignRecord ");

            if (strWhere.Length > 0)
            {
                strSql.Append(" where ");
                strSql.Append(strWhere);
            }
            object obj = DbHelperSQL.GetSingle(DbHelperSQL.connectionString(), strSql.ToString());
            if (obj != null)
            {
                returnstr = obj.ToString();
            }
            return returnstr;

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataTable GetSuplierIDListbyArea(string AreaID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select SupplierID from SupplierAssignRecord ");
            //strSql.AppendFormat(" where Remarks = '{0}'  group by SupplierID", AreaID);
            strSql.AppendFormat(" where Remarks in ({0})  group by SupplierID", AreaID);
            DataSet ds = DbHelperSQL.Query(DbHelperSQL.connectionString(), strSql.ToString());

            return ds.Tables[0];

        }

        /// <summary>
        /// ��������б�
        /// </summary>
        /// <param name="model">��ҳʵ��</param>
        /// <returns>���ػ�ȡ�����б���</returns>
        public DataTable GetAssignRecordByID(LN.Model.PageModel model, out int TotalNumber)
        {
            DataTable dt = GetTableListSqlExec.GetList(model, out TotalNumber);
            if (dt != null)
                return dt;
            else
                return null;

        }
        /// <summary>
        /// ���ݵ��̵õ���Ӧ����Ϣ
        /// </summary>
        /// <param name="ShopID"></param>
        /// <returns></returns>
        public DataTable GetSpplierAssignRecordWithShopID(int ShopID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top 1 ID,SupplierID,SupplierName,AssignProID,ProvinceName,AssignCityID,Cityname,AssignShopID,ShopName,Remarks ");
            strSql.Append(" FROM View_SupplierAssignRecord ");
            strSql.Append(" where  AssignShopID =" + ShopID);
            DataSet ds = DbHelperSQL.Query(DbHelperSQL.connectionString(), strSql.ToString());
            if (ds != null)
                return ds.Tables[0];
            else
                return null;
        }

        /// <summary>
        /// ���ݹ�Ӧ�̵õ�����ĵ�����������
        /// </summary>
        /// <param name="Supplierid"></param>
        /// <returns></returns>
        public int GetShopData(int Supplierid)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("  select count(*) from SupplierAssignRecord ");
            if (Supplierid > 0)
            {
                sb.Append(" where SupplierID = " + Supplierid.ToString());
            }
            object obj = DbHelperSQL.GetSingle(DbHelperSQL.connectionString(), sb.ToString());
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
        /// ����ͼ�еõ����ݡ� 
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataTable getdatafromView(string strWhere)
        {// posid ,shopname ShopMaster ShopMasterPhone dealername SupplierName
            StringBuilder sb = new StringBuilder();
            sb.Append("select *  from View_SupplierAssignRecord ");
            if (strWhere.Length > 0)
                sb.Append(string.Format(" where shopstate=1 and  {0} ",strWhere));

            DataSet ds = DbHelperSQL.Query(DbHelperSQL.connectionString(), sb.ToString());

            return ds.Tables[0];
        }
        /// <summary>
        /// �õ���Ӧ�̵Ĺ�Ӧ����
        /// </summary>
        /// <param name="supplierID"></param>
        /// <returns></returns>
        public DataTable GetSupplierArea(int supplierID)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("select areaname,areaid from areadata where areaid in ( select distinct areaid from View_SupplierAssignRecord");
            if (supplierID > 0)
                sb.Append(string.Format(" where supplierid={0}",supplierID));
            sb.Append(")");
            sb.Append(" order by areaid");
            DataSet ds = DbHelperSQL.Query(DbHelperSQL.connectionString(), sb.ToString());

            return ds.Tables[0];
        }
        public DataTable GetSupplierPro(int supplierID)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("select provincename,areaid,provinceID from provinceData where provinceID in ( select  distinct AssignProID from SupplierAssignRecord ");
            if (supplierID > 0)
                sb.Append(string.Format(" where supplierid={0}", supplierID));
            sb.Append(") order by areaid");
            DataSet ds = DbHelperSQL.Query(DbHelperSQL.connectionString(), sb.ToString());

            return ds.Tables[0];
        }
        /// <summary>
        /// ���ݹ�Ӧ�̵�ID�õ���Ӧ�����и���������POP��Ϣ
        /// </summary>
        /// <param name="supplierID"></param>
        /// <returns></returns>
        public DataTable Getsupplier_popinfo(int supplierID)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("   SELECT  ");
            sb.Append(" [PosID] ���̱�� ,[Shopname] ��������,[Shopsamplename] ���̼�� ,[PostAddress] ����������ַ,[PostCode] �����ʱ�,[ShopPhone] ���̶̹��绰,[LinkMan] �곤,[LinkPhone] �곤�ƶ��绰,[Email] �곤email,[FaxNumber] ���̴������ ");
            sb.Append(" ,[Boolinstall] �Ƿ�������˾ͳһ֧�ְ�װ,[DealerID] һ���ͻ����,[DealerName] һ���ͻ���,(select shopstate from shopstateinfo where id=view_shopinfo.shopstate) as ����״̬,[DepartMent] �������� ");
            sb.Append(" ,[AreaName] ��������,[ProvinceName] ʡ����,[cityname] �ؼ���������,[cityLevel] ���м����м���_�г�����,[townName] ���ؼ���������,TownLevel ���ؼ����м���_�г����� ,[ShopMaster] �������۸����� ");
            sb.Append(" ,[ShopMasterPhone] �������۸������ƶ��绰,(select shoptypename from shoptype where id=view_shopinfo.shoptype) as  �������� ");
            sb.Append(" ,shoplevel ���̼���,[ShopVI] ������������,[ShopArea] Ӫҵ���,[DSRMaster] ����DSR������,[DSRMasterPhone] ����DSR�����˵绰,[VMMaster] ����ʡ��VM������,[VMMasterPhone] ����ʡ��VM�����˵绰,Department_Master ��������VM����,department_MasterPhone ��������VM����绰,[FXID] ֱ���ͻ����,[FXName] ֱ���ͻ��� ");
            sb.Append(" ,[CustomerGroupID] �ϼ��ͻ����ű��,[CustomerGroupName] �ϼ��ͻ�����,[ShopOwnerShip] ���̲�Ȩ��ϵ,[CustomerCard] �ͻ����,[SeatNum] POP���,[POPseat] POP����,[SeatDesc] λ������ ");
            sb.Append(" ,producttypename ���°�����,View_ProductLine.productline POP���°�,[RealHeight] POPʵ��������,[RealWith] POPʵ��������,[POPHeight] POP���ӻ����,[POPWith] POP���ӻ����,[POPPlwz] POP���ӻ���λ��,[POPPljd] POP���ӻ���ƫ��Ƕ�,[POPArea] POP���,[POPMaterial] POP����,[Sexarea] ��Ů����,[TwoSided] �Ƿ�Ϊ˫�� ");
            sb.Append(" ,[Glass] �Ƿ�ճ���ڲ�����,[PlatformWith] �����ռ����mm,[PlatformHeight] �����ռ䳤��mm,[PlatformLong] �����ռ���� ");
            sb.Append(" FROM  ((View_ShopInfo inner join popinfo on View_ShopInfo.shopid=popinfo.shopid) ");
            sb.Append(" left join View_ProductLine on POPInfo.ProductLineID = dbo.View_ProductLine.ProductLineID) ");

            if (supplierID > 0)
            {
                sb.Append(string.Format(" where supplierID={0}", supplierID));
            }

            DataSet ds = DbHelperSQL.Query(DbHelperSQL.connectionString(), sb.ToString());
            return ds.Tables[0];
        }



        public DataTable GetSuplierByProvinceId(int provinceid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select SupplierAssignRecord.SupplierID,SupplierInfo.SupplierName,SupplierInfo.ShortName from SupplierAssignRecord join SupplierInfo on SupplierInfo.SupplierID=SupplierAssignRecord.SupplierID");
            strSql.AppendFormat(" where AssignProID = {0}  group by SupplierID", provinceid);
            DataSet ds = DbHelperSQL.Query(DbHelperSQL.connectionString(), strSql.ToString());

            return ds.Tables[0];

        }


        #endregion  ��Ա����
    }
}

