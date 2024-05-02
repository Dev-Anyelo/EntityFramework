using AutoMapper;
using EntityFramework.DTOs;
using EntityFramework.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EntityFramework.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GenderController : ControllerBase
    {
        private readonly AplicationDBConext context;
        private readonly IMapper mapper;
        public GenderController(AplicationDBConext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        //Get all genders from the database
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Gender>>> Get()
        { 
            return await context.Genders.ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult> Post(CreationGenderDTO genderCreation)
        {
            var genderExists = await context.Genders.AnyAsync(g => g.Name == genderCreation.Name);

            if (genderExists) return BadRequest("Gender already exists");
                
            var gender = mapper.Map<Gender>(genderCreation);

            context.Add(gender);
            await context.SaveChangesAsync();
            return Ok();
         }

        // This method is used to add several entities at once
        [HttpPost ("several")]
        public async Task<ActionResult> PostSeveral(CreationGenderDTO[] gendersCreation)
        {
            var genders = mapper.Map<Gender[]>(gendersCreation);
            // AddRange is used to add several entities at once
            context.AddRange(genders); 
            await context.SaveChangesAsync();
            return Ok();
        }

        //Update data using Conected Model
        [HttpPut("{id:int}/name2")]
        public async Task<ActionResult> Put(int id)
        {
            var gender = await context.Genders.FirstOrDefaultAsync(g => g.Id == id);

            if (gender == null) return NotFound();

            gender.Name = gender.Name + "2";

            await context.SaveChangesAsync();
            return Ok();
        }

        //Update data using Desconected Model
        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(int id, CreationGenderDTO genderCreation)
        {
            var gender = mapper.Map<Gender>(genderCreation);

            gender.Id = id;

            //mark the entity as modified to update the data 
            context.Update(gender);

            await context.SaveChangesAsync();
            return Ok();
        }

        //mordern to delete data
        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var alteredRows = await context.Genders.Where(g => g.Id == id).ExecuteDeleteAsync();

            if (alteredRows == 0) return NotFound();

            return NoContent();
        }

        //old way to delete data
        [HttpDelete("{id:int}/old")]
        public async Task<ActionResult> DeleteOld(int id)
        {
            var gender = await context.Genders.FirstOrDefaultAsync(g => g.Id == id);

            if (gender is null) return NotFound();

            context.Remove(gender);
            await context.SaveChangesAsync();
            return NoContent();
        }
    }
}
