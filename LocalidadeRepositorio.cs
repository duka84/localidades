using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApi_Localidades.Models
{
    public class LocalidadeRepositorio : ILocalidadeRepositorio
    {
        private List<Localidade> localidades = new List<Localidade>();
        private int _nextId = 1;

        public LocalidadeRepositorio()
        {
            Add(new Localidade { Id = 1, Cidade = "RIO", Nome = "Rio de Janeiro" });
            Add(new Localidade { Id = 2, Cidade = "RIO", Nome = "Rio de Janeiro, Santos Dumont" });
            Add(new Localidade { Id = 3, Cidade = "RIO", Nome = "Rio de Janeiro, Galeão" });
            Add(new Localidade { Id = 4, Cidade = "RIO", Nome = "Rio de Janeiro, NovoRio" });
            Add(new Localidade { Id = 5, Cidade = "RIO", Nome = "Rio de Janeiro, Barra da Tijuca" });
            Add(new Localidade { Id = 6, Cidade = "SAO", Nome = "São Paulo" });
            Add(new Localidade { Id = 7, Cidade = "SAO", Nome = "São Paulo, Congonhas" });
            Add(new Localidade { Id = 7, Cidade = "SAO", Nome = "São Paulo, Guarulhos" });
        }

        public Localidade Add(Localidade item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("item");
            }
            item.Id = _nextId++;
            localidades.Add(item);
            return item;
        }

        public Localidade Get(int id)
        {
            return localidades.Find(l => l.Id == id);
        }
        public IEnumerable<Localidade> GetAll()
        {
            return localidades;
        }
        public void Remove(int id)
        {
            localidades.RemoveAll(l => l.Id == id);
        }
        public bool Update(Localidade item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("item");
            }
            int index = localidades.FindIndex(l => l.Id == item.Id);
            if (index == -1)
            {
                return false;
            }
            localidades.RemoveAt(index);
            localidades.Add(item);
            return true;
        }
    }
}
