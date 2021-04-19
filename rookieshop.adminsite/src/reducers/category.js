import * as category from "../contains/category";

const initialState = {
    categoryList: [],
    newCategory:{}
}

export default (state = initialState, { type, payload }) => {
    switch (type) {
        case category.CATEGORY_LIST: {
           
            state.categoryList = payload;
            return { ...state };

        }
   
        case category.ADD_CATEGORY: {
            
            console.log(payload)
           
            state.categoryList = payload;
            return { ...state };

        }
   
        default:
            return state;
    }
}