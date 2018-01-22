<%@ Page Language="C#" AutoEventWireup="true" CodeFile="test.aspx.cs" Inherits="WebUI_GetBaseInfo_test" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>无标题页</title>
    <script language="javascript" type="text/javascript" src="../../js/jquery.min.js" ></script>
    <script language="javascript" type="text/javascript" >
    function Button2_onclick() {
         alert(document.getElementById("a_东区").value);
      }
    </script>

    <script src="autoComplete.js" type="text/jscript"></script>
    <style type="text/css">
    body{
    font-size:12px;
    }
    table{
    position:relative;
    }
    .ts{
    display:none;
    position:absolute;
    /*left:100px;
    top:55px;*/
    width:320px;
    background-color:#FFFFFF;
    border:1px solid #CC9900;
    text-align:center;
    }
    .ts a{
    display:block;
    height:25px;
    line-height:25px;
    cursor:pointer
    }
    .ts a:hover{
    background-color:#CCCCCC
    }
</style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:TextBox ID="txt_posID" runat="server"  onkeyup='showGs(event,"Base_shopInfo.aspx",txt_posID,txt_shopname,"ts")' ></asp:TextBox>
        <asp:TextBox ID="txt_shopname" runat="server"></asp:TextBox><div id="ts"  class="ts"></div><br />
        <asp:TextBox ID="a_东区" runat="server"></asp:TextBox><input id="Button2" type="button"
            value="button" onclick="return Button2_onclick()" />
        <asp:Button ID="Button1" runat="server" Text="Button" OnClick="Button1_Click" /></div>
    </form>
</body>
</html>
