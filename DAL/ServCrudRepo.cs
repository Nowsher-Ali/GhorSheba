using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class ServCrudRepo : AdminIRepository<ServiceProvider, int>
    {
        ShebaDbEntities db;
        public ServCrudRepo(ShebaDbEntities db)
        {
            this.db = db;
        }
        public void Add(ServiceProvider e)
        {
            db.ServiceProviders.Add(e);
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            var e = db.ServiceProviders.FirstOrDefault(en => en.user_id == id);
            db.ServiceProviders.Remove(e);
            db.SaveChanges();
        }

        public void Edit(ServiceProvider e)
        {
            var p = db.ServiceProviders.FirstOrDefault(en => en.user_id == e.user_id);
            db.Entry(p).CurrentValues.SetValues(e);
            db.SaveChanges();
        }

        public List<ServiceProvider> Get()
        {
            return db.ServiceProviders.ToList();
        }

        public ServiceProvider Get(int id)
        {
            return db.ServiceProviders.FirstOrDefault(e => e.user_id == id);
        }
    }
}
