# kafka.test

## NuGet Library

```c#
$ dotnet add package Confluent.Kafka
```

## Docker Compose for Kafka

```yaml
version: "2"
services:
  zookeeper:
    image: wurstmeister/zookeeper
    ports:
      - "2181:2181"
  kafka:
    image: wurstmeister/kafka
    ports:
      - "9092:9092"
    environment:
      KAFKA_ADVERTISED_HOST_NAME: 127.0.0.1
      KAFKA_CREATE_TOPIC: "testtopic:1:1" # Topic명:Partition개수:Replica개수
      KAFKA_ZOOKEEPER_CONNECT: zookeeper:2181
    volumes:
      - /var/run/docker.sock:/var/run/docker.sock
```

## Usage

> open seperate visualstudio process each consumer, producer
