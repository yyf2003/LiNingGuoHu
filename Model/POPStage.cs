using System;
namespace LN.Model
{
	/// <summary>
	/// ʵ����POPStage ��(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
	/// </summary>
	public class POPStage
	{
		public POPStage()
		{}
		#region Model
		private int _stageid;
		private int? _supplierid;
		private int? _popid;
		private string _popmaterial;
		private decimal? _popprice;
		private int? _examuserid;
		private string _examdate;
		/// <summary>
		/// �������Զ�����
		/// </summary>
		public int StageID
		{
			set{ _stageid=value;}
			get{return _stageid;}
		}
		/// <summary>
		/// ���ü۸�Ĺ�Ӧ��ID
		/// </summary>
		public int? SupplierID
		{
			set{ _supplierid=value;}
			get{return _supplierid;}
		}
		/// <summary>
		/// POPID
		/// </summary>
		public int? POPID
		{
			set{ _popid=value;}
			get{return _popid;}
		}
		/// <summary>
		/// ����
		/// </summary>
		public string POPMaterial
		{
			set{ _popmaterial=value;}
			get{return _popmaterial;}
		}
		/// <summary>
		/// ����
		/// </summary>
		public decimal? POPprice
		{
			set{ _popprice=value;}
			get{return _popprice;}
		}
		/// <summary>
		/// ������ID
		/// </summary>
		public int? ExamUserID
		{
			set{ _examuserid=value;}
			get{return _examuserid;}
		}
		/// <summary>
		/// ����ʱ��
		/// </summary>
		public string ExamDate
		{
			set{ _examdate=value;}
			get{return _examdate;}
		}
		#endregion Model

	}
}

