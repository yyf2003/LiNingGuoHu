/*

 *author:秦浩 

 *Create date: 2009-05-19
 
 *Description: 发货记录单表单验证

*/
function ValidateInput()
{
    var txtPOPID = $.trim($("#txtPOPID").val());              //POP发起ID
    var txtPOPCount = $.trim($("#txtPOPCount").val());        //P O P 数 量
    var ddlCompanyName = $.trim($("#ddlCompanyName").val());  //物 流 公 司
    var ddlDealerName = $.trim($("#ddlDealerName").val());    //收货一级客户
    var txtGoodsOrderNO = $.trim($("#txtGoodsOrderNO").val());//发 货 单 号
    
    function FocusPOPID(){$("#txtPOPID").focus();}
    function FocusPOPCount(){$("#txtPOPCount").focus();}
    function FocusCompanyName(){$("#ddlCompanyName").focus();}
    function FocusDealerName(){$("#ddlDealerName").focus();}
    function FocusGoodsOrderNO(){$("#txtGoodsOrderNO").focus();}

    if(txtPOPID == "")
    {
        $.prompt('没有发现最新发起的POP，不能添加发货记录单！！', {callback:FocusPOPID});
        return false;
    }
    
    if(txtPOPCount == "")
    {
        $.prompt('请输入 P O P 数量！！', {callback:FocusPOPCount});
        return false;
    }
    else if(!isint(txtPOPCount))
    {
    	$.prompt('P O P 数量必须输入整数！！', {callback:FocusPOPCount});
        return false;

    }
    
    if(ddlCompanyName == "0")
    {
        $.prompt('请选择物流公司！！', {callback:FocusCompanyName});
        return false;
    }
    
    if(ddlDealerName == "0")
    {
        $.prompt('请选择收货一级客户！！', {callback:FocusDealerName});
        return false;
    }
    
    if(txtGoodsOrderNO == "")
    {
        $.prompt('请输入发货单号！！', {callback:FocusGoodsOrderNO});
        return false;
    }
    
    return true;
    
}


