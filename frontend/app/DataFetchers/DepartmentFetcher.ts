'use server'
import axios from 'axios';
import createApiClient from './api/apiClient';

const baseUrl = 'http://localhost:5031/api/department';
const apiClient = createApiClient({baseURL: baseUrl});

export const fetchAllDepartments = async (): Promise<Department[]> => {
    try {
      const response = await apiClient.get(baseUrl);
      return response.data;
    } catch (error) {
      console.error('Fetch All Departments Error:', error);
      throw error;
    }
  };

export const fetchDepartmentById = async (id: number): Promise<Department | null> => {
    try {
      const response = await apiClient.get(`${baseUrl}/${id}`);
      return response.data;
    } catch (error) {
      console.error('Fetch Department By ID Error:', error);
      throw error;
    }
  };

  export const fetchDepartmentByName = async (name: string): Promise<Department | null> => {
    try {
      const response = await apiClient.get(`${baseUrl}/name/${name}`);
      return response.data;
    } catch (error) {
      console.error('Fetch Department By Name Error:', error);
      throw error;
    }
  };
  
  export const createDepartment = async (department: Department): Promise<Department> => {
    try {
      const response = await apiClient.post(baseUrl, department);
      return response.data;
    } catch (error) {
      console.error('Create Department Error:', error);
      throw error;
    }
  };
  
  export const updateDepartment = async (id: number, department: Department): Promise<Department | null> => {
    try {
      const response = await apiClient.put(`${baseUrl}/${id}`, department);
      return response.data;
    } catch (error) {
      console.error('Update Department Error:', error);
      throw error;
    }
  };
  
  export const deleteDepartment = async (id: number): Promise<Department | null> => {
    try {
      const response = await apiClient.delete(`${baseUrl}/${id}`);
      return response.data;
    } catch (error) {
      console.error('Delete Department Error:', error);
      throw error;
    }
  };