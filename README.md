# Monty-Hall-Problem

#Monty Hall Problem Simulation
This project is a full-stack web application that simulates the Monty Hall problem, a famous probability puzzle based on a TV game show. The application allows users to play the game, track their results, and see how changing their initial choice affects their chances of winning.

## Table of Contents
- [Features](#features)
- [Tech Stack](#tech-stack)
- [Getting Started](#getting-started)
  - [Prerequisites](#prerequisites)
  - [Installation](#installation)
  - [Running the Application](#running-the-application)
- [Project Structure](#project-structure)
- [Usage](#usage)

## Features

- Simulate the Monty Hall problem with an interactive UI.
- Allows users to log in, register, and save their game history.
- Displays game instructions and history of previous games.
- User can choose a door, Monty reveals a door, and user decides whether to switch or stay.
- Displays the outcome (win or lose) after each game with an option to play again.

## Tech Stack

- **Backend**: C#/.NET Core, Entity Framework Core (In-memory database)
- **Frontend**: Angular, Bootstrap
- **API Documentation**: Swagger

## Getting Started

### Prerequisites

- **Node.js**: Install [Node.js](https://nodejs.org/) (version 14 or higher recommended).
- **Angular CLI**: Install Angular CLI globally using `npm install -g @angular/cli`.
- **.NET Core SDK**: Install [.NET Core SDK](https://dotnet.microsoft.com/download).
  
1. **Clone the repository:**
   ```sh
   git clone https://github.com/SamithaN/Monty-Hall-Problem.git 
   cd Monty-Hall-Problem
   ```

2. **Setup Backend:**
   ```sh
   cd backend
   dotnet restore
   dotnet build
   ```
3. **Setup Frontend:**
   ```sh
   cd frontend
   npm install
   ```
### Running the Application

1. **Run Backend:**
   ```sh
   cd MontyHall_be
   dotnet run
   ```
The backend server will start at https://localhost:5113.

2. **Run Frontend:**
   ```sh
   cd frontend
   ng serve
   ```
The frontend will be accessible at http://localhost:4200.

### Project Structure

- monty-hall-simulation/
- │
- ├── backend/               # .NET Core Backend
- │    ├── Controllers/       # API Controllers
- │    ├── Data/              # Database context and configuration
- │    ├── Models/            # Domain models
- │    ├── Program.cs         # Application entry point
- │    └── ...                
- │
- └── frontend/              # Angular Frontend
- │   ├── src/               # Angular app source code
- │   ├── app/               # Application components and services
- │   ├── assets/            # Static assets (images, styles)
- │   ├── environments/      # Environment configurations
- │   └── ...
  
### Usage
- Login/Register: Create an account or log in with an existing account.
- Start Game: Navigate to the game from the menu.
- Choose a Door: Select a door to start the game.
- Monty Reveals: Monty will reveal a door that doesn’t have the car.
- Switch or Stay: Decide whether to switch your choice.
- Game Outcome: See if you won or lost, with an option to play again.
- View History: View your past games from the history section.
