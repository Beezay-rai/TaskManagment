import * as yup from "yup";

export const taskCategorySchema = yup.object().shape({
  name: yup.string().required("Title is required !"),
});

export const taskSchema = yup.object().shape({
  
});

export default { taskCategorySchema, taskSchema };
