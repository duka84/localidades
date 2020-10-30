using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApi_Localidades.Models;

namespace WebApi_Localidades.Controllers
{
    public class LocalidadesController : ApiController
    {
        static readonly ILocalidadeRepositorio repositorio = new LocalidadeRepositorio();
        public IEnumerable<Localidade> GetAllLocalidades()
        {
            return repositorio.GetAll();
        }

        public Localidade GetLocalidade(int id)
        {
            Localidade item = repositorio.Get(id);
            if (item == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            return item;
        }
        public IEnumerable<Localidade> GetLocalidadesPorCidade(string cidade)
        {
            return repositorio.GetAll().Where(
                l => string.Equals(l.Cidade, cidade, StringComparison.OrdinalIgnoreCase));
        }

        public HttpResponseMessage PostLocalidade(Localidade item)
        {
            item = repositorio.Add(item);
            var response = Request.CreateResponse<Localidade>(HttpStatusCode.Created, item);

            string uri = Url.Link("DefaultApi", new { id = item.Id });
            response.Headers.Location = new Uri(uri);
            return response;
        }

        public void PutLocalidade(int id, Localidade localidade)
        {
            localidade.Id = id;
            if (!repositorio.Update(localidade))
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
        }

        public void DeleteLocalidade(int id)
        {
            Localidade item = repositorio.Get(id);
            if (item == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            repositorio.Remove(id);
        }
    }
}
