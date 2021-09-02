using HYM.Domain.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace HYM.Domain.Validations.Student
{
  public  class UpdateStudentCommandValidation:StudentValidation<UpdateStudentCommand>
    {
        public UpdateStudentCommandValidation() 
        {
            ValidateId();
            ValidateName();
            ValidateBirthDate();
            ValidateEmail();
            ValidatePhone();
        }
    }
}
