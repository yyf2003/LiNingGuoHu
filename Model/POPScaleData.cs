using System;
namespace LN.Model
{
	/// <summary>
	/// ʵ����POPScaleData ��(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
	/// </summary>
	public class POPScaleData
	{
		public POPScaleData()
		{}
		#region Model
		private int _photoscaleid;
		private string _photoscale;
		/// <summary>
		/// �������Զ�����
		/// </summary>
		public int PhotoScaleID
		{
			set{ _photoscaleid=value;}
			get{return _photoscaleid;}
		}
		/// <summary>
		/// ��������
		/// </summary>
		public string PhotoScale
		{
			set{ _photoscale=value;}
			get{return _photoscale;}
		}
		#endregion Model

	}
}

