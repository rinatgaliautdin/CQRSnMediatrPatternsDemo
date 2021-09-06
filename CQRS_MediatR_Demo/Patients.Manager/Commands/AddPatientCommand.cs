using MediatR;
using Patients.Model;

namespace Patients.Manager.Commands
{
    public class AddPatientCommand: IRequest<Patient>
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }


        public AddPatientCommand(int id, string firstName, string lastName, string email)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
        }
    }
}
