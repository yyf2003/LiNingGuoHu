using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Text;
using System.Xml;
using System.IO;
using System.Collections;
/// <summary>
/// XmlIntoTable 的摘要说明  从XML 中读出数据 放入datatable
/// </summary>
public class XmlIntoTable
{
    public XmlIntoTable()
    {
        //
        // TODO: 在此处添加构造函数逻辑
        //
    }
    DataTable dt = new DataTable();
    public  DataTable    ReadFromXML(string path)
    {

        FileStream fs = null;
       XmlDocument xmldoc = null;
       try
       {
            DataTable returndt = new DataTable();
           fs = new FileStream(path, FileMode.Open);
           xmldoc = new XmlDocument();
           xmldoc.Load(fs);
           Hashtable hstable = new Hashtable();
           if (xmldoc.HasChildNodes)
           {
               XmlNodeList nodelist = xmldoc.ChildNodes;

                GetXml(nodelist);
           }

           return dt;
       }
       catch (Exception)
       {

           throw;

       }
       finally
       {
           fs.Close();
       }
     
    }
   // Hashtable dt = new Hashtable();
    private  void   GetXml(XmlNodeList nodelist)
    {

        foreach (XmlNode xn in nodelist)
        {
            // 
            if (xn.NodeType == XmlNodeType.Element)
            {
                if (xn.HasChildNodes)
                {
                    if (xn.ChildNodes[0].NodeType == XmlNodeType.Text)
                    {
                        if (!dt.Columns.Contains(xn.Name))
                        {
                            dt.Columns.Add(xn.Name);
                        }
                    }
                    else
                    {
                       GetXml(xn.ChildNodes);
                    }
                    
                }
            }
            if (xn.NodeType == XmlNodeType.Text)
            {

            }
        }
        // hstable.Add(xn.Name, xn.Value);

    }

    
}
