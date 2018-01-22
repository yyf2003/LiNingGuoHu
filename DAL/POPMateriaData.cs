using System;
using System.Data;
using System.Text;
using System.Collections.Generic;
using System.Data.SqlClient;
using LN.DBUtility;//�����������
namespace LN.DAL
{
	/// <summary>
	/// ���ݷ�����POPMateriaData��
	/// </summary>
	public class POPMateriaData
	{
		public POPMateriaData()
		{}
		#region  ��Ա����

		/// <summary>
		/// ����һ������
		/// </summary>
        public int Add(string MateriaPro,string UserID,string cltype)
		{
            int _return = 0;
			StringBuilder strSql=new StringBuilder();

			SqlParameter[] parameters = {
					new SqlParameter("@MateriaPro", SqlDbType.VarChar,50),
                    new SqlParameter("@UserID", SqlDbType.VarChar,50),
                    new SqlParameter("@cltype", SqlDbType.VarChar,50)
            };
			parameters[0].Value = MateriaPro;
            //parameters[1].Value = UserID;
            parameters[1].Value = 0;
            parameters[2].Value = cltype;
            object obj = DbHelperSQL.RunProcedure(DbHelperSQL.connectionString(), "P_AddSupplierMaterial", parameters, out _return);
            if (obj == null)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(_return);
            }
		}
		/// <summary>
		/// ����һ������
		/// </summary>
		public int Update(LN.Model.POPMateriaData model)
		{
            int _return = 0;
			StringBuilder strSql=new StringBuilder();
            strSql.Append("UPDATE POPMateriaData SET ");
			strSql.Append("MateriaPro=@MateriaPro");
            strSql.Append(" WHERE MateriaID=@MateriaID; ");
            strSql.Append(" SELECT @@ROWCOUNT; ");
			SqlParameter[] parameters = {
					new SqlParameter("@MateriaID", SqlDbType.Int,4),
					new SqlParameter("@MateriaPro", SqlDbType.VarChar,50)};
			parameters[0].Value = model.MateriaID;
			parameters[1].Value = model.MateriaPro;

            object obj = DbHelperSQL.GetSingle(DbHelperSQL.connectionString(), strSql.ToString(), parameters);
            if (obj != null)
                _return = Convert.ToInt32(obj);

            return _return;
		}

		/// <summary>
		/// ɾ��һ������
		/// </summary>
		public void Delete(int MateriaID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete POPMateriaData ");
			strSql.Append(" where MateriaID=@MateriaID ");
			SqlParameter[] parameters = {
					new SqlParameter("@MateriaID", SqlDbType.Int,4)};
			parameters[0].Value = MateriaID;

            DbHelperSQL.ExecuteSql(DbHelperSQL.connectionString(), strSql.ToString(), parameters);
		}


		/// <summary>
		/// �õ�һ������ʵ��
		/// </summary>
        public LN.Model.POPMateriaData GetModel(int MateriaID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 MateriaID,MateriaPro,SupplierID,IsDelete from POPMateriaData ");
            strSql.Append(" where MateriaID=@MateriaID ");
            SqlParameter[] parameters = {
					new SqlParameter("@MateriaID", SqlDbType.Int,4)};
            parameters[0].Value = MateriaID;

            LN.Model.POPMateriaData model = null;
            SqlDataReader reader = DbHelperSQL.ExecuteReader(DbHelperSQL.connectionString(), strSql.ToString(), parameters);
            if (reader.Read())
            {
                model = new LN.Model.POPMateriaData();
                if (!string.IsNullOrEmpty(reader.GetInt32(0).ToString()))
                {
                    model.MateriaID = reader.GetInt32(0);
                }
                if (!string.IsNullOrEmpty(reader.GetString(1)))
                {
                    model.MateriaPro = reader.GetString(0);
                }
                if (!string.IsNullOrEmpty(reader.GetInt32(2).ToString()))
                {
                    model.SupplierID = reader.GetInt32(2);
                }
                if (!string.IsNullOrEmpty(reader.GetInt32(3).ToString()))
                {
                    model.IsDelete = reader.GetInt32(3);
                }
            }
            reader.Close();
            return model;
        }
        public DataTable GetTable(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT [MateriaID],[MateriaPro],[SupplierID],[IsDelete],'0' as popprice  ");
            strSql.Append(" FROM [POPMateriaData] ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" WHERE " + strWhere);
            }

            DataSet ds = DbHelperSQL.Query(DbHelperSQL.connectionString(), strSql.ToString());
            return ds.Tables[0];
        }
        /// <summary>
        /// ��ò��������б�
        /// </summary>
        public List<LN.Model.POPMateriaData> GetList(string strWhere)
        {
            List<LN.Model.POPMateriaData> modelList = new List<LN.Model.POPMateriaData>();
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT [MateriaID],[MateriaPro],[SupplierID],[IsDelete] ");
            strSql.Append(" FROM [POPMateriaData] ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" WHERE " + strWhere);
            }
            System.Data.SqlClient.SqlDataReader reader = DbHelperSQL.ExecuteReader(DbHelperSQL.connectionString(), strSql.ToString());
            while (reader.Read())
            {
                LN.Model.POPMateriaData model = new LN.Model.POPMateriaData();
                if (!string.IsNullOrEmpty(reader.GetInt32(0).ToString()))
                {
                    model.MateriaID = reader.GetInt32(0);
                }
                if (!string.IsNullOrEmpty(reader.GetString(1)))
                {
                    model.MateriaPro = reader.GetString(1);
                }
                if (!string.IsNullOrEmpty(reader.GetInt32(2).ToString()))
                {
                    model.SupplierID = reader.GetInt32(2);
                }
                modelList.Add(model);
            }
            reader.Close();
            return modelList;
        }

		/// <summary>
		/// ��ò������������б�
		/// </summary>
        public List<LN.Model.POPMateriaData> GetMateriaList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
            strSql.Append("select distinct materiapro  ");
			strSql.Append(" FROM POPMateriaData ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
            System.Data.SqlClient.SqlDataReader reader = DbHelperSQL.ExecuteReader(DbHelperSQL.connectionString(), strSql.ToString());
            List<LN.Model.POPMateriaData> modelList = new List<LN.Model.POPMateriaData>();
            LN.Model.POPMateriaData model = null;
            while (reader.Read())
            {
                model = new LN.Model.POPMateriaData();
                if (!string.IsNullOrEmpty(reader.GetString(0)))
                {
                    model.MateriaPro = reader.GetString(0);
                }

                modelList.Add(model);
            }
            reader.Close();
            return modelList;
		}

        /// <summary>
        /// �������AJAX��ҳ�б�
        /// </summary>
        /// <param name="model">��ҳʵ��</param>
        /// <returns>���ػ�ȡ�����б���</returns>
        public DataTable GetMateriaListPageByID(LN.Model.PageModel model, out int TotalNumber)
        {
            DataTable dt = GetTableListSqlExec.GetList(model, out TotalNumber);
            if (dt != null)
                return dt;
            else
                return null;

        }

        /// <summary>
        /// �õ�ָ���û����ڹ�Ӧ�����ڲ��ϱ����嵥
        /// </summary>
        /// <param name="userID">�û����</param>
        /// <returns>���ز��ϱ����嵥�б�</returns>
        public DataTable GetMaterialPriceByUserID(string suppilerid)
        {
            DataTable dt = null;
            SqlParameter[] parameters = {
					new SqlParameter("@suppilerid", SqlDbType.Int,4)};
            parameters[0].Value = int.Parse(suppilerid);

            DataSet ds = DbHelperSQL.RunProcedure(DbHelperSQL.connectionString(), "P_ShowMaterialPrice", parameters, "tb");
            if (ds != null)
                dt = ds.Tables[0];

            return dt;

        }

        /// <summary>
        /// �޸�ָ�����ϵ�״̬(ʹ�� �� ����)
        /// </summary>
        /// <param name="mID">���ϱ��</param>
        /// <param name="isDelete">״̬</param>
        /// <returns>���ؽ��</returns>
        public int IsDelete(int mID, int isDelete)
        {
            int _return = 0;
            StringBuilder strSql = new StringBuilder();
            strSql.Append("UPDATE POPMateriaData SET ");
            strSql.Append("IsDelete=@IsDelete");
            strSql.Append(" WHERE MateriaID=@MateriaID; ");
            strSql.Append(" SELECT @@ROWCOUNT; ");
            SqlParameter[] parameters = {
					new SqlParameter("@MateriaID", SqlDbType.Int,4),
					new SqlParameter("@IsDelete", SqlDbType.Int,4)};
            parameters[0].Value = mID;
            parameters[1].Value = isDelete;

            object obj = DbHelperSQL.GetSingle(DbHelperSQL.connectionString(), strSql.ToString(), parameters);
            if (obj != null)
                _return = Convert.ToInt32(obj);

            return _return;
        }
        /// <summary>
        /// ���ݵ����Ƿ�֧�ְ�װ�õ���Ӧ�Ĳ����б�
        /// </summary>
        /// <param name="shopid"></param>
        /// <returns></returns>
        public DataTable GetMaterialByshopID(string shopid)
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("select distinct MateriaID, materiapro from POPMateriaData ");
            sb.Append(" where  IsSupport=2 or  IsSupport=(select Boolinstall from shopinfo where shopid=");
            sb.Append(shopid);
            sb.Append(")");

            DataSet ds = DbHelperSQL.Query(DbHelperSQL.connectionString(), sb.ToString());
            return ds.Tables[0];
        }
        public DataTable GetMaterialListData(string IsDelete)
        {
            string str = "select MateriaPro ����,(case when (IsSupport=1) then  '֧�ְ�װʹ��' when (IsSupport=2) then  'ͨ��' when (IsSupport=0) then  '��֧��ʹ��' end ) �������� from dbo.POPMateriaData where isdelete= " + int.Parse(IsDelete);
            DataSet ds = DbHelperSQL.Query(DbHelperSQL.connectionString(), str);
            return ds.Tables[0];
        }
		#endregion  ��Ա����
	}
}

