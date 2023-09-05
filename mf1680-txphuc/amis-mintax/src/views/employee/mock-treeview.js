const mockTreeview = [
  // Công ty Cổ phần MISA
  {
    id: "PB01",
    value: 1,
    label: "Công ty Cổ phần MISA",
    expanded: true,
  },
  {
    id: "PB01-01",
    value: 2,
    label: "VP MISA Hà Nội",
    parentId: "PB01",
    expanded: true,
  },
  {
    id: "PB01-01-01",
    value: 3,
    label: "Khối NSĐH",
    parentId: "PB01-01",
  },
  {
    id: "PB01-01-02",
    value: 4,
    label: "Khối HCSN",
    parentId: "PB01-01",
  },
  {
    id: "PB01-01-03",
    value: 5,
    label: "Khối GPBL",
    parentId: "PB01-01",
  },
  {
    id: "PB01-01-04",
    value: 6,
    label: "Khối Customize",
    parentId: "PB01-01",
  },

  {
    id: "PB01-02",
    value: 7,
    label: "VP MISA Hồ Chí Minh",
    parentId: "PB01",
  },
  {
    id: "PB01-03",
    value: 8,
    label: "VP MISA Đà Nẵng",
    parentId: "PB01",
  },
  {
    id: "PB01-04",
    value: 9,
    label: "VP MISA Cần Thơ",
    parentId: "PB01",
  },
  {
    id: "PB01-05",
    value: 10,
    label: "VP MISA Buôn Ma Thuột",
    parentId: "PB01",
  },

  // Công ty Cổ phần Satellite
  {
    id: "PB02",
    value: 11,
    label: "Công ty Cổ phần Satellite",
    expanded: false,
  },
  {
    id: "PB02-01",
    value: 12,
    label: "Văn phòng Hà Nội",
    parentId: "PB02",
  },
  {
    id: "PB02-02",
    value: 13,
    label: "Văn phòng Hồ Chí Minh",
    parentId: "PB02",
  },
];

export default {
  getEmployees() {
    return mockTreeview;
  },
};
