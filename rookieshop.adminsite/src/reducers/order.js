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
            console.log(payload);

            state.orderDetails = payload;
           
            return { ...state };

        }
        case order.GETALLORDERLIST: {

            
            return { ...state, orderList : payload };

        }
        case order.UPDATESTATUSORDER: {

            const index = state.orderList.findIndex((x) => x.id === payload.orderId);
            
            state.orderList[index].status = parseInt(payload.statusId);
            
            return {
                ...state,
            };

        }
        default:
            return state;
    }
}