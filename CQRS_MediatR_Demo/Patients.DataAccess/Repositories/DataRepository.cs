using Patients.DataAccess.Interfaces;
using Patients.Model;
using System.Collections.Generic;
using System.Linq;

namespace Patients.DataAccess.Repositories
{
    public class DataRepository : IDataRepository
    {
        public List<Patient> Patients { get; set; } = new List<Patient>();

        public DataRepository()
        {
            Patients.Add(new Patient { Id = 1001, FirstName = "John", LastName = "Silver", Email = "js@mail.com" });
            Patients.Add(new Patient { Id = 1002, FirstName = "Jack", LastName = "Sparrow", Email = "jack@hotmail.com" });
            Patients.Add(new Patient { Id = 1003, FirstName = "Marry", LastName = "Blood", Email = "bm@mail.com" });
        }


        public List<Patient> GetPatiens()
        {
            return Patients;
        }

        public Patient AddPatient(Patient model)
        {
            Patients.Add(model);
            return model;
        }


        public Patient GetPatientById(int id)
        {
            return Patients.FirstOrDefault(p => p.Id == id);
        }

    }
}
