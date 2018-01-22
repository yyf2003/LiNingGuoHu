// 添加供应商材料
function AddSupplierMaterial()
{
    this.addURL = "./CallBack/AddSupplierMaterial.ashx?" + new Date();   //添加材料的服务器处理程序
    this.updateURL = "./CallBack/updateSupplierMaterial.ashx?" + new Date();   //修改材料的服务器处理程序 
    this.IsDeleteURL = "./CallBack/IsDeleteMaterial.ashx?" + new Date();   //更新材料状态的服务器处理程序
}

//添加材料信息
AddSupplierMaterial.prototype.Add = function(id,name,cltype)
{ 
     $.get(this.addURL,{uID:id,name:name,ctype:cltype},
    //回调函数
    function(returnData){
       if(parseInt(returnData) > 0)
       {
            alert("添加成功！！");
            window.location = window.location;
       }
       else
       {
           alert('您输入的材料已经存在！！');
            $("#showPrompt").css("display","none");
            return false;
       }
    });
   
}

//修改材料信息
AddSupplierMaterial.prototype.Update = function(mid,mname)
{ 
     $.get(this.updateURL,{mID:mid,name:mname},
    //回调函数
    function(returnData){
       if(parseInt(returnData) > 0)
       {
            alert("修改成功！！");
            window.location = window.location;
       }
       else
       {
           alert('服务器忙，请稍后更新！！');
            $("#showPrompt").css("display","none");
            return false;
       }
    });
}

//更新材料状态
AddSupplierMaterial.prototype.IsDelete = function(mid,IsDe)
{
    $.get(this.IsDeleteURL,{mID:mid,isDelete:IsDe},
    //回调函数
    function(returnData){
       if(parseInt(returnData) > 0)
       {
            alert("修改状态成功！！");
            window.location = window.location;
       }
       else
       {
            alert('服务器忙，请稍后更新！！');
            $("#showPrompt").css("display","none");
            return false;
       }
    });
}