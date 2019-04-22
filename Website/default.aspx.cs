using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI.WebControls;

namespace Website
{
    public partial class _default : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            //var typeFilter = (string)Session["typeFilter"];
            //var manFilter = (string)Session["manFilter"];
            //var modelFilter = (string)Session["modelFilter"];
            //var costFromFilter = (string)Session["costFromFilter"];
            //var costToFilter = (string)Session["costToFilter"];
            //var list = new List<ModelTypes>();
            //if (DropDownList1.Items.Count == 0)
            //    DropDownList1.Items.Add(new ListItem(""));

            //using (var context = new MainEntities())
            //    list = context.ModelTypes.ToList();

            //if (DropDownList1.Items.Count == 1)
            //    DropDownList1.Items.AddRange(list.Select(o => new ListItem(o.Type)).ToArray());

            //UpdData();

            //if (Session[MasterPage.User] != null)
            //{
            //    var user = (Users)Session[MasterPage.User];
            //    if (user.Rigths == 1)
            //    {
            //        GridView1.Columns[0].Visible = true;
            //        return;
            //    }
            //}

            //GridView1.Columns[0].Visible = false;
        }

        protected void DropDownList1_TextChanged(object sender, EventArgs e)
        {
            Session["typeFilter"] = DropDownList1.Text;
            UpdData();
        }

        protected void TextBox1_TextChanged(object sender, EventArgs e)
        {
            Session["manFilter"] = TextBox1.Text;
            UpdData();
        }

        protected void TextBox2_TextChanged(object sender, EventArgs e)
        {
            Session["modelFilter"] = TextBox2.Text;
            UpdData();
        }

        protected void TextBox3_TextChanged(object sender, EventArgs e)
        {
            Session["costFromFilter"] = TextBox3.Text;
            UpdData();
        }

        protected void TextBox4_TextChanged(object sender, EventArgs e)
        {
            Session["costToFilter"] = TextBox4.Text;
            UpdData();
        }

        protected void UpdData()
        {
            GridView1.DataSourceID = "";
            GridView1.DataSource = GetData();
            GridView1.DataBind();
        }

        public List<Фильмы> Фильмы()
        {
            using (var context = new MainEntities())
                return context.Фильмы.ToList();
        }

        protected object GetData()
        {
            var typeFilter = (string)Session["typeFilter"];
            var manFilter = (string)Session["manFilter"];
            var modelFilter = (string)Session["modelFilter"];
            var costFromFilter = (string)Session["costFromFilter"];
            var costToFilter = (string)Session["costToFilter"];

            object data = null;

            var fromB = int.TryParse(costFromFilter, out var @from);
            var toB = int.TryParse(costToFilter, out var to);

            //using (var context = new MainEntities())
            //{
            //    data = context.Models
            //        .Where(o =>
            //        (string.IsNullOrEmpty(typeFilter) || o.ModelTypes.Type.Equals(typeFilter))
            //        && (string.IsNullOrEmpty(manFilter) || o.Manufacturer.Contains(manFilter))
            //        && (string.IsNullOrEmpty(modelFilter) || o.Model.Contains(modelFilter))
            //        && (!fromB || o.Price > @from)
            //        && (!toB || o.Price < to))
            //        .Include(o => o.ModelTypes)
            //        .ToList();
            //}

            return data;
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "add")
            {
                //var id = int.Parse((string)e.CommandArgument);

                //using (var context = new MainEntities())
                //{
                //    var model = context.Models.ToArray()[id];

                //    var user = (Users)Session[MasterPage.User];

                //    var myPocket = context.Pocket.Where(o => o.UserId == user.Id).ToList();

                //    //var add = false;

                //    if (myPocket.Count(o => o.ModelId.Equals(model.Id)) > 0)
                //    {
                //        context.Pocket.First(o => o.ModelId.Equals(model.Id)).Count++;
                //        context.SaveChanges();
                //    }
                //    else
                //    {
                //        context.Pocket.Add(new Pocket
                //        {
                //            Count = 1,
                //            ModelId = model.Id,
                //            UserId = ((Users)Session[MasterPage.User]).Id
                //        });
                //    }

                //    context.SaveChanges();
                //    Response.Redirect("/default.aspx");
                //}
            }
        }

        protected void Unnamed1_Click(object sender, EventArgs e)
        {
            DropDownList1.SelectedIndex = 0;
            TextBox1.Text = "";
            TextBox2.Text = "";
            TextBox3.Text = "";
            TextBox4.Text = "";

            Session["typeFilter"] = null;
            Session["manFilter"] = null;
            Session["modelFilter"] = null;
            Session["costFromFilter"] = null;
            Session["costToFilter"] = null;
            Response.Redirect("/default.aspx");
        }
    }
}