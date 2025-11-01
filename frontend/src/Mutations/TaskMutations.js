import api from "../api/axios";
import { handleApiResponse } from "../Helpers/ApiResponseHelper";

const createTask = async (newTask) => {
  const response = await api.post("/tasks/create-task", newTask);
  return handleApiResponse(
    async () => await api.post("/tasks/create-task", newTask)
  );
};

export { createTask };
