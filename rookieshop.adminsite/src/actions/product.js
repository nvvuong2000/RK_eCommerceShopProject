import api from '../api/user'
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


