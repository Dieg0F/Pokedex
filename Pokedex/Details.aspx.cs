using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using PokeAPI;

namespace Pokedex
{
    public partial class Details : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            string name = Request.QueryString["name"];

            if (name == null || name == "")
            {
                Response.Redirect("default.aspx");
            }

            getPokemon(name);

        }

        public async void getPokemon(string name)
        {
            try
            {
                Pokemon p = await DataFetcher.GetNamedApiObject<Pokemon>(name);

                Image(p);
                Name(p);
                Height(p);
                Mass(p);
                Species(p);
                Moves(p);
                Ability(p);
                Types(p);
            }
            catch (Exception ex)
            {
                Response.Redirect("Error.html");
            }
        }

        public void Image(Pokemon p)
        {
            ImagePokemon.ImageUrl = "assets/images/official-artwork/" + p.ID + ".png";
            if (p.ID == 0)
            {
                LtlHeight.Visible = false;
            }
        }

        public void Name(Pokemon p)
        {
            LtlName.Text = "<p><span>Name: </span>" + p.Name + "</p>";
            if (p.Name == "")
            {
                LtlHeight.Visible = false;
            }
        }

        public void Height(Pokemon p)
        {
            LtlHeight.Text = "<p><span>Height: </span>" + p.Height + "</p>";
            if (p.Height == 0)
            {
                LtlHeight.Visible = false;
            }
        }

        public void Mass(Pokemon p)
        {
            LtlMass.Text = "<p><span>Mass: </span>" + p.Mass + "</p>";
            if (p.Mass == 0)
            {
                LtlMass.Visible = false;
            }
        }

        public void Ability(Pokemon p)
        {
            LtlAbility.Text = "<p><span>Abilities: </span>";
            foreach (PokemonAbility ability in p.Abilities)
            {
                LtlAbility.Text += " " + ability.Ability.Name.Replace('-', ' ') + ",";
                if (ability.Ability.Name == null)
                {
                    LtlAbility.Visible = false;
                    break;
                }
            }
            LtlAbility.Text += "</p>";

        }

        public void Species(Pokemon p)
        {
            LtlSpecies.Text = "<p><span>Species: </span>" + p.Species.Name + "</p>";
            if(p.Species.Name == null)
            {
                LtlSpecies.Visible = false;
            }
        }

        public void Moves(Pokemon p)
        {
            LtlMoves.Text = "<p><span>Moves: </span>";
            foreach (PokemonMove pm in p.Moves)
            {
                LtlMoves.Text += " " + pm.Move.Name.Replace('-', ' ') + ",";
                if (pm.Move.Name == null)
                {
                    LtlMoves.Visible = false;
                    break;
                }
            }
            LtlMoves.Text += "</p>";
        }

        public void Types(Pokemon p)
        {
            LtlTypes.Text = "<p><span>Types: </span>";
            foreach (PokemonTypeMap typeMap in p.Types)
            {
                NamedApiResource<PokemonType> type = typeMap.Type;
                LtlTypes.Text += " " + type.Name.Replace('-', ' ') + ",";
                if (type.Name == null)
                {
                    LtlTypes.Visible = false;
                    break;
                }
            }
            LtlTypes.Text += "</p>";

        }
    }
}