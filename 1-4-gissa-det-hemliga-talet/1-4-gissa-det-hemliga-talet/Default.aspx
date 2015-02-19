<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="_1_4_gissa_det_hemliga_talet.Default" ViewStateMode="Disabled"%>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="Css/Style.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>Gissa det hemliga talet</h1>

            <asp:ValidationSummary ID="ValidationSummary1" HeaderText="Ett fel inträffade. Korrigera felet och gör ett nytt försök" runat="server" />

            <asp:Label ID="GuessTextLabel" runat="server" Text="Ange ett tal mellan 1-100"></asp:Label>
            <asp:TextBox ID="GuessTextBox" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="GuessTextBoxRequiredFieldValidator" ControlToValidate="GuessTextBox" runat="server" Text="*"
                ErrorMessage="Ange ett tal mellan 1-100" Display="Dynamic"></asp:RequiredFieldValidator>
            <asp:RangeValidator ID="GuessTextBoxRangeValidator" ControlToValidate="GuessTextBox" runat="server" Text="*"
                ErrorMessage="Ange ett tal mellan 1-100" Display="dynamic" MaximumValue="100" MinimumValue="1" Type="integer"></asp:RangeValidator>
            <asp:Button ID="Send" runat="server" Text="Gissa" OnClick="Send_Click" />

            <asp:PlaceHolder ID="Result" runat="server" Visible="false">
                <asp:Literal ID="PrevguessLiteral" runat="server"></asp:Literal>
                <asp:Literal ID="Message" runat="server"></asp:Literal>
            </asp:PlaceHolder>

            <asp:Button ID="Randomize" runat="server" Text="Slumpa ett nytt tal" CausesValidation="False" OnClick="Randomize_Click" />
       
        </div>
    </form>
</body>
</html>
