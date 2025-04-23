// src/services/userService.ts
import axios from "axios";

const API_URL = 'https://localhost:7040/api/User'; // API URL của backend
const coffeeShopAPI = 'https://api.sampleapis.com/coffee/hot'; // API URL của Coffee Shop

// Định nghĩa interface cho yêu cầu tạo người dùng
export interface CreateUserRequest {
    username: string;
    password: string;
    email: string; 
}

// Hàm tạo người dùng
export const createuser = async (user: CreateUserRequest) => {
    const response = await axios.post(`${API_URL}`, user, {
        withCredentials: true
    });
    return response.data;
};

export const getJobByUserId = async (userId: number) => {
    const response = await axios.get(`${API_URL}/${userId}/jobs`, {
        withCredentials: true
    });
    return response.data;
};


export const getCoffeeShopData = async () => {
    const response = await axios.get(coffeeShopAPI);
    return response.data; // Trả về dữ liệu từ API Coffee Shop
}

export const getUserById = async (userId: number) => {
    const response = await axios.get(`${API_URL}/${userId}`, {
        withCredentials: true
    });
    return response.data;
}
