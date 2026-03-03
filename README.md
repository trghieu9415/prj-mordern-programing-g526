# MovieOnline Backend - Modern Programming Approach

Dự án này là một ví dụ điển hình về việc xây dựng hệ thống Backend hiện đại sử dụng **ASP.NET Core 9**, áp dụng kiến trúc **Clean Architecture** (hoặc Hexagonal Architecture) để giải quyết các thách thức phổ biến trong phát triển phần mềm doanh nghiệp.

## Kiến trúc hệ thống (Architecture)

Dự án được chia thành 4 lớp cốt lõi, tách biệt hoàn toàn giữa nghiệp vụ và công nghệ:

1.  **MvDomain**: Chứa các Entity, Value Objects và logic cốt lõi. Không phụ thuộc vào bất kỳ thư viện bên thứ ba nào.
2.  **MvApplication**: Chứa các Use Cases (lớp điều hướng nghiệp vụ). Sử dụng mẫu **CQRS** (Command Query Responsibility Segregation) để phân tách giữa tác vụ đọc và ghi dữ liệu.
3.  **MvInfrastructure**: Triển khai các chi tiết kỹ thuật (Adapters) như Entity Framework Core, Redis, JWT, Email Service.
4.  **MvPresentation**: Lớp giao tiếp với người dùng (Web API), quản lý Middleware, SignalR Hubs và cấu hình ứng dụng.

---

## Các vấn đề Backend được giải quyết

### 1. Quản lý sự phụ thuộc và Khả năng kiểm thử (Dependency Injection & Decoupling)
Thông qua các **Ports (Interfaces)** ở lớp Application và **Adapters** ở lớp Infrastructure, hệ thống đạt được sự lỏng lẻo (loose coupling).
- **Giải quyết:** Dễ dàng thay đổi công nghệ (ví đổi từ SQL Server sang PostgreSQL, hoặc đổi từ Redis sang Memcached) mà không cần sửa đổi logic nghiệp vụ.

### 2. Tính toàn vẹn dữ liệu (Data Integrity & Transactions)
Sử dụng mẫu **Unit of Work** và **Transaction Behavior**.
- **Giải quyết:** Đảm bảo tính nguyên tử (Atomicity). Nếu một quy trình (ví dụ: Đặt vé) gồm nhiều bước ghi dữ liệu bị lỗi ở giữa, toàn bộ tiến trình sẽ được Rollback, tránh tình trạng dữ liệu rác hoặc không nhất quán.

### 3. Xử lý các mối quan tâm chéo (Cross-cutting Concerns)
Sử dụng **MediatR Pipeline Behaviors** và **Middlewares**.
- **Giải quyết:**
  - **Validation:** Tự động kiểm tra dữ liệu đầu vào (FluentValidation) trước khi vào tới Handler.
  - **Global Exception Handling:** Một nơi duy nhất xử lý mọi lỗi phát sinh, trả về định dạng lỗi chuẩn (`AppResponse`) cho Client thay vì làm lộ stack trace.
  - **Logging & Transaction:** Tự động hóa việc ghi log và quản lý transaction cho mọi Command.

### 4. Hiệu suất và Khả năng mở rộng (Performance & Scalability)
- **Caching:** Tích hợp `ICacheStorage` (Redis) để giảm tải cho database với các dữ liệu ít thay đổi.
- **Concurrency Control:** Sử dụng `ILockService` để giải quyết vấn đề **Race Condition** (ví dụ: hai người cùng đặt một ghế cùng một lúc).
- **CQRS:** Tách biệt `IReadRepository` và `IRepository` giúp tối ưu hóa các câu lệnh truy vấn (Query) độc lập với các thao tác thay đổi dữ liệu (Command).

### 5. Bảo mật (Security)
- **Identity & JWT:** Quản lý danh tính người dùng qua ASP.NET Core Identity và xác thực stateless bằng JSON Web Token (JWT) với cơ chế Access Token/Refresh Token.
- **Abstraction:** Thông qua `ICurrentUser`, logic nghiệp vụ không cần biết chi tiết về việc token được lưu ở đâu, chỉ cần lấy thông tin user hiện tại một cách an toàn.

### 6. Giao tiếp thời gian thực (Real-time Communication)
Sử dụng **SignalR Hubs**.
- **Giải quyết:** Cập nhật trạng thái phòng vé, suất chiếu cho toàn bộ người dùng đang truy cập ngay lập tức mà không cần họ phải load lại trang (Polling).

---

## 🛠 Công nghệ sử dụng

- **Runtime:** .NET 9.0 (Latest)
- **Database ORM:** Entity Framework Core (Code First)
- **Messaging/Mediator:** MediatR (implicit via UseCases structure)
- **Real-time:** ASP.NET Core SignalR
- **Caching & Concurrency:** Redis
- **Security:** JWT Auth & ASP.NET Core Identity
- **API Documentation:** Swagger/OpenAPI (Microsoft.AspNetCore.OpenApi)

---

## 📂 Cấu trúc thư mục tiêu biểu

```text
├── MvApplication/
│   ├── Abstractions/    # Định nghĩa các giao thức (Transaction, Command, Query)
│   ├── Behaviors/       # Pipeline xử lý Validation và Transaction
│   ├── Ports/           # Interfaces cho các dịch vụ ngoại vi (Storage, Security, Repo)
│   └── UseCases/        # Logic nghiệp vụ chia theo tính năng (Booking, Catalog...)
├── MvInfrastructure/
│   ├── Adapters/        # Hiện thực hóa các Ports (Redis, EF Repo, JWT)
│   └── Persistence/     # Cấu hình Database (DbContext, Fluent API)
└── MvPresentation/
    ├── Controllers/     # Entry points cho Web API
    ├── Hubs/            # Quản lý kết nối Socket (SignalR)
    └── Middlewares/     # Xử lý lỗi toàn cục
```

---

## Hướng dẫn cài đặt

1. **Yêu cầu:** Cài đặt .NET 9 SDK và Docker (cho SQL Server/Redis).
2. **Cấu hình:** Cập nhật chuỗi kết nối trong `appsettings.Development.json`.
3. **Migration:**
   ```bash
   dotnet ef database update --project MvInfrastructure --startup-project MvPresentation
   ```
4. **Chạy ứng dụng:**
   ```bash
   dotnet run --project MvPresentation
   ```

---
*Dự án này được xây dựng bởi Group 5 - Modern Programming Course.*
