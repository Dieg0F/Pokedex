<%@ Page Title="" Language="C#" MasterPageFile="~/Page.Master" AutoEventWireup="true" CodeBehind="Details.aspx.cs" Inherits="Pokedex.Details" Async="true" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section>
        <div class="container">
            <div class="row justify-content-center">
                <div class="col col-md-8 col-sm-10 col-12">
                    <asp:Panel ID="PnlPokemons" runat="server">
                        <div class="content_item_detail">
                            <asp:Image ID="ImagePokemon" runat="server" />
                            <asp:Literal ID="LtlName" runat="server"></asp:Literal>
                            <asp:Literal ID="LtlSpecies" runat="server"></asp:Literal>
                            <asp:Literal ID="LtlMoves" runat="server"></asp:Literal>
                            <asp:Literal ID="LtlTypes" runat="server"></asp:Literal>
                            <asp:Literal ID="LtlMass" runat="server"></asp:Literal>
                            <asp:Literal ID="LtlHeight" runat="server"></asp:Literal>
                            <asp:Literal ID="LtlAbility" runat="server"></asp:Literal>
                        </div>
                    </asp:Panel>
                </div>
            </div>
        </div>
    </section>
</asp:Content>
