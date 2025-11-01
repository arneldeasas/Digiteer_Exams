const CurrentUserHelper = {
  setCurrentUser: (userId) => {
    console.log(userId);

    localStorage.setItem("currentUser", JSON.stringify({ id: userId }));
  },
  getCurrentUser: () => {
    const user = localStorage.getItem("currentUser");
    const userId = user ? JSON.parse(user) : null;
    return userId;
  },
};

export default CurrentUserHelper;
