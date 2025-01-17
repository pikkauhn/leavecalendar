"use server";
import axios from "axios";
import createApiClient from "./api/apiClient";

const baseUrl = "http://localhost:5031/api/LeaveRequest";
const apiClient = createApiClient({baseURL: baseUrl});

//Fetch All Requests
export const fetchAllLeaveRequests = async () => {
  try {
    const response = await apiClient.get(`${baseUrl}`);
    return response.data;
  } catch (error) {
    console.error("Error fetching Leave Requests: ", error);
    throw error;
  }
};

//Get Request by UserID
export const fetchLeaveRequestByUserId = async (userId: number) => {
  try {
    const response = await apiClient.get(`${baseUrl}/userRequest/${userId}`);
    return response.data;
  } catch (error) {
    console.error(`Error fetching Leave Request by user Id ${userId}: `, error);
    throw error;
  }
};

//Get Request by Id
export const fetchLeaveRequestById = async (Id: number) => {
  try {
    const response = await apiClient.get(`${baseUrl}/${Id}`);
    return response.data;
  } catch (error) {
    console.error(`Error fetching Leave Request by Id ${Id}: `, error);
    throw error;
  }
};

//Create New Request
export const createLeaveRequest = async (
  leaveRequest: CreateLeaveRequestDto
) => {
  try {
    const response = await apiClient.post(`${baseUrl}`, leaveRequest);
    return response.data;
  } catch (error) {
    console.error("Error creating new leave request: ", error);
    throw error;
  }
};

//Delete Request
export const deleteLeaveRequest = async (Id: number) => {
  try {
    const response = await apiClient.delete(`${baseUrl}/${Id}`);
    return response.data;
  } catch (error) {
    console.error(`Error deleting leave request with Id ${Id}: `, error);
    throw error;
  }
};

//Edit Request by Id
export const updateLeaveRequest = async (
  Id: number,
  leaveRequest: UpdateLeaveRequestDto
) => {
  try {
    const response = await apiClient.put(`${baseUrl}/${Id}`, leaveRequest);
    return response.data;
  } catch (error) {
    console.error(`Error updating leave request with Id ${Id}`, error);
    throw error;
  }
};
