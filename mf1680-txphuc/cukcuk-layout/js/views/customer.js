let allCustomers = [];
let selectedCustomers = [];

/**
 * Author: txphuc (20/06/2023)
 * Description: Get customers data
 */
async function getData() {
    try {
        const response = await fetch("https://cukcuk.manhnv.net/api/v1/Customers");
        const customers = await response.json();

        allCustomers = customers;

        renderData();
    } catch (error) {
        console.warn(error);
    }
}
getData();

/**
 * Author: txphuc (20/06/2023)
 * Description: Render data UI
 */
function renderData() {
    try {
        const custommersTable = document.querySelector(".ms-table__table tbody");
        const selectInforBlock = document.querySelector(".filter__select-infor");
        const selectedCount = document.querySelector("#selected-count");
        const searchBlock = document.querySelector("#table-search");

        if (selectedCustomers.length > 0) {
            selectInforBlock.style.display = "flex";
            searchBlock.style.display = "none";
        } else {
            selectInforBlock.style.display = "none";
            searchBlock.style.display = "flex";
        }

        selectedCount.textContent = selectedCustomers.length;

        const customersHtml = allCustomers
            .map(
                (customer) =>
                    `
                <tr>
                    <td>
                        <input
                            onclick='selectCustomer(${JSON.stringify(customer)})'
                            type="checkbox"
                            name="select-customer"
                            id=""
                            ${
                                selectedCustomers.find(
                                    (ctm) => ctm.CustomerId === customer.CustomerId
                                )
                                    ? "checked"
                                    : ""
                            }
                        />
                    </td>
                    <td>
                        <div class="d-flex align-center">
                            <img
                                src="../../assets/img/avatar-default.png"
                                alt="Image"
                            />
                            ${customer.FullName}
                        </div>
                    </td>
                    <td>${
                        customer.Gender === 0
                            ? "Khác"
                            : customer.Gender === 1
                            ? "Nữ"
                            : "Nam"
                    }</td>
                    <td class="text-align--center">${formatDate(
                        customer.DateOfBirth
                    )}</td>
                    <td>${customer.Email}</td>
                    <td class="text-align--end">${customer.PhoneNumber}</td>
                    <td>${customer.CompanyName}</td>
                    <td class="text-align--end">${convertCurrency(
                        customer.DebitAmount
                    )}</td>
                </tr>
                `
            )
            .join("");

        custommersTable.innerHTML = customersHtml;
    } catch (error) {
        console.warn(error);
    }
}

/**
 * Author: txphuc (20/06/2023)
 * Description: Handle select all input change
 */
function handleToggleSelectAllCustomers(e) {
    try {
        if (e.target.checked) {
            selectAllCustomers();
        } else {
            removeAllSelectedCustomer();
        }
    } catch (error) {
        console.warn(error);
    }
}

/**
 * Author: txphuc (20/06/2023)
 * Description: Select all customers
 */
function selectAllCustomers() {
    try {
        selectedCustomers = [...allCustomers];

        renderData();
    } catch (error) {
        console.warn(error);
    }
}

/**
 * Author: txphuc (20/06/2023)
 * Description: Remove all selected customers
 */
function removeAllSelectedCustomer() {
    try {
        var inputSelectAll = document.querySelector("#select-all-rows");
        inputSelectAll.checked = false;

        selectedCustomers = [];

        renderData();
    } catch (error) {
        console.warn(error);
    }
}

/**
 * Author: txphuc (20/06/2023)
 * Description: Select customer
 */
function selectCustomer(customer) {
    try {
        if (selectedCustomers.find((ctm) => ctm.CustomerId === customer.CustomerId)) {
            selectedCustomers = selectedCustomers.filter(
                (ctm) => ctm.CustomerId != customer.CustomerId
            );
        } else {
            selectedCustomers.push(customer);
        }

        renderData();
    } catch (error) {
        console.warn(error);
    }
}

/**
 * Author: txphuc (20/06/2023)
 * Description: Generate in format: DD/MM/YYYY
 */
function formatDate(dateString) {
    try {
        dateString = new Date(dateString);

        const date = dateString.getDate();
        const month = dateString.getMonth() + 1;
        const year = dateString.getFullYear();

        return `${date < 10 ? "0" + date : date}/${
            month < 10 ? "0" + month : month
        }/${year}`;
    } catch (error) {
        return "";
    }
}

/**
 * Author: txphuc (20/06/2023)
 * Description: Convert currency
 */
function convertCurrency(currency) {
    try {
        let currencyString = currency.toLocaleString("vi-VN", {
            style: "currency",
            currency: "VND",
        });

        return currencyString;
    } catch (error) {
        return "";
    }
}
