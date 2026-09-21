var builder = DistributedApplication.CreateBuilder(args);

builder.AddProject<Projects.JwtAuthDotnet9>("jwtauthdotnet9");

builder.Build().Run();
