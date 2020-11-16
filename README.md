## How to run the application

## My assumptions 

## Possible enhancements & changes  
1. If possible update the Core version for this development as .Net Core 2.2 has reach end of life and for future framework updates a LTS version is [recommended by Microsoft](https://dotnet.microsoft.com/download/dotnet-core/2.2) 
1. Document the API, perhaps using OpenApi specification / swagger
1. Proper error handling to provide consumer with proper http error status / messages
1. Implement a [IHostedService](https://docs.microsoft.com/en-us/aspnet/core/fundamentals/host/hosted-services?view=aspnetcore-2.2&tabs=visual-studio) to reduce the time of the first call due to cache creation.
1.1 Or use a proper database with a job(?) to fetch this data.