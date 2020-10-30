using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApi_Localidades.Models
{
    public class Localidade
    {
        public int Id { get; set; }
        public string Cidade { get; set; }
        public string Nome { get; set; }
    }
}