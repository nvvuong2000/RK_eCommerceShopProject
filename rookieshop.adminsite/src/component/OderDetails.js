import React, { useEffect } from 'react'
import { useSelector, useDispatch, } from "react-redux";
import { get_list_order_details } from "../actions/order"
import OrderDetailsItem from './OrderDetailsItem';
import moment from 'moment';
export default function OderDetails({ match }) {

  const dispatch = useDispatch();

  const orderList = useSelector((state) => state.order.orderDetails);


  let data = orderList.data;


  const { id } = match.params;

  useEffect(() => {

    dispatch(get_list_order_details(id))
  }, [])

  useEffect(() => {

  }, [data]);


  const getList = (data) => {
   
    var list = [];
   
    if (data) {
     
      for (var i = 0; i < data.productName.length; i++) {
      
        list.push({ productName: data.productName[i], productQuantity: data.quantity[i], productunitPrice: data.unitPrice[i], productImage: data.imageDefault[i], productId: data.productID[i] })
      }
     
      return list;
    }
  }

  const list = getList(data);
  
  return (
    <div>
      {data && <div className="content container-fluid">
        <div className="page-header d-print-none">
          <div className="row align-items-center">
            <div className="col-sm mb-2 mb-sm-0">
              <nav aria-label="breadcrumb">
                <ol className="breadcrumb breadcrumb-no-gutter">
                  <li className="breadcrumb-item"><a className="breadcrumb-link" href="#">Orders</a></li>
                  <li className="breadcrumb-item active" aria-current="page">Order details</li>
                </ol>
              </nav>
              <div className="d-sm-flex align-items-sm-center">
                <h1 className="page-header-title">Order #{data.id}</h1>
                <span className="badge badge-soft-success ml-sm-3">
                  <span className="legend-indicator bg-success" />
                </span>{data.status == 2 ? "Received" : data.status == 1 ? "Delivery" : data.status == -1 ? "Canceled" : "Processing"}

                <span className="ml-2 ml-sm-3">
                  <i className="fas fa-clock"></i> {moment(data.date).format("MM-DD-YYYY HH:mm:ss")}
                </span>
              </div>
              <div className="mt-2">
              </div>
            </div>
          </div>
        </div>
        <div className="row">
          <div className="col-lg-12 mb-3 mb-lg-0  ">
            <div className="card mb-3 mb-lg-5">
              <div className="card-header">
                <h4 className="card-header-title">Order details</h4>
              </div>

              <OrderDetailsItem list={list} />

              <hr />
              <div className="row justify-content-md-end mb-3">
                <div className="col-md-8 col-lg-7">
                  <div className="row text-sm-right">
                    <dt className="col-sm-10">Amount paid:<span className="ml-4">{Number((data.total).toFixed(1)).toLocaleString()}</span></dt>

                  </div>
                </div>
              </div>
            </div>
          </div>
        </div>
      </div>
      }
    </div>
  )
}
