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
export const add_category = (value) => async (dispatch) => {
    try {
        const data = await api.Category.addNewCategory(value)
        console.log(data);

        dispatch({
            type: category.ADD_CATEGORY,
            payload: data,
        });
        history.push("/category");

    } catch (error) {
        console.log(error);
    }
};
export const get_Category_by_Id = (id) => async (dispatch) => {
    try {
        const data = await api.Category.getCategorybyID(id);
        console.log(data);

        dispatch({
            type: category.CATEGORY_SELECTED,
            payload: data,
        });

    } catch (error) {
        console.log(error);
    }
};



