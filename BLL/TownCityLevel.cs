using System;
using System.Data;
using System.Collections.Generic;
namespace LN.BLL
{
	/// <summary>
	/// ҵ���߼���TownCityLevel ��ժҪ˵����
	/// </summary>
	public class TownCityLevel
	{
		private readonly LN.DAL.TownCityLevel dal=new LN.DAL.TownCityLevel();
		public TownCityLevel()
		{}
		#region  ��Ա����

        /// <summary>
        /// �õ�һ������ʵ��
        /// </summary>
        public LN.Model.TownCityLevel GetModel(int TCL_Id)
        {

            return dal.GetModel(TCL_Id);
        }

        /// <summary>
        /// ��������б�
        /// </summary>
        public IList<LN.Model.TownCityLevel> GetList(string strWhere)
        {
            return dal.GetList(strWhere);
        }

		#endregion  ��Ա����
	}
}

