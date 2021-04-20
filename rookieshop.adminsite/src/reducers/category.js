import * as category from "../contains/category";

const initialState = {
    categoryList: [],
}

export default (state = initialState, { type, payload }) => {
    switch (type) {
        case category.CATEGORY_LIST: {
           
            state.categoryList = payload;
            return { ...state };

        }
   
        default:
            return state;
    }
}