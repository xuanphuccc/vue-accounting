using MISA.WebFresher052023.Domain;

namespace MISA.WebFresher052023.Demo
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        /// <summary>
        /// Xử lý bắt exception
        /// </summary>
        /// <param name="context">HttpContext</param>
        /// <param name="exception">Exception</param>
        /// CreatedBy: txphuc (14/07/2023)
        private async Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";

            if (exception is NotFoundException)
            {
                // Không tìm thấy tài nguyên
                context.Response.StatusCode = StatusCodes.Status404NotFound;

                await context.Response.WriteAsync(
                        new BaseException()
                        {
                            ErrorCode = StatusCodes.Status404NotFound,
                            UserMessage = exception.Message,
                            DevMessage = exception.Message,
                            TraceId = context.TraceIdentifier,
                            MoreInfo = exception.HelpLink
                        }.ToString());
            }
            else if (exception is ConflictException)
            {
                // Trùng mã nhân viên
                context.Response.StatusCode = StatusCodes.Status409Conflict;

                await context.Response.WriteAsync(
                        new BaseException()
                        {
                            ErrorCode = StatusCodes.Status409Conflict,
                            UserMessage = exception.Message,
                            DevMessage = exception.Message,
                            TraceId = context.TraceIdentifier,
                            MoreInfo = exception.HelpLink
                        }.ToString());
            }
            else
            {
                // Lỗi hệ thống
                context.Response.StatusCode = StatusCodes.Status500InternalServerError;

                await context.Response.WriteAsync(
                        new BaseException()
                        {
                            ErrorCode = StatusCodes.Status500InternalServerError,
                            UserMessage = "Lỗi hệ thống, vui lòng thử lại sau",
                            DevMessage = exception.Message,
                            TraceId = context.TraceIdentifier,
                            MoreInfo = exception.HelpLink
                        }.ToString());
            }
        }
    }
}
