# Jex Job API 

## 📖 Overview  
Jex.Assessment is a **Job API** built with **.NET 9**, designed to manage job vacancies and companies. It follows **Vertical Slice Architecture** to ensure maintainability and scalability. The backend uses **Minimal API** for lightweight, high-performance endpoints, along with **CQRS** for clear separation of concerns.  

---

## 📌 Features & User Stories  

### 🔹 **Companies Management**  
- ✅ As an **Admin**, I want to **create a company**, so that it can post job vacancies.  
- ✅ As an **Admin**, I want to **edit company details**, so that I can keep information up to date.  
- ✅ As an **Admin**, I want to **delete a company**, so that I can remove unused records.  
- ✅ As an **Admin**, I want to **view all companies that have active job listings**, so that I can manage them efficiently.  

### 🔹 **Job Vacancies Management**  
- ✅ As a **Recruiter**, I want to **create a job vacancy**, so that I can attract potential candidates.  
- ✅ As a **Recruiter**, I want to **edit job details**, so that I can update requirements or descriptions.  
- ✅ As a **Recruiter**, I want to **delete a job vacancy**, so that I can remove outdated job postings.  
- ✅ As a **Job Seeker**, I want to **view all job vacancies per company**, so that I can find relevant job opportunities.  

---

## 🛠️ Technologies Used  

| Technology | Description |
|------------|------------|
| **.NET 9** | Backend & API development |
| **Minimal API** | Lightweight HTTP API design |
| **Entity Framework Core** | Database management |
| **SQLite** | Database for development/testing |
| **MediatR** | CQRS & application layer communication |
| **FluentValidation** | Request validation |
| **Swagger (NSwag)** | API documentation |
| **Rider / VS Code** | Recommended development tools |

---

## 🚀 Getting Started  

### 🔹 **Prerequisites**  
- Install **.NET 9 SDK**  
- Install **SQLite** (if using local DB)  
- Install **Rider / Visual Studio Code**  

---

### 🔹 **Backend API Setup**  

1️⃣ **Clone the repository:**  
```sh
git clone https://github.com/mpeters21575/jex.git
cd Jex.Assessment
