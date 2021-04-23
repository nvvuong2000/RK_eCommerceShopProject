import { PROVIDER_LIST}  from "../contains/provider";

const initialState = {
    providerList: [],
}

export default (state = initialState, { type, payload }) => {
    switch (type) {
        case PROVIDER_LIST: {
            state.providerList = payload;
            return { ...state };

        }
        default:
            return state;
    }
}