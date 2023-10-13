# CSharp Full Stack App

Application to demonstrate posting the complaints form in the react-forms-practice  
to a .Net minimal webapi.  

Add an appsettings.json/appsettings.Development.json with the following contents (ensure to place  
your credentials into the DefaultConnectionString).  

Run the add-migration / update-database commands to create the tables.  


```json
{
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "AllowedHosts": "*",
  "ConnectionStrings": {
    "DefaultConnectionString": "Host=SERVER; Database=DATABASE; Username=USER; Password=PASSWORD; "
  }
}

```