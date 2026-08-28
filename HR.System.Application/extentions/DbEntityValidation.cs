using System.Data.Entity.Validation;
using System.Text;

namespace HR.System.Application.extentions;

public static class DbEntityValidation
{
    public static string UserErrorMessage(this DbEntityValidationException exception)
    {
        var errorBuilder = new StringBuilder();
        foreach (var eve in exception.EntityValidationErrors)
        {
            errorBuilder.Append("The Following Validation Errors Occurred:");
            foreach (var ve in eve.ValidationErrors)
            {
                errorBuilder.Append(ve.ErrorMessage);
            }
        }

        return errorBuilder.ToString();
    }
}

