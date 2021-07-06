import axios from "axios";

// axios.defaults.baseURL = "https://backend89c3e3aa12e0476482808fe47b1a625a.azurewebsites.net";
axios.defaults.baseURL = "https://localhost:44341";

const config = {
    headers: { Authorization: localStorage.getItem("__token") }
};

const User = {
    login: async (data) => {

        var url = "/connect/token";
        var urlencoded = new URLSearchParams();
        urlencoded.append("grant_type", "password");
        urlencoded.append("username", data.email);
        urlencoded.append("password", data.password);
        urlencoded.append("client_id", "react");
        urlencoded.append("client_secret", "secret");
        return await axios.post(url, urlencoded).then(r => { return r.data });
    },
    get_info_user: async () => {
        var url = "/api/User/infoUser";
        var token = localStorage.getItem("__token");
        if(token){
            axios.defaults.headers.common["Authorization"] = token;
        }
        return await axios.get(url).then(r => { return r.data });
    },
    getlistuser :async(data)=>{
        return await axios.get("/api/User/listUser", config).then(r => { return r.data });
    }
}
const Product = {
    getAllProducts: async () => await axios.get("/api/Product/ListProduct", config).then(r => { return r.data }),
    
    getProductbyId: async (id) => await axios.get(`/api/Product/${id}`).then(r => { return r.data }),
    addProduct: async (data) => await axios.post("/api/Product/addProduct", data, config).then(r => { return r.data }),
    updateProduct: async (data) => await axios.put("/api/Product/", data, config).then(r => { return r.data }),
}
const Category = {
    getAllCategory: async () => await axios.get("/api/Category", config).then(r => { return r.data }),
    addNewCategory: async (data) => await axios.post("/api/Category", data, config).then(r => { return r.data }),
    getCategorybyID: async (id) => await axios.get(`/api/Category/${id}`, config).then(r => { return r.data }),
    updateCategory: async (data) => await axios.put(`/api/Category`, data, config).then(r => { return r.data }),
  
}
const Order = {
    getListOrderofCustomer: async (id) => await axios.get(`/api/Order/listOrder/${id}`, config).then(r => { return r.data }),
    getListOrderDetails: async (id) => await axios.get(`/api/Order/${id}`, config),
    getOrderList: async (id) => await axios.get(`/getorderlist`, config).then(r => { return r.data }),
    updateStatusOrder: async (data) => await axios.post(`/api/Order/updateSttOrderad`, data, config).then(r => { return r.data }),
    
}
const Provider = {
    getListProvider: async () => await axios.get("/api/Provider", config).then(r => { return r.data }),

}

export default { User, Product, Category, Order, Provider };