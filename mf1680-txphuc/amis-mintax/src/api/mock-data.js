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
  {
    value: "VN03",
    countryCode: "VN",
    label: "Cần Thơ",
  },
  {
    value: "VN04",
    countryCode: "VN",
    label: "Đà Nẵng",
  },
  {
    value: "VN05",
    countryCode: "VN",
    label: "Hải Phòng",
  },
  {
    value: "VN06",
    countryCode: "VN",
    label: "An Giang",
  },
  {
    value: "VN07",
    countryCode: "VN",
    label: "Bà Rịa - Vũng Tàu",
  },
  {
    value: "VN08",
    countryCode: "VN",
    label: "Bắc Giang",
  },
  {
    value: "VN09",
    countryCode: "VN",
    label: "Thái Nguyên",
  },
];

// Quận/huyện
export const districts = [
  // Các quận của Hà Nội
  {
    value: "VN0101",
    label: "Quận Ba Đình",
    provinceCode: "VN01",
    countryCode: "VN",
  },
  {
    value: "VN0102",
    label: "Quận Bắc Từ Liêm",
    provinceCode: "VN01",
    countryCode: "VN",
  },
  {
    value: "VN0103",
    label: "Quận Cầu Giấy",
    provinceCode: "VN01",
    countryCode: "VN",
  },
  {
    value: "VN0104",
    label: "Quận Đống Đa",
    provinceCode: "VN01",
    countryCode: "VN",
  },
  {
    value: "VN0105",
    label: "Quận Hà Đông",
    provinceCode: "VN01",
    countryCode: "VN",
  },
  {
    value: "VN0106",
    label: "Quận Hai Bà Trưng",
    provinceCode: "VN01",
    countryCode: "VN",
  },
  {
    value: "VN0107",
    label: "Quận Hoàn Kiếm",
    provinceCode: "VN01",
    countryCode: "VN",
  },
  {
    value: "VN0108",
    label: "Quận Hoàng Mai",
    provinceCode: "VN01",
    countryCode: "VN",
  },
  {
    value: "VN0109",
    label: "Quận Long Biên",
    provinceCode: "VN01",
    countryCode: "VN",
  },
  {
    value: "VN0110",
    label: "Quận Tây Hồ",
    provinceCode: "VN01",
    countryCode: "VN",
  },
  {
    value: "VN0111",
    label: "Quận Thanh Xuân",
    provinceCode: "VN01",
    countryCode: "VN",
  },

  // Các quận của TP Hồ Chí Minh
  {
    value: "VN0201",
    label: "Thành phố Thủ Đức",
    provinceCode: "VN02",
    countryCode: "VN",
  },
  {
    value: "VN0202",
    label: "Quận 1",
    provinceCode: "VN02",
    countryCode: "VN",
  },
  {
    value: "VN0203",
    label: "Quận 10",
    provinceCode: "VN02",
    countryCode: "VN",
  },
  {
    value: "VN0204",
    label: "Quận 11",
    provinceCode: "VN02",
    countryCode: "VN",
  },
  {
    value: "VN0203",
    label: "Quận 12",
    provinceCode: "VN02",
    countryCode: "VN",
  },
  {
    value: "VN0204",
    label: "Quận 3",
    provinceCode: "VN02",
    countryCode: "VN",
  },
  {
    value: "VN0205",
    label: "Quận 4",
    provinceCode: "VN02",
    countryCode: "VN",
  },
  {
    value: "VN0206",
    label: "Quận 5",
    provinceCode: "VN02",
    countryCode: "VN",
  },
  {
    value: "VN0207",
    label: "Quận 6",
    provinceCode: "VN02",
    countryCode: "VN",
  },
  {
    value: "VN0208",
    label: "Quận 7",
    provinceCode: "VN02",
    countryCode: "VN",
  },
  {
    value: "VN0209",
    label: "Quận 8",
    provinceCode: "VN02",
    countryCode: "VN",
  },
  {
    value: "VN0210",
    label: "Quận Bình Tân",
    provinceCode: "VN02",
    countryCode: "VN",
  },
  {
    value: "VN0211",
    label: "Quận Bình Thạnh",
    provinceCode: "VN02",
    countryCode: "VN",
  },
];

// Xã/phường
export const wards = [
  // Các phường của quận Cầu Giấy, Hà Nội
  {
    value: "VN0101001",
    label: "Phường Dịch Vọng",
    districtCode: "VN0103",
    provinceCode: "VN01",
    countryCode: "VN",
  },
  {
    value: "VN0101002",
    label: "Phường Dịch Vọng Hậu",
    districtCode: "VN0103",
    provinceCode: "VN01",
    countryCode: "VN",
  },
  {
    value: "VN0101003",
    label: "Phường Mai Dịch",
    districtCode: "VN0103",
    provinceCode: "VN01",
    countryCode: "VN",
  },
  {
    value: "VN0101004",
    label: "Phường Nghĩa Đô",
    districtCode: "VN0103",
    provinceCode: "VN01",
    countryCode: "VN",
  },
  {
    value: "VN0101005",
    label: "Phường Nghĩa Tân",
    districtCode: "VN0103",
    provinceCode: "VN01",
    countryCode: "VN",
  },
  {
    value: "VN0101006",
    label: "Phường Quan Hoa",
    districtCode: "VN0103",
    provinceCode: "VN01",
    countryCode: "VN",
  },
  {
    value: "VN0101007",
    label: "Phường Trung Hoà",
    districtCode: "VN0103",
    provinceCode: "VN01",
    countryCode: "VN",
  },
  {
    value: "VN0101008",
    label: "Phường Yên Hoà",
    districtCode: "VN0103",
    provinceCode: "VN01",
    countryCode: "VN",
  },

  // Các phường của Quận 1, Hồ Chí Minh
  {
    value: "VN0201001",
    label: "Phường Bến Nghé",
    districtCode: "VN0202",
    provinceCode: "VN02",
    countryCode: "VN",
  },
  {
    value: "VN0201002",
    label: "Phường Bến Thành",
    districtCode: "VN0202",
    provinceCode: "VN02",
    countryCode: "VN",
  },
  {
    value: "VN0201003",
    label: "Phường Cầu Kho",
    districtCode: "VN0202",
    provinceCode: "VN02",
    countryCode: "VN",
  },
  {
    value: "VN0201004",
    label: "Phường Cầu Ông Lãnh",
    districtCode: "VN0202",
    provinceCode: "VN02",
    countryCode: "VN",
  },
  {
    value: "VN0201005",
    label: "Phường Cô Giang",
    districtCode: "VN0202",
    provinceCode: "VN02",
    countryCode: "VN",
  },
  {
    value: "VN0201006",
    label: "Phường Đa Kao",
    districtCode: "VN0202",
    provinceCode: "VN02",
    countryCode: "VN",
  },
  {
    value: "VN0201007",
    label: "Phường Nguyễn Cư Trinh",
    districtCode: "VN0202",
    provinceCode: "VN02",
    countryCode: "VN",
  },
  {
    value: "VN0201008",
    label: "Phường Nguyễn Thái Bình",
    districtCode: "VN0202",
    provinceCode: "VN02",
    countryCode: "VN",
  },
  {
    value: "VN0201009",
    label: "Phường Phạm Ngũ Lão",
    districtCode: "VN0202",
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
    description: "Số Chứng minh nhân dân",
  },
  {
    value: 1,
    label: "CCCD",
    description: "Số Căn cước công dân",
  },
  {
    value: 2,
    label: "Hộ chiếu",
    description: "Số Hộ chiếu",
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

// Trạng thái làm việc
export const genders = [
  {
    value: 0,
    label: "Nam",
  },
  {
    value: 1,
    label: "Nữ",
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
 * Description: Tìm các quận/huyện của một tỉnh/TP
 * Author: txphuc (31/08/2023)
 */
export const getDistrictsOfProvince = (provinceCode) => {
  return districts.filter((pr) => pr.provinceCode == provinceCode);
};

/**
 * Description: Tìm thông tin xã/phường
 * Author: txphuc (23/08/2023)
 */
export const getWard = (code) => {
  return wards.find((wa) => wa.value == code);
};

/**
 * Description: Tìm các quận/huyện của một tỉnh/TP
 * Author: txphuc (31/08/2023)
 */
export const getWardsOfDistrict = (districtCode) => {
  return wards.filter((wa) => wa.districtCode == districtCode);
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

/**
 * Description: Tìm loại đối tượng
 * Author: txphuc (29/08/2023)
 */
export const getEmployeeType = (code) => {
  return employeeTypes.find((em) => em.value == code);
};

/**
 * Description: Tìm giới tính
 * Author: txphuc (29/08/2023)
 */
export const getGender = (code) => {
  return genders.find((em) => em.value == code);
};

/**
 * Description: Tìm loại giấy tờ
 * Author: txphuc (29/08/2023)
 */
export const getIdentifyType = (code) => {
  return identifyTypes.find((em) => em.value == code);
};

/**
 * Description: Tìm trạng thái làm việc
 * Author: txphuc (29/08/2023)
 */
export const getWorkStatus = (code) => {
  return workStatuses.find((em) => em.value == code);
};

/**
 * Description: Tìm loại hợp đồng
 * Author: txphuc (29/08/2023)
 */
export const getContractType = (code) => {
  return contractTypes.find((em) => em.value == code);
};
