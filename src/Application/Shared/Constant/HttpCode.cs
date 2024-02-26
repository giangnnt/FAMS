using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace net03_group02.src.Application.Shared.Constant
{
    public class HttpCode
    {
        public const int OK = 200;
        public const int CREATED = 201;

        public const int BAD_REQUEST = 400;
        public const int UNAUTHORIZED = 401;
        public const int FORBIDDEN = 403;
        public const int NOT_FOUND = 404;
        public const int SOMETHING_WRONG = 422;
        public const int UNKNOWN_ERROR = 500;
        public const int INTERNAL_SERVER_ERROR = 500;
    }
}