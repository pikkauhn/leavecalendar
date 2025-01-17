'use server'
import axios from 'axios';
import createApiClient from './api/apiClient';

const baseUrl = 'http://localhost:5031/api/InvitationCode';
const apiClient = createApiClient({baseURL: baseUrl});
// Fetch all codes
export const fetchAllInvitationCodes = async () => {
    try {
        const response = await apiClient.get(`${baseUrl}`);
        return response.data;
    } catch (error) {
        console.error('Fetch Invitation codes Error: ', error);
        throw error;
    }
};
// Authenticate code
export const AuthenticateCode = async (code: string) => {
    try {
        const response = await apiClient.get(`${baseUrl}/auth/${code}`);
        return response.data;
    } catch (error) {
        console.error('Authorization attempt failed: ', error);
        throw error;
    }
}
// Update Code After Use
export const UpdateCode = async(id: number) => {
    try {
        const response = await apiClient.get(`${baseUrl}/${id}`);
        const update = await apiClient.put(`${baseUrl}/${id}`);
    } catch (error) {
        console.error('Updating code failed: ', error);
        throw error;
    }
}