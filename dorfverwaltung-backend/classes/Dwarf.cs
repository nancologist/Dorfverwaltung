using System;
using System.Collections.Generic;
using System.Linq;

namespace dorfverwaltung_backend
{
    public class Dwarf
    {
        // Fake Database
        public static List<Dwarf> DwarfDB = new List<Dwarf>();

        // Initialisiere die beispielhaften Daten von der Aufgabe 
        static Dwarf() 
        {
            DwarfDB.Add(new Dwarf("Gimli", 140, new List<Weapon>(){ new Weapon("Axt", 12), new Weapon ("Schwert", 15) }, Tribe.TribeDB[0]));
            DwarfDB.Add(new Dwarf("Zwingli", 70, new List<Weapon>(){ new Weapon("Zauberstab", 45), new Weapon ("Streithammer", 15) }, Tribe.TribeDB[0]));
            DwarfDB.Add(new Dwarf("Gumli", 163, new List<Weapon>(){ new Weapon("Axt", 17) }, Tribe.TribeDB[1]));
        }

        public Dwarf() {}

        public Dwarf(string Name, int age, List<Weapon> weapon, Tribe tribe) 
        {
            this.Name = Name;
            this.Age = age;
            this.Weapons = weapon;
            this.Tribe = tribe;
            // Calculate the PowerFactor from the Magic Values of the Weapons of Dwarf:
            this.PowerFactor = weapon.Select(item => item.MagicValue).Sum();
        }

        public string Name { get; set; }
        public int Age { get; set; }
        public List<Weapon> Weapons { get; set; }
        public int PowerFactor { get; set; }
        public Tribe Tribe { get; set; }
    }
}