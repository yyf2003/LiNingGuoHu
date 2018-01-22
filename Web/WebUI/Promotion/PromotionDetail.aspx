<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PromotionDetail.aspx.cs"
    Inherits="WebUI_Promotion_PromotionDetail" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../../CSS/TableCss.css" rel="stylesheet" type="text/css" />
    <script src="../../js/jquery-1.7.2.js" type="text/javascript"></script>
    <link href="../../fancyBox/source/jquery.fancybox.css" rel="stylesheet" type="text/css" />
    <script src="../../fancyBox/source/jquery.fancybox.js" type="text/javascript"></script>
    <style type="text/css">
        #maindiv td
        {
            padding-left: 5px;
        }
    </style>
    <script type="text/javascript">
        $(function () {
            $("a.showimg").fancybox();



        })
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div style="width: 95%">
        <div style="font-size: 14px; font-weight: bold; text-align: left; padding-left: 20px;
            color: #c86000;">
            <a href="PromotionList.aspx" title="POP推广信息" style="color: #c86000;">POP推广信息</a>
            &gt;&gt; 查看详细信息</div>
    </div>
    <br />
    <div id="maindiv">
        <table class="table">
            <tr>
                <td style="width: 15%">
                    POP推广ID:
                </td>
                <td style="width: 35%">
                    <asp:Label ID="labPromotionId" runat="server" Text=""></asp:Label>
                </td>
                <td style="width: 15%">
                    推广主题：
                </td>
                <td style="width: 35%">
                    <asp:Label ID="labTitle" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    起始时间：
                </td>
                <td>
                    <asp:Label ID="labStartDate" runat="server" Text=""></asp:Label>
                </td>
                <td>
                    结束时间：
                </td>
                <td>
                    <asp:Label ID="labEndDate" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    描述：
                </td>
                <td colspan="3">
                    <asp:Label ID="labRemark" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    季度执行规范下载：
                </td>
                <td>
                    <asp:Label ID="labAttachment" runat="server" Text=""></asp:Label>
                </td>
                <td>
                </td>
                <td>
                    <a href="PromotionList.aspx">返回列表</a>
                </td>
            </tr>
        </table>
        <br />
        <table class="table">
            <tr>
                <td style="width: 15%">
                    故事包：
                </td>
                <td>
                    <asp:DropDownList ID="DDLStoryBag" runat="server" AutoPostBack="true" 
                        onselectedindexchanged="DDLStoryBag_SelectedIndexChanged"> 
                        <asp:ListItem Value="0">全部</asp:ListItem>
                    </asp:DropDownList>
               </td>
            </tr>
        </table>
        <asp:Repeater ID="Repeater1" runat="server" 
            onitemdatabound="Repeater1_ItemDataBound">
            <HeaderTemplate>
                <table class="table" id="table1" style="text-align:center;">
                    <tr>
                       
                        <td style=" width:50px;">
                            故事包
                        </td>
                        <td style=" width:60px;">
                            位置
                        </td>
                        <td style=" width:60px;">
                            道具类型
                        </td>
                        <td style=" width:80px;">
                            道具尺寸
                        </td>
                        <td style=" width:80px;">
                            道具名称
                        </td>
                        <td style="text-align:left; padding-left:20px;">
                            效果图
                        </td>
                    </tr>
            </HeaderTemplate>
            <ItemTemplate>
                <tr>
                    
                    <td runat="server" id="StoryBagName" style=" width:50px;">
                        <%#Eval("StoryBagName")%>
                    </td>
                    <td runat="server" id="seat" style=" width:60px;">
                       <%#Eval("seat")%>
                    </td>
                    <td runat="server" id="rackType" style=" width:60px;">
                       <%#Eval("rackType")%>
                    </td>
                    <td style=" width:80px;">
                       <%#Eval("Size")%>
                    </td>
                    <td style=" width:80px;">
                       <%#Eval("RackName")%>-<%#Eval("Category")%>
                    </td>
                    <td style="text-align:left;">
                        <asp:Label ID="labImg" runat="server" Text=""></asp:Label>
                    </td>
                </tr>
            </ItemTemplate>
           
            <FooterTemplate>
                <%if (Repeater1.Items.Count == 0)
                  { %>
                <tr>
                    <td colspan="6" style="text-align: center;">
                        --暂无信息--
                    </td>
                </tr>
                <%} %>
                </table>
            </FooterTemplate>
        </asp:Repeater>
    </div>
    </form>
</body>
</html>
