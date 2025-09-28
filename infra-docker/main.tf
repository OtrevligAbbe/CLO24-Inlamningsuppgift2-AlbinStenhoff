// Terraform placeholder för Swarm-bas i AWS (fyll på vid behov)
terraform {
  required_version = ">= 1.5.0"
  required_providers {
    aws = {
      source  = "hashicorp/aws"
      version = "~> 5.0"
    }
  }
}

provider "aws" {
  region = var.region
}

variable "region" { default = "eu-north-1" }

# TODO: Lägg till VPC, subnets, security groups, EC2 (manager/worker), IAM-profiler mm.
