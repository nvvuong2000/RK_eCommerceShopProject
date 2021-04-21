import React, { Fragment } from 'react'
import OrderList from "./OrderList"
export default function CustomerListOrder(props) {
    const list = props.list
    console.log(list)
    return (
        <Fragment>

            <div className="col-lg-8">
                {/* Card */}
                <div className="card mb-3 mb-lg-5">
                    {/* Header */}
                    <div className="card-header">
                        <h5 className="card-header-title">Order List</h5>
                    </div>
                    {/* End Header */}
                    {/* Table */}
                    <div className="table-responsive">
                        <table className="table table-borderless table-thead-bordered table-nowrap table-align-middle card-table">
                            <thead className="thead-light">
                                <tr>
                                    <th>Order</th>
                                    <th style={{ width: '40%' }}>Status</th>
                                    <th className="table-column-right-aligned">Total</th>
                                </tr>
                            </thead>
                            <tbody>
                                {list && list.map(item=>{
                                    return(
                                        <OrderList order={item} />
                                    )
                                })}
                              
                            </tbody>
                        </table>
                    </div>
                    {/* End Table */}
                </div>
                {/* End Card */}
            </div>

        </Fragment>
    )
}
