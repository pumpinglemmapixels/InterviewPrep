using Microsoft.AspNetCore.Mvc;
using MyRestApi.Controllers.Dtos;
using Prep.Interfaces.Arguments.Application;
using Prep.Interfaces.Common;
using Prep.Interfaces.DataObjects;

namespace MyRestApi.Controllers
{
    [Route("entity1")]
    [ApiController]
    public class Entity1Controller(
        ILogger<Entity1Controller> logger,
        IQuery<GetEntity1ByIdApp, TestEntity1> getByIdApplicationQuery,
        IQuery<GetAllEntity1App, IEnumerable<TestEntity1>> getAllQuery
        )
    {

        // GET api/<Entity1Controller>/5
        [HttpGet("{id}")]
        public async Task<Entity1Dto> GetById(int id)
        {
            try
            {
                var response = await getByIdApplicationQuery.Get(new GetEntity1ByIdApp(id));
                return Entity1Dto.ToDto(response.Result);

            }
            catch (Exception e)
            {
                logger.LogError(e.Message);
                throw;
            }
        }
        [HttpGet]
        public async Task<IEnumerable<Entity1Dto>> GetAll()
        {
            try
            {
                var response = await getAllQuery.Get(new GetAllEntity1App());
                return Entity1Dto.ToDtos(response.Result);

            }
            catch (Exception e)
            {
                logger.LogError(e.Message);
                throw;
            }
        }

        // POST api/<Entity1Controller>
        [HttpPost]
        public void Post([FromBody] Entity1Dto value)
        {
            //both of these go into the same upsert
        }

        // PUT api/<Entity1Controller>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Entity1Dto value)
        {
            //both of these go into the same upsert
        }

        // DELETE api/<Entity1Controller>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}

