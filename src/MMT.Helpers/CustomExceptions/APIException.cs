﻿using System;

namespace MMT.Common.CustomExceptions
{
    public class APIException : Exception
    {
        public int StatusCodes { get; }
        public APIException(string message, int statusCode) : base(message)
        {
            StatusCodes = statusCode;
        }
    }
}
