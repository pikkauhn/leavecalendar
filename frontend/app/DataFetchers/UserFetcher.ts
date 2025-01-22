'use server'
import axios from 'axios';

import createApiClient from './api/apiClient';

const baseUrl = 'http://localhost:5031/api/user';
const apiClient = createApiClient({baseURL: baseUrl});
// Fetch all users
export const fetchAllUsers = async () => {
    try {
        const response = await apiClient.get(baseUrl);
        return response.data;
    } catch (error) {
        console.error('Fetch Users Error: ', error);
        throw error;
    }
};

// Fetch user by ID
export const fetchUserById = async (Id: number) => {
    try {
        const response = await apiClient.get(`${baseUrl}/${Id}`);
        return response.data;
    } catch (error) {
        console.error('Fetch User By Id Error: ', error);
        throw error;
    }
}

// Fetch user by username
export const fetchUserByUsername = async (username: string) => {
    try {
        const response = await apiClient.get(`${baseUrl}/username/${username}`);
        return response.data;
    } catch (error) {
        console.error('Fetch User By Id Error: ', error);
        throw error;
    }
}

// create a new user
export const createUser = async (user: CreateUserDto) => {
    try {
        if (user.role != 1) {
            user.role = 1;
        }
        const response = await apiClient.post(`${baseUrl}`, user);
        return response.data;
    } catch (error) {
        console.error('Create User Error: ', error);
        throw error;
    }
}

// Update user
export const updateUser = async (Id: number, userDto: UpdateUserDto) => {
    try {
        const response = await apiClient.put(`${baseUrl}/${Id}`, userDto);
        return response.data;
    } catch (error) {
        console.error('Update User Error: ', error)
        throw error;
    }
};

// Delete user
export const deleteUser = async (id: number) => {
    try {
        const response = await apiClient.delete(`${baseUrl}/${id}`);
        return response.data;
    } catch (error) {
        console.error('Delete User Error: ', error);
        throw error;
    }
}

export const verifyPassword = async (user: VerifyPassword) => {
    try {
        const response = await apiClient.post(`${baseUrl}/Verify`, user);
        return response.data;
    } catch (error) {
        console.error('Password Verification Error: ', error);
        throw error;
    }
}