using System;
using System.Collections.Generic;

using Newtonsoft.Json;
using System.Net;
using System.Web.UI.WebControls;


namespace Pokedex
{
    public partial class Item : System.Web.UI.Page
    {        
        /// <summary>
        /// Page Load
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                try
                { 
                    //Session used to control de number of pages
                    Session["item_page"] = "0";

                    ListPokemon(int.Parse(Session["item_page"].ToString()));
                }
                catch (Exception ex)
                {
                    Response.Redirect("Error.html");
                }
            }
        }

        /// <summary>
        /// Create a list of objects from JSON
        /// </summary>
        /// <param name="offset">Value to control de pagination</param>
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

        /// <summary>
        /// List View
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// Pagination buttom: Next
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void BtnLoadNext_Click(object sender, EventArgs e)
        {
            try
            {
                //Increments offset to ask a new list from PokeAPI
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

        /// <summary>
        /// Pagination buttom: Previous
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void BtnLoadPrev_Click(object sender, EventArgs e)
        {
            try
            {
                //Decrements offset to ask a new list from PokeAPI
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

        /// <summary>
        /// Buttom Controller
        /// </summary>
        /// <param name="offset"></param>
        /// <param name="root_cont"></param>
        public void btnController(int offset, int root_cont)
        {
            try
            {
                if (offset >= 20 && offset < root_cont)
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