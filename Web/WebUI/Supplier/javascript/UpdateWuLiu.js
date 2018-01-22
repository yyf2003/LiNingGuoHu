/*

 *author:秦浩 

 *Create date: 2009-05-18
 
 *Description: 更新指定物流公司联系人

*/

function UpdateWuLiuJS(id)
{
    this.id = id;
    this.name = $.trim($("#txtContactor"+id).val());
    this.photo = $.trim($("#txtContactorPhone"+id).val());
    this.URL = "./CallBack/UpdateWuLiu.ashx?" + new Date();   //接收客户端参数的服务器处理程序
}

UpdateWuLiuJS.prototype.Validate = function()
{
    if(this.name == "")
    {
        $.prompt("请您填写联系人！！");
        return false;
    }
    if(this.photo == "")
    {
        $.prompt("请您填写联系电话！！");
        return false;
    }
    return true;
}

UpdateWuLiuJS.prototype.updateMethod = function()
{
     $.get(this.URL,{id:this.id , name:this.name , photo:this.photo},
    //回调函数
    function(returnData){
       if(returnData != "0"){
            alert("修改成功！！");
            window.location = window.location;
       }
       else
       {
            $.prompt("更新失败！！  服务器忙，请稍后操作！！");
       }
    });
}
