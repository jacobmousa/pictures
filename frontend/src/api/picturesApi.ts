import axios from 'axios';

const api = axios.create({
  baseURL: 'http://localhost:5000/api',
});

export const getPictures = () => api.get('/pictures');
export const uploadPicture = (formData: FormData) =>
  api.put('/pictures', formData);
