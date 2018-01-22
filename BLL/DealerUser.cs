using System;
using System.Data;
using System.Collections.Generic;

using LN.Model;
namespace LN.BLL
{
	/// <summary>
	/// ҵ���߼���DealerUser ��ժҪ˵����
	/// </summary>
	public class DealerUser
	{
		private readonly LN.DAL.DealerUser dal=new LN.DAL.DealerUser();
		public DealerUser()
		{}
		#region  ��Ա����

		/// <summary>
		/// ����һ������
		/// </summary>
		public int  Add(LN.Model.DealerUser model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// ����һ������
		/// </summary>
		public void Update(LN.Model.DealerUser model)
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
		public LN.Model.DealerUser GetModel(int ID)
		{
			
			return dal.GetModel(ID);
		}


		/// <summary>
		/// ��������б�
		/// </summary>
        public IList<LN.Model.DealerUser> GetList(string strWhere)
		{
			return dal.GetList(strWhere);
		}

        /// <summary>
        /// ͨ���û���Ż�ȡһ���ͻ���
        /// </summary>
        /// <param name="userid">�û����</param>
        /// <returns>����һ���ͻ���</returns>
        public DataTable GetDealerIdByUserID(int userid)
        {
            return dal.GetDealerIdByUserID(userid);
        }

		#endregion  ��Ա����
	}
}

