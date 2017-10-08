using System;
using System.Collections.Generic;

using Newtonsoft.Json;
using System.Net;
using System.Web.UI.WebControls;


namespace Pokedex
{
    public partial class Item : System.Web.UI.Page
    {        

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Session["item_page"] = "0";

                ListPokemon(int.Parse(Session["item_page"].ToString()));
            }
        }

        public void ListPokemon(int offset)
        {
            try
            {
                RootObject root = JsonConvert.DeserializeObject<RootObject>(new WebClient().DownloadString("https://pokeapi.co/api/v2/item/?limit=20&offset=" + offset));

                List<Result> resultList = new List<Result>();
                resultList = root.results;

                btnController(offset, root.count);

                ListPokemons.DataSource = resultList;
                ListPokemons.DataBind();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void ListPokemons_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            // Recuperando o pokemon
            Result item = (Result)e.Item.DataItem;

            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                Label lblName = (Label)e.Item.FindControl("LblItemName");
                lblName.Text = item.name.Replace('-', ' ');
            }
        }

        protected void BtnLoadNext_Click(object sender, EventArgs e)
        {
            try
            {
                int cont = int.Parse(Session["item_page"].ToString());
                cont += 20;
                Session["item_page"] = cont.ToString();

                ListPokemon(cont);
            }
            catch (Exception ex)
            {
                Response.Redirect("Error.html");
            }
        }

        protected void BtnLoadPrev_Click(object sender, EventArgs e)
        {
            try
            {
                int cont = int.Parse(Session["item_page"].ToString());
                cont -= 20;
                Session["item_page"] = cont.ToString();

                ListPokemon(cont);

            }
            catch (Exception ex)
            {
                Response.Redirect("Error.html");
            }
        }

        public void btnController(int offset, int root_cont)
        {
            try
            {

                if (offset >= 20 && offset <= root_cont)
                {
                    BtnLoadPrev.Visible = true;
                }

                if (offset < 20)
                {
                    BtnLoadPrev.Visible = false;
                }

                if (offset <= root_cont)
                {
                    BtnLoadNext.Visible = true;
                }
                else
                {
                    BtnLoadNext.Visible = false;
                }
            }
            catch (Exception ex)
            {
                Response.Redirect("Error.html");
            }
        }
    }
}