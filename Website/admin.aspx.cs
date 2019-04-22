using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.UI.WebControls;

namespace Website
{
    public partial class admin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var user = (Users)Session[MasterPage.User];
            if (user == null) Response.Redirect("/lk.aspx");

            using (var context = new MainEntities())
            {
                var admin = context.Rigths.First(j => j.Value.Contains("admin"));

                var dbUser = context.Users
                    .First(o => o.Id == user.Id && o.Rigths1.id == admin.id);

                if (dbUser == null)
                    Response.Redirect("/lk.aspx");
            }

            if (!IsPostBack)
            {
                SetDataModel(GridView1, GetModels());
                SetDataModel(GridView2, GetRides());
                SetDataModel(GridView3, GetContracts());
                SetDataModel(GridView4, GetDefects());
            }
        }

        #region DbModel

        public List<Models> GetModels()
        {
            using (var context = new MainEntities())
                return context.Models.Include(o => o.ModelTypes).ToList();
        }

        public List<Contracts> GetContracts()
        {
            using (var context = new MainEntities())
                return context.Contracts.ToList();
        }

        public List<Rides> GetRides()
        {
            using (var context = new MainEntities())
                return context.Rides.ToList();
        }

        public List<Defects> GetDefects()
        {
            using (var context = new MainEntities())
                return context.Defects.ToList();
        }

        public void UpdateModels(Models m)
        {
            if (m == null) return;
            using (var context = new MainEntities())
            {
                var model = context.Models.First(o => o.Id.Equals(m.Id));
                context.Entry(model).CurrentValues.SetValues(m);
                context.SaveChanges();
            }
        }

        public void UpdateRides(Rides r)
        {
            if (r == null) return;
            using (var context = new MainEntities())
            {
                var ride = context.Rides.First(o => o.Id.Equals(r.Id));
                context.Entry(ride).CurrentValues.SetValues(r);
                context.SaveChanges();
            }
        }

        public void UpdateContracts(Contracts c)
        {
            if (c == null) return;
            using (var context = new MainEntities())
            {
                var contract = context.Contracts.First(o => o.Id.Equals(c.Id));
                context.Entry(contract).CurrentValues.SetValues(c);
                context.SaveChanges();
            }
        }

        public void UpdateDefects(Defects d)
        {
            if (d == null) return;
            using (var context = new MainEntities())
            {
                var defects = context.Defects.First(o => o.Id.Equals(d.Id));
                context.Entry(defects).CurrentValues.SetValues(d);
                context.SaveChanges();
            }
        }

        public void InsertModels(Models m)
        {
            using (var context = new MainEntities())
                context.Models.Add(m);
        }

        public void InsertRides(Rides r)
        {
            using (var context = new MainEntities())
                context.Rides.Add(r);
        }

        public void InsertContracts(Contracts c)
        {
            using (var context = new MainEntities())
                context.Contracts.Add(c);
        }

        public void InsertDefects(Defects d)
        {
            using (var context = new MainEntities())
                context.Defects.Add(d);
        }

        public void DeleteModels(Models m)
        {
            using (var context = new MainEntities())
                context.Models.Remove(m);
        }
        public void DeleteRides(Rides r)
        {
            using (var context = new MainEntities())
                context.Rides.Remove(r);
        }
        public void DeleteContracts(Contracts c)
        {
            using (var context = new MainEntities())
                context.Contracts.Remove(c);
        }
        public void DeleteDefects(Defects d)
        {
            using (var context = new MainEntities())
                context.Defects.Remove(d);
        }

        #endregion

        protected void SetDataModel(GridView view, object source)
        {
            view.DataSourceID = "";
            view.DataSource = source;
            view.DataBind();
        }

        #region RowUpdating

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            try
            {
                var typeId = -1;
                var id = -1;

                var row = GridView1.Rows[e.RowIndex];

                var ltype = ((TextBox)(row.Cells[5].Controls[0])).Text;

                using (var context = new MainEntities())
                {
                    typeId = context.ModelTypes.First(o => o.Type.Equals(ltype)).Id;
                    id = context.Models.ToArray()[GridView1.EditIndex].Id;
                }

                var m = new Models
                {
                    Id = id,
                    Manufacturer = ((TextBox)(row.Cells[2].Controls[0])).Text,
                    Model = ((TextBox)(row.Cells[3].Controls[0])).Text,
                    Price = int.Parse(((TextBox)(row.Cells[4].Controls[0])).Text),
                    Type = typeId
                };

                UpdateModels(m);

            }
            catch (Exception)
            {
                return;
            }

            GridView1.EditIndex = -1;
            SetDataModel(GridView1, GetModels());
        }

        protected void GridView2_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            try
            {
                var id = -1;

                using (var context = new MainEntities())
                    id = context.Rides.ToArray()[GridView1.EditIndex].Id;

                var r = new Rides()
                {
                    Id = id,
                    StartTime = DateTime.Parse((string)e.NewValues["StartTime"]),
                    Status = (string)e.NewValues["Status"]
                };

                UpdateRides(r);
            }
            catch (Exception) { return; }

            GridView2.EditIndex = -1;
            SetDataModel(GridView2, GetModels());
        }

        protected void GridView3_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            try
            {
                var id = -1;

                using (var context = new MainEntities())
                    id = context.Contracts.ToArray()[GridView1.EditIndex].Id;

                var r = new Contracts()
                {
                    Id = id,
                    Costs = (int)e.NewValues["Costs"],
                    CreationDate = DateTime.Parse((string)e.NewValues["CreationDate"]),
                    ExpireDate = DateTime.Parse((string)e.NewValues["ExpireDate"]),
                    RentTime = DateTime.Parse((string)e.NewValues["RentTime"])
                };

                UpdateContracts(r);
            }
            catch (Exception) { return; }

            GridView2.EditIndex = -1;
            SetDataModel(GridView2, GetModels());
        }

        protected void GridView4_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            try
            {
                var id = -1;

                using (var context = new MainEntities())
                    id = context.Defects.ToArray()[GridView1.EditIndex].Id;

                var r = new Defects()
                {
                    Id = id,
                    Comment = (string)e.NewValues["Comment"],
                    Part = (string)e.NewValues["Part"],
                    Value = (string)e.NewValues["Value"]
                };

                UpdateDefects(r);
            }
            catch (Exception) { return; }

            GridView2.EditIndex = -1;
            SetDataModel(GridView2, GetModels());
        }

        #endregion

        #region CancelEditing

        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView1.EditIndex = -1;
            SetDataModel(GridView1, GetModels());
        }

        protected void GridView2_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView2.EditIndex = -1;
            SetDataModel(GridView2, GetRides());
        }

        protected void GridView3_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView3.EditIndex = -1;
            SetDataModel(GridView3, GetContracts());
        }

        protected void GridView4_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView4.EditIndex = -1;
            SetDataModel(GridView4, GetDefects());
        }

        #endregion

        #region Editing

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;
            SetDataModel(GridView1, GetModels());
        }

        protected void GridView2_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView2.EditIndex = e.NewEditIndex;
            SetDataModel(GridView2, GetRides());
        }

        protected void GridView3_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView3.EditIndex = e.NewEditIndex;
            SetDataModel(GridView3, GetContracts());
        }

        protected void GridView4_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView4.EditIndex = e.NewEditIndex;
            SetDataModel(GridView4, GetDefects());
        }

        #endregion

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("AddModel.aspx");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("AddRide.aspx");
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            Response.Redirect("AddContract.aspx");
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            Response.Redirect("AddDefect.aspx");
        }
    }
}