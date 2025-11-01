const signUpUser = async (newUser) => {
  const response = await axios.post("/api/sign-up", newUser);
  return response.data;
};

export { signUpUser };
