### Requirement

We would like you to build a simple SPA that allows a user to log in and is presented with a dashboard/home page. On this dashboard, the user should be able to see a grid of all other users and a list of buttons at the top of the screen.

**Activity Buttons:**
Start with a list of buttons that have the following activities. (Consider making this configurable via database).
- ON BREAK
- ON CALL
- IN MEETING

The users should see three buttons on their screen as per the above list. When the user clicks on a button, their activity is set to the corresponding activity. All the other users should be able to see this activity on their grid in real time.

**Activity Grid:**
- The grid should show all users who are currently logged in and what activity they are currently doing.
- This data should refresh/sync in real time.
- The grid needs to show how much time has elapsed on the current activity.

**Example scenario:**
James logs on to the system and sees that no one is online. James clicks on “IN MEETING” button. A few minutes later, Matt logs on to the system and sees that James is in a meeting. Matt clicks on “ON CALL”, James immediately sees that Matt is online and “ON CALL” on his grid.

### Technology Stack:
- **.NET Core 8**
- **React 18.0** -- npm start

### API Structure:
- **Folder Architecture:** Contains all services and logic.
- **Folder DbModels:** Houses all database objects.
- **Folder Enums:** Stores enums used in the system.
- **Folder Implementation:** Holds implementations of repository and service interfaces.
- **Folder Interfaces:** Contains interfaces used for repositories and services.
- **Folder Middleware:** Houses middleware for the API.
- **Folder Requests:** Contains classes serving as view models for incoming requests.
- **Folder Responses:** Contains classes serving as view models for outgoing responses.
- **Folder Controllers:** Contains all controllers.
- **Folder Hubs:** Houses SignalR setup.

---

**Login Credentials:**

To access the system, you can use one of the following sets of credentials:

- **User_1**
  - Username: User_1
  - Password: Password_1

- **User_2**
  - Username: User_2
  - Password: Password_2

- **User_3**
  - Username: User_3
  - Password: Password_3

- **User_4**
  - Username: User_4
  - Password: Password_4

- **User_5**
  - Username: User_5
  - Password: Password_5

- **User_6**
  - Username: User_6
  - Password: Password_6

- **User_7**
  - Username: User_7
  - Password: Password_7

- **User_8**
  - Username: User_8
  - Password: Password_8

- **User_9**
  - Username: User_9
  - Password: Password_9

- **User_10**
  - Username: User_10
  - Password: Password_10

**Data Storage Approach:**

In our system, we utilize static variables to store user data and activity types, as opposed to employing a traditional database setup. Here's how the data is managed:

- **Users:** User information is stored in static variables. Users are added to memory during the application's initialization, typically within a static constructor. Each user has a unique set of credentials.

- **Activity Types:** Similarly, activity types are stored in memory using static variables. These activity types are predefined and added during the initialization phase. Four activities are included: "ON BREAK", "ON CALL", "IN MEETING", and "NO TASK". Additionally, one activity is marked as deactivated.

UI Screenshots

![image](https://github.com/UjjwalSud/activity-dashboard/assets/6552252/5c1c91be-d3c4-4ac3-9661-691fa8a01e16)
![image](https://github.com/UjjwalSud/activity-dashboard/assets/6552252/786962f2-8029-4abc-b385-e626859583a8)
![image](https://github.com/UjjwalSud/activity-dashboard/assets/6552252/2dc84d5d-5460-4260-9e64-3502b1dbf8ef)




