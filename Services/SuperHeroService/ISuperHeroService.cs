namespace SuperHeroApiDotNet7.Services.SuperHeroService
{
    public interface ISuperHeroService
    {
        List<SuperHero> GetAllHeroes();

        // single herof
        SuperHero? GetSingleHero(int id);
        // add
        List<SuperHero> AddHero(SuperHero hero);
        // update
        List<SuperHero>? UpdateHero(SuperHero request, int id);
        // delete
        List<SuperHero>? DeleteHero(int id);
        object UpdateHero(int id, SuperHero request);
    }
}