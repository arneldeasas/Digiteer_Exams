import api from "../axios";

export const signUpUser = async () => await api.post("/user/sign-up");
export const signInUser = async () => await api.post("/user/sign-up");
