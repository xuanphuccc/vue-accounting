const MISAResource = {
  VN: {
    Product: "Kế toán",
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
    },

    Text: {
      Selected: "Đã chọn",
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
          EmployeeCode: "Mã là bắt buộc",
          FullName: "Tên là bắt buộc",
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
  EN: {},
};

export default MISAResource;
