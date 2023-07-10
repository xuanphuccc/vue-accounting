# Middleware trong ứng dụng ASP.NET Core

## 1. Middleware

Middleware là một module code nó có thể làm được những chức năng sau:

-   Nhận một HTTP Request gửi đến và phát sinh ngay HTTP Response để trả về.
-   Nhận một HTTP Request gửi đến, thực hiện một số tác vụ (ví dụ như sửa đổi HTTP Request) sau đó chuyển đến một middleware khác để xử lý.
-   Nhận một HTTP Response, sửa nó và chuyển sang một middleware khác.

## 2. Pipeline

Trong ứng dụng ASP.NET Core, các middleware kết nối lại với nhau thành một xích, middleware đầu tiên nhận HTTP Request xử lý nó và có thể chuyển cho middleware tiếp theo hoặc trả ngay về HTTP Response. Chuỗi các middleware theo thứ tự như vậy gọi là pipeline.

## 3. Một số Middleware thường gặp trong ứng dụng ASP.NET Core

-   `app.UseStaticFiles()` nếu yêu cầu truy cập là file tĩnh thì nó trả ngay về Response là nội dung file và là điểm cuối của pipeline còn nếu khác file tĩnh nó gọi Middleware phía sau trong Pipeline.
-   `app.UseSession` khôi phục, thiết lập session sau đó gọi ngay Middleware tiếp theo trong Pipeline.
-   `app.UseCors` xử lý các cấu hình về Cors policy
-   `app.UseAuthentication()` xử lý các yêu cầu về xác thực người dùng
-   `app.UseAuthorization()` xử lý các yêu cầu về phân quyền
-   `app.Run()` tạo điểm cuối của Pipeline

## 4. Tạo custom Middleware trong ứng dụng ASP.NET Core

### 4.1 Xây dựng Custom Middleware triển khai từ interface IMiddleware

```cs
namespace Middleware {
  public class MyMiddleware : IMiddleware
  {
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        // Logic xử lý

        // Chuyển sang Middleware tiếp theo
        await next(context);
    }
  }
}
```

-   Khi sử dụng cần phải đăng ký vào hệ thống DI Container trước:

```cs
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddTransient<MyMiddleware>();
```

-   Sau đó sử dụng bằng cách:

```cs
var app = builder.Build();

app.UseMiddleware<MyMiddleware>();
```

### 4.2 Tự xây dựng Middleware

```cs
namespace Middleware
{
    public class CustomMiddleware
    {
        private readonly RequestDelegate next;
        public CustomMiddleware(RequestDelegate _next) {
            next = _next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            // Logic xử lý

            // Chuyển sang Middleware tiếp theo
            await next(context);
        }
    }
}
```

-   Khi sử dụng chỉ cần sử dụng phương thức UseMiddleware của IApplicationBuilder mà không cần phải đăng ký vào hệ thống DI Container:

```cs
var app = builder.Build();

app.UseMiddleware<CustomMiddleware>();
```
