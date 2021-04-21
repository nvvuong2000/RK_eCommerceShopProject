import React, { Fragment } from 'react'
import {Link} from "react-router-dom"

export default function OrderItem(props) {
    const list = props.list;
    return (
       <Fragment>
           {
                list && list.map(item=>{
                    return (
                        <tr role="row" className="odd">
                            <td className="table-column-pr-0">
                            </td>
                            <td><Link to={`/order/${item.id}`}>#{item.id}</Link></td>
                            <td className="table-column-pl-0">
                                <div className="media-body">
                                    <h5 className="text-hover-primary mb-0">{item.date}</h5>
                                </div>
                            </td>
                            <td>{item.userName}</td>
                            <td>{item.status == 2 ? "Received" : item.status == 1 ? "Delivery" : item.status == -1 ? "Canceled" : "Processing"}</td>
                            <td>{item.total}</td>
                            
                               <td>
                                {(item.status != 2)?
                                    <select id="datatableEntries" class="js-select2-custom" >
                                        <option name="status" value="1">Delivery</option>
                                        <option name="status" value="0">Processing</option>
                                        <option name="status" value="2">Received</option>
                                        <option name="status" value="-1">Cancel</option>                                       
                                    </select>
                                    : ""
                                }           
                                </td>
                        </tr>
                    );
                })
           }
            
       </Fragment>
    )
}
