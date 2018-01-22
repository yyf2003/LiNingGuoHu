// JScript 文件

function checkposcode(poscode)
{
 
   if(poscode.length>0)
   {
       $.get('Shopashx/PostIDExists.ashx',{posid:poscode},function(data){
         if(data=='false')
         {
           alert('此编号已经存在？');
           $('#Btn_Save').attr('disabled','disabled');
         }
         else
         {
             $('#Btn_Save').attr('disabled','');
         }
       }
       );
   }
}