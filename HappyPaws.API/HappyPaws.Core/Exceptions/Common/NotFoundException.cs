namespace HappyPaws.Core.Exceptions.Common
{
    public class NotFoundException : Exception
    {
        public NotFoundException(){}

        public NotFoundException(string type, Guid id) : base(String.Format($"{type} with id: {id} was not found")){}
    }
}
