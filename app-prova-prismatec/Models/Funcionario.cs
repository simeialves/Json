using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace app_prova_prismatec.Models
{
    public class Funcionario
    {
        public Guid Id { get; set; }

        public string Cpf { get; set; }

        public string Nome { get; set; }

        public Guid IdEmpresa { get; set; }
    }
}
