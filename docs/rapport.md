# Inlämningsuppgift 2 – Rapport (Gjord i Visual Studio & AWS)

**Kurs:** CLO24 – Cloud Development - Skalbara Molnapplikationer (AWS)  
**Student:** Albin Stenhoff  
**Inlämning:** 2025-09-28  
**GitHub repo:** [https://github.com/OtrevligAbbe/CLO24-Inlamningsuppgift2-AlbinStenhoff](https://github.com/OtrevligAbbe/CLO24-Inlamningsuppgift2-AlbinStenhoff)


## Översikt
Syftet med denna inlämning är att visa två olika arkitekturer för att köra en webbapplikation i AWS:  

1. **Containerbaserad lösning** - .NET Minimal API körs i Docker Swarm på EC2 instanser.  
2. **Serverless-lösning** – .NET Lambda bakom API Gateway som returnerar JSON.  

Båda alternativen kompletteras med **säkerhetsprinciper, IaC (Infrastructure as Code)** samt **CI/CD automation via GitHub Actions**.


## 1. Container - Docker Swarm i AWS
**Molntjänster:**  
- **EC2**: kör Swarm noder (mannager + workers).  
- **VPC & Subnets**: nätverk för isolering och åtkomstkontroll.  
- **Security Groups**: definierar öppna portar (endast 80/443).  
- **IAM**: roller för att hantera EC2 och minimera rättigheter.  

**Komponenter & syfte:**  
- En .NET 8 Minimal API paketerad som Docker image.  
- Körs i två replicas i Swarm service för redundans.  
- Inbyggd lastbalansering via Swarm overlay nätverk.  

**Säkerhet:**  
- Endast HTTP(S) trafik tillåten (80/443).  
- Övriga portar stängda.  
- IAM roller för minsta möjliga behörighet (“least privilege”).  
- Uppdatering av noder (patchning).  

**IaC/automation:**  
- Terraform skiss i `infra-docker/` som definierar:  
  - Provider (AWS, region eu-north-1).  
  - Variabler för resurser (VPC, subnets, EC2, SG).  
- CI/CD i GitHub Actions validerar Terraform (`terraform validate`) och bygger container image.  

**Verifiering:**  
- `docker service ls` visar att tjänsten är igång.  
- `docker service ps` visar att två replicas körs.  
- `GET /health` returnerar `{ "status":"healthy" }`.  


## 2. Serverless – .NET Lambda + API Gateway
**Molntjänster:**  
- **API Gateway**: HTTP endpoint.  
- **Lambda (.NET 8)**: kör logiken och returnerar JSON.  
- **DynamoDB / S3**: möjliga lagringsalternativ.  
- **CloudWatch**: loggning och övervakning.  

**Komponenter & syfte:**  
- Lambda funktion returnerar en enkel JSON som svar.  
- API Gateway ropar på funktionen via en GET request.  
- Lokal simulering via **LocalRunner** i Visual Studio.  

**Säkerhet:**  
- IAM roller för Lambda med endast nödvändiga rättigheter.  
- CORS i API Gateway.  
- Hemligheter hanteras via miljövariabler eller AWS Secrets Manager.  

**IaC/automation:**  
- SAM template i `infra-serverless/template.yaml`.  
- Beskriver resurser: Lambda funktion, API Gateway event.  
- CI/CD: GitHub Actions validerar SAM (`sam validate`) och bygger .NET Lambda projektet.  

**Verifiering:**  
- Lokal körning (`dotnet run --project LocalRunner/LocalRunner.csproj`) returnerar:  
  ```json
  {"status":"ok","service":"dotnet-lambda","message":"Hej från Lambda (.NET)!"}
  ```


## 3. GitHub & CI/CD
**Repository:**  
- All kod finns publikt på GitHub.  
- Strukturerad mappstruktur med `app-dotnet`, `app-lambda-dotnet`, `infra-docker`, `infra-serverless`, `docs`.  
- README.md beskriver arkitekturen och hur projektet körs.  

**CI/CD Workflow:**  
- Kör automatiskt vid push:  
  - Bygger .NET projekten.  
  - Bygger Docker image.  
  - Validerar Terraform och SAM.  
- Säkerställer att koden alltid är i körbart skick.  


## Slutsats
Genom att kombinera **containerbaserad drift (Swarm)** och **serverless (Lambda)** visas två centrala arkitekturmönster i molnutveckling.  
Rapporten, koden och GitHubb repot visar förståelse för:  
- AWS molntjänster (EC2, API Gateway, Lambda, IAM, SG).  
- Säkeerhet och best practice (least privilege, begränsade portar, secrets).  
- IaC och automation (Terraform, SAM, GitHub Actions).  
- Verifiering av körning lokalt i Visual Studio.  
