/*

 *author:秦浩 

 *Create date: 2009-05-13
 
 *Description: 添加供应商人员表单验证

*/
function ValidateInput()
{
    var txtUserName = $.trim($("#txtUserName").val());              //用户名称
     //var txtPassWord = $.trim($("#txtPassWord").val());              //密码
    var txtEmail = $.trim($("#txtEmail").val());                    //电子邮件
    var txtMob = $.trim($("#txtMob").val());                        //移动电话
    
    function FocusUserName(){$("#txtUserName").focus();}
    function FocusPassWord(){$("#txtPassWord").focus();}
    function FocusEmail(){$("#txtEmail").focus();}
    function FocusMob(){$("#txtMob").focus();}

    if(txtUserName == "")
    {
        $.prompt('请输入员工名称！！', {callback:FocusUserName});
        return false;
    }
    
//    if(txtPassWord == "")
//    {
//        $.prompt('请输入员工密码！！', {callback:FocusPassWord});
//        return false;
//    }
    
    if(txtEmail == "")
    {
        $.prompt('请输入电子邮件地址！！', {callback:FocusEmail});
        return false;
    }
    else
    {
        if(!isemail(txtEmail))
        {
            $.prompt('您输入的电子邮件格式不正确！！', {callback:FocusEmail});
            return false;
        }
    }
    
    if(txtMob == "")
    {
        $.prompt('请输入移动电话！！', {callback:FocusMob});
        return false;
    }
    else
    {
        if(!isMob(txtMob))
        {
            $.prompt('您输入的移动电话格式不正确！！', {callback:FocusMob});
            return false;
        }
    }
    return true;
    
}


