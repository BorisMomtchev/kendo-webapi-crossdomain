using System;
using System.Collections.Generic;
using System.Linq;
using BusinessObjects;

namespace DataObjects
{
    public class ProductRepository : IProductRepository
    {
        // FIELDS
        private List<Product> _products;

        // C~tors
        public ProductRepository()
        {
            _products = ProductData.Current;
        }

        // IProductRepository
        public IQueryable<BusinessObjects.Product> GetAll()
        {
            return _products.AsQueryable();
        }

        public IEnumerable<BusinessObjects.Product> Get(System.Linq.Expressions.Expression<Func<BusinessObjects.Product, bool>> filter = null, Func<IQueryable<BusinessObjects.Product>, IOrderedQueryable<BusinessObjects.Product>> orderBy = null, string includeProperties = "")
        {
            IQueryable<Product> query = _products.AsQueryable();

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

        public BusinessObjects.Product GetById(object id)
        {
            return _products.Where(c => c.Id == (int)id).SingleOrDefault();
        }

        public void Insert(BusinessObjects.Product entity)
        {
            // Get the highest Id for the Products and increment it,
            // then assign it to the new entity before adding to the repository.
            var maxId = _products.Select(c => c.Id).Max();
            entity.Id = maxId + 1;

            _products.Add(entity);
        }

        public void Delete(object id)
        {
            
        }

        public void Delete(BusinessObjects.Product entityToDelete)
        {
        }

        public void Update(BusinessObjects.Product entityToUpdate)
        {
            Product product = _products.Where(p => p.Id == entityToUpdate.Id).SingleOrDefault();
            product.Name = entityToUpdate.Name;
            product.Price = entityToUpdate.Price;
            product.Category.CategoryName = entityToUpdate.Category.CategoryName;
            product.Category.Id = entityToUpdate.Category.Id;

            // Update the repository here.
        }
    }
}
