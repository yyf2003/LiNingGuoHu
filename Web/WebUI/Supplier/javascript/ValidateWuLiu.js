/*

 *author:秦浩 

 *Create date: 2009-05-13
 
 *Description: 添加物流表单验证

*/
function ValidateInput()
{
    var txtSupplierName = $.trim($("#txtSupplierName").val());
    var txtContacter = $.trim($("#txtContacter").val()); 
    var txtContactPhone = $.trim($("#txtContactPhone").val());
    var txtRemarks = $.trim($("#txtRemarks").val());
    
    function FocusSupplierName(){$("#txtSupplierName").focus();}
    function FocusContacter(){$("#txtContacter").focus();}
    function FocusContactPhone(){$("#txtContactPhone").focus();}

    if(txtSupplierName == "")
    {
        $.prompt('请输入物流公司名称！！', {callback:FocusSupplierName});
        return false;
    }
    
    if(txtContacter == "")
    {
        $.prompt('请输入物流联系人！！', {callback:FocusContacter});
        return false;
    }
    
    if(txtContactPhone == "")
    {
        $.prompt('请输入联系人电话！！', {callback:FocusContactPhone});
        return false;
    }
    return true;
    
}



