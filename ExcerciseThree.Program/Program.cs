using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcerciseThree.Program
{
    class Program
    {
        static void Main(string[] args)
        {
            var path = Path.Combine(System.Environment.CurrentDirectory, "App_Data");
            var files = System.IO.Directory.GetFiles(path);
            Console.Clear();
            for (int i = 0; i < files.Length; i++)
            {

                Console.WriteLine(String.Format("{0} {1}", i, Path.GetFileName(files[i])));
            }
            Console.WriteLine();
            Console.Write("Enter file id [0..9]: ");
            var fileId = int.Parse(Console.ReadLine());

            List<string> enc = new List<string>() { "NoEcryption", "Base64" };
            Console.Clear();
            Console.WriteLine("Selected file: " + Path.GetFileName(files[fileId]));
            for (int i = 0; i < enc.Count; i++)
            {
                Console.WriteLine(String.Format("{0} {1}", i, enc[i]));
            }
            Console.Write("Use encryption [0..9]: ");
            var encId = int.Parse(Console.ReadLine());

            List<string> roles = new List<string>() { "NoRole", "User", "Admin" };
            Console.Clear();
            Console.WriteLine("Selected file: " + Path.GetFileName(files[fileId]));
            Console.WriteLine("Selected enc:" + enc[encId]);
            for (int i = 0; i < roles.Count; i++)
            {
                Console.WriteLine(String.Format("{0} {1}", i, roles[i]));
            }
            Console.Write("Use role [0..9]: ");
            var roleId = int.Parse(Console.ReadLine());

            Console.Clear();
            Console.WriteLine("Selected file: " + Path.GetFileName(files[fileId]));
            Console.WriteLine("Selected enc:" + enc[encId]);
            Console.WriteLine("Selected role:" + roles[roleId]);
            Console.Write("Continue [enter]: ");
            var x = Console.ReadLine();

            Console.Clear();
            ReadFile(files[fileId], encId, roleId);
            Console.ReadKey();
        }

        static void ReadFile(string path, int encId, int roleId)
        {
            Lib.IFileReader reader = new Lib.FileReader();
            Lib.ICrypt crypt = null;
            Lib.IRoles role = null;

            if (encId == 1) crypt = new Crypt();

            switch (roleId)
            {
                case 1:
                    role = new Roles(Roles.Role.User);
                    break;
                case 2:
                    role = new Roles(Roles.Role.Admin);
                    break;
                default:
                    break;
            }

            switch (Path.GetExtension(path))
            {
                case ".txt":
                    Console.WriteLine(reader.ReadText(path, crypt, role));
                    break;
                case ".xml":
                    Console.WriteLine(reader.ReadXml(path, crypt, role));
                    break;
                case ".json":
                    Console.WriteLine(reader.ReadJson(path, crypt, role));
                    break;
                default:
                    Console.WriteLine("Unknown file extension.");
                    break;
            }
        }
    }
}
