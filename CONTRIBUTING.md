# QUY TẮC VIẾT COMMIT MESSAGE

Mọi commit vào dự án phải tuân thủ nghiêm ngặt định dạng một dòng duy nhất như sau:

```text
<type>(<scope>): <subject>

```

### 1. Thành phần cấu trúc

| Thành phần | Giải thích | Quy tắc bắt buộc |
| --- | --- | --- |
| **type** | Loại thay đổi | Chọn từ danh sách quy định bên dưới. |
| **scope** | Phạm vi ảnh hưởng | Tên Layer (`domain`, `infra`, `api`) hoặc tên Feature (`auth`, `booking`). |
| **subject** | Nội dung chính | Viết thường, thể mệnh lệnh, **không** có dấu chấm ở cuối. |

### 2. Danh sách Type quy định

| Type | Ý nghĩa | Ví dụ |
| --- | --- | --- |
| **feat** | Thêm tính năng mới | `feat(booking): add ticket validation` |
| **fix** | Sửa lỗi (Bug fix) | `fix(api): handle null request body` |
| **refactor** | Tái cấu trúc code (không đổi logic) | `refactor(domain): rename movie entity property` |
| **style** | Sửa format (space, xuống dòng...) | `style(infra): format db context file` |
| **docs** | Thay đổi tài liệu | `docs(readme): update setup instruction` |
| **test** | Thêm hoặc sửa test | `test(app): add unit test for create command` |
| **chore** | Việc vặt (build, package, config) | `chore(nuget): update ef core to v9.0` |
| **ci** | Cấu hình CI/CD | `ci(github): add docker build workflow` |
| **perf** | Tối ưu hiệu năng | `perf(db): add index for user email` |

### 3. Ví dụ Đúng/Sai

**Nên làm (Đúng chuẩn):**

```bash
feat(auth): implement jwt token generation
fix(domain): correct logic for seat pricing
refactor(app): extract interface for email service
chore(sln): remove unused project reference

```

**Không nên làm (Sai quy tắc):**

```bash
fixed login bug (Sai: Dùng quá khứ, thiếu type/scope)
feat(ui): Added button. (Sai: Dùng quá khứ, dư dấu chấm)
[api] update controller (Sai: Sai định dạng type)
update code (Sai: Quá chung chung)

```

### 4. Ghi chú nhanh

* Sử dụng thể mệnh lệnh: "add" thay vì "added", "fix" thay vì "fixed".
* Toàn bộ viết thường (lowercase), trừ các tên riêng bắt buộc.
* Giới hạn độ dài dưới 72 ký tự nếu có thể.
