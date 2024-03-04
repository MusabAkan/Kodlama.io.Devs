using Core.Persistence.Repositories;

namespace Domain.Entities
{
    public class CodingSkill : Entity
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public CodingSkill()
        {

        }
        public CodingSkill(int ıd, string name) : this()
        {
            Id = ıd;
            Name = name;
        }
    }
}
