import api from '../api/api'
import * as product from "../contains/product";
export const get_product_list = () => async (dispatch) => {
    try {
        const data = await api.Product.getAllProducts();
        console.log(data);
       
        dispatch({
            type: product.PRODUCT_LIST,
            payload: data,
        });
   
    } catch (error) {
        console.log(error);
    }
};
export const get_product_by_id = (id) => async (dispatch) => {
    console.log(id);
    try {
        const data = await api.Product.getProductbyId(id)
        console.log(data);
       
        dispatch({
            type: product.EDIT_PRODUCT,
            payload: data,
        });
   
    } catch (error) {
        console.log(error);
    }
};


