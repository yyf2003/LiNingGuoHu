using System;
using System.Data;
using System.Collections.Generic;

using LN.Model;
namespace LN.BLL
{
	/// <summary>
	/// ҵ���߼���GoodsConfirm ��ժҪ˵����
	/// </summary>
	public class GoodsConfirm
	{
		private readonly LN.DAL.GoodsConfirm dal=new LN.DAL.GoodsConfirm();
		public GoodsConfirm()
		{}
		#region  ��Ա����

		/// <summary>
		/// �޸�����
		/// </summary>
        public int Operate(LN.Model.GoodsConfirm model)
		{
			return dal.Operate(model);
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
		public LN.Model.GoodsConfirm GetModel(int ID)
		{
			
			return dal.GetModel(ID);
		}

		#endregion  ��Ա����
	}
}

