/*

 *author:秦浩 

 *Create date: 2009-05-18
 
 *Description: 更新发货记录单状态

*/

function UpdateStateJS(id,userid)
{
    var checkValue ="";
    var radioLength = $('input:radio[@name=radio'+id+']');
    for(var i = 0; i < radioLength.length; i++)
    {
        if(radioLength[i].checked)
        {
            checkValue = radioLength[i].value;
            break;
        }
    }
    this.id = id;
    this.userid = userid;
    this.state = checkValue;
    this.remarks = $.trim($("#txt"+id).val());
    this.URL = "./CallBack/UpdateState.ashx?" + new Date();   //接收客户端参数的服务器处理程序
}

UpdateStateJS.prototype.Validate = function()
{
    if(this.remarks == "")
    {
        $.prompt("请您填写说明！！");
        return false;
    }
    return true;
}

UpdateStateJS.prototype.updateMethod = function()
{
     $.post(this.URL,{id:this.id , userid:this.userid, state:this.state , remarks:this.remarks},
    //回调函数
    function(returnData){
       if(returnData != "0"){
            alert("状态修改完成！！");
            window.location = window.location;
       }
       else
       {
            $.prompt("状态修改失败！！  服务器忙，请稍后操作！！");
       }
    });
}

