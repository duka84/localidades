using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApi_Localidades.Models
{
    public interface ILocalidadeRepositorio
    {
        IEnumerable<Localidade> GetAll();
        Localidade Get(int id);
        Localidade Add(Localidade item);
        void Remove(int id);
        bool Update(Localidade item);
    }
}