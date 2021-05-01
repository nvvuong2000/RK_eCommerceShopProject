import * as product from "../contains/product";


const initialState = {
    productList: [],
    product_selected: {}
};

export default (state = initialState, { type, payload }) => {
    switch (type) {
        case product.PRODUCT_LIST: {

            state.productList = payload;
            return { ...state };

        }
        case product.PRODUCT_SELECTED: {
            state.product_selected = payload;
            return { ...state };

        }
        case product.ADD_PRODUCT: {

            return { ...state };

        }
        case product.UPDATE_PRODUCT: {

            return { ...state };

        }
        default:
            return state;
    }
}