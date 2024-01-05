// api.js
// may need interrupter and token

import axios from 'axios'

const baseURL = process.env.BASE_URL || 'https://localhost:7202/api';


const instance = axios.create({
  baseURL: baseURL,
  timeout: 5000,
});

// GET Request
export const get = async (url, params = {}) => {
  return await instance.get(url, { params });
};

//POST Request
export const post = async (url, data = {}) => {
    return await instance.post(url, data);
};


export const put = async (url, data = {}) => {
  return await instance.put(url, data);
};
