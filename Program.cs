using FormatadorSQL.FSQL;
using System;
using System.IO;

namespace FormatadorSQL
{
    class Program
    {
        static FormatSQL formatSQL;

        static void Main(string[] args)
        {
            string path = "";
            if (args.Length == 0)
            {
                Console.WriteLine("Formatador de arquivo SQL");
                Console.WriteLine("Digite o caminho ou arraste e solte o arquivo (.TXT|.SQL)");
                path = Console.ReadLine();
            }
            else if (!string.IsNullOrWhiteSpace(args[0]))
            {
                path = args[0];
            }

            if (string.IsNullOrWhiteSpace(path))
            {
                Console.WriteLine("Nenhum arquivo informado!");
                return;
            }

            if (!File.Exists(path))
            {
                Console.WriteLine("Arquivo não existe!");
                return;
            }

            switch (Path.GetExtension(path).ToUpper())
            {
                case ".TXT": case ".SQL":
                    break;
                default:
                    Console.WriteLine("Extensão do arquivo é inválido!");
                    return;
            }

            formatSQL = new FormatSQL(path);

            formatSQL.FormatFile();

        }
    }
}
