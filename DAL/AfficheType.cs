using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using LN.DBUtility;//�����������
namespace LN.DAL
{
    /// <summary>
    /// ���ݷ�����AfficheType��
    /// </summary>
    public class AfficheType
    {
        public AfficheType()
        { }
        #region  ��Ա����

        /// <summary>
        /// �õ����ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperSQL.GetMaxID(DbHelperSQL.connectionString(), "ID", "AfficheType");
        }

        /// <summary>
        /// �Ƿ���ڸü�¼
        /// </summary>
        public bool Exists(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from AfficheType");
            strSql.Append(" where ID=@ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)};
            parameters[0].Value = ID;

            return DbHelperSQL.Exists(DbHelperSQL.connectionString(), strSql.ToString(), parameters);
        }


        /// <summary>
        /// ����һ������
        /// </summary>
        public int Add(LN.Model.AfficheType model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into AfficheType(");
            strSql.Append("Type)");
            strSql.Append(" values (");
            strSql.Append("@Type)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@Type", SqlDbType.NVarChar,20)};
            parameters[0].Value = model.Type;
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
        public void Update(string Typename, int Typeid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update AfficheType set ");
            strSql.Append("Type=@Type ");
            strSql.Append(" where ID=@ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4),
					new SqlParameter("@Type", SqlDbType.NVarChar,20)};
            parameters[0].Value = Typeid;
            parameters[1].Value = Typename;
            DbHelperSQL.ExecuteSql(DbHelperSQL.connectionString(), strSql.ToString(), parameters);
        }

        /// <summary>
        /// ɾ��һ������
        /// </summary>
        public void Delete(int ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("update  AfficheType ");
            strSql.Append("set IsDel =1  ");
            strSql.Append(" where ID=@ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)};
            parameters[0].Value = ID;

            DbHelperSQL.ExecuteSql(DbHelperSQL.connectionString(), strSql.ToString(), parameters);
        }


        /// <summary>
        /// �õ�һ������ʵ��
        /// </summary>
        public LN.Model.AfficheType GetModel(int ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 ID,Type,IsDel from AfficheType ");
            strSql.Append(" where ID=@ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)};
            parameters[0].Value = ID;

            LN.Model.AfficheType model = new LN.Model.AfficheType();
            DataSet ds = DbHelperSQL.Query(DbHelperSQL.connectionString(), strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["ID"].ToString() != "")
                {
                    model.ID = int.Parse(ds.Tables[0].Rows[0]["ID"].ToString());
                }
                model.Type = ds.Tables[0].Rows[0]["Type"].ToString();
                if (ds.Tables[0].Rows[0]["IsDel"].ToString() != "")
                {
                    model.IsDel = int.Parse(ds.Tables[0].Rows[0]["IsDel"].ToString());
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
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ID,Type,IsDel ");
            strSql.Append(" FROM AfficheType  ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by id desc   ");

            return DbHelperSQL.Query(DbHelperSQL.connectionString(), strSql.ToString());
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
            parameters[0].Value = "AfficheType";
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

