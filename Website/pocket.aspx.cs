using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.UI.WebControls;

namespace Website
{
    public partial class pocket : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GridView1.DataSourceID = "";
                GridView1.DataSource = GetItems();
                GridView1.DataBind();
            }
        }

        protected void ObjectDataSource1_Selecting(object sender, ObjectDataSourceSelectingEventArgs e)
        {

        }

        public List<Pocket> GetItems()
        {
            if (Session[MasterPage.User] == null) return null;

            var user = (Users)Session[MasterPage.User];

            using (var context = new MainEntities())
                return context.Pocket
                    .Where(o => o.UserId.Equals(user.Id))
                    .Include(o => o.Models)
                    .Include(o => o.Users)
                    .Include(o => o.Models.ModelTypes)
                    .ToList();
        }

        public void DeleteItem(Pocket p)
        {
            using (var context = new MainEntities())
                context.Pocket.Remove(p);

            GridView1.DataSourceID = "";
            GridView1.DataSource = GetItems();
            GridView1.DataBind();
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            using (var context = new MainEntities())
            {
                var user = (Users)Session[MasterPage.User];
                var myPocket = context.Pocket.Where(o => o.UserId == user.Id).ToList();
                var myPocketItem = myPocket[e.RowIndex];

                if (myPocketItem.Count > 1)
                    context.Pocket.First(o => o.Id == myPocketItem.Id).Count--;
                else
                    context.Pocket.Remove(myPocketItem);

                context.SaveChanges();
            }

            GridView1.DataSourceID = "";
            GridView1.DataSource = GetItems();
            GridView1.DataBind();
        }
    }
}