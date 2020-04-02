using System;
using System.Collections.Generic;

namespace dorfverwaltung_backend
{
    public class Tribe
    {
        public static List<Tribe> TribeDB = new List<Tribe>();

        static Tribe()
        {
            TribeDB.Add(new Tribe("Altobarden", 1247));
            TribeDB.Add(new Tribe("Elbknechte", 1023));
        }

        public Tribe(string name, int since)
        {
            this.Name = name;
            this.Since = since; // Jahre nach nkd
        }

        public string Name { get; set; }
        public int Since { get; set; }
    }
}