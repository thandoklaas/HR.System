using System;
using System.Data.Entity.Validation;
using HR.System.Application.extentions;

namespace HR.System.Application.exceptions;

public class CrudException : BusinessServiceException
{
    public CrudException(string message, Exception e)
        : base(message, e)
    {
    }

    public CrudException(ArgumentException exception)
        : base("The Following Argument Was Invalid: " + exception.ParamName, exception)
    {
    }

    public CrudException(DbEntityValidationException validationException)
        : base(validationException.UserErrorMessage(), validationException)
    {
    }
}
