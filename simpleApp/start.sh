docker build -t simple-app -f Dockerfile .
docker run -d --rm -p 7141:80 --name simple-app simple-app