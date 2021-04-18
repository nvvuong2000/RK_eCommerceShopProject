import * as product from "../contains/product";

const initialState = {
    productList: [],
};

export default (state = initialState, { type, payload }) => {
    switch (type) {
        case product.PRODUCT_LIST: {
            
            state.productList=payload;
             return { ...state };
            
        }
        default:
            return state;
    }
}