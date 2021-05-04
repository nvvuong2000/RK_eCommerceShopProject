import React, { Fragment, useEffect } from 'react'
import { useSelector, useDispatch, } from "react-redux";
import { Link } from "react-router-dom";
import { get_product_list } from "../actions/product"
import ProductList from './ProductList';



export default function Product() {

    const disptach = useDispatch();

    const { productList } = useSelector((state) => state.product);

    useEffect(() => {
        disptach(get_product_list());
    }, []);

    var list_product = productList;

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
                            <Link to={`/product/addProduct`} className="btn btn-primary" href="#">Add product</Link>

                        </div>
                    </div>
                    {/* End Row */}
                    {/* Nav Scroller */}
                    <div className="js-nav-scroller hs-nav-scroller-horizontal">
                        <span className="hs-nav-scroller-arrow-prev" style={{ display: 'none' }}>
                            <a className="hs-nav-scroller-arrow-link" href="#">
                                <i className="tio-chevron-left" />
                            </a>
                        </span>
                        <span className="hs-nav-scroller-arrow-next" style={{ display: 'none' }}>
                            <a className="hs-nav-scroller-arrow-link" href="#">
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

                <div className="card">

                    <div className="table-responsive datatable-custom">
                        <div id="datatable_wrapper" className="dataTables_wrapper no-footer">


                            <ProductList list={list_product} />

                        </div>
                    </div>


                </div>

            </div>

        </div>
    )
}
