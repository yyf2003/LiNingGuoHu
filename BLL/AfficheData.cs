using System;
using System.Data;
using System.Collections.Generic;

using LN.Model;
namespace LN.BLL
{
    /// <summary>
    /// ҵ���߼���AfficheData ��ժҪ˵����
    /// </summary>
    public class AfficheData
    {
        private readonly LN.DAL.AfficheData dal = new LN.DAL.AfficheData();
        public AfficheData()
        { }
        #region  ��Ա����

        /// <summary>
        /// �õ����ID
        /// </summary>
        public int GetMaxId()
        {
            return dal.GetMaxId();
        }

        /// <summary>
        /// �Ƿ���ڸü�¼
        /// </summary>
        public bool Exists(int ID)
        {
            return dal.Exists(ID);
        }
           /// <summary>
        /// ���µ����
        /// </summary>
        /// <param name="ID"></param>
        public void UpdateClick(int ID)
        {
            dal.UpdateClick(ID);
        }

        /// <summary>
        /// ����һ������
        /// </summary>
        public int Add(LN.Model.AfficheData model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// ����һ������
        /// </summary>
        public void Update(LN.Model.AfficheData model)
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
        /// �õ�һ������ʵ��
        /// </summary>
        public LN.Model.AfficheData GetModel(int ID)
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
        /// ��������б�
        /// </summary>
        public List<LN.Model.AfficheData> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            List<LN.Model.AfficheData> modelList = new List<LN.Model.AfficheData>();
            int rowsCount = ds.Tables[0].Rows.Count;
            if (rowsCount > 0)
            {
                LN.Model.AfficheData model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new LN.Model.AfficheData();
                    if (ds.Tables[0].Rows[n]["ID"].ToString() != "")
                    {
                        model.ID = int.Parse(ds.Tables[0].Rows[n]["ID"].ToString());
                    }
                    model.UserID = ds.Tables[0].Rows[n]["UserID"].ToString();
                    model.TypeID = ds.Tables[0].Rows[n]["TypeID"].ToString();
                    model.Title = ds.Tables[0].Rows[n]["Title"].ToString();
                    model.Main = ds.Tables[0].Rows[n]["Main"].ToString();
                    if (ds.Tables[0].Rows[n]["Click"].ToString() != "")
                    {
                        model.Click = int.Parse(ds.Tables[0].Rows[n]["Click"].ToString());
                    }
                    if (ds.Tables[0].Rows[n]["IsScroll"].ToString() != "")
                    {
                        model.IsScroll = int.Parse(ds.Tables[0].Rows[n]["IsScroll"].ToString());
                    }
                    if (ds.Tables[0].Rows[n]["IsDel"].ToString() != "")
                    {
                        model.IsDel = int.Parse(ds.Tables[0].Rows[n]["IsDel"].ToString());
                    }
                    model.FileUrl = ds.Tables[0].Rows[n]["FileUrl"].ToString();
                    model.Time = ds.Tables[0].Rows[n]["Time"].ToString();
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

        /// <summary>
        /// ��������б�
        /// </summary>
        //public DataSet GetList(int PageSize,int PageIndex,string strWhere)
        //{
        //return dal.GetList(PageSize,PageIndex,strWhere);
        //}

           /// <summary>
        /// ����ǰ̨����
        /// </summary>
        public void SetScroll(int ID)
        {
            dal.SetScroll(ID);
        }

          /// <summary>
        /// ȡ��ǰ̨����
        /// </summary>
        public void DelScroll(int ID)
        {
            dal.DelScroll(ID);
        }

        /// <summary>
        /// �õ���ҳҳ��
        /// </summary>
        /// <returns></returns>
        public int GetPageNumWithTypeID(string typeid)
        {
            return dal.GetPageNumWithTypeID(typeid);
        }

        /// <summary>
        /// ����ҳ������DataTable
        /// </summary>
        /// <param name="pageNum">ҳ��</param>
        /// <param name="typeid">���</param>
        /// <returns></returns>
        public DataTable GetPageWithNumWithTypeID(int pageNum, string typeid)
        {
            return dal.GetPageWithNumWithTypeID(pageNum, typeid);
        }
          /// <summary>
        /// ��������б�ǰ6��
        /// </summary>
        public DataSet GetTop6List(string strWhere)
        {
            return dal.GetTop6List(strWhere);
        }

            /// <summary>
        /// �������ǰ������������
        /// </summary>
        public DataSet GetTop6ScrollList()
        {
            return dal.GetTop6ScrollList();
        }

        #endregion  ��Ա����
    }
}

