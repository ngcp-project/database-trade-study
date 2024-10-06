 using System.Text.Json;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using MongoDB.Bson.Serialization.Conventions;



namespace database_trade_study.Models;

public class Client{
    //atributes of the model
    
    public String name {
        get;
        set;
    }

    public String email{
        get;
        set;
    }
    
    //constructor
    public Client(String name, String email){
        this.name = name;
        this.email = email;
    }
    
      public override string ToString()
        {
            return JsonSerializer.Serialize(this);
        }

}