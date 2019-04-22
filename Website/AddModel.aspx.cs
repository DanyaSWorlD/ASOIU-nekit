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

            using (var context = new MainEntities())
            {
                var items = context.ModelTypes.ToList();

                DropDownList1.DataSourceID = "";
                DropDownList1.DataSource = items;
                DropDownList1.DataBind();
            }
        }

        public List<ModelTypes> GetTypes()
        {
            using (var context = new MainEntities())
                return context.ModelTypes.ToList();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            using (var context = new MainEntities())
            {
                var model = new Models
                {
                    Manufacturer = TextBox1.Text,
                    Model = TextBox2.Text,
                    Price = int.Parse(TextBox3.Text),
                    Type = context.ModelTypes.ToList()[DropDownList1.SelectedIndex].Id
                };

                context.Models.Add(model);
                context.SaveChanges();
            }

            Response.Redirect("admin.aspx");
        }
    }
}