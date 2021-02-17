# Weekly Planner

Weekly Planner is a project for companies create one or more dashboard and follow their progress with multiple team

## Requirements

- Redis
- Mongo
- .Net 5

##  Endpoints
### User
|  Endpoint | Desc  |
| :------------ | :------------ |
| POST /api/User/register | Register user to system |
| POST /api/User/login | Login with email |
| POST /api/User/auth | Get JWT Token with Access code and AccessGuid from email |

### Dashboard (Auth)
|  Endpoint | Desc  |
| :------------ | :------------ |
| GET/api/Dashboard | Get dashboard with company domain |
| POST /api/Dashboard | Create dashboard for team  |
| POST /api/Dashboard/createTable | Create table for dashboard  |
| PUT /api/Dashboard/UpdateTableOrder | Update table order in dashboard |
| POST /api/Dashboard/AddAssignment | Add Assignment to table  |






##  Top Level Directory Layout

|  Project | Desc  |
| :------------ | :------------ |
|  WeeklyPlanner.API |  API Endpoint |
|  WeeklyPlanner.Application |  Logging, Validation, Services, Commands and Queries |
| WeeklyPlanner.Domain | Entity Model, Interfaces  |
| WeeklyPlanner.Infrastructure | Repositories, Database, Cache Handler  |

## 3rd Party Libraries
- Mediatr
- FluentValidation
- NETCore.MailKit
