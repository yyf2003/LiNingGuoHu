using System;
using System.Data;
using System.Collections.Generic;
using LN.Model;
using System.Collections;
namespace LN.BLL
{
	/// <summary>
	/// 业务逻辑类DSRExamData 的摘要说明。
	/// </summary>
	public class DSRExamData
	{
		private readonly LN.DAL.DSRExamData dal=new LN.DAL.DSRExamData();
		public DSRExamData()
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
		public bool Exists(int ID)
		{
			return dal.Exists(ID);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int  Add(LN.Model.DSRExamData model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public void Update(LN.Model.DSRExamData model)
		{
			dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(int ID)
		{
			
			dal.Delete(ID);
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public LN.Model.DSRExamData GetModel(int ID)
		{
			
			return dal.GetModel(ID);
		}

        ///// <summary>
        ///// 得到一个对象实体，从缓存中。
        ///// </summary>
        //public LN.Model.DSRExamData GetModelByCache(int ID)
        //{
			
        //    string CacheKey = "DSRExamDataModel-" + ID;
        //    object objModel = LTP.Common.DataCache.GetCache(CacheKey);
        //    if (objModel == null)
        //    {
        //        try
        //        {
        //            objModel = dal.GetModel(ID);
        //            if (objModel != null)
        //            {
        //                int ModelCache = LTP.Common.ConfigHelper.GetConfigInt("ModelCache");
        //                LTP.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
        //            }
        //        }
        //        catch{}
        //    }
        //    return (LN.Model.DSRExamData)objModel;
        //}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			return dal.GetList(strWhere);
		}
        /// <summary>
        /// 根据条件得到 相应区域 所检查店铺的数据 包括 供应商安装 自主安装 总数量的统计 和各种检查项目的（大分类）的分数
         /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataSet EveryAreaCheckShopCount(string strWhere)
        {
            DataSet ds = dal.EveryAreaCheckShopCount(strWhere);
            DataTable resultdt = ds.Tables[0];//得到每个省区检查店铺的数量
            DataTable dtcount = ds.Tables[1];
            DataTable Typecountdt = ds.Tables[2];
            DataTable Areadt = ds.Tables[3];
            DataTable Typedt = ds.Tables[4];

            DataTable stalldt = ds.Tables[5];//得到供应商支持安装和不支持安装的 检查项目（大分类）的分数
            DataTable allstalldt = ds.Tables[6];//所有店铺 检查项目的分数

            DataRow dr = resultdt.NewRow();
            dr[0] = "总计";
            dr[1] = dtcount.Rows[0][0].ToString();
            dr[2] = dtcount.Rows[0][1].ToString();
            dr[3] = dtcount.Rows[0][2].ToString();

            resultdt.Rows.Add(dr);
            //--------------------------------------
            DataTable dt = new DataTable();

            dt.Columns.Add("省区");
            for (int i = 0; i < Typedt.Rows.Count; i++)
            {
                dt.Columns.Add(Typedt.Rows[i][0].ToString());
            }
            DataView dv = null;
            for (int i = 0; i < Areadt.Rows.Count; i++)
            {
                DataRow typedr = dt.NewRow();
                typedr[0] = Areadt.Rows[i][0].ToString();
                dv = new DataView(Typecountdt);



                for (int m = 0; m < Typedt.Rows.Count; m++)
                {
                    dv.RowFilter = " areaname='" + Areadt.Rows[i][0].ToString() + "' and DsrCheckType='" + Typedt.Rows[m][0].ToString() + "' ";
                    DataTable tempdt = dv.ToTable();
                    if (tempdt.Rows.Count > 0)
                        typedr[Typedt.Rows[m][0].ToString()] = tempdt.Rows[0][3].ToString();
                    else
                        typedr[Typedt.Rows[m][0].ToString()] = "0";
                }

                dt.Rows.Add(typedr);
            }
            DataTable rstalldt = new DataTable();
            rstalldt.Columns.Add("省区");
            for (int i = 0; i < Typedt.Rows.Count; i++)
            {
                rstalldt.Columns.Add(Typedt.Rows[i][0].ToString());
            }
            
            string [] strlist={"总体区域","安装区域","非安装区域","1","0"};
            for (int i = 0; i <3; i++)
            {
                DataRow stalldr = rstalldt.NewRow();
                stalldr[0] = strlist[i];
                dv = new DataView(stalldt);
                for (int m = 0; m < Typedt.Rows.Count; m++)
                {
                    if (i == 0)
                    {
                        stalldr[Typedt.Rows[m][0].ToString()] = allstalldt.Rows[m][1].ToString();
                    }
                    if (i > 0)
                    {
                        dv.RowFilter = " Boolinstall='" + strlist[i + 2] + "' and DsrCheckType='" + Typedt.Rows[m][0].ToString() + "' ";
                        DataTable tempdt = dv.ToTable();
                        if (tempdt.Rows.Count > 0)
                            stalldr[Typedt.Rows[m][0].ToString()] = tempdt.Rows[0][1].ToString();
                        else
                            stalldr[Typedt.Rows[m][0].ToString()] = "0";
                    }
                }

                rstalldt.Rows.Add(stalldr);
            }

            DataSet resultds = new DataSet();
            ds.Tables.Clear();
            resultds.Tables.Add(resultdt);
            resultds.Tables.Add(dt);
            resultds.Tables.Add(rstalldt);
            return resultds;
        }
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<LN.Model.DSRExamData> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			List<LN.Model.DSRExamData> modelList = new List<LN.Model.DSRExamData>();
			int rowsCount = ds.Tables[0].Rows.Count;
			if (rowsCount > 0)
			{
				LN.Model.DSRExamData model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new LN.Model.DSRExamData();
					if(ds.Tables[0].Rows[n]["ID"].ToString()!="")
					{
						model.ID=int.Parse(ds.Tables[0].Rows[n]["ID"].ToString());
					}
					if(ds.Tables[0].Rows[n]["POPID"].ToString()!="")
					{
						model.POPID=ds.Tables[0].Rows[n]["POPID"].ToString();
					}
					if(ds.Tables[0].Rows[n]["CheckUserID"].ToString()!="")
					{
						model.CheckUserID=int.Parse(ds.Tables[0].Rows[n]["CheckUserID"].ToString());
					}
					model.AreaID=ds.Tables[0].Rows[n]["AreaID"].ToString();
					if(ds.Tables[0].Rows[n]["ProvinceID"].ToString()!="")
					{
						model.ProvinceID=int.Parse(ds.Tables[0].Rows[n]["ProvinceID"].ToString());
					}
					if(ds.Tables[0].Rows[n]["CityID"].ToString()!="")
					{
						model.CityID=int.Parse(ds.Tables[0].Rows[n]["CityID"].ToString());
					}
					if(ds.Tables[0].Rows[n]["ShopID"].ToString()!="")
					{
						model.ShopID=int.Parse(ds.Tables[0].Rows[n]["ShopID"].ToString());
					}
					if(ds.Tables[0].Rows[n]["CheckDate"].ToString()!="")
					{
						model.CheckDate=DateTime.Parse(ds.Tables[0].Rows[n]["CheckDate"].ToString());
					}
					if(ds.Tables[0].Rows[n]["SysDateTime"].ToString()!="")
					{
						model.SysDateTime=DateTime.Parse(ds.Tables[0].Rows[n]["SysDateTime"].ToString());
					}
					if(ds.Tables[0].Rows[n]["YesCount"].ToString()!="")
					{
						model.YesCount=int.Parse(ds.Tables[0].Rows[n]["YesCount"].ToString());
					}
					if(ds.Tables[0].Rows[n]["NoCount"].ToString()!="")
					{
						model.NoCount=int.Parse(ds.Tables[0].Rows[n]["NoCount"].ToString());
					}
					model.DataID=ds.Tables[0].Rows[n]["DataID"].ToString();
					modelList.Add(model);
				}
			}
			return modelList;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetAllList()
		{
			return GetList("");
		}
             /// <summary>
        /// 存检查结果
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public bool InsertResult(List<string> list)
        {
            return dal.InsertResult(list);
        }
            /// <summary>
        /// 得到DSR分析的结果
        /// </summary>
        /// <param name="ht"></param>
        /// <returns></returns>
        public DataSet GetResultlist(Hashtable ht)
        {
            return dal.GetResultlist(ht);
        }
		/// <summary>
		/// 获得数据列表
		/// </summary>
		//public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		//{
			//return dal.GetList(PageSize,PageIndex,strWhere);
		//}

		#endregion  成员方法
	}
}

