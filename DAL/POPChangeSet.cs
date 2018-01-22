using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using System.Collections.Generic;
using LN.DBUtility;//�����������
namespace LN.DAL
{
	/// <summary>
	/// ���ݷ�����POPChangeSet��
	/// </summary>
	public class POPChangeSet
	{
		public POPChangeSet()
		{}
		#region  ��Ա����

		/// <summary>
		/// �õ����ID
		/// </summary>
		public int GetMaxId()
		{
            return DbHelperSQL.GetMaxID(DbHelperSQL.connectionString(), "ID", "POPChangeSet"); 
		}

		/// <summary>
		/// �Ƿ���ڸü�¼
		/// </summary>
		public bool Exists(int ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from POPChangeSet");
			strSql.Append(" where ID=@ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)};
			parameters[0].Value = ID;

            return DbHelperSQL.Exists(DbHelperSQL.connectionString(), strSql.ToString(), parameters);
		}


		/// <summary>
		/// ����һ������
		/// </summary>
		public int Add(LN.Model.POPChangeSet model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into POPChangeSet(");
            strSql.Append("POPID,AreaID,ProvinceID,CityID,ShopID,CatenaProID,ChangeSetDesc)");
			strSql.Append(" values (");
            strSql.Append("@POPID,@AreaID,@ProvinceID,@CityID,@ShopID,@CatenaProID,@ChangeSetDesc)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@POPID", SqlDbType.Int,4),
					new SqlParameter("@AreaID", SqlDbType.Int,4),
					new SqlParameter("@ProvinceID", SqlDbType.Int,4),
					new SqlParameter("@CityID", SqlDbType.Int,4),
                    new SqlParameter("@ShopID", SqlDbType.Int,4),
					new SqlParameter("@CatenaProID", SqlDbType.Int,4),
					new SqlParameter("@ChangeSetDesc", SqlDbType.VarChar,500)};
			parameters[0].Value = model.POPID;
			parameters[1].Value = model.AreaID;
			parameters[2].Value = model.ProvinceID;
			parameters[3].Value = model.CityID;
            parameters[4].Value = model.ShopID;
			parameters[5].Value = model.CatenaProID;
			parameters[6].Value = model.ChangeSetDesc;

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
		public void Update(LN.Model.POPChangeSet model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update POPChangeSet set ");
			strSql.Append("POPID=@POPID,");
			strSql.Append("AreaID=@AreaID,");
			strSql.Append("ProvinceID=@ProvinceID,");
			strSql.Append("CityID=@CityID,");
            strSql.Append("ShopID=@ShopID,");
			strSql.Append("CatenaProID=@CatenaProID,");
			strSql.Append("ChangeSetDesc=@ChangeSetDesc");
			strSql.Append(" where ID=@ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4),
					new SqlParameter("@POPID", SqlDbType.Int,4),
					new SqlParameter("@AreaID", SqlDbType.Int,4),
					new SqlParameter("@ProvinceID", SqlDbType.Int,4),
					new SqlParameter("@CityID", SqlDbType.Int,4),
                    new SqlParameter("@ShopID", SqlDbType.Int,4),
					new SqlParameter("@CatenaProID", SqlDbType.Int,4),
					new SqlParameter("@ChangeSetDesc", SqlDbType.VarChar,500)};
			parameters[0].Value = model.ID;
			parameters[1].Value = model.POPID;
			parameters[2].Value = model.AreaID;
			parameters[3].Value = model.ProvinceID;
			parameters[4].Value = model.CityID;
            parameters[5].Value = model.ShopID;
			parameters[6].Value = model.CatenaProID;
			parameters[7].Value = model.ChangeSetDesc;

            DbHelperSQL.ExecuteSql(DbHelperSQL.connectionString(), strSql.ToString(), parameters);
		}

		/// <summary>
		/// ɾ��һ������
		/// </summary>
		public void Delete(int ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete POPChangeSet ");
			strSql.Append(" where ID=@ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)};
			parameters[0].Value = ID;

            DbHelperSQL.ExecuteSql(DbHelperSQL.connectionString(), strSql.ToString(), parameters);
		}


		/// <summary>
		/// �õ�һ������ʵ��
		/// </summary>
		public LN.Model.POPChangeSet GetModel(int ID)
		{
			
			StringBuilder strSql=new StringBuilder();
            strSql.Append("select  top 1 ID,POPID,AreaID,ProvinceID,CityID,ShopID,CatenaProID,ChangeSetDesc from POPChangeSet ");
			strSql.Append(" where ID=@ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)};
			parameters[0].Value = ID;

            LN.Model.POPChangeSet model = null;
            SqlDataReader reader = DbHelperSQL.ExecuteReader(DbHelperSQL.connectionString(), strSql.ToString(), parameters);
            if (reader.Read())
			{
                model = new LN.Model.POPChangeSet();
                if (!string.IsNullOrEmpty(reader["ID"].ToString()))
				{
                    model.ID = int.Parse(reader["ID"].ToString());
				}
				if(!string.IsNullOrEmpty(reader["POPID"].ToString()))
				{
                    model.POPID = reader["POPID"].ToString();
				}
				if(!string.IsNullOrEmpty(reader["AreaID"].ToString()))
				{
                    model.AreaID = int.Parse(reader["AreaID"].ToString());
				}
				if(!string.IsNullOrEmpty(reader["ProvinceID"].ToString()))
				{
                    model.ProvinceID = int.Parse(reader["ProvinceID"].ToString());
				}
				if(!string.IsNullOrEmpty(reader["CityID"].ToString()))
				{
                    model.CityID = int.Parse(reader["CityID"].ToString());
				}
                if (!string.IsNullOrEmpty(reader["ShopID"].ToString() ))
                {
                    model.ShopID = int.Parse(reader["ShopID"].ToString());
                }
                if (!string.IsNullOrEmpty(reader["CatenaProID"].ToString()))
				{
                    model.CatenaProID = int.Parse(reader["CatenaProID"].ToString());
				}
                model.ChangeSetDesc = reader["ChangeSetDesc"].ToString();
				
			}
            reader.Close();
            return model;
		}

        	/// <summary>
		/// ��������б�
		/// </summary>
        public DataTable  Getview_List(string strWhere)
        {
            string sqlstr = "select * from View_POPChangeSetNoprice ";
            if (strWhere.Length > 0)
            {
                sqlstr = sqlstr + " where "+strWhere;
            }

            DataSet ds = DbHelperSQL.Query(DbHelperSQL.connectionString(), sqlstr);
            if (ds != null)
                return ds.Tables[0];
            else
                return null;
        }

        /// <summary>
        /// ��������б�
        /// </summary>
        public DataTable GetPOPprice_List(string strWhere)
        {
            string sqlstr = "select *,POPArea*POPprice as totalprice from View_imgToPOP  ";
            if (strWhere.Length > 0)
            {
                sqlstr = sqlstr + " where " + strWhere;
            }

            DataSet ds = DbHelperSQL.Query(DbHelperSQL.connectionString(), sqlstr);
            if (ds != null)
                return ds.Tables[0];
            else
                return null;
        }

		/// <summary>
		/// ��������б�
		/// </summary>
        public List<LN.Model.POPChangeSet> GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ID,POPID,AreaID,ProvinceID,CityID,ShopID,CatenaProID,ChangeSetDesc ");
			strSql.Append(" FROM POPChangeSet ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}

            List<LN.Model.POPChangeSet> modelList = new List<LN.Model.POPChangeSet>();
            SqlDataReader reader = DbHelperSQL.ExecuteReader(DbHelperSQL.connectionString(), strSql.ToString());
            if (reader.HasRows)
            {
                LN.Model.POPChangeSet model;
                while(reader.Read())
                {
                    model = new LN.Model.POPChangeSet();
                    if (!string.IsNullOrEmpty(reader["ID"].ToString()))
                    {
                        model.ID = int.Parse(reader["ID"].ToString());
                    }
                    if (!string.IsNullOrEmpty(reader["POPID"].ToString()))
                    {
                        model.POPID = reader["POPID"].ToString();
                    }
                    if (!string.IsNullOrEmpty(reader["AreaID"].ToString()))
                    {
                        model.AreaID = int.Parse(reader["AreaID"].ToString());
                    }
                    if (!string.IsNullOrEmpty(reader["ProvinceID"].ToString()))
                    {
                        model.ProvinceID = int.Parse(reader["ProvinceID"].ToString());
                    }
                    if (!string.IsNullOrEmpty(reader["CityID"].ToString()))
                    {
                        model.CityID = int.Parse(reader["CityID"].ToString());
                    }
                    if (!string.IsNullOrEmpty(reader["ShopID"].ToString()))
                    {
                        model.ShopID = int.Parse(reader["ShopID"].ToString());
                    }
                    if (!string.IsNullOrEmpty(reader["CatenaProID"].ToString()))
                    {
                        model.CatenaProID = int.Parse(reader["CatenaProID"].ToString());
                    }
                    model.ChangeSetDesc = reader["ChangeSetDesc"].ToString();
                    modelList.Add(model);
                }
            }
            reader.Close();
            return modelList;
		}
        /// <summary>
        /// ��Ʒ��������
        /// </summary>
        /// <param name="sqlstr"></param>
        public void CitySet(string POPID,string CatenaProID, string sqlstr)
        {
            List<string> list = new List<string>();
            //string delstr = "delete POPChangeSet where POPID='" + POPID + "' and CatenaProID=" + CatenaProID;
            string delstr = "delete POPChangeSet where POPID='" + POPID + "'";

            string Sql = "insert into POPChangeSet (POPID,AreaID,ProvinceID,CityID,TownID,ShopID,CatenaProID,ChangeSetDesc) "+sqlstr;
            list.Add(delstr);
            list.Add(Sql);
            DbHelperSQL.ExecuteSqlTran(DbHelperSQL.connectionString(), list);
        }

        /// <summary>
        /// ��ȡָ������������ķ���ID
        /// </summary>
        /// <param name="ShopID">���̱��</param>
        /// <returns>����ָ�����̲���ķ���ID</returns>
        public string GetPOPIDByShopID(string ShopID)
        {
            string _return = String.Empty;
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("SELECT TOP 1 POPID FROM POPChangeSet where ShopID={0} AND ", ShopID);
            sb.Append(" POPID in (SELECT POPID FROM POPLaunch WHERE BeginDate<=getdate() and EndDate>=getdate())");

            object obj = DbHelperSQL.GetSingle(DbHelperSQL.connectionString(), sb.ToString());
            if (obj != null)
                _return = obj.ToString();

            return _return;
        }


        /// <summary>
        /// �������̼���pop���� add  by mhj 2012.06.04
        /// </summary>
        /// <param name="strShopid"></param>
        /// <returns></returns>
        public int JoinPopLanuch(string strShopid)
        {
            string strSql = "delete POPChangeSet where shopid=" + strShopid + " and popid=(select top 1 popid from [POPLaunch] order by id desc);" +
                            "insert into POPChangeSet (POPID,AreaID,ProvinceID,CityID,TownID,ShopID,CatenaProID,ChangeSetDesc)"+
                            "select (select top 1 popid from [POPLaunch] order by id desc),"+
                            "areaid,ProvinceID,0,0,ShopID,0,''  from shopinfo where shopid=" + strShopid;
            return DbHelperSQL.ExecuteSql(DbHelperSQL.connectionString(), strSql);
        }

        /// <summary>
        /// �������̼���pop���� add  by mhj 2015.05.10
        /// </summary>
        /// <param name="strPosId"></param>
        /// <returns></returns>
        public int JoinPopLanuchByPosId(string strPosId)
        {
            string strSql = "declare @shopid varchar(50);select @shopid=shopid from shopinfo where posid='" + strPosId + "';" +
                            "delete POPChangeSet where shopid=@shopid and popid=(select top 1 popid from [POPLaunch] order by id desc);" +
                            "insert into POPChangeSet (POPID,AreaID,ProvinceID,CityID,TownID,ShopID,CatenaProID,ChangeSetDesc)" +
                            "select (select top 1 popid from [POPLaunch] order by id desc)," +
                            "areaid,ProvinceID,0,0,ShopID,0,''  from shopinfo where shopid=@shopid";
            return DbHelperSQL.ExecuteSql(DbHelperSQL.connectionString(), strSql);
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
			parameters[0].Value = "POPChangeSet";
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

