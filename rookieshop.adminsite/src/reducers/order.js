import * as order from "../contains/order";

const initialState = {
    orderlistofcustomer:[],
    orderDetails:[],
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
        default:
            return state;
    }
}