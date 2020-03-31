using System;
using System.Collections.Generic;

namespace dorfverwaltung_backend
{
    public class Dwarf
    {
        public static List<Dwarf> DwarfDB = new List<Dwarf>();

        public Dwarf(string name, int age, string gun, int powerFactor) 
        {
            this.Name = name;
            this.Age = age;
            this.Gun = gun;
            this.PowerFactor = powerFactor;
        }

        public string Name { get; set; }
        public int Age { get; set; }
        public string Gun { get; set; }
        public int PowerFactor { get; set; }

        public static void InitDwarfDB() 
        {
            DwarfDB.Add(new Dwarf("Gimli", 140, "[Axt, Schwert]", 27));
            DwarfDB.Add(new Dwarf("Gumli", 163, "[Axt]", 17));
            DwarfDB.Add(new Dwarf("Zwingli", 70, "[Zauberstab, Streithammer]", 60));
        }
    }
}