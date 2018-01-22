/*

 *author:秦浩 

 *Create date: 2009-05-14
 
 *Description: 获取用户权限列表以及权限页面

*/
function GetRoleListJS()
{
    this.roleURL = "./CallBack/GetRoleList.ashx?" + new Date();   //接收客户端参数的服务器处理程序（获取权限列表）
    this.rolePageURL = "./CallBack/GetRolePageList.ashx?" + new Date();   //接收客户端参数的服务器处理程序（获取权限页面列表）
}

GetRoleListJS.prototype.GetList = function()
{ 
     $.get(this.roleURL,{},
    //回调函数
    function(returnData){
       if(returnData != ""){
            $("#roleList").html("<span style=\"font-weight:bold;\">现有角色：</span><br />" + returnData + "<br /><br />");
       }
    });
}


GetRoleListJS.prototype.GetRolePageList = function(roleID)
{
    $("#showWait").show();
    $.getJSON(this.rolePageURL,{id:roleID},function(list){
    
                var strJS = ""; //显示列表
                strJS += "d = new dTree('d');";
                strJS += "d.add(0,-1,'李宁POP管理系统 权限分配');";
                for(var i = 0; i < list.length; i++)
                {
                    if(list[i].LevelNum == "1")
                        strJS += "d.add("+list[i].id+",0,'"+list[i].funcName+"','#'); ";
                    else if(list[i].LevelNum == "2")
                    {
                        if(list[i].IsCheck == "1")
                            strJS += "d.add("+list[i].id+","+list[i].upId+",'<input id=\"node"+list[i].id+"\" name=\"node"+list[i].id+"\" checked=\"checked\" type=\"checkbox\" value=\""+list[i].id+"\" style=\" border:0px \" />&nbsp;<span style=\"height:17px;\">"+list[i].funcName+"</span>','#','','','../../images/tree/html.gif');";
                        else
                            strJS += "d.add("+list[i].id+","+list[i].upId+",'<input id=\"node"+list[i].id+"\" name=\"node"+list[i].id+"\" type=\"checkbox\" value=\""+list[i].id+"\" style=\" border:0px \" />&nbsp;<span style=\"height:17px;\">"+list[i].funcName+"</span>','#','','','../../images/tree/html.gif');";
                    }
                }
                strJS += "document.getElementById('FunctionList').innerHTML ='<span style=\"font-weight:bold;\">功能列表：</span><br /><br />' + d + '<br /><br />'; ";
                strJS += "d.openAll();";
                eval(strJS);
                $("showWait").hide();
    });
}

GetRoleListJS.prototype.SubmitRolePage = function()
{ 
    var roleID = "";    //权限编号
    var pageID = "";    //功能编号列表
    var url = "./CallBack/SubmitRoleAndPower.ashx?" + new Date();
    var objRadio = $("#roleList :input[type='radio']");
    var objCheck = $("#FunctionList :input[type='checkbox']");
    for(var i = 0; i < objRadio.length; i++)
    {
       if(objRadio[i].checked)
       {
           roleID = objRadio[i].value;
           break;
       }
    }
    for(var i = 0; i < objCheck.length; i++)
    {
       if(objCheck[i].checked)
           pageID += objCheck[i].value + ",";
    }
    if($.trim(pageID) != "")
    {
         $.get(url,{rid : roleID , pid : pageID},function(returnData){
           if(returnData != "0"){
                alert("分配成功！！")
                window.location = window.location;
           }
           else{
                alert("分配失败！！")
                return false;
           }
        });
    }
    else
    {
        alert("请选择功能页面！！");
        return false;
    }
}

