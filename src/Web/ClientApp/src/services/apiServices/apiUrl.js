const apiUrls = {
  authenticate: {
    loginUser: {
      method: "POST",
      url: "/Login",
    },
    signUp: {
      method: "POST",
      url: "/SignUp",
    },
    googleSignUp: {
      method: "POST",
      url: "/GoogleSignup",
    },
    googleLogin: {
      method: "POST",
      url: "/GoogleLogin",
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
