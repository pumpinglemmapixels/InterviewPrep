
using System.Xml.Linq;

namespace Prep.Interfaces.DataObjects
{
    //having implementations in a common library does break dependency injection a little, but the alternative is to make an interface that gets implemented as below in multiple project
    //the comprise is to keep the implemented object free of any logic
    public class TestEntity1(int id, string name, int prop1)
    {
        public int Id { get; set; } = id;
        public string Name { get; set; } = name;
        public int Prop1 { get; set; } = prop1;
    }
}
