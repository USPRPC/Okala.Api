# Environmental Conditions API

## Summary

This project is a .NET Core Web API that fetches and returns current environmental data (weather, air quality, and geolocation) for a given city using the OpenWeatherMap API.

### Features

- Input: City name
- Output:
  - Temperature (°C)
  - Humidity (%)
  - Wind Speed (m/s)
  - Air Quality Index (AQI)
  - Major Pollutants (PM2.5, CO, NO₂, etc.)
  - Latitude and Longitude
- Clean code structure with Dependency Injection and SOLID principles
- Includes one unit test using xUnit



# Technical Assessment – WiraSystem

## How much time did you spend on this task?

I spent approximately 4.5 hours.

### If you had more time, what improvements or additions would you make?

- Add integration tests  
- Improve error handling 
- Use caching for repeated city lookups
- Dockerize the app
- Add retry logic for external API failures

---

## What is the most useful feature recently added to your favorite programming language?

Global using directives in C#.

---

## How do you identify and diagnose a performance issue in a production environment?  
Have you done this before?

I use logging and monitoring tools like Serilog and Application Insights to trace and measure slow responses. I check CPU/memory usage and profile bottlenecks with tools like Visual Studio Diagnostic Tools. Yes, I’ve done this before while fixing latency in an API project.

---

## What’s the last technical book you read or technical conference you attended?  
What did you learn from it?

Clean Architecture by Robert C. Martin.  
I learned how to separate concerns, apply dependency inversion, and design maintainable application layers.

---

## What’s your opinion about this technical test?

It’s practical and focused on real backend skills. I liked that it included both coding and written questions.

---

## Please describe yourself using JSON format.

```json
{
  "name": "Yousof Asadi",
  "role": "Backend Developer",
  "skills": ["C#", ".NET Core", "REST APIs", "SQL", "Unit Testing"],
  "learning": ["Docker", "Azure", "gRPC"],
  "hobbies": [
              "Designing and Developing Malware Simulation Tools for Educational and Security Testing Purposes",
              "Game Development and Ethical Exploiting for Security Learning",
              "Exploring GitHub for Open Source Projects and Innovation",
              "Watching movies"
            ]
}
```
