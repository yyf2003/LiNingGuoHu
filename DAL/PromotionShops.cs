using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using LN.DBUtility;

namespace LN.DAL
{
    public class PromotionShops
    {
        public int Add(LN.Model.PromotionShops model)
        {
            string sql = "insert into PromotionShops(PromotionId,AreaId,ProvinceId,CityId,TownId,ShopId,AddUserId,AddDate,PosID,Shopname,Shopsamplename,ShopAddress,BigArea,LinkMan,LinkPhone,PostAddress,DealerID,DealerName,FXID,FXName,ShopOwnerShip,CustomerCard,ShopImageId,ShopLevelId,ShopType,ShopCategory,SaleTypeID,TCL_ID,ACL_ID,Remark) values(@PromotionId,@AreaId,@ProvinceId,@CityId,@TownId,@ShopId,@AddUserId,@AddDate,@PosID,@Shopname,@Shopsamplename,@ShopAddress,@BigArea,@LinkMan,@LinkPhone,@PostAddress,@DealerID,@DealerName,@FXID,@FXName,@ShopOwnerShip,@CustomerCard,@ShopImageId,@ShopLevelId,@ShopType,@ShopCategory,@SaleTypeID,@TCL_ID,@ACL_ID,@Remark);select @@identity";
            SqlParameter[] paras = new SqlParameter[] { 
               new SqlParameter("@PromotionId",model.PromotionId),
               new SqlParameter("@AreaId",model.AreaId),
               new SqlParameter("@ProvinceId",model.ProvinceId),
               new SqlParameter("@CityId",model.CityId),
               new SqlParameter("@TownId",model.TownId),
               new SqlParameter("@ShopId",model.ShopId),
               new SqlParameter("@AddUserId",model.AddUserId),
               new SqlParameter("@AddDate",model.AddDate),

               new SqlParameter("@PosID",model.PosID),
               new SqlParameter("@Shopname",model.Shopname),
               new SqlParameter("@Shopsamplename",model.Shopsamplename),
               new SqlParameter("@ShopAddress",model.ShopAddress),
               new SqlParameter("@BigArea",model.BigArea),
               new SqlParameter("@LinkMan",model.LinkMan),
               new SqlParameter("@LinkPhone",model.LinkPhone),
               new SqlParameter("@PostAddress",model.PostAddress),
               new SqlParameter("@DealerID",model.DealerID),
               new SqlParameter("@DealerName",model.DealerName),
               new SqlParameter("@FXID",model.FXID),
               new SqlParameter("@FXName",model.FXName),
               new SqlParameter("@ShopOwnerShip",model.ShopOwnerShip),
               new SqlParameter("@CustomerCard",model.CustomerCard),
               new SqlParameter("@ShopImageId",model.ShopImageId),
               new SqlParameter("@ShopLevelId",model.ShopLevelId),
               new SqlParameter("@ShopType",model.ShopType),
               new SqlParameter("@ShopCategory",model.ShopCategory),

               new SqlParameter("@SaleTypeID",model.SaleTypeID),
               new SqlParameter("@TCL_ID",model.TCL_ID),
               new SqlParameter("@ACL_ID",model.ACL_ID),
               new SqlParameter("@Remark",model.Remark)
            };
            object obj = DbHelperSQL.GetSingle(DbHelperSQL.connectionString(), sql, paras);
            return obj != null ? int.Parse(obj.ToString()) : 0;
        }

        public bool DeleteByPromotionId(int pid)
        {
            string sql = "delete from PromotionShops where PromotionId=@PromotionId";
            SqlParameter[] paras = new SqlParameter[] { 
               new SqlParameter("@PromotionId",pid)
            };
            return DbHelperSQL.ExecuteSql(DbHelperSQL.connectionString(), sql, paras) > 0;
        }

        //public DataSet GetList(string where)
        //{
        //    StringBuilder sql = new StringBuilder();
        //    sql.Append("select PromotionShops.*,ShopInfo.ShopID,ShopInfo.PosID,ShopInfo.Shopname,ShopInfo.DealerID,DealerInfo.DealerName,ShopInfo.FXID,DistributorsInfo.FXName,ShopInfo.CustomerCard,AreaData.AreaName,province.CityName ProvinceName,city.CityName,ShopInfo.ShopOwnerShip,ShopInfo.PostAddress,ShopInfo.LinkMan,ShopInfo.LinkPhone  from PromotionShops join ShopInfo on ShopInfo.Id=PromotionShops.ShopId left join DealerInfo on DealerInfo.DealerID=ShopInfo.DealerID left join DistributorsInfo on DistributorsInfo.FXID=ShopInfo.FXID left join AreaData on AreaData.AreaID=ShopInfo.areaid left join CityData province on province.CItyID=ShopInfo.ProvinceID left join CityData city on city.CItyID=ShopInfo.CityID ");
        //    if (!string.IsNullOrEmpty(where))
        //    {
        //        sql.Append(" where " + where);
        //    }
        //    return DbHelperSQL.Query(DbHelperSQL.connectionString(), sql.ToString());

        //}

        public DataSet GetList(string where)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append("select PromotionShops.*,DealerInfo.DealerName,DistributorsInfo.FXName,AreaData.AreaName,province.CityName ProvinceName,city.CityName  from PromotionShops left join DealerInfo on DealerInfo.DealerID=PromotionShops.DealerID left join DistributorsInfo on DistributorsInfo.FXID=PromotionShops.FXID left join AreaData on AreaData.AreaID=PromotionShops.areaid left join CityData province on province.CItyID=PromotionShops.ProvinceID left join CityData city on city.CItyID=PromotionShops.CityID ");
            if (!string.IsNullOrEmpty(where))
            {
                sql.Append(" where " + where);
            }
            return DbHelperSQL.Query(DbHelperSQL.connectionString(), sql.ToString());

        }

        public DataSet GetJoinList_old(string where)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append(@"select PromotionShopInfo.ID
                          ,PromotionShopInfo.PosID
                          ,PromotionShopInfo.Shopname
                          ,PromotionShopInfo.ShopAddress
                          ,DepartMentInfo.department AreaName
                          ,PromotionShopInfo.ProvinceID
                          ,ProvinceData.ProvinceName
                          ,CityData.CityName
                          ,PromotionShopInfo.DealerID
                          ,PromotionShopInfo.DealerName 
                          ,PromotionShopInfo.FXID
                          ,PromotionShopInfo.FXName
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
                          ,SupplierInfo.ShortName SupplierName
                          ,PromotionShopInfo.BigArea
                          ,PromotionShopInfo.ShopCategory
                          from PromotionShops
                          join PromotionShopInfo on PromotionShopInfo.ID =PromotionShops.ShopId
                          left join ProvinceData on ProvinceData.ProvinceID=PromotionShopInfo.ProvinceID
                          left join CityData on CityData.CItyID=PromotionShopInfo.CityID 
                          left join PromotionShopImage on PromotionShopImage.Id=PromotionShopInfo.ShopImageId
                          left join PromotionShopLevel on PromotionShopLevel.Id=PromotionShopInfo.ShopLevelId
                          left join ShopStateInfo on ShopStateInfo.ID=PromotionShopInfo.ShopState
                          left join ShopType on ShopType.ID = PromotionShopInfo.ShopType
                          left join SaleTypeInfo on SaleTypeInfo.SaleTypeID=PromotionShopInfo.SaleTypeID
                          left join TownCityLevel on TownCityLevel.TCL_Id = PromotionShopInfo.TCL_ID
                          left join AreaCityLevel on AreaCityLevel.ACL_Id = PromotionShopInfo.ACL_ID
                          left join DepartMentInfo on DepartMentInfo.ID = PromotionShopInfo.areaid 
                          left join (select max(SupplierArea.SupplierID) SupplierID,DepartmentId,ProvinceId from SupplierArea join SupplierInfo on SupplierInfo.SupplierID=SupplierArea.SupplierId where SupplierInfo.SupplierState=1 and SupplierInfo.IsPromotion=1  group by DepartmentId,ProvinceId) as SupplierArea
                          on ((SupplierArea.ProvinceId>0 and (SupplierArea.ProvinceId=PromotionShopInfo.ProvinceID and SupplierArea.DepartmentId=PromotionShopInfo.areaid)) or (SupplierArea.ProvinceId=0 and SupplierArea.DepartmentId=PromotionShopInfo.areaid))
                          left join SupplierInfo on SupplierInfo.SupplierID=SupplierArea.SupplierID
                         ");
            if (!string.IsNullOrWhiteSpace(where))
            {
                sql.Append(" where " + where);
            }
            sql.Append(" order by PromotionShopInfo.LinkPhone desc,PromotionShopInfo.LinkMan desc");
            return DbHelperSQL.Query(DbHelperSQL.connectionString(), sql.ToString());
        }

        public DataSet GetJoinList(string where)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append(@"select PromotionShops.ShopId
                          ,PromotionShops.PosID
                          ,PromotionShops.Shopname
                          ,PromotionShops.ShopAddress
                          ,DepartMentInfo.department AreaName
                          ,PromotionShops.ProvinceID
                          ,ProvinceData.ProvinceName
                          ,CityData.CityName
                          ,PromotionShops.DealerID
                          ,PromotionShops.DealerName 
                          ,PromotionShops.FXID
                          ,PromotionShops.FXName
                          ,PromotionShops.LinkMan
                          ,PromotionShops.LinkPhone
                          ,PromotionShops.ShopOwnerShip
                          ,PromotionShops.CustomerCard
                          ,PromotionShops.PostAddress
                          ,PromotionShopImage.ImageName
                          ,PromotionShopLevel.ShortName ShopLevelName
                          ,ShopStateInfo.ShopState
                          ,ShopType.ShopTypename
                          ,SaleTypeInfo.SaleType
                          ,TownCityLevel.TCL_Name
                          ,AreaCityLevel.ACL_Name
                          ,SupplierInfo.ShortName SupplierName
                          ,PromotionShops.BigArea
                          ,PromotionShops.ShopCategory
                          ,PromotionShops.Remark
                          from PromotionShops
                          
                          left join ProvinceData on ProvinceData.ProvinceID=PromotionShops.ProvinceID
                          left join CityData on CityData.CItyID=PromotionShops.CityID 
                          left join PromotionShopImage on PromotionShopImage.Id=PromotionShops.ShopImageId
                          left join PromotionShopLevel on PromotionShopLevel.Id=PromotionShops.ShopLevelId
                          left join ShopStateInfo on ShopStateInfo.ID=PromotionShops.ShopState
                          left join ShopType on ShopType.ID = PromotionShops.ShopType
                          left join SaleTypeInfo on SaleTypeInfo.SaleTypeID=PromotionShops.SaleTypeID
                          left join TownCityLevel on TownCityLevel.TCL_Id = PromotionShops.TCL_ID
                          left join AreaCityLevel on AreaCityLevel.ACL_Id = PromotionShops.ACL_ID
                          left join DepartMentInfo on DepartMentInfo.ID = PromotionShops.areaid 
                          left join (select max(SupplierArea.SupplierID) SupplierID,DepartmentId,ProvinceId from SupplierArea join SupplierInfo on SupplierInfo.SupplierID=SupplierArea.SupplierId where SupplierInfo.SupplierState=1 and SupplierInfo.IsPromotion=1  group by DepartmentId,ProvinceId) as SupplierArea
                          on ((SupplierArea.ProvinceId>0 and (SupplierArea.ProvinceId=PromotionShops.ProvinceID and SupplierArea.DepartmentId=PromotionShops.areaid)) or (SupplierArea.ProvinceId=0 and SupplierArea.DepartmentId=PromotionShops.areaid))
                          left join SupplierInfo on SupplierInfo.SupplierID=SupplierArea.SupplierID
                         ");
            if (!string.IsNullOrWhiteSpace(where))
            {
                sql.Append(" where " + where);
            }
            sql.Append(" order by PromotionShops.LinkPhone desc,PromotionShops.LinkMan desc");
            return DbHelperSQL.Query(DbHelperSQL.connectionString(), sql.ToString());
        }


        public int GetPageCount(string where)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append("select count(1) from PromotionShops join ShopInfo on ShopInfo.Id=PromotionShops.ShopId where 1=1 "+where);
            object obj= DbHelperSQL.GetSingle(DbHelperSQL.connectionString(), sql.ToString());
            return obj != null ? int.Parse(obj.ToString()) : 0;

        }

        public DataSet GetPageList(string where, int currPage, int pageSize)
        {
            string sql = "select * from (select row_number() over(order by PromotionShops.ShopId) row,PromotionShops.*,ShopInfo.PosID,ShopInfo.Shopname from PromotionShops join ShopInfo on ShopInfo.Id=PromotionShops.ShopId where 1=1 " + where + ") as temp where row between ((@currPage-1)*@pageSize+1) and (@currPage*@pageSize)";
            SqlParameter[] paraList = new SqlParameter[] { 
               new SqlParameter("@currPage",currPage),
               new SqlParameter("@pageSize",pageSize)
            };
            return DbHelperSQL.Query(DbHelperSQL.connectionString(), sql, paraList);
        }

        public IList<LN.Model.PromotionShops> GetDataList(string where)
        {
            StringBuilder sql = new StringBuilder();
            IList<LN.Model.PromotionShops> list = new List<LN.Model.PromotionShops>();
            LN.Model.PromotionShops model;
            sql.Append("select * from PromotionShops");
            if (!string.IsNullOrEmpty(where))
            {
                sql.Append(" where " + where);
            }
            SqlDataReader reader = DbHelperSQL.ExecuteReader(DbHelperSQL.connectionString(), sql.ToString());
            while (reader.Read())
            {
                model = new Model.PromotionShops();
                if(!string.IsNullOrEmpty(reader["AddDate"].ToString()))
                {
                    model.AddDate = DateTime.Parse(reader["AddDate"].ToString());
                }
                if (!string.IsNullOrEmpty(reader["AddUserId"].ToString()))
                {
                    model.AddUserId = int.Parse(reader["AddUserId"].ToString());
                }
                if (!string.IsNullOrEmpty(reader["AreaId"].ToString()))
                {
                    model.AreaId = int.Parse(reader["AreaId"].ToString());
                }
                if (!string.IsNullOrEmpty(reader["CityId"].ToString()))
                {
                    model.CityId = int.Parse(reader["CityId"].ToString());
                }
                if (!string.IsNullOrEmpty(reader["Id"].ToString()))
                {
                    model.Id = int.Parse(reader["Id"].ToString());
                }
                if (!string.IsNullOrEmpty(reader["PromotionId"].ToString()))
                {
                    model.PromotionId = int.Parse(reader["PromotionId"].ToString());
                }
                if (!string.IsNullOrEmpty(reader["ProvinceId"].ToString()))
                {
                    model.ProvinceId = int.Parse(reader["ProvinceId"].ToString());
                }
                if (!string.IsNullOrEmpty(reader["ReceiveOrderDate"].ToString()))
                {
                    model.ReceiveOrderDate = DateTime.Parse(reader["ReceiveOrderDate"].ToString());
                }
                if (!string.IsNullOrEmpty(reader["ReceiveOrderUserId"].ToString()))
                {
                    model.ReceiveOrderUserId = int.Parse(reader["ReceiveOrderUserId"].ToString());
                }
                if (!string.IsNullOrEmpty(reader["SentOrderDate"].ToString()))
                {
                    model.SentOrderDate = DateTime.Parse(reader["SentOrderDate"].ToString());
                }
                if (!string.IsNullOrEmpty(reader["SentOrderUserId"].ToString()))
                {
                    model.SentOrderUserId = int.Parse(reader["SentOrderUserId"].ToString());
                }
                if (!string.IsNullOrEmpty(reader["ShopId"].ToString()))
                {
                    model.ShopId = int.Parse(reader["ShopId"].ToString());
                }
                if (!string.IsNullOrEmpty(reader["TownId"].ToString()))
                {
                    model.TownId = int.Parse(reader["TownId"].ToString());
                }
                if (!string.IsNullOrEmpty(reader["SentRemark"].ToString()))
                {
                    model.SentRemark = reader["SentRemark"].ToString();
                }
                if (!string.IsNullOrEmpty(reader["ReceiveRemark"].ToString()))
                {
                    model.ReceiveRemark = reader["ReceiveRemark"].ToString();
                }



                if (!string.IsNullOrEmpty(reader["PosID"].ToString()))
                {
                    model.PosID = reader["PosID"].ToString();
                }
                if (!string.IsNullOrEmpty(reader["Shopname"].ToString()))
                {
                    model.Shopname = reader["Shopname"].ToString();
                }
                if (!string.IsNullOrEmpty(reader["Shopsamplename"].ToString()))
                {
                    model.Shopsamplename = reader["Shopsamplename"].ToString();
                }
                if (!string.IsNullOrEmpty(reader["ShopAddress"].ToString()))
                {
                    model.ShopAddress = reader["ShopAddress"].ToString();
                }
                if (!string.IsNullOrEmpty(reader["BigArea"].ToString()))
                {
                    model.BigArea = reader["BigArea"].ToString();
                }
                if (!string.IsNullOrEmpty(reader["LinkMan"].ToString()))
                {
                    model.LinkMan = reader["LinkMan"].ToString();
                }
                if (!string.IsNullOrEmpty(reader["LinkPhone"].ToString()))
                {
                    model.LinkPhone = reader["LinkPhone"].ToString();
                }
                if (!string.IsNullOrEmpty(reader["PostAddress"].ToString()))
                {
                    model.PostAddress = reader["PostAddress"].ToString();
                }
                if (!string.IsNullOrEmpty(reader["DealerID"].ToString()))
                {
                    model.DealerID = reader["DealerID"].ToString();
                }
                if (!string.IsNullOrEmpty(reader["DealerName"].ToString()))
                {
                    model.DealerName = reader["DealerName"].ToString();
                }
                if (!string.IsNullOrEmpty(reader["FXID"].ToString()))
                {
                    model.FXID = reader["FXID"].ToString();
                }
                if (!string.IsNullOrEmpty(reader["FXName"].ToString()))
                {
                    model.FXName = reader["FXName"].ToString();
                }
                if (!string.IsNullOrEmpty(reader["ShopOwnerShip"].ToString()))
                {
                    model.ShopOwnerShip = reader["ShopOwnerShip"].ToString();
                }
                if (!string.IsNullOrEmpty(reader["CustomerCard"].ToString()))
                {
                    model.CustomerCard = reader["CustomerCard"].ToString();
                }
                if (!string.IsNullOrEmpty(reader["ShopImageId"].ToString()))
                {
                    model.ShopImageId = int.Parse(reader["ShopImageId"].ToString());
                }
                if (!string.IsNullOrEmpty(reader["ShopLevelId"].ToString()))
                {
                    model.ShopLevelId = int.Parse(reader["ShopLevelId"].ToString());
                }
                if (!string.IsNullOrEmpty(reader["ShopType"].ToString()))
                {
                    model.ShopType = int.Parse(reader["ShopType"].ToString());
                }
                if (!string.IsNullOrEmpty(reader["ShopCategory"].ToString()))
                {
                    model.ShopCategory = reader["ShopCategory"].ToString();
                }

                if (!string.IsNullOrEmpty(reader["SaleTypeID"].ToString()))
                {
                    model.SaleTypeID = int.Parse(reader["SaleTypeID"].ToString());
                }
                if (!string.IsNullOrEmpty(reader["TCL_ID"].ToString()))
                {
                    model.TCL_ID = int.Parse(reader["TCL_ID"].ToString());
                }
                if (!string.IsNullOrEmpty(reader["ACL_ID"].ToString()))
                {
                    model.ACL_ID = int.Parse(reader["ACL_ID"].ToString());
                }
                list.Add(model);
            }
            return list;
        }

        public bool Update(LN.Model.PromotionShops model)
        {
            StringBuilder sql = new StringBuilder();
            List<SqlParameter> paraList = new List<SqlParameter>();
            sql.Append("update PromotionShops set ");
            if (model != null)
            {
                if (model.ReceiveOrderDate != null)
                {
                    sql.Append(" ReceiveOrderDate=@ReceiveOrderDate,");
                    paraList.Add(new SqlParameter("@ReceiveOrderDate",model.ReceiveOrderDate));
                }
                if (model.ReceiveOrderUserId != null)
                {
                    sql.Append(" ReceiveOrderUserId=@ReceiveOrderUserId,");
                    paraList.Add(new SqlParameter("@ReceiveOrderUserId", model.ReceiveOrderUserId));
                }
                if (model.SentOrderDate != null)
                {
                    sql.Append(" SentOrderDate=@SentOrderDate,");
                    paraList.Add(new SqlParameter("@SentOrderDate", model.SentOrderDate));
                }
                if (model.SentOrderUserId != null)
                {
                    sql.Append(" SentOrderUserId=@SentOrderUserId,");
                    paraList.Add(new SqlParameter("@SentOrderUserId", model.SentOrderUserId));
                }
                if (model.SentRemark != null)
                {
                    sql.Append(" SentRemark=@SentRemark,");
                    paraList.Add(new SqlParameter("@SentRemark", model.SentRemark));
                }
                if (model.ReceiveRemark != null)
                {
                    sql.Append(" ReceiveRemark=@ReceiveRemark,");
                    paraList.Add(new SqlParameter("@ReceiveRemark", model.ReceiveRemark));
                }



                if (model.AreaId != null)
                {
                    sql.Append(" AreaId=@AreaId,");
                    paraList.Add(new SqlParameter("@AreaId", model.AreaId));
                }
                if (model.ProvinceId != null)
                {
                    sql.Append(" ProvinceId=@ProvinceId,");
                    paraList.Add(new SqlParameter("@ProvinceId", model.ProvinceId));
                }
                if (model.CityId != null)
                {
                    sql.Append(" CityId=@CityId,");
                    paraList.Add(new SqlParameter("@CityId", model.CityId));
                }
                if (model.CustomerCard != null)
                {
                    sql.Append(" CustomerCard=@CustomerCard,");
                    paraList.Add(new SqlParameter("@CustomerCard", model.CustomerCard));
                }
                if (model.DealerName != null)
                {
                    sql.Append(" DealerName=@DealerName,");
                    paraList.Add(new SqlParameter("@DealerName", model.DealerName));
                }
                if (model.ShopLevelId != null)
                {
                    sql.Append(" ShopLevelId=@ShopLevelId,");
                    paraList.Add(new SqlParameter("@ShopLevelId", model.ShopLevelId));
                }
                if (model.ShopImageId != null)
                {
                    sql.Append(" ShopImageId=@ShopImageId,");
                    paraList.Add(new SqlParameter("@ShopImageId", model.ShopImageId));
                }
                if (model.Shopname != null)
                {
                    sql.Append(" Shopname=@Shopname,");
                    paraList.Add(new SqlParameter("@Shopname", model.Shopname));
                }
                if (model.ShopOwnerShip != null)
                {
                    sql.Append(" ShopOwnerShip=@ShopOwnerShip,");
                    paraList.Add(new SqlParameter("@ShopOwnerShip", model.ShopOwnerShip));
                }
                if (model.Shopsamplename != null)
                {
                    sql.Append(" Shopsamplename=@Shopsamplename,");
                    paraList.Add(new SqlParameter("@Shopsamplename", model.Shopsamplename));
                }
                if (model.PostAddress != null)
                {
                    sql.Append(" PostAddress=@PostAddress,");
                    paraList.Add(new SqlParameter("@PostAddress", model.PostAddress));
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
                

                if (sql.Length > 0)
                {
                    string sql1 = sql.ToString().TrimEnd(',');
                    if (model.PromotionId != null && model.ShopId!=null)
                    {
                        sql1 += " where PromotionId=@PromotionId and ShopId=@ShopId ";
                        paraList.Add(new SqlParameter("@PromotionId", model.PromotionId));
                        paraList.Add(new SqlParameter("@ShopId", model.ShopId));
                        return DbHelperSQL.ExecuteSql(DbHelperSQL.connectionString(), sql1, paraList.ToArray()) > 0;
                    }
                    else
                        return false;
                }
                else
                    return false;
            }
            else
                return false;
        }

        public LN.Model.PromotionShops GetModel(int id)
        {
            string sql = "select * from PromotionShops where Id=@Id";
            SqlParameter[] paras = new SqlParameter[] { 
               new SqlParameter("@Id",id)
            };
            SqlDataReader reader = DbHelperSQL.ExecuteReader(DbHelperSQL.connectionString(), sql, paras);
            LN.Model.PromotionShops model=null;
            if (reader.Read())
            {
                model = new Model.PromotionShops();
                if (!string.IsNullOrEmpty(reader["Id"].ToString()))
                {
                    model.Id = int.Parse(reader["Id"].ToString());

                }
                if (!string.IsNullOrEmpty(reader["PromotionId"].ToString()))
                {
                    model.PromotionId = int.Parse(reader["PromotionId"].ToString());

                }
                if (!string.IsNullOrEmpty(reader["AreaId"].ToString()))
                {
                    model.AreaId = int.Parse(reader["AreaId"].ToString());

                }
                if (!string.IsNullOrEmpty(reader["ProvinceId"].ToString()))
                {
                    model.ProvinceId = int.Parse(reader["ProvinceId"].ToString());

                }
                if (!string.IsNullOrEmpty(reader["CityId"].ToString()))
                {
                    model.CityId = int.Parse(reader["CityId"].ToString());

                }
                if (!string.IsNullOrEmpty(reader["TownId"].ToString()))
                {
                    model.TownId = int.Parse(reader["TownId"].ToString());

                }
                if (!string.IsNullOrEmpty(reader["ShopId"].ToString()))
                {
                    model.ShopId = int.Parse(reader["ShopId"].ToString());

                }
                if (!string.IsNullOrEmpty(reader["AddUserId"].ToString()))
                {
                    model.AddUserId = int.Parse(reader["AddUserId"].ToString());

                }
                if (!string.IsNullOrEmpty(reader["AddDate"].ToString()))
                {
                    model.AddDate = DateTime.Parse(reader["AddDate"].ToString());

                }
                if (!string.IsNullOrEmpty(reader["SentOrderDate"].ToString()))
                {
                    model.SentOrderDate = DateTime.Parse(reader["SentOrderDate"].ToString());

                }
                if (!string.IsNullOrEmpty(reader["SentOrderUserId"].ToString()))
                {
                    model.SentOrderUserId = int.Parse(reader["SentOrderUserId"].ToString());

                }

                if (!string.IsNullOrEmpty(reader["SentRemark"].ToString()))
                {
                    model.SentRemark = reader["SentRemark"].ToString();

                }
                if (!string.IsNullOrEmpty(reader["ReceiveOrderUserId"].ToString()))
                {
                    model.ReceiveOrderUserId = int.Parse(reader["ReceiveOrderUserId"].ToString());

                }
                if (!string.IsNullOrEmpty(reader["ReceiveOrderDate"].ToString()))
                {
                    model.ReceiveOrderDate = DateTime.Parse(reader["ReceiveOrderDate"].ToString());

                }
                if (!string.IsNullOrEmpty(reader["ReceiveRemark"].ToString()))
                {
                    model.ReceiveRemark = reader["ReceiveRemark"].ToString();
                }


                if (!string.IsNullOrEmpty(reader["PosID"].ToString()))
                {
                    model.PosID = reader["PosID"].ToString();
                }
                if (!string.IsNullOrEmpty(reader["Shopname"].ToString()))
                {
                    model.Shopname = reader["Shopname"].ToString();
                }
                if (!string.IsNullOrEmpty(reader["Shopsamplename"].ToString()))
                {
                    model.Shopsamplename = reader["Shopsamplename"].ToString();
                }
                if (!string.IsNullOrEmpty(reader["ShopAddress"].ToString()))
                {
                    model.ShopAddress = reader["ShopAddress"].ToString();
                }
                if (!string.IsNullOrEmpty(reader["BigArea"].ToString()))
                {
                    model.BigArea = reader["BigArea"].ToString();
                }
                if (!string.IsNullOrEmpty(reader["LinkMan"].ToString()))
                {
                    model.LinkMan = reader["LinkMan"].ToString();
                }
                if (!string.IsNullOrEmpty(reader["LinkPhone"].ToString()))
                {
                    model.LinkPhone = reader["LinkPhone"].ToString();
                }
                if (!string.IsNullOrEmpty(reader["PostAddress"].ToString()))
                {
                    model.PostAddress = reader["PostAddress"].ToString();
                }
                if (!string.IsNullOrEmpty(reader["DealerID"].ToString()))
                {
                    model.DealerID = reader["DealerID"].ToString();
                }
                if (!string.IsNullOrEmpty(reader["DealerName"].ToString()))
                {
                    model.DealerName = reader["DealerName"].ToString();
                }
                if (!string.IsNullOrEmpty(reader["FXID"].ToString()))
                {
                    model.FXID = reader["FXID"].ToString();
                }
                if (!string.IsNullOrEmpty(reader["FXName"].ToString()))
                {
                    model.FXName = reader["FXName"].ToString();
                }
                if (!string.IsNullOrEmpty(reader["ShopOwnerShip"].ToString()))
                {
                    model.ShopOwnerShip = reader["ShopOwnerShip"].ToString();
                }
                if (!string.IsNullOrEmpty(reader["CustomerCard"].ToString()))
                {
                    model.CustomerCard = reader["CustomerCard"].ToString();
                }
                if (!string.IsNullOrEmpty(reader["ShopImageId"].ToString()))
                {
                    model.ShopImageId = int.Parse(reader["ShopImageId"].ToString());
                }
                if (!string.IsNullOrEmpty(reader["ShopLevelId"].ToString()))
                {
                    model.ShopLevelId = int.Parse(reader["ShopLevelId"].ToString());
                }
                if (!string.IsNullOrEmpty(reader["ShopType"].ToString()))
                {
                    model.ShopType = int.Parse(reader["ShopType"].ToString());
                }
                if (!string.IsNullOrEmpty(reader["ShopCategory"].ToString()))
                {
                    model.ShopCategory = reader["ShopCategory"].ToString();
                }

                if (!string.IsNullOrEmpty(reader["SaleTypeID"].ToString()))
                {
                    model.SaleTypeID = int.Parse(reader["SaleTypeID"].ToString());
                }
                if (!string.IsNullOrEmpty(reader["TCL_ID"].ToString()))
                {
                    model.TCL_ID = int.Parse(reader["TCL_ID"].ToString());
                }
                if (!string.IsNullOrEmpty(reader["ACL_ID"].ToString()))
                {
                    model.ACL_ID = int.Parse(reader["ACL_ID"].ToString());
                }
            }
            return model;
        }
    }
}
