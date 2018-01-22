using System;
using System.Data;
using System.Collections.Generic;
using System.Collections;
using LN.Model;
namespace LN.BLL
{
	/// <summary>
	/// ҵ���߼���POPImageData ��ժҪ˵����
	/// </summary>
	public class POPImageData
	{
		private readonly LN.DAL.POPImageData dal=new LN.DAL.POPImageData();
		public POPImageData()
		{}
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
		public bool Exists(int ImageID)
		{
			return dal.Exists(ImageID);
		}

		/// <summary>
		/// ����һ������
		/// </summary>
		public int  Add(LN.Model.POPImageData model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// ����һ������
		/// </summary>
		public void Update(LN.Model.POPImageData model)
		{
			dal.Update(model);
		}

		/// <summary>
		/// ɾ��һ������
		/// </summary>
		public void Delete(int ImageID)
		{
			
			dal.Delete(ImageID);
		}

		/// <summary>
		/// �õ�һ������ʵ��
		/// </summary>
		public LN.Model.POPImageData GetModel(int ImageID)
		{
			
			return dal.GetModel(ImageID);
		}

		/// <summary>
		/// ��������б�
		/// </summary>
        public List<LN.Model.POPImageData> GetList(string strWhere)
		{
			return dal.GetList(strWhere);
		}
		
         /// <summary>
        /// ����ָ��������ȡ
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public IList<string> GetImageLevel(string strWhere)
        {
            return dal.GetImageLevel(strWhere);
        }

		/// <summary>
		/// ��������б�
		/// </summary>
        public List<LN.Model.POPImageData> GetAllList()
		{
			return GetList("");
		}
             /// <summary>
        /// ���ϴ�ͼƬ��������
        /// </summary>
        /// <param name="htlist"></param>
        public void UpdateImgDesc(List<Hashtable> htlist)
        {
             dal.UpdateImgDesc(htlist);
        }
		/// <summary>
		/// ��������б�
		/// </summary>
		//public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		//{
			//return dal.GetList(PageSize,PageIndex,strWhere);
		//}
        /// <summary>
        /// �õ�����ͼƬ��POP����
        /// </summary>
        /// <param name="popid"></param>
        /// <returns></returns>
        public DataTable GetSetProtype(string popid)
        {
            return dal.GetSetProtype(popid);
        }

        public DataTable GetLineByType(string popid, string protype)
        {
            return dal.GetLineByType(popid, protype);
        }

         /// <summary>
        /// ���û���ʹ�÷�Χ
        /// </summary>
        /// <param name="imageId"></param>
        /// <param name="AreaIDs"></param>
        /// <param name="ACL_IDs"></param>
        /// <returns></returns>
        public int SetPOPImageUseRange(int imageId, string AreaIDs, string ACL_IDs)
        {
            return dal.SetPOPImageUseRange(imageId, AreaIDs, ACL_IDs);
        }

        /// <summary>
        /// ��ȡ����ʹ�÷�Χ
        /// </summary>
        /// <param name="imageId"></param>
        /// <returns></returns>
        public DataSet GetPOPImageUseRange(int imageId)
        {
            return dal.GetPOPImageUseRange(imageId);
        }
		#endregion  ��Ա����
	}
}

