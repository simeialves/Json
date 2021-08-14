using app_prova_prismatec.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace app_prova_prismatec
{
    class Program
    {
        static void Main(string[] args)
        {
            //TODO: Conforme a abordagem Domain Driven Design, crie uma instância e utilize a entidade "Empresa" e "Funcionario",
            //populando suas propriedades.

            //TODO: Salve o objeto criado em formato .json em um arquivo local (pasta configurada no app settings).

            //TODO: Altere os dados das propriedades e salve novamente o arquivo (o mesmo não pode ser sobrescrito).

            //TODO: Crie um método que verifica se no telefone da empresa, se o código da região é do RS (Utilize LINQ).

            //TODO: Imprima no console logs dos eventos de todas as ações realizadas no sistema.

            Funcionario funcionario1 = new Funcionario();

            funcionario1.Id = IntExtensions.ToGuid(1);
            funcionario1.Cpf = "10067065694";
            funcionario1.Nome = "Simei Alves";
            funcionario1.IdEmpresa = IntExtensions.ToGuid(1);

            Console.WriteLine("Id: " + funcionario1.Id);
            Console.WriteLine("Cpf: " + funcionario1.Cpf);
            Console.WriteLine("Nome: " + funcionario1.Nome);
            Console.WriteLine("IdEmpresa: " + funcionario1.IdEmpresa);
            Console.WriteLine("\n");

            Funcionario funcionario2 = new Funcionario();

            funcionario2.Id = IntExtensions.ToGuid(2);
            funcionario2.Cpf = "06650590606";
            funcionario2.Nome = "Stefane Parreiras";
            funcionario2.IdEmpresa = IntExtensions.ToGuid(2);

            Console.WriteLine("Id: " + funcionario2.Id);
            Console.WriteLine("Cpf: " + funcionario2.Cpf);
            Console.WriteLine("Nome: " + funcionario2.Nome);
            Console.WriteLine("IdEmpresa: " + funcionario2.IdEmpresa);
            Console.WriteLine("\n");

            Funcionario funcionario3 = new Funcionario();

            funcionario3.Id = IntExtensions.ToGuid(3);
            funcionario3.Cpf = "08818963651";
            funcionario3.Nome = "Erick Clavell";
            funcionario3.IdEmpresa = IntExtensions.ToGuid(3);

            Console.WriteLine("Id: " + funcionario3.Id);
            Console.WriteLine("Cpf: " + funcionario3.Cpf);
            Console.WriteLine("Nome: " + funcionario3.Nome);
            Console.WriteLine("IdEmpresa: " + funcionario3.IdEmpresa);

            //var _data = new
            //{
            //    um = 1,
            //    dois = 2,
            //    tres = 3
            //};

            //string json = JsonConvert.SerializeObject(_data);

            //System.IO.File.WriteAllText(@"C:\objeto.json", json);

        }
    }
        public static class IntExtensions
        {
            public static Guid ToGuid(this Int32 value)
            {
                if (value >= 0) // if value is positive
                    return new Guid(string.Format("00000000-0000-0000-0000-00{0:0000000000}", value));
                else if (value > Int32.MinValue) // if value is negative
                    return new Guid(string.Format("00000000-0000-0000-0000-01{0:0000000000}", Math.Abs(value)));
                else //if (value == Int32.MinValue)
                    return new Guid("00000000-0000-0000-0000-012147483648");  // Because Abs(-12147483648) generates a stack overflow due to being > 12147483647 (Int32.Max)
            }
        }

}
