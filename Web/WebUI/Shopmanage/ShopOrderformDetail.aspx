<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ShopOrderformDetail.aspx.cs"
    Inherits="WebUI_Shopmanage_ShopOrderformDetail" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>订单详情</title>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="../../CSS/TableCss.css" rel="stylesheet" type="text/css" />

    <script language="javascript" src="../../js/jquery-1.3.2.min.js" type="text/javascript"></script>

</head>
<body>
    <form id="form1" runat="server">    
        <div style="margin-left: 20px">
            <div style="font-size: 14px; color: #c86000; font-weight: bold">
                &nbsp;订单详情</div>
                
                
            <%-- <table class="table" style="margin-top: 20px; width: 95%; ">
                <tr>
                    <td style="text-align:right; width:40%;">
                        POP位置：</td>
                    <td>
                        <asp:DropDownList ID="DDL_POPSeat" runat="server">
                            <asp:ListItem Value="0">请选择</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td style="text-align:right;">安装后图片：</td>
                    <td><asp:FileUpload ID="FileUpload1" runat="server" /></td>
                </tr>
                <tr>
                    <td colspan="2" align="center">
                        <asp:Button ID="btn_save" runat="server" Text="上传" />
                    </td>
                </tr>
            </table>         --%>  
                
                
            <table class="table" style="margin-top: 20px; width: 95%; text-align:center;">
                <tr>
                    <th>
                        序号</th>
                    <th>
                        POP位置</th>
                    <th>
                        位置描述</th>
                    <th>
                        男女区域</th>
                    <th>
                        POP材质</th>
                    <th>
                        图片</th>
                    <th>
                        安装后图片</th>
                    <th>
                        安装前图片</th>
                    <th>
                         操作</th>
                </tr>
                <asp:Repeater ID="RepPOPList" runat="server">
                    <ItemTemplate>
                        <tr>
                            <td>
                                <%#Eval("SeatNum")%>
                            </td>
                            <td>
                                <%#Eval("POPseat")%>
                            </td>
                            <td>
                                <%#Eval("SeatDesc")%>
                            </td>
                            <td>
                                <%#Eval("Sexarea")%>
                            </td>
                            <td>
                                <%#Eval("POPMaterial")%>
                            </td>
                            <td>
                                <a href="<%#Eval("ImageUrl")%>" target="_blank"><img src="<%#Eval("SmallImageUrl")%>" alt="" width="80" /></a>
                            </td>
                            <td>
                                <span style='display:<%#Eval("NewImageUrl_Small").ToString().Trim() == "" ? "none" : "" %>;'><a href="<%#Eval("NewImageUrl_Big")%>" target="_blank"><img src="<%#Eval("NewImageUrl_Small")%>" alt="" width="80" /></a></span>
                            </td>
                            <td>
                                <span style='display:<%#Eval("OldImageUrl_Small").ToString().Trim() == "" ? "none" : "" %>;'><a href="<%#Eval("OldImageUrl_Big")%>" target="_blank"><img src="<%#Eval("OldImageUrl_Small")%>" alt="" width="80" /></a></span>
                            </td>
                            <td>
                                <a href='ShopOrderformUpload.aspx?ShopID=<%=ShopID %>&POPID=<%=POPID %>&id=<%#Eval("imageToPOP_ID")%>'>上传</a>
                            </td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
            </table>
        </div>
    </form>
</body>
</html>
