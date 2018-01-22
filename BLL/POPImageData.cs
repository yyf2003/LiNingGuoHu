using System;
using System.Data;
using System.Collections.Generic;
using System.Collections;
using LN.Model;
namespace LN.BLL
{
	/// <summary>
	/// 业务逻辑类POPImageData 的摘要说明。
	/// </summary>
	public class POPImageData
	{
		private readonly LN.DAL.POPImageData dal=new LN.DAL.POPImageData();
		public POPImageData()
		{}
		#region  成员方法

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
			return dal.GetMaxId();
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int ImageID)
		{
			return dal.Exists(ImageID);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int  Add(LN.Model.POPImageData model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public void Update(LN.Model.POPImageData model)
		{
			dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(int ImageID)
		{
			
			dal.Delete(ImageID);
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public LN.Model.POPImageData GetModel(int ImageID)
		{
			
			return dal.GetModel(ImageID);
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
        public List<LN.Model.POPImageData> GetList(string strWhere)
		{
			return dal.GetList(strWhere);
		}
		
         /// <summary>
        /// 根据指定条件获取
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public IList<string> GetImageLevel(string strWhere)
        {
            return dal.GetImageLevel(strWhere);
        }

		/// <summary>
		/// 获得数据列表
		/// </summary>
        public List<LN.Model.POPImageData> GetAllList()
		{
			return GetList("");
		}
             /// <summary>
        /// 对上传图片进行设置
        /// </summary>
        /// <param name="htlist"></param>
        public void UpdateImgDesc(List<Hashtable> htlist)
        {
             dal.UpdateImgDesc(htlist);
        }
		/// <summary>
		/// 获得数据列表
		/// </summary>
		//public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		//{
			//return dal.GetList(PageSize,PageIndex,strWhere);
		//}
        /// <summary>
        /// 得到设置图片的POP大类
        /// </summary>
        /// <param name="popid"></param>
        /// <returns></returns>
        public DataTable GetSetProtype(string popid)
        {
            return dal.GetSetProtype(popid);
        }

        public DataTable GetLineByType(string popid, string protype)
        {
            return dal.GetLineByType(popid, protype);
        }

         /// <summary>
        /// 设置画面使用范围
        /// </summary>
        /// <param name="imageId"></param>
        /// <param name="AreaIDs"></param>
        /// <param name="ACL_IDs"></param>
        /// <returns></returns>
        public int SetPOPImageUseRange(int imageId, string AreaIDs, string ACL_IDs)
        {
            return dal.SetPOPImageUseRange(imageId, AreaIDs, ACL_IDs);
        }

        /// <summary>
        /// 获取画面使用范围
        /// </summary>
        /// <param name="imageId"></param>
        /// <returns></returns>
        public DataSet GetPOPImageUseRange(int imageId)
        {
            return dal.GetPOPImageUseRange(imageId);
        }
		#endregion  成员方法
	}
}

