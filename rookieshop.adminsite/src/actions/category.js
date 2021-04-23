import api from '../api/api'
import * as category from "../contains/category";
import { success, error as err } from "../notify/index";
import history from '../history';
export const get_category_list = () => async (dispatch) => {
    try {
        const data = await api.Category.getAllCategory();
        console.log(data);

        dispatch({
            type: category.CATEGORY_LIST,
            payload: data,
        });

    } catch (error) {
        err(error);
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
        success("Add category successfully");
        history.push("/category");

    } catch (error) {
        err(error);
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
        err(error);
    }
};
export const update_category = (value) => async (dispatch) => {
    try {
        const data = await api.Category.updateCategory(value);
        console.log(data);

        dispatch({
            type: category.UPDATE_CATEGORY,
            payload: value,
        });
        success("Edited category successfully");
        history.push("/category");

    } catch (error) {
        err(error);
    }
};



