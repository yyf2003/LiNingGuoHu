using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Collections.Generic;

public partial class WebUI_ShopPOP_POPSeatEdit : System.Web.UI.Page
{
    LN.BLL.POPSeat bll = new LN.BLL.POPSeat();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            if (Request.QueryString["id"] != null)
            {
                string seatid = Request.QueryString["id"].ToString();
                bll.Delete(int.Parse(seatid));
                Response.Write("<script>alert('删除完毕；');</script>");
            }
            bind();
        }

    }
    protected void btn_add_Click(object sender, EventArgs e)
    {

        LN.Model.POPSeat model = new LN.Model.POPSeat();
        model.seat = txt_seat.Text.ToString().Trim();
        bll.Add(model);

        txt_seat.Text = "";
        hf_seatid.Value = "";
        bind();
    }
    private void bind()
    {
        IList<LN.Model.POPSeat> modellist = bll.GetList("");
        this.Repeater1.DataSource = modellist;
        Repeater1.DataBind();
    }
    protected void btn_update_Click(object sender, EventArgs e)
    {

        LN.Model.POPSeat model = new LN.Model.POPSeat();
        model.seat = txt_seat.Text.ToString().Trim();
        model.SeatID = int.Parse(hf_seatid.Value);
        bll.Update(model);
        txt_seat.Text = "";
        hf_seatid.Value = "";
        bind();
    }
}
