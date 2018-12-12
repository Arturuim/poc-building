using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.Repositories
{
    public interface IInvestigationNotesRepository 
    {
        void CreateNote(string investigationId, string investigatorId, string note);
    }
}
