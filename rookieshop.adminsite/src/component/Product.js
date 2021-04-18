import React, { Fragment, useEffect } from 'react'
import { useSelector, useDispatch, } from "react-redux";
import { Link } from "react-router-dom";
import { get_product_list } from "../actions/product"
import ProductList from './ProductList';
export default function Product() {
    let disptach = useDispatch();
    useEffect(() => {
        disptach(get_product_list());
    }, []);
    const { productList } = useSelector((state) => state.product);
    // const prod = useSelector((state) =>console.log(state));
    var list_product = productList.data;
    console.log(list_product)
    return (
        <div>
            {/* Content */}
            <div className="content container-fluid">
                {/* Page Header */}
                <div className="page-header">
                    <div className="row align-items-center mb-3">
                        <div className="col-sm mb-2 mb-sm-0">
                            <h1 className="page-header-title">Products <span className="badge badge-soft-dark ml-2" /></h1>
                        </div>
                        <div className="col-sm-auto">
                            <Link to={`/product/addProduct`} className="btn btn-primary" href="ecommerce-add-product.html">Add product</Link>

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
                                <a className="nav-link active" href="#">All products</a>
                            </li>

                        </ul>
                        {/* End Nav */}
                    </div>
                    {/* End Nav Scroller */}
                </div>
                {/* End Page Header */}
                <div className="row justify-content-end mb-3">
                    <div className="col-lg">

                    </div>
                </div>
                {/* End Row */}
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

                                        {/* Example split danger button */}

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
                            <div id="datatable_filter" className="dataTables_filter">
                                <label>Search:<input type="search" className placeholder aria-controls="datatable" /></label>

                                <select id="datatableEntries" class="js-select2-custom" >
                                    <option name="status" value="1">Đang chuẩn bị hàng</option>
                                    <option name="status" value="2" selected="">Đang vận chuyển</option>
                                    <option name="status" value="-1" disabled="">Hủy</option>

                                </select>
                            </div>
                            <ProductList list={list_product} />
                            <div className="dataTables_info" id="datatable_info" role="status" aria-live="polite">Showing 1 to 12 of
          20 entries</div>
                        </div>
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
            {/* End Content */}

        </div>
    )
}
