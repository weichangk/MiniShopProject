namespace System.ComponentModel
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
    public class OperationIdAttribute : Attribute
    {
        private string Default = null;

        public string OperationId { get { return Default; } }

        public OperationIdAttribute()
        {
        }

        public OperationIdAttribute(string description)
        {
            Default = description;
        }
    }
}
