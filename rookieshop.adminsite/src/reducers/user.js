import * as user from "../contains/user";

const initialState = {
    currentUser: {},
    listUsers:[],
};

export default (state = initialState, { type, payload }) => {
    switch (type) {
        case user.LOGIN: {
      
            return {

                currentUser: payload,
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