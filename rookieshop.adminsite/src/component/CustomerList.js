import React from 'react'
import { Link } from "react-router-dom";
export default function CustomerList(props) {

    const { list } = props;

    return (
        <div>
            {/* Table */}
            <div className="table-responsive datatable-custom">
                <div id="datatable_wrapper" className="dataTables_wrapper no-footer">
                    <table id="datatable" className="table table-borderless table-thead-bordered table-nowrap table-align-middle card-table dataTable no-footer">
                        <thead className="thead-light">
                            <tr>
                                <th scope="col" className="table-column-pr-0">
                                </th><th />
                                <th className="table-column-pl-0">Name</th>
                                <th>E-mail</th>
                                <th>Phone</th>
                                <th>Orders</th>
                                <th>Total</th>
                            </tr>
                        </thead>
                        <tbody>
                            {list && list.map((item,i) => {
                                return (
                                    <tr role="row" className="odd">
                                        <td className="table-column-pr-0">
                                        </td>
                                        <td><Link to={`/customer/${item.userId}`} >#{i+1}</Link> </td>
                                        <td className="table-column-pl-0">
                                            <a className="media align-items-center" href="#">                                              
                                                <div className="media-body">
                                                    <Link to={`/customer/${item.userId}`} className="text-hover-primary mb-0">{item.fullName}</Link>
                                                </div>
                                            </a>
                                        </td>
                                        <td>{item.userEmail}</td>
                                        <td>{item.userPhone}</td>
                                        <td>{item.countOrder}</td>
                                        <td>{Number((item.totalOrder).toFixed(1)).toLocaleString()}</td>
                                    </tr>
                                );
                            })}

                        </tbody>
                    </table>

                </div>
            </div>
            {/* End Table */}
        </div>
    )
}
