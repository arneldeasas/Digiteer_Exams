import * as yup from "yup";
export const CreateTaskSchema = yup
  .object({
    title: yup.string().required("Title is required"),
    description: yup.string().required("Description is required"),
    dueDate: yup.date().required("End Date is required"),
  })
  .required();
