# Cassandra Breakdown

## Test Conditions
3 Scripts running at 10 Hertz

## Results
Average of 7.7 ms for insert operation

<img width="275" alt="Screenshot 2024-10-25 010332" src="https://github.com/user-attachments/assets/2c681386-f797-4542-81cf-785b0af4f9ab">

## Developer Experience
Pretty rough to set up. Highly optimized for horizontal scaling with initialization options for data replication. Doesn't seem designed for a single database.

# Pros
- Stupid amount of scaling possibilities
- ORM (Object Relation Mapper) support
  - Automatic serialization; can easily work with data as its given as an object when fetching from database

# Cons
- Absolutely overkill
- Lack of built-in UI to visually see data inside Cassandra database
- Crappy Error handling


## Resources Used
- [Cassandra Overview](https://medium.com/codenx/navigating-apache-cassandra-with-net-9170459dcf09)
- [Cassandra Syntax](https://docs.datastax.com/en/cql/dse-6.9/reference/cql-commands/drop-table.html)
- [3rd Party Cassandra Tooling](https://cassandra.tools/Kindrat/cassandra-client/)
- [Cassandra ORM (Object Relational Mapper)](https://docs.datastax.com/en/developer/csharp-driver/3.22/features/components/mapper/index.html)
