<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PromotionFour.aspx.cs" Inherits="WebUI_Promotion_PromotionFour" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../../CSS/TableCss.css" rel="stylesheet" type="text/css" />
    <script src="../../js/jquery-1.7.2.js" type="text/javascript"></script>
    <script src="js/GetProvinceByRegion.js" type="text/javascript"></script>
    <link href="../../fancyBox/source/jquery.fancybox.css" rel="stylesheet" type="text/css" />
    <script src="../../fancyBox/source/jquery.fancybox.js" type="text/javascript"></script>
    <script src="js/Promotion.js" type="text/javascript"></script>
    <script type="text/javascript">
        function ShowMsg(msg) {
            alert(msg);
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div style="width: 95%">
        <div style="font-size: 14px; font-weight: bold; text-align: left; padding-left: 20px;
            color: #c86000;">
            <a href="PromotionList.aspx" title="POP推广信息" style="color: #c86000;">POP推广信息</a>
            &gt;&gt; 选择店铺</div>
        <br />
        <table class="table">
            <tr>
                <td style="width: 150px; text-align: right">
                    推广ID:
                </td>
                <td style="text-align: left">
                    <asp:Label ID="labPromotionId" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="text-align: right">
                    推广主题:
                </td>
                <td style="text-align: left">
                    <asp:Label ID="labTitle" runat="server" Text=""></asp:Label>
                </td>
            </tr>
        </table>
        <br />
        <table class="table">
            <tr>
                <td style="width: 150px; text-align: right">
                    选择店铺:
                </td>
                <td style="text-align: left">
                    <asp:RadioButtonList ID="rblSelectType" runat="server" RepeatDirection="Horizontal"
                        RepeatLayout="Flow" OnSelectedIndexChanged="rblSelectType_SelectedIndexChanged"
                        AutoPostBack="true">
                        <asp:ListItem Selected="True" Value="0">所有店铺 </asp:ListItem>
                        <asp:ListItem Value="1">按条件筛选  </asp:ListItem>
                        <asp:ListItem Value="2">手动导入 </asp:ListItem>
                    </asp:RadioButtonList>
                </td>
            </tr>
        </table>
        <br />
        <asp:MultiView ID="MultiView1" runat="server" ActiveViewIndex="0">
            <asp:View ID="View1" runat="server">
            </asp:View>
            <asp:View ID="View2" runat="server">
                <table class="table">
                    <tr>
                        <td style="width: 150px; text-align: right">
                            店铺零售属性:
                        </td>
                        <td>
                            <asp:Label ID="labShopST" runat="server" Text=""></asp:Label>
                            <asp:HiddenField ID="hfShopST" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td style="text-align: right">
                            店铺级别:
                        </td>
                        <td>
                            <asp:Label ID="labShoplevel" runat="server" Text=""></asp:Label>
                            <asp:HiddenField ID="hfShoplevel" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td style="text-align: right">
                            店铺类型:
                        </td>
                        <td>
                            <asp:Label ID="labShopType" runat="server" Text=""></asp:Label>
                            <asp:HiddenField ID="hfShopType" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td style="text-align: right">
                            店铺形象属性:
                        </td>
                        <td>
                            <asp:Label ID="labShopVI" runat="server" Text=""></asp:Label>
                            <asp:HiddenField ID="hfShopVI" runat="server" />
                        </td>
                    </tr>
                    <%--<tr>
                        <td style="text-align: right">
                            地市级城市级别-市场定义:
                        </td>
                        <td>
                            <asp:Label ID="labTCL" runat="server" Text=""></asp:Label>
                            <asp:HiddenField ID="hfTCL" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td style="text-align: right">
                            区县级城市级别-市场定义:
                        </td>
                        <td>
                            <asp:Label ID="labACL" runat="server" Text=""></asp:Label>
                            <asp:HiddenField ID="hfACL" runat="server" />
                        </td>
                    </tr>--%>
                    <tr>
                        <td style="text-align: right">
                            区域:
                        </td>
                        <td>
                            <div>
                                <input id="selectAllRegion" type="checkbox" value="0" /><span style="color: Blue;">全选</span>
                            </div>
                            <asp:Label ID="labRegion" runat="server" Text=""></asp:Label>
                            <asp:HiddenField ID="hfRegion" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td style="text-align: right">
                            省份:
                        </td>
                        <td>
                            <div id="provinceDiv">
                            </div>
                            <asp:HiddenField ID="hfProvince" runat="server" />
                        </td>
                    </tr>
                    <%--<tr>
                        <td style="text-align: right">
                            城市:
                        </td>
                        <td>
                            
                        </td>
                    </tr>--%>
                    <tr>
                        <td colspan="2" style="text-align: right; padding-right: 20px;">
                            <a href="javascript:void(0)" id="checkShops">查看所选择的店铺</a>
                        </td>
                    </tr>
                </table>
            </asp:View>
            <asp:View ID="View3" runat="server">
                <table class="table">
                    <tr>
                        <td style="width: 150px; text-align: right">
                            选择上传文件:
                        </td>
                        <td style="width: 250px;">
                            <asp:FileUpload ID="FileUpload1" runat="server" />
                        </td>
                        <td style="text-align: left;">
                            <div id="showButton" runat="server">
                                <asp:Button ID="Button_AddProp" runat="server" Text=" 导 入 " OnClick="Button_AddProp_Click"
                                    OnClientClick="return checkFile()" />
                                &nbsp;&nbsp;<asp:LinkButton ID="lb_DownLoadPropTemplate" runat="server" OnClick="lb_DownLoadPropTemplate_Click">下载模板</asp:LinkButton>
                            </div>
                            <div id="showWaiting" runat="server" style="color: Red; display: none;">
                                <img src='../../images/loading.gif' />正在导入，请稍等...
                            </div>
                        </td>
                    </tr>
                </table>
                <div id="uploadMsg" runat="server" style="text-align: left; display: none; height: 200px;
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
                        失败：<asp:Label ID="labFailNum" runat="server" Text=""></asp:Label>
                        条<br />
                    </div>
                    <div id="errorMsg" runat="server" style="margin-top: 10px; display: none; line-height: 24px;">
                        <span style="color: Red;">错误信息：</span>
                        <br />
                        <asp:Label ID="labErrorMsg" runat="server" Text=""></asp:Label>
                    </div>
                </div>
            </asp:View>
        </asp:MultiView>
        <br />
        <br />
        <div id="loading" style=" height:30px; text-align:center; display:none;color:Red;">
            <img src="../../images/loading.gif" />正在提交....&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        </div>
        <div id="buttons" style="text-align: center; width: 900px;">
            <asp:Button ID="BtnNext" CssClass="qr0" runat="server" Text="下一步" OnClientClick="return check()"
                OnClick="BtnNext_Click" />
            &nbsp; &nbsp;
            <asp:Button ID="btnPrev" runat="server" Text="上一步" CssClass="qr0" OnClick="btnPrev_Click" />
            &nbsp; &nbsp;
            <asp:LinkButton ID="lbJump" runat="server" onclick="lbJump_Click">跳 过</asp:LinkButton>
        </div>
        <br />
        <br />
    </div>
    </form>
</body>
</html>
<script type="text/javascript">
    $(function () {

    })
    function checkFile() {
        var val = $("#FileUpload1").val();
        if (val != "") {
            var extent = val.substring(val.lastIndexOf('.') + 1);
            if (extent != "xls" && extent != "xlsx") {
                alert("只能上传Excel文件");
                return false;
            }
        }
        else {
            alert("请选择文件");
            return false;
        }
        $("#showButton").css({ display: "none" });
        $("#showWaiting").css({ display: "" });
    }


    function check() {
        
        var val = $("input[type='radio']:checked").val();
        if (val == "1") {
            var selectAreaCount = GetVal();
//            if (selectAreaCount == 0) {
//                alert("请选择筛选条件");
//                return false;
//            }
//            if ($("#hfRegion").val() != "" && $("#hfProvince").val() == "") {
//                alert("请选择省份");
//                return false;
//            }
        }
        if (val == "2") {
            if ($("#labTotal").text() == "") {
                alert("请先导入店铺数据");
                return false;
            }
        }
        $("#loading").show();
        $("#buttons").hide();
    }

    function ShowMsg(msg) {
        alert(msg);
    }
</script>
