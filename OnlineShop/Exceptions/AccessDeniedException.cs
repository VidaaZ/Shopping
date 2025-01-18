namespace OnlineShop.Exceptions
{
    public class AccessDeniedException : Exception
    {
        public int RoleId { get; }
        public AccessDeniedException()
        {

        }
        public AccessDeniedException(string message) : base(message) { }
        public AccessDeniedException(string message, Exception inner) : base(message, inner) { }
        public AccessDeniedException(string message, int roleId) : this(message)
        {
            RoleId = roleId;
        }
    }
}
