export const employeeFilterGroups = [
  {
    key: 1,
    name: "Trạng thái làm việc",
    enabled: false,
    filters: [
      {
        key: "WorkStatus",
        value: 1,
        filterBy: "equal",
        type: "option",
        options: [
          {
            value: 1,
            label: "Đang làm việc",
          },
          {
            value: 0,
            label: "Đã nghỉ việc",
          },
        ],
      },
    ],
  },
  {
    key: 2,
    name: "Loại đối tượng",
    enabled: false,
    filters: [
      {
        key: "EmployeeType",
        value: 0,
        filterBy: "equal",
        type: "option",
        options: [
          {
            value: 0,
            label: "Nhân viên",
          },
          {
            value: 1,
            label: "Vãng lai",
          },
        ],
      },
    ],
  },
  {
    key: 3,
    name: "Mã số thuế",
    enabled: false,
    filters: [
      {
        key: "TaxCode",
        value: "true",
        filterBy: "equal",
        type: "option",
        options: [
          {
            value: "true",
            label: "Đã có MST",
          },
          {
            value: "false",
            label: "Chưa có MST",
          },
        ],
      },
    ],
  },
  {
    key: 4,
    name: "Thời gian",
    enabled: false,
    filters: [
      {
        key: "DateColumn",
        value: "HireDate",
        filterBy: "between",
        type: "option",
        options: [
          {
            value: "HireDate",
            label: "Ngày thử việc",
          },
          {
            value: "ReceiveDate",
            label: "Ngày chính thức",
          },
        ],
      },
      {
        key: "Date",
        start: null,
        end: null,
        filterBy: "between",
        type: "date-between",
      },
    ],
  },
];
