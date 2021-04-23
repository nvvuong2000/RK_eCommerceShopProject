import api from '../api/api'
import {PRODUCT_LIST,PRODUCT_SELECTED,UPDATE_PRODUCT,ADD_PRODUCT} from "../contains/product";
import { success, error as err } from "../notify/index";
import history from '../history';
export const get_product_list = () => async (dispatch) => {
    try {
        const data = await api.Product.getAllProducts();

        dispatch({
            type: PRODUCT_LIST,
            payload: data,
        });

    } catch (error) {
        err(error);
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
        err(error);
    }
};
export const add_product = (product) => async (dispatch) => {
    try {
        const data = await api.Product.addProduct(product)

        dispatch({
            type: ADD_PRODUCT,
            payload: data,
        });
        success("Add product successfully");
        history.push("/products");

    } catch (error) {
        err(error);
    }
};
export const update_product = (product) => async (dispatch) => {
    try {

        const data = await api.Product.updateProduct(product)

        dispatch({
            type: UPDATE_PRODUCT,
            payload: data,
        });
        success("Edited product successfully");
        history.push("/products");


    } catch (error) {
        err(error);
    }
};


