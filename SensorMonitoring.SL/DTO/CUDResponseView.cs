using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SensorMonitoring.SL.DTO
{
    public class CUDResponseView
    {
        public bool IsSuccess { get; set; }
        public string ExceptionType { get; set; }
        public string ExceptionMessage { get; set; }

        public static CUDResponseView BuildSuccessResponse() => new CUDResponseView() { IsSuccess = true };

        public static CUDResponseView BuildErrorResponse(string message) =>
            new CUDResponseView()
            {
                IsSuccess = false,
                ExceptionMessage = message
            };

        public static CUDResponseView BuildErrorResponse(string type, string message) =>
            new CUDResponseView()
            {
                IsSuccess = false,
                ExceptionMessage = message,
                ExceptionType = type
            };
    }
}