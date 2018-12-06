namespace Domain.Model
{
    using System;

    public class Person
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public PersonStatuses Status { get; set; }
        public DateTime BirthDate { get; set; }
    }

    public  enum  PersonStatuses { }
}
