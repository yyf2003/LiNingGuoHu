using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using LN.DBUtility;//�����������
namespace LN.DAL
{
    /// <summary>
    /// ���ݷ�����ShippingSpeedData��
    /// </summary>
    public class ShippingSpeedData
    {
        public ShippingSpeedData()
        { }
        #region  ��Ա����

        /// <summary>
        /// ����һ������
        /// </summary>
        public int Add(List<string> strSql)
        {
            int _return = 0;
            try
            {
                _return = DbHelperSQL.ExecuteSqlTran(DbHelperSQL.connectionString(), strSql);
            }
            catch (Exception)
            {
                _return = 0;
            }

            return _return;
        }

        /// <summary>
        /// ɾ��һ������
        /// </summary>
        public void Delete(int ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete ShippingSpeedData ");
            strSql.Append(" where ID=@ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)};
            parameters[0].Value = ID;

            DbHelperSQL.ExecuteSql(DbHelperSQL.connectionString(), strSql.ToString(), parameters);
        }


        /// <summary>
        /// �õ�һ������ʵ��
        /// </summary>
        public LN.Model.ShippingSpeedData GetModel(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT [ID],[GoodsOrderNO],[POPCount],[CompanyID],[FHDate],[OperatorID],[DealerID],[SupplierID],[ShopID],[IsState],[Remars],");
            strSql.Append("(SELECT TOP 1 CompanyName FROM PhysicalCompanyData WHERE CompanyID = s.CompanyID) AS CompanyName, ");
            strSql.Append("(SELECT TOP 1 [DealerName] FROM DealerInfo WHERE DealerID = s.DealerID) AS DealerName,");
            strSql.Append("(SELECT TOP 1 [SupplierName] FROM SupplierInfo WHERE SupplierID = s.SupplierID) AS SupplierName,");
            strSql.Append("(SELECT TOP 1 [ShopName] FROM ShopInfo WHERE ShopID = s.ShopID) AS ShopName,");
            strSql.Append(" FROM ShippingSpeedData AS s ");
            strSql.Append(" WHERE s.ID=@ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)};
            parameters[0].Value = ID;
            LN.Model.ShippingSpeedData model = null;
            SqlDataReader reader = DbHelperSQL.ExecuteReader(DbHelperSQL.connectionString(), strSql.ToString(), parameters);

            if (reader.Read())
            {
                model = new LN.Model.ShippingSpeedData();
                if (!string.IsNullOrEmpty(reader.GetInt32(0).ToString()))
                    model.ID = reader.GetInt32(0);

                if (!string.IsNullOrEmpty(reader.GetString(1)))
                    model.GoodsOrderNO = reader.GetString(1);

                if (!string.IsNullOrEmpty(reader.GetInt32(2).ToString()))
                    model.POPCount = reader.GetInt32(2);

                if (!string.IsNullOrEmpty(reader.GetInt32(3).ToString()))
                    model.CompanyID = reader.GetInt32(3);

                if (!string.IsNullOrEmpty(reader.GetDateTime(4).ToString()))
                    model.FHDate = reader.GetDateTime(4);

                if (!string.IsNullOrEmpty(reader.GetInt32(5).ToString()))
                    model.OperatorID = reader.GetInt32(5);

                if (!string.IsNullOrEmpty(reader.GetString(6)))
                    model.DealerID = reader.GetString(6);

                if (!string.IsNullOrEmpty(reader.GetInt32(7).ToString()))
                    model.SupplierID = reader.GetInt32(7);

                if (!string.IsNullOrEmpty(reader.GetInt32(8).ToString()))
                    model.ShopID = reader.GetInt32(8);

                if (!string.IsNullOrEmpty(reader.GetString(9)))
                    model.IsState = reader.GetString(9);

                if (!string.IsNullOrEmpty(reader.GetString(10)))
                    model.Remars = reader.GetString(10);

                if (!string.IsNullOrEmpty(reader.GetString(11)))
                    model.CompanyName = reader.GetString(11);

                if (!string.IsNullOrEmpty(reader.GetString(12)))
                    model.DealerName = reader.GetString(12);

                if (!string.IsNullOrEmpty(reader.GetString(13)))
                    model.SupplierName = reader.GetString(13);

                if (!string.IsNullOrEmpty(reader.GetString(14)))
                    model.ShopName = reader.GetString(14);


            }
            reader.Close();
            return model;
        }
        /// <summary>
        /// �ջ�����
        /// </summary>
        /// <param name="POPID"></param>
        /// <param name="rdate"></param>
        /// <param name="userid"></param>
        /// <param name="fs"></param>
        /// <param name="pj"></param>
        /// <param name="shopid"></param>
        /// <returns></returns>
        public int RecevieGoods(string POPID, string rdate, string userid, string fs, string pj, string shopid)
        {
            StringBuilder sqlstr = new StringBuilder();
            sqlstr.Append("update ShippingSpeedData");
            sqlstr.Append(" set GetInState='���ջ�'");
            sqlstr.Append(",GetInUserID=" + userid);
            sqlstr.Append(",SHScore=" + fs);
            sqlstr.Append(",SHDate='" + rdate + "'");
            sqlstr.Append(",GetInFeedBack='" + pj + "'");
            sqlstr.Append(" where POPID in (SELECT POPID FROM POPLaunch WHERE BeginDate<=getdate() and EndDate>=getdate()) and goodsorderno in (" + shopid + ")");

            return DbHelperSQL.ExecuteSql(DbHelperSQL.connectionString(), sqlstr.ToString());
        }
        /// <summary>
        /// ��������б�
        /// </summary>
        public IList<LN.Model.ShippingSpeedData> GetList(string strWhere)
        {
            IList<LN.Model.ShippingSpeedData> list = new List<LN.Model.ShippingSpeedData>();
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT [ID],[GoodsOrderNO],[POPCount],[CompanyID],[FHDate],[OperatorID],[DealerID],[SupplierID],[ShopID],[IsState],[Remars],");
            strSql.Append("(SELECT TOP 1 CompanyName FROM PhysicalCompanyData WHERE CompanyID = s.CompanyID) AS CompanyName, ");
            strSql.Append("(SELECT TOP 1 [DealerName] FROM DealerInfo WHERE DealerID = s.DealerID) AS DealerName,");
            strSql.Append("(SELECT TOP 1 [SupplierName] FROM SupplierInfo WHERE SupplierID = s.SupplierID) AS SupplierName,");
            strSql.Append("(SELECT TOP 1 [ShopName] FROM ShopInfo WHERE ShopID = s.ShopID) AS ShopName,");
            strSql.Append(" FROM ShippingSpeedData AS s ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" WHERE " + strWhere);
            }
            SqlDataReader reader = DbHelperSQL.ExecuteReader(DbHelperSQL.connectionString(), strSql.ToString());
            while (reader.Read())
            {
                LN.Model.ShippingSpeedData model = new LN.Model.ShippingSpeedData();
                if (!string.IsNullOrEmpty(reader.GetInt32(0).ToString()))
                    model.ID = reader.GetInt32(0);

                if (!string.IsNullOrEmpty(reader.GetString(1)))
                    model.GoodsOrderNO = reader.GetString(1);

                if (!string.IsNullOrEmpty(reader.GetInt32(2).ToString()))
                    model.POPCount = reader.GetInt32(2);

                if (!string.IsNullOrEmpty(reader.GetInt32(3).ToString()))
                    model.CompanyID = reader.GetInt32(3);

                if (!string.IsNullOrEmpty(reader.GetDateTime(4).ToString()))
                    model.FHDate = reader.GetDateTime(4);

                if (!string.IsNullOrEmpty(reader.GetInt32(5).ToString()))
                    model.OperatorID = reader.GetInt32(5);

                if (!string.IsNullOrEmpty(reader.GetString(6)))
                    model.DealerID = reader.GetString(6);

                if (!string.IsNullOrEmpty(reader.GetInt32(7).ToString()))
                    model.SupplierID = reader.GetInt32(7);

                if (!string.IsNullOrEmpty(reader.GetInt32(8).ToString()))
                    model.ShopID = reader.GetInt32(8);

                if (!string.IsNullOrEmpty(reader.GetString(9)))
                    model.IsState = reader.GetString(9);

                if (!string.IsNullOrEmpty(reader.GetString(10)))
                    model.Remars = reader.GetString(10);

                if (!string.IsNullOrEmpty(reader.GetString(11)))
                    model.CompanyName = reader.GetString(11);

                if (!string.IsNullOrEmpty(reader.GetString(12)))
                    model.DealerName = reader.GetString(12);

                if (!string.IsNullOrEmpty(reader.GetString(13)))
                    model.SupplierName = reader.GetString(13);

                if (!string.IsNullOrEmpty(reader.GetString(14)))
                    model.ShopName = reader.GetString(14);

                list.Add(model);
            }
            reader.Close();
            return list;
        }

        /// <summary>
        /// ����ShippingSpeedData�е�����
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public int GetShippingPOPDataDone(string strWhere)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("SELECT count(*) from ShippingSpeedData where 1=1 ");
            if (strWhere != "")
            {
                sb.Append(" and " + strWhere);
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
        /// �õ��Ѿ�����pop����
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public int GetShippingPOPData(int SupplierID)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(" select  count(distinct shopid) from ShippingSpeedData ");
            if (SupplierID > 0)
            {
                sb.Append("  where SupplierID = " + SupplierID.ToString());
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
        /// ������POP�б��õ����еķ�����pop��Ϣ
        /// </summary>
        /// <param name="shopid"></param>
        /// <returns></returns>
        public DataSet GetShippingPOPDataInfo(int shopid,string popid)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(" select * from  popinfo,imagetopop where  popinfo.id=imagetopop.popinfoid and  imagetopop.shopid = " + shopid +" and popid='"+popid+"'");
            return DbHelperSQL.Query(DbHelperSQL.connectionString(), sb.ToString());
        }
        
        /// <summary>
        /// һ���ͻ������Ѿ���װ�ĵ����б�
        /// </summary>
        /// <param name="DealerID">һ���ͻ����</param>
        /// <param name="FXID">ֱ���ͻ����</param>
        /// <param name="ShopID">���̱��</param>
        /// <param name="ShopName">��������</param>
        /// <param name="OrderField">�����ֶ�</param>
        /// <param name="pageSize">ÿҳ��ʾ�����б�ĸ���</param>
        /// <param name="pageIndex">��ǰҳ</param>
        /// <param name="TotalRecord">��������</param>
        /// <returns>�����б���</returns>
        public DataTable GetConfirmShopListByDealerID(string DealerID, string FXID, string ShopID, string ShopName, string OrderField, int pageSize, int pageIndex, ref int TotalNumber)
        {
            DataTable dt = null;
            SqlParameter[] parameters = {
					new SqlParameter("@DealerID", SqlDbType.VarChar,20),
                    new SqlParameter("@FXID", SqlDbType.VarChar,20),
                    new SqlParameter("@ShopID", SqlDbType.VarChar,20),
                    new SqlParameter("@ShopName", SqlDbType.VarChar,200),
                    new SqlParameter("@OrderField", SqlDbType.VarChar,1000),
                    new SqlParameter("@pageSize", SqlDbType.Int,4),
                    new SqlParameter("@pageIndex", SqlDbType.Int,4),
                    new SqlParameter("@TotalRecord", SqlDbType.Int,4)};
            parameters[0].Value = DealerID;
            parameters[1].Value = FXID;
            parameters[2].Value = ShopID;
            parameters[3].Value = ShopName;
            parameters[4].Value = OrderField;
            parameters[5].Value = pageSize;
            parameters[6].Value = pageIndex;
            parameters[7].Direction = ParameterDirection.Output;

            DataSet ds = DbHelperSQL.RunProcedure(DbHelperSQL.connectionString(), "GetConfirmShopListByDealerID", parameters, "tb");
            if (ds != null)
                dt = ds.Tables[0];
            TotalNumber = (int)parameters[7].Value;

            return dt;
        }

        /// <summary>
        /// ֱ���ͻ������Ѿ���װ�ĵ����б�
        /// </summary>
        /// <param name="FXID">ֱ���ͻ����</param>
        /// <param name="ShopID">���̱��</param>
        /// <param name="ShopName">��������</param>
        /// <param name="OrderField">�����ֶ�</param>
        /// <param name="pageSize">ÿҳ��ʾ�����б�ĸ���</param>
        /// <param name="pageIndex">��ǰҳ</param>
        /// <param name="TotalRecord">��������</param>
        /// <returns>�����б���</returns>
        public DataTable GetConfirmShopListByFXID(string FXID, string ShopID, string ShopName, string OrderField, int pageSize, int pageIndex, ref int TotalNumber)
        {
            DataTable dt = null;
            SqlParameter[] parameters = {
                    new SqlParameter("@FXID", SqlDbType.VarChar,20),
                    new SqlParameter("@ShopID", SqlDbType.VarChar,20),
                    new SqlParameter("@ShopName", SqlDbType.VarChar,200),
                    new SqlParameter("@OrderField", SqlDbType.VarChar,1000),
                    new SqlParameter("@pageSize", SqlDbType.Int,4),
                    new SqlParameter("@pageIndex", SqlDbType.Int,4),
                    new SqlParameter("@TotalRecord", SqlDbType.Int,4)};
            parameters[0].Value = FXID;
            parameters[1].Value = ShopID;
            parameters[2].Value = ShopName;
            parameters[3].Value = OrderField;
            parameters[4].Value = pageSize;
            parameters[5].Value = pageIndex;
            parameters[6].Direction = ParameterDirection.Output;

            DataSet ds = DbHelperSQL.RunProcedure(DbHelperSQL.connectionString(), "GetConfirmShopListByFXID", parameters, "tb");
            if (ds != null)
                dt = ds.Tables[0];
            TotalNumber = (int)parameters[6].Value;

            return dt;
        }
        /// <summary>
        /// �õ��շ������еĵ��̵Ļ�����Ϣ
        /// </summary>
        /// <param name="StrWhere"></param>
        /// <returns></returns>
        public DataTable GetSubList(string StrWhere)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("select areaname ʡ��,provincename ʡ��,cityname ��,view_shopinfo.posid ���̱��,view_shopinfo.shopname ��������,linkman �곤,linkphone �곤�绰,shopmaster ���̸�����,shopmasterphone �����˵绰,shopphone ���̵绰,dealername һ���ͻ�,suppliername ��Ӧ�� from view_shopinfo ,View_shippingSpeed where view_shopinfo.shopid=View_shippingSpeed.shopid ");
            if (StrWhere.Length > 0)
                sb.Append(StrWhere);
            DataSet ds = DbHelperSQL.Query(DbHelperSQL.connectionString(), sb.ToString());
            return ds.Tables[0];
        }
        /// <summary>
        /// �õ���Ӧ�ķ�������
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataTable GetFHID(string strWhere)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("select GoodsOrderNO from ShippingSpeedData ");
            if (strWhere.Length > 0)
            {
                sb.Append(" where "+strWhere);
            }
            DataSet ds = DbHelperSQL.Query(DbHelperSQL.connectionString(), sb.ToString());
            return ds.Tables[0];
        }
        /// <summary>
        /// �õ������б�
        /// </summary>
        /// <param name="strwhere"></param>
        /// <param name="popid"></param>
        /// <param name="fhtype"></param>
        /// <returns></returns>
        public DataSet GetFHAnaysis(string strwhere, string popid, string fhtype,string beginDate,string endDate)
        {
            SqlParameter[] para ={ 
               new SqlParameter("@strWhere",SqlDbType.VarChar,2000),
               new SqlParameter("@POPID",SqlDbType.VarChar,30),
               new SqlParameter("@FHType",SqlDbType.VarChar,20),
               new SqlParameter("@beginDate",SqlDbType.VarChar,40),
               new SqlParameter("@endDate",SqlDbType.VarChar,40)
            };
            para[0].Value = strwhere;
            para[1].Value = popid;
            para[2].Value = fhtype;
            if (beginDate.Length > 0)
                para[3].Value = beginDate+" 00:00:00";
            else
                para[3].Value = "";
            if (endDate.Length > 0)
                para[4].Value =endDate+" 00:00:00";
            else
                para[4].Value = "";
            DataSet ds = DbHelperSQL.RunProcedure(DbHelperSQL.connectionString(), "Pro_supplierFHAnalysis", para, "ds");
            return ds;
        }

        /// <summary>
        /// �õ��ջ��б�
        /// </summary>
        /// <param name="strwhere"></param>
        /// <param name="popid"></param>
        /// <param name="fhtype"></param>
        /// <returns></returns>
        public DataSet GetSHAnaysis(string strwhere)
        {
            SqlParameter[] para ={ 
               new SqlParameter("@strWhere",SqlDbType.VarChar,2000)
            
            };
            para[0].Value = strwhere;


            DataSet ds = DbHelperSQL.RunProcedure(DbHelperSQL.connectionString(), "Pro_ShopSHAnalysis", para, "ds");
            return ds;
        }
        #endregion  ��Ա����
    }
}

