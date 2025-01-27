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
Retrieves all freelancers along with their skillsets and hobbies.
Get Freelancer by ID
http
Copy
Edit
GET /api/freelancers/{id}
Retrieves a freelancer's details by their ID, including skillsets and hobbies.
Search Freelancers (Wildcard)
http
Copy
Edit
GET /api/freelancers/search?term={searchTerm}
Searches for freelancers by username or email using a wildcard search.
Insert Freelancer
http
Copy
Edit
POST /api/freelancers
Request Body:
json
Copy
Edit
{
  "username": "john_doe_inserted",
  "email": "john_inserted@example.com",
  "phoneNumber": "987-654-3210",
  "skillsets": ["Docker", "Kubernetes"],
  "hobbies": ["Traveling", "Hiking"]
}
Update Freelancer
http
Copy
Edit







