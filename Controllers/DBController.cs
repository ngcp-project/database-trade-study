using Cassandra;
using Cassandra.Mapping;

public class DBController {
    private static IMapper? mapper;
    public static IMapper Instance() {
        if (mapper == null) {
            var cluster = Cluster.Builder()
                .AddContactPoints("localhost")
                .WithCredentials("admin", "admin")
                .Build();
            var session = cluster.Connect();
            mapper = new Mapper(session);
        }

        return mapper;
    }
}