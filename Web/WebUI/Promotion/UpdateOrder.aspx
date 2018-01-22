<%@ Page Language="C#" AutoEventWireup="true" CodeFile="UpdateOrder.aspx.cs" Inherits="WebUI_Promotion_UpdateOrder" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        #rackCount
        {
            list-style: none;
            margin: 0;
            padding-left: 0;
        }
        #rackCount li
        {
            float: left;
            margin-right: 10px;
        }
    </style>
    <link href="../../CSS/TableCss.css" rel="stylesheet" type="text/css" />
    <script src="../../js/jquery-1.7.2.js" type="text/javascript"></script>
    <script type="text/javascript">
        var isInt = /^\d{1,}$/;

        function checkFile() {
            // var sbid = $("input:radio[name='rblStoryBag']:checked").val() || "";
            var sbid = $("#hfStoryBag").val() || "";
            if (sbid == "") {
                alert("请选择故事包!");
                return false;
            }

            
            var regionId = $("input:radio[name='rblRegion']:checked").val() || "";
            if (regionId == "") {
                alert("请选择区域!");
                return false;
            }
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
            $("#hfImporting").val("1");
        }

        $(function () {

            //rack.getList();

            $("#showBtn").click(function () {
                var txt = $(this).html();
                if (txt == "隐藏") {
                    $(this).html("显示");
                    $("#logMsg").hide();
                }
                else {
                    $(this).html("隐藏");
                    $("#logMsg").show();
                }
            })


        })


       
    </script>
    <link href="../../fancyBox/source/jquery.fancybox.css" rel="stylesheet" type="text/css" />
    <script src="../../fancyBox/source/jquery.fancybox.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(function () {
            $("#updateLimitCount").click(function () {
                $.fancybox.open({
                    href: "RackInfo/SetRackLimitCount1.aspx",
                    type: "iframe",
                    padding: 5,
                    width: "90%"
                })
            })
        })
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <asp:HiddenField ID="hfImporting" runat="server" />
    <div style="font-size: 14px; font-weight: bold; text-align: left; padding-left: 20px;
        color: #c86000;">
        更新推广订单
    </div>
    <br />
    <table class="table">
        <tr>
            <td style="width: 150px; text-align: right">
                选择要更新的故事包:
            </td>
            <td colspan="2" style="text-align: left;">
                <%-- <asp:RadioButtonList ID="rblStoryBag" runat="server" AutoPostBack="true" RepeatDirection="Horizontal"
                    RepeatLayout="Flow" OnSelectedIndexChanged="rblStoryBag_SelectedIndexChanged">
                </asp:RadioButtonList>--%>
                <asp:CheckBoxList ID="cblStoryBag" runat="server" AutoPostBack="true" RepeatDirection="Horizontal"
                    RepeatLayout="Flow" OnSelectedIndexChanged="cblStoryBag_SelectedIndexChanged">
                </asp:CheckBoxList>
                <asp:HiddenField ID="hfStoryBag" runat="server" />
            </td>
        </tr>
        <tr>
            <td style="text-align: right; width: 150px;">
                历史数据:
            </td>
            <td colspan="2">
                <asp:Button ID="btnClearData" runat="server" Text="清除历史数据" Enabled="false" OnClick="btnClearData_Click1"
                    OnClientClick="return confirm('确定清除吗？')" />
                （<asp:Label ID="Label1" runat="server" Text="无历史数据"></asp:Label>）
            </td>
        </tr>
        <tr>
            <td style="text-align: right; width: 150px;">
                请选择省区:
            </td>
            <td colspan="2">
                <asp:RadioButtonList ID="rblRegion" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow">
                </asp:RadioButtonList>
            </td>
        </tr>
        <tr>
            <td style="width: 150px; text-align: right">
                设置道具数量上限值:
            </td>
            <td colspan="2" style="text-align: left;">
                <span id="updateLimitCount" style="color: Blue; text-decoration: underline; cursor: pointer;">
                    设 置</span>
            </td>
        </tr>
        <tr>
            <td style="width: 150px; text-align: right">
                道具数量是否已确认:
            </td>
            <td colspan="2" style="text-align: left;">
                <asp:CheckBox ID="cbRackCountIsOk" runat="server" />全部已确认(如果不选择，提示道具不足)
            </td>
        </tr>
        <tr>
            <td style="width: 150px; text-align: right">
                选择上传文件:
            </td>
            <td colspan="2" style="text-align: left;">
                <asp:FileUpload ID="FileUpload1" runat="server" />
            </td>
        </tr>
        <tr>
            <td style="width: 150px; text-align: right">
            </td>
            <td colspan="2" style="text-align: left;">
                <div id="showButton" runat="server">
                    <asp:Button ID="Button_AddProp" runat="server" Text=" 导 入 " CssClass="qr0" OnClientClick="return checkFile()"
                        OnClick="Button_AddProp_Click" />
                    &nbsp;&nbsp;<asp:LinkButton ID="lb_DownLoadPropTemplate" runat="server" OnClick="lb_DownLoadPropTemplate_Click">下载模板</asp:LinkButton>
                </div>
                <div id="showWaiting" runat="server" style="color: Red; display: none;">
                    <img src='../../images/loading.gif' />正在导入，请稍等...
                </div>
            </td>
        </tr>
    </table>
    <asp:Panel ID="Panel1" runat="server" Visible="false">
        <br />
        <div>
            更新记录：<span id="showBtn" style="cursor: pointer; color: Blue; text-decoration: underline;">显示</span>
        </div>
        <div id="logMsg" style="display: none;">
            <asp:Repeater ID="Repeater1" runat="server">
                <HeaderTemplate>
                    <table class="table">
                        <tr>
                            <th style="width: 30px;">
                                序号
                            </th>
                            <th style="width: 100px;">
                                故事包
                            </th>
                            <th style="width: 100px;">
                                区域
                            </th>
                            <th>
                                状态信息
                            </th>
                        </tr>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr>
                        <td style="width: 30px;">
                            <%#Container.ItemIndex+1 %>
                        </td>
                        <td style="width: 100px;">
                            <%#Eval("StoryBagName")%>
                        </td>
                        <td style="width: 100px;">
                            <%#Eval("department")%>
                        </td>
                        <td>
                            <%#Eval("UpdateMsg")%>
                        </td>
                    </tr>
                </ItemTemplate>
                <FooterTemplate>
                    </table>
                </FooterTemplate>
            </asp:Repeater>
        </div>
    </asp:Panel>
    <asp:Panel ID="Panel2" runat="server" Visible="false">
        <asp:Repeater ID="Repeater2" runat="server">
            <HeaderTemplate>
                <table>
                    <tr>
                        <td>
                            区域
                        </td>
                        <td>
                            店铺级别
                        </td>
                        <td>
                            总记录
                        </td>
                        <td>
                            更新成功
                        </td>
                        <td>
                            重复数量
                        </td>
                        <td>
                            失败数量
                        </td>
                    </tr>
            </HeaderTemplate>
            <ItemTemplate>
                <tr>
                    <td runat="server" id="tdRegion">
                        <%#Eval("department")%>
                    </td>
                    <td>
                        <%#Eval("ShopLevel")%>
                    </td>
                    <td>
                        <%#Eval("TotalRecord")%>
                    </td>
                    <td>
                        <%#Eval("SuccessNum")%>
                    </td>
                    <td>
                        <%#Eval("RepeatNum")%>
                    </td>
                    <td>
                        <%#Eval("FailNum")%>
                    </td>
                </tr>
            </ItemTemplate>
            <FooterTemplate>
                </table>
            </FooterTemplate>
        </asp:Repeater>
    </asp:Panel>
    <div id="uploadMsg" runat="server" style="text-align: left; display: none; height: 1px;
        line-height: 22px; width: 100%;">
    </div>
    <div>
        <asp:Label ID="labuploadMsg" runat="server" Text="" Style="font-size: 15px; color: Red;"></asp:Label>
    </div>
    <div id="errorMsg" runat="server" style="display: none; line-height: 24px;">
        <span style="color: Red;">错误信息：</span>
        <br />
        <asp:Label ID="labErrorMsg" runat="server" Text=""></asp:Label>
    </div>
    <asp:Panel ID="Panel3" runat="server" Visible="false">
        <div>
            重复店铺信息：</div>
        <asp:Repeater ID="Repeater3" runat="server">
            <HeaderTemplate>
                <table>
                    <tr>
                        <td style="width: 120px;">
                            大区
                        </td>
                        <td style="width: 120px;">
                            店铺级别
                        </td>
                        <td style="width: 150px;">
                            店铺编号
                        </td>
                        <td style="width: 120px;">
                            重复数量
                        </td>
                    </tr>
            </HeaderTemplate>
            <ItemTemplate>
                <tr>
                    <td>
                        <%#Eval("BigArea")%>
                    </td>
                    <td>
                        <%#Eval("ShopLevel")%>
                    </td>
                    <td>
                        <%#Eval("ShopNo")%>
                    </td>
                    <td>
                        <%#Eval("RepeatNum")%>
                    </td>
                </tr>
            </ItemTemplate>
            <FooterTemplate>
                </table>
            </FooterTemplate>
        </asp:Repeater>
    </asp:Panel>
    <br />
    <br />
    <br />
    <div id="buttons" style="text-align: center; width: 900px;">
        <asp:Button ID="btnBack" CssClass="qr0" runat="server" Text="返 回" OnClick="btnExport_Click" />
    </div>
    <br />
    <br />
    </form>
</body>
</html>
