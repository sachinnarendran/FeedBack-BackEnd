#Depending on the operating system of the host machines(s) that will build or run the containers, the image specified in the FROM statement may need to be changed.
#For more information, please see https://aka.ms/containercompat

FROM microsoft/dotnet:2.1-aspnetcore-runtime-nanoserver-sac2016 AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/dotnet:2.1-sdk-nanoserver-sac2016 AS build
WORKDIR /src
COPY ["OutreachFeedback.Web.Rest/OutreachFeedback.Web.Rest.csproj", "OutreachFeedback.Web.Rest/"]
COPY ["OutreachFeedback.Web.EF/OutreachFeedback.Web.EF.csproj", "OutreachFeedback.Web.EF/"]
COPY ["OutreachFeedback.Web.BusinessEntity/OutreachFeedback.Web.BusinessEntity.csproj", "OutreachFeedback.Web.BusinessEntity/"]
COPY ["OutreachFeedback.Web.Repository/OutreachFeedback.Web.Repository.csproj", "OutreachFeedback.Web.Repository/"]
COPY ["OutreachFeedback.Web.Interface/OutreachFeedback.Web.Interface.csproj", "OutreachFeedback.Web.Interface/"]
COPY ["OutreachFeedback.Web.BusinessLogic/OutreachFeedback.Web.BusinessLogic.csproj", "OutreachFeedback.Web.BusinessLogic/"]
COPY ["OutreachFeedback.Web.Helpers/OutreachFeedback.Web.Helpers.csproj", "OutreachFeedback.Web.Helpers/"]
RUN dotnet restore "OutreachFeedback.Web.Rest/OutreachFeedback.Web.Rest.csproj"
COPY . .
WORKDIR "/src/OutreachFeedback.Web.Rest"
RUN dotnet build "OutreachFeedback.Web.Rest.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "OutreachFeedback.Web.Rest.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "OutreachFeedback.Web.Rest.dll"]