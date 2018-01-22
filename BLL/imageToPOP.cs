using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using LN.Model;
namespace LN.BLL
{
	/// <summary>
	/// 业务逻辑类imageToPOP 的摘要说明。
	/// </summary>
    public class imageToPOP
    {
        private readonly LN.DAL.imageToPOP dal = new LN.DAL.imageToPOP();
        public imageToPOP()
        { }
        #region  成员方法
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int ID)
        {
            return dal.Exists(ID);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(LN.Model.imageToPOP model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新图片地址 add by mhj 2012.2.5
        /// </summary>
        /// <param name="model"></param>
        /// <param name="type">0为更新前图片，1更新后图片</param>
        /// <returns></returns>
        public int UpdateImage(LN.Model.imageToPOP model, int type)
        {
            return dal.UpdateImage(model, type);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public void Update(LN.Model.imageToPOP model)
        {
            dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void Delete(int ID)
        {

            dal.Delete(ID);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void Delete(string str)
        {

            dal.Delete(str);
        }
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public LN.Model.imageToPOP GetModel(int ID)
        {

            return dal.GetModel(ID);
        }



        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            return dal.GetList(strWhere);
        }

        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            return dal.GetList(Top, strWhere, filedOrder);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<LN.Model.imageToPOP> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<LN.Model.imageToPOP> DataTableToList(DataTable dt)
        {
            List<LN.Model.imageToPOP> modelList = new List<LN.Model.imageToPOP>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                LN.Model.imageToPOP model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new LN.Model.imageToPOP();
                    if (dt.Rows[n]["ID"].ToString() != "")
                    {
                        model.ID = int.Parse(dt.Rows[n]["ID"].ToString());
                    }
                    model.POPID = dt.Rows[n]["POPID"].ToString();
                    if (dt.Rows[n]["POPinfoID"].ToString() != "")
                    {
                        model.POPinfoID = int.Parse(dt.Rows[n]["POPinfoID"].ToString());
                    }
                    if (dt.Rows[n]["imageID"].ToString() != "")
                    {
                        model.imageID = int.Parse(dt.Rows[n]["imageID"].ToString());
                    }
                    if (dt.Rows[n]["prolineID"].ToString() != "")
                    {
                        model.prolineID = int.Parse(dt.Rows[n]["prolineID"].ToString());
                    }
                    if (dt.Rows[n]["shopid"].ToString() != "")
                    {
                        model.shopid = int.Parse(dt.Rows[n]["shopid"].ToString());
                    }
                    if (dt.Rows[n]["sysTime"].ToString() != "")
                    {
                        model.sysTime = DateTime.Parse(dt.Rows[n]["sysTime"].ToString());
                    }
                    modelList.Add(model);
                }
            }
            return modelList;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetAllList()
        {
            return GetList("");
        }
        public DataSet getShoplist(Hashtable ht)
        {
            StringBuilder sb = new StringBuilder();
            StringBuilder sb2 = new StringBuilder();
            if (ht["POPID"].ToString() != "0")
            {
                sb.Append(" and POPID='" + ht["POPID"].ToString() + "'");
            }
            if (ht["PosCode"].ToString().Length > 0)
            {
                sb.Append(" and Posid='" + ht["PosCode"].ToString() + "'");
                sb2.Append(" and Posid='" + ht["PosCode"].ToString() + "'");
            }
            if (ht["Shopname"].ToString().Length > 0)
            {
                sb.Append(" and shopname like '%" + ht["Shopname"].ToString() + "%'");
                sb2.Append(" and shopname like '%" + ht["Shopname"].ToString() + "%'");

            }

            if (ht["DealerID"].ToString() != "0")
            {
                sb.Append(" and DealerID = '" + ht["DealerID"].ToString() + "'");
                sb2.Append(" and DealerID = '" + ht["DealerID"].ToString() + "'");

            }

            if (ht["areaID"].ToString() != "-1")
            {
                sb.Append(" and areaID = " + ht["areaID"].ToString());
                sb.Append(" and areaID = " + ht["areaID"].ToString());

            }
            if (ht["ProvinceID"].ToString() != "0")
            {
                sb.Append(" and ProvinceID = " + ht["ProvinceID"].ToString());
                sb2.Append(" and ProvinceID = " + ht["ProvinceID"].ToString());

            }
            if (ht["CityID"].ToString() != "0")
            {
                sb.Append(" and CityID = " + ht["CityID"].ToString());
                sb2.Append(" and CityID = " + ht["CityID"].ToString());

            }

            DataTable dt1 = dal.getShoplist(sb.ToString());
            DataTable dt2 = dal.GetshoplistNO(sb2.ToString());

            DataSet tds = new DataSet();
            //tds.Tables.Add(dt1);
            //tds.Tables.Add(dt2);

            return tds;
            //return dal.GetNewaddPOPCount(sb.ToString());
        }

        /// <summary>
        /// 得到各个供应商所得到的订单数量
        /// </summary>
        /// <returns></returns>
        public DataTable Supplier_POPcount(string strwhere)
        {
            return dal.Supplier_POPcount(strwhere);
        }
        /// <summary>
        /// 得到各个图片的POP的数量
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataTable Supplier_popcountByimg(string strWhere)
        {
            return dal.Supplier_popcountByimg(strWhere);
        }
        /// <summary>
        /// 根据条件导出订单 每张pop信息
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataTable supplier_orderdaochu(string strWhere, string POPID)
        {
            return dal.supplier_orderdaochu(strWhere, POPID);
        }
        /// <summary>
        /// 得到没有提交订单的店铺列表
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataTable Supplier_NoSubmitOrderShop(string strWhere)
        {
            return dal.Supplier_NoSubmitOrderShop(strWhere);
        }

        /// <summary>
        /// 得到没有提交订单的店铺列表
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataTable Supplier_NoSubmitOrderShopNew(string strWhere, string POPID)
        {
            return dal.Supplier_NoSubmitOrderShopNew(strWhere, POPID);
        }

        /// <summary>
        /// 判断指定POP是否已经被提交
        /// </summary>
        /// <param name="POPInfoID">POP编号</param>
        /// <returns></returns>
        public int IsExist(string POPInfoID)
        {
            return dal.IsExist(POPInfoID);
        }


        #endregion  成员方法
    }
}

