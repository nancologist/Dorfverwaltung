using System;

namespace dorfverwaltung_backend
{
    public class Weapon
    {
        public Weapon(string name, int magicValue)
        {
            this.Name = name;
            this.MagicValue = magicValue;
        }

        public string Name { get; set; }
        public int MagicValue { get; set; }
    }
}