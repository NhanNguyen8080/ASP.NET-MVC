﻿## Controller
- Là một lớp kế thừa lớp Controller : Microsoft.AspNetCore.Mvc.Controller
- Action trong controller là một phương thức public (kh đc static)
- Action trả về bất kỳ kiểu dữ liệu nào, thường là IActionResult
- Các dịch vụ inject vào controller qua hàm tạo
## View
- Là file .cshtml
- View cho Action lưu tại: /Views/ControllerName/ActionName.cshtml
- Thêm thư mục lưu trữ View:
```
// {0} -> tên Action
// {1} -> tên Controller
// {2} -> tên Area 
options.ViewLocationFormats.Add("/MyView/{1}/{0}" + RazorViewEngine.ViewExtension);
```

## Truyền dữ liệu sang View
- Model
- ViewData
- ViewBag
- TempData 
