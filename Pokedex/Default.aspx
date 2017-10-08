<%@ Page Title="" Language="C#" MasterPageFile="~/Page.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Pokedex.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section>
        <div class="content_center">
            <div class="container">
                <div class="row justify-content-around">
                    <div class="col col-md-5">
                        <a href="Item.aspx" class="box_effect">
                            <div class="content_type_select">
                                <img src="assets/images/bag_icon.png" />
                                <p>Itens</p>
                            </div>
                        </a>
                    </div>
                    <div class="col col-md-5">
                        <a href="Pokemons.aspx" class="box_effect">
                            <div class="content_type_select">
                                <img src="assets/images/pokedex.png" />
                                <p>Pokémons</p>
                            </div>
                        </a>
                    </div>
                </div>
            </div>
        </div>
    </section>
</asp:Content>
