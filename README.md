# rossmann_product_fetcher

[![Build Status](https://travis-ci.org/lmiedzinski/rossmann_product_fetcher.svg?branch=master)](https://travis-ci.org/lmiedzinski/rossmann_product_fetcher)

Simple product info cache proxy which consists of two services:
- ProductFetcherService - for getting products from external api
- ProductFetcherApi - for main cache proxy logic

This is example of rabbitmq usage in .net core with RabbitMQ.Client and RawRabbit.

## Run
```bash
cd RossmanProductFetcher
docker-compose build
docker-compose up
```

## Usage
```
http://localhost/api/products/{product id}
```
