import axios from "axios";

export const httpClient = axios.create({
    baseURL: 'http://localhost:5000/api'
});

httpClient.interceptors.request.use(config => {
    const jwt = localStorage.getItem("jwt");
    if (jwt) {
        config.headers.Authorization = `Bearer ${jwt}`;
    }
    return config;
});
