using System;
namespace LN.Model
{
	/// <summary>
	/// ʵ����AreaData ��(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
	/// </summary>
	public class AreaData
	{
		public AreaData()
		{}
		#region Model
		private int _areaid;
		private string _areaname;
        private string _dept;
		/// <summary>
		/// �����������Զ�����
		/// </summary>
		public int AreaID
		{
			set{ _areaid=value;}
			get{return _areaid;}
		}
		/// <summary>
		/// ��������
		/// </summary>
		public string AreaName
		{
			set{ _areaname=value;}
			get{return _areaname;}
		}
        /// <summary>
        /// ��������
        /// </summary>
        public string DepartMent
        {
            set { _dept = value; }
            get { return _dept; }
        }
		#endregion Model

	}
}

