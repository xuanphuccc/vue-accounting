const resourceEn = {
  product: "MinTax",
  fullProductName: "Personal Income Tax",
  company: "MISA Joint Stock Company",

  validate: {
    required: "field is required",
    inValidate: "invalid format",
  },

  sidebar: {
    registerTaxId: "Register tax ID",
    registerDependents: "Register dependents",
    taxReportingByPeriod: "Tax reporting by period",
    taxDeductionReceipts: "Tax deduction receipts",
    taxFinalization: "Tax finalization",
    procedure: "Procedures",
    report: "Reports",
    taxpayer: "Taxpayer",
    taxServiceRegistration: "Tax service segistration",
    configuration: "Configuration",
    trashBin: "Trash bin",

    collapse: "Collapse",
  },

  userMenu: {
    userFullName: "Tran Xuan Phuc",
    changePassword: "Change password",
    accountSettings: "Account setting",
    securitySettings: "Security setting",
    referralsEarnPoints: "Referral - Loyalty",
    language: "Language",
    signOut: "Logout",
  },

  gender: {
    male: "Male",
    female: "Female",
    other: "Other",
  },

  button: {
    addNew: "Add new",
    add: "Add",
    save: "Save",
    dontSave: "Don't save",
    saveAndAddNew: "Save & Add new",
    apply: "Apply",
    ok: "OK",
    removeFilter: "Remove filter",
    delete: "Delete",
    cancel: "Cancel",
    edit: "Edit",
    openInNewWindow: "Open in a new window",
    unChecked: "Uncheck",
    restoreDefault: "Restore default",
    exportExcel: "Export to Excel",
    using: "Using",
    stopUsing: "Stop using",
    yes: "Yes",
    no: "No",
  },

  placeholder: {
    selectAValue: "Select a value",
    search: "Search",
    enterValue: "Enter a value",
    select: "Select",
    input: "Enter",
    selectOrInput: "Select/enter",
  },

  paging: {
    totalRecords: "Total",
    itemsPerPage: "Records per page",
    records: "records",
    nextPage: "Next page",
    prevPage: "Previous page",
  },

  dialog: {
    errorTitle: "An error occurred",
    warningTitle: "Warning",
    infoTitle: "Information",
    deleteTitle: "Delete data",
    closeFormWarningTitle: "Data has been modified",
    closeFormWarningDesc: "Do you want to save the changes?",
  },

  tooltip: {
    notification: "Notification",
    help: "Help",
    otherFeatures: "Other features",
    account: "Account",
    close: "Close",
    setting: "Column settings",
    back: "Back",
  },

  text: {
    selected: "Selected",
  },

  // Document Types
  identifyType: {
    nationalIdentityCard: "National ID card",
    citizenCard: "Citizen card",
    passport: "Passport",
  },

  // Contract Types
  contractType: {
    nonResident: "Non-resident",
    residenceWithContract: "Resident with employment Contract (3 months and above)",
    residenceWithoutContract: "Resident without Employment Contract (less than 3 months)",
  },

  customizeColumn: {
    title: "Customize columns",
    search: "Search",
  },

  filterPopup: {
    title: "Filter",
    startDate: "Start date",
    endDate: "End date",
  },

  employee: {
    toast: {
      addSuccess: "Successfully created taxpayer",
      updateSuccess: "Successfully updated taxpayer",
      deleteSuccess: "Successfully deleted taxpayer",

      addFamilySuccess: "Successfully created family information for the taxpayer",
      updateFamilySuccess: "Successfully updated family information for the taxpayer",
      deleteFamilySuccess: "Successfully deleted family information",
    },

    dialog: {
      deleteEmployeeTitle: "Delete Taxpayer",
      deleteEmployeeDesc:
        "Are you sure you want to delete taxpayer <b>{employee}</b> to the Trash Bin?",
      deleteMultipleEmployeeDesc:
        "Are you sure you want to delete <b>({quantity})</b> taxpayers to the Trash Bin?",
      deleteFamilyDesc: "Are you sure you want to delete this family information from the list?",
    },

    advancedFilter: {
      workStatus: "Employee status",
      employeeType: "Employee type",
      taxCode: "Tax Identification number",
      haveTaxCode: "Have tax ID",
      noTaxCode: "No tax ID",
      time: "Time",
    },

    // Loại đối tượng
    employeeType: {
      employee: "Employee",
      client: "Client",
    },

    // Trạng thái làm việc
    workStatus: {
      formerlyEmployed: "Formerly employed",
      currentlyEmployed: "Currently employed",
    },

    // Trạng thái sử dụng
    usageStatus: {
      using: "Currently in use",
      stopUsing: "Discontinued usage",
    },

    filterBar: {
      search: "Search by Employee code/Name, Tax ID, ID card",
      department: "Department",
      filter: "Filter",
      customizeColumns: "Customize columns",
      usageStatus: "Usage status",
    },

    text: {
      hideDepartmentSelect: "Show organizational structure as inactive",
    },

    employeeList: {
      title: "Taxpayer profiles",
      button: {
        syncAmisSystem: "Sync AMIS system",
        manageEmployeeUsingService: "Manage employees using service",
        createDeclaration: "Create declaration",
        createProcedure: "Create procedure",
      },
    },

    employeeDetail: {
      createFormTitle: "Add Taxpayer",
      updateFormTitle: "Edit Taxpayer",
      viewTitle: "Taxpayer profile",

      button: {
        getInfo: "Get information",
      },

      mainInfoTitle: "Main information",
      jobInfoTitle: "Job information",
      familyInfoTitle: "Family information",
      familyInfoEmpty: "No family information available",

      personalInfoSubTitle: "Personal information",
      permanentResidenceSubTitle: "Permanent residence",
      currentAccommodationSubTitle: "Current accommodation",

      employeeType: "Employee type",
      employeeCode: "Employee code",
      employeeCodeColumn: "Employee code",
      fullName: "Full name",
      fullNameColumn: "Full name",
      dateOfBirth: "Date of birth",
      gender: "Gender",
      mobile: "Phone number",
      email: "Email",
      taxCode: "Tax Identification number",
      identifyType: "Identification type",
      identifyNumber: "{identifyType}",
      identifyNumberColumn: "ID number/Citizen number/Passport",
      identifyDate: "Issued date",
      identifyIssuedPlace: "Issued place",
      national: "Nationality",
      contractType: "Contract type",
      country: "Country",
      province: "Province",
      district: "District",
      ward: "Ward",
      streetNumber: "Address line",
      address: "Address",
      isCopyAddress: "Similar to permanent residence",
      department: "Department",
      departmentColumn: "Department",
      jobPosition: "Job position",
      jobPositionColumn: "Job position",
      jobTitle: "Job title",
      employeeStatus: "Employee status",
      probationDate: "Internship date",
      hireDate: "Probation date",
      receiveDate: "Receive date",
      terminationDate: "Termination date",
      usageStatus: "Usage status",
    },

    employeeFamilyDetail: {
      createFormTitle: "Add family member",
      updateFormTitle: "Edit family member",

      birthInformationTitle: "Birth information",
      permanentResidenceTitle: "Permanent residence",
      currentAccommodationTitle: "Current accommodation",
      deductionInformation: "Deduction information",

      button: {
        getInfo: "Get information",
      },

      fullName: "Full name",
      fullNameColumn: "Full name",
      relationship: "Relationship",
      dateOfBirth: "Date of birth",
      gender: "Gender",
      taxCode: "Tax identification number",
      nationality: "Nationality",
      identifyType: "Identification type",
      identifyNumber: "{identifyType}",
      identifyIssuedDate: "Date of issue",
      identifyIssuedPlace: "Place of issue",
      dependentNumber: "Dependent number",
      numberBook: "Book number",
      birthCertificationIssueDate: "Date of birth certification issue",
      country: "Country",
      province: "Province",
      district: "District",
      ward: "Ward",
      streetNumber: "Address line",
      isDependent: "Is dependent",
      deductionStartDate: "Deduction start month",
      deductionStartDateColumn: "Deduction start",
      deductionEndDate: "Deduction end month",
      deductionEndDateColumn: "Deduction end",
      description: "Description",
    },

    employeeManagerList: {
      title: "Employee management using the service",

      totalEmployees: "Total employees",
      totalEmployeesDesc: "All taxpayers with object types Employee and Client on AMIS MinTax",

      currentlyUsingService: "Currently using the service",
      currentlyUsingServiceDesc:
        "Taxpayers with object types Employee and Client who have set up the use of MinTax service",

      notUsingService: "Not using the service",
      notUsingServiceDesc:
        "Taxpayers with object types Employee and Client who have not set up the use of MinTax service",

      button: {
        configureAutomaticRules: "Configure automatic rules",
      },
    },
  },
};

export default resourceEn;
