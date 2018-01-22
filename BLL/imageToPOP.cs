using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using LN.Model;
namespace LN.BLL
{
	/// <summary>
	/// ҵ���߼���imageToPOP ��ժҪ˵����
	/// </summary>
    public class imageToPOP
    {
        private readonly LN.DAL.imageToPOP dal = new LN.DAL.imageToPOP();
        public imageToPOP()
        { }
        #region  ��Ա����
        /// <summary>
        /// �Ƿ���ڸü�¼
        /// </summary>
        public bool Exists(int ID)
        {
            return dal.Exists(ID);
        }

        /// <summary>
        /// ����һ������
        /// </summary>
        public int Add(LN.Model.imageToPOP model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// ����ͼƬ��ַ add by mhj 2012.2.5
        /// </summary>
        /// <param name="model"></param>
        /// <param name="type">0Ϊ����ǰͼƬ��1���º�ͼƬ</param>
        /// <returns></returns>
        public int UpdateImage(LN.Model.imageToPOP model, int type)
        {
            return dal.UpdateImage(model, type);
        }

        /// <summary>
        /// ����һ������
        /// </summary>
        public void Update(LN.Model.imageToPOP model)
        {
            dal.Update(model);
        }

        /// <summary>
        /// ɾ��һ������
        /// </summary>
        public void Delete(int ID)
        {

            dal.Delete(ID);
        }
        /// <summary>
        /// ɾ��һ������
        /// </summary>
        public void Delete(string str)
        {

            dal.Delete(str);
        }
        /// <summary>
        /// �õ�һ������ʵ��
        /// </summary>
        public LN.Model.imageToPOP GetModel(int ID)
        {

            return dal.GetModel(ID);
        }



        /// <summary>
        /// ��������б�
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            return dal.GetList(strWhere);
        }

        /// <summary>
        /// ���ǰ��������
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            return dal.GetList(Top, strWhere, filedOrder);
        }
        /// <summary>
        /// ��������б�
        /// </summary>
        public List<LN.Model.imageToPOP> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// ��������б�
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
        /// ��������б�
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
        /// �õ�������Ӧ�����õ��Ķ�������
        /// </summary>
        /// <returns></returns>
        public DataTable Supplier_POPcount(string strwhere)
        {
            return dal.Supplier_POPcount(strwhere);
        }
        /// <summary>
        /// �õ�����ͼƬ��POP������
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataTable Supplier_popcountByimg(string strWhere)
        {
            return dal.Supplier_popcountByimg(strWhere);
        }
        /// <summary>
        /// ���������������� ÿ��pop��Ϣ
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataTable supplier_orderdaochu(string strWhere, string POPID)
        {
            return dal.supplier_orderdaochu(strWhere, POPID);
        }
        /// <summary>
        /// �õ�û���ύ�����ĵ����б�
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataTable Supplier_NoSubmitOrderShop(string strWhere)
        {
            return dal.Supplier_NoSubmitOrderShop(strWhere);
        }

        /// <summary>
        /// �õ�û���ύ�����ĵ����б�
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataTable Supplier_NoSubmitOrderShopNew(string strWhere, string POPID)
        {
            return dal.Supplier_NoSubmitOrderShopNew(strWhere, POPID);
        }

        /// <summary>
        /// �ж�ָ��POP�Ƿ��Ѿ����ύ
        /// </summary>
        /// <param name="POPInfoID">POP���</param>
        /// <returns></returns>
        public int IsExist(string POPInfoID)
        {
            return dal.IsExist(POPInfoID);
        }


        #endregion  ��Ա����
    }
}

