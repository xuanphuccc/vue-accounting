# Attribute

## 1. Khái niệm Attribute

-   Một Attribute tác động vào một thành phần nào đó của chương trình (lớp, phương thức, thuộc tính), nó là một phần của siêu dữ liệu (metadata - loại dữ liệu cung cấp thêm thông tin về đối tượng nào đó). Atrribute giúp thêm thông tin vào lớp, phương thức, thuộc tính những đoạn code mở rộng.
-   Các Attribute có thể được truy xuất và tra cứu ở thởi điểm thực thi bằng kỹ thuật `reflection`, truy xuất ngược từ đối tượng biết được nguồn gốc mà nó sinh ra (lớp).

## 2. Data Attribute

Các Data Atrribute trong C# có các loại bao gồm:

-   Các Attribute để validate dữ liệu
-   Các Attribute hiển thị (Display Attribute)
-   Modelling Atrribute

Một số Attribute thường gặp:

-   `Required` dữ liệu là bắt buộc
-   `StringLength` thiết lập độ dài trường dữ liệu
-   `DataType` chỉ ra dữ liệu phải phù hợp với một loại dữ liệu nào đó
-   `Range` chỉ ra dữ liệu phải nămgf trong khoảng nào đó
-   `Phone` dữ liệu phải theo định dạng của số điện thoại
-   `EmailAddress` dữ liệu phải theo định dạng của email
