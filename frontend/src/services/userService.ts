// src/services/userService.ts
import axios from "axios";

const API_CREATE_USER = 'http://localhost:5261/api/User';

export interface CreateUserRequest {
    username: string;
    password: string;
    email: string;
    fullname: string;
    phone: string;
    address: string;
    detailAddress?: "Thanh Binh Thinh, Ha Tinh, Viet Nam";
}

export const createuser = async (user: CreateUserRequest) => {
    const response = await axios.post(API_CREATE_USER, user, {
        withCredentials: true // nếu backend yêu cầu cookie
    });
    return response.data;
};
