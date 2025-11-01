import api from "../api/axios";
import { handleApiResponse } from "../Helpers/ApiResponseHelper";

const createTask = async (newTask) => {
  return await handleApiResponse(
    async () => await api.post("/tasks/create-task", newTask)
  );
};
const startTask = async (taskId) => {
  return await handleApiResponse(
    async () => await api.post(`/tasks/start-task/${taskId}`)
  );
};
export { createTask, startTask };
