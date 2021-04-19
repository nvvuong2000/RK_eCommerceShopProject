import api from '../api/user'
import * as category from "../contains/category";
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



