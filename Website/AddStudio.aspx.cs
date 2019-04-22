using System;
using System.Collections.Generic;
using System.Linq;

namespace Website
{
    public partial class AddModel : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((Session[MasterPage.User] as Users)?.Rigths != 2) Response.Redirect("login.aspx");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            using (var context = new MainEntities())
            {
                var студия = new Студии()
                {
                    Название = TextBox1.Text,
                    Адрес = TextBox2.Text,
                    Страна = TextBox3.Text,
                    Телефон = TextBox4.Text
                };

                context.Студии.Add(студия);
                context.SaveChanges();
            }

            Response.Redirect("admin.aspx");
        }
    }
}