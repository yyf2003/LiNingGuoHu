using System;
using System.Data;
using System.Collections.Generic;
using LN.Model;

namespace LN.BLL
{
    /// <summary>
    /// ҵ���߼���tb_OrderSearch_Time ��ժҪ˵����
    /// </summary>
    public class tb_OrderSearch_Time
    {
        private readonly LN.DAL.tb_OrderSearch_Time dal = new LN.DAL.tb_OrderSearch_Time();

        public tb_OrderSearch_Time() { }

        #region  ��Ա����

        /// <summary>
        /// ����һ������
        /// </summary>
        public int Add(LN.Model.tb_OrderSearch_Time model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// ����POPID��ȡ������ض�����ʱ��
        /// </summary>
        /// <param name="POPID">�ƶ�POPID</param>
        /// <returns>����ʱ��</returns>
        public string GetOrderSearchByPOPID(string POPID,int UserID)
        {
            return dal.GetOrderSearchByPOPID(POPID, UserID);
        }

        #endregion
    }
}
