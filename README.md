# Freelancers API

A RESTful API for managing freelancers, their skillsets, and hobbies. This project demonstrates CRUD operations, wildcard search, and the ability to archive/unarchive freelancers. Built using **.NET 8** and connected to a relational database for persistent data storage.

## Features

1. **CRUD Operations for Freelancers**:
   - `@GET` to retrieve freelancer details.
   - `@POST` to register a new freelancer.
   - `@PUT` to update freelancer details.
   - `@DELETE` to delete a freelancer.

2. **Relational Data Management**:
   - Freelancers have one-to-many relationships with `Skillsets` and `Hobbies`.
   - Skillsets and Hobbies are stored in separate tables.

3. **Wildcard Search**:
   - Search for freelancers by username or email using flexible search terms.

4. **Archive/Unarchive Freelancers**:
   - Freelancers can be archived or unarchived using a dedicated endpoint.

5. **Database Integration**:
   - Uses a well-known RDBMS (SQL Server, PostgreSQL, etc.) to store and manage data.

---

## API Endpoints

### **Freelancers**
#### Get All Freelancers
```http
GET /api/freelancers

#### Get Freelancer with ID
```http
GET /api/freelancers/{id}

#### search Freelancer with name of email with wildcard
```http
GET /api/freelancers/search?term={searchTerm}

#### Insert  Freelancer
POST /api/freelancers
- request body:  
```json
{
  "username": "john_doe_updated",
  "email": "john_inserted@example.com",
  "phoneNumber": "987-654-3210",
  "skillsets": ["Docker", "Kubernetes"],
  "hobbies": ["Traveling", "Hiking"]
}
json

#### update Freelancer
PUT /api/freelancers/{id}
{
  "username": "john_doe_updated",
  "email": "john_updated@example.com",
  "phoneNumber": "987-654-3210",
  "skillsets": ["Kubernetes"],
  "hobbies": ["Traveling", "Hiking"]
}
json

#### Delete Freelancer
DELETE /api/freelancers/{id}

#### Archive Freelancer
PUT /api/freelancers/{id}/archive

#### Unarchive a Freelancer
PUT /api/freelancers/{id}/unarchive








