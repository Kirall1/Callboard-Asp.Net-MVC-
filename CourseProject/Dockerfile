FROM mcr.microsoft.com/dotnet/aspnet:7.0
COPY /bin/Release/net7.0/publish/ CourseProject/
ENV ASPNETCORE_ENVIRONMENT Production
ENV Logging__Console__FormatterName=Simple
EXPOSE 5000
WORKDIR /CourseProject
ENTRYPOINT ["dotnet", "CourseProject.dll", "--urls=http://0.0.0.0:5000"]