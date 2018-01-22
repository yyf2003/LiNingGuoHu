using System;
using System.Data;
using System.Collections.Generic;

using LN.Model;
namespace LN.BLL
{
	/// <summary>
	/// ҵ���߼���ProvinceData ��ժҪ˵����
	/// </summary>
	public class ProvinceData
	{
		private readonly LN.DAL.ProvinceData dal=new LN.DAL.ProvinceData();
		public ProvinceData()
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
		public bool Exists(int ProvinceID)
		{
			return dal.Exists(ProvinceID);
		}

		/// <summary>
		/// ����һ������
		/// </summary>
		public void Add(LN.Model.ProvinceData model)
		{
			dal.Add(model);
		}

		/// <summary>
		/// ����һ������
		/// </summary>
		public void Update(LN.Model.ProvinceData model)
		{
			dal.Update(model);
		}

		/// <summary>
		/// ɾ��һ������
		/// </summary>
		public void Delete(int ProvinceID)
		{
			
			dal.Delete(ProvinceID);
		}

		/// <summary>
		/// �õ�һ������ʵ��
		/// </summary>
		public LN.Model.ProvinceData GetModel(int ProvinceID)
		{
			
			return dal.GetModel(ProvinceID);
		}

        /// <summary>
        /// ��������б�
        /// </summary>
        public IList<LN.Model.ProvinceData> GetList(string strWhere)
        {
			return dal.GetList(strWhere);
		}

		#endregion  ��Ա����
	}
}

