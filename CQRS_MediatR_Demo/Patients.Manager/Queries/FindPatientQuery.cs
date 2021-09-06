using MediatR;
using Patients.Model;

namespace Patients.Manager.Queries
{
    public class FindPatientQuery: IRequest<Patient>
    {
        public int Id { get; set; }

        public FindPatientQuery(int id)
        {
            Id = id;
        }
    }
}
