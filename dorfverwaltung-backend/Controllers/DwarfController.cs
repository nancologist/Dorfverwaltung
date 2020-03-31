using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace dorfverwaltung_backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DwarfController : ControllerBase
    {

        [HttpGet]
        public List<Dwarf> Get()
        {
            return GetDwarfs();

        }

        public List<Dwarf> GetDwarfs() 
        {
            List<Dwarf> dwarfs = new List<Dwarf>();

            dwarfs.Add(new Dwarf("Gimli", 140, "[Axt, Schwert]", 27));
            dwarfs.Add(new Dwarf("Gumli", 163, "[Axt]", 17));
            dwarfs.Add(new Dwarf("Zwingli", 70, "[Zauberstab, Streithammer]", 60));

            return dwarfs;
        }
    }
}
