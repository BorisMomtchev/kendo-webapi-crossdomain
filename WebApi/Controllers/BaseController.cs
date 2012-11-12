using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BusinessObjects;
using DataObjects;

namespace WebApi.Controllers
{
    /// <summary>
    /// This is the common base ApiController used for all controllers.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class BaseController<T> : ApiController where T : Entity
    {
        // FIELDS
        private readonly IRepository<T> _repository;

        /// <summary>
        /// Dependency Injection using Unity.  Look at the App_Start/UnityWebApi.cs file for usage.
        /// </summary>
        /// <param name="repository"></param>
        public BaseController(IRepository<T> repository)
        {
            this._repository = repository;
        }

        
        #region Basic CRUD

        /// <summary>
        /// Get all the Products in the repository.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<T> Get()
        {
            return _repository.Get();
        }

        /// <summary>
        /// Get the selected Product.
        /// </summary>
        /// <param name="id">Id</param>
        /// <returns></returns>
        public T Get(int id)
        {
            T model = _repository.GetById(id);
            if (model == null)
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));

            return model;
        }

        /// <summary>
        /// Insert a new Product into the repository.
        /// </summary>
        /// <param name="model">Product</param>
        /// <returns></returns>
        public HttpResponseMessage Post(T model)
        {
            if (ModelState.IsValid)
            {
                _repository.Insert(model);

                var response = Request.CreateResponse(HttpStatusCode.Created, model);
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = model.Id }));

                return response;
            }
            else
            {
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.BadRequest));
            }
        }

        /// <summary>
        /// Update the selected Product.
        /// </summary>
        /// <param name="id">Id</param>
        /// <param name="model">Product</param>
        /// <returns></returns>
        public HttpResponseMessage Put(T model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _repository.Update(model);
                }
                catch (Exception)
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound);
                }
                return Request.CreateResponse(HttpStatusCode.OK, model);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }

        /// <summary>
        /// Delete the selected Product.
        /// </summary>
        /// <param name="id">Id</param>
        /// <returns></returns>
        public HttpResponseMessage Delete(int id)
        {
            T model = _repository.GetById(id);
            if (model == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            try
            {
                _repository.Delete(model);
            }
            catch (Exception)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            return Request.CreateResponse(HttpStatusCode.OK, model);
        }
        #endregion

    }
}