const resourceVn = {
  product: "Thuế TNCN",
  fullProductName: "Thuế thu nhập cá nhân",
  company: "Công ty Cổ phần MISA",

  validate: {
    required: "không được bỏ trống",
    inValidate: "Không đúng định dạng",
  },

  sidebar: {
    registerTaxId: "Đăng ký mã số thuế",
    registerDependents: "Đăng ký người phụ thuộc",
    taxReportingByPeriod: "Khai thuế theo kỳ",
    taxDeductionReceipts: "Chứng từ khấu trừ thuế",
    taxFinalization: "Quyết toán thuế",
    procedure: "Thủ tục",
    report: "Báo cáo",
    taxpayer: "Người nộp thuế",
    taxServiceRegistration: "Đăng ký dịch vụ thuế",
    configuration: "Thiết lập",
    trashBin: "Thùng rác",

    collapse: "Thu gọn",
  },

  userMenu: {
    userFullName: "Trần Xuân Phúc",
    changePassword: "Đổi mật khẩu",
    accountSettings: "Thiết lập tài khoản",
    securitySettings: "Thiết lập bảo mật",
    referralsEarnPoints: "Giới thiệu - Tích điểm",
    language: "Ngôn ngữ",
    signOut: "Đăng xuất",
  },

  gender: {
    male: "Nam",
    female: "Nữ",
    other: "Khác",
  },

  button: {
    addNew: "Thêm mới",
    add: "Thêm",
    save: "Lưu",
    dontSave: "Không lưu",
    saveAndAddNew: "Lưu & Thêm mới",
    apply: "Âp dụng",
    ok: "Đồng ý",
    removeFilter: "Bỏ lọc",
    delete: "Xoá",
    cancel: "Huỷ",
    edit: "Chỉnh sửa",
    openInNewWindow: "Mở trong cửa sổ mới",
    unChecked: "Bỏ chọn",
    restoreDefault: "Mặc định",
    exportExcel: "Xuất khẩu",
    using: "Sử dụng",
    stopUsing: "Ngừng sử dụng",
    yes: "Có",
    no: "Không",
  },

  placeholder: {
    selectAValue: "Chọn giá trị",
    search: "Tìm kiếm",
    enterValue: "Nhập giá trị",
    select: "Chọn",
    input: "Nhập",
    selectOrInput: "Chọn/nhập",
  },

  paging: {
    totalRecords: "Tổng số",
    itemsPerPage: "Số bản ghi/trang",
    records: "bản ghi",
    nextPage: "Trang sau",
    prevPage: "Trang trước",
  },

  dialog: {
    errorTitle: "Đã có lỗi",
    warningTitle: "Cảnh báo",
    infoTitle: "Thông tin",
    deleteTitle: "Xoá dữ liệu",
    closeFormWarningTitle: "Dữ liệu đã thay đổi",
    closeFormWarningDesc: "Lưu lại những thay đổi?",
  },

  tooltip: {
    notification: "Thông báo",
    help: "Trợ giúp",
    otherFeatures: "Tính năng khác",
    account: "Tài khoản",
    close: "Đóng",
    setting: "Tuỳ chỉnh cột",
    back: "Quay lại",
  },

  text: {
    selected: "Đã chọn",
  },

  // Loại giấy tờ
  identifyType: {
    nationalIdentityCard: "CMND",
    citizenCard: "CCCD",
    passport: "Hộ chiếu",
  },

  // Loại hợp đồng
  contractType: {
    nonResident: "Không cư trú",
    residenceWithContract: "Cư trú và có HĐLĐ từ 3 tháng trở lên",
    residenceWithoutContract: "Cư trú và không đăng ký HĐLĐ/HĐLĐ dưới 3 tháng",
  },

  customizeColumn: {
    title: "Tuỳ chỉnh cột",
    search: "Tìm kiếm",
  },

  filterPopup: {
    title: "Bộ lọc",
    startDate: "Từ ngày",
    endDate: "Đến ngày",
  },

  employee: {
    toast: {
      addSuccess: "Thêm người nộp thuế thành công",
      updateSuccess: "Cập nhật người nộp thuế thành công",
      deleteSuccess: "Xoá người nộp thuế thành công",

      addFamilySuccess: "Thêm mới thông tin gia đình người nộp thuế thành công",
      updateFamilySuccess: "Cập nhật thông tin gia đình người nộp thuế thành công",
      deleteFamilySuccess: "Xoá thông tin gia đình thành công",
    },

    dialog: {
      deleteEmployeeTitle: "Xoá người nộp thuế",
      deleteEmployeeDesc:
        "Bạn có chắc chắn muốn xóa người nộp thuế <b>{employee}</b> vào Thùng rác?",
      deleteMultipleEmployeeDesc:
        "Bạn có chắc chắn muốn xoá <b>({quantity})</b> người nộp thuế vào Thùng rác?",
      deleteFamilyDesc: "Bạn có chắc chắn xóa thông tin gia đình này khỏi danh sách không?",
    },

    advancedFilter: {
      workStatus: "Trạng thái làm việc",
      employeeType: "Loại đối tượng",
      taxCode: "Mã số thuế",
      haveTaxCode: "Đã có MST",
      noTaxCode: "Chưa có MST",
      time: "Thời gian",
    },

    // Loại đối tượng
    employeeType: {
      employee: "Nhân viên",
      client: "Vãng lai",
    },

    // Trạng thái làm việc
    workStatus: {
      formerlyEmployed: "Đã nghỉ việc",
      currentlyEmployed: "Đang làm việc",
    },

    // Trạng thái sử dụng
    usageStatus: {
      using: "Đang sử dụng",
      stopUsing: "Không sử dụng",
    },

    filterBar: {
      search: "Tìm theo Mã/Tên nhân viên, MST, CMND",
      department: "Bộ phận/phòng ban",
      filter: "Bộ lọc",
      customizeColumns: "Tuỳ chỉnh cột",
      usageStatus: "Trạng thái sử dụng",
    },

    text: {
      hideDepartmentSelect: "Hiển thị cơ cấu tổ chức ngừng theo dõi",
    },

    employeeList: {
      title: "Hồ sơ người nộp thuế",
      button: {
        syncAmisSystem: "Đồng bộ AMIS Hệ thống",
        manageEmployeeUsingService: "Quản lý lao động sử dụng dịch vụ",
        createDeclaration: "Lập tờ khai",
        createProcedure: "Lập thủ tục",
      },
    },

    employeeDetail: {
      createFormTitle: "Thêm người nộp thuế",
      updateFormTitle: "Sửa người nộp thuế",
      viewTitle: "Thông tin người nộp thuế",

      button: {
        getInfo: "Lấy thông tin",
      },

      mainInfoTitle: "Thông tin chung",
      jobInfoTitle: "Thông tin công việc",
      familyInfoTitle: "Thông tin gia đình",
      familyInfoEmpty: "Chưa có thông tin gia đình",

      personalInfoSubTitle: "Thông tin cá nhân",
      permanentResidenceSubTitle: "Hộ khẩu thường trú",
      currentAccommodationSubTitle: "Chỗ ở hiện nay",

      employeeType: "Loại đối tượng",
      employeeCode: "Mã người nộp thuế",
      employeeCodeColumn: "Mã nhân viên",
      fullName: "Họ tên",
      fullNameColumn: "Họ và tên",
      dateOfBirth: "Ngày sinh",
      gender: "Giới tính",
      mobile: "Số điện thoại",
      email: "Email",
      taxCode: "Mã số thuế",
      identifyType: "Loại giấy tờ",
      identifyNumber: "Số {identifyType}",
      identifyNumberColumn: "Số CMND/CCCD/Hộ chiếu",
      identifyDate: "Ngày cấp",
      identifyIssuedPlace: "Nơi cấp",
      national: "Quốc tịch",
      contractType: "Loại hợp đồng",
      country: "Quốc gia",
      province: "Tỉnh/thành phố",
      district: "Quận/huyện",
      ward: "Xã/phường",
      streetNumber: "Số nhà, đường/phố, thôn/xóm",
      address: "Địa chỉ",
      isCopyAddress: "Giống hộ khẩu thường trú",
      department: "Bộ phận/phòng ban",
      departmentColumn: "Bộ phận/Phòng ban",
      jobPosition: "Vị trí công việc",
      jobPositionColumn: "Vị trí/Chức vụ",
      jobTitle: "Chức danh",
      employeeStatus: "Trạng thái làm việc",
      probationDate: "Ngày học việc",
      hireDate: "Ngày thử việc",
      receiveDate: "Ngày chính thức",
      terminationDate: "Ngày nghỉ việc",
      usageStatus: "Trạng thái sử dụng",
    },

    employeeFamilyDetail: {
      createFormTitle: "Thêm thành viên gia đình",
      updateFormTitle: "Sửa thành viên gia đình",

      birthInformationTitle: "Thông tin khai sinh",
      permanentResidenceTitle: "Hộ khẩu thường trú",
      currentAccommodationTitle: "Chỗ ở hiện nay",
      deductionInformation: "Thông tin giảm trừ",

      button: {
        getInfo: "Lấy thông tin",
      },

      fullName: "Họ tên thành viên",
      fullNameColumn: "Họ và tên",
      relationship: "Quan hệ",
      dateOfBirth: "Ngày sinh",
      gender: "Giới tính",
      taxCode: "Mã số thuế",
      nationality: "Quốc tịch",
      identifyType: "Loại giấy tờ",
      identifyNumber: "Số {identifyType}",
      identifyIssuedDate: "Ngày cấp",
      identifyIssuedPlace: "Nơi cấp",
      dependentNumber: "Số khai sinh",
      numberBook: "Quyển số",
      birthCertificationIssueDate: "Ngày cấp giấy khai sinh",
      country: "Quốc gia",
      province: "Tỉnh/thành phố",
      district: "Quận/huyện",
      ward: "Xã/phường",
      streetNumber: "Số nhà, đường/phố, thôn/xóm",
      isDependent: "Là người phụ thuộc",
      deductionStartDate: "Giảm trừ từ tháng",
      deductionStartDateColumn: "Giảm trừ từ",
      deductionEndDate: "Giảm trừ đến tháng",
      deductionEndDateColumn: "Giảm trừ đến",
      description: "Ghi chú",
    },

    employeeManagerList: {
      title: "Quản lý lao động sử dụng dịch vụ",

      totalEmployees: "Tổng số lao động",
      totalEmployeesDesc:
        "Tất cả người nộp thuế có loại đối tượng là Nhân viên và Vãng lai trên AMIS Thuế TNCN",

      currentlyUsingService: "Đang sử dụng dịch vụ",
      currentlyUsingServiceDesc:
        "Người nộp thuế có loại đối tượng là Nhân viên và Vãng lai có thiết lập sử dụng dịch vụ Thuế TNCN",

      notUsingService: "Không sử dụng dịch vụ",
      notUsingServiceDesc:
        "Người nộp thuế có loại đối tượng là Nhân viên và Vãng lai không thiết lập sử dụng dịch vụ Thuế TNCN",

      button: {
        configureAutomaticRules: "Thiết lập quy tắc tự động",
      },
    },
  },
};

export default resourceVn;
