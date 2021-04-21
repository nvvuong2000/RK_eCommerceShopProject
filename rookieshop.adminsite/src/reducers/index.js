import { combineReducers } from "redux";
import user from "./user"
import product from "./product"
import category from "./category"
import order from "./order"
const rootReducer =combineReducers({
    user,product,category,order
});
export default rootReducer;