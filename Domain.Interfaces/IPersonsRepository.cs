using Domain.Model;

namespace Domain.Interfaces.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    // TODO : Add person repository here
    public interface IPersonsRepository
    {
        List<Person> GetPersons(Filter filter);
        //List<Person> GetPersons(Filter filter);
    }
}
