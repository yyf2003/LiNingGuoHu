using System;
namespace LN.Model
{
	/// <summary>
	/// ʵ����POPSeat ��(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
	/// </summary>
	public class POPSeat
	{
		public POPSeat()
		{}
		#region Model
		private int _seatid;
		private string _seat;
		/// <summary>
		/// 
		/// </summary>
		public int SeatID
		{
			set{ _seatid=value;}
			get{return _seatid;}
		}
		/// <summary>
		/// POP λ��  ���磺����������̨ �ȵ�
		/// </summary>
		public string seat
		{
			set{ _seat=value;}
			get{return _seat;}
		}
		#endregion Model

	}
}

