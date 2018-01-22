using System;
namespace LN.Model
{
	/// <summary>
	/// 实体类UserInfo 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	public class UserInfo
	{
		public UserInfo()
		{}
		#region Model
		private int? _id;
		private int? _userid;
		private string _username;
		private string _sex;
		private string _usertype;
		private string _userpassword;
		private string _useremail;
		private string _useraddress;
		private string _userphone;
		private string _usermobel;
		private int? _userstate;
		private string _userdesc;
        private int? _userofarea;
		/// <summary>
		/// 自增长列,主键
		/// </summary>
		public int? ID
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 人员ID自定义
		/// </summary>
		public int? UserID
		{
			set{ _userid=value;}
			get{return _userid;}
		}
		/// <summary>
		/// 人员姓名
		/// </summary>
		public string Username
		{
			set{ _username=value;}
			get{return _username;}
		}
		/// <summary>
		/// 性别
		/// </summary>
		public string Sex
		{
			set{ _sex=value;}
			get{return _sex;}
		}
		/// <summary>
		/// 人员类型
		/// </summary>
		public string Usertype
		{
			set{ _usertype=value;}
			get{return _usertype;}
		}
		/// <summary>
		/// 密码
		/// </summary>
		public string UserPassword
		{
			set{ _userpassword=value;}
			get{return _userpassword;}
		}
		/// <summary>
		/// Email
		/// </summary>
		public string UserEmail
		{
			set{ _useremail=value;}
			get{return _useremail;}
		}
		/// <summary>
		/// 地址
		/// </summary>
		public string UserAddress
		{
			set{ _useraddress=value;}
			get{return _useraddress;}
		}
		/// <summary>
		/// 家庭电话
		/// </summary>
		public string UserPhone
		{
			set{ _userphone=value;}
			get{return _userphone;}
		}
		/// <summary>
		/// 移动电话
		/// </summary>
		public string UserMobel
		{
			set{ _usermobel=value;}
			get{return _usermobel;}
		}
		/// <summary>
		/// 状态 1在职 0离职
		/// </summary>
		public int? UserState
		{
			set{ _userstate=value;}
			get{return _userstate;}
		}
		/// <summary>
		/// 备注
		/// </summary>
		public string UserDesc
		{
			set{ _userdesc=value;}
			get{return _userdesc;}
		}
        /// <summary>
        /// 人员所在的区域
        /// </summary>
        public int? Userofarea
        {
            set { _userofarea = value; }
            get { return _userofarea; }
        }
		#endregion Model

	}
}

