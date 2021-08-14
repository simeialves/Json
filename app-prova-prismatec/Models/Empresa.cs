using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace app_prova_prismatec.Models
{
    public class Empresa
    {
        public Guid Id { get; private set; }

        public string Cnpj { get; private set; }

        public string RazaoSocial { get; private set; }

        public string NomeFantasia { get; private set; }

        public string Telefone { get; private set; }

        public IEnumerable<Funcionario> Funcionarios { get; private set; }
    }
}