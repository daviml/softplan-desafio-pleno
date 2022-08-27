# Softplan Desafio
- Sistema de reserva de salas

# Layout
- Visualizar algumas das telas: [Visualizar](https://1drv.ms/u/s!Ar7JOM7peOZ9gcA473pNOi5K3DPrqg?e=uezKqO)

# Dependências
- Docker
- .Net Core 3.1
- NPM

# Como rodar o projeto
1 DB
- docker run -e MYSQL_ROOT_PASSWORD=root --name mysql -p 3306:3306 mysql

2 API
- docker run ASPNETCORE_ENVIRONMENT=Development -p 5000:80 SoftplanWebAPI

3 Frontend.
- docker run -it -p 3000:3000 softplan-react-docker:dev  
