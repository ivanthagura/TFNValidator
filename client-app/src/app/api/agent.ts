import { ITFN } from './../models/tfn';
import axios, { AxiosResponse } from 'axios';

axios.defaults.baseURL = process.env.REACT_APP_API_URL;

const responseBody = (response: AxiosResponse) => response.data;

const requests = {
    post: (url: string, body: {}) => axios.post(url, body).then(responseBody)
};

const TFN = {
    validate: (tfnNumber: ITFN) => requests.post(`/tfn/${tfnNumber.tfnNumber}`, {})
};

// eslint-disable-next-line import/no-anonymous-default-export
export default {
    TFN
};