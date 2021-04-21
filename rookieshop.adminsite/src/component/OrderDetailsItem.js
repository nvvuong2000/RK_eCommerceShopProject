import React, { Fragment } from 'react'
import { Link } from "react-router-dom"
export default function OrderDetailsItem(props) {
    const orders = props.list;
    console.log(orders);
    return (
        <Fragment>
            <div>
                <table id="datatable" className="table table-borderless table-thead-bordered table-nowrap table-align-middle card-table dataTable no-footer">
                    <thead className="thead-light">
                        <tr role="row">
                            <th scope="col" className="table-column-pr-0 sorting_disabled" rowSpan={1} colSpan={1} style={{ width: 41 }}>
                            </th>
                            <th className="sorting" tabIndex={0} aria-controls="datatable" rowSpan={1} colSpan={1} style={{ width: 121 }}>SKU</th>
                            <th className="table-column-pl-0 sorting" tabIndex={0} aria-controls="datatable" rowSpan={1} colSpan={1} aria-label="Product: activate to sort column ascending" style={{ width: 331 }}>Product</th>
                            <th className="sorting" tabIndex={0} aria-controls="datatable" rowSpan={1} colSpan={1} aria-label="Price: activate to sort column ascending" style={{ width: 83 }}>Price</th>
                            <th className="sorting" tabIndex={0} aria-controls="datatable" rowSpan={1} colSpan={1} aria-label="Variants: activate to sort column ascending" style={{ width: 118 }}>Quantity</th>
                            <th className="sorting_disabled" rowSpan={1} colSpan={1} aria-label="Stocks" style={{ width: 46 }}>Subtotal</th>
                        </tr>
                    </thead>
                    <tbody>
                        {orders && orders.map(order => {
                            return (
                                <tr role="row" className="odd">
                                    <td className="table-column-pr-0">
                                    </td>
                                    <td>#{order.productId}</td>
                                    <td className="table-column-pl-0">
                                        <Link className="media align-items-center" to={`/product/${order.productId}`}>
                                            <img className="avatar avatar-lg mr-3" src={`https://localhost:44341`+order.productImage} alt="Image Description" />
                                            <div className="media-body">
                                                <Link to={`/product/${order.productId}`} className="text-hover-primary mb-0">{order.productName}</Link>
                                            </div>
                                        </Link>
                                    </td>
                                    <td>{order.productQuantity}</td>
                                    <td>{order.productunitPrice}</td>
                                    <td>{order.productQuantity * order.productunitPrice}</td>
                                </tr>
                            );
                        })}
                    </tbody>
                </table>
            </div>
        </Fragment>
    )
}
