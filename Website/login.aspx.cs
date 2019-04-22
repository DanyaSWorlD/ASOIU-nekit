using System;
using System.Linq;

namespace Website
{
    public partial class login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            Label2.Visible = false;

            var login = TextBox1.Text;
            var password = TextBox2.Text;

            if (login == null || password == null) return;

            using (var context = new MainEntities())
            {
                var users = context.Users
                    .Where(o => o.Login == login && o.Password == password)
                    .ToList();

                if (users.Count > 0)
                    Session[MasterPage.User] = users[0];
                else
                    Label2.Visible = true;
            }

            Response.Redirect("/lk.aspx");
        }

        protected void Unnamed1_Click(object sender, EventArgs e)
        {
            Response.Redirect("/register.aspx");
        }
    }
}