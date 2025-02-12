import axios from "axios";


export const PORT = 8080;
const api = axios.create({
    baseURL: `http://localhost:${PORT}`,
});


export default api;