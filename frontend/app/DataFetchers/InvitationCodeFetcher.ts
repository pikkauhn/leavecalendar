'use server'
import axios from 'axios';

const baseUrl = 'http://localhost:5031/api/InvitationCode';

// Fetch all codes
export const fetchAllInvitationCodes = async () => {
    try {
        const response = await axios.get(`${baseUrl}`);
        return response.data;
    } catch (error) {
        console.error('Fetch Invitation codes Error: ', error);
        throw error;
    }
};
// Authenticate code
export const AuthenticateCode = async (code: string) => {
    try {
        const response = await axios.get(`${baseUrl}/auth/${code}`);
        return response.data;
    } catch (error) {
        console.error('Authorization attempt failed: ', error);
        throw error;
    }
}
// Update Code After Use
export const UpdateCode = async(id: number) => {
    try {
        const response = await axios.get(`${baseUrl}/${id}`);
        const update = await axios.put(`${baseUrl}/${id}`);
    } catch (error) {
        console.error('Updating code failed: ', error);
        throw error;
    }
}