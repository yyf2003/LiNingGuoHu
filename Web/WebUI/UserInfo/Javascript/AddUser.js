// JScript 文件

function ValidUser() {
    var User = $("#txt_UserName").val();
    
    $("#msg").html("");
    if (User != "") {

        $.ajax({
            type: "get",
            url: "../ashx/CheckAddUser.ashx?UserName=" + escape(User),
            cache: false,
            success: function (data) {
                if (data.length>0) {
                    $("#msg").html(data);
                }
            }
        })
    }
}

function CheckAdd() {
    var txt_UserName = $("#txt_UserName").val();
    if (txt_UserName == "") {
        $.prompt("人员名称不能为空!");
        $("#txt_UserName").focus();
        return false;
    }
    var txt_Pwd = $("#txt_Pwd").val();
    if (txt_Pwd == "") {
        $.prompt("人员登录密码为空!");
        $("#txt_Pwd").focus();
        return false;
    }
    var usertype = document.getElementById("ddl_UserType");
    var typetxt = usertype.options[usertype.selectedIndex].value;
    if (typetxt == "0") {
        $.prompt("请选择用户职位类型!");
        return false;
    }
    var role = $("#ddl_UserType").val();
    if (role != "2") {
        if ($("#hfArea").val() == "") {
            $.prompt("请选择区域名称!");
            return false;
        }
    }
    
    var txt_UserMail = $("#txt_UserMail").val();
    if (txt_UserMail == "") {
        $.prompt("电子邮件地址为空!");
        $("#txt_UserMail").focus();
        return false;
    }
    if (!isemail(txt_UserMail)) {
        $.prompt("电子邮件地址不合法!");
        $("#txt_UserMail").focus();
        return false;
    }
    var txt_UserAddress = $("#txt_UserAddress").val();
    if (txt_UserAddress == "") {
        $.prompt("用户所在地址为空!");
        $("#txt_UserAddress").focus();
        return false;
    }
    var txt_UserMobile = $("#txt_UserMobile").val();
    if (txt_UserMobile == "") {
        $.prompt("用户移动电话不能为空!");
        $("#txt_UserMobile").focus();
        return false;
    }

    var div2 = document.getElementById("Div2").style.display;
    if (div2 == "block") {
        var op = document.getElementById("DDL_dealerList");
        var opid = op.options[op.selectedIndex].value;
        if (opid == "0") {
            $.prompt("请选择一级客户名称!");
            return false;
        }
    }

}