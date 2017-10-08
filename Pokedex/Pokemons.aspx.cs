using System;
using System.Collections.Generic;

using Newtonsoft.Json;
using System.Net;
using System.Web.UI.WebControls;

using System.Text.RegularExpressions;
using System.Linq;

namespace Pokedex
{
    public partial class Pokemons : System.Web.UI.Page
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
                    Session["Pokemon_page"] = "0";

                    ListPokemon(int.Parse(Session["Pokemon_page"].ToString()));
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
                RootObject root = JsonConvert.DeserializeObject<RootObject>(new WebClient().DownloadString("https://pokeapi.co/api/v2/pokemon/?limit=20&offset=" + offset)); 

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
            Result pokemon = (Result)e.Item.DataItem;
                                        
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                Label lblName = (Label)e.Item.FindControl("LblPokemonName");
                lblName.Text = pokemon.name;

                HyperLink linkDetail = (HyperLink)e.Item.FindControl("LinkDetails");
                linkDetail.NavigateUrl = "Details.aspx?name=" + pokemon.name + "&type=pokemon";


                Image imgPokemon = (Image)e.Item.FindControl("ImgPokemon");
                imgPokemon.ImageUrl = "assets/images/official-artwork/" + getIdPokemon(pokemon.url) + ".png";

            }
        }

        /// <summary>
        /// Get the pokemon id from url json
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public string getIdPokemon(string url)
        {
            Char delimiter = '/';
            String[] substrings = url.Split(delimiter);
            return substrings[6];
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
                int cont = int.Parse(Session["Pokemon_page"].ToString());
                cont += 20;
                Session["Pokemon_page"] = cont.ToString();

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
                int cont = int.Parse(Session["Pokemon_page"].ToString());
                cont -= 20;
                Session["Pokemon_page"] = cont.ToString();

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