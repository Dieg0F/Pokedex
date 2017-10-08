<%@ Page Title="" Language="C#" MasterPageFile="~/Page.Master" AutoEventWireup="true" CodeBehind="Item.aspx.cs" Inherits="Pokedex.Item" Async="true" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section>
        <div class="content_center">
            <div class="container">
                <div class="row justify-content-center">
                    <asp:Repeater ID="ListPokemons" runat="server" OnItemDataBound="ListPokemons_ItemDataBound">
                        <ItemTemplate>
                            <div class="col col-12 col-sm-6 col-md-4 col-lg-3">
                                <div class="content_item">
                                    <asp:HyperLink ID="LinkDetails" runat="server">
                                        <asp:Label ID="LblItemName" runat="server" Text="Label"></asp:Label>
                                    </asp:HyperLink>
                                </div>
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
