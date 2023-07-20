const MISAResource = {
  VN: {
    Language: "Tiếng Việt",
    LanguageCode: "VN",
    Product: "Kế toán",
    FullProductName: "AMIS Kế toán",
    Company: "Công ty Cổ phần MISA",
    Sidebar: {
      Dashboard: "Tổng quan",
      Employee: "Nhân viên",
      Cash: "Tiền mặt",
      Purchase: "Mua hàng",
      Sell: "Bán hàng",
      InvoiceManagement: "Quản lý hoá đơn",
      Warehouse: "Kho",
      Tax: "Thuế",
      Report: "Báo cáo",
      Collapse: "Thu gọn",
    },

    UserMenu: {
      ChangePassword: "Đổi mật khẩu",
      AccountSettings: "Thiết lập tài khoản",
      SecuritySettings: "Thiết lập bảo mật",
      LicenseAndPayment: "Giấy phép & Thanh toán",
      ReferralsEarnPoints: "Giới thiệu - Tích điểm",
      Language: "Ngôn ngữ",
      SignOut: "Đăng xuất",
    },

    Gender: {
      Male: "Nam",
      Female: "Nữ",
      Other: "Khác",
    },

    Button: {
      Save: "Cất",
      SaveAndContinue: "Cất và thêm",
      Cancel: "Huỷ",
      OK: "Đồng ý",
      UnChecked: "Bỏ chọn",
      Delete: "Xoá",
      Update: "Sửa",
    },

    Table: {
      Functions: "Chức năng",
    },

    ContextMenu: {
      Duplicate: "Nhân bản",
      Delete: "Xoá",
      StopUsing: "Ngừng sử dụng",
    },

    Combobox: {
      PlaceHolder: "Chọn giá trị",
    },

    Paging: {
      TotalRecords: "Tổng",
      ItemsPerPage: "Số bản ghi/trang",
      Records: "Bản ghi",
      NextPage: "Trang Sau",
      PrevPage: "Trang Trước",
    },

    Dialog: {
      ErrorTitle: "Đã có lỗi",
    },

    Popup: {},

    Toast: {
      Success: "Thành công!",
      Error: "Lỗi!",
      Warning: "Cảnh báo!",
      Info: "Thông tin!",
    },

    Tooltip: {
      Reload: "Tải lại",
      Notification: "Thông báo",
      Account: "Tài khoản",
      Close: "Đóng",
    },

    Text: {
      Selected: "Đã chọn",
    },

    Month: {
      M1: "Tháng 1",
      M2: "Tháng 2",
      M3: "Tháng 3",
      M4: "Tháng 4",
      M5: "Tháng 5",
      M6: "Tháng 6",
      M7: "Tháng 7",
      M8: "Tháng 8",
      M9: "Tháng 9",
      M10: "Tháng 10",
      M11: "Tháng 11",
      M12: "Tháng 12",
    },

    Day: {
      Today: "Hôm nay",
      Mo: "T2",
      Tu: "T3",
      We: "T4",
      Th: "T5",
      Fr: "T6",
      Sa: "T7",
      Su: "CN",
    },

    Page: {
      Employee: {
        Title: "Nhân viên",
        AddButton: "Thêm mới nhân viên",
        SearchPlaceholder: "Tìm theo mã, tên nhân viên",
        Form: {
          CreateTitle: "Thêm nhân viên",
          UpdateTitle: "Sửa nhân viên",
        },
        Toast: {
          CreateSuccess: "Thêm nhân viên thành công",
          UpdateSuccess: "Cập nhật nhân viên thành công",
          DeleteSuccess: "Xoá nhân viên thành công",
          DuplicateSuccess: "Nhân bản nhân viên thành công",
        },
        Dialog: {
          DeleteConfirmTitle: "Xoá nhân viên",
          DeleteConfirmDesc: (name) =>
            `Xoá nhân viên "${name}". Nhân viên sau khi xoá sẽ không thể khôi phục lại được`,
          MultipleDeleteConfirmDesc: (count) =>
            `Xoá ${count} nhân viên. Nhân viên sau khi xoá sẽ không thể khôi phục lại được`,
        },
        Validate: {
          EmployeeCode: "Mã không được để trống",
          FullName: "Tên không được để trống",
          Department: "Đơn vị không được để trống",
        },

        EmployeeCode: {
          Title: "Mã",
          SubTitle: "Mã nhân viên",
          Desc: "Mã",
        },
        FullName: {
          Title: "Tên",
          SubTitle: "Tên nhân viên",
          Desc: "Tên",
        },
        Department: {
          Title: "Đơn vị",
          Desc: "Đơn vị",
        },
        Position: {
          Title: "Chức danh",
          Desc: "Chức danh",
        },
        DateOfBirth: {
          Title: "Ngày sinh",
          Desc: "Ngày sinh",
        },
        Gender: {
          Title: "Giới tính",
          Desc: "Giới tính",
        },
        IdentityNumber: {
          Title: "Số CMND",
          Desc: "Số Chứng minh nhân dân",
        },
        IdentityDate: {
          Title: "Ngày cấp",
          Desc: "Ngày cấp",
        },
        IdentityPlace: {
          Title: "Nơi cấp",
          Desc: "Nơi cấp",
        },
        Address: {
          Title: "Địa chỉ",
          Desc: "Địa chỉ",
        },
        MobilePhone: {
          Title: "ĐT di động",
          Desc: "Điện thoại di động",
        },
        LandlinePhone: {
          Title: "ĐT cố định",
          Desc: "Điện thoại cố định",
        },
        Email: {
          Title: "Email",
          Desc: "Email",
        },
        BankAccount: {
          Title: "Tài khoản ngân hàng",
          SubTitle: "Số tài khoản",
          Desc: "Tài khoản ngân hàng",
        },
        BankName: {
          Title: "Tên ngân hàng",
          Desc: "Tên ngân hàng",
        },
        BankBranch: {
          Title: "Chi nhánh",
          SubTitle: "Chi nhánh TK ngân hàng",
          Desc: "Chi nhánh tài khoản ngân hàng",
        },
      },
    },
  },
  EN: {
    Language: "English",
    LanguageCode: "EN",
    Product: "Accounting",
    FullProductName: "AMIS Accounting",
    Company: "MISA Joint Stock Company",
    Sidebar: {
      Dashboard: "Dashboard",
      Employee: "Employee",
      Cash: "Cash",
      Purchase: "Purchase",
      Sell: "Sell",
      InvoiceManagement: "Invoice",
      Warehouse: "Warehouse",
      Tax: "Tax",
      Report: "Report",
      Collapse: "Collapse",
    },

    UserMenu: {
      ChangePassword: "Change password",
      AccountSettings: "Account settings",
      SecuritySettings: "Security settings",
      LicenseAndPayment: "License & Payment",
      ReferralsEarnPoints: "Referrals - Earn points",
      Language: "Language",
      SignOut: "Sign out",
    },

    Gender: {
      Male: "Male",
      Female: "Female",
      Other: "Other",
    },

    Button: {
      Save: "Save",
      SaveAndContinue: "Save and continue",
      Cancel: "Cancel",
      OK: "OK",
      UnChecked: "Uncheck",
      Delete: "Delete",
      Update: "Edit",
    },

    Table: {
      Functions: "Functions",
    },

    ContextMenu: {
      Duplicate: "Duplicate",
      Delete: "Delete",
      StopUsing: "Stop Using",
    },

    Combobox: {
      PlaceHolder: "Select a value",
    },

    Paging: {
      TotalRecords: "Total",
      ItemsPerPage: "Records per page",
      Records: "Records",
      NextPage: "Next Page",
      PrevPage: "Previous Page",
    },

    Dialog: {
      ErrorTitle: "Error",
    },

    Popup: {},

    Toast: {
      Success: "Success!",
      Error: "Error!",
      Warning: "Warning!",
      Info: "Information!",
    },

    Tooltip: {
      Reload: "Reload",
      Notification: "Notification",
      Account: "Account",
      Close: "Close",
    },

    Text: {
      Selected: "Selected",
    },

    Month: {
      M1: "January",
      M2: "February",
      M3: "March",
      M4: "April",
      M5: "May",
      M6: "June",
      M7: "July",
      M8: "August",
      M9: "September",
      M10: "October",
      M11: "November",
      M12: "December",
    },

    Day: {
      Today: "Today",
      Mo: "MO",
      Tu: "TU",
      We: "WE",
      Th: "TH",
      Fr: "FR",
      Sa: "SA",
      Su: "SU",
    },

    Page: {
      Employee: {
        Title: "Employee",
        AddButton: "Add new employee",
        SearchPlaceholder: "Search by code or name",
        Form: {
          CreateTitle: "Add Employee",
          UpdateTitle: "Edit Employee",
        },
        Toast: {
          CreateSuccess: "Successfully added employee",
          UpdateSuccess: "Successfully updated employee",
          DeleteSuccess: "Successfully deleted employee",
          DuplicateSuccess: "Successfully duplicated employee",
        },
        Dialog: {
          DeleteConfirmTitle: "Delete Employee",
          DeleteConfirmDesc: (name) =>
            `Delete employee "${name}". The employee cannot be recovered after deletion`,
          MultipleDeleteConfirmDesc: (count) =>
            `Delete ${count} employees. Employees cannot be recovered after deletion`,
        },
        Validate: {
          EmployeeCode: "Code is required",
          FullName: "Name is required",
          Department: "Department is required",
        },

        EmployeeCode: {
          Title: "Code",
          SubTitle: "Employee code",
          Desc: "Code",
        },
        FullName: {
          Title: "Name",
          SubTitle: "Employee name",
          Desc: "Name",
        },
        Department: {
          Title: "Department",
          Desc: "Department",
        },
        Position: {
          Title: "Position",
          Desc: "Position",
        },
        DateOfBirth: {
          Title: "Date of Birth",
          Desc: "Date of Birth",
        },
        Gender: {
          Title: "Gender",
          Desc: "Gender",
        },
        IdentityNumber: {
          Title: "ID Number",
          Desc: "Identity Card Number",
        },
        IdentityDate: {
          Title: "Issue Date",
          Desc: "Issue Date",
        },
        IdentityPlace: {
          Title: "Issue Place",
          Desc: "Issue Place",
        },
        Address: {
          Title: "Address",
          Desc: "Address",
        },
        MobilePhone: {
          Title: "Mobile Phone",
          Desc: "Mobile Phone",
        },
        LandlinePhone: {
          Title: "Landline Phone",
          Desc: "Landline Phone",
        },
        Email: {
          Title: "Email",
          Desc: "Email",
        },
        BankAccount: {
          Title: "Bank Account",
          SubTitle: "Account Number",
          Desc: "Bank Account",
        },
        BankName: {
          Title: "Bank Name",
          Desc: "Bank Name",
        },
        BankBranch: {
          Title: "Bank Branch",
          SubTitle: "Bank Account Branch",
          Desc: "Bank Account Branch",
        },
      },
    },
  },
};

export default MISAResource;
