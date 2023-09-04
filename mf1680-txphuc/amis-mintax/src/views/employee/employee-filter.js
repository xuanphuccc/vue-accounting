import i18n from "@/i18n";

export const employeeFilterGroups = [
  {
    key: 1,
    name: i18n.t("employee.advancedFilter.workStatus"),
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
            label: i18n.t("employee.workStatus.currentlyEmployed"),
          },
          {
            value: 0,
            label: i18n.t("employee.workStatus.formerlyEmployed"),
          },
        ],
      },
    ],
  },
  {
    key: 2,
    name: i18n.t("employee.advancedFilter.employeeType"),
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
            label: i18n.t("employee.employeeType.employee"),
          },
          {
            value: 1,
            label: i18n.t("employee.employeeType.client"),
          },
        ],
      },
    ],
  },
  {
    key: 3,
    name: i18n.t("employee.advancedFilter.taxCode"),
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
            label: i18n.t("employee.advancedFilter.haveTaxCode"),
          },
          {
            value: "false",
            label: i18n.t("employee.advancedFilter.noTaxCode"),
          },
        ],
      },
    ],
  },
  {
    key: 4,
    name: i18n.t("employee.advancedFilter.time"),
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
            label: i18n.t("employee.employeeDetail.hireDate"),
          },
          {
            value: "ReceiveDate",
            label: i18n.t("employee.employeeDetail.receiveDate"),
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
