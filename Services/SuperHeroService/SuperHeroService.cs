namespace SuperHeroApiDotNet7.Services.SuperHeroService
{
    public class SuperHeroService : ISuperHeroService
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
        public List<SuperHero> AddHero(SuperHero hero)
        {
            superHeroes.Add(hero);
            return superHeroes; // Ok is used in controller !
        }

        public List<SuperHero>? DeleteHero(int id)
        {
            // throw new NotImplementedException();
            var hero = superHeroes.Find(x => x.Id == id);
            if (hero is null)
                // return NotFound("Désolé, ce hero n\'existe pas");// ! we can not return this here || return null or empty list
                return null;
            superHeroes.Remove(hero);

            // return Ok(hero);
            return superHeroes;
        }

        public List<SuperHero> GetAllHeroes()
        {
            return superHeroes;
        }

        public SuperHero GetSingleHero(int id)
        {
            var hero = superHeroes.Find(x => x.Id == id);
            if (hero is null)
                return null;
            return hero;
        }

        public List<SuperHero> UpdateHero(SuperHero request, int id)
        {
            var hero = superHeroes.Find(x => x.Id == id);
            if (hero is null)
                // return NotFound("Désolé, ce hero n\'existe pas"); // ? IF IS IN A CONTROLLER NotFound can be use
                return null; // Temporally null

            // problem here our methods are going to update every single property when one modif.
            hero.FirstName = request.FirstName;
            hero.LastName = request.LastName;
            hero.Name = request.Name;
            hero.Place = request.Place;

            return superHeroes;
        }
    }
}