<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Supplier_MateriaPrice.aspx.cs" Inherits="WebUI_Supplier_Supplier_MateriaPrice" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>无标题页</title>
        <link href="../../CSS/TableCss.css" rel="stylesheet" type="text/css" />
<script src="../../js/Validate.js" type="text/javascript"></script>
 <script language="javascript" type="text/javascript">
        
        function checkdate(obj)
        {
            if(document.getElementById(obj).value!="")
            {
                   if(!isnumber(document.getElementById(obj).value))
                   {
                      alert(" 材料价格为数字！请正确填写");
                      document.getElementById(obj).focus();
                      return false;
                   }
                   if(document.getElementById(obj).value<0)
                   {
                      alert(" 材料价格应大于等于0！");
                      document.getElementById(obj).focus();
                      return false;
                   }
            }
   
        }
        </script>
</head>
<body >
<form id="form1" runat="server">
<div>
<div style=" padding-left:20px; ">
    <div style=" font-size:14px; font-weight:bold; text-align:left;width:50%; height:30px;color: #c86000;"><%=suppliername %>  维护材料价格</div>
    <br />
    <div class="table" style="width:55%; text-align:center">
        <asp:GridView ID="GridView1" runat="server" Width="95%" AutoGenerateColumns="False" OnRowDataBound="GridView1_RowDataBound">
            <Columns>
                <asp:BoundField HeaderText="材料名称" DataField="MateriaPro" />
                <asp:TemplateField HeaderText="维护价格">
                    <ItemTemplate>
                        &nbsp;<asp:TextBox ID="txt_price" onblur="checkdate(this.id)" onKeyDown="if(event.keyCode==13) event.keyCode=9;" Text="<%#Bind('POPprice') %>" runat="server"></asp:TextBox>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="MateriaID" />
            </Columns>
        </asp:GridView>
        <br />
        <asp:Button ID="btn_update" runat="server" CssClass="qr0" OnClientClick="return confirm('确认更改价格？');" Text="更新价格" OnClick="btn_update_Click" />
    </div>
    </div>
</div>
</form>
</body>
</html>
