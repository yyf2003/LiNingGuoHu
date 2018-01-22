using System;
namespace LN.Model
{
	/// <summary>
	/// ʵ����UserInfo ��(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
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
		/// ��������,����
		/// </summary>
		public int? ID
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// ��ԱID�Զ���
		/// </summary>
		public int? UserID
		{
			set{ _userid=value;}
			get{return _userid;}
		}
		/// <summary>
		/// ��Ա����
		/// </summary>
		public string Username
		{
			set{ _username=value;}
			get{return _username;}
		}
		/// <summary>
		/// �Ա�
		/// </summary>
		public string Sex
		{
			set{ _sex=value;}
			get{return _sex;}
		}
		/// <summary>
		/// ��Ա����
		/// </summary>
		public string Usertype
		{
			set{ _usertype=value;}
			get{return _usertype;}
		}
		/// <summary>
		/// ����
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
		/// ��ַ
		/// </summary>
		public string UserAddress
		{
			set{ _useraddress=value;}
			get{return _useraddress;}
		}
		/// <summary>
		/// ��ͥ�绰
		/// </summary>
		public string UserPhone
		{
			set{ _userphone=value;}
			get{return _userphone;}
		}
		/// <summary>
		/// �ƶ��绰
		/// </summary>
		public string UserMobel
		{
			set{ _usermobel=value;}
			get{return _usermobel;}
		}
		/// <summary>
		/// ״̬ 1��ְ 0��ְ
		/// </summary>
		public int? UserState
		{
			set{ _userstate=value;}
			get{return _userstate;}
		}
		/// <summary>
		/// ��ע
		/// </summary>
		public string UserDesc
		{
			set{ _userdesc=value;}
			get{return _userdesc;}
		}
        /// <summary>
        /// ��Ա���ڵ�����
        /// </summary>
        public int? Userofarea
        {
            set { _userofarea = value; }
            get { return _userofarea; }
        }
		#endregion Model

	}
}

