using Patients.Model;
using System.Collections.Generic;

namespace Patients.DataAccess.Interfaces
{
    public interface IDataRepository
    {
        List<Patient> GetPatiens();

        Patient AddPatient(Patient model);

        Patient GetPatientById(int id);
    }
}
