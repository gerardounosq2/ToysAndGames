import axios, { AxiosError, AxiosResponse } from "axios";
import { ToysAndGames, ToysAndGamesInput } from "../models/ToysAndGames";

axios.defaults.baseURL = 'https://localhost:7059/api'

const responseBody = <T>(response: AxiosResponse<T>) => response.data;

const sleep = (delay: number) => {
    return new Promise(resolve => setTimeout(resolve, delay));
}

axios.interceptors.response.use(async res => {
    await sleep(1000);
    return res;
});

const requests = {
    get: <T>(url: string) => axios.get<T>(url).then(responseBody),
    post: <T>(url: string, body: {}) => axios.post<T>(url, body).then(responseBody),
    put: <T>(url: string, body: {}) => axios.put<T>(url, body).then(responseBody),
    del: (url: string) => axios.delete<void>(url).then(responseBody)
}

const Products = {
    getAll: () => requests.get<ToysAndGames[]>('/Products/GetAll'),
    get: (id: number) => requests.get<ToysAndGames>(`/Products/${id}`),
    delete: (id: number) => requests.del(`/Products/${id}`),
    update: (id: number, input: ToysAndGamesInput) => requests.put(`/Products/${id}`, input),
    create: (input: ToysAndGamesInput) => requests.post('/Products/Create', input)
}

const agent = {
    Products
}

export default agent;