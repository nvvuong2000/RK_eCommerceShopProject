import * as user from "../contains/user";

const initialState = {
    currentUser: {},
    listUsers:[],
    isLoginSuccess:false,
    isLogoutSucess:false,
};

export default (state = initialState, { type, payload }) => {
    switch (type) {
        case user.LOGIN: {   
 
            return { ...state, isLoginSuccess:true};
        }
        case user.LOGOUT: {
            return {
                ...state,
                isLoginSuccess:false,
                currentUser: {},
            };
        }
        case user.GETCURRENTUSER: {       
            return {
                ...state, currentUser:payload
               
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