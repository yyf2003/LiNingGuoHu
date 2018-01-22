<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SupplierReportList.aspx.cs" Inherits="WebUI_ReportDamage_SupplierReportList" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <link rel="stylesheet" media="all" type="text/css" href="../../css/TableCss.css" />
    <link rel="stylesheet" media="all" type="text/css" href="../../css/examples.css" /> 
    
    <style>
   a:link{text-decoration :none; color:#424242;}
   a:visited{text-decoration :none;color:#424242;}
   a:active{text-decoration :none;}
   a:hover{text-decoration :underline;}  
    </style>
    <!-- Can't miss  begin -->

    <script language="javascript" type="text/javascript" src="../../js/calendar.js"></script>

    <script type="text/javascript" src="../../js/jquery-1.3.2.min.js"></script>

    <script type="text/javascript" src="../../js/jquery.corner.js"></script>

    <script type="text/javascript" src="../../js/jquery-impromptu.2.5.min.js"></script>

    <script type="text/javascript" src="../../js/common.js"></script>
    <script type="text/javascript" src="../../js/ShowImg.js"></script>
  
    <script>
     
     var dt1="";
     var dt2=""; 
     var  satation ="";
     var arry ="";
     var d1="";
     var d2="";
     var shopid=<%#ShopID %>;
     function CheckTime()
     {
        d1 =$("#txtStartTime").val();
        d2 =$("#txtEndTime").val(); 
     arry ="";
    if(d1!="")
   {
      var arr1 =d1.toString ().split ('-'); 
      if(d2!="")
     { 
      var arr2 =d2.toString ().split ('-');   
      dt1 =new Date(arr1[0],arr1[1],arr1[2]);
      dt2 =new Date(arr2[0],arr2[1],arr2[2]); 
     if(dt1-dt2>0)
     {
       $.prompt("结束时间不能小于开始时间！",{callback:timefocus});
       return false;
     } 
     } 
     else
     {
         $.prompt("请选择结束时间！",{callback:timefocus});
        return false; 
     } 
   }  
    
   satation =$("#vmstation").val(); 
   if(d1!="")
  {
    arry ="&StartTime="+d1;
  
     if(d2!="")
     {
        arry +="&EndTime="+d2;
     } 
     if(satation!="")
     {
        arry +="&Station="+satation; 
     }  
  }   
  else
  {
       if(satation!="")
       {
      arry ="&Station="+satation; 
       }
  }  
  alert(arry);
 location.href ="ShowReportDamage.aspx?ShopID="+shopid+arry;
 
     } 
      function timefocus()
  {
   $("txtEndTime").focus(); 
  }  
     
    </script> 

    <!--  end-->
    <title>POP报损信息</title>
</head>
<body>
    <form id="form1" runat="server">
        <table cellpadding="0" cellspacing="0" border="0" class="table">
            <tr>
                <td>
                    POP报损信息-<%#ShopName %>
                </td>
            </tr>
        </table>
        <table cellpadding="0" cellspacing="0" border="0" class="table" style="margin-top: 3px;">
            <tr>
                <td width="100px">
                    开始时间:
                </td>
                <td width="350px">
                    <input id="txtStartTime" type="text" onclick="setday(this,document.getElementById('txtStartTime'))"
                        readonly="readOnly" />
                </td>
                <td width="100px">
                    结束时间:
                </td>
                <td>
                    <input id="txtEndTime" type="text" onclick="setday(this,document.getElementById('txtEndTime'))"
                        readonly="readOnly" />
                </td>
            </tr>
            <tr>
                <td width="100px">
                    状态：
                </td>
                <td>
                    <select id="vmstation">
                        <option value="0">未通过</option>
                        <option value="1">通过</option>
                    </select>
                </td>
                <td colspan="2">
                    <input id="Button1" type="button" value="查询" class="qr0" onclick="return CheckTime();" /></td>
            </tr>
        </table>
        <div class="table" style="margin-top: 3px;  ">
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false" Width="899px"
                AllowPaging="True" OnPageIndexChanging="GridView1_PageIndexChanging">
                <Columns>
                    <asp:TemplateField HeaderText=" 编号">
                        <ItemTemplate>
                            <%#GetShopPosCodeWithShopID(Eval("ShopID").ToString ())%>
                        </ItemTemplate>
                        <HeaderStyle Width="10%" />
                        <ItemStyle Width="10%" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="店铺名称">
                        <ItemTemplate>
                            <%#GetShopName(Eval("ShopID").ToString())%>
                        </ItemTemplate>
                        <HeaderStyle Width="18%" />
                        <ItemStyle Width="18%" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="提交人">
                        <ItemTemplate>
                            <%#GetUserName(Eval("UpUserID").ToString())%>
                        </ItemTemplate>
                        <HeaderStyle Width="12%" />
                        <ItemStyle Width="12%" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="图片">
                        <ItemTemplate>
                            <%#Eval("PhotoPath").ToString() == "" ? "" : "<img src='../" + Eval("PhotoPath") + "' / width='22' height='22' alt='" + Eval("ShopDesc") + "' border='0'  style=\"cursor :pointer;\" onclick=\"javascript:ShowImg('40%','40%','600px','50px','450px','[店铺详情]',this.src)\">"%>
                        </ItemTemplate>
                        <HeaderStyle Width="4%" />
                        <ItemStyle Width="4%" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="提交时间">
                        <ItemTemplate>
                            <%#Eval("UpPOPDate")%>
                        </ItemTemplate>
                        <HeaderStyle Width="18%" />
                        <ItemStyle Width="18%" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="描述">
                        <ItemTemplate>
                            <textarea id="textareashopdesc" cols="20" rows="2" style="width: 160px; height: 60px;"
                                readonly="readonly"><%#Eval("ShopDesc")%></textarea>
                        </ItemTemplate>
                        <HeaderStyle Width="15%" />
                        <ItemStyle Width="15%" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="VM描述">
                        <ItemTemplate>
                            <textarea id="textareacheck<%#Eval("ID") %>" cols="20" rows="2" style="width: 160px;
                                height: 60px;" <%#Eval("vmdesc").ToString()==""?"":"readonly='readonly'" %>><%#Eval("VMDesc") %></textarea>
                        </ItemTemplate>
                        <HeaderStyle Width="15%" />
                        <ItemStyle Width="15%" />
                    </asp:TemplateField>
                 
                </Columns>
            </asp:GridView>
        </div>
    </form>
</body>
</html>
