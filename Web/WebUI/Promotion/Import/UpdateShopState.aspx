<%@ Page Language="C#" AutoEventWireup="true" CodeFile="UpdateShopState.aspx.cs" Inherits="WebUI_Promotion_Import_UpdateShopState" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../../../CSS/TableCss.css" rel="stylesheet" type="text/css" />
    <script src="../../../js/jquery-1.7.2.js" type="text/javascript"></script>
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
        }

        
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <div style="font-size: 14px; font-weight: bold; text-align: left; padding-left: 20px;
            color: #c86000;">
            更新基础店铺</div>
    </div>
    <br />
     <table class="table">
        <tr>
            <td style="width: 150px; text-align: right">
                选择上传文件：
            </td>
            <td style="width: 250px;">
                <asp:FileUpload ID="FileUpload1" runat="server" />
            </td>
            <td style="text-align: left;">
               
            </td>
        </tr>
        <tr>
          <td  style="text-align: right">
          是否包含道具信息：
          </td>
          <td style="width: 250px;">
               
              <asp:RadioButtonList ID="rblIsRack" runat="server" 
                  RepeatDirection="Horizontal" RepeatLayout="Flow">
                <asp:ListItem Value="0" Selected="True">否 </asp:ListItem>
                <asp:ListItem Value="1">是 </asp:ListItem>
              </asp:RadioButtonList>
               
          </td>
          <td>
             <div id="showButton" runat="server">
                    <asp:Button ID="Button_AddProp" runat="server" Text=" 导 入 " CssClass="qr0" 
                        OnClientClick="return checkFile()" onclick="Button_AddProp_Click" />
                    
                    &nbsp;&nbsp;<asp:LinkButton ID="lb_DownLoadPropTemplate" runat="server" OnClick="lb_DownLoadPropTemplate_Click">下载模板</asp:LinkButton>
                </div>
                <div id="showWaiting" runat="server" style="color: Red; display: none;">
                    <img src='../../../images/loading.gif' />正在导入，请稍等...
                </div>
          </td>
        </tr>
    </table>
    <div id="uploadMsg" runat="server" style="text-align: left; display:none ; height: 140px;
        line-height: 22px; padding-left: 20px; width: 100%;">
        <div>
            <asp:Label ID="labuploadMsg" runat="server" Text="" Style="font-size: 15px; color: Red;"></asp:Label>
        </div>
        <div>
            总数据：<asp:Label ID="labTotal" runat="server" Text=""></asp:Label>
            条<br />
            
            成功：<asp:Label ID="labSuccessNum" runat="server" Text=""></asp:Label>
            条<br />
            新增：<asp:Label ID="labNewNum" runat="server" Text=""></asp:Label>
            条<br />
            重复：<asp:Label ID="labRepeatNum" runat="server" Text=""></asp:Label>
            条<br />
            失败：<asp:Label ID="labFailNum" runat="server" Text=""></asp:Label>
            条<br />
        </div>
    </div>
    
    <div id="errorMsg" runat="server" style="display:none ; line-height: 24px; padding-left: 20px;">
        <span style="color: Red;">错误信息：</span>
        <br />
        <asp:Label ID="labErrorMsg" runat="server" Text=""></asp:Label>
    </div>
    </form>
</body>
</html>
