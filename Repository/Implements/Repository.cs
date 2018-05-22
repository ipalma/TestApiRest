using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Repository.Implements
{
    public class Repository<TModel, TViewModel> : IRepository<TModel, TViewModel> where TModel : class where TViewModel : IViewModel<TModel>, new()
    {
        private DbContext context;
        protected virtual DbSet<TModel> DbSet { get { return context.Set<TModel>(); } }

        public Repository(DbContext context)
        {
            this.context = context;
        }
        public virtual TViewModel Add(TViewModel model)
        {
            var mdl = model.ToDataBase();
            DbSet.Add(mdl);
            try
            {
                context.SaveChanges();
                model.FromDataBase(mdl);
                return model;
            }
            catch (Exception ex)
            {
                return default(TViewModel);
            }
        }

        public int Delete(TViewModel model)
        {
            try
            {
                DbSet.Remove(DbSet.Find(model.GetKeys()));
                return context.SaveChanges();
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public int Delete(Expression<Func<TModel, bool>> query)
        {
            try
            {
                DbSet.RemoveRange(DbSet.Where(query));
                return context.SaveChanges();
            }
            catch (Exception)
            {

                return 0;
            }
        }

        public ICollection<TViewModel> Get()
        {
            var data = new List<TViewModel>();
            foreach (var model in DbSet)
            {
                TViewModel obj = new TViewModel();
                obj.FromDataBase(model);
                data.Add(obj);
            }
            return data;
        }

        public TViewModel Get(params object[] keys)
        {
            TViewModel model = GetModelByParams(keys).FirstOrDefault();
            return model;
        }

        public TViewModel Get(params Guid[] keys)
        {
            TViewModel model = GetModelByParams(keys).FirstOrDefault();
            return model;
        }

        public TViewModel Get(int key)
        {
            var data = DbSet.Find(key);
            TViewModel obj = new TViewModel();
            obj.FromDataBase(data);
            return obj;
        }

        public TViewModel Get(params string[] keys)
        {
            TViewModel model = GetModelByParams(keys).FirstOrDefault();
            return model;
        }

        public ICollection<TViewModel> Get(Expression<Func<TModel, bool>> query)
        {
            var dataQuery = DbSet.Where(query);
            var data = new List<TViewModel>();
            foreach (var model in dataQuery)
            {
                TViewModel obj = new TViewModel();
                obj.FromDataBase(model);
                data.Add(obj);
            }
            return data;
        }

        public int Update(TViewModel model)
        {
            try
            {
                var obj = DbSet.Find(model.GetKeys());
                model.UpdateDataBase(obj);
                return context.SaveChanges();
            }
            catch (Exception)
            {
                return 0;
            }
            
        }

        private ICollection<TViewModel> GetModelByParams(params object[] keys)
        {
            List<TViewModel> resultList = new List<TViewModel>();
            foreach (var key in keys)
            {
                var data = DbSet.Find(Convert.ToInt32(key));
                var result = new TViewModel();
                result.FromDataBase(data);
                resultList.Add(result);
            }
            
            
            return resultList;
        }
    }
}
