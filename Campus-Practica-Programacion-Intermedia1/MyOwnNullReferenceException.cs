using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Campus_Practica_Programacion_Intermedia1
{
    internal class MyOwnNullReferenceException : NullReferenceException
    {
        public override string Message
        {
            get
            {
                return "dato no valido";
            }
        }
    }
}
