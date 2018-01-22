<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Edit.aspx.cs" Inherits="WebUI_Promotion_RackInfo_Edit" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../../../CSS/TableCss.css" rel="stylesheet" type="text/css" />
    <script src="../../../js/jquery-1.7.2.js" type="text/javascript"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
       <table class="table">
          <tr>
            <td style="width:120px;">故事包</td>
            <td style="width:200px; text-align:left;">
                <asp:DropDownList ID="ddlStoryBag" runat="server">
                </asp:DropDownList>
            </td>
            <td style="width:120px;">位置</td>
            <td style="text-align:left;">
                 <asp:DropDownList ID="ddlSeat" runat="server">
                 </asp:DropDownList>
            </td>
          </tr>
          <tr>
            <td>道具类型</td>
            <td style="text-align:left;">
               <asp:TextBox ID="txtRackType" runat="server" MaxLength="20"></asp:TextBox>
            </td>
            <td>道具名称</td>
            <td style="text-align:left;">
              <asp:TextBox ID="txtRackName" runat="server" MaxLength="20"></asp:TextBox>
            </td>
          </tr>
          <tr>
            <td>尺寸</td>
            <td style="text-align:left;">
               <asp:TextBox ID="txtSize" runat="server" MaxLength="20"></asp:TextBox>
            </td>
            <td>材质</td>
            <td style="text-align:left;">
               <asp:TextBox ID="txtTexture" runat="server" MaxLength="30"></asp:TextBox>
            </td>
          </tr>
          <tr>
            <td>规格</td>
            <td style="text-align:left;">
              <asp:TextBox ID="txtSpecification" runat="server" MaxLength="20"></asp:TextBox>
            </td>
            <td>单位</td>
            <td style="text-align:left;">
               <asp:TextBox ID="txtUnits" runat="server" MaxLength="10"></asp:TextBox>
            </td>
          </tr>
           <tr>
            <td>类型<br />（男子/女子、正向/反向）</td>
            <td  style="text-align:left;">
               <asp:TextBox ID="txtCategory" runat="server" MaxLength="20"></asp:TextBox>
            </td>
             <td>价格</td>
            <td style="text-align:left;">
               <asp:TextBox ID="txtPrice" runat="server" MaxLength="10"></asp:TextBox>
            </td>
          </tr>
       </table>
       <br />
       <br />
       <div style=" text-align:center;">
         <asp:Button ID="btnSubmit" CssClass="qr0" runat="server" Text="更 新" onclick="btnSubmit_Click" 
            OnClientClick="return check()"     />
          &nbsp;&nbsp;&nbsp;&nbsp; 
          <asp:Button ID="btnAddNew" CssClass="qr0" runat="server" Text="新 增" 
            OnClientClick="return check()" onclick="btnAddNew_Click"     />
          &nbsp;&nbsp;&nbsp;&nbsp; 
         <input type="button" value="返 回" class="qr0" onclick="javascript:window.history.go(-1)"/>           
       </div>
       <br />
       <br />
    </div>
    </form>
</body>
</html>
<script type="text/javascript">
    var isFloat = /^\d{1,}(\.{1}\d{1,}){0,1}$/;
    function check() {
        if ($("#ddlStoryBag").val() == "0") {
            alert("请选择故事包");
            return false;
        }
        if ($("#ddlSeat").val() == "0") {
            alert("请选择位置");
            return false;
        }
        if ($.trim($("#txtRackType").val()) == "") {
            alert("请填写道具类型");
            return false;
        }
        if ($.trim($("#txtRackName").val()) == "") {
            alert("请填写道具名称");
            return false;
        }
        if ($.trim($("#txtSize").val()) == "") {
            alert("请填写道具尺寸");
            return false;
        }
        var price = $.trim($("#txtPrice").val());
        if (price != "") {
            if (!isFloat.exec(price)) {
                alert("价格必须是数值");
                return false;
            }
        }
        return confirm("确定提交吗？");
    }
</script>