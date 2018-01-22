<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Edit.aspx.cs" Inherits="WebUI_Promotion_Shops_Edit" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../../../CSS/TableCss.css" rel="stylesheet" type="text/css" />
    <script src="../../../js/jquery-1.7.2.js" type="text/javascript"></script>
    <script type="text/javascript">
        function Finish() {
            alert("提交成功！");
            window.parent.Update();
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div style="font-size: 14px; font-weight: bold; text-align: left; padding-left: 20px;
        color: #c86000;">
        &gt;&gt;
        <asp:Label ID="labTitle" runat="server" Text="店铺信息"></asp:Label>
    </div>
    <table class="table" style="margin-top: 10px;">
        <tr>
            <td style="width: 100px;">
                店铺编号：
            </td>
            <td style="width: 250px; text-align: left; padding-left: 5px;">
                <asp:TextBox ID="txtShopNo" runat="server" MaxLength="10"></asp:TextBox>
                <span style=" color:Red;">*</span>
            </td>
            <td style="width: 100px;">
                店铺名称：
            </td>
            <td style="text-align: left; padding-left: 5px;">
                <asp:TextBox ID="txtShopName" runat="server" MaxLength="50" Style="width: 300px;"></asp:TextBox>
                <span style=" color:Red;">*</span>
            </td>
        </tr>
        <tr>
            <td>
                店铺简称：
            </td>
            <td style="text-align: left; padding-left: 5px;">
                <asp:TextBox ID="txtShopsamplename" runat="server" MaxLength="50" Style="width: 200px;"></asp:TextBox>
            </td>
            <td>
                店铺营业地址：
            </td>
            <td style="text-align: left; padding-left: 5px;">
                <asp:TextBox ID="txtShopAddress" runat="server" MaxLength="50" Style="width: 300px;"></asp:TextBox>
                <span style=" color:Red;">*</span>
            </td>
        </tr>
        <tr>
            <td>
                收货地址：
            </td>
            <td colspan="3" style="text-align: left; padding-left: 5px;">
                <asp:TextBox ID="txtPostAddress" runat="server" MaxLength="50" Style="width: 300px;"></asp:TextBox>
            </td>
            
        </tr>
        <tr>
            <td>
                联系人：
            </td>
            <td style="text-align: left; padding-left: 5px;">
                <asp:TextBox ID="txtLinkMan" runat="server" MaxLength="20"></asp:TextBox>
                <span style=" color:Red;">*</span>
            </td>
            <td>
                联系人电话：
            </td>
            <td style="text-align: left; padding-left: 5px;">
                <asp:TextBox ID="txtLinkPhone" runat="server" MaxLength="30"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                上级客户编码：
            </td>
            <td style="text-align: left; padding-left: 5px;">
                <asp:TextBox ID="txtDealerID" runat="server" MaxLength="20"></asp:TextBox>
            </td>
            <td>
                上级客户名称：
            </td>
            <td style="text-align: left; padding-left: 5px;">
                <asp:TextBox ID="txtDealerName" runat="server" MaxLength="50" Style="width: 300px;"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                直属客户编码：
            </td>
            <td style="text-align: left; padding-left: 5px;">
               <asp:TextBox ID="txtFXID" runat="server" MaxLength="20"></asp:TextBox>
            </td>
            <td>
                直属客户名称：
            </td>
            <td style="text-align: left; padding-left: 5px;">
               <asp:TextBox ID="txtFXName" runat="server" MaxLength="50" Style="width: 300px;"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                直属客户身份：
            </td>
            <td style="text-align: left; padding-left: 5px;">
                <asp:DropDownList ID="ddlCustomerCard" runat="server">
                    <asp:ListItem Value="0">--请选择--</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td>
                店铺状态：
            </td>
            <td style="text-align: left; padding-left: 5px;">
                <asp:DropDownList ID="ddlShopState" runat="server">
                    <asp:ListItem Value="-1">--请选择--</asp:ListItem>
                </asp:DropDownList>
                <span style=" color:Red;">*</span>
            </td>
        </tr>
        <tr>
            <td>
                大区：
            </td>
            <td style="text-align: left; padding-left: 5px;">
                <asp:DropDownList ID="ddlBigArea" runat="server">
                    <asp:ListItem Value="0">--请选择--</asp:ListItem>
                </asp:DropDownList>
                <span style=" color:Red;">*</span>
            </td>
            <td>
                省区：
            </td>
            <td style="text-align: left; padding-left: 5px;">
                <asp:DropDownList ID="ddlArea" runat="server">
                    <asp:ListItem Value="0">--请选择--</asp:ListItem>
                </asp:DropDownList>
                <span style=" color:Red;">*</span>
            </td>
        </tr>
        <tr>
            <td>
                省份：
            </td>
            <td style="text-align: left; padding-left: 5px;">
                <asp:DropDownList ID="ddlProvince" runat="server" 
                    onselectedindexchanged="ddlProvince_SelectedIndexChanged" AutoPostBack="true">
                    <asp:ListItem Value="0">--请选择--</asp:ListItem>
                </asp:DropDownList>
                <span style=" color:Red;">*</span>
            </td>
            <td>
                城市：
            </td>
            <td style="text-align: left; padding-left: 5px;">
                <asp:DropDownList ID="ddlCity" runat="server">
                    <asp:ListItem Value="0">--请选择--</asp:ListItem>
                </asp:DropDownList>
                <span style=" color:Red;">*</span>
            </td>
        </tr>
        <tr>
            <td>
                城市级别：
            </td>
            <td style="text-align: left; padding-left: 5px;">
                <asp:DropDownList ID="ddlTCL" runat="server">
                    <asp:ListItem Value="0">--请选择--</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td>
                区县级城市级别：
            </td>
            <td style="text-align: left; padding-left: 5px;">
                <asp:DropDownList ID="ddlACL" runat="server">
                    <asp:ListItem Value="0">--请选择--</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td>
                店铺零售属性：
            </td>
            <td style="text-align: left; padding-left: 5px;">
                <asp:DropDownList ID="ddlSaleType" runat="server">
                    <asp:ListItem Value="0">--请选择--</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td>
                店铺类型：
            </td>
            <td style="text-align: left; padding-left: 5px;">
                <asp:DropDownList ID="ddlShopType" runat="server">
                    <asp:ListItem Value="0">--请选择--</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td>
                店铺级别：
            </td>
            <td style="text-align: left; padding-left: 5px;">
                <asp:DropDownList ID="ddlShopLevel" runat="server">
                    <asp:ListItem Value="0">--请选择--</asp:ListItem>
                </asp:DropDownList>
                <span style=" color:Red;">*</span>
            </td>
            <td>
                店铺形象：
            </td>
            <td style="text-align: left; padding-left: 5px;">
                <asp:DropDownList ID="ddlShopImage" runat="server">
                    <asp:ListItem Value="0">--请选择--</asp:ListItem>
                </asp:DropDownList>
                <span style=" color:Red;">*</span>
            </td>
        </tr>
        <tr>
            <td>
                店铺产权关系：
            </td>
            <td style="text-align: left; padding-left: 5px;">
                <asp:DropDownList ID="ddlShopOwnerShip" runat="server">
                    <asp:ListItem Value="0">--请选择--</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td>
              店铺系列:
            </td>
            <td style="text-align: left; padding-left: 5px;">
              <asp:TextBox ID="txtShopCategory" runat="server" MaxLength="30"></asp:TextBox>
            </td>
        </tr>
    </table>
    <div style="text-align: center; margin-top: 10px; margin-bottom: 20px;">
        <asp:Button ID="btnSumbitEdit" runat="server" CssClass="qr0" Text="提交修改" OnClick="btnSumbitEdit_Click" OnClientClick="return Check();"/>
    </div>
    </form>
</body>
</html>

<script type="text/javascript">
    function Check() { 
        var posId =$.trim($("#txtShopNo").val());
        var shopName = $.trim($("#txtShopName").val());
        var shopAddress = $.trim($("#txtShopAddress").val());
        var linkMan = $.trim($("#txtLinkMan").val());
        var shopState = $("#ddlShopState").val();
        var bigArea = $("#ddlBigArea").val();
        var areaId = $("#ddlArea").val();
        var provinceId = $("#ddlProvince").val();
        var cityId =$("#ddlCity").val();
        var shopLevel = $("#ddlShopLevel").val();
        var shopImage =$("#ddlShopImage").val();
        if (posId == "") {
            alert("请填写店铺编号");
            return false;
        }
        if (shopName == "") {
            alert("请填写店铺名称");
            return false;
        }
        if (shopAddress == "") {
            alert("请填写店铺营业地址");
            return false;
        }
        if (linkMan == "") {
            alert("请填写联系人");
            return false;
        }
        if (shopState == "-1") {
            alert("请选择店铺状态");
            return false;
        }
        if (bigArea == "0") {
            alert("请选择大区");
            return false;
        }
        if (areaId == "0") {
            alert("请选择省区");
            return false;
        }
        if (provinceId == "0") {
            alert("请选择省份");
            return false;
        }
        if (cityId == "0") {
            alert("请选择城市");
            return false;
        }
        if (shopLevel == "0") {
            alert("请选择店铺级别");
            return false;
        }
        if (shopImage == "0") {
            alert("请选择店铺形象");
            return false;
        }
        return true;
    }

  
</script>
