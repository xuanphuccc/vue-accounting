const enums = {
  form: {
    mode: {
      CREATE: 0,
      UPDATE: 1,
      DUPLICATE: 2,
    },
  },
  dialog: {
    type: {
      INFO: "info",
      WARNING: "warning",
      ERROR: "error",
    },
  },
  sort: {
    DESC: "desc",
    ASC: "asc",
  },
  filter: {
    EQUAL: "equal",
    NOTEQUAL: "notequal",
    CONTAIN: "contain",
    NOTCONTAIN: "notcontain",
    SMALLER: "smaller",
    GREATER: "greater",
  },
  type: {
    GENDER: "Gender",
    DATE: "Date",
  },
  gender: {
    MALE: 0,
    FEMALE: 1,
    OTHER: 2,
  },
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
  import: {
    step: {
      UPLOAD: 1,
      MAP: 2,
      VALIDATE: 3,
      RESULT: 4,
    },
  },
  language: {
    VN: "vi-VN",
    EN: "en-US",
  },
};

export default enums;
