<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SetupToShop.aspx.cs" Inherits="WebUI_PhysicalDistribution_SetupToShop" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>安装到店铺</title>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="../../CSS/TableCss.css" rel="stylesheet" type="text/css" />
    <link href="../../CSS/screen.css" rel="stylesheet" type="text/css" />
    <link href="../../CSS/examples.css" rel="stylesheet" type="text/css" />

    <script type="text/javascript" language="javascript" src="../../js/jquery-1.3.2.min.js"></script>

    <script type="text/javascript" language="javascript" src="../../js/jquery.corner.js"></script>

    <script type="text/javascript" language="javascript" src="../../js/jquery-impromptu.2.5.min.js"></script>

    <script type="text/javascript" language="javascript" src="../../js/common.js"></script>

    <script type="text/javascript" language="javascript" src="../../js/Validate.js"></script>

    <script type="text/javascript" language="javascript" src="./javascript/ValidateSendFrom.js"></script>

    <script type="text/javascript" language="javascript">
	    var IsAllCheck = 0;
	    function AllCheck()
	    {
	        var selectSpan = $("#selectSpan");
	        var chk = $("input[type='checkbox']");
	        if(IsAllCheck == 0)
	        {
	            chk.attr("checked",'true');//全选
	            IsAllCheck = 1;
	            selectSpan.html("取消");
	            selectSpan.attr("title","全部取消");
	        }
	        else
	        {
	            chk.removeAttr("checked");//取消
	            IsAllCheck = 0;
	            selectSpan.html("全选");
	            selectSpan.attr("title","全部选择");
	        }
	    }
    </script>

</head>
<body>
    <form id="form1" runat="server">
        <div style="width: 100%; height: auto; text-align: center">
            <div style="font-size: 14px; font-weight: bold; text-align: left; padding-left: 20px;
                width: 50%; float: left; height: 30px; color: #c86000;">
                <a href="SendToShopList.aspx" title="安装到店铺" style="color: #c86000;">安装到店铺</a> &gt;&gt;
                <%= ShopName%>
            </div>
            <table class="table" style="margin-top: 20px; float: left; margin-left: 20px; width: 90%">
                <caption style="font-weight: bold">
                    POP信息列表：</caption>
                <tr>
                    <th>
                        POP编号</th>
                    <th style="width: 25%">
                        POP位置</th>
                    <th style="width: 25%">
                        材料</th>
                    <th>
                        POP高度</th>
                    <th>
                        POP宽度</th>
                    <th>
                        POP面积</th>
                    <th>
                        <span id="selectSpan" style="cursor: pointer" onclick="javascript:AllCheck();" title="全部选择">
                            全选</span></th>
                </tr>
                <asp:Repeater runat="server" ID="RepPOPList">
                    <ItemTemplate>
                        <tr>
                            <td>
                                <asp:Label ID="lblID" runat="server" Text='<%# Eval("ID")%>'></asp:Label></td>
                            <td>
                                <%# Eval("POPseat")%>
                            </td>
                            <td>
                                <%# Eval("POPMaterial") %>
                            </td>
                            <td>
                                <%# Eval("POPHeight")%>
                            </td>
                            <td>
                                <%# Eval("POPWith")%>
                            </td>
                            <td>
                                <%# Eval("POPArea")%>
                            </td>
                            <td>
                                <asp:CheckBox ID="chkSelect" runat="server" /></td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
            </table>
            <table class="table" style="margin-top: 10px; float: left; margin-left: 20px; width: 90%">
                <tr>
                    <td style="width: 30%; height: 30px;">
                        POP发起ID：</td>
                    <td style="text-align: left; height: 30px;">
                        <asp:DropDownList ID="ddlPOPID" runat="server" CssClass="txtwith">
                        </asp:DropDownList><span style="margin-left: 5px; color: red">*</span>
                    </td>
                </tr>
                <tr>
                    <td style="width: 30%; height: 30px;">
                        实际安装数量：</td>
                    <td style="text-align: left; height: 30px;">
                        <span style="margin-left: 5px; color: red">
                            <asp:TextBox ID="txt_Num" runat="server" CssClass="txtwith" onafterpaste="this.value=this.value.replace(/\D/g,'')"
                                onkeyup="this.value=this.value.replace(/\D/g,'')" Width="149px"></asp:TextBox>*</span>
                    </td>
                </tr>
                <tr>
                    <td style="width: 30%; height: 30px;">
                        发货地址：</td>
                    <td style="text-align: left; height: 30px;">
                        &nbsp;<asp:TextBox ID="txt_SendAddress" CssClass="txtwith" runat="server"></asp:TextBox><span
                            style="margin-left: 5px; color: red">*</span>
                    </td>
                </tr>
                <tr>
                    <td style="width: 30%; height: 30px;">
                        收货人：</td>
                    <td style="text-align: left; height: 30px;">
                        &nbsp;<asp:TextBox ID="txt_Consignee" CssClass="txtwith" runat="server"></asp:TextBox><span
                            style="margin-left: 5px; color: red">*</span>
                    </td>
                </tr>
                <tr>
                    <td style="width: 30%; height: 30px;">
                        收货人移动电话：</td>
                    <td style="text-align: left; height: 30px;">
                        &nbsp;<asp:TextBox ID="txt_ConsigneeMobile" CssClass="txtwith" runat="server"></asp:TextBox><span
                            style="margin-left: 5px; color: red">*</span>
                    </td>
                </tr>
                <tr>
                    <td style="width: 30%; height: 30px;">
                        收货固定电话：</td>
                    <td style="text-align: left; height: 30px;">
                        &nbsp;<asp:TextBox ID="txt_ConsigneePhone" CssClass="txtwith" runat="server"></asp:TextBox><span
                            style="margin-left: 5px; color: red">*</span>
                    </td>
                </tr>
                <tr>
                    <td style="height: 30px;">
                        上传图片：</td>
                    <td style="text-align: left">
                        <span style="margin-left: 5px; color: red">
                            <asp:FileUpload ID="FileUpload1" runat="server" Width="435px" />
                            多幅图片，请上传RAR格式压缩文件*</span>
                    </td>
                </tr>
                <tr>
                    <td style="height: 30px;">
                        备&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;注：<br />
                        <span style="color: red"></span>
                    </td>
                    <td style="text-align: left">
                        &nbsp;<asp:TextBox ID="txt_Desc" runat="server" CssClass="txtwith" Height="80px"
                            TextMode="MultiLine" Width="360px"></asp:TextBox></td>
                </tr>
                <tr>
                    <td style="height: 30px;">
                    </td>
                    <td style="text-align: left">
                        <asp:Button runat="server" Text="发   货" ID="btnAdd" CssClass="qr0" OnClientClick="return ValidateInput();"
                            OnClick="btnAdd_Click"></asp:Button>
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
