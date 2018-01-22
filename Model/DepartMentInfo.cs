using System;
namespace LN.Model
{
	/// <summary>
	/// 实体类DepartMentInfo 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public class DepartMentInfo
	{
		public DepartMentInfo()
		{}
		#region Model
        //private int _id;
        //private string _department;
        //private string _department_master;
        //private string _department_masterphone;
        ///// <summary>
        ///// 
        ///// </summary>
        //public int ID
        //{
        //    set{ _id=value;}
        //    get{return _id;}
        //}
        ///// <summary>
        ///// 
        ///// </summary>
        //public string department
        //{
        //    set{ _department=value;}
        //    get{return _department;}
        //}
        ///// <summary>
        ///// 
        ///// </summary>
        //public string Department_Master
        //{
        //    set{ _department_master=value;}
        //    get{return _department_master;}
        //}
        ///// <summary>
        ///// 
        ///// </summary>
        //public string department_MasterPhone
        //{
        //    set{ _department_masterphone=value;}
        //    get{return _department_masterphone;}
        //}
        public int? ID { get; set; }
        public string department { get; set; }
        public string Department_Master { get; set; }
        public string department_MasterPhone { get; set; }
        public int? State { get; set; }
        
		#endregion Model

	}
}

