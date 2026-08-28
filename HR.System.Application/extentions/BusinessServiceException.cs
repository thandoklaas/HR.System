using System.Globalization;
using System.Runtime.Serialization;

namespace HR.System.Application.extentions;

[Serializable]
public abstract class BusinessServiceException : Exception
{
    protected BusinessServiceException(string message)
        : base(StandardiseExceptionMessage(message))
    {
    }

    private static string StandardiseExceptionMessage(string message)
    {
        if (string.IsNullOrEmpty(message))
            return string.Empty;

        message = message.Trim(' ', ',', '.', '!', '?', ':', ';', '-');

        if (string.IsNullOrWhiteSpace(message))
            return string.Empty;

        var words = message
            .ToLower()
            .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
            .ToList();

        var info = CultureInfo.CurrentCulture.TextInfo;

        var joined = string.Join(" ", words.Select(w => info.ToTitleCase(w.Trim())));

        /* Known Exception to the rule fixed */
        var returnValue = joined.Replace("(S)", "(s)") + ".";

        return returnValue;
    }

    protected BusinessServiceException(string message, Exception inner)
        : base(StandardiseExceptionMessage(message), inner)
    {
    }

    protected BusinessServiceException(
        SerializationInfo info,
        StreamingContext context) : base(info, context)
    {
    }

    public override string ToString()
    {
        return InnerException == null ? Message : InnerException.ToString();
    }
}
