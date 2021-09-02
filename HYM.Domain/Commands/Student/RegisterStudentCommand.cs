using HYM.Domain.Validations.Student;
using System;
using System.Collections.Generic;
using System.Text;

namespace HYM.Domain.Commands
{
    public class RegisterStudentCommand : StudentCommand
    {
        public RegisterStudentCommand(string name, string email, DateTime birthDate, string phone, string province, string city, string county, string street)
        {
            Name = name;
            Email = email;
            BirthDate = birthDate;
            Phone = phone;
            Province = province;
            City = city;
            County = county;
            Street = street;
        }
        public override bool IsValid()
        {
            ValidationResult = new RegisterStudentCommandValidation().Validate(this);
            return IsValid();
        }
    }
}
