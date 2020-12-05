using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcerciseThree.Lib
{
    public class FileReader : IFileReader
    {
        public string ReadText(string path, ICrypt crypt = null)
        {
            if (System.IO.Path.GetExtension(path).ToLower() != "txt") throw new Exception("Wrong file type.");
            
            if (crypt == null)
                return System.IO.File.ReadAllText(path);
            else
                return crypt.Decode(System.IO.File.ReadAllText(path));
        }

        public string ReadXml(string path, ICrypt crypt = null, IRoles role = null)
        {
            if (System.IO.Path.GetExtension(path).ToLower() != "xml") throw new Exception("Wrong file type.");
            if (role != null) role.check(path);

            if (crypt == null)
                return System.IO.File.ReadAllText(path);
            else
                return crypt.Decode(System.IO.File.ReadAllText(path));
        }
    }
}
