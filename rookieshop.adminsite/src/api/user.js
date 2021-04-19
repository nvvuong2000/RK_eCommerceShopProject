import axios from "axios";
axios.defaults.baseURL = "https://localhost:44341";



const config = {
    headers: { Authorization: localStorage.getItem("__token") }
};

const User = {
    login: async (data) => {

        var url = "https://localhost:44341/connect/token";
        var urlencoded = new URLSearchParams();
        urlencoded.append("grant_type", "password");
        urlencoded.append("username", data.email);
        urlencoded.append("password", data.password);
        urlencoded.append("client_id", "react");
        urlencoded.append("client_secret", "secret");
        return await axios.post(url, urlencoded).then(r => { return r.data });
    },
    get_info_user: async () => {
        var url = "https://localhost:44341/api/User/infoUser";
        return await axios.get(url, config).then(r => { return r.data });
    }
}
const Product = {
    getAllProducts: async () => await axios.get("/api/Product", config),
    getProductbyId: async (id) => await axios.get(`/api/Product/${id}`)
}
const Category = {
    getAllCategory: async () => await axios.get("/api/Category", config),
  
}

export default { User, Product, Category };