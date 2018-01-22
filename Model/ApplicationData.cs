using System;
namespace LN.Model
{
	/// <summary>
	/// ʵ����ApplicationData ��(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
	/// </summary>
	[Serializable]
	public class ApplicationData
	{
		public ApplicationData()
		{}
		#region Model
		private int _id;
		private int? _shopid;
		private string _poscode;
		private string _popseatnum;
		private string _seatdesc;
		private decimal? _popheight;
		private decimal? _popwith;
		private decimal? _poparea;
		private string _popmaterial;
		private int? _productlineid;
		private string _sexarea;
		private int? _twosided;
		private int? _glass;
		private decimal? _platformwith;
		private decimal? _platformheight;
		private decimal? _platformlong;
		private int? _applyuserid;
		private string _applytype;
		private string _applydesc;
		private string _applydate;
		private string _photopath;
		private int? _areavmexamstate;
		private string _areavmexamdesc;
		private int? _areavmexamuseid;
		/// <summary>
		/// ������ID
		/// </summary>
		public int ID
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// Shop��ʾ
		/// </summary>
		public int? ShopID
		{
			set{ _shopid=value;}
			get{return _shopid;}
		}
		/// <summary>
		/// �ɲ���̺�
		/// </summary>
		public string POSCode
		{
			set{ _poscode=value;}
			get{return _poscode;}
		}
		/// <summary>
		/// Popλ�ñ��
		/// </summary>
		public string POPSeatNum
		{
			set{ _popseatnum=value;}
			get{return _popseatnum;}
		}
		/// <summary>
		/// λ������
		/// </summary>
		public string SeatDesc
		{
			set{ _seatdesc=value;}
			get{return _seatdesc;}
		}
		/// <summary>
		/// POP��
		/// </summary>
		public decimal? POPHeight
		{
			set{ _popheight=value;}
			get{return _popheight;}
		}
		/// <summary>
		/// POP��
		/// </summary>
		public decimal? POPWith
		{
			set{ _popwith=value;}
			get{return _popwith;}
		}
		/// <summary>
		/// POP���
		/// </summary>
		public decimal? POPArea
		{
			set{ _poparea=value;}
			get{return _poparea;}
		}
		/// <summary>
		/// ����ID
		/// </summary>
		public string POPMaterial
		{
			set{ _popmaterial=value;}
			get{return _popmaterial;}
		}
		/// <summary>
		/// ��Ʒϵ��ID
		/// </summary>
		public int? ProductLineID
		{
			set{ _productlineid=value;}
			get{return _productlineid;}
		}
		/// <summary>
		/// ��/Ů���� 1 ��2 Ů 3 ��Ů����
		/// </summary>
		public string Sexarea
		{
			set{ _sexarea=value;}
			get{return _sexarea;}
		}
		/// <summary>
		/// ˫�� 1 �� 2 ��
		/// </summary>
		public int? TwoSided
		{
			set{ _twosided=value;}
			get{return _twosided;}
		}
		/// <summary>
		/// ���� 1 �� 0 ��
		/// </summary>
		public int? Glass
		{
			set{ _glass=value;}
			get{return _glass;}
		}
		/// <summary>
		/// ��̨���
		/// </summary>
		public decimal? PlatformWith
		{
			set{ _platformwith=value;}
			get{return _platformwith;}
		}
		/// <summary>
		/// ��̨�߶�
		/// </summary>
		public decimal? PlatformHeight
		{
			set{ _platformheight=value;}
			get{return _platformheight;}
		}
		/// <summary>
		/// ��̨����
		/// </summary>
		public decimal? PlatformLong
		{
			set{ _platformlong=value;}
			get{return _platformlong;}
		}
		/// <summary>
		/// ������ID
		/// </summary>
		public int? ApplyUserID
		{
			set{ _applyuserid=value;}
			get{return _applyuserid;}
		}
		/// <summary>
		/// �������ͣ����ӣ����٣��޸�
		/// </summary>
		public string ApplyType
		{
			set{ _applytype=value;}
			get{return _applytype;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ApplyDesc
		{
			set{ _applydesc=value;}
			get{return _applydesc;}
		}
		/// <summary>
		/// ����ʱ��
		/// </summary>
		public string ApplyDate
		{
			set{ _applydate=value;}
			get{return _applydate;}
		}
		/// <summary>
		/// ����ͼƬ·��
		/// </summary>
		public string PhotoPath
		{
			set{ _photopath=value;}
			get{return _photopath;}
		}
		/// <summary>
		/// ����VM����״̬
		/// </summary>
		public int? AreaVMExamState
		{
			set{ _areavmexamstate=value;}
			get{return _areavmexamstate;}
		}
		/// <summary>
		/// ����VM������ע
		/// </summary>
		public string AreaVMExamDesc
		{
			set{ _areavmexamdesc=value;}
			get{return _areavmexamdesc;}
		}
		/// <summary>
		/// ����VM������ID
		/// </summary>
		public int? AreaVMExamUseID
		{
			set{ _areavmexamuseid=value;}
			get{return _areavmexamuseid;}
		}
		#endregion Model

	}
}

