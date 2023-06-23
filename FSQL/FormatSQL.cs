using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using BasicSQLFormatter;

namespace FormatadorSQL.FSQL
{
    public class FormatSQL
    {
        private string _path;
        private SQLFormatter formatter;

        public FormatSQL(string path)
        {
            if (!File.Exists(path))
                throw new FileNotFoundException("Arquivo informado não existe");

            _path = path;
        }

        public string FormatFile()
        {
            try
            {
                string sql = GetSQLinFile();

                if (string.IsNullOrWhiteSpace(_path))
                    throw new Exception("Arquivo não contem código SQL válido!");

                formatter = new SQLFormatter(sql);

                return SaveSQLFile(formatter.Format());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }

        private string GetSQLinFile()
        {
            using(StreamReader sr = new StreamReader(_path))
            {
                return sr.ReadToEnd();
            }
        }

        private string SaveSQLFile(string sql)
        {
            string fileFormatted = Path.GetDirectoryName(_path);
            fileFormatted = Path.Combine(fileFormatted, Path.GetFileNameWithoutExtension(_path) + "_Formatado.SQL");
            using(StreamWriter sw = new StreamWriter(fileFormatted))
            {
                sw.WriteLine(sql);
            }
            return sql;
        }
    }
}
