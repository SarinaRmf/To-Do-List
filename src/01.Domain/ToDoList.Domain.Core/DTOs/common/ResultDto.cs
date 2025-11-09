using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoList.Domain.Core.DTOs.common
{
    public class ResultDto<T>
    {
        public bool IsSuccess { get; set; }
        public string? Message { get; set; }
        public T? Data { get; set; }

        public static ResultDto<T> Success(string message, T? data = default) =>
             new() { IsSuccess = true, Message = message, Data = data };

        public static ResultDto<T> Failure(string message, T? data = default) =>
            new() { IsSuccess = false, Message = message, Data = data };
    }
}
