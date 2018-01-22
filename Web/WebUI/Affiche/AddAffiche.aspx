<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AddAffiche.aspx.cs" Inherits="WebUI_Affiche_AddAffiche" %>

<%@ Register Assembly="FredCK.FCKeditorV2" Namespace="FredCK.FCKeditorV2" TagPrefix="FCKeditorV2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>添加公告</title>
    <link rel="stylesheet" media="all" type="text/css" href="../../css/TableCss.css" />
    <link rel="stylesheet" media="all" type="text/css" href="../../css/examples.css" />
    <!-- Can't miss  begin -->

    <script type="text/javascript" src="../../js/jquery-1.3.2.min.js"></script>

    <script type="text/javascript" src="../../js/jquery.corner.js"></script>

    <script type="text/javascript" src="../../js/jquery-impromptu.2.5.min.js"></script>

    <script type="text/javascript" src="../../js/common.js"></script>

    <!--  end-->

    <script> 
  $(function(){
    $.get("ashx/LoadAfficheTypeData.ashx",{index:0},
			function(data){
				if(data.length > 0){
					$("#type").html(data);//显示服务器结果 
				}
		});
})


 function Add()
   {
    var typedd =$("#Text1").val();
   if(typedd=="")
   {
    $.prompt("请输入分类名称！",{callback:gettypenamefocus});
   return false;
   } 
    $.get("ashx/AddAfficheTypeForAdd.ashx",{TypeName:typedd},
			function(data){
				if(data.length > 0){
				$("#AddType").hide();
				document.getElementById ("Text1").value="";
					$("#type").html(data);//显示服务器结果 
				}
		});
   }
   function gettypenamefocus()
  {
   $("#Text1").focus();
  }  
    </script>

    <script language="javascript" type="text/javascript">
    	//上传附件的总数
        var fileCount = 5;
    	//计数器
    	var fileNum = 1;
    	function AddFile()
    	{
    		if(fileNum < fileCount)
    		{
	    		var strFile = '<input id="SHWuJian" name="SHWuJian" type="file" style="width:250px" />';
	    		document.getElementById("divFile").insertAdjacentHTML("beforeEnd",strFile);
	    		fileNum ++;
    		}
    		else
    		{
    		  $.prompt("最多支持上传5个附件!");
    		}
    	}  

   function gettitlefocus()
   {
    $("#txtAfficeTitle").focus(); 
   } 
   
   function NoPost()
   {
     document.getElementById ("txtTypeName").value="";
     FCKeditorAPI.GetInstance("FCKeditor1").SetHTML("");
   } 
   function CheckPost()
  {
    var title =$("#txtTypeName").val();
   if(title=="")
  {
     $.prompt("请输入标题",{callback:getaffichetitle});
     return false
  }   
    var content = FCKeditorAPI.GetInstance("FCKeditor1").GetXHTML(true);
	if(content.length < 1){
		   $.prompt("请输入公告内容",{callback:getaffichemain});
		return false;
	}
  }  
  
   function getaffichetitle()
  { 
    $("#txtTypeName").focus();
  } 
  
   function getaffichemain()
  { 
    $("#FCKeditor1").focus();
  } 
    </script>

</head>
<body>
    <form id="form1" runat="server">
        <table cellpadding="0" cellspacing="0" border="0" class="table">
            <tr>
                <td align="center">
                    发表公告
                </td>
            </tr>
        </table>
        <table cellpadding="0" cellspacing="0" border="0" class="table" style="margin-top: 3px;"
            width="900px">
            <tr>
                <td width="100px">
                    标题
                </td>
                <td>
                    <asp:TextBox ID="txtTypeName" runat="server" Width="464px"  CssClass ="txtwith"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td width="100px">
                    类别
                </td>
                <td align="left">
                    <div id="type" style="float: left;">
                    </div>
                    <div style="float: left; padding-top: 2px; padding-left: 12px;">
                        <a href='javascript:' onclick="document.getElementById('AddType').style.display='block'"
                            style="text-decoration: none;">新增分类</a></div>
                    <div style="float: left; display: none; padding-left: 12px;" id="AddType">
                        <input id="Text1" type="text" />
                        <input id="Button4" type="button" value="新增" onclick="return Add();" style="width: 60px;"
                            class="qr0" />&nbsp;&nbsp;<a href='javascript:' onclick="$('#AddType').hide();" style="text-decoration: none;">取消</a>
                    </div>
                </td>
            </tr>
            <tr>
                <td width="100px">
                    内容
                </td>
                <td>
                    <FCKeditorV2:FCKeditor ID="FCKeditor1" runat="server" ToolbarSet="Basic" Height="412px">
                    </FCKeditorV2:FCKeditor>
                </td>
            </tr>
            <tr>
                <td width="100px">
                    上传附件</td>
                <td>
                    <div id="divFile" style="float: left; padding-left: 12px; width: 280px;">
                        <asp:FileUpload ID="FileUpload1" runat="server" Width="250px" />
                    </div>
                    <div id="Div2" style="float: left; padding-left: 12px; color: Red;">
                        <input id="btnShowFile" name="btnShowFile" type="button" value="增加附件" onclick="AddFile()"  class ="qr0" />&nbsp;小提示：上传文件大小推荐2M以内，建议多使用压缩文件
                    </div>
                </td>
            </tr>
            <tr>
                <td colspan="2" align="center">
                    <asp:Button ID="Button1" runat="server" Text="发表公告" CssClass="qr0" OnClientClick="return CheckPost();" OnClick="Button1_Click" />&nbsp;&nbsp;
                    <input id="Button2" type="button" value="取消发表" class="qr0" onclick="NoPost();" />
                </td>
            </tr>
        </table>
    </form>
</body>
</html>
