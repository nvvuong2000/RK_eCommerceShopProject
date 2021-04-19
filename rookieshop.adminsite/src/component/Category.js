import React, { Fragment, useEffect } from 'react'
import { useSelector, useDispatch, } from "react-redux";
import { Link } from "react-router-dom";
import { get_category_list } from "../actions/category"
import CategoryList from './CategoryList';
import ProductList from './ProductList';
export default function Product() {
    const dispatch = useDispatch();
    useEffect(() => {

        dispatch(get_category_list())
    }, [])
    const getCategoryList = useSelector((state) => state.category.categoryList)
    let categoryList = getCategoryList.data;
    return (
        <div>
            {/* Content */}
            <div className="content container-fluid">
                {/* Page Header */}
                <div className="page-header">
                    <div className="row align-items-center mb-3">
                        <div className="col-sm mb-2 mb-sm-0">
                            <h1 className="page-header-title">Category <span className="badge badge-soft-dark ml-2" /></h1>
                        </div>
                        <div className="col-sm-auto">
                            <Link to={`/category/addCategory`} className="btn btn-primary" href="ecommerce-add-product.html">Add Category</Link>

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
                                <a className="nav-link active" href="#">All Category</a>
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
                    </div>
                    {/* End Header */}
                    {/* Table */}
                    <div className="table-responsive datatable-custom">
                        <div id="datatable_wrapper" className="dataTables_wrapper no-footer">
                            <CategoryList list={categoryList} />
                        </div>
                    </div>
                    {/* End Table */}
                  
                </div>
                {/* End Card */}
            </div>
            {/* End Content */}
       
        </div>
    )
}
