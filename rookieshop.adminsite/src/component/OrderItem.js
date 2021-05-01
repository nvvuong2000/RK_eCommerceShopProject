import React, { Fragment, useEffect, useState } from 'react'
import { useSelector, useDispatch, } from "react-redux";
import { Link } from "react-router-dom"
import moment from 'moment';
import {update_status_order} from "../actions/order"

export default function OrderItem(props) {
    

    const dispatch = useDispatch();
    
    useEffect(() =>{},[props.list]);
 
    const list  = props.list;
    
    const handleChange = (value,id) => {
        let data =
        {
            "orderId": id,
          
            "statusId": value
        }

        dispatch(update_status_order(data))
    }
 
    return (
        <Fragment>
            {
                list && list.map(item => {
                    return (
                        <tr role="row" className="odd" key={item.id}>
                            <td className="table-column-pr-0">
                            </td>
                            <td><Link to={`/order/${item.id}`}>#{item.id}</Link></td>
                            <td className="table-column-pl-0">
                                <div className="media-body">
                                    <p className="text-hover-primary mb-0">{moment(item.date).format("MM-DD-YYYY HH:mm:ss")}</p>
                                </div>
                            </td>
                            <td>{item.userName}</td>
                            <td>{item.status == 2 ? "Received" : item.status == 1 ? "Delivery" : item.status == -1 ? "Canceled" : "Processing"}</td>
                            <td>{item.total}</td>

                            <td>
                                {(item.status == 0) ?
                                    <select className="js-select2-custom" id={item.id} onChange={(e)=>handleChange(e.target.value,item.id)} key={item.id} >
                                        <option name="status" value="1">Delivery</option>
                                        <option name="status" value="0" selected >Processing</option>
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
