using System.ComponentModel.DataAnnotations;

namespace SerenUP.ApplicationCore.Entities
{
    public class Model : Entity<Guid>
    {

        public string Name { get; set; }
        public string Description { get; set; }

    }
}
