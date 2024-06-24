# Database Trade Study
Comparison of different database providers


## Context

Last year, we used a database provider called Redis. Redis uses a key-value data structure to store information. However, Redis is transitioning away from being open source software, so we need an alternative.

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
    - Must be able to handle 1 update per second
- General advantages / disadvantages