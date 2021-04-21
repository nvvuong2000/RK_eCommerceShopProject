import React, { Fragment,useEffect } from 'react'
import { useSelector, useDispatch, } from "react-redux";
import {Link} from "react-router-dom";
import { get_list_order } from "../actions/order"
import OrderItem from './OrderItem';

export default function Orders() {

    const dispatch = useDispatch();

    useEffect(() => {

        dispatch(get_list_order())
    }, [])

    const orderList = useSelector((state) => state.order.orderList.data);
    return (
        <Fragment>
            <div className="content container-fluid">
                <div className="page-header">
                    <div className="row align-items-center mb-3">
                        <div className="col-sm mb-2 mb-sm-0">
                            <h1 className="page-header-title">Orders <span className="badge badge-soft-dark ml-2" /></h1>
                        </div>
                    </div>
                </div>
                <div className="card">
                    <div className="table-responsive datatable-custom">
                        <div id="datatable_wrapper" className="dataTables_wrapper no-footer">
                           <table id="datatable" className="table table-borderless table-thead-bordered table-nowrap table-align-middle card-table dataTable no-footer">
                                <thead className="thead-light">
                                    <tr role="row">
                                        <th scope="col" className="table-column-pr-0 sorting_disabled" rowSpan={1} colSpan={1} style={{ width: 25 }}></th>
                                        <th className="table-column-pl-0 sorting" tabIndex={0} aria-controls="datatable" rowSpan={1} colSpan={1} aria-label="Order: activate to sort column ascending" style={{ width: 69 }}>Order</th>
                                        <th className="sorting" tabIndex={0} aria-controls="datatable" rowSpan={1} colSpan={1} style={{ width: 155 }}>Date</th>
                                        <th className="sorting" tabIndex={0} aria-controls="datatable" rowSpan={1} colSpan={1}  style={{ width: 129 }}>Customer</th>
                                        <th className="sorting" tabIndex={0} aria-controls="datatable" rowSpan={1} colSpan={1} style={{ width: 123 }}>Payment status</th>
                                        <th className="sorting" tabIndex={0} aria-controls="datatable" rowSpan={1} colSpan={1}  style={{ width: 64 }}>Total</th>
                                        <th className="sorting" tabIndex={0} aria-controls="datatable" rowSpan={1} colSpan={1}  style={{ width: 104 }}> Actions </th>
                                    </tr>
                                </thead>
                                <tbody>
                                    <OrderItem list={orderList}/>
                                </tbody>
                            </table>
                        </div>
                    </div>
                </div>
            </div>

        </Fragment>
    )
}
