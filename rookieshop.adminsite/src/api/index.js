import axios from "axios";
axios.defaults.baseURL = "https://localhost:44341";

// axios.interceptors.request.use(
//     (config) => {
//         const token = window.localStorage.getItem("x-auth");
//         if (token) config.headers.Authorization = `Bearer ${token}`;
//         return config;
//     },
//     (error) => {
//         console.log(error);

//         return Promise.reject(error);
//     }
// );
const responseBody = (response) => response.data;

const errorBody = (res) => {
    throw res.response.data;
};

const request = {
    post: async (url, body) =>
        await axios.post(url, body).then(responseBody).catch(errorBody),
};
const config = {
    headers: { Authorization: localStorage.getItem("__token") }
};

   const login= async(data)=>{
       console.log(data);

       
         var url = "https://localhost:44341/connect/token";

        var urlencoded = new URLSearchParams();
        urlencoded.append("grant_type", "password");
        urlencoded.append("username", data.email);
        urlencoded.append("password", data.password);
        urlencoded.append("client_id", "react");
        urlencoded.append("client_secret", "secret");
        return await axios.post(url, urlencoded).then(r=> { return r.data});
    }
    const get_info_user=async()=>{
        var url = "https://localhost:44341/api/User/infoUser";
        return await axios.get(url,config).then(r=>{return r.data});
    }

export const Account={login,get_info_user};