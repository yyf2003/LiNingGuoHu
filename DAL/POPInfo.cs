using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Collections;
using LN.DBUtility;//请先添加引用

namespace LN.DAL
{
    /// <summary>
    /// 数据访问类POPInfo。
    /// </summary>
    public class POPInfo
    {
        public POPInfo()
        { }
        #region  成员方法

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from POPInfo");
            strSql.Append(" where ID=@ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Decimal)};
            parameters[0].Value = ID;

            return DbHelperSQL.Exists(DbHelperSQL.connectionString(), strSql.ToString(), parameters);
        }
        /// <summary>
        /// 得到店铺内所有pop的信息
        /// </summary>
        /// <param name="shopid"></param>
        /// <returns></returns>
        public DataTable GetPOPByshopid(string shopid)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("select * from popinfo ");
            if (shopid.Length > 0)
                sb.Append(" where shopid=" + shopid);

            DataSet ds = DbHelperSQL.Query(DbHelperSQL.connectionString(), sb.ToString());
            return ds.Tables[0];
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(LN.Model.POPInfo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into POPInfo(");
            strSql.Append("ShopID,SeatNum,POPSeat,SeatDesc,POPHeight,POPWith,POPArea,POPMaterial,ProductLineID,Sexarea,TwoSided,Glass,PlatformWith,PlatformHeight,PlatformLong,ExamState,ExamUserID,ExamDesc,AddState,POPPlwz,POPPljd,realheight,realwith,VMExamState,VMExamUserId,VMExamDesc,SysTime,POPMaterialRemark)");
            strSql.Append(" values (");
            strSql.Append("@ShopID,@SeatNum,@POPSeat,@SeatDesc,@POPHeight,@POPWith,@POPArea,@POPMaterial,@ProductLineID,@Sexarea,@TwoSided,@Glass,@PlatformWith,@PlatformHeight,@PlatformLong,@ExamState,@ExamUserID,@ExamDesc,@AddState,@POPPlwz,@POPPljd,@realheight,@realwith,@VMExamState,@VMExamUserId,@VMExamDesc,@SysTime,@POPMaterialRemark)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@ShopID", SqlDbType.Int,4),
					new SqlParameter("@SeatNum", SqlDbType.VarChar,50),
					new SqlParameter("@SeatDesc", SqlDbType.VarChar,50),
					new SqlParameter("@POPHeight", SqlDbType.Float,8),
					new SqlParameter("@POPWith", SqlDbType.Float,8),
					new SqlParameter("@POPArea", SqlDbType.Float,8),
					new SqlParameter("@POPMaterial", SqlDbType.VarChar,50),
					new SqlParameter("@ProductLineID", SqlDbType.Int,4),
					new SqlParameter("@Sexarea", SqlDbType.VarChar,10),
					new SqlParameter("@TwoSided", SqlDbType.Int,4),
					new SqlParameter("@Glass", SqlDbType.Int,4),
					new SqlParameter("@PlatformWith", SqlDbType.Float,8),
					new SqlParameter("@PlatformHeight", SqlDbType.Float,8),
					new SqlParameter("@PlatformLong", SqlDbType.Float,8),
					new SqlParameter("@ExamState", SqlDbType.Int,4),
                    new SqlParameter("@POPSeat", SqlDbType.VarChar,30),
                    new SqlParameter("@ExamUserID", SqlDbType.Int,4),
                    new SqlParameter("@ExamDesc", SqlDbType.VarChar,300),
                    new SqlParameter("@AddState", SqlDbType.VarChar,50),
                    new SqlParameter("@POPPlwz",SqlDbType.VarChar,20),
                    new SqlParameter("@POPPljd",SqlDbType.Int,4),
                    new SqlParameter("@realheight", SqlDbType.Float,8),
                    new SqlParameter("@realwith", SqlDbType.Float,8),
                    new SqlParameter("@VMExamState", SqlDbType.Int,4),
                    new SqlParameter("@VMExamUserID", SqlDbType.Int,4),
                    new SqlParameter("@VMExamDesc", SqlDbType.VarChar,300),
                    new SqlParameter("@SysTime", SqlDbType.DateTime),
                    new SqlParameter("@POPMaterialRemark", SqlDbType.VarChar,200)};

            parameters[0].Value = model.ShopID;
            parameters[1].Value = model.SeatNum;
            parameters[2].Value = model.SeatDesc;
            parameters[3].Value = model.POPHeight;
            parameters[4].Value = model.POPWith;
            parameters[5].Value = model.POPArea;
            parameters[6].Value = model.POPMaterial;
            parameters[7].Value = model.ProductLineID;
            parameters[8].Value = model.Sexarea;
            parameters[9].Value = model.TwoSided;
            parameters[10].Value = model.Glass;
            parameters[11].Value = model.PlatformWith;
            parameters[12].Value = model.PlatformHeight;
            parameters[13].Value = model.PlatformLong;
            parameters[14].Value = model.ExamState;
            parameters[15].Value = model.POPSeat;
            parameters[16].Value = model.ExamUserID;
            parameters[17].Value = model.ExamDesc;
            parameters[18].Value = model.AddState;
            parameters[19].Value = model.POPPlwz;
            parameters[20].Value = model.POPPljd;
            parameters[21].Value = model.RealHeight;
            parameters[22].Value = model.RealWith;
            parameters[23].Value = model.VMExamState;
            parameters[24].Value = model.VMExamUserId;
            parameters[25].Value = model.VMExamDate;
            parameters[26].Value = DateTime.Now;
            parameters[27].Value = model.POPMaterialRemark;
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
        public void Update(LN.Model.POPInfo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update POPInfo set ");
            strSql.Append("ShopID=@ShopID,");
            strSql.Append("SeatNum=@SeatNum,");
            strSql.Append("POPSeat=@POPSeat,");
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
            strSql.Append("ExamState=@ExamState,");
            strSql.Append("SysTime=getdate(),");
            strSql.Append("POPMaterialRemark=@POPMaterialRemark");
            strSql.Append(" where ID=@ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4),
					new SqlParameter("@ShopID", SqlDbType.Int,4),
					new SqlParameter("@SeatNum", SqlDbType.VarChar,50),
					new SqlParameter("@SeatDesc", SqlDbType.VarChar,50),
					new SqlParameter("@POPHeight", SqlDbType.Float,8),
					new SqlParameter("@POPWith", SqlDbType.Float,8),
					new SqlParameter("@POPArea", SqlDbType.Float,8),
					new SqlParameter("@POPMaterial", SqlDbType.VarChar,50),
					new SqlParameter("@ProductLineID", SqlDbType.Int,4),
					new SqlParameter("@Sexarea", SqlDbType.VarChar,10),
					new SqlParameter("@TwoSided", SqlDbType.Int,4),
					new SqlParameter("@Glass", SqlDbType.Int,4),
					new SqlParameter("@PlatformWith", SqlDbType.Float,8),
					new SqlParameter("@PlatformHeight", SqlDbType.Float,8),
					new SqlParameter("@PlatformLong", SqlDbType.Float,8),
					new SqlParameter("@ExamState", SqlDbType.Int,4),
                    new SqlParameter("@POPSeat", SqlDbType.VarChar,30),
                    new SqlParameter("@POPMaterialRemark", SqlDbType.VarChar,200)};
            parameters[0].Value = model.ID;
            parameters[1].Value = model.ShopID;
            parameters[2].Value = model.SeatNum;
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
            parameters[15].Value = model.ExamState;
            parameters[16].Value = model.POPSeat;
            parameters[17].Value = model.POPMaterialRemark;
            DbHelperSQL.ExecuteSql(DbHelperSQL.connectionString(), strSql.ToString(), parameters);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public int UpdatePOP(LN.Model.POPInfo model)
        {
            int _return = 0;
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update POPInfo set ");

            //add by mhj 2012.09.14
            strSql.Append("POPseat=@POPseat,");

            strSql.Append("SeatDesc=@SeatDesc,");
            strSql.Append("POPHeight=@POPHeight,");
            strSql.Append("POPWith=@POPWith,");
            strSql.Append("RealHeight=@RealHeight,");
            strSql.Append("RealWith=@RealWith,");
            strSql.Append("POPArea=@POPArea,");
            strSql.Append("POPMaterial=@POPMaterial,");
            strSql.Append("Sexarea=@Sexarea,");
            strSql.Append("TwoSided=@TwoSided,");
            strSql.Append("Glass=@Glass,");
            strSql.Append("PlatformWith=@PlatformWith,");
            strSql.Append("PlatformHeight=@PlatformHeight,");
            strSql.Append("PlatformLong=@PlatformLong,");
            strSql.Append("POPPlwz=@POPPlwz,");
            strSql.Append("POPPljd=@POPPljd,");
            strSql.Append("ExamState=1,");
            strSql.Append("ExamUserID=0,");
            strSql.Append("VMExamState=1,");
            strSql.Append("VMExamUserID=0,");
            strSql.Append("POPMaterialRemark=@POPMaterialRemark");
            strSql.Append(" where ID=@ID; ");
            strSql.Append(" select @@ROWCOUNT; ");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4),
                    new SqlParameter("@SeatDesc", SqlDbType.VarChar,50),
                    new SqlParameter("@POPHeight", SqlDbType.Float,8),
                    new SqlParameter("@POPWith", SqlDbType.Float,8),
                    new SqlParameter("@RealHeight", SqlDbType.Float,8),
                    new SqlParameter("@RealWith", SqlDbType.Float,8),
                    new SqlParameter("@POPArea", SqlDbType.Float,8),
                    new SqlParameter("@POPMaterial", SqlDbType.VarChar,50),
                    new SqlParameter("@Sexarea", SqlDbType.VarChar,10),
                    new SqlParameter("@TwoSided", SqlDbType.Int,4),
                    new SqlParameter("@Glass", SqlDbType.Int,4),
                    new SqlParameter("@PlatformWith", SqlDbType.Float,8),
                    new SqlParameter("@PlatformHeight", SqlDbType.Float,8),
                    new SqlParameter("@PlatformLong", SqlDbType.Float,8),
                    new SqlParameter("@POPPlwz", SqlDbType.VarChar,20),
                    new SqlParameter("@POPPljd", SqlDbType.Int,4),
                    new SqlParameter("@POPMaterialRemark", SqlDbType.VarChar,200),

                    //add by mhj 2012.09.14
                    new SqlParameter("@POPseat", SqlDbType.VarChar,50),

            };
            parameters[0].Value = model.ID;
            parameters[1].Value = model.SeatDesc;
            parameters[2].Value = model.POPHeight;
            parameters[3].Value = model.POPWith;
            parameters[4].Value = model.RealHeight;
            parameters[5].Value = model.RealWith;
            decimal POPArea = model.RealHeight * model.RealWith / 1000000;
            parameters[6].Value = float.Parse(POPArea.ToString("#0.00"));
            parameters[7].Value = model.POPMaterial;
            parameters[8].Value = model.Sexarea;
            parameters[9].Value = model.TwoSided;
            parameters[10].Value = model.Glass;
            parameters[11].Value = model.PlatformWith;
            parameters[12].Value = model.PlatformHeight;
            parameters[13].Value = model.PlatformLong;
            parameters[14].Value = model.POPPlwz;
            parameters[15].Value = model.POPPljd;
            parameters[16].Value = model.POPMaterialRemark;

            //add by mhj 2012.09.14
            parameters[17].Value = model.POPSeat;

            object obj = DbHelperSQL.GetSingle(DbHelperSQL.connectionString(), strSql.ToString(), parameters);
            if (obj != null)
                _return = Convert.ToInt32(obj);

            return _return;
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void Delete(int ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete POPInfo ");
            strSql.Append(" where ID=@ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)};
            parameters[0].Value = ID;

            DbHelperSQL.ExecuteSql(DbHelperSQL.connectionString(), strSql.ToString(), parameters);
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public LN.Model.POPInfo GetModel(int ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 ID,ShopID,SeatNum,POPSeat,SeatDesc,POPHeight,POPWith,POPArea,POPMaterial,ProductLineID,Sexarea,TwoSided,Glass,PlatformWith,PlatformHeight,PlatformLong,ExamState,SysTime,addstate,realHeight,realwith,POPplwz,POPpljd,POPMaterialRemark from POPInfo ");
            strSql.Append(" where ID=@ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Decimal)};
            parameters[0].Value = ID;

            LN.Model.POPInfo model = null;
            SqlDataReader reader = DbHelperSQL.ExecuteReader(DbHelperSQL.connectionString(), strSql.ToString(), parameters);
            if (reader.Read())
            {
                model = new LN.Model.POPInfo();
                if (!string.IsNullOrEmpty(reader["ID"].ToString()))
                {
                    model.ID = int.Parse(reader["ID"].ToString());
                }
                if (!string.IsNullOrEmpty(reader["ShopID"].ToString()))
                {
                    model.ShopID = int.Parse(reader["ShopID"].ToString());
                }

                model.SeatNum = reader["SeatNum"].ToString();
                model.POPSeat = reader["POPSeat"].ToString();
                model.SeatDesc = reader["SeatDesc"].ToString();
                if (!string.IsNullOrEmpty(reader["POPHeight"].ToString()))
                {
                    model.POPHeight = Convert.ToDecimal(reader["POPHeight"]);
                }
                if (!string.IsNullOrEmpty(reader["POPWith"].ToString()))
                {
                    model.POPWith = Convert.ToDecimal(reader["POPWith"]);
                }
                if (!string.IsNullOrEmpty(reader["POPArea"].ToString()))
                {
                    model.POPArea = Convert.ToDecimal(reader["POPArea"]);
                }
                if (!string.IsNullOrEmpty(reader["POPMaterial"].ToString()))
                {
                    model.POPMaterial = reader["POPMaterial"].ToString();
                }
                else//add by mhj 2012.7.11
                {
                    model.POPMaterial = "";
                }
                if (!string.IsNullOrEmpty(reader["ProductLineID"].ToString()))
                {
                    model.ProductLineID = int.Parse(reader["ProductLineID"].ToString());
                }

                model.Sexarea = reader["Sexarea"].ToString();
                if (!string.IsNullOrEmpty(reader["TwoSided"].ToString()))
                {
                    model.TwoSided = (int)reader["TwoSided"];
                }
                if (!string.IsNullOrEmpty(reader["Glass"].ToString()))
                {
                    model.Glass = (int)reader["Glass"];
                }
                if (!string.IsNullOrEmpty(reader["PlatformWith"].ToString()))
                {
                    model.PlatformWith = Convert.ToDecimal(reader["PlatformWith"]);
                }
                if (!string.IsNullOrEmpty(reader["PlatformHeight"].ToString()))
                {
                    model.PlatformHeight = Convert.ToDecimal(reader["PlatformHeight"]);
                }
                if (!string.IsNullOrEmpty(reader["PlatformLong"].ToString()))
                {
                    model.PlatformLong = Convert.ToDecimal(reader["PlatformLong"]);
                }
                if (!string.IsNullOrEmpty(reader["ExamState"].ToString()))
                {
                    model.ExamState = (int)reader["ExamState"];
                }
                if (!string.IsNullOrEmpty(reader["SysTime"].ToString()))
                {
                    model.SysTime = reader["SysTime"].ToString();
                }
                if (!string.IsNullOrEmpty(reader["AddState"].ToString()))
                {
                    model.AddState = reader["AddState"].ToString();
                }
                if (!string.IsNullOrEmpty(reader["realWith"].ToString()))
                {
                    model.RealWith = Convert.ToDecimal(reader["realWith"]);
                }
                if (!string.IsNullOrEmpty(reader["realHeight"].ToString()))
                {
                    model.RealHeight = Convert.ToDecimal(reader["realHeight"]);
                }
                if (!string.IsNullOrEmpty(reader["POPplwz"].ToString()))
                {
                    model.POPPlwz = reader["POPplwz"].ToString();
                }
                if (!string.IsNullOrEmpty(reader["POPpljd"].ToString()))
                {
                    model.POPPljd = int.Parse(reader["POPpljd"].ToString());
                }
                model.POPMaterialRemark = reader["POPMaterialRemark"].ToString();
            }
            reader.Close();
            return model;
        }

        /// <summary>
        /// 获得数据列表返回DataSet
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataSet GetListDataSet(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ID,ShopID,SeatNum,POPSeat,SeatDesc,RealHeight,RealWith,POPHeight,POPWith,POPPlwz,POPPljd,POPArea,POPMaterial,ProductLineID,Sexarea,TwoSided,Glass,PlatformWith,PlatformHeight,PlatformLong,ExamState,SysTime,(ProductTypeName+'--'+ProductLine) as ProductLine,POPMaterialRemark  ");
            strSql.Append(" FROM View_shippoplist ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where  ExamState=1 and " + strWhere);
            }
            return DbHelperSQL.Query(DbHelperSQL.connectionString(), strSql.ToString());
        }


        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<LN.Model.POPInfo> GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            //strSql.Append("select distinct vsl.ID,vsl.ShopID,SeatNum,POPSeat,SeatDesc,RealHeight,RealWith,POPHeight,POPWith,POPPlwz,POPPljd,POPArea,POPMaterial,ProductLineID,Sexarea,TwoSided,Glass,PlatformWith,PlatformHeight,PlatformLong,ExamState,vsl.SysTime,(ProductTypeName+'--'+ProductLine) as ProductLine,POPMaterialRemark ");
            //strSql.Append(" FROM imageToPOP imp left outer join  View_shippoplist vsl on vsl.ID = imp.popinfoID ");

            strSql.Append("select vsl.ID,vsl.ShopID,SeatNum,POPSeat,SeatDesc,RealHeight, ");
            strSql.Append("RealWith,POPHeight,POPWith,POPPlwz,POPPljd,POPArea,POPMaterial, ");
            strSql.Append("ProductLineID,Sexarea,TwoSided,Glass,PlatformWith,PlatformHeight, ");
            strSql.Append("PlatformLong,ExamState,vsl.SysTime,(ProductTypeName+'--'+ProductLine) ");
            strSql.Append("as ProductLine,POPMaterialRemark   ");
            strSql.Append("FROM  View_shippoplist vsl    ");

            if (strWhere.Trim() != "")
            {
                strSql.Append("  where  1=1 and  " + strWhere);
            }
            List<LN.Model.POPInfo> modelList = new List<LN.Model.POPInfo>();
            SqlDataReader reader = DbHelperSQL.ExecuteReader(DbHelperSQL.connectionString(), strSql.ToString());
            LN.Model.POPInfo model;
            while (reader.Read())
            {
                model = new LN.Model.POPInfo();
                if (!string.IsNullOrEmpty(reader["ID"].ToString()))
                {
                    model.ID = int.Parse(reader["ID"].ToString());
                }
                if (!string.IsNullOrEmpty(reader["ShopID"].ToString()))
                {
                    model.ShopID = int.Parse(reader["ShopID"].ToString());
                }

                model.SeatNum = reader["SeatNum"].ToString();
                model.POPSeat = reader["POPSeat"].ToString();
                model.SeatDesc = reader["SeatDesc"].ToString();
                if (!string.IsNullOrEmpty(reader["RealHeight"].ToString()))
                {
                    model.RealHeight = Convert.ToDecimal(reader["RealHeight"].ToString());
                }
                if (!string.IsNullOrEmpty(reader["RealWith"].ToString()))
                {
                    model.RealWith = Convert.ToDecimal(reader["RealWith"].ToString());
                }
                model.POPPlwz = reader["POPPlwz"].ToString();
                if (!string.IsNullOrEmpty(reader["POPPljd"].ToString()))
                {
                    model.POPPljd = int.Parse(reader["POPPljd"].ToString());
                }
                if (!string.IsNullOrEmpty(reader["POPHeight"].ToString()))
                {
                    model.POPHeight = Convert.ToDecimal(reader["POPHeight"]);
                }
                if (!string.IsNullOrEmpty(reader["POPWith"].ToString()))
                {
                    model.POPWith = Convert.ToDecimal(reader["POPWith"]);
                }
                if (!string.IsNullOrEmpty(reader["POPArea"].ToString()))
                {
                    model.POPArea = Convert.ToDecimal(reader["POPArea"]);
                }
                if (!string.IsNullOrEmpty(reader["POPMaterial"].ToString()))
                {
                    model.POPMaterial = reader["POPMaterial"].ToString();
                }
                if (!string.IsNullOrEmpty(reader["ProductLineID"].ToString()))
                {
                    model.ProductLineID = int.Parse(reader["ProductLineID"].ToString());
                }
                if (!string.IsNullOrEmpty(reader["ProductLine"].ToString()))
                {
                    model.ProductLine = reader["ProductLine"].ToString();
                }
                model.Sexarea = reader["Sexarea"].ToString();
                if (!string.IsNullOrEmpty(reader["TwoSided"].ToString()))
                {
                    model.TwoSided = (int)reader["TwoSided"];
                }
                if (!string.IsNullOrEmpty(reader["Glass"].ToString()))
                {
                    model.Glass = (int)reader["Glass"];
                }
                if (!string.IsNullOrEmpty(reader["PlatformWith"].ToString()))
                {
                    model.PlatformWith = Convert.ToDecimal(reader["PlatformWith"]);
                }
                if (!string.IsNullOrEmpty(reader["PlatformHeight"].ToString()))
                {
                    model.PlatformHeight = Convert.ToDecimal(reader["PlatformHeight"]);
                }
                if (!string.IsNullOrEmpty(reader["PlatformLong"].ToString()))
                {
                    model.PlatformLong = Convert.ToDecimal(reader["PlatformLong"]);
                }
                if (!string.IsNullOrEmpty(reader["ExamState"].ToString()))
                {
                    model.ExamState = (int)reader["ExamState"];
                }
                if (!string.IsNullOrEmpty(reader["SysTime"].ToString()))
                {
                    model.SysTime = reader["SysTime"].ToString();
                }
                model.POPMaterialRemark = reader["POPMaterialRemark"].ToString();

                modelList.Add(model);
            }
            reader.Close();
            return modelList;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<LN.Model.POPInfo> GetListOrder(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT ID,ShopID,SeatNum,POPSeat,SeatDesc,RealHeight,RealWith,POPHeight,POPWith,POPPlwz,POPPljd,POPArea,POPMaterial,ProductLineID,Sexarea,TwoSided,Glass,PlatformWith,PlatformHeight,PlatformLong,VMExamState,ExamState,SysTime, ");
            strSql.Append("(SELECT COUNT(ID) FROM imageToPOPTemp WHERE POPID=(SELECT TOP 1 POPID FROM POPLaunch WHERE steps=0 ORDER BY ID DESC) AND POPinfoID=p.ID) AS IsSubmit,POPMaterialRemark FROM POPInfo AS p WHERE VMExamState=1 AND ExamState=1 ");
            if (strWhere.Trim() != "")
            {
                strSql.Append("  AND  " + strWhere);
            }
            List<LN.Model.POPInfo> modelList = new List<LN.Model.POPInfo>();
            SqlDataReader reader = DbHelperSQL.ExecuteReader(DbHelperSQL.connectionString(), strSql.ToString());
            LN.Model.POPInfo model;
            while (reader.Read())
            {
                model = new LN.Model.POPInfo();
                if (!string.IsNullOrEmpty(reader["ID"].ToString()))
                {
                    model.ID = int.Parse(reader["ID"].ToString());
                }
                if (!string.IsNullOrEmpty(reader["ShopID"].ToString()))
                {
                    model.ShopID = int.Parse(reader["ShopID"].ToString());
                }

                model.SeatNum = reader["SeatNum"].ToString();
                model.POPSeat = reader["POPSeat"].ToString();
                model.SeatDesc = reader["SeatDesc"].ToString();
                if (!string.IsNullOrEmpty(reader["RealHeight"].ToString()))
                {
                    model.RealHeight = Convert.ToDecimal(reader["RealHeight"].ToString());
                }
                if (!string.IsNullOrEmpty(reader["RealWith"].ToString()))
                {
                    model.RealWith = Convert.ToDecimal(reader["RealWith"].ToString());
                }
                model.POPPlwz = reader["POPPlwz"].ToString();
                if (!string.IsNullOrEmpty(reader["POPPljd"].ToString()))
                {
                    model.POPPljd = int.Parse(reader["POPPljd"].ToString());
                }
                if (!string.IsNullOrEmpty(reader["POPHeight"].ToString()))
                {
                    model.POPHeight = Convert.ToDecimal(reader["POPHeight"]);
                }
                if (!string.IsNullOrEmpty(reader["POPWith"].ToString()))
                {
                    model.POPWith = Convert.ToDecimal(reader["POPWith"]);
                }
                if (!string.IsNullOrEmpty(reader["POPArea"].ToString()))
                {
                    model.POPArea = Convert.ToDecimal(reader["POPArea"]);
                }
                if (!string.IsNullOrEmpty(reader["POPMaterial"].ToString()))
                {
                    model.POPMaterial = reader["POPMaterial"].ToString();
                }
                model.Sexarea = reader["Sexarea"].ToString();
                if (!string.IsNullOrEmpty(reader["TwoSided"].ToString()))
                {
                    model.TwoSided = (int)reader["TwoSided"];
                }
                if (!string.IsNullOrEmpty(reader["Glass"].ToString()))
                {
                    model.Glass = (int)reader["Glass"];
                }
                if (!string.IsNullOrEmpty(reader["PlatformWith"].ToString()))
                {
                    model.PlatformWith = Convert.ToDecimal(reader["PlatformWith"]);
                }
                if (!string.IsNullOrEmpty(reader["PlatformHeight"].ToString()))
                {
                    model.PlatformHeight = Convert.ToDecimal(reader["PlatformHeight"]);
                }
                if (!string.IsNullOrEmpty(reader["PlatformLong"].ToString()))
                {
                    model.PlatformLong = Convert.ToDecimal(reader["PlatformLong"]);
                }
                if (!string.IsNullOrEmpty(reader["ExamState"].ToString()))
                {
                    model.ExamState = (int)reader["ExamState"];
                }
                if (!string.IsNullOrEmpty(reader["SysTime"].ToString()))
                {
                    model.SysTime = reader["SysTime"].ToString();
                }
                if (!string.IsNullOrEmpty(reader["IsSubmit"].ToString()))
                {
                    model.IsSubmit = (int)reader["IsSubmit"];
                }
                model.POPMaterialRemark = reader["POPMaterialRemark"].ToString();

                modelList.Add(model);
            }
            reader.Close();
            return modelList;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<LN.Model.POPInfo> GetListOrderByShop(string ShopID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT ID,ShopID,SeatNum,POPSeat,SeatDesc,RealHeight,RealWith,POPHeight,POPWith,POPPlwz,POPPljd,POPArea,POPMaterial,ProductLineID,Sexarea,TwoSided,Glass,PlatformWith,PlatformHeight,PlatformLong,VMExamState,ExamState,SysTime,IsHide, ");
            strSql.AppendFormat("(SELECT COUNT(ID) FROM imageToPOPTemp WHERE POPID=(SELECT TOP 1 POPID FROM POPChangeSet where ShopID={0} and POPID in (SELECT POPID FROM POPLaunch WHERE BeginDate<=getdate() and EndDate>=getdate())) AND POPinfoID=p.ID) AS IsSubmit,POPMaterialRemark FROM POPInfo AS p WHERE VMExamState=1 AND ExamState=1 ", ShopID);
            if (ShopID.Trim() != "")
            {
                strSql.Append(" AND  ShopID = " + ShopID);
            }
            strSql.Append("  order by IsHide ");
            List<LN.Model.POPInfo> modelList = new List<LN.Model.POPInfo>();
            SqlDataReader reader = DbHelperSQL.ExecuteReader(DbHelperSQL.connectionString(), strSql.ToString());
            LN.Model.POPInfo model;
            while (reader.Read())
            {
                model = new LN.Model.POPInfo();
                if (!string.IsNullOrEmpty(reader["ID"].ToString()))
                {
                    model.ID = int.Parse(reader["ID"].ToString());
                }
                if (!string.IsNullOrEmpty(reader["ShopID"].ToString()))
                {
                    model.ShopID = int.Parse(reader["ShopID"].ToString());
                }
                if (!string.IsNullOrEmpty(reader["IsHide"].ToString()))
                {
                    model.IsHide = int.Parse(reader["IsHide"].ToString());
                }

                model.SeatNum = reader["SeatNum"].ToString();
                model.POPSeat = reader["POPSeat"].ToString();
                model.SeatDesc = reader["SeatDesc"].ToString();
                if (!string.IsNullOrEmpty(reader["RealHeight"].ToString()))
                {
                    model.RealHeight = Convert.ToDecimal(reader["RealHeight"].ToString());
                }
                if (!string.IsNullOrEmpty(reader["RealWith"].ToString()))
                {
                    model.RealWith = Convert.ToDecimal(reader["RealWith"].ToString());
                }
                model.POPPlwz = reader["POPPlwz"].ToString();
                if (!string.IsNullOrEmpty(reader["POPPljd"].ToString()))
                {
                    model.POPPljd = int.Parse(reader["POPPljd"].ToString());
                }
                if (!string.IsNullOrEmpty(reader["POPHeight"].ToString()))
                {
                    model.POPHeight = Convert.ToDecimal(reader["POPHeight"]);
                }
                if (!string.IsNullOrEmpty(reader["POPWith"].ToString()))
                {
                    model.POPWith = Convert.ToDecimal(reader["POPWith"]);
                }
                if (!string.IsNullOrEmpty(reader["POPArea"].ToString()))
                {
                    model.POPArea = Convert.ToDecimal(reader["POPArea"]);
                }
                if (!string.IsNullOrEmpty(reader["POPMaterial"].ToString()))
                {
                    model.POPMaterial = reader["POPMaterial"].ToString();
                }
                model.Sexarea = reader["Sexarea"].ToString();
                if (!string.IsNullOrEmpty(reader["TwoSided"].ToString()))
                {
                    model.TwoSided = (int)reader["TwoSided"];
                }
                if (!string.IsNullOrEmpty(reader["Glass"].ToString()))
                {
                    model.Glass = (int)reader["Glass"];
                }
                if (!string.IsNullOrEmpty(reader["PlatformWith"].ToString()))
                {
                    model.PlatformWith = Convert.ToDecimal(reader["PlatformWith"]);
                }
                if (!string.IsNullOrEmpty(reader["PlatformHeight"].ToString()))
                {
                    model.PlatformHeight = Convert.ToDecimal(reader["PlatformHeight"]);
                }
                if (!string.IsNullOrEmpty(reader["PlatformLong"].ToString()))
                {
                    model.PlatformLong = Convert.ToDecimal(reader["PlatformLong"]);
                }
                if (!string.IsNullOrEmpty(reader["ExamState"].ToString()))
                {
                    model.ExamState = (int)reader["ExamState"];
                }
                if (!string.IsNullOrEmpty(reader["SysTime"].ToString()))
                {
                    model.SysTime = reader["SysTime"].ToString();
                }
                if (!string.IsNullOrEmpty(reader["IsSubmit"].ToString()))
                {
                    model.IsSubmit = (int)reader["IsSubmit"];
                }
                model.POPMaterialRemark = reader["POPMaterialRemark"].ToString();

                modelList.Add(model);
            }
            reader.Close();
            return modelList;
        }


        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<LN.Model.POPInfo> GetListOrderByShopID(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT ID,ShopID,SeatNum,POPSeat,SeatDesc,RealHeight,RealWith,POPHeight,POPWith,POPPlwz,POPPljd,POPArea,POPMaterial,ProductLineID,Sexarea,TwoSided,Glass,PlatformWith,PlatformHeight,PlatformLong,VMExamState,ExamState,SysTime, ");
            strSql.Append("(SELECT COUNT(ID) FROM imageToPOPTemp WHERE POPID=(SELECT TOP 1 POPID FROM POPLaunch WHERE steps=0 ORDER BY ID DESC)) AS IsSubmit,POPMaterialRemark FROM POPInfo AS p  ");
            if (strWhere.Trim() != "")
            {
                strSql.Append("  WHERE  " + strWhere);
            }
            List<LN.Model.POPInfo> modelList = new List<LN.Model.POPInfo>();
            SqlDataReader reader = DbHelperSQL.ExecuteReader(DbHelperSQL.connectionString(), strSql.ToString());
            LN.Model.POPInfo model;
            while (reader.Read())
            {
                model = new LN.Model.POPInfo();
                if (!string.IsNullOrEmpty(reader["ID"].ToString()))
                {
                    model.ID = int.Parse(reader["ID"].ToString());
                }
                if (!string.IsNullOrEmpty(reader["ShopID"].ToString()))
                {
                    model.ShopID = int.Parse(reader["ShopID"].ToString());
                }

                model.SeatNum = reader["SeatNum"].ToString();
                model.POPSeat = reader["POPSeat"].ToString();
                model.SeatDesc = reader["SeatDesc"].ToString();
                if (!string.IsNullOrEmpty(reader["RealHeight"].ToString()))
                {
                    model.RealHeight = Convert.ToDecimal(reader["RealHeight"].ToString());
                }
                if (!string.IsNullOrEmpty(reader["RealWith"].ToString()))
                {
                    model.RealWith = Convert.ToDecimal(reader["RealWith"].ToString());
                }
                model.POPPlwz = reader["POPPlwz"].ToString();
                if (!string.IsNullOrEmpty(reader["POPPljd"].ToString()))
                {
                    model.POPPljd = int.Parse(reader["POPPljd"].ToString());
                }
                if (!string.IsNullOrEmpty(reader["POPHeight"].ToString()))
                {
                    model.POPHeight = Convert.ToDecimal(reader["POPHeight"]);
                }
                if (!string.IsNullOrEmpty(reader["POPWith"].ToString()))
                {
                    model.POPWith = Convert.ToDecimal(reader["POPWith"]);
                }
                if (!string.IsNullOrEmpty(reader["POPArea"].ToString()))
                {
                    model.POPArea = Convert.ToDecimal(reader["POPArea"]);
                }
                if (!string.IsNullOrEmpty(reader["POPMaterial"].ToString()))
                {
                    model.POPMaterial = reader["POPMaterial"].ToString();
                }
                model.Sexarea = reader["Sexarea"].ToString();
                if (!string.IsNullOrEmpty(reader["TwoSided"].ToString()))
                {
                    model.TwoSided = (int)reader["TwoSided"];
                }
                if (!string.IsNullOrEmpty(reader["Glass"].ToString()))
                {
                    model.Glass = (int)reader["Glass"];
                }
                if (!string.IsNullOrEmpty(reader["PlatformWith"].ToString()))
                {
                    model.PlatformWith = Convert.ToDecimal(reader["PlatformWith"]);
                }
                if (!string.IsNullOrEmpty(reader["PlatformHeight"].ToString()))
                {
                    model.PlatformHeight = Convert.ToDecimal(reader["PlatformHeight"]);
                }
                if (!string.IsNullOrEmpty(reader["PlatformLong"].ToString()))
                {
                    model.PlatformLong = Convert.ToDecimal(reader["PlatformLong"]);
                }
                if (!string.IsNullOrEmpty(reader["ExamState"].ToString()))
                {
                    model.ExamState = (int)reader["ExamState"];
                }
                if (!string.IsNullOrEmpty(reader["SysTime"].ToString()))
                {
                    model.SysTime = reader["SysTime"].ToString();
                }
                if (!string.IsNullOrEmpty(reader["IsSubmit"].ToString()))
                {
                    model.IsSubmit = (int)reader["IsSubmit"];
                }
                if (!string.IsNullOrEmpty(reader["VMExamState"].ToString()))
                {
                    model.VMExamState = (int)reader["VMExamState"];
                }
                model.POPMaterialRemark = reader["POPMaterialRemark"].ToString();

                modelList.Add(model);
            }
            reader.Close();
            return modelList;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<LN.Model.POPInfo> GetListOrderByShopIDNew(string ShopID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT ID,ShopID,SeatNum,POPSeat,SeatDesc,RealHeight,RealWith,POPHeight,POPWith,POPPlwz,POPPljd,POPArea,POPMaterial,ProductLineID,Sexarea,TwoSided,Glass,PlatformWith,PlatformHeight,PlatformLong,VMExamState,ExamState,SysTime, ");
            strSql.AppendFormat("(SELECT COUNT(ID) FROM imageToPOPTemp WHERE POPID IN (SELECT POPID FROM POPLaunch WHERE BeginDate<=getdate() and EndDate>=getdate()) AND ShopID={0} AND POPinfoID=p.ID) AS IsSubmit,POPMaterialRemark FROM POPInfo AS p  ", ShopID);
            if (ShopID.Trim() != "")
            {
                strSql.Append("  WHERE  ShopID = " + ShopID);
            }
            List<LN.Model.POPInfo> modelList = new List<LN.Model.POPInfo>();
            SqlDataReader reader = DbHelperSQL.ExecuteReader(DbHelperSQL.connectionString(), strSql.ToString());
            LN.Model.POPInfo model;
            while (reader.Read())
            {
                model = new LN.Model.POPInfo();
                if (!string.IsNullOrEmpty(reader["ID"].ToString()))
                {
                    model.ID = int.Parse(reader["ID"].ToString());
                }
                if (!string.IsNullOrEmpty(reader["ShopID"].ToString()))
                {
                    model.ShopID = int.Parse(reader["ShopID"].ToString());
                }

                model.SeatNum = reader["SeatNum"].ToString();
                model.POPSeat = reader["POPSeat"].ToString();
                model.SeatDesc = reader["SeatDesc"].ToString();
                if (!string.IsNullOrEmpty(reader["RealHeight"].ToString()))
                {
                    model.RealHeight = Convert.ToDecimal(reader["RealHeight"].ToString());
                }
                if (!string.IsNullOrEmpty(reader["RealWith"].ToString()))
                {
                    model.RealWith = Convert.ToDecimal(reader["RealWith"].ToString());
                }
                model.POPPlwz = reader["POPPlwz"].ToString();
                if (!string.IsNullOrEmpty(reader["POPPljd"].ToString()))
                {
                    model.POPPljd = int.Parse(reader["POPPljd"].ToString());
                }
                if (!string.IsNullOrEmpty(reader["POPHeight"].ToString()))
                {
                    model.POPHeight = Convert.ToDecimal(reader["POPHeight"]);
                }
                if (!string.IsNullOrEmpty(reader["POPWith"].ToString()))
                {
                    model.POPWith = Convert.ToDecimal(reader["POPWith"]);
                }
                if (!string.IsNullOrEmpty(reader["POPArea"].ToString()))
                {
                    model.POPArea = Convert.ToDecimal(reader["POPArea"]);
                }
                if (!string.IsNullOrEmpty(reader["POPMaterial"].ToString()))
                {
                    model.POPMaterial = reader["POPMaterial"].ToString();
                }
                model.Sexarea = reader["Sexarea"].ToString();
                if (!string.IsNullOrEmpty(reader["TwoSided"].ToString()))
                {
                    model.TwoSided = (int)reader["TwoSided"];
                }
                if (!string.IsNullOrEmpty(reader["Glass"].ToString()))
                {
                    model.Glass = (int)reader["Glass"];
                }
                if (!string.IsNullOrEmpty(reader["PlatformWith"].ToString()))
                {
                    model.PlatformWith = Convert.ToDecimal(reader["PlatformWith"]);
                }
                if (!string.IsNullOrEmpty(reader["PlatformHeight"].ToString()))
                {
                    model.PlatformHeight = Convert.ToDecimal(reader["PlatformHeight"]);
                }
                if (!string.IsNullOrEmpty(reader["PlatformLong"].ToString()))
                {
                    model.PlatformLong = Convert.ToDecimal(reader["PlatformLong"]);
                }
                if (!string.IsNullOrEmpty(reader["ExamState"].ToString()))
                {
                    model.ExamState = (int)reader["ExamState"];
                }
                if (!string.IsNullOrEmpty(reader["VMExamState"].ToString()))
                {
                    model.VMExamState = (int)reader["VMExamState"];
                }
                if (!string.IsNullOrEmpty(reader["SysTime"].ToString()))
                {
                    model.SysTime = reader["SysTime"].ToString();
                }
                if (!string.IsNullOrEmpty(reader["IsSubmit"].ToString()))
                {
                    model.IsSubmit = (int)reader["IsSubmit"];
                }
                model.POPMaterialRemark = reader["POPMaterialRemark"].ToString();

                modelList.Add(model);
            }
            reader.Close();
            return modelList;
        }

        /// <summary>
        /// 查看数据库中是否存在此 位置编号
        /// </summary>
        /// <param name="shopid"></param>
        /// <param name="seatnum"></param>
        /// <returns></returns>
        public int GetOnlyNum(string shopid, string seatnum)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(*) from popinfo ");
            strSql.Append(" where shopID=" + shopid);
            strSql.Append(" and SeatNum='" + seatnum + "'");

            object obj = DbHelperSQL.GetSingle(DbHelperSQL.connectionString(), strSql.ToString());
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
        /// 得到有未审批POP的店铺信息
        /// </summary>
        /// <param name="htable"></param>
        /// <returns></returns>
        public DataTable GetExamPOP(Hashtable htable, ref int TotalNumber)
        {
            SqlParameter[] parm ={
                 
             new SqlParameter("@PosID",SqlDbType.VarChar,20),
             new SqlParameter("@ShopName",SqlDbType.VarChar,100),
             new SqlParameter("@SupplierID",SqlDbType.Int,4),
             new SqlParameter("@ProID",SqlDbType.Int,4),
             new SqlParameter("@CityID",SqlDbType.Int,4),
             new SqlParameter("@btime",SqlDbType.VarChar,20),
             new SqlParameter("@etime",SqlDbType.VarChar,20),
             new SqlParameter("@OrderField",SqlDbType.VarChar,20),
             new SqlParameter("@pageSize",SqlDbType.Int,4),
             new SqlParameter("@pageIndex",SqlDbType.Int,4),
             new SqlParameter("@TotalRecord",SqlDbType.Int,4),
             new SqlParameter("@dept",SqlDbType.VarChar,10),
             new SqlParameter("@areaid",SqlDbType.VarChar,200),
             new SqlParameter("@strWhere",SqlDbType.VarChar,50)
           };

            parm[0].Value = htable["PosID"].ToString();
            parm[1].Value = htable["ShopName"].ToString();
            parm[2].Value = htable["Supplier"].ToString();
            parm[3].Value = htable["Pro"].ToString();
            parm[4].Value = htable["City"].ToString();
            parm[5].Value = htable["btime"].ToString();
            parm[6].Value = htable["etime"].ToString();
            parm[7].Value = htable["Order"].ToString();
            parm[8].Value = htable["pageSize"].ToString();
            parm[9].Value = htable["pageIndex"].ToString();
            parm[10].Direction = ParameterDirection.Output;
            parm[11].Value = htable["dept"].ToString();
            parm[12].Value = htable["areaid"].ToString();
            parm[13].Value = htable["strwhere"].ToString();
            DataSet ds = DbHelperSQL.RunProcedure(DbHelperSQL.connectionString(), "GetNoExamPOP", parm, "dt");
            TotalNumber = int.Parse(parm[8].Value.ToString());
            return ds.Tables[0];

        }


        /// <summary>
        /// 得到店铺的POP详细信息
        /// </summary>
        /// <param name="htable"></param>
        /// <returns></returns>
        public DataTable GetShopPOPInfoList(Hashtable htable)
        {

            string strsql = @"select poin.ID,poin.ShopID,SeatNum,POPSeat,SeatDesc,RealHeight,RealWith,POPHeight,POPWith
,POPPlwz,POPPljd,POPArea,POPMaterial,ProductLineID,Sexarea
,TwoSided,Glass,PlatformWith,PlatformHeight,PlatformLong,poin.VMExamState,poin.ExamState,poin.SysTime 
,pimg.ImageUrl,pimg.SmallImageUrl,imtp.NewImageUrl_Small,imtp.NewImageUrl_Big,imtp.OldImageUrl_Small,imtp.OldImageUrl_Big,imtp.Id as imageToPOP_ID
 from imageToPOP imtp
inner join ShopInfo shin on imtp.shopid = shin.shopid
inner join POPInfo poin on poin.id = imtp.POPinfoID
inner join POPImageData pimg on pimg.imageID=imtp.imageID
where imtp.PopId =@POPID and shin.Shopid = @ShopID";
            SqlParameter[] parm ={
             new SqlParameter("@POPID",SqlDbType.VarChar,20),
             new SqlParameter("@ShopID",SqlDbType.VarChar,100)
           };

            parm[0].Value = htable["POPID"].ToString();
            parm[1].Value = htable["ShopID"].ToString();


            DataSet ds = DbHelperSQL.Query(DbHelperSQL.connectionString(), strsql, parm);

            return ds.Tables[0];

        }


        /// <summary>
        ///  部门经理确认店铺没有审批的POP  审核完毕成功POP后 将审核的POP的ID插入到NewAddPOP表中进行记录 表示为新增的POP信息。
        /// </summary>
        /// <param name="shopid"></param>
        /// <returns></returns>
        public bool ExamShopPOP(List<string> IDlist, string userID)
        {
            List<string> strsqllist = new List<string>();
            string popid = new POPLaunch().GetLastPOPID();
            for (int i = 0; i < IDlist.Count; i++)
            {
                strsqllist.Add("DELETE FROM NewAddPOP WHERE POPID='" + popid + "' AND POPinfoID='" + IDlist[i].ToString() + "'; insert into NewAddPOP (POPID,POPinfoID) values ('" + popid + "'," + IDlist[i].ToString() + ")");
                strsqllist.Add(" update POPInfo set ExamState=1,ExamUserID= " + userID + ",ExamDesc=CONVERT(varchar(30), GETDATE(), 20) where ID=" + IDlist[i].ToString());
            }

            try
            {
                DbHelperSQL.ExecuteSqlTran(DbHelperSQL.connectionString(), strsqllist);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// 部门经理放弃Pop信息 将审批状态改为-1 即为放弃
        /// </summary>
        /// <param name="ID"></param>
        public void giveupPOP(string ID, string UserID)
        {
            string strsql = "update popinfo set examState=-1,ExamUserID= " + UserID + "  where ID in (" + ID + ")";

            DbHelperSQL.ExecuteSql(DbHelperSQL.connectionString(), strsql);
        }

        /// <summary>
        /// 省区VM审核季度新增POP信息
        /// </summary>
        /// <param name="ExamState"></param>
        /// <param name="ID"></param>
        /// <param name="UserID"></param>
        public bool VMExamPOPState(string ExamState, string ID, string UserID)
        {
            try
            {
                string strsql = "update popinfo set VMexamState=" + ExamState + ",VMExamUserID= " + UserID + ",VMExamDesc=CONVERT(varchar(30), GETDATE(), 20)  where ID in (" + ID + ")";
                DbHelperSQL.ExecuteSql(DbHelperSQL.connectionString(), strsql);
                return true;
            }
            catch (Exception)
            {

                return false;
            }

        }

        /// <summary>
        /// 供应商查找指定店铺的安装POP信息列表，以便上传图片
        /// </summary>
        /// <param name="SupplierID">供应商编号</param>
        /// <param name="ShopName">店铺名称</param>
        /// <param name="PosID">POS编号</param>
        /// <returns>返回列表集合</returns>
        public DataTable GetPOPListByShopID(string SupplierID, string ShopID)
        {
            DataTable dt = null;
            SqlParameter[] parm ={    
                             new SqlParameter("@SupplierID",SqlDbType.VarChar,50),
                             new SqlParameter("@ShopID",SqlDbType.VarChar,200),
                             new SqlParameter("@IsState",SqlDbType.VarChar,50),
                             new SqlParameter("@GetInState",SqlDbType.VarChar,50)};

            parm[0].Value = SupplierID;
            parm[1].Value = ShopID;
            parm[2].Value = "安装到店";
            parm[3].Value = "已收货";
            DataSet ds = DbHelperSQL.RunProcedure(DbHelperSQL.connectionString(), "GetPOPListByShopID", parm, "dt");
            if (ds != null)
                dt = ds.Tables[0];

            return dt;
        }

        /// <summary>
        /// VM管理员审核指定店铺的安装POP图片信息列表
        /// </summary>
        /// <param name="POPID">发起的POP编号</param>
        /// <param name="SupplierID">供应商编号</param>
        /// <param name="ShopID">店铺编号</param>
        /// <returns>返回列表集合</returns>
        public DataTable GetPOPJudgeListByShopID(string POPID, string SupplierID, string ShopID)
        {
            DataTable dt = null;
            SqlParameter[] parm ={    
                             new SqlParameter("@POPID",SqlDbType.VarChar,100),
                             new SqlParameter("@SupplierID",SqlDbType.VarChar,50),
                             new SqlParameter("@ShopID",SqlDbType.VarChar,50)};

            parm[0].Value = POPID;
            parm[1].Value = SupplierID;
            parm[2].Value = ShopID;
            DataSet ds = DbHelperSQL.RunProcedure(DbHelperSQL.connectionString(), "GetPOPJudgeListByShopID", parm, "dt");
            if (ds != null)
                dt = ds.Tables[0];

            return dt;
        }

        /// <summary>
        /// 更新POP的属性
        /// </summary>
        /// <param name="id"></param>
        /// <param name="pro"></param>
        public void Update_type(string id, string pro, string material)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("update POPInfo set ProductLineID=");
            sb.Append(pro);
            sb.Append(",POPMaterial='");
            sb.Append(material);
            sb.Append("'");
            sb.Append(" where id=");
            sb.Append(id);
            DbHelperSQL.Query(DbHelperSQL.connectionString(), sb.ToString());
        }

        /// <summary>
        /// 得到新增店铺pop的数据
        /// </summary>
        /// <param name="ht"></param>
        /// <returns></returns>
        public DataSet GetNewaddPOPCount(string strWhere)
        {
            SqlParameter[] parm ={    
                             new SqlParameter("@StrWhere",SqlDbType.VarChar,500)
                            };
            parm[0].Value = strWhere;

            DataSet ds = DbHelperSQL.RunProcedure(DbHelperSQL.connectionString(), "NewAddPOPAnalysis", parm, "ds");
            return ds;

        }

        public int Getsetupcount(string shopid, string Popid)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("select count(*) from imagetopop where shopid=" + shopid + " and popid ='" + Popid + "'");
            object obj = DbHelperSQL.GetSingle(DbHelperSQL.connectionString(), sb.ToString());
            if (obj != null)
                return (int)obj;
            else
                return 0;
        }

        /// <summary>
        /// 得到新加pop的位置编号
        /// </summary>
        /// <returns></returns>
        public string Getnextseatnum(string shopid)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("select  isnull(max(cast( seatnum as int)+1),1) from popinfo where shopid= " + shopid);
            object obj = DbHelperSQL.GetSingle(DbHelperSQL.connectionString(), sb.ToString());
            if (obj != null)
                return obj.ToString();
            else
                return "0";
        }

        /// <summary>
        /// 判断指定店铺的POP是否全部审核通过
        /// </summary>
        /// <param name="ShopID">店铺编号</param>
        /// <returns>是否全部审核</returns>
        public int IsAllExamByShopID(int ShopID)
        {
            int _return = 0;
            SqlParameter[] parm ={    
                             new SqlParameter("@ShopID",SqlDbType.Int,4)
                            };
            parm[0].Value = ShopID;

            object obj = DbHelperSQL.RunProcedure(DbHelperSQL.connectionString(), "IsAllExamByShopID", parm, out _return);
            if (obj != null)
                _return = Convert.ToInt32(obj);

            return _return;

        }

        /// <summary>
        /// 隐藏指定画面的POP信息
        /// </summary>
        /// <param name="imgIDList">画面编号集合</param>
        /// <returns>是否隐藏成功</returns>
        public int UpdateIsHide(string imgIDList)
        {
            int _return = 0;
            StringBuilder strSql = new StringBuilder();
            strSql.Append("UPDATE POPInfo SET ");
            strSql.Append(" IsHide=0; ");
            if (!String.IsNullOrEmpty(imgIDList))
            {
                strSql.Append("UPDATE POPInfo SET ");
                strSql.Append(" IsHide=1 ");
                strSql.AppendFormat(" WHERE ID IN (SELECT [POPinfoID] FROM [imageToPOP] WHERE [imageID] IN (SELECT [ImageID] FROM [POPImageData] WHERE ImageLevel in ({0})));", imgIDList);
                strSql.Append(" SELECT @@ROWCOUNT; ");
            }
            else
            {
                strSql.Append(" SELECT @@ROWCOUNT; ");
            }

            object obj = DbHelperSQL.GetSingle(DbHelperSQL.connectionString(), strSql.ToString());
            if (obj != null)
                _return = Convert.ToInt32(obj);

            return _return;
        }

        //public int UpdateIsHide(string imgIDList)
        //{
        //    int _return = 0;
        //    StringBuilder strSql = new StringBuilder();
        //    if (!String.IsNullOrEmpty(imgIDList))
        //    {
        //        strSql.Append("UPDATE POPInfo SET ");
        //        strSql.Append(" IsHide=1 ");
        //        strSql.AppendFormat(" WHERE ID IN (SELECT [POPinfoID] FROM [imageToPOP] WHERE [imageID] IN (SELECT [ImageID] FROM [POPImageData] WHERE ImageLevel in ({0})));", imgIDList);
        //        strSql.Append(" SELECT @@ROWCOUNT; ");
        //    }
        //    else
        //    {
        //        strSql.Append("UPDATE POPInfo SET ");
        //        strSql.Append(" IsHide=0; ");
        //        strSql.Append(" SELECT @@ROWCOUNT; ");
        //    }

        //    object obj = DbHelperSQL.GetSingle(DbHelperSQL.connectionString(), strSql.ToString());
        //    if (obj != null)
        //        _return = Convert.ToInt32(obj);

        //    return _return;
        //}

        public DataSet GetDSList(string whereStr)
        {
            string sql = "select * from POPInfo";
            if (!string.IsNullOrWhiteSpace(whereStr))
            {
                sql +=" where "+ whereStr;
            }
            DataSet ds = DbHelperSQL.Query(DbHelperSQL.connectionString(), sql);
            return ds;
        }

        public int GetMaxPOPNumByShopId(int shopId)
        {
            string sql = "select max(cast(SeatNum as int)) from POPInfo where ShopID=" + shopId;
            object obj = DbHelperSQL.GetSingle(DbHelperSQL.connectionString(), sql);
            if (obj != null)
                return int.Parse(obj.ToString());
            else
                return 0;
        }


        #endregion  成员方法
    }
}

