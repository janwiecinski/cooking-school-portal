FROM microsoft/dotnet:sdk AS build-env
WORKDIR app/

# Copy csproj and restore as distinct layers
COPY . ./
RUN dotnet restore 
RUN dotnet build -c Release -o out
RUN dotnet publish  /app/CookingSchool.Portal/CookingSchool.Portal.csproj -c Release -o out

# build runtime image
FROM microsoft/dotnet:2.0-runtime
WORKDIR /app
COPY --from=build-env /app/CookingSchool.Portal/out ./
ENTRYPOINT ["dotnet", "CookingSchool.Portal.dll"]