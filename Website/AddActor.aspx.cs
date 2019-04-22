using System;

namespace Website
{
    public partial class AddDefect : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((Session[MasterPage.User] as Users)?.Rigths != 2) Response.Redirect("login.aspx");
        }


        protected void Button1_Click(object sender, EventArgs e)
        {
            using (var context = new MainEntities())
            {
                var актер = new Актеры()
                {
                    Фамилия = TextBox1.Text,
                    Имя = TextBox2.Text,
                    Страна = TextBox3.Text,
                    Год = int.Parse(TextBox4.Text)
                };

                context.Актеры.Add(актер);
                context.SaveChanges();
            }

            Response.Redirect("admin.aspx");
        }
    }
}