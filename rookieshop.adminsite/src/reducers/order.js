import * as order from "../contains/order";

const initialState = {
    orderlistofcustomer:[],
    orderDetails:[],
    orderList:[],
    statusOrder:{}
};

export default (state = initialState, { type, payload }) => {
    switch (type) {
        case order.ORDERLISTOFCUS: {

            state.orderlistofcustomer = payload;
            return { ...state };

        }
        case order.ORDERDETAILS: {

            state.orderDetails = payload;
            return { ...state };

        }
        case order.GETALLORDERLIST: {

            
            return { ...state, orderList : payload };

        }
        case order.UPDATESTATUSORDER: {
            const {orderList} = state;
            const index = state.orderList.data.findIndex((x) => x.id == payload.orderId)
            const item = orderList.data[index];
            console.log(item.status);
            item.status = parseInt(payload.statusId);
            console.log(item.status);
            orderList.data[index] = item;
            return { ...state,orderList  };

        }
        default:
            return state;
    }
}