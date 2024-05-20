import axios from "axios";

export const httpClient = axios.create({
    baseURL: process.env.REACT_APP_API_BASE_URL
});

httpClient.interceptors.request.use(config => {
    const jwt = localStorage.getItem("jwt");
    if (jwt) {
        config.headers.Authorization = `Bearer ${jwt}`;
    }
    return config;
});
