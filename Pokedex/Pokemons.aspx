﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Page.Master" AutoEventWireup="true" CodeBehind="Pokemons.aspx.cs" Inherits="Pokedex.Pokemons" Async="true" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section>
        <div class="content_center list_pokemons">
            <div class="container">
                <div class="row justify-content-center">
                    <asp:Repeater ID="ListPokemons" runat="server" OnItemDataBound="ListPokemons_ItemDataBound">
                        <ItemTemplate>
                            <div class="col col-12 col-sm-6 col-md-4 col-lg-3">
                                <asp:HyperLink ID="LinkDetails" runat="server">
                                    <div class="content_item">
                                        <asp:Image ID="ImgPokemon" runat="server" />
                                        <asp:Label ID="LblPokemonName" runat="server" Text="Label"></asp:Label>
                                    </div>
                                </asp:HyperLink>
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>
                </div>
                <div class="row justify-content-between">
                    <div class="col col-6 col-sm-4 col-md-3">
                        <div class="content_btn_grup">
                            <asp:Button ID="BtnLoadPrev" runat="server" Text="Prev" OnClick="BtnLoadPrev_Click" CssClass="btn_pages" />
                        </div>
                    </div>
                    <div class="col col-6 col-sm-4 col-md-3">
                        <div class="content_btn_grup">
                            <asp:Button ID="BtnLoadNext" runat="server" Text="Next" OnClick="BtnLoadNext_Click" CssClass="btn_pages" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </section>
</asp:Content>
