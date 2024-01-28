### Technology Stack:
- **.NET Core 8**
- **React 18.0**

### API Structure:
- **Folder Architecture:** Contains all services and logic.
- **Folder DbModels:** Houses all database objects.
- **Folder Enums:** Stores enums used in the system.
- **Folder Implementation:** Holds implementations of repository and service interfaces.
- **Folder Interfaces:** Contains interfaces used for repository and services.
- **Folder Middleware:** Houses middleware for the API.
- **Folder Requests:** Contains classes serving as view models for incoming requests.
- **Folder Responses:** Contains classes serving as view models for outgoing responses.
- **Folder Controllers:** Contains all controllers.
- **Folder Hubs:** Houses SignalR setup.

Certainly! Here's a revised version suitable for a GitHub README file:

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

