using MediatR;
using Patients.DataAccess.Interfaces;
using Patients.Manager.Queries;
using Patients.Model;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Patients.Manager.Handlers
{
    public class GetPatientsHandler : IRequestHandler<GetPatientsQuery, List<Patient>>
    {
        private readonly IDataRepository _repository;
 
        public GetPatientsHandler(IDataRepository repository)
        {
            _repository = repository;
        }

        public Task<List<Patient>> Handle(GetPatientsQuery request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_repository.GetPatiens());
        }
    }
}
