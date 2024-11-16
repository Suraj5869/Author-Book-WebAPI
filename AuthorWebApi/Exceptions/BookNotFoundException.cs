namespace AuthorWebApi.Exceptions
{
    public class BookNotFoundException:Exception
    {
        public BookNotFoundException(string msg):base(msg) { }
    }
}
