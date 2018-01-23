<%@ Page Language="C#" AutoEventWireup="true" CodeFile="login1.aspx.cs" Inherits="login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
     <asp:Label ID="Label3" runat="server" Text="欢迎！"></asp:Label>
    <table>
    <tr>
    <td>
        <asp:Label ID="Label1" runat="server" Text="用户名："></asp:Label></td>
      <td>  <asp:TextBox ID="TextBox1" runat="server" MaxLength="50"></asp:TextBox></td>
      
        </tr>
        <tr>
       <td> <asp:Label ID="Label2" runat="server" Text="密码："></asp:Label></td>
       <td> <asp:TextBox ID="TextBox2" runat="server" MaxLength="50" TextMode="Password"></asp:TextBox>
           <br />
           <asp:Button ID="Button1" runat="server" onclick="Button1_Click" Text="注册" />
            <asp:Button ID="Button2" runat="server" onclick="Button2_Click" Text="登录" />
            </td>
        </tr>
        </table>
    
    </div>
    </form>
</body>
</html>
