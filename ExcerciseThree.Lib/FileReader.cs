using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcerciseThree.Lib
{
    public class FileReader : IFileReader
    {
        public string ReadText(string path)
        {
            if (System.IO.Path.GetExtension(path).ToLower() != "txt") throw new Exception("Wrong file type.");
            return System.IO.File.ReadAllText(path);
        }

        public string ReadXml(string path)
        {
            if (System.IO.Path.GetExtension(path).ToLower() != "xml") throw new Exception("Wrong file type.");
            return System.IO.File.ReadAllText(path);
        }
    }
}
