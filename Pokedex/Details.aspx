<%@ Page Title="" Language="C#" MasterPageFile="~/Page.Master" AutoEventWireup="true" CodeBehind="Details.aspx.cs" Inherits="Pokedex.Details" Async="true" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section>
        <div class="content_center">
            <div class="container">
                <div class="row justify-content-center">
                    <div class="col col-12 col-sm-11">
                        <asp:Panel ID="PnlPokemons" runat="server">
                            <div class="content_item_detail">
                                <div class="row justify-content-center">
                                    <div class="col col-12 col-md-6 col-lg-4">
                                        <asp:Image ID="ImagePokemon" runat="server" />
                                    </div>
                                    <div class="col col-12 col-md-6 col-lg-5">
                                        <div class="content_description name">
                                            <asp:Literal ID="LtlName" runat="server"></asp:Literal>
                                            <asp:Literal ID="LtlMass" runat="server"></asp:Literal>
                                            <asp:Literal ID="LtlHeight" runat="server"></asp:Literal>
                                            <asp:Literal ID="LtlSpecies" runat="server"></asp:Literal>
                                            <asp:Literal ID="LtlTypes" runat="server"></asp:Literal>
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col col-12">
                                        <div class="content_description">
                                            <asp:Literal ID="LtlMoves" runat="server"></asp:Literal>
                                            <asp:Literal ID="LtlAbility" runat="server"></asp:Literal>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </asp:Panel>
                    </div>
                </div>
            </div>

        </div>
    </section>
</asp:Content>
