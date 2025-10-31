import * as yup from "yup";
export const SignInSchema = yup
  .object({
    username: yup.string().required("Username is required :P"),
    password: yup.string().required("Password is required :P"),
  })
  .required();

export const SignUpSchema = yup
  .object({
    username: yup.string().required("Username is required :P"),
    name: yup.string().required("Name is required :P").min(3),
    email: yup
      .string()
      .required("Email is required :P")
      .email("Invalid email format"),
    password: yup
      .string()
      .required("Password is required :P")
      .min(6, "Password must be at least 6 characters"),
  })
  .required();
