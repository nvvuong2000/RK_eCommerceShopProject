import api from '../api/api'
import * as types from "../contains/user";
import {history} from "../index"
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
        console.log(error);
    }
};
export const get_info_user = () => async (dispatch) => {
    try {
        const data = await api.User.get_info_user()
        dispatch({
            type: types.GET_CURRENT_USER,
            payload: data,
        });
       
    } catch (error) {
        console.log(error);;
    }
};

