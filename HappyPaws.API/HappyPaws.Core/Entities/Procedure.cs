using HappyPaws.Core.Entities.Common;

namespace HappyPaws.Core.Entities
{
    public class Procedure : Entity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }

        public List<AppointmentProcedure>? AppointmentProcedures { get; set; }
    }
}
