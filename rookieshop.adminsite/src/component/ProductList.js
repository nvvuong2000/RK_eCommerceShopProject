import React, { Fragment } from 'react'
import { Link } from "react-router-dom"

export default function ProductList(props) {
    console.log(props.list)
    return (
        <div>
            <table id="datatable" className="table table-borderless table-thead-bordered table-nowrap table-align-middle card-table dataTable no-footer">
                <thead className="thead-light">
                    <tr role="row">
                        <th scope="col" className="table-column-pr-0 sorting_disabled" rowSpan={1} colSpan={1}style={{ width: 41 }}>
                        </th>
                        <th className="sorting" tabIndex={0} aria-controls="datatable" rowSpan={1} colSpan={1} style={{ width: 121 }}>SKU</th>
                        <th className="table-column-pl-0 sorting" tabIndex={0} aria-controls="datatable" rowSpan={1} colSpan={1} aria-label="Product: activate to sort column ascending" style={{ width: 331 }}>Product</th>
                        <th className="sorting" tabIndex={0} aria-controls="datatable" rowSpan={1} colSpan={1} aria-label="Type: activate to sort column ascending" style={{ width: 107 }}>Type</th>
                        <th className="sorting" tabIndex={0} aria-controls="datatable" rowSpan={1} colSpan={1} aria-label="Price: activate to sort column ascending" style={{ width: 83 }}>Price
              </th>
                        <th className="sorting" tabIndex={0} aria-controls="datatable" rowSpan={1} colSpan={1} aria-label="Variants: activate to sort column ascending" style={{ width: 118 }}>
                            Stocks</th>
                        <th className="sorting_disabled" rowSpan={1} colSpan={1} aria-label="Stocks" style={{ width: 46 }}>Status</th>
                        <th className="sorting_disabled" rowSpan={1} colSpan={1} aria-label="Actions" style={{ width: 99 }}>Actions</th>
                    </tr>
                </thead>

                {props.list && props.list.map(item => {
                    return (
                        <tbody>
                            <tr role="row" className="odd">
                                <td className="table-column-pr-0">
                                </td>
                                <td>#{item.productID}</td>
                                <td className="table-column-pl-0">
                                    <Link className="media align-items-center" to={`/product/${item.productID}`}>
                                        <img className="avatar avatar-lg mr-3" src={item.imgDefault} alt="Image Description" />
                                        <div className="media-body">
                                            <Link to={`/product/${item.productID}`} className="text-hover-primary mb-0">{item.productName}</Link>

                                        </div>
                                    </Link>
                                </td>
                                <td>{item.categoryName}</td>
                                <td>{item.unitPrice}</td>
                                <td>{item.stock}</td>
                                
                                <td>
                                    <label className="toggle-switch toggle-switch-sm" htmlFor="stocksCheckbox1">
                                        <input type="checkbox" className="toggle-switch-input" id={`status-${item.productID}`}name={`status-${item.productID}`} defaultChecked={item.status===true?"checked":""} />
                                        <span className="toggle-switch-label">
                                            <span className="toggle-switch-indicator" />
                                        </span>
                                    </label>
                                </td>
                                <td>
                                    <div className="btn-group" role="group">
                                        <a className="btn btn-sm btn-white" href="#">
                                            <i className="fas fa-edit" />
                                             <Link to={`/product/${item.productID}`} className="text-hover-primary mb-0">Edit</Link>
                  </a>

                                    </div>
                                </td>
                            </tr>

                        </tbody>
                    );
                })}
            </table>
        </div>
    )
}
