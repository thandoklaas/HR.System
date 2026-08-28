using System.Collections.Generic;
using HR.System.Application.extentions;

namespace HR.System.Application.exceptions;

public class CrossValidationException : BusinessServiceException
{
    public CrossValidationException(string message, params object[] args)
        : base(string.Format(message, args))
    {
    }

    public CrossValidationException(IEnumerable<string> relatedEntities)
        : base($"Sorry, The Record Could Not Be Deleted. It Is Being Used In {relatedEntities.JoinUsingLastSeparator(", ", " And ")}")
    {
    }

    public override string ToString()
    {
        return InnerException == null ? Message : InnerException.ToString();
    }
}
