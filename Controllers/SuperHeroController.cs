using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace SuperHeroApiDotNet7
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuperHeroController : ControllerBase
    {

        private static List<SuperHero> superHeroes = new List<SuperHero> {
             new SuperHero
                {
                    Id= 1,
                    Name="Spider Man",
                    FirstName="Peter",
                    LastName="Parker",
                    Place="New York City"
                },
                 new SuperHero
                {
                    Id= 2,
                    Name="Iron Man",
                    FirstName="Tony",
                    LastName="Stark",
                    Place="Malibu"
                }
        };

        [HttpGet]
        public async Task<ActionResult<List<SuperHero>>> GetAllHeroes()
        {

            return Ok(superHeroes);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SuperHero>> GetSingleHero(int id)
        {
            var hero = superHeroes.Find(x => x.Id == id);
            if (hero is null)
                return NotFound("Désolé, ce hero n\'existe pas");
            return Ok(hero);
        }

        [HttpPost]
        public async Task<ActionResult<List<SuperHero>>> AddHero(SuperHero hero)
        {
            superHeroes.Add(hero);
            return Ok(superHeroes);
        }

        // 
        [HttpPut("{id}")]
        public async Task<ActionResult<List<SuperHero>>> UpdateHero(SuperHero request, int id)
        {
            var hero = superHeroes.Find(x => x.Id == id);
            if (hero is null)
                return NotFound("Désolé, ce hero n\'existe pas");

            // problem here our methods are going to update every single property when one modif.
            hero.FirstName = request.FirstName;
            hero.LastName = request.LastName;
            hero.Name = request.Name;
            hero.Place = request.Place;

            return Ok(hero);
        }

         [HttpDelete("{id}")]
        public async Task<ActionResult<List<SuperHero>>> DeleteHero(int id)
        {
            var hero = superHeroes.Find(x => x.Id == id);
            if (hero is null)
                return NotFound("Désolé, ce hero n\'existe pas");

            superHeroes.Remove(hero);

            return Ok(hero);
        }
    }
}