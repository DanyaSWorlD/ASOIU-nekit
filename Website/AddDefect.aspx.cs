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
                var defect = new Defects
                {
                    Part = TextBox1.Text,
                    Value = TextBox2.Text,
                    Comment = TextBox3.Text
                };

                context.Defects.Add(defect);
                context.SaveChanges();
            }

            Response.Redirect("admin.aspx");
        }
    }
}