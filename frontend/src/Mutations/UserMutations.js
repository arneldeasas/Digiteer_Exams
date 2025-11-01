import api from "../api/axios";
import { handleApiResponse } from "../Helpers/ApiResponseHelper";

const signUpUser = async (newUser) => {
  const response = await api.post("/user/sign-up", newUser);
  return handleApiResponse(response);
};
const signInUser = async (user) => {
  return handleApiResponse(async () => await api.post("/user/sign-in", user));
};
export { signUpUser, signInUser };
