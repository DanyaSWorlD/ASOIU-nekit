using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI.WebControls;

namespace Website
{
    public partial class AddRide : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((Session[MasterPage.User] as Users)?.Rigths != 2) Response.Redirect("login.aspx");

            Date.Value = DateTime.Now.ToString();
        }

        public List<Rides> GetRides()
        {
            using (var context = new MainEntities())
                return context.Rides.ToList();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            using (var context = new MainEntities())
            {
                var model = new Rides()
                {
                    StartTime = DateTime.Parse(Date.Value),
                    Status = TextBox1.Text
                };

                context.Rides.Add(model);
                context.SaveChanges();
            }

            Response.Redirect("admin.aspx");
        }
    }
}