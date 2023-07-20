using MISA.WebFresher052023.Domain;
using System.Globalization;
using System.Text.RegularExpressions;

namespace MISA.WebFresher052023.Middleware
{
    public class LocalizationMiddleware
    {
        #region Fields
        private readonly RequestDelegate _next;
        #endregion

        #region Constructor
        public LocalizationMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        #endregion

        #region Methods
        /// <summary>
        /// Thay đổi ngôn ngữ
        /// </summary>
        /// <param name="context">HttpContext</param>
        /// CreatedBy: txphuc (14/07/2023)
        public async Task InvokeAsync(HttpContext context)
        {
            var language = context.Request.Headers.ContentLanguage;

            if(language.Count == 1)
            {
                CultureInfo.CurrentCulture = new CultureInfo(language[0]);
                CultureInfo.CurrentUICulture = new CultureInfo(language[0]);
            }

            await _next(context);
        }
        #endregion
    }
}
