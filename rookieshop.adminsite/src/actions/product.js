import api from '../api/api'
import {PRODUCT_LIST,PRODUCT_SELECTED,UPDATE_PRODUCT,ADD_PRODUCT} from "../contains/product";
export const get_product_list = () => async (dispatch) => {
    try {
        const data = await api.Product.getAllProducts();

        dispatch({
            type: PRODUCT_LIST,
            payload: data,
        });

    } catch (error) {
        console.log(error);
    }
};
export const get_product_by_id = (id) => async (dispatch) => {
    try {
        const data = await api.Product.getProductbyId(id)

        dispatch({
            type: PRODUCT_SELECTED,
            payload: data,
        });

    } catch (error) {
        console.log(error);
    }
};
export const add_product = (product) => async (dispatch) => {
    try {
        const data = await api.Product.addProduct(product)

        dispatch({
            type: ADD_PRODUCT,
            payload: data,
        });

    } catch (error) {
        console.log(error);
    }
};
export const update_product = (product) => async (dispatch) => {
    try {

        const data = await api.Product.updateProduct(product)

        dispatch({
            type: UPDATE_PRODUCT,
            payload: data,
        });

    } catch (error) {
        console.log(error);
    }
};


