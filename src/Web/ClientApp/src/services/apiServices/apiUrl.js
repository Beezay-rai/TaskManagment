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
  
  task: {
    task: {
      method: "GET",
      url: "/GetAllTaskEntity",
    },
    createTask: {
      method: "POST",
      url: "/CreateTask",
    },
    editTask: {
      method: "PUT",
      url: "/EditTask",
    },
    deleteTask: {
      method: "DELETE",
      url: "/DeleteTask",
    },
    taskById: {
      method: "GET",
      url: "/GetTaskById",
    },
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
