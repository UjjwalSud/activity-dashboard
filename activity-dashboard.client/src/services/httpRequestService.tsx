import { commonReturnResponse } from "../interfaces/returnResponse";
import appSettings from "../settings/appSettings";
import { getAuthToken } from "./authService";

export const makePostRequest = (endpoint: string, data?: any): Promise<any> => {
  const requestOptions: RequestInit = {
    method: "POST",
    headers: {
      "Content-Type": "application/json",
      Authorization: `Bearer ${getAuthToken()}`,
    },
    body: data ? JSON.stringify(data) : undefined,
  };

  return fetch(appSettings.apiUrl + endpoint, requestOptions).then(
    (response) => {
      if (!response.ok) {
        let errorMessage = "An error occurred.";

        if (response.status === 400) {
          errorMessage = "Please enter required fields.";
          throw new Error(errorMessage);
        } else {
          return response.json().then((errorData) => {
            const error = errorData as commonReturnResponse;
            throw new Error(`Error: ${error.message}`);
          });
        }
      }

      return response.json();
    }
  );
};

export const makeGetRequest = (endpoint: string, data?: any): Promise<any> => {
  const requestOptions: RequestInit = {
    method: "GET",
    headers: {
      "Content-Type": "application/json",
      Authorization: `Bearer ${getAuthToken()}`,
    },
    body: data ? JSON.stringify(data) : undefined,
  };

  return fetch(appSettings.apiUrl + endpoint, requestOptions).then(
    (response) => {
      if (!response.ok) {
        let errorMessage = "An error occurred.";

        if (response.status === 400) {
          errorMessage = "Please enter required fields.";
          throw new Error(errorMessage);
        } else {
          return response.json().then((errorData) => {
            const error = errorData as commonReturnResponse;
            throw new Error(`Error: ${error.message}`);
          });
        }
      }

      return response.json();
    }
  );
};
