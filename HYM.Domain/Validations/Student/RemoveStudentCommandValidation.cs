using HYM.Domain.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace HYM.Domain.Validations.Student
{
    public class RemoveStudentCommandValidation:StudentValidation<RemoveStudentCommand>
    {
        public RemoveStudentCommandValidation()
        {
            ValidateId();
        }
    }
}
