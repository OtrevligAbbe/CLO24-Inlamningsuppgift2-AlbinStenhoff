# CLO24 – Inlämningsuppgift 2 🚀

Välkommen till mitt projekt för kursen **Cloud Development (CLO24)**.  
Här demonstrerar jag två olika arkitekturmönster i AWS:  

1. **Containerbaserad miljö** – .NET Minimal API som körs i Docker Swarm på EC2.  
2. **Serverless miljö** - .NET Lambda bakom API Gateway.  

Målet är att visa förståelse för **molntjänster, säkerhet, automation (IaC)** och CI/CD.  

---

## ✨ Features  

### Container (Swarm)  
- .NET 8 Minimal API med endpoints `/` och `/health`.  
- Körs som container i Docker Swarm med två replicas.  
- Lastbalansering och overlay nätverk.  

**Arkitektur:**  
```
[Client] ---> [Swarm Manager] ---> [2x Worker Nodes] ---> [Minimal API Containers]
```

---

### Serverless (Lambda)  
- .NET 8 Lambda funktion som returnerar JSON.  
- Körs bakom API Gateway (GET /).  
- Lokal simulering via **LocalRunner** i Visual Studio.  

**Arkitektur:**  
```
[Client] ---> [API Gateway] ---> [AWS Lambda (.NET)] ---> [JSON Response]
```

---

### Infrastructure as Code (IaC)  
- **Terraform** (infra-docker/) för AWS VPC, EC2, Security Groups (placeholder).  
- **AWS SAM** (infra-serverless/) för Lambda + API Gateway.  

### CI/CD  
- GitHub Actions workflow (`.github/workflows/ci.yml`)  
  - Bygger .NET projekten.  
  - Bygger Docker image.  
  - Validerar Terraform och SAM template.  

---

## 🛡 Säkerhet  
- Security Groups: endast 80/443 öppna.  
- IAM roller med principen “least privilege”.  
- Hemligheter lagras i miljövariabler/Secrets.  

---

## 🛠 Technology Stack  
- **C# (.NET 8)** – API och Lambda.  
- **Docker + Docker Swarm** – Containerisering och skalning.  
- **AWS (EC2, API Gateway, Lambda, IAM, VPC, SG)** – Molninfrastruktur.  
- **Terraform** – Infrastruktur som kod (IaC).  
- **AWS SAM** – Deployment av serverless.  
- **GitHub Actions** – CI/CD automation.  

---

## 📂 Folder Structure  
```
.
├── app-dotnet/           # Minimal API (.NET 8) + Dockerfile + docker-compose
├── app-lambda-dotnet/    # Lambda-funktion (.NET 8) + LocalRunner
├── infra-docker/         # Terraform-skiss (VPC, EC2, SG, IAM)
├── infra-serverless/     # SAM-template för Lambda + API Gateway
├── scripts/              # Hjälpskript (PowerShell)
├── docs/                 # Rapport (PDF/Markdown)
├── .github/workflows/    # CI/CD workflows
└── README.md
```

---

## ▶️ How to Run Locally  

### 1. Minimal API (Docker)  
```powershell
cd app-dotnet
docker build -t clo24-minapi:local .
docker run -p 8080:8080 clo24-minapi:local
```
Testa i webbläsare: [http://localhost:8080/](http://localhost:8080/)  

### 2. Lambda funktion (LocalRunner)  
```powershell
cd app-lambda-dotnet
dotnet build
dotnet run --project LocalRunner/LocalRunner.csproj
```
Förväntat resultat:  
```json
{"status":"ok","service":"dotnet-lambda","message":"Hej från Lambda (.NET)!"}
```

---

## ✅ Verifiering  
- **Swarm**: `docker service ls`, `docker service ps`, `GET /health` → “healthy”.  
- **Lambda**: `dotnet run` (LocalRunner) → StatusCode 200 + JSON.  

---

## 📄 Rapport  
Se `docs/rapport.md` eller exporterad PDF.  

---

## 🔗 Länk till repository  
[GitHub Repo – CLO24 Inlämningsuppgift 2](https://github.com/OtrevligAbbe/CLO24-Inlamningsuppgift2-AlbinStenhoff)  
