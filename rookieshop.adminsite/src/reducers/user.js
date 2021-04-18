import * as user from "../contains/user";

const initialState = {
    currentUser: {},
};

export default (state = initialState, { type, payload }) => {
    switch (type) {
        case user.LOGIN: {
      
            return {

                currentUser: payload,
            };
        }
        case user.GET_CURRENT_USER: {
            
            return {

                currentUser: payload,
            };
        }
        default:
            return state;
    }
}