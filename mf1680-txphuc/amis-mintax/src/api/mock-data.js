// Mối quan hệ
export const relationships = [
  {
    value: 0,
    label: "Con gái",
  },
  {
    value: 1,
    label: "Con trai",
  },
  {
    value: 2,
    label: "Em gái",
  },
  {
    value: 3,
    label: "Em trai",
  },
  {
    value: 4,
    label: "Chị",
  },
  {
    value: 5,
    label: "Anh",
  },
  {
    value: 6,
    label: "Vợ",
  },
  {
    value: 7,
    label: "Chồng",
  },
  {
    value: 8,
    label: "Mẹ",
  },
  {
    value: 9,
    label: "Bố",
  },
];

// Quốc gia
export const countries = [
  {
    value: "VN",
    label: "Việt Nam",
  },
];

// Tỉnh/thành phố
export const provinces = [
  {
    value: "VN01",
    countryCode: "VN",
    label: "Hà Nội",
  },
  {
    value: "VN02",
    countryCode: "VN",
    label: "Hồ Chí Minh",
  },
];

// Quận/huyện
export const districts = [
  {
    value: "VN0101",
    label: "Cầu Giấy",
    provinceCode: "VN01",
    countryCode: "VN",
  },

  {
    value: "VN0201",
    label: "Quận 1",
    provinceCode: "VN02",
    countryCode: "VN",
  },
];

// Xã/phường
export const wards = [
  {
    value: "VN0101001",
    label: "Phường Dịch Vọng",
    districtCode: "VN0101",
    provinceCode: "VN01",
    countryCode: "VN",
  },

  {
    value: "VN0201001",
    label: "Phường Bến Nghé",
    districtCode: "VN0201",
    provinceCode: "VN02",
    countryCode: "VN",
  },
];

// Bộ phận/phòng ban
export const departments = [
  {
    value: 0,
    label: "",
  },
];

// Vị trí công việc
export const positions = [
  {
    value: 0,
    label: "Giám đốc chi nhánh",
  },
  {
    value: 1,
    label: "Kiểm soát chất lượng",
  },
  {
    value: 2,
    label: "Nhân viên kinh doanh",
  },
  {
    value: 3,
    label: "Lập trình viên",
  },
  {
    value: 4,
    label: "Nhân viên Digital Marketing",
  },
  {
    value: 5,
    label: "Giám đốc văn phòng",
  },
  {
    value: 6,
    label: "Phó tổng giám đốc",
  },
  {
    value: 7,
    label: "Giám đốc chi nhánh",
  },
  {
    value: 8,
    label: "Nhân viên Content Marketing",
  },
  {
    value: 9,
    label: "Giám đốc chi nhánh",
  },
  {
    value: 10,
    label: "Kế toán tổng hợp",
  },
];

// Loại đối tượng
export const employeeTypes = [
  {
    value: 0,
    label: "Nhân viên",
  },
  {
    value: 1,
    label: "Vãng lai",
  },
];

// Loại giấy tờ
export const identifyTypes = [
  {
    value: 0,
    label: "CMND",
  },
  {
    value: 1,
    label: "CCCD",
  },
  {
    value: 2,
    label: "Hộ chiếu",
  },
];

// Loại hợp đồng
export const contractTypes = [
  {
    value: 0,
    label: "Không cư trú",
  },
  {
    value: 2,
    label: "Cư trú và không đăng ký HĐLĐ/HĐLĐ dưới 3 tháng",
  },
  {
    value: 1,
    label: "Cư trú và có HĐLD từ 3 tháng trở lên",
  },
];

// Trạng thái làm việc
export const workStatuses = [
  {
    value: 1,
    label: "Đang làm việc",
  },
  {
    value: 0,
    label: "Đã nghỉ việc",
  },
];

/**
 * Description: Tìm thông tin quốc gia
 * Author: txphuc (23/08/2023)
 */
export const getRelationship = (code) => {
  return relationships.find((co) => co.value == code);
};

/**
 * Description: Tìm thông tin quốc gia
 * Author: txphuc (23/08/2023)
 */
export const getCountry = (code) => {
  return countries.find((co) => co.value == code);
};

/**
 * Description: Tìm thông tin tỉnh/thành phố
 * Author: txphuc (23/08/2023)
 */
export const getProvince = (code) => {
  return provinces.find((pr) => pr.value == code);
};

/**
 * Description: Tìm thông tin quận/huyện
 * Author: txphuc (23/08/2023)
 */
export const getDistrict = (code) => {
  return districts.find((di) => di.value == code);
};

/**
 * Description: Tìm thông tin xã/phường
 * Author: txphuc (23/08/2023)
 */
export const getWard = (code) => {
  return wards.find((wa) => wa.value == code);
};

/**
 * Description: Tìm thông tin phòng ban
 * Author: txphuc (23/08/2023)
 */
export const getDepartment = (code) => {
  return departments.find((de) => de.value == code);
};

/**
 * Description: Tìm thông tin phòng ban
 * Author: txphuc (23/08/2023)
 */
export const getPosition = (code) => {
  return positions.find((po) => po.value == code);
};
