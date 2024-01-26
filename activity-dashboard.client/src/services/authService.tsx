export const addAuthTokenKey = (token: any) => {
  localStorage.setItem("token", token);
};
export const removeAuthTokenKey = () => {
  localStorage.removeItem("token");
};

export const getAuthToken = () => {
  return localStorage.getItem("token");
};
