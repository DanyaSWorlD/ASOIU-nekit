using System.Collections.Generic;
using System.Linq;

namespace Website
{
    public static class DB
    {
        public static List<Режиссеры> Режиссеры()
        {
            using (var context = new MainEntities())
                return context.Режиссеры.ToList();
        }

        public static List<Студии> Студии()
        {
            using (var context = new MainEntities())
                return context.Студии.ToList();
        }
        public static List<Персонажи> Персонажи()
        {
            using (var context = new MainEntities())
                return context.Персонажи.ToList();
        }
        public static List<Актеры> Актеры()
        {
            using (var context = new MainEntities())
                return context.Актеры.ToList();
        }

        public static List<Фильмы> Фильмы()
        {
            using (var context = new MainEntities())
                return context.Фильмы.ToList();
        }

        public static void ОбновитьФильм(Фильмы ф)
        {
            if (ф == null) return;
            using (var context = new MainEntities())
            {
                var contract = context.Фильмы.First(o => o.Id.Equals(ф.Id));
                context.Entry(contract).CurrentValues.SetValues(ф);
                context.SaveChanges();
            }
        }

        public static void УдалитьФильм(Фильмы ф)
        {
            if (ф == null) return;
            if (ф.Название == null) return;
            using (var context = new MainEntities())
                context.Фильмы.Remove(ф);
        }
    }
}