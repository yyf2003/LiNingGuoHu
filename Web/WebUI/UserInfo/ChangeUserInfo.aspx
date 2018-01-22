<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ChangeUserInfo.aspx.cs" Inherits="WebUI_UserInfo_ChangeUserInfo" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>修改个人信息</title>
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
    <link rel="stylesheet" media="all" type="text/css" href="../../css/examples.css" />
    <link rel="stylesheet" media="all" type="text/css" href="../../css/TableCss.css" />
    <script type="text/javascript" src="../../js/jquery.min.js"></script>
    <script type="text/javascript" src="../../js/Validate.js"></script>
    <script type="text/javascript" src="Javascript/AddUser.js"> </script>
    <script type="text/javascript" src="../../js/GetAreaBydept.js"></script>
    <!-- Can't miss  begin -->
    <script type="text/javascript" src="../../js/jquery.corner.js"></script>
    <script type="text/javascript" src="../../js/jquery-impromptu.2.5.min.js"></script>
    <script type="text/javascript" src="../../js/common.js"></script>
    <!--  end-->
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
            if (optxt == "一级客户") {
                document.getElementById("Div1").style.display = "block";
                document.getElementById("Div2").style.display = "block";
            }
            else {
                document.getElementById("Div1").style.display = "none";
                document.getElementById("Div2").style.display = "none";
            }
        }

        $(function () {
            ChangeUserType();
            GetAreaName();
        })

        function GetAreaName() {
            var dept = $("#DDL_department option:selected").text();
            var role = $("#ddl_UserType").val();
            if (role == "2") {
                $("#areaListDiv").html("");
            }
            else {
                var oldAreas = $("#oldAreas").val();
                
                var arr = [];
                if ($.trim(oldAreas) != "") {
                    arr = oldAreas.split(',');
                }
                
                var url = '../ashx/GetAreaBydepartMent.ashx';
                if (dept != "0") {
                    $.getJSON(url, { dept: dept }, function (list) {

                        var div = "<ul class='areaList'>";
                        for (var i = 0; i < list.length; i++) {
                            if (list[i].ID != "0") {
                                var select = "";
                                for (var j = 0; j < arr.length; j++) {
                                    if (parseInt(list[i].ID) == parseInt(arr[j])) {
                                        select = "checked='checked'";
                                    }
                                }
                                div += "<li><input type='checkbox' name='areaCB' value='" + list[i].ID + "' " + select + "/>" + list[i].IName + "</li>";
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


        function check() {
            if ($.trim($("#msg").html()) != "") {
                alert("员工名称已存在");
                return false;
            }
            if ($("#ddl_UserType").val() == "0") {
                $("#ddl_UserType").focus();
                alert("请选择角色类型");
                return false;
            }
            if ($("#DDL_department").val() == "0") {
                $("#DDL_department").focus();
                alert("请选择部门");
                return false;
            }
            if ($("#ddl_UserType").val() != "2") {
                GetUserAreas();
                if ($.trim($("#hfAreas").val()) == "") {
                    alert("请选择区域");
                    return false;
                }
            }
            
            return confirm("您确定要修改吗？");
        }
        function GetUserAreas() {
            var areas = "";
            $("#areaListDiv input[name='areaCB']:checked").each(function () {
                areas += $(this).val() + ",";
            })
            $("#hfAreas").val(areas);

        }


        function ValidUser() {
            var User = $.trim($("#txt_UserName").val());
            var userId = '<%=UserID %>';
            $("#msg").html("");
            if (User != "") {
                $.ajax({
                    type: "get",
                    url: "../ashx/CheckAddUser.ashx?UserName=" + escape(User) + "&UserId=" + userId,
                    cache:false,
                    success: function (data) {
                        if (data != "可以注册") {
                            $("#msg").html(data);
                        }
                    }
                })

            }
        }
    </script>
</head>
<body>
    <form id="form1" runat="server" onsubmit="return CheckAdd();">
    <div style="width: 90%">
        <div style="font-size: 14px; font-weight: bold; text-align: left; padding-left: 20px;
            color: #c86000;">
            <a href="UserList.aspx" title="人员信息管理" style="color: #c86000;">人员信息管理</a> &gt;&gt;
            修改员工信息</div>
            
        <table class="table" style="margin-top: 20px; margin-left: 5%">
            <tr>
                <td style=" width:15%;">
                    员工名称
                </td>
                <td align="left">
                    <asp:TextBox ID="txt_UserName" runat="server" CssClass="txtwith" onblur="ValidUser()"></asp:TextBox>
                    <div id="msg" style="color: Red;">
                    </div>
                </td>
                <td style="width: 15%">
                    登录密码
                </td>
                <td align="left">
                    <asp:TextBox ID="txt_Pwd" runat="server" CssClass="txtwith"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    性别
                </td>
                <td align="left">
                    <asp:DropDownList ID="ddl_Sex" runat="server" CssClass="DDlstyle">
                        <asp:ListItem Value="男">男</asp:ListItem>
                        <asp:ListItem Value="女">女</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td>
                    角色类型
                </td>
                <td align="left">
                    <asp:DropDownList ID="ddl_UserType" runat="server" CssClass="DDlstyle" onchange="ChangeUserType();">
                        <asp:ListItem Value="0">请选择角色类型</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>
                    部门名称：
                </td>
                <td colspan="3">
                    
                     <asp:DropDownList ID="DDL_department" runat="server" onchange="GetAreaName();">
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
                    <asp:HiddenField ID="hfAreas" runat="server" />
                    <asp:HiddenField ID="oldAreas" runat="server" />
                    <div id="areaListDiv">
                    </div>
                </td>
            </tr>
            <tr>
                <td>
                    电子邮件地址
                </td>
                <td align="left">
                    <asp:TextBox ID="txt_UserMail" runat="server" CssClass="txtwith" Text=''></asp:TextBox>
                </td>
                <td>
                    所在地
                </td>
                <td align="left">
                    <asp:TextBox ID="txt_UserAddress" runat="server" CssClass="txtwith"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    家庭电话
                </td>
                <td align="left">
                    <asp:TextBox ID="txt_UserPhone" runat="server" CssClass="txtwith"></asp:TextBox>
                </td>
                <td>
                    移动电话
                </td>
                <td align="left">
                    <asp:TextBox ID="txt_UserMobile" runat="server" CssClass="txtwith"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="height: 34px">
                    用户状态
                </td>
                <td align="left" style="height: 34px">
                    <asp:RadioButtonList ID="rblState" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow">
                        <asp:ListItem Value="1">在职 </asp:ListItem>
                        <asp:ListItem Value="2">离职 </asp:ListItem>
                    </asp:RadioButtonList>
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
            <tr height="80px">
                <td>
                    描述
                </td>
                <td colspan="3" align="left">
                    <asp:TextBox ID="txt_UserDesc" runat="server" TextMode="MultiLine" Height="80px"
                        Width="320px" CssClass="txtwith"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td colspan="4" align="center">
                    <asp:Button ID="Button1" runat="server" Text="确认修改" OnClick="Button1_Click" CssClass="qr0" OnClientClick="return check()"/>
                    &nbsp;&nbsp;
                    <input id="Button2" type="button" value="返 回" class="qr0" onclick="javascript:if(window.history.length==0) window.close();else window.history.back();" />
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
