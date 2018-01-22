using System;
using System.Data;
using System.Collections.Generic;
using LN.Model;

namespace LN.BLL
{
	/// <summary>
	/// ҵ���߼���tb_FOSPOP ��ժҪ˵����
	/// </summary>
	public class tb_FOSPOP
	{
		private readonly LN.DAL.tb_FOSPOP dal=new LN.DAL.tb_FOSPOP();

		public tb_FOSPOP(){}

		#region  ��Ա����

		/// <summary>
		/// ����һ������
		/// </summary>
		public int  Add(LN.Model.tb_FOSPOP model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// ����һ������
		/// </summary>
		public int Update(LN.Model.tb_FOSPOP model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// ɾ��һ������
		/// </summary>
        public int Delete(int FOS_ID)
		{
            return dal.Delete(FOS_ID);
		}

		/// <summary>
		/// �õ�һ������ʵ��
		/// </summary>
        public LN.Model.tb_FOSPOP GetModel(string FOS_POPSeat)
		{
            return dal.GetModel(FOS_POPSeat);
		}

		/// <summary>
		/// ��������б�
		/// </summary>
        public IList<LN.Model.tb_FOSPOP> GetList(string strWhere)
		{
			return dal.GetList(strWhere);
		}

		#endregion  ��Ա����
	}
}

