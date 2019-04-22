using System;

namespace Website
{
    public partial class AddContract : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((Session[MasterPage.User] as Users)?.Rigths != 2) Response.Redirect("login.aspx");

            Date.Value = DateTime.Now.ToString();
            Date2.Value = DateTime.Now.AddDays(10).ToString();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            using (var context = new MainEntities())
            {
                var contracts = new Contracts
                {
                    Costs = int.Parse(TextBox2.Text),
                    CreationDate = DateTime.Parse(Date.Value),
                    ExpireDate = DateTime.Parse(Date2.Value),
                    RentTime = DateTime.MinValue.AddHours(int.Parse(TextBox2.Text))
                };

                context.Contracts.Add(contracts);
                context.SaveChanges();
            }

            Response.Redirect("admin.aspx");
        }
    }
}