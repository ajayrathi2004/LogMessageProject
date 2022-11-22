# Qvik Assignment

# Getting Started

### Technology stack:
1. .Net Core
2. .Net Core WebAPI
3. Microsoft.EntityFrameworkCore
4. Microsoft.EntityFrameworkCore.InMemory 
5. xUnit for unitTest Cases
6. FakeItEasy to fake the repository calls in unit Testing.

### Steps:
1. Clone the project from Git
2. setup project locally
3. No database setup required as it used InMemory DB.


LogMessageApp Components:
1. Repository
2. Api Controller for Rest

LogMessageApp Test Components:
1. It Uses xUnit Testing with the help of FakeItEasy.


APIs
1. SwaggerUI: https://localhost:7042/swagger/index.html
2. POST API: https://localhost:7042/api/LogMessage?name=Ajay%20Supplier&logId=1&message=Hello%20Ajay
3. GET API: https://localhost:7042/api/LogMessage/GetLog/1


