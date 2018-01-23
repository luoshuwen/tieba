<%@ Page Language="C#" AutoEventWireup="true" CodeFile="find.aspx.cs" Inherits="find" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
     <asp:Label ID="Label6" runat="server" Text="当前用户："></asp:Label>
        <asp:Label ID="labelusername" runat="server" Text="游客"></asp:Label>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<a href="card.aspx?"><asp:Label ID="Label8" runat="server" Text="贴吧首页"></asp:Label></a>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="Button2" runat="server" onclick="Button2_Click" Text="注册" />
        <asp:Button ID="Button3" runat="server" onclick="Button3_Click" Text="登录" />
        <asp:Button ID="Button4" runat="server" Enabled="False" onclick="Button4_Click" 
            Text="注销" />
        <br />
        <asp:DropDownList ID="DropDownList1" runat="server" Height="20px" Width="168px">
            <asp:ListItem>标题 </asp:ListItem>
            <asp:ListItem>用户</asp:ListItem>
        </asp:DropDownList>
        <asp:TextBox ID="TextBox3" runat="server" Width="538px"></asp:TextBox>
        <asp:Button ID="Button8" runat="server" Text="吧内搜索" onclick="Button8_Click" />
        <asp:Repeater ID="Repeater1" runat="server" 
            onitemdatabound="Repeater1_ItemDataBound">
            <HeaderTemplate>
                <table width="80%">
            </HeaderTemplate>
            <ItemTemplate>
                <tr style="background-color:#e6feda;">
                    <td>
                        <a href='temp2.aspx?id=<%#Eval("carduserid") %>'><%#Eval("cardusername") %></a>
                    </td>
                    <td>
                        <a href='temp.aspx?id=<%#Eval("cardtitleid")%>'><%#Eval("cardtitle") %></a>
                    </td>
                    <td>
                        <%#Eval("cardtime") %>
                    </td>
                </tr>
            </ItemTemplate>
            <SeparatorTemplate>
                <tr>
                    <td>
                    <hr>
                    </td>
                    <td>
                    <hr>
                    </td>
                    <td>
                    <hr>
                    </td>
                </tr>
            </SeparatorTemplate>
            <FooterTemplate>
            <tr>
            <td colspan="2" style="font-size:12pt;color:#0099ff; background-color:#e6feda;">共<asp:Label ID="Label1" runat="server" Text="Label1"></asp:Label>页  当前为第<asp:Label ID="Label2" runat="server" Text="Label2"></asp:Label>页
            <asp:HyperLink ID="hlfir" runat="server" Text="首页"></asp:HyperLink>
            <asp:HyperLink ID="hlp" runat="server" Text="上一页"></asp:HyperLink>
            <asp:HyperLink ID="hln" runat="server" Text="下一页"></asp:HyperLink>
            <asp:HyperLink ID="hlla" runat="server" Text="尾页"></asp:HyperLink>
            </td>
            </tr>
                </table>
            </FooterTemplate>
        </asp:Repeater>
    </div>
    </form>
</body>
</html>
