﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factory_Method
{
    class Program
    {
        static void Main(string[] args)
        {
            WebRequestCreator requestCreator= new HttpRequestCreator();
            var req= requestCreator.SendRequest("http://");
           

        }
    }
}
