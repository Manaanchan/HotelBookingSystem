using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DTO
{
    public class BaseResponse<T>
    {
        public bool IsSuccessful { get; set; }
        public string Message { get; set; } = default!;
        public T? Data { get; set; }


        public static BaseResponse<T> Success(T? data, string message)
        {
            return new BaseResponse<T>
            {
                IsSuccessful = true,
                Message = message,
                Data = data
            };
        }

        public static BaseResponse<T> Failure(string message)
        {
            return new BaseResponse<T>
            {

                IsSuccessful = false,
                Message = message
            };
        }
    }
}
