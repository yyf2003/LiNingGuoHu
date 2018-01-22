// JScript 文件

/**** CheckUserlgoin     ****/



 function CheckUser()
     { 
       var user =$("#idname").val();
       var pwd =$("#password").val();
    if(user=="") 
   {
       $.prompt('请输入登录用户名!', {callback:focusUser});
        return false; 
   } 
    if(pwd=="") 
  {
      $.prompt('请输入登录密码!', {callback:focuspwd});
     return false; 
   }    
  
   $.post("WebUI/ashx/CheckUserLogin.ashx",{User:user,Pwd:pwd},function(data){
    if(data.length>0) 
    if(data=="fail")
   {
       $.prompt('用户名字或密码错误！');   
         return false;
   }  
   }) ;
  } 
   
       
        function focusUser()
       {
        $("#idname").focus();
       } 
            function focuspwd()
       {
        $("#password").focus();
       } 
  