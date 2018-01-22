using System;
using System.Data;
using System.Collections.Generic;

using LN.Model;
namespace LN.BLL
{
    /// <summary>
    /// ҵ���߼���UserAreaMange ��ժҪ˵����
    /// </summary>
    public class UserAreaMange
    {
        private readonly LN.DAL.UserAreaMange dal = new LN.DAL.UserAreaMange();
        public UserAreaMange()
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
        /// ����һ������
        /// </summary>
        public int Add(LN.Model.UserAreaMange model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// ����һ������
        /// </summary>
        public void Update(LN.Model.UserAreaMange model)
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
        /// ɾ���û�������
        /// </summary>
        /// <param name="UserID"></param>
        public void DeleteUserData(int UserID)
        {
            dal.DeleteUserData(UserID);
        }
        /// <summary>
        /// �õ�һ������ʵ��
        /// </summary>
        public LN.Model.UserAreaMange GetModel(int ID)
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
        public List<LN.Model.UserAreaMange> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            List<LN.Model.UserAreaMange> modelList = new List<LN.Model.UserAreaMange>();
            int rowsCount = ds.Tables[0].Rows.Count;
            if (rowsCount > 0)
            {
                LN.Model.UserAreaMange model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new LN.Model.UserAreaMange();
                    if (ds.Tables[0].Rows[n]["ID"].ToString() != "")
                    {
                        model.ID = int.Parse(ds.Tables[0].Rows[n]["ID"].ToString());
                    }
                    if (ds.Tables[0].Rows[n]["UserID"].ToString() != "")
                    {
                        model.UserID = int.Parse(ds.Tables[0].Rows[n]["UserID"].ToString());
                    }
                    if (ds.Tables[0].Rows[n]["AreaID"].ToString() != "")
                    {
                        model.AreaID = int.Parse(ds.Tables[0].Rows[n]["AreaID"].ToString());
                    }
                    if (ds.Tables[0].Rows[n]["ProvinceID"].ToString() != "")
                    {
                        model.ProvinceID = int.Parse(ds.Tables[0].Rows[n]["ProvinceID"].ToString());
                    }
                    if (ds.Tables[0].Rows[n]["CityID"].ToString() != "")
                    {
                        model.CityID = int.Parse(ds.Tables[0].Rows[n]["CityID"].ToString());
                    }
                    if (ds.Tables[0].Rows[n]["TownID"].ToString() != "")
                    {
                        model.TownID = int.Parse(ds.Tables[0].Rows[n]["TownID"].ToString());
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

        /// <summary>
        /// �õ������������Ϣ
        /// </summary>
        /// <param name="UID"></param>
        /// <returns></returns>
        public DataSet GetUserAssginArea(int UID)
        {
            return dal.GetUserAssginArea(UID);
        }

        /// <summary>
        /// �õ�����ĳ�����Ϣ
        /// </summary>
        /// <param name="UID"></param>
        /// <returns></returns>
        public DataSet GetUserAssginCity(int UID)
        {
            return dal.GetUserAssginCity(UID);
        }

        /// <summary>
        /// �õ������ʡ����Ϣ
        /// </summary>
        /// <param name="UID"></param>
        /// <returns></returns>
        public DataSet GetUserAssginProvice(int UID)
        {
            return dal.GetUserAssginProvice(UID);
        }
          /// <summary>
        /// �õ�����ĳ�����Ϣ
        /// </summary>
        /// <param name="UID"></param>
        /// <returns></returns>
        public DataSet GetUserAssginTown(int UID)
        {
            return dal.GetUserAssginTown(UID);
        }
        /// <summary>
        /// ��������б�
        /// </summary>
        //public DataSet GetList(int PageSize,int PageIndex,string strWhere)
        //{
        //return dal.GetList(PageSize,PageIndex,strWhere);
        //}

        #endregion  ��Ա����
    }
}

