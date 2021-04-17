import React, { Fragment } from 'react'
import {
  
    Link
} from "react-router-dom";

export default function Orders() {
    return (
        <Fragment>
            {/* Content */}
            <div className="content container-fluid">
                {/* Page Header */}
                <div className="page-header">
                    <div className="row align-items-center mb-3">
                        <div className="col-sm mb-2 mb-sm-0">
                            <h1 className="page-header-title">Orders <span className="badge badge-soft-dark ml-2" /></h1>
                        </div>
                    </div>
                    {/* End Row */}
                    {/* Nav Scroller */}
                    <div className="js-nav-scroller hs-nav-scroller-horizontal">
                        <span className="hs-nav-scroller-arrow-prev" style={{ display: 'none' }}>
                            <a className="hs-nav-scroller-arrow-link" href="javascript:;">
                                <i className="tio-chevron-left" />
                            </a>
                        </span>
                        <span className="hs-nav-scroller-arrow-next" style={{ display: 'none' }}>
                            <a className="hs-nav-scroller-arrow-link" href="javascript:;">
                                <i className="tio-chevron-right" />
                            </a>
                        </span>
                        {/* Nav */}
                        <ul className="nav nav-tabs page-header-tabs" id="pageHeaderTab" role="tablist">
                            <li className="nav-item">
                                <a className="nav-link active" href="#">All Orders</a>
                            </li>
                        </ul>
                        {/* End Nav */}
                    </div>
                    {/* End Nav Scroller */}
                </div>
                {/* End Page Header */}
               
                {/* Card */}
                <div className="card">
                    {/* Header */}
                    <div className="card-header">
                        <div className="row justify-content-between align-items-center flex-grow-1">
                            <div className="col-md-4 mb-3 mb-md-0">
                                <form>
                                    {/* Search */}
                                    <div className="input-group input-group-merge input-group-flush">
                                        <div className="input-group-prepend">
                                            <div className="input-group-text">
                                                <i className="fas fa-search" />
                                            </div>
                                        </div>
                                        <input id="datatableSearch" type="search" className="form-control" placeholder="Search product" aria-label="Search users" />
                                    </div>
                                    {/* End Search */}
                                </form>
                            </div>
                            <div className="col-auto">
                                {/* Unfold */}
                                <div className="hs-unfold">
                                    <div id="showHideDropdown" className="hs-unfold-content dropdown-unfold dropdown-menu dropdown-menu-right dropdown-card hs-unfold-hidden hs-unfold-content-initialized hs-unfold-css-animation animated" style={{ width: '15rem', animationDuration: '300ms' }} data-hs-target-height="352.4" data-hs-unfold-content data-hs-unfold-content-animation-in="slideInUp" data-hs-unfold-content-animation-out="fadeOut">
                                        <div className="card card-sm">
                                            <div className="card-body">
                                                <div className="d-flex justify-content-between align-items-center mb-3">
                                                    <span className="mr-2">Product</span>
                                                    {/* Checkbox Switch */}
                                                    <label className="toggle-switch toggle-switch-sm" htmlFor="toggleColumn_product">
                                                        <input type="checkbox" className="toggle-switch-input" id="toggleColumn_product" defaultChecked />
                                                        <span className="toggle-switch-label">
                                                            <span className="toggle-switch-indicator" />
                                                        </span>
                                                    </label>
                                                    {/* End Checkbox Switch */}
                                                </div>
                                                <div className="d-flex justify-content-between align-items-center mb-3">
                                                    <span className="mr-2">Type</span>
                                                    {/* Checkbox Switch */}
                                                    <label className="toggle-switch toggle-switch-sm" htmlFor="toggleColumn_type">
                                                        <input type="checkbox" className="toggle-switch-input" id="toggleColumn_type" defaultChecked />
                                                        <span className="toggle-switch-label">
                                                            <span className="toggle-switch-indicator" />
                                                        </span>
                                                    </label>
                                                    {/* End Checkbox Switch */}
                                                </div>
                                                <div className="d-flex justify-content-between align-items-center mb-3">
                                                    <span className="mr-2">Vendor</span>
                                                    {/* Checkbox Switch */}
                                                    <label className="toggle-switch toggle-switch-sm" htmlFor="toggleColumn_vendor">
                                                        <input type="checkbox" className="toggle-switch-input" id="toggleColumn_vendor" />
                                                        <span className="toggle-switch-label">
                                                            <span className="toggle-switch-indicator" />
                                                        </span>
                                                    </label>
                                                    {/* End Checkbox Switch */}
                                                </div>
                                                <div className="d-flex justify-content-between align-items-center mb-3">
                                                    <span className="mr-2">Stocks</span>
                                                    {/* Checkbox Switch */}
                                                    <label className="toggle-switch toggle-switch-sm" htmlFor="toggleColumn_stocks">
                                                        <input type="checkbox" className="toggle-switch-input" id="toggleColumn_stocks" defaultChecked />
                                                        <span className="toggle-switch-label">
                                                            <span className="toggle-switch-indicator" />
                                                        </span>
                                                    </label>
                                                    {/* End Checkbox Switch */}
                                                </div>
                                                <div className="d-flex justify-content-between align-items-center mb-3">
                                                    <span className="mr-2">SKU</span>
                                                    {/* Checkbox Switch */}
                                                    <label className="toggle-switch toggle-switch-sm" htmlFor="toggleColumn_sku">
                                                        <input type="checkbox" className="toggle-switch-input" id="toggleColumn_sku" defaultChecked />
                                                        <span className="toggle-switch-label">
                                                            <span className="toggle-switch-indicator" />
                                                        </span>
                                                    </label>
                                                    {/* End Checkbox Switch */}
                                                </div>
                                                <div className="d-flex justify-content-between align-items-center mb-3">
                                                    <span className="mr-2">Price</span>
                                                    {/* Checkbox Switch */}
                                                    <label className="toggle-switch toggle-switch-sm" htmlFor="toggleColumn_price">
                                                        <input type="checkbox" className="toggle-switch-input" id="toggleColumn_price" defaultChecked />
                                                        <span className="toggle-switch-label">
                                                            <span className="toggle-switch-indicator" />
                                                        </span>
                                                    </label>
                                                    {/* End Checkbox Switch */}
                                                </div>
                                                <div className="d-flex justify-content-between align-items-center mb-3">
                                                    <span className="mr-2">Quantity</span>
                                                    {/* Checkbox Switch */}
                                                    <label className="toggle-switch toggle-switch-sm" htmlFor="toggleColumn_quantity">
                                                        <input type="checkbox" className="toggle-switch-input" id="toggleColumn_quantity" />
                                                        <span className="toggle-switch-label">
                                                            <span className="toggle-switch-indicator" />
                                                        </span>
                                                    </label>
                                                    {/* End Checkbox Switch */}
                                                </div>
                                                <div className="d-flex justify-content-between align-items-center">
                                                    <span className="mr-2">Variants</span>
                                                    {/* Checkbox Switch */}
                                                    <label className="toggle-switch toggle-switch-sm" htmlFor="toggleColumn_variants">
                                                        <input type="checkbox" className="toggle-switch-input" id="toggleColumn_variants" defaultChecked />
                                                        <span className="toggle-switch-label">
                                                            <span className="toggle-switch-indicator" />
                                                        </span>
                                                    </label>
                                                    {/* End Checkbox Switch */}
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                {/* End Unfold */}
                            </div>
                        </div>
                        {/* End Row */}
                    </div>
                    {/* End Header */}
                    {/* Table */}
                    <div className="table-responsive datatable-custom">
                        <div id="datatable_wrapper" className="dataTables_wrapper no-footer">

                            <table id="datatable" className="table table-borderless table-thead-bordered table-nowrap table-align-middle card-table dataTable no-footer">
                                <thead className="thead-light">
                                    <tr role="row">
                                        <th scope="col" className="table-column-pr-0 sorting_disabled" rowSpan={1} colSpan={1} style={{ width: 25 }}>
                                        </th>
                                        <th className="table-column-pl-0 sorting" tabIndex={0} aria-controls="datatable" rowSpan={1} colSpan={1} aria-label="Order: activate to sort column ascending" style={{ width: 69 }}>Order</th>
                                        <th className="sorting" tabIndex={0} aria-controls="datatable" rowSpan={1} colSpan={1} aria-label="Date: activate to sort column ascending" style={{ width: 155 }}>Date</th>
                                        <th className="sorting" tabIndex={0} aria-controls="datatable" rowSpan={1} colSpan={1} aria-label="Customer: activate to sort column ascending" style={{ width: 129 }}>
                                            Customer</th>
                                        <th className="sorting" tabIndex={0} aria-controls="datatable" rowSpan={1} colSpan={1} aria-label="Payment status: activate to sort column ascending" style={{ width: 123 }}>
                                            Payment status</th>
                                        <th className="sorting" tabIndex={0} aria-controls="datatable" rowSpan={1} colSpan={1} aria-label="Total: activate to sort column ascending" style={{ width: 64 }}>Total
              </th>
                                        <th className="sorting" tabIndex={0} aria-controls="datatable" rowSpan={1} colSpan={1} aria-label="Actions: activate to sort column ascending" style={{ width: 104 }}>
                                            Actions
              </th>
                                    </tr>
                                </thead>
                                <tbody>
                                    <tr role="row" className="odd">
                                        <td className="table-column-pr-0">
                                        </td>
                                        <td><Link to={`/order/${1}`}>#1</Link></td>
                                        <td className="table-column-pl-0">
                                            <a className="media align-items-center" href="ecommerce-product-details.html">
                                                <div className="media-body">
                                                    <h5 className="text-hover-primary mb-0">4/17/2021</h5>
                                                </div>
                                            </a>
                                        </td>
                                        <td>vuong Nguyen</td>
                                        <td>Đã nhận</td>
                                        <td>20000 VND</td>
                                        <td>

                                            {/* Example single danger button */}


                                            <select id="datatableEntries" class="js-select2-custom" >
                                                <option name="status" value="1">Đang chuẩn bị hàng</option>
                                                <option name="status" value="2" selected="">Đang vận chuyển</option>
                                                <option name="status" value="-1" disabled="">Hủy</option>
                                               
                                            </select>


                                            {/* End Unfold */}

                                        </td>
                                    </tr>
                                </tbody>
                            </table>
                        </div>
                        {/* End Table */}
                        {/* Footer */}
                        <div className="card-footer">
                            {/* Pagination */}
                            <div className="row justify-content-center justify-content-sm-between align-items-sm-center">
                                <div className="col-sm mb-2 mb-sm-0">
                                </div>
                                <div className="col-sm-auto">
                                    <div className="d-flex justify-content-center justify-content-sm-end">
                                        {/* Pagination */}
                                        <nav id="datatablePagination" aria-label="Activity pagination">
                                            <div className="dataTables_paginate paging_simple_numbers" id="datatable_paginate">
                                                <ul id="datatable_pagination" className="pagination datatable-custom-pagination">
                                                    <li className="paginate_item page-item disabled"><a className="paginate_button previous page-link" aria-controls="datatable" data-dt-idx={0} tabIndex={0} id="datatable_previous"><span aria-hidden="true">Prev</span></a></li>
                                                    <li className="paginate_item page-item active"><a className="paginate_button page-link" aria-controls="datatable" data-dt-idx={1} tabIndex={0}>1</a></li>
                                                    <li className="paginate_item page-item"><a className="paginate_button page-link" aria-controls="datatable" data-dt-idx={2} tabIndex={0}>2</a></li>
                                                    <li className="paginate_item page-item"><a className="paginate_button next page-link" aria-controls="datatable" data-dt-idx={3} tabIndex={0} id="datatable_next"><span aria-hidden="true">Next</span></a></li>
                                                </ul>
                                            </div>
                                        </nav>
                                    </div>
                                </div>
                            </div>
                            {/* End Pagination */}
                        </div>
                        {/* End Footer */}
                    </div>
                    {/* End Card */}
                </div>
                {/* End Content */}</div>

        </Fragment>
    )
}
