using System;

namespace HappyPaws.API.Core.Entities
{
    public class Note
    {
        public Guid Id { get; set; }
        public string Value { get; set; } = string.Empty;
        public int MyProperty2 { get; set; }
    }
}
