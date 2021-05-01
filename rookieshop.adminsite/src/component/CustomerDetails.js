import React, { Fragment, useEffect } from 'react'
import { useSelector, useDispatch, } from "react-redux";
import CustomerInfor from "./CustomerInfo"
import CustomerListOrder from "./CustomerListOrder"
import { get_list_order_of_customer } from "../actions/order"
export default function CustomerDetails({ match }) {

    const { id } = match.params;

    const dispatch = useDispatch();
   
    useEffect(() => {

        dispatch(get_list_order_of_customer(id))
    }, [])

    const orderList = useSelector((state) => state.order.orderlistofcustomer)

    let data = orderList;


    return (
        <div>
            <main id="content" role="main" className="main">
                <div className="content container-fluid">
                    <div className="row justify-content-lg-center">
                        <div className="col-lg-10">
                            <div className="row">

                                <CustomerInfor info={data}/> 

                                <CustomerListOrder list={data} />

                            </div>
                        </div>
                    </div>
                </div>
            </main>
        </div>
    )
}
