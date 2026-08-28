using HR.System.Application.extentions;

namespace HR.System.Application.exceptions
{
    [Serializable]
    public class EntityNotFoundException : BusinessServiceException
    {
        public EntityNotFoundException(string message)
            : base(message)
        {
        }

        public EntityNotFoundException(string message, Exception e)
            : base(message, e)
        {
        }

        public EntityNotFoundException(string entityName, string propertyName, string propertyValue)
            : base($"The {entityName} With {propertyName}: {propertyValue} Could Not Be Found.")
        {
        }

        public override string ToString()
        {
            return InnerException == null ? Message : InnerException.ToString();
        }
    }
}
