using System;

namespace Website
{
    public partial class AddRide : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((Session[MasterPage.User] as Users)?.Rigths != 2) Response.Redirect("login.aspx");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            using (var context = new MainEntities())
            {
                var режиссер = new Режиссеры()
                {
                    Фамилия = TextBox1.Text,
                    Имя = TextBox2.Text,
                    Страна = TextBox3.Text,
                    Информация = TextBox4.Text
                };

                context.Режиссеры.Add(режиссер);
                context.SaveChanges();
            }

            Response.Redirect("admin.aspx");
        }
    }
}