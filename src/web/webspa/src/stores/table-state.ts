import { defineStore } from "pinia";
import axios from 'axios';

const url = 'http://localhost:5000/clients';

export const useTable = defineStore({
    id: 'Table',
    actions: {
        async getTableData() {
            try {
                return await axios.get(url)
            } catch (err) {
                console.log(err);
            }
        },
        async getById(id: string) {
            try {
                return await axios.get(`${url}/${id}`)
            } catch (err) {
                console.log(err);
            }
        },
        async deleteById(id: string) {
            try {
                return await axios.delete(`${url}/${id}`)
            } catch (err) {
                console.log(err);
            }
        },
        async createItem(body: object) {
            try {
                return await axios.post(url, body)
            } catch (err) {
                console.log(err);
            }
        },
        async updateItem(id:string, body: object) {
            try {
                return await axios.put(`${url}/${id}`, body)
            } catch (err) {
                console.log(err);
            }
        }
    }
})

