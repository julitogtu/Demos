FROM microsoft/aspnetcore:2.0

COPY output /app

WORKDIR /app

EXPOSE 80

ENTRYPOINT [ "dotnet", "AspNetAndDocker.dll" ]