<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ModifyAffiche.aspx.cs" Inherits="WebUI_Affiche_ModifyAffiche" %>

<%@ Register Assembly="FredCK.FCKeditorV2" Namespace="FredCK.FCKeditorV2" TagPrefix="FCKeditorV2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>��ӹ���</title>
    <link rel="stylesheet" media="all" type="text/css" href="../../css/TableCss.css" />
    <link rel="stylesheet" media="all" type="text/css" href="../../css/examples.css" />
    <!-- Can't miss  begin -->

    <script type="text/javascript" src="../../js/jquery-1.3.2.min.js"></script>

    <script type="text/javascript" src="../../js/jquery.corner.js"></script>

    <script type="text/javascript" src="../../js/jquery-impromptu.2.5.min.js"></script>

    <script type="text/javascript" src="../../js/common.js"></script>

    <!--  end-->

    <script> 
 

 function Add()
   {
    var typedd =$("#Text1").val();
   if(typedd=="")
   {
    $.prompt("������������ƣ�",{callback:gettypenamefocus});
   return false;
   } 
    $.get("ashx/AddAfficheTypeForAdd.ashx",{TypeName:typedd},
			function(data){
				if(data.length > 0){
				$("#AddType").hide();
				document.getElementById ("Text1").value="";
					$("#type").html(data);//��ʾ��������� 
				}
		});
   }
   function gettypenamefocus()
  {
   $("#Text1").focus();
  }  
    </script>

    <script language="javascript" type="text/javascript">
    	//�ϴ�����������
        var fileCount = 5;
    	//������
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
    		  $.prompt("���֧���ϴ�5������!");
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
     $.prompt("���������",{callback:getaffichetitle});
     return false
  }   
    var content = FCKeditorAPI.GetInstance("FCKeditor1").GetXHTML(true);
	if(content.length < 1){
		   $.prompt("�����빫������",{callback:getaffichemain});
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
                    ������
                </td>
            </tr>
        </table>
        <table cellpadding="0" cellspacing="0" border="0" class="table" style="margin-top: 3px;"
            width="900px">
            <tr>
                <td width="100px">
                    ����
                </td>
                <td>
                    <asp:TextBox ID="txtTypeName" runat="server" Width="464px"  CssClass ="txtwith"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td width="100px">
                    ���
                </td>
                <td align="left">
                    <asp:DropDownList ID="ddltype" runat="server" CssClass ="DDlstyle">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td width="100px">
                    ����
                </td>
                <td>
                    <FCKeditorV2:FCKeditor ID="FCKeditor1" runat="server" ToolbarSet="Basic" Height="412px">
                    </FCKeditorV2:FCKeditor>
                </td>
            </tr>
            <tr>
                <td width="100px">
                    �ϴ�����</td>
                <td>
                    <div id="divFile" style="float: left; padding-left: 12px; width: 280px;">
                        <asp:FileUpload ID="FileUpload1" runat="server" Width="250px" />
                    </div>
                    <div id="Div2" style="float: left; padding-left: 12px; color: Red;">
                        <input id="btnShowFile" name="btnShowFile" type="button" value="���Ӹ���" onclick="AddFile()" class ="qr0" />&nbsp;С��ʾ���ϴ��ļ���С�Ƽ�2M���ڣ������ʹ��ѹ���ļ�
                    </div>
                </td>
            </tr>
            <tr>
                <td colspan="2" align="center">
                    <asp:Button ID="Button1" runat="server" Text="�ύ�޸�" CssClass="qr0" OnClientClick="return CheckPost();"
                        OnClick="Button1_Click" />&nbsp;&nbsp;
                    <input id="Button2" type="button" value="����" class="qr0"  onclick ="javascript:if(window.history.length==0) window.close();else window.history.back();"  />
                </td>
            </tr>
        </table>
    </form>
</body>
</html>
