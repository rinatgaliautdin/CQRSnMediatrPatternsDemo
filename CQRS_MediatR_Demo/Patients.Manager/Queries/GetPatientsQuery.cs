using MediatR;
using Patients.Model;
using System.Collections.Generic;

namespace Patients.Manager.Queries
{
    public class GetPatientsQuery: IRequest<List<Patient>>
    {
    }
}
