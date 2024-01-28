import * as signalR from "@microsoft/signalr";
import appSettings from "../settings/appSettings";

const hubConnection = new signalR.HubConnectionBuilder()
  .withUrl(appSettings.apiUrlSignalR + "ActivityHub")
  .build();

export const startConnection = async () => {
  try {
    await hubConnection.start();
    console.log("SignalR Connected.");
  } catch (err) {
    console.error("Error while starting SignalR connection: ", err);
  }
};

export const registerReceiveDataHandler = (callback: () => void) => {
  hubConnection.on("RefreshGrid", () => {
    callback();
  });
};

export const sendData = (user: string, message: string) => {
  hubConnection
    .invoke("SendData", user, message)
    .catch((err) => console.error("Error while sending message: ", err));
};
