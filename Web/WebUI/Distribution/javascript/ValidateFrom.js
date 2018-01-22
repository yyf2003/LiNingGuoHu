// JScript 文件
function ValidateInput()
{
    var txtFXID = $.trim($("#txtFXID").val());                      //直属客户编号
    var txtFXName = $.trim($("#txtFXName").val());                  //直属客户名称
    var txtFXContactor = $.trim($("#txtFXContactor").val());        //联系人名称
    var txtFXPhone = $.trim($("#txtFXPhone").val());                //联系人电话
    var txtFXtel = $.trim($("#txtFXtel").val());                    //直属客户电话
    var txtFXAddress = $.trim($("#txtFXAddress").val());            //配送地址
    var txtAreaID=$("#DDL_Area").val();
    var txtProID=$("#DDL_Province").val();
    var txtCityID=$("#DDL_city").val();
    function FocusFXID(){$("#txtFXID").focus();}
    function FocusFXName(){$("#txtFXName").focus();}
    function FocusFXAddress(){$("#txtFXAddress").focus();}
    
    function FocusAreaID(){$("#DDL_Area").focus();}
    function FocusProID(){$("#DDL_Province").focus();}
    function FocusCityID(){$("#DDL_city").focus();}

    if(txtFXID == "")
    {
        $.prompt('请输入直属客户编号！！', {callback:FocusFXID});
        return false;
    }
    
    if(txtFXName == "")
    {
        $.prompt('请输入直属客户名称！！', {callback:FocusFXName});
        return false;
    }
    
    if(txtFXAddress == "")
    {
        $.prompt('请输入直属客户配送地址！！', {callback:FocusFXName});
        return false;
    }
    if(txtAreaID=="0")
     {
        $.prompt('请选择区域名称！！', {callback:FocusAreaID});
        return false;
    }
   if(txtProID=="0")
   {
        $.prompt('请选择省市名称！！', {callback:FocusProID});
        return false;
    }
   if(txtCityID=="0")
    {
        $.prompt('请选择地级城市名称！！', {callback:FocusCityID});
        return false;
    }
    
    /*if(txtFXContactor == "")
    {
        $.prompt('请输入联系人名称！！', {callback:FocusFXContactor});
        return false;
    }

    if(txtFXPhone == "")
    {
        $.prompt('请输入联系人电话！！', {callback:FocusFXPhone});
        return false;
    }

    if(txtFXtel == "")
    {
        $.prompt('请输入直属客户电话！！', {callback:FocusFXtel});
        return false;
    }*/

    
    return true;
    
}


