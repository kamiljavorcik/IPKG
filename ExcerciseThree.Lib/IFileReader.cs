﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcerciseThree.Lib
{
    interface IFileReader
    {
        string ReadText(string path, ICrypt crypt = null);
        string ReadXml(string path);
    }
}
