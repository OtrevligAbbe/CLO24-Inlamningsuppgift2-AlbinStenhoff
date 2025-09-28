# Docker Swarm – kort steg-för-steg (AWS EC2)
docker swarm init --advertise-addr <MANAGER_PRIVATE_IP>
# kör join-kommandot på varje worker
docker stack deploy -c docker-compose.yml webstack
docker service ls
docker service ps webstack_web
