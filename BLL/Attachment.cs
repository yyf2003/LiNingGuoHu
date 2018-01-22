using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using LN.DAL;

namespace LN.BLL
{
    public class Attachment
    {
        private readonly LN.DAL.Attachment dal = new LN.DAL.Attachment();
        public int Add(LN.Model.Attachment model)
        {
            return dal.Add(model);
        }

        public bool Update(LN.Model.Attachment model)
        {
            return dal.Update(model);
        }

        public LN.Model.Attachment GetModel(int id)
        {
            return dal.GetModel(id);
        }

        public DataSet GetList(string whereStr)
        {
            return dal.GetList(whereStr);
        }

        public DataSet GetPageList(string where, int currPage, int pageSize)
        {
            return dal.GetPageList(where, currPage, pageSize);
        }

        public int PageCount(string where)
        {
            return dal.PageCount(where);
        }

        public string GetAttachList(string where,string onlyGetTilte=null)
        {
            DataSet ds = GetList(where);
            StringBuilder sb = new StringBuilder();
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    

                    if (onlyGetTilte != null)
                    {
                        sb.Append("<a style='float:left;margin-right:8px;' href='../../Handlers/OperateFile.ashx?id=" + dr["Id"].ToString() + "&type=download' rel='" + dr["Title"].ToString() + "'>" + dr["Title"].ToString() + "</a>");
                    }
                    else
                    {
                        string exten = dr["FilePath"].ToString().Substring(dr["FilePath"].ToString().LastIndexOf('.') + 1);
                        string src = GetSrcString(exten, dr["FileType"].ToString());
                        if (src == "" && dr["SmallImgUrl"].ToString() == "")
                        {
                            src = "/images/UpLoadFileType/Others.png";
                        }
                        if (src == "")//图片
                        {

                            src = dr["SmallImgUrl"].ToString().Replace("./", "../../");
                            src = dr["SmallImgUrl"].ToString().Replace("~/", "../../");
                            string path = dr["FilePath"].ToString().Replace("./", "../../");
                            path = dr["FilePath"].ToString().Replace("~/", "../../");
                            sb.Append("<div style='width:120px;float:left;margin-right:8px;'><a href='" + path + "' class='showimg' data-fancybox-group='imgs' style='border:0px;'><img style='border:0px;' src='" + src + "' width='120px' height='95px' /></a><br/>");
                        }
                        else//非图片
                        {
                            src = src.Replace("./", "../../");
                            src = src.Replace("~/", "../../");
                            sb.Append("<div style='width:120px;float:left;margin-right:8px;'><img src='" + src + "' width='120px' height='95px' /><br/>");
                        }

                        sb.Append("<table width='100%' cellpadding='0' cellspacing='0'><tr><td style='text-align:left;width:50px; height:30px;font-size:12px;border:0px;'><a href='../../Handlers/OperateFile.ashx?id=" + dr["Id"].ToString() + "&type=download' rel='" + dr["Title"].ToString() + "' title='" + dr["Title"].ToString() + "'>" + (dr["Title"].ToString().Length > 15 ? (dr["Title"].ToString().Substring(0, 15) + "...") : dr["Title"].ToString()) + "</a></td><td style='width:20px;;color:red;cursor:pointer;text-align:right;padding-right:12px;border:0px;'></td><td style='border:0px;'></td></tr></table>");
                        sb.Append("</div>");
                    }
                }
            }
            return sb.ToString();
        }

        static string GetSrcString(string type, string fileType)
        {
            string src = "";
            switch (type)
            {
                case "xls":
                case "xlsx":
                    src = "/images/UpLoadFileType/EXCEL.png";
                    break;
                case "docx":
                case "doc":
                    src = "/images/UpLoadFileType/WORD.png";
                    break;
                case "pptx":
                case "pptm":
                case "ppsx":
                case "ppsm":
                case "pps":
                case "ppt":
                    src = "/images/UpLoadFileType/PPT.png";
                    break;
                case "rar":
                case "zip":
                    src = "/images/UpLoadFileType/yasuo.png";
                    break;
            }

            return src;
        }
    }
}
