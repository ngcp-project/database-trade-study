# Database Trade Study
Comparison of different database providers


## Context

Last year, we used a database provider called Redis. Redis uses a key-value data structure to store information. However, Redis is transitioning away from being open source software, so we need to look into alternatives.

## Database Candidates

1. Influx DB (SQL supporting database but niche)
2. Local version of MongoDB (document-based database)
3. Cassandra (Discord previously used it)
4. PostgreSQL (SQL supported)

## Mock Application

The mock application will simulate telemetry data without having to go through the actual hassle of connecting to a simulated vehicle. In last year’s iteration, we were required to receive information at one update per second sent through a web socket. Think of this mock application as a chat application except that there’s a script that sends a user message every second.

## Factors to Consider

- Development Speed
- LARGE WEIGHT: Read/write speed
    - Must be able to handle AT LEAST 1 update per second (1 Hertz)
- General advantages / disadvantages


## Installation Instructions
1. Clone the repository
2. Install language support
- [.NET](https://dotnet.microsoft.com/en-us/download)
    - **NOTE:** Everyone must install the same version of .NET (blame Microsoft)
    - Use .NET SDK 8.0.302 [direct installation link if needed](https://download.visualstudio.microsoft.com/download/pr/b6f19ef3-52ca-40b1-b78b-0712d3c8bf4d/426bd0d376479d551ce4d5ac0ecf63a5/dotnet-sdk-8.0.302-win-x64.exe)
- [Node.js](https://nodejs.org/en/download/)
    - Optional: The test client's dependencies can be installed with whatever package manager you want (npm, bun, etc.). You will have to configure the `package.json` script to run the client based on your package manager.
    - Version doesn't matter. Long-term support (LTS) is recommended.
3. Initialize & Run Database Server
    
    a. Ctrl + Shift + P (or Cmd + Shift + P) to open up the command palette in VS Code
    
    b. Type "Tasks: Run Task" and press Enter
    
    c. Select "Run Database Server" and press Enter

4. Initialize & Run Test Client
    
    a. Open up a new terminal window

    b. Install the test client's dependencies with `npm run install` or cd into the `test-client` directory and run `[package manager] install`

    c. Run the test client with `npm run client`