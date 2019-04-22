using System;
using System.Linq;

namespace Website
{
    public partial class lk : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session[MasterPage.User] == null) Response.Redirect("/login.aspx");
            Label1.Text = $"Добро пожаловать в личный кабинет, {((Users)Session[MasterPage.User]).Login}";

            var user = (Users)Session[MasterPage.User];

            if (string.IsNullOrEmpty(TextBox1.Text))
            {
                TextBox1.Text = user.Login;
                TextBox2.Text = user.Email;
                TextBox3.Text = user.Password;
                TextBox4.Text = user.Password;
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Session[MasterPage.User] = null;
            Response.Redirect("/login.aspx");
        }

        protected void TextBox1_TextChanged(object sender, EventArgs e)
        {
            var user = (Users)Session[MasterPage.User];
            using (var context = new MainEntities())
            {
                var dbUser = context.Users.First(o => user.Id == o.Id);
                dbUser.Login = TextBox1.Text;
                Session[MasterPage.User] = dbUser;
                context.SaveChanges();
            }
        }

        protected void TextBox2_TextChanged(object sender, EventArgs e)
        {
            var user = (Users)Session[MasterPage.User];
            using (var context = new MainEntities())
            {
                var dbUser = context.Users.First(o => user.Id == o.Id);
                dbUser.Email = TextBox2.Text;
                Session[MasterPage.User] = dbUser;
                context.SaveChanges();
            }
        }

        protected void TextBox4_TextChanged(object sender, EventArgs e)
        {
            var user = (Users)Session[MasterPage.User];
            using (var context = new MainEntities())
            {
                var dbUser = context.Users.First(o => user.Id == o.Id);
                dbUser.Password = TextBox4.Text;
                Session[MasterPage.User] = dbUser;
                context.SaveChanges();
            }
        }
    }
}