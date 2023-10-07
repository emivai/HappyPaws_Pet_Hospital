using HappyPaws.API.Core.Entities;

namespace HappyPaws.API.Responses
{
    public class ProcedureResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }

        public static ProcedureResponse FromDomain(Procedure procedure)
        {
            return new ProcedureResponse {
                Id = procedure.Id,
                Name = procedure.Name,
                Description = procedure.Description,
                Price = procedure.Price 
            };
        }
    }
}
