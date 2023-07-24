﻿using MISA.WebFresher052023.Domain;
using MISA.WebFresher052023.Domain.Resources.ErrorMessage;

namespace MISA.WebFresher052023
{
    public class ExceptionMiddleware
    {
        #region Fields
        private readonly RequestDelegate _next;
        #endregion

        #region Constructor
        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        #endregion

        #region Methods
        /// <summary>
        /// Bắt exception trong pipeline
        /// </summary>
        /// <param name="context">HttpContext</param>
        /// CreatedBy: txphuc (14/07/2023)
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

            switch (exception)
            {
                // Không tìm thấy tài nguyên
                case NotFoundException:
                    context.Response.StatusCode = StatusCodes.Status404NotFound;

                    await context.Response.WriteAsync(
                            new BaseException()
                            {
                                ErrorCode = ErrorCode.NotFound,
                                UserMessage = ErrorMessage.NotFound,
                                DevMessage = exception.Message,
                                TraceId = context.TraceIdentifier,
                                MoreInfo = exception.HelpLink
                            }.ToString() ?? "");
                    break;

                // Trùng mã
                case ConflictException:
                    context.Response.StatusCode = StatusCodes.Status409Conflict;

                    await context.Response.WriteAsync(
                            new BaseException()
                            {
                                ErrorCode = ErrorCode.ConflictCode,
                                UserMessage = ErrorMessage.ConflictCode,
                                DevMessage = exception.Message,
                                TraceId = context.TraceIdentifier,
                                MoreInfo = exception.HelpLink
                            }.ToString() ?? "");
                    break;

                // Lỗi hệ thống
                default:
                    context.Response.StatusCode = StatusCodes.Status500InternalServerError;

                    await context.Response.WriteAsync(
                            new BaseException()
                            {
                                ErrorCode = ErrorCode.ServerError,
                                UserMessage = ErrorMessage.ServerError,
                                DevMessage = exception.Message,
                                TraceId = context.TraceIdentifier,
                                MoreInfo = exception.HelpLink
                            }.ToString() ?? "");
                    break;
            }
        }
        #endregion
    }
}
