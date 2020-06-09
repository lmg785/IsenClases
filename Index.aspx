<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="IsenClases.Views.Index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server" method="post">
        <div>
            <h1>LOGIN</h1>
            Usuario:<br />
            <input type="text" id="Username" name="Username" value="" /><br />
            Password:<br />
            <input type="text" id="Password" name="Password" value="" /><br /><br />
            <input type="submit" value="Submit" class="submit" />
        </div>
    </form>
</body>
</html>
