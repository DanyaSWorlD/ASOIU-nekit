using System;
using System.Collections.Generic;
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
                SetDataModel(GridView1, Актеры());
                SetDataModel(GridView2, Студии());
                SetDataModel(GridView3, Режиссеры());
                SetDataModel(GridView4, Персонажи());
            }
        }

        #region DbModel

        public List<Актеры> Актеры()
        {
            using (var context = new MainEntities())
                return context.Актеры.ToList();
        }

        public List<Режиссеры> Режиссеры()
        {
            using (var context = new MainEntities())
                return context.Режиссеры.ToList();
        }

        public List<Студии> Студии()
        {
            using (var context = new MainEntities())
                return context.Студии.ToList();
        }

        public List<Персонажи> Персонажи()
        {
            using (var context = new MainEntities())
                return context.Персонажи.ToList();
        }

        public void ОбновитьАктера(Актеры а)
        {
            if (а == null) return;
            using (var context = new MainEntities())
            {
                var model = context.Актеры.First(o => o.Id.Equals(а.Id));
                context.Entry(model).CurrentValues.SetValues(а);
                context.SaveChanges();
            }
        }

        public void ОбновитьРежиссера(Режиссеры r)
        {
            if (r == null) return;
            using (var context = new MainEntities())
            {
                var ride = context.Режиссеры.First(o => o.Id.Equals(r.Id));
                context.Entry(ride).CurrentValues.SetValues(r);
                context.SaveChanges();
            }
        }

        public void ОбновитьСтудию(Студии c)
        {
            if (c == null) return;
            using (var context = new MainEntities())
            {
                var contract = context.Студии.First(o => o.Id.Equals(c.Id));
                context.Entry(contract).CurrentValues.SetValues(c);
                context.SaveChanges();
            }
        }

        public void ОбновитьПерсонажа(Персонажи d)
        {
            if (d == null) return;
            using (var context = new MainEntities())
            {
                var defects = context.Персонажи.First(o => o.Id.Equals(d.Id));
                context.Entry(defects).CurrentValues.SetValues(d);
                context.SaveChanges();
            }
        }

        public void УдалитьАктера(Актеры m)
        {
            using (var context = new MainEntities())
                context.Актеры.Remove(m);
        }

        public void УдалитьРежиссера(Режиссеры r)
        {
            using (var context = new MainEntities())
                context.Режиссеры.Remove(r);
        }

        public void УдалитьСтудию(Студии c)
        {
            using (var context = new MainEntities())
                context.Студии.Remove(c);
        }

        public void УдалитьПерсонажа(Персонажи d)
        {
            using (var context = new MainEntities())
                context.Персонажи.Remove(d);
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
                var id = -1;

                using (var context = new MainEntities())
                    id = context.Актеры.ToArray()[GridView1.EditIndex].Id;

                var r = new Актеры()
                {
                    Id = id,
                };

                ОбновитьАктера(r);
            }
            catch (Exception) { return; }

            GridView2.EditIndex = -1;
            SetDataModel(GridView1, Режиссеры());
        }

        protected void GridView2_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            try
            {
                var id = -1;

                using (var context = new MainEntities())
                    id = context.Режиссеры.ToArray()[GridView2.EditIndex].Id;

                var r = new Режиссеры()
                {
                    Id = id,
                };

                ОбновитьРежиссера(r);
            }
            catch (Exception) { return; }

            GridView2.EditIndex = -1;
            SetDataModel(GridView2, Режиссеры());
        }

        protected void GridView3_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            try
            {
                var id = -1;

                using (var context = new MainEntities())
                    id = context.Студии.ToArray()[GridView3.EditIndex].Id;

                var r = new Студии()
                {
                    Id = id
                };

                ОбновитьСтудию(r);
            }
            catch (Exception) { return; }

            GridView2.EditIndex = -1;
            SetDataModel(GridView2, Студии());
        }

        protected void GridView4_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            try
            {
                var id = -1;

                using (var context = new MainEntities())
                    id = context.Персонажи.ToArray()[GridView4.EditIndex].Id;

                var r = new Персонажи()
                {
                    Id = id
                };

                ОбновитьПерсонажа(r);
            }
            catch (Exception) { return; }

            GridView2.EditIndex = -1;
            SetDataModel(GridView2, Персонажи());
        }

        #endregion

        #region CancelEditing

        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView1.EditIndex = -1;
            SetDataModel(GridView1, Актеры());
        }

        protected void GridView2_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView2.EditIndex = -1;
            SetDataModel(GridView2, Студии());
        }

        protected void GridView3_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView3.EditIndex = -1;
            SetDataModel(GridView3, Режиссеры());
        }

        protected void GridView4_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView4.EditIndex = -1;
            SetDataModel(GridView4, Персонажи());
        }

        #endregion

        #region Editing

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;
            SetDataModel(GridView1, Актеры());
        }

        protected void GridView2_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView2.EditIndex = e.NewEditIndex;
            SetDataModel(GridView2, Студии());
        }

        protected void GridView3_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView3.EditIndex = e.NewEditIndex;
            SetDataModel(GridView3, Режиссеры());
        }

        protected void GridView4_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView4.EditIndex = e.NewEditIndex;
            SetDataModel(GridView4, Персонажи());
        }

        #endregion

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("AddActor.aspx");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("AddStudio.aspx");
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            Response.Redirect("AddRegisser.aspx");
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            Response.Redirect("AddHero.aspx");
        }
    }
}