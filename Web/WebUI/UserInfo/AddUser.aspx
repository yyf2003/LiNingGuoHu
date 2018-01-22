<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AddUser.aspx.cs" Inherits="WebUI_UserInfo_AddUser" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>添加人员信息</title>
    <link rel="stylesheet" media="all" type="text/css" href="../../css/TableCss.css" />
    <link href="../../CSS/examples.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        .areaList
        {
            list-style: none;
            margin: 0px;
            padding-left: 0px;
        }
        .areaList li
        {
            float: left;
            margin-right: 10px;
        }
    </style>
   <script type="text/javascript" src="../../js/jquery.min.js"></script>
   
    <script type="text/javascript" src="../../js/Validate.js"></script>
    <script type="text/javascript" src="../../js/jquery.corner.js"></script>
    <script type="text/javascript" src="../../js/jquery-impromptu.2.5.min.js"></script>
   <script type="text/javascript" src="../../js/common.js"></script>
    <script src="Javascript/AddUser.js" type="text/javascript"></script>
    <script type="text/javascript">
        function ChangeUserType() {
            var role = $("#ddl_UserType").val();
            
            if (role == "2") {
                $("#areaListDiv").html("");
                $("#DDL_department").hide();
                $("#cblDepartment").show();
            }
            else {
                $("#DDL_department").val("0");
                $("#DDL_department").show();
                $("#cblDepartment").hide();
            }

            var op = document.getElementById("ddl_UserType");
            var optxt = op.options[op.selectedIndex].text;
            if (optxt == "一级客户管理") {
                document.getElementById("Div1").style.display = "block";
                document.getElementById("Div2").style.display = "block";
            }
            else {
                document.getElementById("Div1").style.display = "none";
                document.getElementById("Div2").style.display = "none";
            }
        }

        function checkUserInfo() {

            if ($("#txt_UserName").val() == "") {
                $("#txt_UserName").focus();
                alert("请输入用户名");
                return false;
            }
            if ($("#txt_Pwd").val() == "") {
                $("#txt_Pwd").focus();
                alert("请输入登录密码");
                return false;
            }
            if ($("#ddl_UserType").val() == "0") {
                $("#ddl_UserType").focus();
                alert("请选择角色类型");
                return false;
            }
            GetUserAreas();
            return confirm("您确定要添加用户吗？");
        }

        function GetUserAreas() {
            var areas = "";
            $("#areaListDiv input[name='areaCB']:checked").each(function () {
                areas += $(this).val() + ",";
            })
            $("#hfArea").val(areas);
           
        }

       

        function GetAreaName(dept) {
            var dept = $("#DDL_department option:selected").text();
            
            var role = $("#ddl_UserType").val();
            if (role == "2") {
                $("#areaListDiv").html("");
            }
            else {
                var url = '../ashx/GetAreaBydepartMent.ashx';
                if (dept != "0") {
                    $.getJSON(url, { dept: dept }, function (list) {
                        
                        var div = "<ul class='areaList'>";
                        for (var i = 0; i < list.length; i++) {
                            if (list[i].ID != "0") {
                                div += "<li><input type='checkbox' name='areaCB' value='" + list[i].ID + "'/>" + list[i].IName + "</li>";
                            }

                        }
                        div += "</ul>";
                        $("#areaListDiv").html(div);
                    })
                }
                else {
                    $("#areaListDiv").html("");
                }
            }
            

        }

    </script>
</head>
<body style="font-size: 12px; background-position: center bottom; background-repeat: no-repeat;">
    <form id="form1" runat="server" onsubmit="return CheckAdd();">
    <div>
        <div style="font-size: 14px; font-weight: bold; text-align: left; padding-left: 20px;
            color: #c86000;">
            添加人员信息</div>
        <table class="table" style="margin-top: 20px; margin-left: 20px">
            <tr>
                <td style="width: 15%">
                    员工名称：
                </td>
                <td style="width: 35%" align="left">
                    <asp:TextBox ID="txt_UserName" runat="server" CssClass="txtwith" onblur="ValidUser();"></asp:TextBox>
                    <div id="msg" style="color: Red;">
                    </div>
                </td>
                <td style="width: 15%">
                    登录密码：
                </td>
                <td style="width: 35%" align="left">
                    <asp:TextBox ID="txt_Pwd" runat="server" CssClass="txtwith" TextMode="Password"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    性别：
                </td>
                <td align="left">
                    <asp:DropDownList ID="ddl_Sex" runat="server" CssClass="DDlstyle">
                        <asp:ListItem Text="男">男</asp:ListItem>
                        <asp:ListItem Text="女">女</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td>
                    角色类型：
                </td>
                <td align="left">
                    <asp:DropDownList ID="ddl_UserType" runat="server" onchange="ChangeUserType();" CssClass="DDlstyle">
                        <asp:ListItem Value="0">请选择角色类型</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>
                    部门名称：
                </td>
                <td colspan="3" style="text-align: left;">
                  <asp:DropDownList ID="DDL_department" runat="server" onchange=" GetAreaName();" >
                        <asp:ListItem Value="0">请选择部门名称</asp:ListItem>
                    </asp:DropDownList>
                    <asp:CheckBoxList ID="cblDepartment" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow" style="display:none;">
                    </asp:CheckBoxList>
                </td>
              
            </tr>
            <tr>
                <td>
                    区域名称：
                </td>
                <td colspan="3" style="text-align: left;">
                    <asp:HiddenField ID="hfArea" runat="server" />
                    <div id="areaListDiv">
                    </div>
                </td>
            </tr>
            <tr>
                <td>
                    电子邮件地址：
                </td>
                <td align="left">
                    <asp:TextBox ID="txt_UserMail" runat="server" CssClass="txtwith"></asp:TextBox>
                </td>
                <td>
                    邮政地址：
                </td>
                <td align="left">
                    <asp:TextBox ID="txt_UserAddress" runat="server" CssClass="txtwith"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    固定电话：
                </td>
                <td align="left">
                    <asp:TextBox ID="txt_UserPhone" runat="server" CssClass="txtwith"></asp:TextBox>
                </td>
                <td>
                    移动电话(必填)：
                </td>
                <td align="left">
                    <asp:TextBox ID="txt_UserMobile" runat="server" CssClass="txtwith"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    用户状态：
                </td>
                <td align="left">
                    <asp:DropDownList ID="ddl_UserStation" runat="server" CssClass="DDlstyle">
                        <asp:ListItem Value="1">在职</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td>
                    <div id="Div1" style="display: none;">
                        所属一级客户：</div>
                </td>
                <td>
                    <div id="Div2" style="display: none;">
                        <asp:DropDownList ID="DDL_dealerList" runat="server" CssClass="DDlstyle">
                            <asp:ListItem Value="0">请选择一级客户</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </td>
            </tr>
            <tr>
                <td style="height: 80px">
                    描述：
                </td>
                <td colspan="3" align="left">
                    <asp:TextBox ID="txt_UserDesc" runat="server" TextMode="MultiLine" Height="80px"
                        Width="320px" CssClass="txtwith"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td colspan="2" align="center">
                    <asp:Button ID="Button1" runat="server" Text="添 加" OnClientClick="return checkUserInfo()"
                        OnClick="Button1_Click" CssClass="qr0" />
                </td>
                <td colspan="2" align="center">
                    <input id="Reset1" type="reset" value="取 消" class="qr0" />
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
