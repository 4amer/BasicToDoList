import { ApiGetToDoInfos } from '../configs/ApiConfig';

const ToDoInfoAPI = async () => {
    try{
        const request = await fetch(ApiGetToDoInfos + "/GetToDoInfos", {
            method: "GET"
        });
    
        if (!request.ok) {
            throw new Error("Failed to fetch data from server");
        }
    
        const data = await request.json();
        return data;
    } 
    catch (error) {
        console.error("Error fetching data:", error);
        throw error;
    }
}

export default ToDoInfoAPI