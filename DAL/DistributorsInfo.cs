using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using LN.DBUtility;//�����������
namespace LN.DAL
{
    /// <summary>
    /// ���ݷ�����DistributorsInfo��
    /// </summary>
    public class DistributorsInfo
    {
        public DistributorsInfo()
        { }
        #region  ��Ա����

        /// <summary>
        /// �Ƿ���ڸü�¼
        /// </summary>
        public bool Exists(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from DistributorsInfo");
            strSql.Append(" where ID=@ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)};
            parameters[0].Value = ID;

            return DbHelperSQL.Exists(DbHelperSQL.connectionString(), strSql.ToString(), parameters);
        }


        /// <summary>
        /// ����һ������
        /// </summary>
        public int Add(LN.Model.DistributorsInfo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into DistributorsInfo(");
            strSql.Append("FXID,FXName,FXContactor,FXPhone,FXtel,DealerID,FXAddress,AreaID,ProvinceID,CityID,ExamState,ExamUserID,VMExamState,VMExamUserID,NewDealerID)");
            strSql.Append(" values (");
            strSql.Append("@FXID,@FXName,@FXContactor,@FXPhone,@FXtel,@DealerID,@FXAddress,@AreaID,@ProvinceID,@CityID,0,0,0,0,@NewDealerID)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@FXID", SqlDbType.VarChar,50),
					new SqlParameter("@FXName", SqlDbType.VarChar,200),
					new SqlParameter("@FXContactor", SqlDbType.VarChar,50),
					new SqlParameter("@FXPhone", SqlDbType.VarChar,50),
					new SqlParameter("@FXtel", SqlDbType.VarChar,50),
					new SqlParameter("@DealerID", SqlDbType.VarChar,50),
					new SqlParameter("@FXAddress", SqlDbType.VarChar,200),
					new SqlParameter("@AreaID", SqlDbType.Int,4),
					new SqlParameter("@ProvinceID", SqlDbType.Int,4),
					new SqlParameter("@CityID", SqlDbType.Int,4),                    
                    new SqlParameter("@NewDealerID", SqlDbType.VarChar,50)
            };
            parameters[0].Value = model.FXID;
            parameters[1].Value = model.FXName;
            parameters[2].Value = model.FXContactor;
            parameters[3].Value = model.FXPhone;
            parameters[4].Value = model.FXtel;
            parameters[5].Value = model.DealerID;
            parameters[6].Value = model.FXAddress;
            parameters[7].Value = model.AreaID;
            parameters[8].Value = model.ProvinceID;
            parameters[9].Value = model.CityID;
            parameters[10].Value = model.NewDealerID;

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
        public void Update(LN.Model.DistributorsInfo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update DistributorsInfo set ");
            strSql.Append("FXID=@FXID,");
            strSql.Append("FXName=@FXName,");
            strSql.Append("FXContactor=@FXContactor,");
            strSql.Append("FXPhone=@FXPhone,");
            strSql.Append("FXtel=@FXtel,");
            strSql.Append("DealerID=@DealerID,");
            strSql.Append("FXAddress=@FXAddress,");
            strSql.Append("AreaID=@AreaID,");
            strSql.Append("ProvinceID=@ProvinceID,");
            strSql.Append("CityID=@CityID,");
            strSql.Append("NewDealerID=@NewDealerID,");
            strSql.Append("ExamState=@ExamState");
            strSql.Append(" where FXID=@FXID ");
            SqlParameter[] parameters = {
					new SqlParameter("@FXID", SqlDbType.VarChar,50),
					new SqlParameter("@FXName", SqlDbType.VarChar,200),
					new SqlParameter("@FXContactor", SqlDbType.VarChar,50),
					new SqlParameter("@FXPhone", SqlDbType.VarChar,50),
					new SqlParameter("@FXtel", SqlDbType.VarChar,50),
					new SqlParameter("@DealerID", SqlDbType.VarChar,50),
					new SqlParameter("@FXAddress", SqlDbType.VarChar,200),
					new SqlParameter("@AreaID", SqlDbType.Int,4),
					new SqlParameter("@ProvinceID", SqlDbType.Int,4),
					new SqlParameter("@CityID", SqlDbType.Int,4),
                    new SqlParameter("@NewDealerID",SqlDbType.VarChar,20),
                    new SqlParameter("@ExamState",SqlDbType.Int,4)
            };
            parameters[0].Value = model.FXID;
            parameters[1].Value = model.FXName;
            parameters[2].Value = model.FXContactor;
            parameters[3].Value = model.FXPhone;
            parameters[4].Value = model.FXtel;
            parameters[5].Value = model.DealerID;
            parameters[6].Value = model.FXAddress;
            parameters[7].Value = model.AreaID;
            parameters[8].Value = model.ProvinceID;
            parameters[9].Value = model.CityID;
            parameters[10].Value = model.NewDealerID;
            parameters[11].Value = model.ExamState;
            DbHelperSQL.ExecuteSql(DbHelperSQL.connectionString(), strSql.ToString(), parameters);
        }

        /// <summary>
        /// ɾ��һ������
        /// </summary>
        public int Delete(string  FXID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from DistributorsInfo ");
            strSql.Append(" where FXID=@ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.VarChar,10)};
            parameters[0].Value = FXID;

            return DbHelperSQL.ExecuteSql(DbHelperSQL.connectionString(), strSql.ToString(), parameters);
        }


        /// <summary>
        /// �õ�һ������ʵ��
        /// </summary>
        public LN.Model.DistributorsInfo GetModel(string FXID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 ID,FXID,FXName,FXContactor,FXPhone,FXtel,DealerID,FXAddress,AreaID,ProvinceID,CityID from DistributorsInfo ");
            strSql.Append(" where FXID=@FXID ");
            SqlParameter[] parameters = {
					new SqlParameter("@FXID", SqlDbType.VarChar,10)};
            parameters[0].Value = FXID;

            LN.Model.DistributorsInfo model = new LN.Model.DistributorsInfo();
            DataSet ds = DbHelperSQL.Query(DbHelperSQL.connectionString(), strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["ID"].ToString() != "")
                {
                    model.ID = int.Parse(ds.Tables[0].Rows[0]["ID"].ToString());
                }
                model.FXID = ds.Tables[0].Rows[0]["FXID"].ToString();
                model.FXName = ds.Tables[0].Rows[0]["FXName"].ToString();
                model.FXContactor = ds.Tables[0].Rows[0]["FXContactor"].ToString();
                model.FXPhone = ds.Tables[0].Rows[0]["FXPhone"].ToString();
                model.FXtel = ds.Tables[0].Rows[0]["FXtel"].ToString();
                model.DealerID = ds.Tables[0].Rows[0]["DealerID"].ToString();
                model.FXAddress = ds.Tables[0].Rows[0]["FXAddress"].ToString();
                if (ds.Tables[0].Rows[0]["AreaID"].ToString() != "")
                {
                    model.AreaID = int.Parse(ds.Tables[0].Rows[0]["AreaID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["ProvinceID"].ToString() != "")
                {
                    model.ProvinceID = int.Parse(ds.Tables[0].Rows[0]["ProvinceID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["CityID"].ToString() != "")
                {
                    model.CityID = int.Parse(ds.Tables[0].Rows[0]["CityID"].ToString());
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
            strSql.Append("select ROW_NUMBER() OVER (ORDER BY ID DESC) AS SNumberID,ID,FXID,FXName,FXContactor,FXPhone,FXtel,DealerID,FXAddress,AreaID,ProvinceID,CityID ");
            strSql.Append(" FROM DistributorsInfo ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(DbHelperSQL.connectionString(), strSql.ToString());
        }

        /// <summary>
        /// ���ǰ��������
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            if (Top > 0)
            {
                strSql.Append(" top " + Top.ToString());
            }
            strSql.Append(" ID,FXID,FXName,FXContactor,FXPhone,FXtel,DealerID,FXAddress,AreaID,ProvinceID,CityID ");
            strSql.Append(" FROM DistributorsInfo ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return DbHelperSQL.Query(DbHelperSQL.connectionString(), strSql.ToString());
        }
        /// <summary>
        /// ���������õ�ֱ���ͻ���ID��ֱ���ͻ�����
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataTable GetIDName(string strWhere)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("select FXID,FXName from DistributorsInfo");
            if (strWhere.Length > 0)
            {
                sb.Append(" where " + strWhere);
            }
            DataSet ds = DbHelperSQL.Query(DbHelperSQL.connectionString(), sb.ToString());
            DataTable dt = ds.Tables[0];
            return dt;
        }

        /// <summary>
        /// ��ȡָ���û��Ƿ���ֱ���ͻ�
        /// </summary>
        /// <param name="UserID">�û����</param>
        /// <returns>����ֱ���ͻ����</returns>
        public string GetFXIdByUserID(string UserID)
        {
            string _return = String.Empty;
            string strSql = string.Format("select FXID from DistributorsInfo where FXContactor=(select top 1 Username from UserInfo where UserID={0})", UserID);

            object obj = DbHelperSQL.GetSingle(DbHelperSQL.connectionString(), strSql);

            if (obj != null)
                _return = obj.ToString();

            return _return;
        }

        /// <summary>
        /// ���ݳ��е�id��ȡֱ���ͻ����б�
        /// </summary>
        /// <param name="CityID"></param>
        public DataTable GetFXinfolistBy(string CityID)
        {

            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("select  FXID,FXName from dbo.DistributorsInfo where FXID in(select distinct FXID from ShopInfo where Cityid='{0}' )",CityID);
            
            DataSet ds = DbHelperSQL.Query(DbHelperSQL.connectionString(), sb.ToString());
            DataTable dt = ds.Tables[0];
            return dt;
        }


        /// <summary>
        /// ���ݳ��е�id��ȡֱ���ͻ����б�
        /// </summary>
        /// <param name="CityID"></param>
        public DataTable GetFXinfolistsBy(string DealerID)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("select  FXID,FXName from dbo.DistributorsInfo where DealerID = '{0}'", DealerID);

            DataSet ds = DbHelperSQL.Query(DbHelperSQL.connectionString(), sb.ToString());
            DataTable dt = ds.Tables[0];
            return dt;
        }



        /// <summary>
        /// �������AJAX��ҳ�б�
        /// </summary>
        /// <param name="model">��ҳʵ��</param>
        /// <returns>���ػ�ȡֱ���ͻ��б���</returns>
        public DataTable GetListPageByWhere(LN.Model.PageModel model, out int TotalNumber)
        {
            DataTable dt = GetTableListSqlExec.GetList(model, out TotalNumber);
            if (dt != null)
                return dt;
            else
                return null;

        }
        /// <summary>
        /// ����FXID�õ�һ��ֱ���ͻ�����ϸ��Ϣ
        /// </summary>
        /// <param name="FXID"></param>
        /// <returns></returns>
        public DataTable GetOneFX(string FXID)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(" SELECT DistributorsInfo.ID, ");
            sb.Append("[FXID],[FXName],FXaddress,[FXContactor],[FXPhone],[FXtel],[DistributorsInfo].DealerID, DealerName,department,areaname,");
            sb.Append(" (select top 1 provincename from ProvinceData where ProvinceID=[DistributorsInfo].ProvinceID) as ProvinceName,");
            sb.Append(" (select top 1 cityname from citydata where cityID=[DistributorsInfo].CityID) as CityName,");
            sb.Append(" [DistributorsInfo].AreaID,[DistributorsInfo].ProvinceID,[DistributorsInfo].CityID ");
            sb.Append(" FROM [DistributorsInfo] ");
            sb.Append(" INNER JOIN [DealerInfo] ON DistributorsInfo.DealerID = DealerInfo.DealerID");
            sb.Append(" left join areadata on [DistributorsInfo].areaID=areaData.areaID");
            if (FXID.Trim().Length > 0)
            {
                sb.Append(" where ");
                sb.AppendFormat(" FXID ='{0}'", FXID);
            }

            DataSet ds = DbHelperSQL.Query(DbHelperSQL.connectionString(), sb.ToString());
            return ds.Tables[0];
        }
        /// <summary>
        ///  �õ�Ҫ������ֱ���ͻ�
        /// </summary>
        /// <param name="strwhere"></param>
        /// <returns></returns>
        public DataTable GetFXinfolist(string strwhere)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("select ID,FXID,FXName,FxContactor,FxPhone, ");
            sb.Append("DealerID+'|'+(select dealerName from dealerinfo where DealerID=DistributorsInfo.DealerID) dealername, ");
            sb.Append("NewDealerID+'|'+(select dealerName from dealerinfo where DealerID=DistributorsInfo.NewDealerID) newdealername ");
            sb.Append("from DistributorsInfo  left join areaData on DistributorsInfo.areaID=areaData.areaID   where 1=1 ");
            if (strwhere.Length > 0)
                sb.Append(strwhere);
            DataSet ds = DbHelperSQL.Query(DbHelperSQL.connectionString(), sb.ToString());
            return ds.Tables[0];
        }
        /// <summary>
        /// ���ž������ֱ���ͻ�����������һ���ͻ�
        /// </summary>
        /// <param name="examState"></param>
        /// <param name="userID"></param>
        /// <param name="Strwhere"></param>
        public void ExamFXofDealer(string examState,string userID,string Strwhere)
        {
            StringBuilder sb=new StringBuilder();
            string str = string.Empty;
            if (examState == "1")
            {
                sb.Append("INSERT INTO [UserInfo] ([Username],[Sex],[Usertype],[UserPassword],[UserEmail],[UserAddress],[UserPhone],[UserMobel],[UserState],[UserDesc],[userofarea]) ");
                sb.Append("SELECT FXID+'LN','',8,'000000','',FXName,FXPhone,FXtel,1,'',AreaID FROM DistributorsInfo WHERE " + Strwhere+" ;");
                str += " ,DealerID=NewDealerID  ";
            }
            sb.AppendFormat("update DistributorsInfo set ExamState={0},ExamUserID={1},ExamDate='{2}'{3}", examState, userID, DateTime.Now.ToString(),str);
            if (Strwhere.Length > 0)
            {
                sb.Append(" where ");
                sb.Append(Strwhere);
            }
            DbHelperSQL.ExecuteSql(DbHelperSQL.connectionString(), sb.ToString());
        }
        /// <summary>
        /// ʡ��VM���ֱ���ͻ�����������һ���ͻ�
        /// </summary>
        /// <param name="VMexamState"></param>
        /// <param name="UserID"></param>
        /// <param name="Strwhere"></param>
        public void VMExamFXofDealer(string VMexamState, string UserID, string Strwhere)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("update DistributorsInfo set VMExamState={0},VMExamUserID={1},VMExamDate='{2}'", VMexamState, UserID, DateTime.Now.ToString());
            if (Strwhere.Length > 0)
            {
                sb.Append(" where ");
                sb.Append(Strwhere);
            }
            DbHelperSQL.ExecuteSql(DbHelperSQL.connectionString(), sb.ToString());
        }
		#endregion  ��Ա����

      
    }
}

