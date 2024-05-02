using AutoMapper;
using AutoMapper.QueryableExtensions;
using EntityFramework.DTOs;
using EntityFramework.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EntityFramework.Controllers
{
    [ApiController]
    [Route("api/actors")]
    public class ActorController : ControllerBase
    {
        private readonly AplicationDBConext context;
        private readonly IMapper mapper;
        public ActorController(AplicationDBConext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        //Get all actors from the database
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Actor>>> Get()
        {
            return await context.Actors.OrderBy(a => a.Birthdate).ToListAsync();
        }

        // Filter actors by name
        [HttpGet("name")]
        public async Task<ActionResult<IEnumerable<Actor>>> Get(string name)
        {
            //v1
            return await context.Actors.
                Where(n => n.Name == name)
                .OrderBy(a => a.Name)
                    .ThenByDescending(a => a.Birthdate)
                .ToListAsync();
        }

        [HttpGet("name/coincidence")]
        public async Task<ActionResult<IEnumerable<Actor>>> GetCoincidence(string name)
        {
            //v2 using .Contains()
            return await context.Actors.Where(n => n.Name.Contains(name)).ToListAsync();
        }

        [HttpGet("BirthDate/range")]
        public async Task<ActionResult<IEnumerable<Actor>>> Get(DateTime initial, DateTime last)
        {
            return await context.Actors.Where(d => d.Birthdate >= initial && d.Birthdate <= last).ToListAsync();
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Actor>> Get(int id)
        {
            var actor = await context.Actors.FirstOrDefaultAsync(a => a.Id == id);

            if (actor == null) return NotFound(); 

            return actor;
        }

        //select only the id and name of the actors
        [HttpGet("id-name")]
        public async Task<ActionResult> GetIdName()
        {
            var actors = await context.Actors.Select(a => new { a.Id, a.Name }).ToListAsync();
            return Ok(actors);
        }

        //Projecting data from Actor class to ActorDTO
        [HttpGet("id-name-dto")]
        public async Task<ActionResult<IEnumerable<ActorDTO>>> GetIdNameDTO()
        {
           //return await context.Actors.Select(a => new ActorDTO {Id = a.Id, Name = a.Name }).ToListAsync();

            return await context.Actors.ProjectTo<ActorDTO>(mapper.ConfigurationProvider).ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult> Post(CreationActorDTO actorCreation)
        {
            var actor = mapper.Map<Actor>(actorCreation);

            context.Add(actor);
            await context.SaveChangesAsync();
            return Ok();
        }
    }
}
