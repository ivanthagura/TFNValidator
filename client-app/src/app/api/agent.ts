import { ITFN } from './../models/tfn';
import axios, { AxiosResponse } from 'axios';
import toast from 'react-hot-toast';

axios.defaults.baseURL = process.env.REACT_APP_API_URL;

const responseBody = (response: AxiosResponse) => response.data;

axios.interceptors.response.use(undefined, (error) => {
    if (error.message === 'Network Error' && !error.response) {
      toast.error('Network error - make sure API is running');
    }
    const { status, data } = error.response;
    if (status === 404) {
      toast.error('Network error - request not found');
    }
    if (status === 400) {
        toast.error('Validation tool does not allow multiple attempts within a give time frame');
    }
    if (status === 500) {
      toast.error('Server error - check the terminal for more info!');
    }
    throw error.response;
});

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