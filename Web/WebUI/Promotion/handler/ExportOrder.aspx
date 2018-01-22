<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ExportOrder.aspx.cs" Inherits="WebUI_Promotion_handler_ExportOrder" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="../../../js/jquery-1.7.2.js" type="text/javascript"></script>
    <script type="text/javascript">
        function go() {
            window.parent.Cancel();
        }
        function go1() {
            alert("ddd");
            window.parent.CancelLoading();
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
    </div>
    </form>
</body>
</html>
