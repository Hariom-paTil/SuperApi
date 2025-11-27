using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SuperApi.Module;

namespace SuperApi.Controllers



//<IActionResult> every controller return actionresult means it not dirclty return a data it return usernot-found,ok-status,not-found
//List<superHero>> used because we want return overalll list of super hero
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuperHeroController : ControllerBase
    {
       private static List<superHero> superHeroes = new List<superHero>
        {
            new superHero { Id=1, Name="spider_Man", FirstName="peter",LastName="parker",Place="New_Yourk" },
            new superHero { Id=2, Name="iron_man", FirstName="Tony",LastName="Strak",Place="New_Yourk" },
        };
        [HttpGet]
        public async Task<ActionResult<List<superHero>>> GetSuperHero()// async  work like means some one called this api so it starting to work
                                                       // suppose this api needs 5 min to completed har work so it will be work in 
                                                       // background and over program will go for next stack "NOT STOP FOR HAS FULL EXECQUTIO.
        {
            return Ok(superHeroes);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<superHero>> GetSuperHeroById(int id)
        {
            superHero? superhero = superHeroes.Find(x => x.Id == id);
            if (superhero == null)
                return NotFound("Super_Hero Will Not Found");
       
            return Ok(superhero);

        }

        [HttpPost]
        public async Task<ActionResult<List<superHero>>> PostSuperHero(superHero hero)
        {
            superHeroes.Add(hero);
            return Ok(superHeroes);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<List<superHero>>> UpdateSuperHero(int id ,superHero newhero)
        {
            superHero? superhero = superHeroes.Find(x => x.Id == id);
            if (superhero == null)
                return NotFound("Super_Hero Will Not Found");
            superhero.Name = newhero.Name;
            superhero.FirstName = newhero.FirstName;
            superhero.LastName = newhero.LastName;
            superhero.Place = newhero.Place;
            return Ok(superhero);

        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<superHero>> DeleteSuperHero(int id)
        {
            superHero? superhero = superHeroes.Find(x => x.Id == id);
            if (superhero == null)
                return NotFound("Super_Hero Will Not Found");
            superHeroes.Remove(superhero);
            return Ok(superHeroes);

        }


    }
}
