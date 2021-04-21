import * as order from "../contains/order";

const initialState = {
    orderlistofcustomer:[]
};

export default (state = initialState, { type, payload }) => {
    switch (type) {
        case order.ORDERLISTOFCUS: {

            state.orderlistofcustomer = payload;
            return { ...state };

        }
        default:
            return state;
    }
}