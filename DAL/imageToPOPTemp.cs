using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using LN.DBUtility;//请先添加引用
namespace LN.DAL
{
    /// <summary>
    /// 数据访问类imageToPOPTemp。
    /// </summary>
    public class imageToPOPTemp
    {
        public imageToPOPTemp()
        { }
        #region  成员方法

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(LN.Model.imageToPOPTemp model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into imageToPOPTemp(");
            strSql.Append("POPID,POPinfoID,imageID,prolineID,shopid,sysTime)");
            strSql.Append(" values (");
            strSql.Append("@POPID,@POPinfoID,@imageID,@prolineID,@shopid,@sysTime)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@POPID", SqlDbType.VarChar,50),
					new SqlParameter("@POPinfoID", SqlDbType.Int,4),
					new SqlParameter("@imageID", SqlDbType.Int,4),
					new SqlParameter("@prolineID", SqlDbType.Int,4),
					new SqlParameter("@shopid", SqlDbType.Int,4),
					new SqlParameter("@sysTime", SqlDbType.DateTime)};
            parameters[0].Value = model.POPID;
            parameters[1].Value = model.POPinfoID;
            parameters[2].Value = model.imageID;
            parameters[3].Value = model.prolineID;
            parameters[4].Value = model.shopid;
            parameters[5].Value = model.sysTime;

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
        /// 删除一条数据
        /// </summary>
        public void Delete(int ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from imageToPOPTemp ");
            strSql.Append(" where ID=@ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)};
            parameters[0].Value = ID;

            DbHelperSQL.ExecuteSql(DbHelperSQL.connectionString(), strSql.ToString(), parameters);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void Delete(string str)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from imageToPOPTemp ");
            strSql.Append(" where  " + str);

            DbHelperSQL.ExecuteSql(DbHelperSQL.connectionString(), strSql.ToString());
        }


        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ID,POPID,POPinfoID,imageID,prolineID,shopid,sysTime ");
            strSql.Append(" FROM imageToPOPTemp ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(DbHelperSQL.connectionString(), strSql.ToString());
        }

        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            if (Top > 0)
            {
                strSql.Append(" top " + Top.ToString());
            }
            strSql.Append(" ID,POPID,POPinfoID,imageID,prolineID,shopid,sysTime ");
            strSql.Append(" FROM imageToPOPTemp ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return DbHelperSQL.Query(DbHelperSQL.connectionString(), strSql.ToString());
        }

        /// <summary>
        /// 判断店铺POP是否全部提交订单
        /// </summary>
        /// <param name="POPID">指定POP发起编号</param>
        /// <param name="ShopID">店铺编号</param>
        /// <returns>返回是否全部提交订单</returns>
        public int POPUniformSubmit_old(string ShopID)
        {
            int _return = 0;
            SqlParameter[] parameters = {
					new SqlParameter("@ShopID", SqlDbType.VarChar,4)};
            parameters[0].Value = ShopID;
            object obj = DbHelperSQL.RunProcedure(DbHelperSQL.connectionString(), "POPUniformSubmit", parameters, out _return);

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
        /// 提交订单 add by mhj 20140310
        /// </summary>
        /// <param name="ShopID"></param>
        /// <returns></returns>
        public int POPUniformSubmit(string ShopID)
        {
            string strSql = "SELECT COUNT(ID) FROM imageToPOPTemp WHERE POPID = (SELECT TOP 1 POPID FROM [POPChangeSet] WHERE ShopID=" + ShopID + " ORDER BY ID DESC)  AND shopid=" + ShopID;
            int tempPOPCount = int.Parse(DbHelperSQL.Query(DbHelperSQL.connectionString(), strSql.ToString()).Tables[0].Rows[0][0].ToString());
            strSql = "SELECT COUNT(ID) FROM POPInfo WHERE ExamState=1 and VMExamState=1 and IsHide=0  AND shopid=" + ShopID;
            int POPCount = int.Parse(DbHelperSQL.Query(DbHelperSQL.connectionString(), strSql.ToString()).Tables[0].Rows[0][0].ToString());
            if (tempPOPCount == POPCount)
            {
                strSql = "DELETE FROM imageToPOP WHERE POPID=(SELECT TOP 1 POPID FROM [POPChangeSet] WHERE ShopID=" + ShopID + " ORDER BY ID DESC)  AND shopid=" + ShopID;
                strSql += ";INSERT INTO imageToPOP(POPID,POPinfoID,imageID,prolineID,shopid,sysTime)SELECT POPID,POPinfoID,imageID,prolineID,shopid,sysTime FROM imageToPOPTemp ";
                strSql += "WHERE POPID=(SELECT TOP 1 POPID FROM POPChangeSet WHERE ShopID=" + ShopID + " ORDER BY ID DESC) AND shopid=" + ShopID;
                DbHelperSQL.ExecuteSql(DbHelperSQL.connectionString(), strSql.ToString());
                return 1;
            }
            else
            {
                return 0;
            }           
        }


        #endregion  成员方法
    }
}

