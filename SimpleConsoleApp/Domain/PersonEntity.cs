using System;

namespace Domain
{
    public class PersonEntity
    {
        // used for list when converted and uses below values. 
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
    }
}