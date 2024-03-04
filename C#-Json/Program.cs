using System;
using System.IO;
using Newtonsoft.Json.Linq;

class Program
{
    static void Main(string[] args)
    {
        string configFile = "config.json";
        ConfigSetup.CreateConfigFile(configFile);
        bool menu = true;

        while (menu)
        {
            Console.WriteLine("\r\n░█████╗░██╗░░░░░░█████╗░██╗░░░██╗██████╗░██████╗░░█████╗░██████╗░██╗░░██╗\r\n██╔══██╗██║░░░░░██╔══██╗██║░░░██║██╔══██╗██╔══██╗██╔══██╗██╔══██╗██║░██╔╝\r\n██║░░╚═╝██║░░░░░██║░░██║██║░░░██║██║░░██║██████╔╝███████║██████╔╝█████═╝░\r\n██║░░██╗██║░░░░░██║░░██║██║░░░██║██║░░██║██╔═══╝░██╔══██║██╔══██╗██╔═██╗░\r\n╚█████╔╝███████╗╚█████╔╝╚██████╔╝██████╔╝██║░░░░░██║░░██║██║░░██║██║░╚██╗\r\n░╚════╝░╚══════╝░╚════╝░░╚═════╝░╚═════╝░╚═╝░░░░░╚═╝░░╚═╝╚═╝░░╚═╝╚═╝░░╚═╝\r\n");

            Console.WriteLine("Escolha uma opção:");
            Console.WriteLine("1 - Ler configuração");
            Console.WriteLine("2 - Escrever configuração");
            Console.WriteLine("3 - Informação técnica");
            Console.WriteLine("4 - Sair aplicação\r\n");
            string opcao = Console.ReadLine();

            if (opcao == "1")
            {
                Console.Clear();
                LerConfiguracao(configFile);
                Console.WriteLine("Digite qualquer tecla para voltar ao menu anterior");
                Console.ReadLine();
                Console.Clear();
            }
            else if (opcao == "2")
            {
                Console.Clear();
                EscreverConfiguracao(configFile);
                Console.WriteLine("Digite qualquer tecla para voltar ao menu anterior");
                Console.ReadLine();
                Console.Clear();
            }
            else if (opcao == "3")
            {
                Console.Clear();
                Console.WriteLine("Segue a informação do arquivo JSON:");
                InfoArquivo(configFile);
                Console.WriteLine("Digite qualquer tecla para voltar ao menu anterior");
                Console.ReadLine();
                Console.Clear();
            }
            else if (opcao == "4")
            {
                Console.Clear();
                Console.WriteLine("Aplicação encerrando...");
                Thread.Sleep(2000);
                menu = false;
            }
            else
            {
                Console.WriteLine("Opção inválida, tente novamente");
                Thread.Sleep(2000);
                Console.Clear();
            }
        }
    }

    static void LerConfiguracao(string configFile)
    {
        string json = File.ReadAllText(configFile);
        if (json == "{}")
        {
            Console.WriteLine("O arquivo não contém informações.");
        }
        else
        {
            Console.WriteLine("Configuração atual:");
            Console.WriteLine(json);
        }
    }

    static void EscreverConfiguracao(string configFile)
    {
        var configuracao = new JObject();
        Console.WriteLine("Informe o nome do servidor:");
        configuracao["server_name"] = Console.ReadLine();
        Console.WriteLine("Informe o IP do servidor:");
        configuracao["server_ip"] = Console.ReadLine();
        Console.WriteLine("Informe a senha do servidor:");
        configuracao["server_password"] = Console.ReadLine();

        File.WriteAllText(configFile, configuracao.ToString());
        Console.WriteLine("Informações salvas com sucesso:");
        Console.WriteLine(configuracao);
    }

    static void InfoArquivo(string configFile)
    {
        string configFilePath = Path.GetFullPath(configFile);
        Console.WriteLine($"O arquivo config.json está localizado em: {configFilePath}\r\n");
    }
}

public class ConfigSetup
{
    public static void CreateConfigFile(string configFile)
    {
        // Verifica se o arquivo já existe
        if (!File.Exists(configFile))
        {
            // Cria um novo arquivo config.json com conteúdo padrão
            string jsonContent = "{\"server_name\": \"\", \"server_ip\": \"\", \"server_password\": \"\"}";
            File.WriteAllText(configFile, jsonContent);
            Console.WriteLine("Arquivo config.json criado com sucesso.");
        }
        else
        {

        }
    }
}
