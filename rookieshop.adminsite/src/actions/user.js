import api from '../api/api'
import * as types from "../contains/user";
import history from '../history';
import { success, error as err } from "../notify/index";
export const login = (value) => async (dispatch) => {
    try { 
        const data = await api.User.login(value)
        localStorage.setItem("__token", 'Bearer' + ` ${data.access_token}`);
        dispatch({
            type: types.LOGIN,
            payload:"",      
        });
        history.push("/");
    } catch (error) {
        err(error);
    }
};
export const logout = () => async (dispatch) => {
    try { 
        localStorage.removeItem("__token");
        dispatch({
            type: types.LOGOUT,
            payload:"",      
        });
        history.push("/login");
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

