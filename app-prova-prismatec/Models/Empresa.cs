using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace app_prova_prismatec.Models
{
    public class Empresa
    {
        public Guid Id { get; set; }

        public string Cnpj { get; set; }

        public string RazaoSocial { get; set; }

        public string NomeFantasia { get; set; }

        public string Telefone { get; set; }
        public List<Funcionario> Funcionarios { get; set; }
        //public IEnumerable<Funcionario> Funcionarios { get; set; }

        public static List<Empresa> VerificarTelefone(List<Empresa> listaEmpresas)
        {
            var result = listaEmpresas.Where(u => u.Telefone.Contains("(5"));
            List<Empresa> listResult = new List<Empresa>();

            foreach (Empresa item in result)
            {
              //  Console.WriteLine("Empresa: " + item.RazaoSocial + "\nTelefone: " + item.Telefone + "\n");
                listResult.Add(item);
            }
            return listResult;
        }



        //public IEnumerable<Funcionario> Funcionarios { get; set; }

        //public string JsonSerializar(Empresa empresa)
        //{
        //    return JsonConvert.SerializeObject(empresa, Formatting.Indented);
        //}

        //public string JsonSerializarLista(List<Empresa> lista)
        //{
        //    return JsonConvert.SerializeObject(lista, Formatting.Indented);
        //}

        //public static Empresa JsonDeserializar(string Json)
        //{
        //    return JsonConvert.DeserializeObject<List<Empresa>>(Json));
        //}
    }
}