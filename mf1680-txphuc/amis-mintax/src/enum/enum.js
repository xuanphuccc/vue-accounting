const enums = {
  // Các chế độ form
  form: {
    mode: {
      CREATE: 0,
      UPDATE: 1,
      DUPLICATE: 2,
    },
  },

  editMode: {
    // Thêm mới
    CREATE: 0,

    // Cập nhật
    UPDATE: 1,

    // Xoá
    DELETE: 2,
  },

  // Loại dialog
  dialog: {
    type: {
      INFO: "info",
      WARNING: "warning",
      ERROR: "error",
    },
  },

  // Loại sắp xếp
  sort: {
    DESC: "desc",
    ASC: "asc",
  },

  // Loại filter
  filter: {
    EQUAL: "equal",
    NOTEQUAL: "notequal",
    CONTAIN: "contain",
    NOTCONTAIN: "notcontain",
    SMALLER: "smaller",
    GREATER: "greater",
  },

  // Giới tính
  gender: {
    male: 0,
    female: 1,
    other: 2,
  },

  // Loại đối tượng
  employeeType: {
    // Nhân viên
    employee: 0,

    // Vãng lai
    client: 1,
  },

  // Loại giấy tờ
  identifyType: {
    // CMND
    nationalIdentityCard: 0,

    // CCCD
    citizenCard: 1,

    // Hộ chiếu
    passport: 2,
  },

  // Loại hợp đồng
  contractType: {
    // Không cư trú
    nonResident: 0,

    // Cư trú và có HĐLD từ 3 tháng trở lên
    residenceWithContract: 1,

    // Cư trú và không đăng ký HĐLĐ/HĐLĐ dưới 3 tháng
    residenceWithoutContract: 2,
  },

  // Trạng thái làm việc
  workStatus: {
    // Đã nghỉ việc
    formerlyEmployed: 0,

    // Đang làm việc
    currentlyEmployed: 1,
  },

  // Mã bàn phím
  key: {
    TAB: 9,
    ENTER: 13,
    ESC: 27,
    ARROW_LEFT: 37,
    ARROW_UP: 38,
    ARROW_RIGHT: 39,
    ARROW_DOWN: 40,
    NUM_1: 49,
    D: 68,
    S: 83,
    Y: 89,
  },

  // Các chế độ import Excel
  import: {
    step: {
      UPLOAD: 1,
      MAP: 2,
      VALIDATE: 3,
      RESULT: 4,
    },
  },

  // Mã ngôn ngữ
  language: {
    VN: "vi-VN",
    EN: "en-US",
  },
};

export default enums;
