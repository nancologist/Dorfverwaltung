using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace dorfverwaltung_backend.Controllers
{
    [ApiController]
    [Route("api/")]
    public class Controller : ControllerBase
    {

        // Response JSON data on https://localhost:5019 
        [HttpGet("dwarfs/")]
        public List<Dwarf> Get()
        {
            return Dwarf.DwarfDB;
        }
        
        [HttpPost]
        public string Post(Dwarf dwarf)
        {
            // Remove the Dwarf
            Dwarf.DwarfDB = Dwarf.DwarfDB.Where(item => item.Name != dwarf.Name).ToList();
            // Add the dwarf with new Weapons:
            Dwarf.DwarfDB.Add(dwarf);
            return "successfully added";
        }
    }
}
