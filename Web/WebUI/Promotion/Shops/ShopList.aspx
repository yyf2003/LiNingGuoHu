<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ShopList.aspx.cs" Inherits="WebUI_Promotion_Shops_ShopList" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .table1
        {
            border: 1px solid #6d6060; /* 表格边框 */
            font-family: Arial;
            border-collapse: collapse; /* 边框重叠 */
            background-color: #fdf6f6; /* 表格背景色 */
            font-size: 12px;
            
        }
        .table1 caption
        {
            padding-bottom: 5px;
            font: bold 1.4em;
            text-align: left;
        }
        .table1 th
        {
            border: 1px solid #6d7378; /* 行名称边框 */
            background-color: #a1a1a1; /* 行名称背景色 */
            color: #fff; /* 行名称颜色 */
            font-weight: bold;
            padding-top: 4px;
            padding-bottom: 4px;
            padding-left: 12px;
            padding-right: 12px;
            text-align: center;
        }
        .table1 td
        {
            border: 1px solid #797e83; /* 单元格边框 */
            line-height: 25px;
            padding-top: 4px;
            padding-bottom: 4px;
            padding-left: 5px;
            padding-right: 10px;
        }
        .table1 tr.altrow
        {
            background-color: #e2e0e0; /* 动态变色 */
        }
        .table1 tr:hover
        {
            background-color: #e2e0e0; /* 动态变色 */
        }
    </style>
    <link href="../../../CSS/TableCss.css" rel="stylesheet" type="text/css" />
    <script src="../../../js/jquery-1.7.2.js" type="text/javascript"></script>
    <link href="../../../fancyBox/source/jquery.fancybox.css" rel="stylesheet" type="text/css" />
    <script src="../../../fancyBox/source/jquery.fancybox.js" type="text/javascript"></script>
    <script type="text/javascript">
        var isUpdate = 0;
        function Update() {
            isUpdate = 1;
            
        }
        $(function () {
            $("#txtRackNum").on("blur", function () {
                var val = $(this).val();
                if (isNaN(val)) {
                    alert("请输入数字");
                    $(this).val("");
                }
            })


            $("span[name='checkrack']").click(function () {
                var shopid = $(this).data("shopid");
                $.fancybox.open({
                    href: "RackList.aspx?shopid=" + shopid,
                    type: "iframe",
                    width: "95%",
                    padding: 5
                })
            })

            $("span[name='checkshop']").click(function () {
                var shopid = $(this).data("shopid");
                $.fancybox.open({
                    href: "Edit.aspx?shopid=" + shopid,
                    type: "iframe",
                    width: "95%",
                    padding: 5,
                    afterClose: function () {
                        if (isUpdate == 1) {
                            isUpdate = 0;
                            $("#btnSearch").click();
                        }
                    }
                })
            })
        })
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div style="width: 95%">
        <div style="font-size: 14px; font-weight: bold; text-align: left; padding-left: 20px;
            color: #c86000;">
            <a href="../PromotionList.aspx" style="color: #c86000;">POP推广</a> &gt;&gt;
            <asp:Label ID="labTitle" runat="server" Text="店铺信息管理"></asp:Label></div>
    </div>
    <br />
    <table class="table">
        <tr>
            <td style="width: 120px;">
                省区：
            </td>
            <td style="width: 250px;">
                <asp:DropDownList ID="ddlArea" runat="server">
                </asp:DropDownList>
            </td>
            <td style="width: 120px;">
                城市：
            </td>
            <td>
                省份:
                <asp:DropDownList ID="ddlProvince" runat="server">
                </asp:DropDownList>
                城市:
                <asp:DropDownList ID="ddlCity" runat="server">
                   <asp:ListItem Value="0">全部</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td style="width: 120px;">
                店铺级别：
            </td>
            <td style="width: 250px;">
               
                <asp:CheckBoxList ID="cblShopLevel" runat="server" RepeatDirection="Horizontal"
                    RepeatLayout="Flow">
                </asp:CheckBoxList>
            </td>
            <td style="width: 120px;">
                店铺形象：
            </td>
            <td>
               
                <asp:CheckBoxList ID="cblShopImage" runat="server" RepeatDirection="Horizontal"
                    RepeatLayout="Flow">
                </asp:CheckBoxList>
            </td>
        </tr>
        <tr>
            <td style="width: 120px;">
                店铺类型：
            </td>
            <td style="width: 250px;">
               
                <asp:CheckBoxList ID="cblShopType" runat="server" RepeatDirection="Horizontal"
                    RepeatLayout="Flow">
                </asp:CheckBoxList>
            </td>
            <td style="width: 120px;">
                零售属性：
            </td>
            <td>
                <asp:CheckBoxList ID="cblShopSaleType" runat="server" RepeatDirection="Horizontal"
                    RepeatLayout="Flow">
                </asp:CheckBoxList>
            </td>
        </tr>
        <tr>
            <td style="width: 120px;">
                店铺状态：
            </td>
            <td style="width: 250px;">
               
                <asp:CheckBoxList ID="cblShopState" runat="server" RepeatDirection="Horizontal"
                    RepeatLayout="Flow">
                </asp:CheckBoxList>
            </td>
            <td style="width: 120px;">
                道具信息：
            </td>
            <td>
                道具类型：<asp:DropDownList ID="ddlRackType" runat="server">
                </asp:DropDownList>
                数量：<asp:DropDownList ID="ddlOperater" runat="server" Style="width: 40px;">
                    <asp:ListItem Value="=">=</asp:ListItem>
                    <asp:ListItem Value=">">></asp:ListItem>
                    <asp:ListItem Value="<"><</asp:ListItem>
                </asp:DropDownList>
                <asp:TextBox ID="txtRackNum" runat="server" MaxLength="3" Style="width: 40px;"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="width: 120px;">
                店铺编号：
            </td>
            <td style="width: 250px;">
                <asp:TextBox ID="txtShopNo" runat="server" MaxLength="10"></asp:TextBox>
            </td>
            <td style="width: 120px;">
              店铺名称：
            </td>
            <td>
            <asp:TextBox ID="txtShopName" runat="server" MaxLength="50" Style="width: 200px;"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="width: 120px;">
                导出Excel：
            </td>
            <td style="width: 250px;">
               <asp:LinkButton ID="lbExport" runat="server" onclick="lbExport_Click">导 出</asp:LinkButton>
            </td>
            <td style="width: 120px;">
             
            </td>
            <td>
       
            </td>
        </tr>
        <tr>
            <td>
            </td>
            <td colspan="3">
                <asp:Button ID="btnSearch" CssClass="qr0" runat="server" Text="查 询" OnClick="btnSearch_Click" />
            </td>
        </tr>
    </table>
    <br />
    <div style="width: 900px; overflow: auto;">
        <asp:Repeater ID="Repeater1" runat="server">
            <HeaderTemplate>
                <table class="table1" style=" width:3000px;">
                    <tr>
                        <th>
                            序号
                        </th>
                        <th>
                            道具信息
                        </th>
                        <th>
                            店铺编号
                        </th>
                        <th>
                            店铺名称
                        </th>
                        <th>
                            店铺简称
                        </th>
                        <th>
                            店铺营业地址
                        </th>
                        <th>
                            上级客户编码
                        </th>
                        <th>
                            上级客户名称
                        </th>
                        
                        <th>
                            直属客户编码
                        </th>
                        <th>
                            直属客户名称
                        </th>
                        <th>
                            直属客户身份
                        </th>
                        <th>
                            店铺状态
                        </th>
                        <th>
                            省区
                        </th>
                        <th>
                            省份
                        </th>
                        <th>
                            城市
                        </th>
                        <th>
                            城市级别
                        </th>
                        
                        <th>
                            区县级城市级别
                        </th>
                        <th>
                            店铺零售属性
                        </th>
                        <th>
                            店铺类型
                        </th>
                        <th>
                            店铺级别
                        </th>
                        <th>
                            店铺形象
                        </th>
                        <th>
                            店铺产权关系
                        </th>
                    </tr>
                
            </HeaderTemplate>
            <ItemTemplate>
                 <tr>
                        <td>
                            <%#Container.ItemIndex + 1 + ((AspNetPager1.CurrentPageIndex - 1) * AspNetPager1.PageSize)%>
                        </td>
                        <td>
                            <span name="checkrack" data-shopid='<%#Eval("ID") %>' style=" text-align:underline;color:Blue; cursor:pointer;">查看</span>
                        </td>
                        <td>
                            <span name="checkshop" data-shopid='<%#Eval("ID") %>' style=" text-align:underline;color:Blue; cursor:pointer;"><%#Eval("PosID")%></span>
                        </td>
                        <td>
                            <%#Eval("Shopname")%>
                        </td>
                        <td>
                            <%#Eval("Shopsamplename")%>
                        </td>
                        <td>
                            <%#Eval("ShopAddress")%>
                        </td>
                        <td>
                            <%#Eval("DealerID")%>
                        </td>
                        <td>
                            <%#Eval("DealerName")%>
                        </td>
                        
                        <td>
                            <%#Eval("FXID")%>
                        </td>
                        <td>
                            <%#Eval("FXName")%>
                        </td>
                        <td>
                            <%#Eval("CustomerCard")%>
                        </td>
                        <td>
                            <%#Eval("ShopState")%>
                        </td>
                        <td>
                            <%#Eval("AreaName")%>
                        </td>
                        <td>
                            <%#Eval("ProvinceName")%>
                        </td>
                        <td>
                            <%#Eval("CityName")%>
                        </td>
                        <td>
                            <%#Eval("TCL_Name")%>
                        </td>
                        
                        <td>
                            <%#Eval("ACL_Name")%>
                        </td>
                        <td>
                            <%#Eval("SaleType")%>
                        </td>
                        <td>
                            <%#Eval("ShopTypename")%>
                        </td>
                        <td>
                            <%#Eval("ShopLevelName")%>
                        </td>
                        <td>
                            <%#Eval("ImageName")%>
                        </td>
                        <td>
                            <%#Eval("ShopOwnerShip")%>
                        </td>
                    </tr>
            </ItemTemplate>
            <FooterTemplate>
               </table>
            </FooterTemplate>
        </asp:Repeater>
    </div>
    <div style=" text-align:center;">
        <webdiyer:AspNetPager ID="AspNetPager1" runat="server"
          CssClass="pager" AlwaysShow="true"
            PageSize="15" FirstPageText="首页" LastPageText="尾页" NextPageText="后页" PrevPageText="前页"
            NumericButtonCount="7" OnPageChanged="AspNetPager1_PageChanged" LayoutType="Table"
            HorizontalAlign="Left" CustomInfoHTML="共%RecordCount%条记录" ShowCustomInfoSection="Left"
        >
           
        </webdiyer:AspNetPager>
    </div>
    </form>
</body>
</html>
