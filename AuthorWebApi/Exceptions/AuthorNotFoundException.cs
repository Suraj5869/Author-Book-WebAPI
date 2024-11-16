namespace AuthorWebApi.Exceptions
{
    public class AuthorNotFoundException:Exception
    {
        public AuthorNotFoundException(string msg):base(msg) { }
    }
}
