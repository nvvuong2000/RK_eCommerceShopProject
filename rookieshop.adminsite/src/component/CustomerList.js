import React from 'react'
import { Link } from "react-router-dom";
export default function CustomerList(props) {
    const { list } = props;
    console.log(list);
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
                                        <td><Link to={`/user/${item.userId }}`} >#{i+1}</Link> </td>
                                        <td className="table-column-pl-0">
                                            <a className="media align-items-center" href="ecommerce-product-details.html">
                                                <img className="avatar avatar-lg mr-3" src={item.avatar == null ? "https://localhost:44341/images/default-user.jpg":`${item.avatar}`} alt="Avatar" />
                                                <div className="media-body">
                                                    <Link to={`/user/${1}`} className="text-hover-primary mb-0">{item.userName}</Link>
                                                </div>
                                            </a>
                                        </td>
                                        <td>{item.userEmail}</td>
                                        <td>{item.userPhone}</td>
                                        <td>{item.countOrder}</td>
                                        <td>{item.totalOrder}</td>
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
