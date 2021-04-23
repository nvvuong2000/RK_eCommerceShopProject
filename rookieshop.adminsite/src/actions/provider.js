import api from '../api/api'
import { PROVIDER_LIST} from "../contains/provider";
import { success, error as err } from "../notify/index";

export const get_provider_list = () => async (dispatch) => {
    try {
        const data = await api.Provider.getListProvider();
        dispatch({
            type: PROVIDER_LIST ,
            payload: data,
        });

    } catch (error) {
        err(error);
    }
};