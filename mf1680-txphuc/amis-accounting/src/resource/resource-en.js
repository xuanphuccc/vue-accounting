const resourceEn = {
  Language: "English",
  LanguageCode: "en-US",
  Product: "Accounting",
  FullProductName: "AMIS Accounting",
  Company: "MISA Joint Stock Company",
  UserName: "Tran Xuan Phuc",

  ErrorMessage: {
    1000: "Invalid data input",
    1001: "Resource not found",
    1002: "The code <@code> already exists in the system, please check again.",
    1003: "System error, please try again later",
    1004: "Constraint error",
  },

  Sidebar: {
    Dashboard: "Dashboard",
    Employee: "Employee",
    Department: "Department",
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
    SaveS: "Save",
    SaveAndContinue: "Save and continue",
    Cancel: "Cancel",
    OK: "OK",
    Yes: "Yes",
    No: "No",
    UnChecked: "Uncheck",
    Delete: "Delete",
    Update: "Edit",
    RestoreDefault: "Restore default",
  },

  Table: {
    Functions: "Functions",
    CustomTableTitle: "Customize columns",
  },

  ContextMenu: {
    Duplicate: "Duplicate",
    Delete: "Delete",
    StopUsing: "Stop using",
    ExportAllToExcel: "Export all",
    ExportListToExcel: "Export selected records",
    ImportFromExcel: "Import from Excel",
    DownloadSampleFile: "Download sample",
  },

  Combobox: {
    PlaceHolder: "Select a value",
  },

  PlaceHolder: {
    SelectAValue: "Select a value",
    Search: "Search",
  },

  Paging: {
    TotalRecords: "Total",
    ItemsPerPage: "Records/Page",
    Records: "Records",
    NextPage: "Next page",
    PrevPage: "Previous page",
  },

  Dialog: {
    ErrorTitle: "Error",
    WarningTitle: "Warning",
    CloseFormWarning: "The data has been modified. Do you want to save?",
  },

  Popup: {
    Close: "Close (ESC)",
  },

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
    ExportExcel: "Export to Excel",
    Setting: "Customize columns",
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
        CreateTitle: "Add employee",
        UpdateTitle: "Edit employee",
        DuplicateTitle: "Duplicate employee",
      },
      Toast: {
        CreateSuccess: "Successfully added employee",
        UpdateSuccess: "Successfully updated employee",
        DeleteSuccess: "Successfully deleted employee",
        DuplicateSuccess: "Successfully duplicated employee",
      },
      Dialog: {
        DeleteConfirmTitle: "Delete employee",
        DeleteConfirmDesc: (name) =>
          `Delete employee "${name}". The employee cannot be recovered after deletion`,
        MultipleDeleteConfirmDesc: (count) =>
          `Delete ${count} employees. Employees cannot be recovered after deletion`,
      },
      Validate: {
        EmployeeCode: "Code is required",
        FullName: "Name is required",
        Department: "Department is required",
        CodeFormat: "Code format is NV-1000 +",
        EmailFormat: "Email invalidate",
        MobilePhoneFormat: "Mobile phone invalidate",
        MaxLength: "Max @char characters",
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
        Title: "Date of birth",
        Desc: "Date of birth",
      },
      Gender: {
        Title: "Gender",
        Desc: "Gender",
      },
      IdentityNumber: {
        Title: "ID number",
        Desc: "Identity card number",
      },
      IdentityDate: {
        Title: "Issue date",
        Desc: "Issue date",
      },
      IdentityPlace: {
        Title: "Issue place",
        Desc: "Issue place",
      },
      IsCustomer: {
        Title: "Customer",
        Desc: "Customer",
      },
      IsSupplier: {
        Title: "Supplier",
        Desc: "Supplier",
      },
      Address: {
        Title: "Address",
        Desc: "Address",
      },
      MobilePhone: {
        Title: "Mobile phone",
        Desc: "Mobile phone",
      },
      LandlinePhone: {
        Title: "Landline phone",
        Desc: "Landline phone",
      },
      Email: {
        Title: "Email",
        Desc: "Email",
      },
      BankAccount: {
        Title: "Bank account",
        SubTitle: "Account number",
        Desc: "Bank account",
      },
      BankName: {
        Title: "Bank name",
        Desc: "Bank name",
      },
      BankBranch: {
        Title: "Bank branch",
        SubTitle: "Bank branch",
        Desc: "Bank branch",
      },
    },

    Department: {
      Title: "Department",
      AddButton: "Add new department",
      SearchPlaceholder: "Search by code or name",
      Form: {
        CreateTitle: "Add department",
        UpdateTitle: "Edit department",
        DuplicateTitle: "Duplicate department",
      },
      Toast: {
        CreateSuccess: "Successfully added department",
        UpdateSuccess: "Successfully updated department",
        DeleteSuccess: "Successfully deleted department",
        DuplicateSuccess: "Successfully duplicated department",
      },
      Dialog: {
        DeleteConfirmTitle: "Delete department",
        DeleteConfirmDesc: "Are you sure you want to delete department @code?",
        MultipleDeleteConfirmDesc: "Are you sure you want to delete the selected department?",
      },

      DepartmentCode: {
        Title: "Department code",
        SubTitle: "Department code",
        Desc: "Department code",
      },
      DepartmentName: {
        Title: "Department name",
        SubTitle: "Department name",
        Desc: "Department name",
      },
      Description: {
        Title: "Description",
        SubTitle: "Description",
        Desc: "Description",
      },
    },
  },
};

export default resourceEn;
