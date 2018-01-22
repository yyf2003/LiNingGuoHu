using System;
using System.Data;
using System.Collections.Generic;
using LN.Model;
namespace LN.BLL
{
	/// <summary>
	/// ҵ���߼���AreaData ��ժҪ˵����
	/// </summary>
	public class AreaData
	{
		private readonly LN.DAL.AreaData dal=new LN.DAL.AreaData();
		public AreaData()
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
		public bool Exists(int AreaID)
		{
			return dal.Exists(AreaID);
		}

		/// <summary>
		/// ����һ������
		/// </summary>
		public int  Add(LN.Model.AreaData model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// ����һ������
		/// </summary>
		public void Update(LN.Model.AreaData model)
		{
			dal.Update(model);
		}

		/// <summary>
		/// ɾ��һ������
		/// </summary>
		public void Delete(int AreaID)
		{
			
			dal.Delete(AreaID);
		}

		/// <summary>
		/// �õ�һ������ʵ��
		/// </summary>
		public LN.Model.AreaData GetModel(int AreaID)
		{
			
			return dal.GetModel(AreaID);
		}



        /// <summary>
        /// ��������б�
        /// </summary>
        public IList<LN.Model.AreaData> GetList(string strWhere)
        {
			return dal.GetList(strWhere);
		}

		#endregion  ��Ա����
	}
}

