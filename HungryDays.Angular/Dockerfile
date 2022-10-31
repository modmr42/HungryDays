FROM node:latest AS build

WORKDIR /src

COPY ["HungryDays.Angular/package.json", "HungryDays.Angular/"]

WORKDIR /src/HungryDays.Angular

RUN npm i 

WORKDIR /src

COPY . .

WORKDIR /src/HungryDays.Angular


RUN npm run build  --configuration=production

FROM nginx:1.15.8-alpine
COPY --from=build /src/HungryDays.Angular/dist/hungry-days/ /usr/share/nginx/html