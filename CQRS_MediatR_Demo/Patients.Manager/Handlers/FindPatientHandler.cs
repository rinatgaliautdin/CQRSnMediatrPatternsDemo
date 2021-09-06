using MediatR;
using Patients.Manager.Queries;
using Patients.Model;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Patients.Manager.Handlers
{
    public class FindPatientHandler : IRequestHandler<FindPatientQuery, Patient>
    {
        private readonly IMediator _mediator;

        public FindPatientHandler(IMediator mediator)
        {
            _mediator = mediator;
        }


        /// <summary>
        /// Within this handler I intentionally do not call for the GetPatienById method of the DataRepository, instead I am using the Mediator to call another handler
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<Patient> Handle(FindPatientQuery request, CancellationToken cancellationToken)
        {
            var patientsList = await _mediator.Send(new GetPatientsQuery());
            var result = patientsList.FirstOrDefault(p=>p.Id==request.Id);

            return result;
        }
    }
}
