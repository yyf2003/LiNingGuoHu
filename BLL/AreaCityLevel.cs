using System;
using System.Data;
using System.Collections.Generic;
namespace LN.BLL
{
	/// <summary>
	/// ҵ���߼���AreaCityLevel ��ժҪ˵����
	/// </summary>
	public class AreaCityLevel
	{
		private readonly LN.DAL.AreaCityLevel dal=new LN.DAL.AreaCityLevel();
		public AreaCityLevel()
		{}
		#region  ��Ա����


		/// <summary>
		/// �õ�һ������ʵ��
		/// </summary>
		public LN.Model.AreaCityLevel GetModel(int ACL_Id)
		{
			
			return dal.GetModel(ACL_Id);
		}

		/// <summary>
		/// ��������б�
		/// </summary>
        public IList<LN.Model.AreaCityLevel> GetList(string strWhere)
		{
            return dal.GetList(strWhere);
		}

		#endregion  ��Ա����
	}
}

