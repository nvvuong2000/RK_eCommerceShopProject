import * as user from "../contains/user";

const initialState = {
    currentUser: {},
    listUsers:[],
};

export default (state = initialState, { type, payload }) => {
    switch (type) {
        case user.LOGIN: {   
            state.currentUser = payload;
            return { ...state};
        }
        case user.LOGOUT: {
            return {
                ...state,
                currentUser: {},
            };
        }
        case user.GETCURRENTUSER: {       
            return {

                currentUser: payload,
            };
        }
        case user.GETLISTUSER: {
            state.listUsers = payload;
            return { ...state };     
        }
        default:
            return state;
    }
}