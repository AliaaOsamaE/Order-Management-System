namespace ErrorModels
{
    public class ErrorToReturn
    {
        public int StatusCode { get; set; }
        public string Message { get; set; } = default!;
    }
}
