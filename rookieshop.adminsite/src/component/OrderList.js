import React, { Fragment } from 'react'
import {Link } from "react-router-dom"
export default function OrderList(props) {
    const order= props.order;
    return (
        <Fragment>
            <tr>
                <td>
                    <div className="d-flex">
                        <span className="avatar avatar-xs avatar-soft-dark avatar-circle">
                            <span className="avatar-initials">V</span>
                        </span>
                        <div className="ml-3">
                            <h5 className="mb-0"><Link to={`/order/${order.id}`}>#{order.id}</Link></h5>
                            <small>{order.date}</small>
                        </div>
                    </div>
                </td>
                <td>
                    <div className="d-flex align-items-center">
                        <span className="mr-3">{order.status == 2 ? "Received" : order.status == 1 ? "Delivery" : order.status == -1 ? "Canceled" :"Processing"}</span>
                        <div className="progress table-progress">
                            <div className="progress-bar" role="progressbar" style={{ width: order.status == 2 ? "100%" : order.status == 1 ? "75%" : order.status == -1 ? "0%" : "25%" } } aria-valuenow={0} aria-valuemin={0} aria-valuemax={100}>
                            </div>
                        </div>
                    </div>
                </td>
                <td className="table-column-right-aligned">{order.total}</td>
            </tr>
        </Fragment>
    )
}
