<%@ Page Language="C#" AutoEventWireup="true" CodeFile="floor.aspx.cs" Inherits="floor" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Label ID="Label6" runat="server" Text="当前用户："></asp:Label>
        <asp:Label ID="labelusername" runat="server" Text="罗舒文"></asp:Label>
        &nbsp;&nbsp;
        <asp:Label ID="Label7" runat="server" Text="当前标题："></asp:Label>
        <a href="card.aspx?">
            <asp:Label ID="Labeltitle" runat="server" Text="Label"></asp:Label></a> &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <a href="card.aspx?">
            <asp:Label ID="Label8" runat="server" Text="贴吧首页"></asp:Label></a>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="注册" />
        <asp:Button ID="Button3" runat="server" OnClick="Button3_Click" Text="登录" />
        <asp:Button ID="Button4" runat="server" Enabled="False" OnClick="Button4_Click" Text="注销" />
        <br />
        <asp:DropDownList ID="DropDownList1" runat="server" Height="20px" Width="168px">
            <asp:ListItem>标题 </asp:ListItem>
            <asp:ListItem>用户</asp:ListItem>
        </asp:DropDownList>
        <asp:TextBox ID="TextBox3" runat="server" Width="473px"></asp:TextBox>
        <asp:Button ID="Button8" runat="server" Text="吧内搜索" OnClick="Button8_Click1" />
        <asp:Repeater ID="Repeater1" runat="server" OnItemDataBound="Repeater1_ItemDataBound"
            OnItemCommand="Repeater1_ItemCommand">
            <HeaderTemplate>
                <table width="80%">
            </HeaderTemplate>
            <ItemTemplate>
                <tr>
                    <td>
                        <asp:HiddenField ID="HiddenField1" runat="server" Value='<%#Eval("floorid") %>' />
                    </td>
                </tr>
                <tr style="background-color: #e6feda;">
                    <td>
                        <a href="temp2.aspx?id=<%#Eval("flooruserid")%>">
                            <%#Eval("floorusername") %></a>
                    </td>
                    <td>
                        <%#Eval("floorcontent") %>
                    </td>
                    <td>
                        <%#Eval("floortime") %>
                    </td>
                    <td>
                        <asp:Image ID="Image2" runat="server" ImageUrl='<%#Eval("floorpic") %>' />
                    </td>
                    <td>
                        <asp:Button ID="Button5" CommandName="btn5" runat="server" Text="回复"></asp:Button>
                    </td>
                </tr>
                <tr>
                    <asp:Repeater ID="Repeater2" runat="server" OnItemDataBound="Repeater2_ItemDataBound"
                        OnItemCommand="Repeater2_ItemCommand">
                        <HeaderTemplate>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <td>
                            </td>
                            <td>
                                <a href="temp2.aspx?id=<%#Eval("reuserid")%>">
                                    <%#Eval("reusername") %></a>
                            </td>
                            <td>
                                <%#Eval("recontent") %>
                            </td>
                            <td>
                                <%#Eval("retime") %>
                            </td>
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
                        </FooterTemplate>
                    </asp:Repeater>
                </tr>
                <td>
                    <td>
                        <asp:TextBox ID="TextBox1" runat="server" Visible="False"></asp:TextBox>
                        <asp:Button ID="Button6" Visible="False" runat="server" Text="发表" CommandName="btn6" />
                    </td>
                </td>
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
                    <td colspan="2" style="font-size: 12pt; color: #0099ff; background-color: #e6feda;">
                        共<asp:Label ID="Label1" runat="server" Text="Label1"></asp:Label>页 当前为第<asp:Label
                            ID="Label2" runat="server" Text="Label2"></asp:Label>页
                        <asp:HyperLink ID="hlfir" runat="server" Text="首页"></asp:HyperLink>
                        <asp:HyperLink ID="hlp" runat="server" Text="上一页"></asp:HyperLink>
                        <asp:HyperLink ID="hln" runat="server" Text="下一页"></asp:HyperLink>
                        <asp:HyperLink ID="hlla" runat="server" Text="尾页"></asp:HyperLink>
                    </td>
                </tr>
                </table>
            </FooterTemplate>
        </asp:Repeater>
        <asp:Label ID="Label5" runat="server" Text="请在此发表内容："></asp:Label>
        <asp:Panel ID="Panel1" runat="server" Width="645px" Height="22px">
            &nbsp; &nbsp;
            <asp:Label ID="Label9" runat="server" Text="附加图片："></asp:Label>
            &nbsp;<asp:FileUpload ID="FileUpload1" runat="server" />
            <asp:Button ID="Button7" runat="server" OnClick="Button7_Click" Text="上传" />
            <asp:Label ID="Label10" runat="server"></asp:Label>
        </asp:Panel>
        <asp:Label ID="Label4" runat="server" Text="内容："></asp:Label>
        <asp:TextBox ID="TextBox2" runat="server" Height="145px" MaxLength="1000" TextMode="MultiLine"
            Width="601px"></asp:TextBox>
        <asp:Image ID="Image1" runat="server" />
        <br />
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="发表" Style="width: 40px" />
    </div>
    </form>
</body>
</html>
