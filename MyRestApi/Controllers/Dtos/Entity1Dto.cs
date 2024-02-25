
using Prep.Interfaces.DataObjects;

namespace MyRestApi.Controllers.Dtos
{
    public class Entity1Dto(int id, string name, int prop1)
    {
        public int Id { get; set; } = id;
        public string Name { get; set; } = name;
        public int Prop1 { get; set; } = prop1;

        public static Entity1Dto ToDto(TestEntity1 entity1)
        {
            return new Entity1Dto(entity1.Id, entity1.Name, entity1.Prop1);
        }

        public static IEnumerable<Entity1Dto> ToDtos(IEnumerable<TestEntity1> entities)
        {
            var dtos = new List<Entity1Dto>();

            foreach (var entity in entities)
            {
                dtos.Add(ToDto(entity));
            }

            return dtos;
        }
    }
}
