import api from "../api/axios";

const signUpUser = async (newUser) => {
  const response = await api.post("/user/sign-up", newUser);
  console.log(response);

  return response.data;
};

export { signUpUser };
