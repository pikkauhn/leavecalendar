import axios, { AxiosInstance } from 'axios';

interface ApiOptions {
    baseURL?: string;
    apiKey?: string;
}

const api = process.env.NEXT_PUBLIC_API_KEY;

const createApiClient = ({ baseURL = '', apiKey = api}: ApiOptions): AxiosInstance => {
    return axios.create({
        baseURL,
        headers: {
            'X-API-Key': apiKey,
        },
    });
};

export default createApiClient;