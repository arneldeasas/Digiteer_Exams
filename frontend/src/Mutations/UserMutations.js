import api from "../api/axios";
import { handleApiResponse } from "../Helpers/ApiResponseHelper";

const signUpUser = async (newUser) => {
  return await handleApiResponse(
    async () => await api.post("/user/sign-up", newUser)
  );
};
const signInUser = async (user) => {
  return await handleApiResponse(
    async () => await api.post("/user/sign-in", user)
  );
};
export { signUpUser, signInUser };
