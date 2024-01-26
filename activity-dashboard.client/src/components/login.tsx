import React, { useEffect, useState } from "react";
import { commonReturnResponse } from "../interfaces/returnResponse";
import { addAuthTokenKey, getAuthToken } from "../services/authService";
import { useNavigate } from "react-router-dom";
import { makePostRequest } from "../services/httpRequestService";

const Login: React.FC = () => {
  const navigate = useNavigate();
  useEffect(() => {
    document.title = "Login";
  }, []);
  const [username, setUsername] = useState("");
  const [password, setPassword] = useState("");
  const [error, setError] = useState<string | null>(null);
  useEffect(() => {
    if (getAuthToken()) {
      navigate("/dashboard", { replace: true });
    }
  }, []);

  const handleLogin = () => {
    makePostRequest("user/login", { email: username, password })
      .then((data) => {
        const userData = data as commonReturnResponse;
        addAuthTokenKey(userData.data);
        navigate("/dashboard", { replace: true });
      })
      .catch((error) => {
        setError(error.message);
      });
  };

  return (
    <div className="container mt-5">
      <h2>Login</h2>
      <form>
        {error && <div className="alert alert-danger mt-1 mb-1">{error}</div>}

        <div className="mb-3">
          <label htmlFor="username" className="form-label">
            Username
          </label>
          <input
            type="text"
            className="form-control"
            id="username"
            placeholder="Enter your username"
            value={username}
            onChange={(e) => setUsername(e.target.value)}
          />
        </div>

        <div className="mb-3">
          <label htmlFor="password" className="form-label">
            Password
          </label>
          <input
            type="password"
            className="form-control"
            id="password"
            placeholder="Enter your password"
            value={password}
            onChange={(e) => setPassword(e.target.value)}
          />
        </div>

        <button type="button" className="btn btn-primary" onClick={handleLogin}>
          Login
        </button>
      </form>
    </div>
  );
};

export default Login;
