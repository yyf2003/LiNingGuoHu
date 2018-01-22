using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using LN.DBUtility;

namespace LN.DAL
{
    public class PromotionShopInfo
    {
        public int Add(LN.Model.PromotionShopInfo model)
        {
            string sql = "insert into PromotionShopInfo(PosID,Shopname,Shopsamplename,ShopAddress,ProvinceID,CityID,TownID,areaid,LinkMan,LinkPhone,PostAddress,DealerID,DealerName,FXID,FXName,ShopOwnerShip,CustomerCard,CreateDate,SupplierId,ShopImageId,ShopLevelId,ShopState,ShopType,SaleTypeID,TCL_ID,ACL_ID,BigArea,ShopCategory,Remark) values(@PosID,@Shopname,@Shopsamplename,@ShopAddress,@ProvinceID,@CityID,@TownID,@areaid,@LinkMan,@LinkPhone,@PostAddress,@DealerID,@DealerName,@FXID,@FXName,@ShopOwnerShip,@CustomerCard,@CreateDate,@SupplierId,@ShopImageId,@ShopLevelId,@ShopState,@ShopType,@SaleTypeID,@TCL_ID,@ACL_ID,@BigArea,@ShopCategory,@Remark);select @@identity";
            SqlParameter[] parameters = new SqlParameter[] { 
               new SqlParameter("@PosID",model.PosID),
               new SqlParameter("@Shopname",model.Shopname),
               new SqlParameter("@Shopsamplename",model.Shopsamplename),
               new SqlParameter("@ShopAddress",model.ShopAddress),
               new SqlParameter("@ProvinceID",model.ProvinceID),
               new SqlParameter("@CityID",model.CityID),
               new SqlParameter("@TownID",model.TownID),
               new SqlParameter("@areaid",model.areaid),
               new SqlParameter("@LinkMan",model.LinkMan),
               new SqlParameter("@LinkPhone",model.LinkPhone),
               new SqlParameter("@PostAddress",model.PostAddress),
               new SqlParameter("@DealerID",model.DealerID),
               new SqlParameter("@DealerName",model.DealerName),
               new SqlParameter("@FXID",model.FXID),
               new SqlParameter("@FXName",model.FXName),
               new SqlParameter("@ShopOwnerShip",model.ShopOwnerShip),
               new SqlParameter("@CustomerCard",model.CustomerCard),
               new SqlParameter("@CreateDate",model.CreateDate),
               new SqlParameter("@SupplierId",model.SupplierId),
               new SqlParameter("@ShopImageId",model.ShopImageId),
               new SqlParameter("@ShopLevelId",model.ShopLevelId),

               new SqlParameter("@ShopState",model.ShopState),
               new SqlParameter("@ShopType",model.ShopType),
               new SqlParameter("@SaleTypeID",model.SaleTypeID),
               new SqlParameter("@TCL_ID",model.TCL_ID),
               new SqlParameter("@ACL_ID",model.ACL_ID),
               new SqlParameter("@BigArea",model.BigArea),
               new SqlParameter("@ShopCategory",model.ShopCategory),
               new SqlParameter("@Remark",model.Remark)
            };
            object obj = DbHelperSQL.GetSingle(DbHelperSQL.connectionString(), sql, parameters);
            return obj != null ? int.Parse(obj.ToString()) : 0;

        }

        public bool Update(LN.Model.PromotionShopInfo model)
        {
            StringBuilder sql = new System.Text.StringBuilder();
            sql.Append("update PromotionShopInfo set ");
            List<SqlParameter> paraList = new List<SqlParameter>();
            if (model != null)
            {
                if (model.PosID != null)
                {
                    sql.Append(" PosID=@PosID,");
                    paraList.Add(new SqlParameter("@PosID", model.PosID));
                }
                if (model.Shopname != null)
                {
                    sql.Append(" Shopname=@Shopname,");
                    paraList.Add(new SqlParameter("@Shopname", model.Shopname));
                }
                if (model.Shopsamplename != null)
                {
                    sql.Append(" Shopsamplename=@Shopsamplename,");
                    paraList.Add(new SqlParameter("@Shopsamplename", model.Shopsamplename));
                }
                if (model.ShopAddress != null)
                {
                    sql.Append(" ShopAddress=@ShopAddress,");
                    paraList.Add(new SqlParameter("@ShopAddress", model.ShopAddress));
                }
                if (model.ProvinceID != null)
                {
                    sql.Append(" ProvinceID=@ProvinceID,");
                    paraList.Add(new SqlParameter("@ProvinceID", model.ProvinceID));
                }
                if (model.CityID != null)
                {
                    sql.Append(" CityID=@CityID,");
                    paraList.Add(new SqlParameter("@CityID", model.CityID));
                }
                if (model.TownID != null)
                {
                    sql.Append(" TownID=@TownID,");
                    paraList.Add(new SqlParameter("@TownID", model.TownID));
                }
                if (model.areaid != null)
                {
                    sql.Append(" areaid=@areaid,");
                    paraList.Add(new SqlParameter("@areaid", model.areaid));
                }
                if (model.LinkMan != null)
                {
                    sql.Append(" LinkMan=@LinkMan,");
                    paraList.Add(new SqlParameter("@LinkMan", model.LinkMan));
                }
                if (model.LinkPhone != null)
                {
                    sql.Append(" LinkPhone=@LinkPhone,");
                    paraList.Add(new SqlParameter("@LinkPhone", model.LinkPhone));
                }
                if (model.PostAddress != null)
                {
                    sql.Append(" PostAddress=@PostAddress,");
                    paraList.Add(new SqlParameter("@PostAddress", model.PostAddress));
                }

                if (model.DealerID != null)
                {
                    sql.Append(" DealerID=@DealerID,");
                    paraList.Add(new SqlParameter("@DealerID", model.DealerID));
                }
                if (model.DealerName != null)
                {
                    sql.Append(" DealerName=@DealerName,");
                    paraList.Add(new SqlParameter("@DealerName", model.DealerName));
                }
                if (model.FXID != null)
                {
                    sql.Append(" FXID=@FXID,");
                    paraList.Add(new SqlParameter("@FXID", model.FXID));
                }
                if (model.FXName != null)
                {
                    sql.Append(" FXName=@FXName,");
                    paraList.Add(new SqlParameter("@FXName", model.FXName));
                }
                if (model.ShopOwnerShip != null)
                {
                    sql.Append(" ShopOwnerShip=@ShopOwnerShip,");
                    paraList.Add(new SqlParameter("@ShopOwnerShip", model.ShopOwnerShip));
                }
                if (model.CustomerCard != null)
                {
                    sql.Append(" CustomerCard=@CustomerCard,");
                    paraList.Add(new SqlParameter("@CustomerCard", model.CustomerCard));
                }
                if (model.CreateDate != null)
                {
                    sql.Append(" CreateDate=@CreateDate,");
                    paraList.Add(new SqlParameter("@CreateDate", model.CreateDate));
                }
                if (model.SupplierId != null)
                {
                    sql.Append(" SupplierId=@SupplierId,");
                    paraList.Add(new SqlParameter("@SupplierId", model.SupplierId));
                }
                if (model.ShopImageId != null)
                {
                    sql.Append(" ShopImageId=@ShopImageId,");
                    paraList.Add(new SqlParameter("@ShopImageId", model.ShopImageId));
                }
                if (model.ShopLevelId != null)
                {
                    sql.Append(" ShopLevelId=@ShopLevelId,");
                    paraList.Add(new SqlParameter("@ShopLevelId", model.ShopLevelId));
                }
                if (model.IsWeiDeShop != null)
                {
                    sql.Append(" IsWeiDeShop=@IsWeiDeShop,");
                    paraList.Add(new SqlParameter("@IsWeiDeShop", model.IsWeiDeShop));
                }
                if (model.ShopState != null)
                {
                    sql.Append(" ShopState=@ShopState,");
                    paraList.Add(new SqlParameter("@ShopState", model.ShopState));
                }
                if (model.ShopType != null)
                {
                    sql.Append(" ShopType=@ShopType,");
                    paraList.Add(new SqlParameter("@ShopType", model.ShopType));
                }
                if (model.SaleTypeID != null)
                {
                    sql.Append(" SaleTypeID=@SaleTypeID,");
                    paraList.Add(new SqlParameter("@SaleTypeID", model.SaleTypeID));
                }
                if (model.TCL_ID != null)
                {
                    sql.Append(" TCL_ID=@TCL_ID,");
                    paraList.Add(new SqlParameter("@TCL_ID", model.TCL_ID));
                }

                if (model.ACL_ID != null)
                {
                    sql.Append(" ACL_ID=@ACL_ID,");
                    paraList.Add(new SqlParameter("@ACL_ID", model.ACL_ID));
                }
                if (model.BigArea != null)
                {
                    sql.Append(" BigArea=@BigArea,");
                    paraList.Add(new SqlParameter("@BigArea", model.BigArea));
                }
                if (model.ShopCategory != null)
                {
                    sql.Append(" ShopCategory=@ShopCategory,");
                    paraList.Add(new SqlParameter("@ShopCategory", model.ShopCategory));
                }
                if (model.Remark != null)
                {
                    sql.Append(" Remark=@Remark,");
                    paraList.Add(new SqlParameter("@Remark", model.Remark));
                }
                string sql1 = sql.ToString().Substring(0, sql.Length - 1);
                if (model.ID>0)
                {
                    sql1 += " where ID=@ID ";
                    paraList.Add(new SqlParameter("@ID", model.ID));
                    return DbHelperSQL.ExecuteSql(DbHelperSQL.connectionString(), sql1, paraList.ToArray()) > 0;
                }
                else
                    return false;
            }
            else
                return false;
        }

        public void Delete(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete PromotionShopInfo ");
            strSql.Append(" where ID=@Id ");
            SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4)};
            parameters[0].Value = id;
            DbHelperSQL.ExecuteSql(DbHelperSQL.connectionString(), strSql.ToString(), parameters);
        }

        public DataSet GetList(string whereStr)
        {
            string sql = "select * from PromotionShopInfo ";
            if (!string.IsNullOrEmpty(whereStr))
            {
                sql += " where " + whereStr;
            }
            return DbHelperSQL.Query(DbHelperSQL.connectionString(), sql);
        }

        public DataSet GetJoinList(string whereStr)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append(@"select PromotionShopInfo.ID
                          ,PromotionShopInfo.PosID
                          ,PromotionShopInfo.Shopname
                          ,PromotionShopInfo.ShopAddress
                          ,DepartMentInfo.department AreaName
                          ,ProvinceData.ProvinceName
                          ,CityData.CityName
                          ,PromotionShopInfo.DealerID
                          ,PromotionShopInfo.FXID
                          ,PromotionShopInfo.LinkMan
                          ,PromotionShopInfo.LinkPhone
                          ,PromotionShopInfo.ShopOwnerShip
                          ,PromotionShopInfo.CustomerCard
                          ,PromotionShopInfo.PostAddress
                          ,PromotionShopImage.ImageName
                          ,PromotionShopLevel.ShortName ShopLevelName
                          ,ShopStateInfo.ShopState
                          ,ShopType.ShopTypename
                          ,SaleTypeInfo.SaleType
                          ,TownCityLevel.TCL_Name
                          ,AreaCityLevel.ACL_Name 
                          ,PromotionShopInfo.BigArea
                          ,PromotionShopInfo.ShopCategory
                          ,PromotionShopInfo.Remark
                          from PromotionShopInfo 
                          left join ProvinceData on ProvinceData.ProvinceID=PromotionShopInfo.ProvinceID
                          left join CityData on CityData.CItyID=PromotionShopInfo.CityID 
                          left join PromotionShopImage on PromotionShopImage.Id=PromotionShopInfo.ShopImageId
                          left join PromotionShopLevel on PromotionShopLevel.Id=PromotionShopInfo.ShopLevelId
                          left join ShopStateInfo on ShopStateInfo.ID=PromotionShopInfo.ShopState
                          left join ShopType on ShopType.ID = PromotionShopInfo.ShopType
                          left join SaleTypeInfo on SaleTypeInfo.SaleTypeID=PromotionShopInfo.SaleTypeID
                          left join TownCityLevel on TownCityLevel.TCL_Id = PromotionShopInfo.TCL_ID
                          left join AreaCityLevel on AreaCityLevel.ACL_Id = PromotionShopInfo.ACL_ID
                          left join DepartMentInfo on DepartMentInfo.ID = PromotionShopInfo.areaid");
            if (!string.IsNullOrWhiteSpace(whereStr))
            {
                sql.Append(" where " + whereStr);
            }
            return DbHelperSQL.Query(DbHelperSQL.connectionString(), sql.ToString());
        }

        public DataSet GetJoinList(string whereStr, string rackType, string rackOperater, int rackNum, int currPage, int pageSize, out int totalRecord)
        {
            totalRecord=0;
            SqlParameter[] paras = new SqlParameter[] { 
               new SqlParameter("@shopWhere",whereStr),
               new SqlParameter("@rackType",rackType),
               new SqlParameter("@rackOperater",rackOperater),
               new SqlParameter("@rackNum",rackNum),
               new SqlParameter("@currPage",currPage),
               new SqlParameter("@pageSize",pageSize),
               new SqlParameter("@totalRecord",SqlDbType.Int,4)
            };
            paras[6].Direction = ParameterDirection.Output;
            DataSet ds = DbHelperSQL.RunProcedure(DbHelperSQL.connectionString(), "GetPromotionShopList", paras, "dt");
            if (ds != null)
            {
                totalRecord = (int)paras[6].Value;
            }
            return ds;
        }
        
        public DataSet GetList(string whereStr, int currPage, int pageSize)
        {
            string sql = "select * from (select row_number() over(order by ID desc) row,* from PromotionShopInfo where 1=1 " + whereStr + ") temp where row between ((@currPage-1)*@pageSize+1) and (@currPage*@pageSize)";
            SqlParameter[] paras = new SqlParameter[] { 
                new SqlParameter("@currPage",currPage),
                new SqlParameter("@pageSize",pageSize)
            };
            return DbHelperSQL.Query(DbHelperSQL.connectionString(), sql, paras);
        }

        public int GetPageCount(string whereStr)
        {
            string sql = "select count(*) from PromotionShopInfo where 1=1 " + whereStr;
            object obj = DbHelperSQL.GetSingle(DbHelperSQL.connectionString(), sql);
            return obj != null ? int.Parse(obj.ToString()) : 0;
        }

        public LN.Model.PromotionShopInfo GetModel(int id)
        {
            DataSet ds = GetList(string.Format(" Id={0}", id));
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                LN.Model.PromotionShopInfo model = new Model.PromotionShopInfo();
                DataRow dr = ds.Tables[0].Rows[0];
                model.ID = id;
                if (!string.IsNullOrEmpty(dr["PosID"].ToString()))
                {
                    model.PosID = dr["PosID"].ToString();
                }
                if (!string.IsNullOrEmpty(dr["Shopname"].ToString()))
                {
                    model.Shopname = dr["Shopname"].ToString();
                }
                if (!string.IsNullOrEmpty(dr["Shopsamplename"].ToString()))
                {
                    model.Shopsamplename = dr["Shopsamplename"].ToString();
                }
                if (!string.IsNullOrEmpty(dr["ShopAddress"].ToString()))
                {
                    model.ShopAddress = dr["ShopAddress"].ToString();
                }
                if (!string.IsNullOrEmpty(dr["ProvinceID"].ToString()))
                {
                    model.ProvinceID = int.Parse(dr["ProvinceID"].ToString());
                }
                if (!string.IsNullOrEmpty(dr["CityID"].ToString()))
                {
                    model.CityID = int.Parse(dr["CityID"].ToString());
                }
                if (!string.IsNullOrEmpty(dr["TownID"].ToString()))
                {
                    model.TownID = int.Parse(dr["TownID"].ToString());
                }
                if (!string.IsNullOrEmpty(dr["areaid"].ToString()))
                {
                    model.areaid = int.Parse(dr["areaid"].ToString());
                }
                if (!string.IsNullOrEmpty(dr["LinkMan"].ToString()))
                {
                    model.LinkMan = dr["LinkMan"].ToString();
                }
                if (!string.IsNullOrEmpty(dr["LinkPhone"].ToString()))
                {
                    model.LinkPhone = dr["LinkPhone"].ToString();
                }
                if (!string.IsNullOrEmpty(dr["PostAddress"].ToString()))
                {
                    model.PostAddress = dr["PostAddress"].ToString();
                }
                if (!string.IsNullOrEmpty(dr["DealerID"].ToString()))
                {
                    model.DealerID = dr["DealerID"].ToString();
                }
                if (!string.IsNullOrEmpty(dr["DealerName"].ToString()))
                {
                    model.DealerName = dr["DealerName"].ToString();
                }
                if (!string.IsNullOrEmpty(dr["FXID"].ToString()))
                {
                    model.FXID = dr["FXID"].ToString();
                }
                if (!string.IsNullOrEmpty(dr["FXName"].ToString()))
                {
                    model.FXName = dr["FXName"].ToString();
                }
                if (!string.IsNullOrEmpty(dr["ShopOwnerShip"].ToString()))
                {
                    model.ShopOwnerShip = dr["ShopOwnerShip"].ToString();
                }
                if (!string.IsNullOrEmpty(dr["CustomerCard"].ToString()))
                {
                    model.CustomerCard = dr["CustomerCard"].ToString();
                }
                if (!string.IsNullOrEmpty(dr["CreateDate"].ToString()))
                {
                    model.CreateDate = DateTime.Parse(dr["CreateDate"].ToString());
                }
                if (!string.IsNullOrEmpty(dr["SupplierId"].ToString()))
                {
                    model.SupplierId = int.Parse(dr["SupplierId"].ToString());
                }
                if (!string.IsNullOrEmpty(dr["ShopImageId"].ToString()))
                {
                    model.ShopImageId = int.Parse(dr["ShopImageId"].ToString());
                }
                if (!string.IsNullOrEmpty(dr["ShopLevelId"].ToString()))
                {
                    model.ShopLevelId = int.Parse(dr["ShopLevelId"].ToString());
                }
                if (!string.IsNullOrEmpty(dr["BigArea"].ToString()))
                {
                    model.BigArea = dr["BigArea"].ToString();
                }
                if (!string.IsNullOrEmpty(dr["ShopCategory"].ToString()))
                {
                    model.ShopCategory = dr["ShopCategory"].ToString();
                }
                if (!string.IsNullOrEmpty(dr["ShopState"].ToString()))
                {
                    model.ShopState = int.Parse(dr["ShopState"].ToString());
                }
                if (!string.IsNullOrEmpty(dr["ShopType"].ToString()))
                {
                    model.ShopType = int.Parse(dr["ShopType"].ToString());
                }
                if (!string.IsNullOrEmpty(dr["SaleTypeID"].ToString()))
                {
                    model.SaleTypeID = int.Parse(dr["SaleTypeID"].ToString());
                }
                if (!string.IsNullOrEmpty(dr["TCL_ID"].ToString()))
                {
                    model.TCL_ID = int.Parse(dr["TCL_ID"].ToString());
                }
                if (!string.IsNullOrEmpty(dr["ACL_ID"].ToString()))
                {
                    model.ACL_ID = int.Parse(dr["ACL_ID"].ToString());
                }
                return model;
            }
            else
                return null;
        }

        public LN.Model.PromotionShopInfo GetModel(string whereStr)
        {
            DataSet ds = GetList(whereStr);
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                LN.Model.PromotionShopInfo model = new Model.PromotionShopInfo();
                DataRow dr = ds.Tables[0].Rows[0];
                if (!string.IsNullOrEmpty(dr["ID"].ToString()))
                {
                    model.ID =int.Parse(dr["ID"].ToString());
                }
                if (!string.IsNullOrEmpty(dr["PosID"].ToString()))
                {
                    model.PosID = dr["PosID"].ToString();
                }
                if (!string.IsNullOrEmpty(dr["Shopname"].ToString()))
                {
                    model.Shopname = dr["Shopname"].ToString();
                }
                if (!string.IsNullOrEmpty(dr["Shopsamplename"].ToString()))
                {
                    model.Shopsamplename = dr["Shopsamplename"].ToString();
                }
                if (!string.IsNullOrEmpty(dr["ShopAddress"].ToString()))
                {
                    model.ShopAddress = dr["ShopAddress"].ToString();
                }
                if (!string.IsNullOrEmpty(dr["ProvinceID"].ToString()))
                {
                    model.ProvinceID = int.Parse(dr["ProvinceID"].ToString());
                }
                if (!string.IsNullOrEmpty(dr["CityID"].ToString()))
                {
                    model.CityID = int.Parse(dr["CityID"].ToString());
                }
                if (!string.IsNullOrEmpty(dr["TownID"].ToString()))
                {
                    model.TownID = int.Parse(dr["TownID"].ToString());
                }
                if (!string.IsNullOrEmpty(dr["areaid"].ToString()))
                {
                    model.areaid = int.Parse(dr["areaid"].ToString());
                }
                if (!string.IsNullOrEmpty(dr["LinkMan"].ToString()))
                {
                    model.LinkMan = dr["LinkMan"].ToString();
                }
                if (!string.IsNullOrEmpty(dr["LinkPhone"].ToString()))
                {
                    model.LinkPhone = dr["LinkPhone"].ToString();
                }
                if (!string.IsNullOrEmpty(dr["PostAddress"].ToString()))
                {
                    model.PostAddress = dr["PostAddress"].ToString();
                }
                if (!string.IsNullOrEmpty(dr["DealerID"].ToString()))
                {
                    model.DealerID = dr["DealerID"].ToString();
                }
                if (!string.IsNullOrEmpty(dr["DealerName"].ToString()))
                {
                    model.DealerName = dr["DealerName"].ToString();
                }
                if (!string.IsNullOrEmpty(dr["FXID"].ToString()))
                {
                    model.FXID = dr["FXID"].ToString();
                }
                if (!string.IsNullOrEmpty(dr["FXName"].ToString()))
                {
                    model.FXName = dr["FXName"].ToString();
                }
                if (!string.IsNullOrEmpty(dr["ShopOwnerShip"].ToString()))
                {
                    model.ShopOwnerShip = dr["ShopOwnerShip"].ToString();
                }
                if (!string.IsNullOrEmpty(dr["CustomerCard"].ToString()))
                {
                    model.CustomerCard = dr["CustomerCard"].ToString();
                }
                if (!string.IsNullOrEmpty(dr["CreateDate"].ToString()))
                {
                    model.CreateDate = DateTime.Parse(dr["CreateDate"].ToString());
                }
                if (!string.IsNullOrEmpty(dr["SupplierId"].ToString()))
                {
                    model.SupplierId = int.Parse(dr["SupplierId"].ToString());
                }
                if (!string.IsNullOrEmpty(dr["ShopImageId"].ToString()))
                {
                    model.ShopImageId = int.Parse(dr["ShopImageId"].ToString());
                }
                if (!string.IsNullOrEmpty(dr["ShopLevelId"].ToString()))
                {
                    model.ShopLevelId = int.Parse(dr["ShopLevelId"].ToString());
                }
                if (!string.IsNullOrEmpty(dr["BigArea"].ToString()))
                {
                    model.BigArea = dr["BigArea"].ToString();
                }
                if (!string.IsNullOrEmpty(dr["ShopCategory"].ToString()))
                {
                    model.ShopCategory = dr["ShopCategory"].ToString();
                }
                if (!string.IsNullOrEmpty(dr["ShopState"].ToString()))
                {
                    model.ShopState = int.Parse(dr["ShopState"].ToString());
                }
                if (!string.IsNullOrEmpty(dr["ShopType"].ToString()))
                {
                    model.ShopType = int.Parse(dr["ShopType"].ToString());
                }
                if (!string.IsNullOrEmpty(dr["SaleTypeID"].ToString()))
                {
                    model.SaleTypeID = int.Parse(dr["SaleTypeID"].ToString());
                }
                if (!string.IsNullOrEmpty(dr["TCL_ID"].ToString()))
                {
                    model.TCL_ID = int.Parse(dr["TCL_ID"].ToString());
                }
                if (!string.IsNullOrEmpty(dr["ACL_ID"].ToString()))
                {
                    model.ACL_ID = int.Parse(dr["ACL_ID"].ToString());
                }
                if (!string.IsNullOrEmpty(dr["Remark"].ToString()))
                {
                    model.Remark = dr["Remark"].ToString();
                }
                return model;
            }
            else
                return null;
        }

        public List<LN.Model.PromotionShopInfo> GetDataList(string whereStr)
        {
            List<LN.Model.PromotionShopInfo> list = new List<LN.Model.PromotionShopInfo>();
            DataSet ds = GetList(whereStr);
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                LN.Model.PromotionShopInfo model;
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    model = new Model.PromotionShopInfo();
                    model.ID = int.Parse(dr["ID"].ToString());
                    if (!string.IsNullOrWhiteSpace(dr["PosID"].ToString()))
                        model.PosID = dr["PosID"].ToString();

                    
                    model.PosID = dr["PosID"].ToString();
                    model.Shopname = dr["Shopname"].ToString();
                    model.Shopsamplename = dr["Shopsamplename"].ToString();
                    model.ShopAddress = dr["ShopAddress"].ToString();
                    if (!string.IsNullOrWhiteSpace(dr["ProvinceID"].ToString()))
                        model.ProvinceID = int.Parse(dr["ProvinceID"].ToString());
                    if (!string.IsNullOrWhiteSpace(dr["CityID"].ToString()))
                        model.CityID = int.Parse(dr["CityID"].ToString());
                    if (!string.IsNullOrWhiteSpace(dr["TownID"].ToString()))
                        model.TownID = int.Parse(dr["TownID"].ToString());
                    model.LinkMan = dr["LinkMan"].ToString();
                    model.LinkPhone = dr["LinkPhone"].ToString();
                    model.PostAddress = dr["PostAddress"].ToString();
                    model.DealerID = dr["DealerID"].ToString();
                    model.DealerName = dr["DealerName"].ToString();
                    model.FXID = dr["FXID"].ToString();
                    model.FXName = dr["FXName"].ToString();
                    model.BigArea = dr["BigArea"].ToString();
                    if (!string.IsNullOrWhiteSpace(dr["areaid"].ToString()))
                        model.areaid = int.Parse(dr["areaid"].ToString());
                    model.ShopOwnerShip = dr["ShopOwnerShip"].ToString();
                    model.CustomerCard = dr["CustomerCard"].ToString();
                    if (!string.IsNullOrWhiteSpace(dr["ShopImageId"].ToString()))
                        model.ShopImageId = int.Parse(dr["ShopImageId"].ToString());
                    if (!string.IsNullOrWhiteSpace(dr["ShopLevelId"].ToString()))
                        model.ShopLevelId = int.Parse(dr["ShopLevelId"].ToString());
                    if (!string.IsNullOrWhiteSpace(dr["ShopState"].ToString()))
                        model.ShopState = int.Parse(dr["ShopState"].ToString());
                    if (!string.IsNullOrWhiteSpace(dr["ShopType"].ToString()))
                        model.ShopType = int.Parse(dr["ShopType"].ToString());
                    if (!string.IsNullOrWhiteSpace(dr["SaleTypeID"].ToString()))
                        model.SaleTypeID = int.Parse(dr["SaleTypeID"].ToString());
                    if (!string.IsNullOrWhiteSpace(dr["TCL_ID"].ToString()))
                        model.TCL_ID = int.Parse(dr["TCL_ID"].ToString());
                    if (!string.IsNullOrWhiteSpace(dr["ACL_ID"].ToString()))
                        model.ACL_ID = int.Parse(dr["ACL_ID"].ToString());
                     model.ShopCategory = dr["ShopCategory"].ToString();
                     model.Remark = dr["Remark"].ToString();
                     list.Add(model);
                }
            }
            return list;
        }
    }
}
