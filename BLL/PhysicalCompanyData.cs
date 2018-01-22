using System;
using System.Data;
using System.Collections.Generic;

using LN.Model;
namespace LN.BLL
{
	/// <summary>
	/// ҵ���߼���PhysicalCompanyData ��ժҪ˵����
	/// </summary>
	public class PhysicalCompanyData
	{
		private readonly LN.DAL.PhysicalCompanyData dal=new LN.DAL.PhysicalCompanyData();
		public PhysicalCompanyData()
		{}
		#region  ��Ա����

		/// <summary>
		/// ����һ������
		/// </summary>
		public int  Add(LN.Model.PhysicalCompanyData model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// ����һ������
		/// </summary>
		public int Update(int id,string name,string photo)
		{
			return dal.Update(id,name,photo);
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
		public LN.Model.PhysicalCompanyData GetModel(int ID)
		{
			
			return dal.GetModel(ID);
		}

		/// <summary>
		/// ��������б�
		/// </summary>
		public IList<LN.Model.PhysicalCompanyData> GetList(string strWhere)
		{
            return dal.GetList(strWhere);
		}

		#endregion  ��Ա����
	}
}

