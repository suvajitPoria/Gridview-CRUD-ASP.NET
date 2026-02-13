# Student CRUD Application (ASP.NET WebForms)

A simple **Student Management CRUD application** built using **ASP.NET WebForms** with a clean **3-Tier Architecture (UI, BLL, DAL)** and **SQL Server Stored Procedures**.

This project demonstrates how to perform **Create, Read, Update, and Delete (CRUD)** operations using `GridView` with validation and proper layering.

---

## 🔧 Tech Stack

- ASP.NET WebForms (.NET Framework)
- C#
- SQL Server
- ADO.NET
- HTML/CSS
- Stored Procedures

---

## 🧱 Architecture

This project follows a **3-Tier Architecture**:

1. **Presentation Layer (UI)**  
   - ASPX page with GridView and Validators

2. **Business Logic Layer (BLL)**  
   - Handles business rules and communicates with DAL

3. **Data Access Layer (DAL)**  
   - Handles all database operations using ADO.NET

---

## ✨ Features

- Add new student
- View all students in GridView
- Edit student details inline
- Delete student with JavaScript confirmation
- Server-side validations:
  - Required field validation
  - Email format validation
  - Age range validation
- Uses SQL Stored Procedures
- Clean separation of concerns (UI / BLL / DAL)

---

## 🗄 Database Structure

### Table: `tblStudent`

```sql
CREATE TABLE tblStudent
(
	StudentId INT PRIMARY KEY IDENTITY(1,1),
	Name VARCHAR(100) NOT NULL,
	Email VARCHAR(100),
	Course VARCHAR(50),
	Age INT,
	CreatedAt DATE DEFAULT GETDATE()
)
