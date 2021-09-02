using HYM.Domain.Validations.Student;
using System;
using System.Collections.Generic;
using System.Text;

namespace HYM.Domain.Commands
{
    public class RemoveStudentCommand : StudentCommand
    {
        public RemoveStudentCommand(Guid id)
        {
            Id = id;
            //AggregateId = id;
        }
        public override bool IsValid()
        {
            ValidationResult = new RemoveStudentCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
