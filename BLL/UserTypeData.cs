using System;
using System.Data;
using System.Collections.Generic;
using LN.Model;
namespace LN.BLL
{
	/// <summary>
	/// ҵ���߼���UserTypeData ��ժҪ˵����
	/// </summary>
	public class UserTypeData
	{
		private readonly LN.DAL.UserTypeData dal=new LN.DAL.UserTypeData();
		public UserTypeData()
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
		public bool Exists(int ID)
		{
			return dal.Exists(ID);
		}

		/// <summary>
		/// ����һ������
		/// </summary>
		public int  Add(LN.Model.UserTypeData model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// ����һ������
		/// </summary>
		public void Update(LN.Model.UserTypeData model)
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
		public LN.Model.UserTypeData GetModel(int ID)
		{
			
			return dal.GetModel(ID);
		}
 
        /// <summary>
        /// ��������б�
        /// </summary>
        public IList<LN.Model.UserTypeData> GetList(string strWhere)
        {
			return dal.GetList(strWhere);
		}

        /// <summary>
        /// ��ȡָ���û���Ȩ��
        /// </summary>
        /// <param name="UserID">�û����</param>
        /// <returns></returns>
        public int GetUserType(string UserID)
        {
            return dal.GetUserType(UserID);
        }

		#endregion  ��Ա����
	}
}

