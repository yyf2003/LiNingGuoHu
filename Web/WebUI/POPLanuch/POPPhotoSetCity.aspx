<%@ Page Language="C#" AutoEventWireup="true" CodeFile="POPPhotoSetCity.aspx.cs" Inherits="WebUI_POPLanuch_POPPhotoSetCity" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>添加一级客户</title>
    <base target="_self" />
    <link rel="stylesheet" media="all" type="text/css" href="../../css/screen.css" />
    <link rel="stylesheet" media="all" type="text/css" href="../../css/examples.css" />
    <link rel="stylesheet" media="all" type="text/css" href="../../css/TableCss.css" />
    <script language="javascript" type="text/javascript" src="../../js/jquery-1.3.2.min.js"></script>
    <script language="javascript" type="text/javascript" src="../../js/jquery.corner.js"></script>
    <script language="javascript" type="text/javascript" src="../../js/jquery-impromptu.2.5.min.js"></script>
    <script language="javascript" type="text/javascript" src="../../js/common.js"></script>
    <script language="javascript" type="text/javascript" src="../../js/GetProvinceName.js"></script>
    <script language="javascript" type="text/javascript" src="../../js/GetCityByProvince.js"></script>
    <script type="text/javascript" language="javascript" src="../../js/GetAreaBydept.js"></script>
    <script language="javascript" type="text/javascript">
        function GetcityList() {
            var pro = $("#DDL_Province").val();
            GetCityname(pro);
        }


        function CheckAdd() {
            var deakerid = $("#txt_DealerID").val();
            if (deakerid == "") {
                $.prompt("一级客户编号不能为空!", { callback: getdeakerid });
                return false;
            }
            var txt_DealerName = $("#txt_DealerName").val();
            if (txt_DealerName == "") {
                $.prompt("一级客户名称不能为空!", { callback: gettxt_DealerName });
                return false;
            }
            var DDL_Area = document.getElementById("DDL_Area");
            var areatxt = DDL_Area.options[DDL_Area.selectedIndex].value;
            if (areatxt == "0") {
                $.prompt("请选择区域名称!", { callback: gettxt_DDL_Area });
                return false;
            }

            var DDL_Province = document.getElementById("DDL_Province");
            var provtxt = DDL_Province.options[DDL_Province.selectedIndex].value;
            if (provtxt == "0") {
                $.prompt("请选择所在省份!", { callback: getDDL_Province });
                return false;
            }

            var DDL_city = document.getElementById("DDL_city");
            var citytxt = DDL_city.options[DDL_city.selectedIndex].value;
            if (citytxt == "0") {
                $.prompt("请选择所在市区!", { callback: getDDL_city });
                return false;
            }

            var txt_Contactor = $("#txt_Contactor").val();
            if (txt_Contactor == "") {
                $.prompt("一级客户联系人不能为空!", { callback: gettxt_Contactor });
                return false;
            }
            var txt_UserMobile = $("#txt_UserMobile").val();
            if (txt_UserMobile == "") {
                $.prompt("一级客户联系人电话不能为空!", { callback: gettxt_UserMobile });
                return false;
            }

            var txt_Address = $("#txt_Address").val();
            //            if(txt_Address=="")
            //            {
            //                $.prompt("一级客户联系人地址不能为空!",{callback:gettxt_Address});
            //             return false; 
            //            }

            var txt_PostAddress = $("#txt_PostAddress").val();
            if (txt_PostAddress == "") {
                $.prompt("一级客户邮政地址不能为空!", { callback: gettxt_PostAddress });
                return false;
            }
            //                   var txt_Dealerchannel =$("#txt_Dealerchannel").val();
            //            if(txt_Dealerchannel=="")
            //            {
            //                $.prompt("一级客户渠道信息不能为空!",{callback:gettxt_Dealerchannel});
            //             return false; 
            //            }
        }

        function getdeakerid() {
            $("#txt_DealerID").focus();
        }
        function gettxt_DealerName() {
            $("#txt_DealerName").focus();
        }
        function gettxt_DDL_Area() {
            $("#DDL_Area").focus();
        }
        function getDDL_Province() {
            $("#DDL_Province").focus();
        }
        function getDDL_city() {
            $("#DDL_city").focus();
        }
        function gettxt_Contactor() {
            $("#txt_Contactor").focus();
        }
        function gettxt_UserMobile() {
            $("#txt_UserMobile").focus();
        }
        function gettxt_Address() {
            $("#txt_Address").focus();
        }
        function gettxt_PostAddress() {
            $("#txt_PostAddress").focus();
        }
        //      function gettxt_Dealerchannel()
        //       {
        //       $("#txt_Dealerchannel").focus();
        //       }
    </script>

</head>
<body >
    <form id="form1" runat="server">
    	<div>
    	<div style=" font-size:14px; font-weight:bold; text-align:left; padding-left:20px;color: #c86000;margin-top: 20px;">添加一级客户信息</div>
        <table class="table" style="margin-top: 20px; float:left; text-align:left; margin-left:20px">
           <tr>
                <td>部门名称：</td>
                <td>
                    <asp:CheckBoxList ID="chbArea" runat="server" RepeatColumns="7"  RepeatDirection="Horizontal">
                    </asp:CheckBoxList>
                </td>
            </tr>
            <tr>
                <td>城市级别：</td>
                <td>
                    <asp:CheckBoxList ID="chbCityLevel" runat="server" RepeatColumns="5" RepeatDirection="Horizontal">
                      <asp:ListItem Value="1">超大</asp:ListItem>
                      <asp:ListItem Value="2">一线</asp:ListItem>
                      <asp:ListItem Value="3">二线</asp:ListItem>
                      <asp:ListItem Value="4">三线</asp:ListItem>
                      <asp:ListItem Value="5">三线以下</asp:ListItem>
                    </asp:CheckBoxList>
                </td>
            </tr>
            <tr>
                <td colspan="4" align="center">
                    <asp:Button ID="Button1" runat="server" Text="设 置" CssClass="qr0" 
                        onclick="Button1_Click" />
                </td>
            </tr>
        </table>
        </div>
    </form>
</body>
</html>

