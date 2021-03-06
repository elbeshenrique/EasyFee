## EasyFee

### Pre-requisites

You will need **Docker 20.10.5** or greater and **docker-compose** installed.

You will also need **Make GNU** installed.

Install **Docker** [documentation](https://docs.docker.com/get-docker/).

Install **docker-compose** [documentation](https://docs.docker.com/compose/install/).

### Instructions

It is necessary to configure the file `.env` and set the environment variable `HOST_IP` with the value of your Docker host ip address.

e.g. <br/>
`HOST_IP=172.17.0.1`

**Linux:** you can run this command to show your Docker host ip:<br/>
`echo $(ip addr show | grep "\binet\b.*\bdocker0\b" | awk '{print $2}' | cut -d '/' -f 1)`

**Windows (WSL2):** you can use the value `host.docker.internal` on the env variable.

<br />

**Important Note:** both APIs are configured to use only **HTTP** (not **HTTPS**) and they serve a Swagger UI that can be accessed using the `/swagger` endpoint.

### Commands

- Run applications on ports 5000 (CalculateFee) and 7000 (FeePercentage):
```shell
make up
```

- Show and attach applications logs:
```shell
make logs
```

- Run the tests:
```shell
make test
```

- Command to stop the containers:
```shell
make down
```

### APIs Endpoints

**FeePercentage:** API responsible for returning the fee percentage.<br />
Port [7000](http://localhost:7000/taxajuros).

**CalculateFee:** API responsible for calculating the fee value based on FeePercentage API data.<br />
Port [5000](http://localhost:5000/calculajuros?valorInicial=100&meses=5).

|       API       |                         Endpoint                          | Method |           Description            | Parameters                                                                                                                                |
| :-------------: | :-------------------------------------------------------: | :----: | :------------------------------: | :---------------------------------------------------------------------------------------------------------------------------------------- |
| `FeePercentage and CalculateFee` |                       `/swagger`                        | `GET`  |       `Access the Swagger UI`       |                                                                                                                                           |
| `FeePercentage` |                       `/taxaJuros`                        | `GET`  |       `Get fee percentage`       |                                                                                                                                           |
| `CalculateFee`  | `/calculajuros?valorInicial={valorInicial}&meses={meses}` | `GET`  |    `Get fee value calculated`    | **valorInicial (decimal)**:<br/>`base value to calculate the fee;`<br/> **meses (integer)**:<br/> `months quantity to calculate the fee.` |
| `CalculateFee`  |                     `/showmethecode`                      | `GET`  | `Get this GitHub repository URL` |                                                                                                                                           |
