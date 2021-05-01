import api from '../api/api'
import * as types from "../contains/order";
import { success, error as err } from "../notify/index";
export const get_list_order_of_customer = (id) => async (dispatch) => {
    try {
        const data = await api.Order.getListOrderofCustomer(id);
        dispatch({
            type: types.ORDERLISTOFCUS,
            payload: data,
        });

    } catch (error) {
        err(error);;
    }
};
export const get_list_order_details = (id) => async (dispatch) => {
    try {
        const data = await api.Order.getListOrderDetails(id);
        dispatch({
            type: types.ORDERDETAILS,
            payload: data,
        });

    } catch (error) {
        err(error);
    }
};
export const get_list_order = () => async (dispatch) => {
    try {
        const data = await api.Order.getOrderList();
    
        dispatch({
            type: types.GETALLORDERLIST,
            payload: data,
        });

    } catch (error) {
        err(error);
    }
};
export const update_status_order = (value) => async (dispatch) => {
    try {
        const data = await api.Order.updateStatusOrder(value);
        
        dispatch({
            type: types.UPDATESTATUSORDER,
            payload: value,
        });
        success("Updated order successfully");

    } catch (error) {
        err(error);
    }
};
