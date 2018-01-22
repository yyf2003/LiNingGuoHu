using System;
namespace LN.Model
{
    /// <summary>
    /// ʵ����ShopRetailAttribute ��(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
    /// </summary>
    [Serializable]
    public class ShopRetailAttribute
    {
        public ShopRetailAttribute() { }

		#region Model
		private int _sa_id;
		private string _sa_name;
		/// <summary>
		/// 
		/// </summary>
        public int SA_Id
		{
            set { _sa_id = value; }
            get { return _sa_id; }
		}
		/// <summary>
		/// 
		/// </summary>
        public string SA_Name
		{
            set { _sa_name = value; }
            get { return _sa_name; }
		}
		#endregion Model
    }
}
