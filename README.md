# 📚 R-Library Management System

A Console-based Library Management System built in C# using advanced Object-Oriented Programming principles.

This project demonstrates clean architecture, encapsulation, inheritance, polymorphism, custom exceptions, and real-world domain modeling.

---
## 🚀 Project Overview

R-Library is a console application that allows users to:

- Manage books
- Import books from CSV files
- Filter books by genre
- Borrow and return books
- Manage newspapers and magazines in a reading room
- Track daily acquisitions

The project was developed to demonstrate strong understanding of OOP design patterns and domain modeling.

---
## 🧠 OOP Concepts Implemented

### 🔐 Encapsulation
- Private fields with public properties
- Validation logic inside setters
- Controlled state management (e.g., availability, ISBN validation)

### 🧬 Inheritance
- `ReadingRoomItem` (abstract base class)
- `NewsPaper` and `Magazine` inherit from it

### 🎭 Polymorphism
- Abstract properties:
  - `Identification`
  - `Categorie`
- Runtime type checking (`is Magazine`, `is NewsPaper`)

### 🧩 Composition
- `Library` contains:
  - `List<Book>`
  - `Dictionary<DateTime, ReadingRoomItem>`

### 📜 Interface Usage
- `ILendable` implemented by `Book`

### ⚠ Custom Exceptions
- `InvalidIsbnException`
- `NegativeValueException`

---
## 📖 Features

### 📚 Book Management
- Add books
- Remove books
- Search by ISBN
- Search by title and author
- Filter by genre
- Display all books

### 📂 CSV Import
Import books using:

```
Title,Author,ISBN,Language,Pages,Price,Genre
```

### 📰 Reading Room System
- Add Newspapers
- Add Magazines
- Display all magazines
- Display all newspapers
- Show today's acquisitions

### 🔄 Borrowing System
- Borrow a book
- Automatic due date calculation
- Return book
- Late return detection

---

## 🏗 System Architecture
```
Library
│
├── List<Book>
├── Dictionary<DateTime, ReadingRoomItem>
│
├── Book (implements ILendable)
│
└── ReadingRoomItem (abstract)
       ├── NewsPaper
       └── Magazine
```

---

## ⚙ Technologies Used

- C#
- .NET
- Console Application
- Object-Oriented Programming
- File I/O (CSV Parsing)
- Collections (List, Dictionary)
- Enums
- Custom Exceptions

---

## ▶ How to Run
1. Open solution in Visual Studio 2022
2. Build the project
3. Run the application
4. Use the interactive console menu

---
## 💡 Technical Highlights

- Clean domain separation
- Validation inside property setters
- Business logic inside domain classes
- Genre-based borrowing rules
- Dynamic acquisition tracking by date

---
## 🔮 Possible Improvements

- Add persistent database storage
- Add LINQ refactoring
- Add logging system
- Add unit tests
- Convert to WPF or ASP.NET version
- Implement dependency injection

---
## 👨‍💻 Author

Ridha Alkhaykanee  
Fullstack Developer | .NET & React  

Developed as part of academic coursework in Belgium focusing on advanced Object-Oriented Programming principles.

---
