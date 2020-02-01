using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Threading;
using _2008.Z;
using _2008.Classes;

namespace _2008.Structs
{
    class Company
    {
        public struct Company_
        {
            public int TotalManpower;
            public int Captured;
            public int Injured;
            public int Dead;
            public int Soldiers;
            public int SupportManpower;
            public int Experience;
            public int Level;
            public int Morale;

            public List<Instance> Equipment;
            public List<Building> SpecialBuild;
        };

        static public Company_ InitializeUnit()
        {
            Company_ seller = new Company_();


            return seller;
        }





    }
}
