﻿using System;
using System.Collections.Generic;
using System.Text;

namespace MyLibrary
{
    public static class Examples
    {
        public static string ExampleLoadTextFile(string file)
        {
            if (file.Length < 10)
            {
                throw new ArgumentException("The file name was too short","file");
            }

            return "The file was correctly loaded.";
        }
    }
}
