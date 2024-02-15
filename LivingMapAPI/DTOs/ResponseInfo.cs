namespace LivingMapAPI.DTOs
{
    public class ResponseInfo<T>
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public T Data { get; set; }

        public static ResponseInfo<T> CreateSuccess(T data)
        {
            return new ResponseInfo<T>
            {
                Success = true,
                Data = data
            };
        }

        public static ResponseInfo<T> CreateFailure(string message)
        {
            return new ResponseInfo<T>
            {
                Success = false,
                Message = message
            };
        }
    }
}
