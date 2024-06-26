import React, { useEffect, useState } from "react";
import { makeGetRequest } from "../services/httpRequestService";
import { activityResponse } from "../interfaces/returnResponse";
import {
  registerReceiveDataHandler,
  startConnection,
} from "../services/signalrService";

const ViewRunningActivities: React.FC = () => {
  const [runningActivities, setRunningActivities] =
    useState<activityResponse[]>();

  const bindRunningActivity = () => {
    makeGetRequest("activity/get-all-active-activities").then((data) => {
      setRunningActivities(data.data);
    });
  };

  useEffect(() => {
    bindRunningActivity();

    startConnection(); // Connect to SignalR hub when component mounts

    // Register handler for receiving messages
    registerReceiveDataHandler(() => {
      bindRunningActivity();
    });
  }, []);
  return (
    <div className="d-flex align-items-center justify-content-center vh-100">
      <div className="text-center">
        <table className="table table-striped table-bordered table-hover">
          <thead>
            <tr>
              <th scope="col">#</th>
              <th scope="col">Use Name</th>
              <th scope="col">Activity</th>
              <th scope="col">Started At</th>
            </tr>
          </thead>

          <tbody>
            {runningActivities &&
              runningActivities.length > 0 &&
              runningActivities.map((item) => (
                <tr>
                  <td>1.</td>
                  <td>{item.userDetails}</td>
                  <td>{item.activityName}</td>
                  <td>{item.activityStartedAt.toString()}</td>
                </tr>
              ))}

            {!runningActivities ||
              (runningActivities.length == 0 && (
                <tr>
                  <td colSpan={4}>
                    <div className="alert alert-danger mt-1 mb-1">
                      No running activity{" "}
                    </div>
                  </td>
                </tr>
              ))}
          </tbody>
        </table>
      </div>
    </div>
  );
};

export default ViewRunningActivities;
