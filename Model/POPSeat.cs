using System;
namespace LN.Model
{
	/// <summary>
	/// 实体类POPSeat 。(属性说明自动提取数据库字段的描述信息)
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
		/// POP 位置  例如：橱窗，收银台 等等
		/// </summary>
		public string seat
		{
			set{ _seat=value;}
			get{return _seat;}
		}
		#endregion Model

	}
}

