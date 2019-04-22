using System;

namespace Website
{
    public partial class AddContract : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((Session[MasterPage.User] as Users)?.Rigths != 2) Response.Redirect("login.aspx");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            using (var context = new MainEntities())
            {
                var персонаж = new Персонажи()
                {
                    Фамилия = TextBox1.Text,
                    Имя = TextBox2.Text,
                    Злодей = CheckBox1.Checked
                };

                context.Персонажи.Add(персонаж);
                context.SaveChanges();
            }

            Response.Redirect("admin.aspx");
        }
    }
}