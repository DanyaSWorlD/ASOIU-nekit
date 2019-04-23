using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.UI.WebControls;

namespace Website
{
    public partial class _default : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {

            if (IsPostBack) return;

            DropDownList1.DataSourceID = "";
            DropDownList2.DataSourceID = "";

            using (var context = new MainEntities())
            {
                DropDownList1.Items.Add("");
                var items1 = context.Режиссеры.ToList();
                DropDownList1.Items.AddRange(items1.Select(o => new ListItem(o.Имя + " " + o.Фамилия)).ToArray());

                DropDownList2.Items.Add("");
                var items2 = context.Студии.ToList();
                DropDownList2.Items.AddRange(items2.Select(o => new ListItem(o.Название)).ToArray());
            }

            DropDownList1.DataBind();
            DropDownList2.DataBind();

            UpdData();

            if (Session[MasterPage.User] != null)
            {
                var user = (Users)Session[MasterPage.User];
                if (user.Rigths == 1)
                {
                    GridView1.Columns[0].Visible = true;
                    return;
                }
            }

            GridView1.Columns[0].Visible = false;
        }

        protected void UpdData()
        {
            GridView1.DataSourceID = "";
            GridView1.DataSource = GetData();
            GridView1.DataBind();
        }

        public List<Фильм> Фильмы()
        {
            using (var context = new MainEntities())
            {
                var films = context.Фильмы
                    .Include(o => o.Режиссеры)
                    .Include(o => o.Студии)
                    .ToList();

                return films.Select(o => new Фильм(o)).ToList();
            }
        }

        protected object GetData()
        {
            var regisser = (string)Session["regFilter"];
            var studio = (string)Session["studioFilter"];
            var name = (string)Session["nameFilter"];
            var country = (string)Session["countryFilter"];
            var seriesFrom = (string)Session["seriesFromFilter"];
            var seriesTo = (string)Session["seriesToFilter"];

            object data = null;

            var fromB = int.TryParse(seriesFrom, out var @from);
            var toB = int.TryParse(seriesTo, out var to);

            using (var context = new MainEntities())
            {
                var films = context.Фильмы
                    .Include(o => o.Режиссеры)
                    .Include(o => o.Студии)
                    .ToList();

                data = films
                    .Where(o =>
                    (string.IsNullOrEmpty(regisser) || ($"{o.Режиссеры.Имя} {o.Режиссеры.Фамилия}").Contains(regisser))
                    && (string.IsNullOrEmpty(studio) || o.Студии.Название.Contains(studio))
                    && (string.IsNullOrEmpty(name) || o.Название.Contains(name))
                    && (string.IsNullOrEmpty(country) || o.Страна.Contains(country))
                    && (!fromB || o.Количество_серий > @from)
                    && (!toB || o.Количество_серий < to))
                    .Select(o => new Фильм(o))
                    .ToList();
            }

            return data;
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "add")
            {
                var id = int.Parse((string)e.CommandArgument);

                using (var context = new MainEntities())
                {
                    var фильмы = context.Фильмы.ToArray()[id];

                    var user = (Users)Session[MasterPage.User];

                    var myPocket = context.Pocket.Where(o => o.UserId == user.Id).ToList();

                    if (myPocket.Count(o => o.Фильм.Equals(фильмы.Id)) > 0)
                    {
                        context.Pocket.First(o => o.Фильм.Equals(фильмы.Id)).Количество++;
                        context.SaveChanges();
                    }
                    else
                    {
                        context.Pocket.Add(new Pocket
                        {
                            Количество = 1,
                            Фильм = фильмы.Id,
                            UserId = ((Users)Session[MasterPage.User]).Id
                        });
                    }

                    context.SaveChanges();
                    Response.Redirect("/default.aspx");
                }
            }
        }

        protected void Unnamed1_Click(object sender, EventArgs e)
        {
            DropDownList1.SelectedIndex = 0;
            DropDownList2.SelectedIndex = 0;
            TextBox2.Text = "";
            TextBox3.Text = "";
            TextBox4.Text = "";
            TextBox5.Text = "";

            Session["typeFilter"] = null;
            Session["manFilter"] = null;
            Session["modelFilter"] = null;
            Session["costFromFilter"] = null;
            Session["costToFilter"] = null;
            Response.Redirect("/default.aspx");
        }

        public class Фильм
        {
            private Фильмы _фильм;

            public int Id => _фильм.Id;

            public string Название => _фильм.Название;

            public string Страна => _фильм.Страна;

            public string Сюжет => _фильм.Сюжет;

            public System.DateTime Дата_выхода => _фильм.Дата_выхода;

            public int Количество_серий => _фильм.Количество_серий;

            public string Режиссер => _фильм.Режиссеры.Имя + " " + _фильм.Режиссеры.Фамилия;

            public string Студия => _фильм.Студии.Название;

            public Фильм(Фильмы фильм)
            {
                _фильм = фильм;
            }
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session["regFilter"] = DropDownList1.SelectedValue;
            UpdData();
        }

        protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session["studioFilter"] = DropDownList2.SelectedValue;
            UpdData();
        }

        protected void TextBox2_TextChanged(object sender, EventArgs e)
        {
            Session["nameFilter"] = TextBox2.Text;
            UpdData();
        }

        protected void TextBox3_TextChanged(object sender, EventArgs e)
        {
            Session["countryFilter"] = TextBox3.Text;
            UpdData();
        }

        protected void TextBox4_TextChanged(object sender, EventArgs e)
        {
            Session["seriesFromFilter"] = TextBox4.Text;
            UpdData();
        }

        protected void TextBox5_TextChanged(object sender, EventArgs e)
        {
            Session["seriesToFilter"] = TextBox5.Text;
            UpdData();
        }
    }
}