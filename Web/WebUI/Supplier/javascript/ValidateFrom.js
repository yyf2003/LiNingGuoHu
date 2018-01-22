// JScript 文件
function ValidateInput()
{
    var txtSupplierName = $.trim($("#txtSupplierName").val());      //供应商名称
    var ddlContacter = $.trim($("#ddlContacter").val());            //联系人
    var txtContactPhone = $.trim($("#txtContactPhone").val());      //联 系 电  话
    var txtContacterRole = $.trim($("#txtContacterRole").val());    //联系人职位
    
    var txtPostCode = $.trim($("#txtPostCode").val());              //邮 政 编 码
    var txtPostAddress = $.trim($("#txtPostAddress").val());        //邮 政 地 址
    var txtStaffNum = $.trim($("#txtStaffNum ").val());        		//员 工 数 量
    
    function FocusSupplierName(){$("#txtSupplierName").focus();}
    function FocusContacter(){$("#ddlContacter").focus();}
    function FocusContactPhone(){$("#txtContactPhone").focus();}
    function FocusContacterRole(){$("#txtContacterRole").focus();}
    function FocusPostCode(){$("#txtPostCode").focus();}
    function FocusPostAddress(){$("#txtPostAddress").focus();}
    function FocusStaffNum(){$("#txtStaffNum").focus();}

    if(txtSupplierName == "")
    {
        $.prompt('请输入供应商名称！！', {callback:FocusSupplierName});
        return false;
    }
    
    if(ddlContacter == "0")
    {
        $.prompt('请选择负责人！！', {callback:FocusContacter});
        return false;
    }
    
    if(txtContactPhone == "")
    {
        $.prompt('请输入移动电话！！', {callback:FocusContactPhone});
        return false;
    }
    else
    {
        if(!isMob(txtContactPhone))
        {
            $.prompt('您输入的移动电话格式不正确！！', {callback:FocusContactPhone});
            return false;
        }
    }
    
    if(txtContacterRole == "")
    {
        $.prompt('请输入联系人职位！！', {callback:FocusContacterRole});
        return false;
    }

    
    if(txtPostCode == "")
    {
        $.prompt('请输入邮政编码！！', {callback:FocusPostCode});
        return false;
    }
    else
    {
        if(!ispostcode(txtPostCode))
        {
            $.prompt('您输入的邮政编码格式不正确！！', {callback:FocusPostCode});
            return false;
        }
    }
    
    if(txtPostAddress == "")
    {
        $.prompt('请输入邮政地址！！', {callback:FocusPostAddress});
        return false;
    }
    
    if(txtStaffNum == "")
    {
        $.prompt('请输入员工数量！！', {callback:FocusStaffNum});
        return false;
    }
    else if(!isint(txtStaffNum))
    {
    	$.prompt('员工数量必须输入整数！！', {callback:FocusStaffNum});
        return false;

    }

    
    return true;
    
}


