using System;
using HR.System.Application.extentions;

namespace HR.System.Application.exceptions;

public class DuplicationException : BusinessServiceException
{
    public DuplicationException(string message)
        : base(message)
    {
    }

    public DuplicationException(string message, Exception e)
        : base(message, e)
    {
    }

    public DuplicationException(params string[] properties)
        : base($"A Duplicate Record Was Found In The Database. Please Ensure That {properties.JoinUsingLastSeparator(", ", " And ")} Is Unique.")
    {
    }
}
