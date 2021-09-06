using MediatR;
using Patients.DataAccess.Interfaces;
using Patients.Manager.Commands;
using Patients.Model;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Patients.Manager.Handlers
{
    public class AddPatientHandler : IRequestHandler<AddPatientCommand, Patient>
    {
        private readonly IDataRepository _repository;

        public AddPatientHandler(IDataRepository repository)
        {
            _repository = repository;
        }

 
        public Task<Patient> Handle(AddPatientCommand request, CancellationToken cancellationToken)
        {
            var patient = new Patient(request.Id, request.FirstName, request.LastName, request.Email);

            return Task.FromResult(_repository.AddPatient(patient)); 
        }
    }
}
