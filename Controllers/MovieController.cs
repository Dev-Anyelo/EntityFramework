using AutoMapper;
using EntityFramework.DTOs;
using EntityFramework.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EntityFramework.Controllers
{
    [ApiController]
    [Route("api/movies")]
    public class MovieController : ControllerBase
    {
        private readonly AplicationDBConext context;
        private readonly IMapper mapper;
        public MovieController(AplicationDBConext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        //Eager loading is use to load the comments of a movie
        [HttpGet("{id:int}")]
        public async Task<ActionResult<Movie>> Get(int id)
        {
            var movie = await context.Movies
                .Include(p => p.Comments)
                .Include(p => p.Genders)
                .Include(p => p.ActorsMovies.OrderBy(pa => pa.Order))
                    .ThenInclude(pa => pa.Actor)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (movie == null) return NotFound();

            return movie;
        }

        //Eager loading is use to load the comments of a movie
        [HttpGet("slect/{id:int}")]
        public async Task<ActionResult> GetSelect(int id)
        {
            var movie = await context.Movies
                .Select(m => new
                {
                    m.Id,
                    m.Title,
                    Generos = m.Genders.Select(g => g.Name).ToList(),
                    Actores = m.ActorsMovies.OrderBy(ma => ma.Order).Select(ma =>
                    new
                    {
                        Id = ma.ActorId,
                        ma.Actor.Name,
                        ma.Character
                    }),
                    CantidadComentarios = m.Comments.Count()
                })
                .FirstOrDefaultAsync(m => m.Id == id);

            if (movie == null) return NotFound();

            return Ok(movie);
        }

        [HttpPost]
        public async Task<ActionResult> Post(CreationMovieDTO movieCreation)
        {
            var movie = mapper.Map<Movie>(movieCreation);
            var genderExists = movie.Genders;

            if (genderExists is not null)
            {
                foreach (var gender in genderExists)
                {
                    // this is to avoid adding a new gender to the database if it already exists
                    context.Entry(gender).State = EntityState.Unchanged;
                }
            }

            if (movie.ActorsMovies is not null)
            {
                for (int i = 0; i < movie.ActorsMovies.Count; i++)
                {
                    movie.ActorsMovies[i].Order = i + 1;
                }
            }

            context.Add(movie);
            await context.SaveChangesAsync();
            return Ok();
        }

        //mordern to delete data
        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var alteredRows = await context.Movies.Where(g => g.Id == id).ExecuteDeleteAsync();

            if (alteredRows == 0) return NotFound();

            return NoContent();
        }

        //old way to delete data
        [HttpDelete("{id:int}/old")]
        public async Task<ActionResult> DeleteOld(int id)
        {
            var gender = await context.Movies.FirstOrDefaultAsync(g => g.Id == id);

            if (gender is null) return NotFound();

            context.Remove(gender);
            await context.SaveChangesAsync();
            return NoContent();
        }


   
    }
}
