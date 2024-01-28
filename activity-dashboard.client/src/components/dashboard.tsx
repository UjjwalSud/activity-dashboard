// src/components/NotFound.tsx
import React, { useEffect, useState } from "react";
import { getAuthToken, removeAuthTokenKey } from "../services/authService";
import { useNavigate } from "react-router-dom";
import {
  makeGetRequest,
  makePostRequest,
} from "../services/httpRequestService";
import {
  activityResponse,
  activityTypesResponse,
} from "../interfaces/returnResponse";
import ViewRunningActivities from "./viewRunningActivities";

const Dashboard: React.FC = () => {
  const navigate = useNavigate();
  const [error, setError] = useState<string | null>(null);
  const [success, setSuccess] = useState<string | null>(null);
  const [activityTypes, setActivityTypes] = useState<activityTypesResponse[]>();

  const [currentActivityTypeId, setCurrentActivityTypeId] = useState<number>(0);
  const [currentActivityId, setCurrentActivityId] = useState<string>("");
  const [userStartedActivityCalled, setUserStartedActivityCalled] =
    useState<boolean>(false);

  useEffect(() => {
    document.title = "Dashboard";
    if (!getAuthToken()) {
      navigate("/login", { replace: true });
    }
    getActivityTypes();
  }, []);

  useEffect(() => {
    if (!userStartedActivityCalled && activityTypes) {
      getUserStartedActivity();
    }
  }, [activityTypes]);

  const handleLogoutClick = () => {
    removeAuthTokenKey();
    navigate("/login", { replace: true });
  };

  const getActivityTypes = () => {
    makeGetRequest("activity-type/get-all")
      .then((data) => {
        setActivityTypes(data.data);
      })
      .catch((error) => {
        setError(error.message);
      });
  };

  const getUserStartedActivity = () => {
    makeGetRequest("activity/get-user-started-activity")
      .then((data) => {
        const typeCastedData = data.data as activityResponse;
        if (typeCastedData.activityTypeId > 0 && activityTypes) {
          setCurrentActivityId(typeCastedData.activityId);
          setCurrentActivityTypeId(typeCastedData.activityTypeId);

          var foundItem = activityTypes.find(
            (item) => item.id === typeCastedData.activityTypeId
          );

          if (foundItem) {
            resetActivityTypButtons(foundItem, "started");
          }
        }
      })
      .catch((error) => {
        setError(error.message);
      });
    setUserStartedActivityCalled(true);
  };

  const handleActivityTypeClick = (type: activityTypesResponse) => {
    setError(null);
    setSuccess(null);
    if (currentActivityId == "") {
      makePostRequest("activity/start", { activityTypeId: type.id })
        .then((data) => {
          setCurrentActivityId(data.data);
          setCurrentActivityTypeId(type.id);
          resetActivityTypButtons(type, "started");
          setSuccess(data.message);
        })
        .catch((error) => {
          setError(error.message);
        });
    } else {
      makePostRequest("activity/end", { activityId: currentActivityId })
        .then((data) => {
          setCurrentActivityId("");
          setCurrentActivityTypeId(0);
          resetActivityTypButtons(type, "ended");
          setSuccess(data.message);
        })
        .catch((error) => {
          setError(error.message);
        });
    }
  };

  const resetActivityTypButtons = (
    currentActivityTypeId: activityTypesResponse,
    actionType: string
  ) => {
    if (!activityTypes) {
      return;
    }
    setActivityTypes(
      activityTypes.filter((item) => {
        if (currentActivityTypeId.id == item.id || actionType == "ended") {
          item.isDisabled = false;
        } else {
          item.isDisabled = true;
        }
        return item;
      })
    );
  };

  return (
    <div className="container-fluid mt-5">
      <div className="logout-btn-container">
        <button className="btn btn-danger" onClick={handleLogoutClick}>
          Logout
        </button>
      </div>
      <>
        {activityTypes &&
          activityTypes.map((activityType) => (
            <button
              key={activityType.id}
              disabled={activityType.isDisabled}
              onClick={() => handleActivityTypeClick(activityType)}
              className={`btn ${activityType.buttonCss} mx-2 ${
                activityType.id === currentActivityTypeId
                  ? "glowing-button"
                  : ""
              } `}
            >
              {activityType.id === currentActivityTypeId ? "Stop" : "Start"}
              &nbsp; '{activityType.activityName}'
            </button>
          ))}
      </>
      <ViewRunningActivities />
      {error && (
        <div className="row">
          <div className="col-12">
            <div className="alert alert-danger mt-1 mb-1">{error}</div>
          </div>
        </div>
      )}
      {success && (
        <div className="row">
          <div className="col-12">
            <div className="alert alert-success mt-1 mb-1">{success}</div>
          </div>
        </div>
      )}
    </div>
  );
};

export default Dashboard;
