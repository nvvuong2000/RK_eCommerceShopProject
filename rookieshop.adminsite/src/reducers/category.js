import * as category from "../contains/category";

const initialState = {
    categoryList: [],
    newCategory:{},
    categoryselected:{}
}

export default (state = initialState, { type, payload }) => {
    switch (type) {
        case category.CATEGORY_LIST: {
           
            state.categoryList = payload;
            return { ...state };

        }
   
        case category.ADD_CATEGORY: {
            state.newCategory = payload;
            return { ...state };

        }
        case category.CATEGORY_SELECTED: {
            state.categoryselected = payload;
            return { ...state };

        }
   
        default:
            return state;
    }
}