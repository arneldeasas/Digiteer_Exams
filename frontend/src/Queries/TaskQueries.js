import api from "../api/axios";
import { handleApiResponse } from "../Helpers/ApiResponseHelper";

export const getUserTasks = async (userId) => {
  console.log(userId);

  return await handleApiResponse(
    async () => await api.get(`/tasks/all/${userId}`)
  );
};
