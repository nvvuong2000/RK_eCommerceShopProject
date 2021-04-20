import api from '../api/api'
import * as category from "../contains/category";
import { history } from "../index";
export const get_category_list = () => async (dispatch) => {
    try {
        const data = await api.Category.getAllCategory();
        console.log(data);

        dispatch({
            type: category.CATEGORY_LIST,
            payload: data,
        });

    } catch (error) {
        console.log(error);
    }
};




