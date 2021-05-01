import React from 'react'
import { Link } from "react-router-dom"
export default function CategoryList(props) {
    return (
        <div>
            <div>
                <table id="datatable" className="table table-borderless table-thead-bordered table-nowrap table-align-middle card-table dataTable no-footer">
                    <thead className="thead-light">
                        <tr role="row">
                            <th scope="col" className="table-column-pr-0 sorting_disabled" rowSpan={1} colSpan={1} style={{ width: 41 }}>
                            </th>
                            <th className="sorting" tabIndex={0} aria-controls="datatable" rowSpan={1} colSpan={1} style={{ width: 121 }}>SKU</th>
                            <th className="table-column-pl-0 sorting" tabIndex={0} aria-controls="datatable" rowSpan={1} colSpan={1} style={{ width: 331 }}>Category Name</th>
                            <th className="sorting_disabled" rowSpan={1} colSpan={1} aria-label="Actions" style={{ width: 99 }}>Category Description </th>
                            <th></th>
                        </tr>
                    </thead>
                    <tbody>
                    {props.list && props.list.map((item,index) => {
                        return (
                            
                                <tr role="row" className="odd" key={index}>
                                    <td className="table-column-pr-0">
                                    </td>
                                    <td>#{item.id}                 
                                    </td>
                                    <td className="text-hover-primary mb-0">{item.categoryName}</td>
                                    <td>{item.categoryDescription}</td>
                                    <td>
                                        <div className="btn-group" role="group">
                                            <Link className="btn btn-sm btn-white" to={`/category/${item.id}`} ><i className="fas fa-edit" />Edit</Link>
                                        </div>
                                    </td>
                                </tr>
                            
                        );
                    })}
                    </tbody>
                </table>
            </div>
        </div>
    )
}
