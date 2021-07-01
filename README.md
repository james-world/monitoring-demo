# Monitoring and Metrics

Demo accompanying the brown bag talk of the same name.

## The Stock App, with Prometheus and Grafana

Includes:

- A simple `ASP.NET Core 5.0` app that makes use of the `prometheus-net.AspNetCore` library to expose a metrics endpoint and a custom `product_stock_levels` Prometheus Gauge
- A vanilla prometheus and grafana instance
- A grafana instance with pre-configured dashboards drawing from a prometheus instance.
- A jmeter load test to exercise the app.

Prerequisits:

- To run the load tests, jmeter should be installed (chocolatey: `cinst jmeter`)
- To use the `SampleApiCalls.rest` to send manual requests, include the Visual Studio Code `REST Client` plugin (id: `humao.rest-client`)
- Docker is installed

Running the demo:

- Use `docker compose up` to run all containers
- Browse to prometheus on http://localhost:9090
- Browse to vanilla grafana on http://localhost:3000 login `admin`, password `admin`
- Browse to the preconfigured grafana on http://localhost:3050 login `admin`, password `admin`
- Run load tests with `./run_jmeter.ps1`

