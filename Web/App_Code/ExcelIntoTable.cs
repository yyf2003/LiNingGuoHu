using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.OleDb;
/// <summary>
/// ExcelIntoTable 的摘要说明   从Excel读出数据 放入datatable
/// </summary>
public class ExcelIntoTable
{
    public   ExcelIntoTable()
    {
        //
        // TODO: 在此处添加构造函数逻辑
        //
    }

    public static DataTable ReturnTable(string Path)
    {
        string ConStr = "Provider=Microsoft.Jet.OLEDB.4.0;"+"Data Source="+ Path +";"+"Extended Properties=Excel 8.0;";

        OleDbConnection OleCon = new OleDbConnection(ConStr);
        try
        {
            OleCon.Open();
            OleDbDataAdapter OleCom = null;
            string ExcelStr = " select * from [sheet1$] ";

            OleCom = new OleDbDataAdapter(ExcelStr, OleCon);
            DataSet ds = new DataSet();

            OleCom.Fill(ds);

            return ds.Tables[0];

        }
        catch (Exception)
        {

            throw;
        }
        finally
        {
            if (OleCon.State == ConnectionState.Open)
            {
                OleCon.Close();
            }
        }
    }
}
