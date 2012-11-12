using System;
using System.Collections.Generic;
using System.Linq;
using BusinessObjects;

namespace DataObjects
{
    public class CategoryRepository : ICategoryRepository
    {
        // FIELDS
        private List<Category> _categories;

        // C~tors
        public CategoryRepository()
        {
            this._categories = CategoryData.GetData();
        }

        // ICategoryRepository
        public IQueryable<Category> GetAll()
        {
            return _categories.AsQueryable();
        }

        public IEnumerable<Category> Get(System.Linq.Expressions.Expression<Func<Category, bool>> filter = null, Func<IQueryable<Category>, IOrderedQueryable<Category>> orderBy = null, string includeProperties = "")
        {
            IQueryable<Category> query = _categories.AsQueryable();

            if (filter != null)
            {
                query = query.Where(filter);
            }

            if (orderBy != null)
            {
                return orderBy(query).ToList();
            }
            else
            {
                return query.ToList();
            }
        }

        public Category GetById(object id)
        {
            return _categories.Where(c => c.Id == (int)id).SingleOrDefault();
        }

        public void Insert(Category entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(object id)
        {
            throw new NotImplementedException();
        }

        public void Delete(Category entityToDelete)
        {
            throw new NotImplementedException();
        }

        public void Update(Category entityToUpdate)
        {
            throw new NotImplementedException();
        }
    }
}
