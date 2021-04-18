import {Account} from '../api/index'
import * as types from "../contains/user";
import {history} from "../index"

import {
    BrowserRouter as Router,
    Switch,
    Route,
    Link
} from "react-router-dom";

export const login = (value) => async (dispatch) => {
    try { 
        const data = await Account.login(value);
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
        const data = await Account.get_info_user();
        dispatch({
            type: types.GET_CURRENT_USER,
            payload: data,
        });
       
    } catch (error) {
        console.log(error);;
    }
};

