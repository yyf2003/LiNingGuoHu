<%@ Page Language="C#" AutoEventWireup="true" CodeFile="UpdatePOP.aspx.cs" Inherits="WebUI_Shopmanage_UpdatePOP" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../../CSS/TableCss.css" rel="stylesheet" type="text/css" />
   
    <script src="../../js/jquery-1.7.2.js" type="text/javascript"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div style="font-size: 14px; font-weight: bold; text-align: left; padding-left: 20px;
        color: #c86000;">
        更新POP信息</div>
    <br />
    <div>
        <table class="table" style="margin-top: 20px; margin-left: 5%">
            <tr>
                <td style="width: 15%; text-align: left">
                    请选择文件
                </td>
                <td>
                    <asp:FileUpload ID="FileUpload1" runat="server" />
                </td>
            </tr>
            <tr>
                <td style="width: 15%; text-align: left">
                    
                </td>
                <td>
                <div id="showButton" runat="server">
                  <asp:Button ID="btnUpLoad" runat="server" Text="上 传" CssClass="qr0" OnClientClick="return checkFile()"
                        onclick="btnUpLoad_Click" />
                &nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Label ID="Label1" runat="server" Text="" ForeColor="Red"></asp:Label>
                </div>
                <div id="showWaiting" runat="server" style="color: Red; display: none;">
                    <img src='../../images/loading.gif' />正在导入，请稍等...
                </div>
                    
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
<script type="text/javascript">
    function checkFile() {

        var file = $("#FileUpload1").val();
        
        if (file == "") {
            alert("请选择导入的文件!");
            return false;
        }
        file = file.substring(file.lastIndexOf('.') + 1);
        if (file != "xls" && file != "xlsx") {
            alert("只能导入Excel文件");
            document.getElementById("<%=form1.ClientID %>").reset();
            return false;
        }
        $("#showButton").css({ display: "none" });
        $("#showWaiting").css({ display: "" });
        return true;
    }

        
  </script>
