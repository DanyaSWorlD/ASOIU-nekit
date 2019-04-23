using System;
using System.Linq;
using System.Web.UI.WebControls;

namespace Website
{
    public partial class AddFilm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((Session[MasterPage.User] as Users)?.Rigths != 2) Response.Redirect("login.aspx");

            using (var context = new MainEntities())
            {
                CheckBoxList1.DataSourceID = "";
                CheckBoxList2.DataSourceID = "";

                var source1 = context.Актеры.ToList();
                var source2 = context.Персонажи.ToList();

                CheckBoxList1.DataSource = source1.Select(o => $"{o.Имя} {o.Фамилия}").ToList();
                CheckBoxList2.DataSource = source2.Select(o => $"{o.Имя} {o.Фамилия}").ToList();

                CheckBoxList1.DataBind();
                CheckBoxList2.DataBind();
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            using (var context = new MainEntities())
            {
                var f = new Фильмы
                {
                    Название = TextBox1.Text,
                    Сюжет = TextBox2.Text,
                    Дата_выхода = DateTime.Parse(TextBox3.Text),
                    Страна = TextBox4.Text,
                    Количество_серий = int.Parse(TextBox5.Text),
                    Режиссер = context.Режиссеры.ToList()[DropDownList1.SelectedIndex].Id,
                    Студия = context.Студии.ToList()[DropDownList2.SelectedIndex].Id
                };

                var filmId = context.Фильмы.Add(f);

                var items = CheckBoxList1.Items.Cast<ListItem>().ToList();

                foreach (var a in items.Where(sItem => sItem.Selected))
                {
                    var indexOfA = items.IndexOf(a);
                    var ai = new Актеры_в_фильме
                    {
                        Фильм = filmId.Id,
                        Актер = context.Актеры.ToList()[indexOfA].Id
                    };
                    context.Актеры_в_фильме.Add(ai);
                }

                var itemsPers = CheckBoxList2.Items.Cast<ListItem>().ToList();
                foreach (var a in itemsPers.Where(sItem => sItem.Selected))
                {
                    var indexOfA = items.IndexOf(a);
                    var ai = new Персонажи_в_фильме
                    {
                        Фильм = filmId.Id,
                        Персонаж = context.Актеры.ToList()[indexOfA].Id
                    };
                    context.Персонажи_в_фильме.Add(ai);
                }

                context.SaveChanges();

                Response.Redirect("admin.aspx");
            }
        }
    }
}