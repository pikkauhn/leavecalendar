'use server'
import axios from 'axios';

const baseUrl = 'http://localhost:5031/api/user';

export const fetchUsers = async () => {
    try {
        const response = await axios.get(`${baseUrl}`);
        return response.data;
    } catch (error) {
        console.error('Fetch Users Error: ', error);
        throw error;
    }
};

export const fetchUserById = async (Id: number) => {
    try {
        const response = await axios.get(`${baseUrl}/${Id}`);
        return response.data;
    } catch (error) {
        console.error('Fetch User By Id Error: ', error);
        throw error;
    }
}

export const fetchUserByUsername = async (username: string) => {
    try {
        const response = await axios.get(`${baseUrl}/n/${username}`);
        return response.data;
    } catch (error) {
        console.error('Fetch User By Id Error: ', error);
        throw error;
    }
}