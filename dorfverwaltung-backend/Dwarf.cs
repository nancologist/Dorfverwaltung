using System;

namespace dorfverwaltung_backend
{
    public class Dwarf
    {
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
    }
}