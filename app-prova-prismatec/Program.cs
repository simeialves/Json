using app_prova_prismatec.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
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

            int contFuncionario = 1;
            int contEmpresa = 1;

            var pathFile = ConfigurationManager.ConnectionStrings["local"].ConnectionString;
            if (!Directory.Exists(pathFile))
                    Directory.CreateDirectory(pathFile);

            pathFile = pathFile + "\\arquivo.json";

            #region Empresa1
            var empresa1 = new Empresa();

            empresa1.Id = IntExtensions.ToGuid(contEmpresa);
            empresa1.Cnpj = "55.611.018/0001-11";
            empresa1.RazaoSocial = "Benício e Clarice Alimentos ME";
            empresa1.NomeFantasia = "Benício e Clarice Alimentos ME";
            empresa1.Telefone = "(31) 2922-5424";
            empresa1.Funcionarios = new List<Funcionario>();

            Funcionario funcionario1 = new Funcionario();
            funcionario1.Id = IntExtensions.ToGuid(contFuncionario);
            funcionario1.Cpf = "904.604.426-27";
            funcionario1.Nome = "Pietro Marcelo Alexandre Viana";
            funcionario1.IdEmpresa = empresa1.Id;
            empresa1.Funcionarios.Add(funcionario1);
            contFuncionario++;

            Funcionario funcionario2 = new Funcionario();
            funcionario2.Id = IntExtensions.ToGuid(contFuncionario);
            funcionario2.Cpf = "813.117.706-82";
            funcionario2.Nome = "Rodrigo Cláudio Alves";
            funcionario2.IdEmpresa = empresa1.Id;
            empresa1.Funcionarios.Add(funcionario2);
            contFuncionario++;

            contEmpresa++;

            #endregion

            #region Empresa2
            Empresa empresa2 = new Empresa();

            empresa2.Id = IntExtensions.ToGuid(contEmpresa);
            empresa2.Cnpj = "96.319.784/0001-94";
            empresa2.RazaoSocial = "Breno e Elias Restaurante Ltda";
            empresa2.NomeFantasia = "Restaurante 2 Irmãos";
            empresa2.Telefone = "(55) 2695-0313";
            empresa2.Funcionarios = new List<Funcionario>();

            Funcionario funcionario3 = new Funcionario();
            funcionario3.Id = IntExtensions.ToGuid(contFuncionario);
            funcionario3.Cpf = "644.004.020-02";
            funcionario3.Nome = "Luciana Jennifer Pereira";
            funcionario3.IdEmpresa = empresa2.Id;
            empresa2.Funcionarios.Add(funcionario3);
            contFuncionario++;

            Funcionario funcionario4 = new Funcionario();
            funcionario4.Id = IntExtensions.ToGuid(contFuncionario);
            funcionario4.Cpf = "449.149.940-38";
            funcionario4.Nome = "Heitor Bernardo Benício Dias";
            funcionario4.IdEmpresa = empresa2.Id;
            empresa2.Funcionarios.Add(funcionario4);
            contFuncionario++;

            contEmpresa++;
            #endregion

            #region Empresa3
            Empresa empresa3 = new Empresa();

            empresa3.Id = IntExtensions.ToGuid(contEmpresa);
            empresa3.Cnpj = "51.859.478/0001-02";
            empresa3.RazaoSocial = "Nicolas e Emilly Locações de Automóveis ME";
            empresa3.NomeFantasia = "N&M Locações";
            empresa3.Telefone = "(51) 2846-7950";
            empresa3.Funcionarios = new List<Funcionario>();

            Funcionario funcionario5 = new Funcionario();
            funcionario5.Id = IntExtensions.ToGuid(contFuncionario);
            funcionario5.Cpf = "506.908.520-45";
            funcionario5.Nome = "Alícia Tatiane Sebastiana Galvão";
            funcionario5.IdEmpresa = empresa3.Id;
            empresa3.Funcionarios.Add(funcionario5);
            contFuncionario++;

            Funcionario funcionario6 = new Funcionario();
            funcionario6.Id = IntExtensions.ToGuid(contFuncionario);
            funcionario6.Cpf = "282.579.600-04";
            funcionario6.Nome = "Melissa Carla Giovanna Pires";
            funcionario6.IdEmpresa = empresa3.Id;
            empresa3.Funcionarios.Add(funcionario6);
            contFuncionario++;

            Funcionario funcionario7 = new Funcionario();
            funcionario7.Id = IntExtensions.ToGuid(contFuncionario);
            funcionario7.Cpf = "337.623.520-11";
            funcionario7.Nome = "Alexandre César Leandro Caldeira";
            funcionario7.IdEmpresa = empresa3.Id;
            empresa3.Funcionarios.Add(funcionario7);
            contFuncionario++;

            contEmpresa++;
            #endregion

            List<Empresa> listaEmpresas = new List<Empresa>();

            listaEmpresas.Add(empresa1);
            listaEmpresas.Add(empresa2);
            listaEmpresas.Add(empresa3);

            try
            {
                using (StreamWriter sw = new StreamWriter(pathFile))
                {
                    sw.WriteLine(JsonConvert.SerializeObject(listaEmpresas, Formatting.Indented));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro: " + ex);
            }

            try
            {
                var strJson = "";
                
                using (StreamReader sr = new StreamReader(pathFile))
                {
                    strJson = sr.ReadToEnd();
                }

                var empresa = JsonConvert.DeserializeObject<List<Empresa>>(strJson);

                List<Empresa> result = Empresa.VerificarTelefone(empresa);

                Console.WriteLine("Foram localizadas as seguintes empresas com o código do Rio Grande do Sul:");
                foreach (Empresa item in result)
                {
                    Console.WriteLine("\n");
                    Console.WriteLine("----------");
                    Console.WriteLine("\n");
                    Console.WriteLine("Id: " + item.Id);
                    Console.WriteLine("Cnpj: " + item.Cnpj);
                    Console.WriteLine("Razao Social: " + item.RazaoSocial);
                    Console.WriteLine("Nome Fantasia: " + item.NomeFantasia);
                    Console.WriteLine("Telefone: " + item.Telefone);
                }
                Console.Read();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro: " + ex);
            }
        }
    }
}
