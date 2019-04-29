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
                // из списка элемнтов с типом Rights выбирается первый элемент у которого в поле Value содержится admin
                var admin = context.Rigths.First(j => j.Value.Contains("admin"));

                var dbUser = context.Users
                    .First(o => o.Id == user.Id && o.Rigths1.id == admin.id);

                if (dbUser == null)
                    Response.Redirect("/lk.aspx");
            }

            // если не запрос на обнов данных то мы заполяем таблицы
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

        public List<Фильмы> Фильмы()
        {
            using (var context = new MainEntities())
                return context.Фильмы.ToList();
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

        public void ОбновитьФильм(Фильмы ф)
        {
            if (ф == null) return;
            using (var context = new MainEntities())
            {
                var defects = context.Фильмы.First(o => o.Id.Equals(ф.Id));
                // обьекту бд присваиваются поля ф
                context.Entry(defects).CurrentValues.SetValues(ф);
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

        public void УдалитьФильм(Фильмы ф)
        {
            using (var context = new MainEntities())
                context.Фильмы.Remove(ф);
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
                    // берем из списка актеров обьект номер которого соответствует редактируемой строке и получаем его айди
                    id = context.Актеры.ToArray()[GridView1.EditIndex].Id;

                var r = new Актеры()
                {
                    Id = id,
                    Год = int.Parse((string)e.NewValues["Год"]),
                    Имя = (string)e.NewValues["Имя"],
                    Фамилия = (string)e.NewValues["Фамилия"],
                    Страна = (string)e.NewValues["Страна"]
                };

                ОбновитьАктера(r);
            }
            catch (Exception) { return; }

            GridView1.EditIndex = -1;
            SetDataModel(GridView1, Актеры());
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
                    Имя = (string)e.NewValues["Имя"],
                    Страна = (string)e.NewValues["Страна"],
                    Фамилия = (string)e.NewValues["Фамилия"],
                    Информация = (string)e.NewValues["Информация"]
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
                    Id = id,
                    Страна = (string)e.NewValues["Страна"],
                    Адрес = (string)e.NewValues["Адрес"],
                    Название = (string)e.NewValues["Название"],
                    Телефон = (string)e.NewValues["Телефон"]
                };

                ОбновитьСтудию(r);
            }
            catch (Exception) { return; }

            GridView3.EditIndex = -1;
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
                    Id = id,
                    Имя = (string)e.NewValues["Имя"],
                    Фамилия = (string)e.NewValues["Фамилия"],
                    Злодей = (bool)e.NewValues["Злодей"]
                };

                ОбновитьПерсонажа(r);
            }
            catch (Exception) { return; }

            GridView4.EditIndex = -1;
            SetDataModel(GridView2, Персонажи());
        }

        protected void GridView5_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            try
            {
                var id = -1;

                using (var context = new MainEntities())
                    id = context.Фильмы.ToArray()[GridView5.EditIndex].Id;

                var r = new Фильмы()
                {
                    Id = id,
                    Название = (string)e.NewValues["Название"],
                    Страна = (string)e.NewValues["Страна"],
                    Дата_выхода = DateTime.Parse((string)e.NewValues["Дата_выхода"]),
                    Количество_серий = int.Parse((string)e.NewValues["Количество_серий"]),
                    Режиссер = int.Parse((string)e.NewValues["Режиссер"]),
                    Студия = int.Parse((string)e.NewValues["Студия"]),
                    Сюжет = (string)e.NewValues["Сюжет"]
                };

                ОбновитьФильм(r);
            }
            catch (Exception) { return; }

            GridView5.EditIndex = -1;
            SetDataModel(GridView5, Фильмы());
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

        protected void GridView5_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView5.EditIndex = -1;
            SetDataModel(GridView5, Персонажи());
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

        protected void GridView5_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView5.EditIndex = e.NewEditIndex;
            SetDataModel(GridView5, Фильмы());
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

        protected void Unnamed1_Click(object sender, EventArgs e)
        {
            Response.Redirect("AddFilm.aspx");
        }

        protected void GridView5_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            using (var context = new MainEntities())
            {
                var model = context.Фильмы.ToList()[e.RowIndex];
                context.Фильмы.Remove(model);
                context.SaveChanges();
            }
            GridView5.DataBind();
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            using (var context = new MainEntities())
            {
                var model = context.Актеры.ToList()[e.RowIndex];
                context.Актеры.Remove(model);
                context.SaveChanges();
            }
            GridView1.DataBind();
        }

        protected void GridView2_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            using (var context = new MainEntities())
            {
                var model = context.Студии.ToList()[e.RowIndex];
                context.Студии.Remove(model);
                context.SaveChanges();
            }
            GridView2.DataBind();
        }

        protected void GridView3_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            using (var context = new MainEntities())
            {
                var model = context.Режиссеры.ToList()[e.RowIndex];
                context.Режиссеры.Remove(model);
                context.SaveChanges();
            }
            GridView3.DataBind();
        }

        protected void GridView4_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            using (var context = new MainEntities())
            {
                var model = context.Персонажи.ToList()[e.RowIndex];
                context.Персонажи.Remove(model);
                context.SaveChanges();
            }
            GridView4.DataBind();
        }
    }
}