const apiUrls = {
  authenticate: {
    login: {
      method: "POST",
      url: "/Login",
    },
    signUp: {
      method: "POST",
      url: "/SignUp",
    }
  },

  taskCategory: {
    taskCategory: {
      method: "GET",
      url: "/GetAllTaskCategory",
    },
    createTaskCategory: {
      method: "POST",
      url: "/CreateTaskCategory",
    },
    editTaskCategory: {
      method: "PUT",
      url: "/EditTaskCategory",
    },
    deleteTaskCategory: {
      method: "DELETE",
      url: "/DeleteTaskCategory",
    },
    taskCategoryById: {
      method: "GET",
      url: "/GetTaskCategoryById",
    },
  },
};
export default apiUrls;
