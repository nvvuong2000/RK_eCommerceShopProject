import { combineReducers } from "redux";
import user from "./user"
import product from "./product"
import category from "./category"
import order from "./order"
import provider from "./provider"
const rootReducer =combineReducers({
    user,product,category,order,provider
});
export default rootReducer;