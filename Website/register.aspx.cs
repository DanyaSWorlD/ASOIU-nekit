using System;
using System.Linq;

namespace Website
{
    public partial class register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            using (var context = new MainEntities())
            {
                if (context.Users.Count(o => o.Login.Equals(TextBox1.Text)) > 0) return;

                var user = new Users
                {
                    Login = TextBox1.Text,
                    Password = TextBox4.Text,
                    Email = TextBox2.Text,
                    Rigths = 1 
                };

                context.Users.Add(user);

                context.SaveChanges();

                Session[MasterPage.User] = user;

                Response.Redirect("/lk.aspx");
            }
        }
    }
}