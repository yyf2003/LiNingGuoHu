<%@ Page language="c#" %>
<script runat="server">
    public int iMaxWidth = 800;
    public string sPhotoPath = ConfigurationManager.AppSettings["UploadDir"].ToString();
    public string sHostUrl = ConfigurationManager.AppSettings["HostName"].ToString();

    protected void Page_Load(object sender, EventArgs e)
    {
    }

    protected void returnNull()
    {
        string script = "<script language='javascript'>";
        script += "window.returnValue = null;window.close();";
        script += @"</";
        script += "script>";
        Response.Write(script);

    }
    public bool ThumbnailCallback()
    {
        return false;
    }

    protected void btnUpPhoto_Click(object sender, EventArgs e)
    {
        //System.IO.Stream memfile = null;
        System.IO.MemoryStream memStream = new System.IO.MemoryStream();
        System.Drawing.Image imgPhoto = null;
        try
        {
            memStream.Write(filePhoto.FileBytes, 0, filePhoto.FileBytes.Length);
            //memfile.Write(filePhoto.FileBytes, 0, filePhoto.FileBytes.Length);

            imgPhoto = System.Drawing.Image.FromStream((System.IO.Stream)memStream);
        }
        catch
        {
            imgPhoto = null;
        }

        if (null == imgPhoto)
        {
            returnNull();
            return;
        }

        filePhoto.Dispose();
        string fileName = Guid.NewGuid().ToString() + ".jpg";

        string retScript = "<script language=\"javascript\">";
        string sCaption = txtCaption.Text;
        if (sCaption.Length > 128)
            sCaption = sCaption.Substring(0, 128);

        retScript += "var oEditor = window.parent.InnerDialogLoaded();";

        sCaption = HttpUtility.HtmlEncode(sCaption);
        fileName = HttpUtility.HtmlEncode(fileName);
        sPhotoPath = HttpUtility.HtmlEncode(sPhotoPath);

        //if (imgPhoto.Width > iMaxWidth)
        //{
        //    System.Drawing.Image.GetThumbnailImageAbort abortCall = new System.Drawing.Image.GetThumbnailImageAbort(ThumbnailCallback);
        //    int iHeight = (int)((float)iMaxWidth / imgPhoto.Width * imgPhoto.Height);
        //    System.Drawing.Image smallPhoto = imgPhoto.GetThumbnailImage(iMaxWidth, iHeight, abortCall, new IntPtr());
        //    smallPhoto.Save(MapPath("./") + sPhotoPath + @"\" + fileName, System.Drawing.Imaging.ImageFormat.Jpeg);
        //    smallPhoto.Dispose();

        //    retScript += "<img src=\"./" + sPhotoPath + "/" + fileName + "\" width=\"" + iMaxWidth.ToString() + "px\" height=\"" + iHeight.ToString() + "px\" alt=\"" + sCaption + "\" /> ";
        //}
        //else
        //{
        //    imgPhoto.Save(MapPath("./") + sPhotoPath + @"\" + fileName, System.Drawing.Imaging.ImageFormat.Jpeg);
        //    retScript += "<img src=\"./" + sPhotoPath + "/" + fileName + "\" width=\"" + imgPhoto.Width.ToString() + "px\" height=\"" + imgPhoto.Height.ToString() + "px\" alt=\"" + sCaption + "\" /> ";
        //}

        // use for BBCODE EDITOR
        imgPhoto.Save(MapPath("~/") + sPhotoPath + @"\" + fileName, System.Drawing.Imaging.ImageFormat.Jpeg);

        //Response.Write("<script language=\"javascript\">" + "var oEditor = window.parent.InnerDialogLoaded();oEditor.FCK.InsertHtml( '" + + "' ) ;" + "</" + "script>");
        //Response.Write("<script language=\"javascript\">" + "alert(2);" + "</" + "script>");

        retScript += "oEditor.FCK.InsertHtml( '<img alt=\"" + sCaption + "\" src=\"" + sHostUrl + sPhotoPath + "/" + fileName + "\">' ) ;";
        retScript += "</" + "script>";
        
        imgPhoto.Dispose();


        Response.Write(retScript);
        retScript = "";
    }

</script>

<!doctype html public "-//W3C//DTD HTML 4.0 Transitional//EN" >
<html>
<head>
<meta HTTP-EQUIV="Expires" CONTENT="0" />
<meta content="noindex, nofollow" name="robots" />
<title>上传图片</title>
<script type="text/javascript" src="../../fckeditor.js"></script>
<style type="text/css">

body {
	margin: 0px 0px 0px 0px;padding: 0px 0px 0px 0px;background: #ffffff; width: 100%;overflow:hidden;border: 0;color:#444444;font-size:11px;
}
span
{
    display:block;width:80px;position:relative;float:left;
}
body,tr,td {
	color: #000000;font-family: Verdana, Arial, Helvetica, sans-serif;font-size: 10pt;
}

.Div {
   	left:10px;width:450px;top:10px;height:30px;display:block;position:relative;
}
.button
{
	background-color: #FFFFFF;	background-repeat: repeat-x;	padding: 0px 0.5em 0px;color:#444444;	font-size:11px;	vertical-align: middle; 	background-image: url(../../images/bg_btn.gif);line-height: 15px;	border: 1px solid #CCEAEE;
}

</style>


<script type="text/javascript" language="javascript">
function returnNull() {
	window.returnValue = null;
	window.close();
}

var oEditor = window.parent.InnerDialogLoaded();

function OnLoad()
{
	LoadSelected() ;

	// Show the "Ok" button.
	window.parent.SetOkButton( true ) ;
	window.parent.SetAutoSize( true ) ;
}

function InsertEditorHtml(htmlContent)
{
    alert(1);
//    if(htmlContent != null)
//        oEditor.FCK.InsertHtml( htmlContent ) ;
}

var eSelected = oEditor.FCKSelection.GetSelectedElement() ;

function LoadSelected()
{
	if ( !eSelected )
		return ;

	if ( eSelected.tagName == 'SPAN' && eSelected._fckplaceholder )
		document.getElementById('txtName').value = eSelected._fckplaceholder ;
	else
		eSelected == null ;
}


</script>		
</head>
<body onload="OnLoad()" scroll="no" style="OVERFLOW: hidden">

<form id="FORM1" encType="multipart/form-data" runat="server">
    <div>
        <div id="divCodeStyle" class="Div" >
            <span>标题</span>
            <span>
                <asp:TextBox ID="txtCaption" runat="server" />
            </span>
            <span style="width:30px;"></span>
            <span>
                <asp:Button ID="btnUpPhoto" CssClass="button" Text="上传" runat="server" OnClick="btnUpPhoto_Click" />
            </span>
            <span>
                <input id="btnCancel" class="button" type="button" onclick="returnNull();" title="取消" value="取消" />
            </span>
        </div>
        <div id="divCode" class="Div" >
            <span>图片</span>
            <span>
                <asp:FileUpload ID="filePhoto" runat="server" />
            </span>
        </div>
    </div>
</form>

</body>
</HTML>
