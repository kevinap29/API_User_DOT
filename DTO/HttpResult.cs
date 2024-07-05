namespace Shared
{
    public class HttpResult<T>
    {
        public HttpResult(string message)
        {
            IsSuccess = false;
            ErrorMessage = message;
        }

        public HttpResult(T value)
        {
            IsSuccess = true;
            Value = value;
        }

        public bool IsSuccess { get; set; }
        public string? ErrorMessage { get; set; }
        public T? Value { get; set; }
    }
}
