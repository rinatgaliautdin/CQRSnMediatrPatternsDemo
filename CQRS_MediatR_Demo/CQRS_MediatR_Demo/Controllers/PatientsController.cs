using MediatR;
using Microsoft.AspNetCore.Mvc;
using Patients.Manager.Commands;
using Patients.Manager.Queries;
using Patients.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CQRS_MediatR_Demo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PatientsController(IMediator mediator)
        {
            _mediator = mediator;
        }

      
        [HttpGet]
        [Route("GetPatients")]
        public async Task<List<Patient>> GetPatients()
        {
            return await _mediator.Send(new GetPatientsQuery());
        }


        [HttpGet]
        [Route("GetPatientById/{id}")]
        public async Task<Patient> GetPatientById(int id)
        {
            return await _mediator.Send(new FindPatientQuery(id));
        }


        [HttpPost]
        [Route("AddPatient")]
        public async Task<Patient> AddPatient([FromBody] Patient patient)
        {
            return await _mediator.Send(new AddPatientCommand(patient.Id, patient.FirstName, patient.LastName, patient.Email));
        }

    }
}
