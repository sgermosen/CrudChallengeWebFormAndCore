namespace FormApp.Models
{
    public class Response<T>
    {
        public bool IsSuccess { get; set; }
        public T Value { get; set; }
        public string Error { get; set; }

    }
}