using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using System.Collections.Generic;
using LN.DBUtility;//�����������
namespace LN.DAL
{
	/// <summary>
	/// ���ݷ�����TownCityLevel��
	/// </summary>
	public class TownCityLevel
	{
		public TownCityLevel()
		{}
        #region  ��Ա����


        /// <summary>
        /// �õ�һ������ʵ��
        /// </summary>
        public LN.Model.TownCityLevel GetModel(int TCL_Id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 TCL_Id,TCL_Name from TownCityLevel where TCL_Id=@TCL_Id ");
            SqlParameter[] parameters = {
					new SqlParameter("@TCL_Id", SqlDbType.Int,4)};
            parameters[0].Value = TCL_Id;

            LN.Model.TownCityLevel model = null;
            SqlDataReader reader = DbHelperSQL.ExecuteReader(DbHelperSQL.connectionString(), strSql.ToString(), parameters);
            if (reader.Read())
            {
                model = new LN.Model.TownCityLevel();
                if (!string.IsNullOrEmpty(reader.GetInt32(0).ToString()))
                    model.TCL_Id = reader.GetInt32(0);

                if (!string.IsNullOrEmpty(reader.GetString(1)))
                    model.TCL_Name = reader.GetString(1);
            }
            reader.Close();
            return model;
        }

        /// <summary>
        /// ��������б�
        /// </summary>
        public IList<LN.Model.TownCityLevel> GetList(string strWhere)
        {
            IList<LN.Model.TownCityLevel> list = new List<LN.Model.TownCityLevel>();

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select TCL_Id,TCL_Name FROM TownCityLevel ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            SqlDataReader reader = DbHelperSQL.ExecuteReader(DbHelperSQL.connectionString(), strSql.ToString());
            while (reader.Read())
            {
                LN.Model.TownCityLevel model = new LN.Model.TownCityLevel();
                if (!string.IsNullOrEmpty(reader.GetInt32(0).ToString()))
                    model.TCL_Id = reader.GetInt32(0);

                if (!string.IsNullOrEmpty(reader.GetString(1)))
                    model.TCL_Name = reader.GetString(1);
                list.Add(model);
            }
            reader.Close();
            return list;
        }

        #endregion  ��Ա����
	}
}

