import api from '../api/api'
import * as types from "../contains/user";
import {history} from "../index"
import { success, error as err } from "../notify/index";
export const login = (value) => async (dispatch) => {
    try { 
        const data = await api.User.login(value)
        localStorage.setItem("__token", 'Bearer' + ` ${data.access_token}`);
        console.log(data);
        dispatch({
            type: types.LOGIN,
            payload: data,      
        });
        history.push("/");
    } catch (error) {
        err(error);
    }
};
export const get_info_user = () => async (dispatch) => {
    try {
        const data = await api.User.get_info_user()
        dispatch({
            type: types.GETCURRENTUSER,
            payload: data,
        });
       
    } catch (error) {
        err(error);;
    }
};
export const get_list_user = () => async (dispatch) => {
    try {
        const data = await api.User.getlistuser();
        dispatch({
            type: types.GETLISTUSER,
            payload: data,
        });
       
    } catch (error) {
        err(error);;
    }
};

