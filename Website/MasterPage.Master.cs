using System;
using System.Linq;

namespace Website
{
    public partial class MasterPage : System.Web.UI.MasterPage
    {
        public static string User = "user";

        protected void Page_Load(object sender, EventArgs e)
        {
            var user = (Users)Session[User];

            if (user != null)
            {
                using (var context = new MainEntities())
                {
                    if (context.Users.Where(o => o.Login == user.Login && o.Password == user.Password).ToList().Count > 0)
                    {
                        header.InnerText = user.Login;
                        header.HRef = "/lk.aspx";

                        var cart = context.Pocket.Where(o => o.UserId.Equals(user.Id)).ToList();

                        if (cart.Count > 0)
                        {
                            var count = 0;
                            foreach (var c in cart) count += c.Count;

                            pocket.InnerHtml = $"В корзине {count} шт";
                            pocket.HRef = "/pocket.aspx";
                        }

                        if (user.Rigths == 1)
                            Link1.Visible = true;
                        else if (user.Rigths == 2)
                            Link2.Visible = true;

                        return;
                    }
                }
            }

            header.InnerText = "Войти";
            header.HRef = "/login.aspx";
        }

        protected void Link1_Click(object sender, EventArgs e)
        {
            Response.Redirect("/lk.aspx");
        }

        protected void Link2_Click(object sender, EventArgs e)
        {
            Response.Redirect("/admin.aspx");
        }
    }
}