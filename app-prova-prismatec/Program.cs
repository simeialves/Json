using app_prova_prismatec.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace app_prova_prismatec
{
    class Program
    {
        public static void VerificarTelefone(List<Empresa> empresas, int ms)
        {
            Console.WriteLine("\nVerificando empresas com o código do Telefone do Rio Grande do Sul - " + DateTime.Now);
            Thread.Sleep(ms);

            List<Empresa> result = Empresa.VerificarTelefone(empresas);

            Console.WriteLine("\nForam localizadas " + result.Count + " empresas com o código do Rio Grande do Sul:\n");
            foreach (Empresa item in result)
            {
                Console.WriteLine("Id: " + item.Id);
                Console.WriteLine("Cnpj: " + item.Cnpj);
                Console.WriteLine("Razao Social: " + item.RazaoSocial);
                Console.WriteLine("Nome Fantasia: " + item.NomeFantasia);
                Console.WriteLine("Telefone: " + item.Telefone);
                Console.WriteLine("\n");
            }

            Thread.Sleep(ms + 2000);
        }
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
            int ms = 3000;
            DateTime horarioInicial;
            string novoTelefone = "(54) 3397-5706";

            horarioInicial = DateTime.Now;

            Console.WriteLine("Inicio do processo - " + DateTime.Now);
            Thread.Sleep(ms);

            var pathFile = ConfigurationManager.ConnectionStrings["path"].ConnectionString;

            Console.WriteLine("\nVerificando a existência do diretório do arquivo Json - " + DateTime.Now);
            Thread.Sleep(ms);

            if (!Directory.Exists(pathFile))
            {
                Directory.CreateDirectory(pathFile);
                Console.WriteLine("\nDiretório não encontrado. Criando diretório do arquivo Json em \"" + pathFile + "\" - " + DateTime.Now);
                Thread.Sleep(ms);
            }
            else
            {
                Console.WriteLine("\nDiretório localizado - " + DateTime.Now);
                Thread.Sleep(ms);
            }

            pathFile += "\\arquivo.json";

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

            Console.WriteLine("\nPopulando instância com a primeira empresa (" + empresa1.RazaoSocial + ") e seus funcionários - " + DateTime.Now);
            Thread.Sleep(ms);

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

            Console.WriteLine("\nPopulando instância com a segunda empresa (" + empresa2.RazaoSocial + ") e seus funcionários - " + DateTime.Now);
            Thread.Sleep(ms);

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

            Console.WriteLine("\nPopulando instância com a terceira empresa (" + empresa3.RazaoSocial + ") e seus funcionários - " + DateTime.Now);
            Thread.Sleep(ms);

            #region Empresa4
            /*Empresa empresa4 = new Empresa();

            empresa4.Id = IntExtensions.ToGuid(contEmpresa);
            empresa4.Cnpj = "13.422.886/0001-03";
            empresa4.RazaoSocial = "Lorenzo e Nina Gráfica ME";
            empresa4.NomeFantasia = "Gráfica da Nina";
            empresa4.Telefone = "(55) 3397-5706";
            empresa4.Funcionarios = new List<Funcionario>();

            Funcionario funcionario8 = new Funcionario();
            funcionario8.Id = IntExtensions.ToGuid(contFuncionario);
            funcionario8.Cpf = "148.266.850-50";
            funcionario8.Nome = "Bento Thales Costa";
            funcionario8.IdEmpresa = empresa4.Id;
            empresa4.Funcionarios.Add(funcionario8);
            contFuncionario++;

            Funcionario funcionario9 = new Funcionario();
            funcionario9.Id = IntExtensions.ToGuid(contFuncionario);
            funcionario9.Cpf = "604.529.910-80";
            funcionario9.Nome = "Daiane Marli Carolina Carvalho";
            funcionario9.IdEmpresa = empresa4.Id;
            empresa4.Funcionarios.Add(funcionario9);
            contFuncionario++;

            contEmpresa++;*/
            #endregion

            List<Empresa> listaEmpresas = new List<Empresa>();

            listaEmpresas.Add(empresa1);
            listaEmpresas.Add(empresa2);
            listaEmpresas.Add(empresa3);

            try
            {
                using (StreamWriter sw = File.CreateText(pathFile))
                {
                    sw.WriteLine(JsonConvert.SerializeObject(listaEmpresas, Formatting.Indented));
                    Console.WriteLine("\nArquivo Json criado com sucesso no diretório \"" + pathFile + "\" - " + DateTime.Now);
                    Thread.Sleep(ms);
                }

                Console.WriteLine("\nSerializando e criando arquivo Json no diretório \"" + pathFile + "\" - " + DateTime.Now);
                Thread.Sleep(ms);
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

                Console.WriteLine("\nLendo e desserializando arquivo Json no diretório \"" + pathFile + "\" - " + DateTime.Now);
                Thread.Sleep(ms);

                VerificarTelefone(empresa, ms);

                Thread.Sleep(ms + 2000);
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

                Console.WriteLine("\nLendo e desserializando arquivo Json no diretório \"" + pathFile + "\" - " + DateTime.Now);
                Thread.Sleep(ms);

                Console.WriteLine("\nAlterando telefone da empresa \"" + empresa[0].RazaoSocial + "\" de \"" + empresa[0].Telefone +
                    "\" para \"" + novoTelefone + "\" - " + DateTime.Now);
                Thread.Sleep(ms);

                empresa[0].Telefone = novoTelefone;

                Console.WriteLine("\nSerializando e alterando arquivo Json no diretório \"" + pathFile + "\" - " + DateTime.Now);
                Thread.Sleep(ms);

               //using (StreamWriter sw = File.AppendText(pathFile))
                using (StreamWriter sw = new StreamWriter(pathFile))
                {
                    sw.WriteLine(JsonConvert.SerializeObject(empresa, Formatting.Indented));
                    Console.WriteLine("\nArquivo Json alterado com sucesso no diretório \"" + pathFile + "\" - " + DateTime.Now);
                    Thread.Sleep(ms);
                }

                Console.WriteLine("\nLendo e desserializando arquivo Json no diretório \"" + pathFile + "\" - " + DateTime.Now);
                Thread.Sleep(ms);

                using (StreamReader sr = new StreamReader(pathFile))
                {
                    strJson = sr.ReadToEnd();
                }

                empresa = JsonConvert.DeserializeObject<List<Empresa>>(strJson);

                VerificarTelefone(empresa, ms);
            }
            catch (Exception)
            {
                throw;
            }

            Console.WriteLine("\nFim do processo - " + DateTime.Now + ". Tempo Gasto: " + DateTime.Now.Subtract(horarioInicial));
            Thread.Sleep(ms);
            Console.ReadKey();
        }
    }
}
