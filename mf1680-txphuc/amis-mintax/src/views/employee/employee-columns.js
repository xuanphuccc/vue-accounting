import enums from "@/enum/enum";
import { formatDate } from "devextreme/localization";
import { getPosition } from "@/api/mock-data";

const employeeColumns = [
  {
    dataField: "EmployeeCode",
    caption: "Mã nhân viên",
    dataType: "number",
    alignment: "left",
    fixed: true,
    width: 150,
    visible: true,
  },
  {
    dataField: "FullName",
    caption: "Tên nhân viên",
    dataType: "string",
    alignment: "left",
    fixed: true,
    width: 150,
    visible: true,
  },
  {
    dataField: "DateOfBirth",
    caption: "Ngày sinh",
    dataType: "date",
    customizeText: (e) => formatDate(new Date(e.value), "dd/MM/yyyy"),
    alignment: "center",
    width: 180,
    visible: true,
  },
  {
    dataField: "Gender",
    caption: "Giới tính",
    dataType: "string",
    alignment: "left",
    customizeText: (e) =>
      e.value === enums.gender.male ? "Nam" : e.value === enums.gender.female ? "Nữ" : "Khác",
    width: 180,
    visible: true,
  },
  {
    dataField: "TaxCode",
    caption: "Mã số thuế",
    dataType: "string",
    alignment: "left",
    width: 180,
    visible: true,
  },
  {
    dataField: "EmployeeType",
    caption: "Loại đối tượng",
    dataType: "string",
    customizeText: (e) => (e.value == enums.employeeType.employee ? "Nhân viên" : "Vãng lai"),
    alignment: "left",
    width: 180,
    visible: true,
  },
  {
    dataField: "JobPositionId",
    caption: "Vị trí/Chức vụ",
    customizeText: (e) => getPosition(e.value)?.label,
    dataType: "string",
    alignment: "left",
    width: 180,
    visible: true,
  },

  {
    dataField: "OrganizationUnitId",
    caption: "Bộ phận/Phòng ban",
    dataType: "string",
    alignment: "left",
    width: 180,
    visible: true,
  },

  {
    dataField: "ContractMintaxType",
    caption: "Loại hợp đồng",
    dataType: "string",
    customizeText: (e) =>
      e.value == enums.contractType.nonResident
        ? "Không cư trú"
        : e.value == enums.contractType.residenceWithContract
        ? "Cư trú và có HĐLD từ 3 tháng trở lên"
        : "Cư trú và không đăng ký HĐLĐ/HĐLĐ dưới 3 tháng",
    alignment: "left",
    width: 180,
    visible: true,
  },

  {
    dataField: "ProbationDate",
    caption: "Ngày học việc",
    dataType: "string",
    customizeText: (e) => formatDate(new Date(e.value), "dd/MM/yyyy"),
    alignment: "left",
    width: 180,
    visible: true,
  },
  {
    dataField: "HireDate",
    caption: "Ngày thử việc",
    dataType: "string",
    customizeText: (e) => formatDate(new Date(e.value), "dd/MM/yyyy"),
    alignment: "left",
    width: 180,
    visible: true,
  },

  {
    dataField: "ReceiveDate",
    caption: "Ngày chính thức",
    dataType: "date",
    customizeText: (e) => formatDate(new Date(e.value), "dd/MM/yyyy"),
    alignment: "left",
    width: 180,
    visible: true,
  },
  {
    dataField: "TerminationDate",
    caption: "Ngày nghỉ việc",
    dataType: "date",
    customizeText: (e) => formatDate(new Date(e.value), "dd/MM/yyyy"),
    alignment: "left",
    width: 180,
    visible: true,
  },
  {
    dataField: "Email",
    caption: "Email",
    dataType: "string",
    alignment: "left",
    width: 280,
    visible: true,
  },
  {
    dataField: "IdentifyNumber",
    caption: "Số CMND/CCCD/Hộ chiếu",
    dataType: "string",
    alignment: "left",
    width: 220,
    visible: true,
  },
  {
    dataField: "EmployeeStatus",
    caption: "Trạng thái làm việc",
    dataType: "string",
    customizeText: (e) =>
      e.value == enums.workStatus.currentlyEmployed ? "Đang làm việc" : "Đã nghỉ việc",
    alignment: "left",
    width: 180,
    visible: true,
  },
];

export default employeeColumns;
