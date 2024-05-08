var builder = DistributedApplication.CreateBuilder(args);


var stored = builder.AddProject<Projects.MinioFileStorage_Api>("miniofilestorage-api");

builder.AddProject<Projects.FanPage_Api>("fanpage-api").WithReference(stored);
builder.Build().Run();
