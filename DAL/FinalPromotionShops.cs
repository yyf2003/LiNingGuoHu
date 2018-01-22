using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using LN.DBUtility;
using System.Data;

namespace LN.DAL
{
    public class FinalPromotionShops
    {
        public int Add(LN.Model.FinalPromotionShops model)
        {
            string sql = "insert into FinalPromotionShops(PromotionId,StoryBagApplyId,AreaId,ShopId,Remark,BigArea,PosID,Shopname,Shopsamplename,ShopAddress,LinkMan,LinkPhone,PostAddress,DealerID,DealerName,FXID,FXName,ShopOwnerShip,CustomerCard,ShopImageId,ShopLevelId,ShopType,ShopCategory,SaleTypeID,TCL_ID,ACL_ID) values(@PromotionId,@StoryBagApplyId,@AreaId,@ShopId,@Remark,@BigArea,@PosID,@Shopname,@Shopsamplename,@ShopAddress,@LinkMan,@LinkPhone,@PostAddress,@DealerID,@DealerName,@FXID,@FXName,@ShopOwnerShip,@CustomerCard,@ShopImageId,@ShopLevelId,@ShopType,@ShopCategory,@SaleTypeID,@TCL_ID,@ACL_ID); select @@identity";
            SqlParameter[] parameters = new SqlParameter[] { 
              new SqlParameter("@PromotionId",model.PromotionId),
              new SqlParameter("@StoryBagApplyId",model.StoryBagApplyId),
              new SqlParameter("@AreaId",model.AreaId),
              new SqlParameter("@ShopId",model.ShopId),
              new SqlParameter("@Remark",model.Remark),
              new SqlParameter("@BigArea",model.BigArea),

              new SqlParameter("@PosID",model.PosID),
               new SqlParameter("@Shopname",model.Shopname),
               new SqlParameter("@Shopsamplename",model.Shopsamplename),
               new SqlParameter("@ShopAddress",model.ShopAddress),
               
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
               new SqlParameter("@ACL_ID",model.ACL_ID)
            };
            object obj = DbHelperSQL.GetSingle(DbHelperSQL.connectionString(), sql, parameters);
            if (obj == null)
            {
                return 1;
            }
            else
            {
                return Convert.ToInt32(obj);
            }
        }

        public DataSet GetList(string where)
        {
             StringBuilder sql=new StringBuilder();
             sql.Append("select Id,PromotionId,StoryBagApplyId,AreaId,ShopId,Remark,BigArea from FinalPromotionShops");
            if (!string.IsNullOrWhiteSpace(where))
            {
                sql.Append(" where " + where);
            }
            return DbHelperSQL.Query(DbHelperSQL.connectionString(), sql.ToString());
        }

//        public DataSet GetJoinShopList(string where)
//        {
//            StringBuilder sql = new StringBuilder();
//            sql.Append(@"select FinalPromotionShops.Id,FinalPromotionShops.PromotionId,FinalPromotionShops.StoryBagApplyId
//                         ,FinalPromotionShops.ShopId,FinalPromotionShops.Remark,PromotionShopInfo.PosID,PromotionShopInfo.Shopname
//                         ,PromotionShopInfo.ShopLevelId
//                         from FinalPromotionShops
//                         join PromotionShopInfo on PromotionShopInfo.ID = FinalPromotionShops.ShopId 
//                         where (FinalPromotionShops.IsDelete is null or FinalPromotionShops.IsDelete=0)  
//                      ");
//            if (!string.IsNullOrWhiteSpace(where))
//            {
//                sql.Append(" and  " + where);
//            }
//            return DbHelperSQL.Query(DbHelperSQL.connectionString(), sql.ToString());
//        }

        public DataSet GetJoinShopList(string where)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append(@"select FinalPromotionShops.Id,FinalPromotionShops.PromotionId,FinalPromotionShops.StoryBagApplyId
                         ,FinalPromotionShops.ShopId,FinalPromotionShops.Remark,PromotionShops.PosID,PromotionShops.Shopname
                         ,PromotionShops.ShopLevelId
                         from FinalPromotionShops
                         join PromotionShops on PromotionShops.ShopId = FinalPromotionShops.ShopId 
                         where (FinalPromotionShops.IsDelete is null or FinalPromotionShops.IsDelete=0)  
                      ");
            if (!string.IsNullOrWhiteSpace(where))
            {
                sql.Append(" and  " + where);
            }
            return DbHelperSQL.Query(DbHelperSQL.connectionString(), sql.ToString());
        }

        public bool DeleteByPromotionId(int promotionId)
        {
            string sql = "update FinalPromotionShops set IsDelete=1 where PromotionId=" + promotionId;
            return DbHelperSQL.ExecuteSql(DbHelperSQL.connectionString(), sql)>=0;
        }

        public void Delete(string where)
        {
            string sql = "delete from FinalPromotionShops where " + where;
            DbHelperSQL.ExecuteSql(DbHelperSQL.connectionString(), sql);
        }

        public bool DeleteByStoryBagApplyId(int promotionId,int storyBagApplyId,string bigArea)
        {
            //string sql = "delete from FinalPromotionShops where StoryBagApplyId=" + storyBagApplyId;
            string sql = "update FinalPromotionShops set IsDelete=1 where PromotionId=" + promotionId + " and StoryBagApplyId=" + storyBagApplyId + " and BigArea='" + bigArea+"'";
            return DbHelperSQL.ExecuteSql(DbHelperSQL.connectionString(), sql) >= 0;

        }

        public bool DeleteByStoryBagApplyIds(int promotionId, string storyBagApplyIds, string bigArea)
        {
            if (string.IsNullOrWhiteSpace(storyBagApplyIds))
                storyBagApplyIds = "0";
            string sql = "update FinalPromotionShops set IsDelete=1 where PromotionId=" + promotionId + " and StoryBagApplyId in(" + storyBagApplyIds + ") and BigArea='" + bigArea + "'";
            return DbHelperSQL.ExecuteSql(DbHelperSQL.connectionString(), sql) >= 0;

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
                          ,FinalPromotionShops.Remark
                          ,PromotionShops.BigArea
                          ,PromotionShops.ShopCategory
                          
                          from FinalPromotionShops
                          join PromotionShops on PromotionShops.ShopId =FinalPromotionShops.ShopId
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



                          where (FinalPromotionShops.IsDelete is null or FinalPromotionShops.IsDelete=0) 
                         ");
            if (!string.IsNullOrWhiteSpace(where))
            {
                sql.Append(" and " + where);
            }
            sql.Append(" order by PromotionShops.LinkPhone desc,PromotionShops.LinkMan desc");
            return DbHelperSQL.Query(DbHelperSQL.connectionString(), sql.ToString());
        }

        public void Update(LN.Model.FinalPromotionShops model)
        {
            StringBuilder sql = new System.Text.StringBuilder();
            sql.Append("update FinalPromotionShops set ");
            List<SqlParameter> paraList = new List<SqlParameter>();
            if (model != null)
            {
                if (model.PromotionId != null)
                {
                    sql.Append(" PromotionId=@PromotionId,");
                    paraList.Add(new SqlParameter("@PromotionId", model.PromotionId));
                }
                if (model.StoryBagApplyId != null)
                {
                    sql.Append(" StoryBagApplyId=@StoryBagApplyId,");
                    paraList.Add(new SqlParameter("@StoryBagApplyId", model.StoryBagApplyId));
                }
                if (model.AreaId != null)
                {
                    sql.Append(" AreaId=@AreaId,");
                    paraList.Add(new SqlParameter("@AreaId", model.AreaId));
                }
                if (model.ShopId != null)
                {
                    sql.Append(" ShopId=@ShopId,");
                    paraList.Add(new SqlParameter("@ShopId", model.ShopId));
                }
                if (model.IsDelete != null)
                {
                    sql.Append(" IsDelete=@IsDelete,");
                    paraList.Add(new SqlParameter("@IsDelete", model.IsDelete));
                }
                if (model.Remark != null)
                {
                    sql.Append(" Remark=@Remark,");
                    paraList.Add(new SqlParameter("@Remark", model.Remark));
                }
                string sql1 = sql.ToString().Substring(0, sql.Length - 1);
                if (model.Id>0)
                {
                    sql1 += " where Id=@Id ";
                    paraList.Add(new SqlParameter("@Id", model.Id));
                    DbHelperSQL.ExecuteSql(DbHelperSQL.connectionString(), sql1, paraList.ToArray());
                }
                
            }
            
        }

        public void DeleteAll()
        {
            StringBuilder sql = new System.Text.StringBuilder();
            sql.Append("update FinalPromotionShops set IsDelete=1");
            DbHelperSQL.ExecuteSql(DbHelperSQL.connectionString(), sql.ToString());
        }

        public List<LN.Model.PromotionShopInfo> GetShopList(string where)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append(@"select PromotionShopInfo.* 
                         from FinalPromotionShops
                         join PromotionShopInfo on PromotionShopInfo.ID =FinalPromotionShops.ShopId
                         where (FinalPromotionShops.IsDelete is null or FinalPromotionShops.IsDelete=0) 
                      ");
            if (!string.IsNullOrWhiteSpace(where))
            {
                sql.Append(" and  " + where);
            }
            DataSet ds= DbHelperSQL.Query(DbHelperSQL.connectionString(), sql.ToString());
            List<LN.Model.PromotionShopInfo> list = new List<Model.PromotionShopInfo>();
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                LN.Model.PromotionShopInfo model;
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    model = new Model.PromotionShopInfo();
                    
                    if (!string.IsNullOrWhiteSpace(dr["ID"].ToString()))
                    {
                        model.ID = int.Parse(dr["ID"].ToString());
                    }
                    if (!string.IsNullOrWhiteSpace(dr["ShopLevelId"].ToString()))
                    {
                        model.ShopLevelId = int.Parse(dr["ShopLevelId"].ToString());
                    }
                    list.Add(model);
                }
            }
            return list;
        }
        
    }
}
