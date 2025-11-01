import * as yup from "yup";
export const SignInSchema = yup
  .object({
    username: yup.string().required("Username is required"),
    password: yup.string().required("Password is required"),
  })
  .required();

export const SignUpSchema = yup
  .object({
    username: yup.string().required("Username is required"),
    name: yup.string().required("Name is required").min(3),
    email: yup
      .string()
      .required("Email is required")
      .email("Invalid email format"),
    password: yup
      .string()
      .required("Password is required")
      .min(6, "Password must be at least 6 characters"),
  })
  .required();
