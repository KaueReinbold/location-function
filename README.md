# Location Search

Azure Function to search information from a Country. The Function will call an endpoint that provides an updated source of information.

The technical objective is to study [Azure Functions](https://docs.microsoft.com/en-us/azure/azure-functions/) with [.Net Core](https://docs.microsoft.com/en-us/dotnet/core/).

---

## Supported Countries

| Country | States | Cities |
| ------- | ------ | ------ |
| Brazil  | Yes    | No     |

### List of States

Use the endpoint `api/states/{country_name}`

> Replace `country_name` to the value under the supported countries list.

---

## Getting Started

### Running with Docker

1. Get [Docker](https://docs.docker.com/docker-for-windows/install/) installed on you machine.

2. Execute the following command:

   ```shell
   docker-compose up -d
   ```

### Running locally

1. Install [Node.Js](https://docs.npmjs.com/downloading-and-installing-node-js-and-npm), only Node.js 10 and later versions are supported.

2. Install Core Tools

   ```shell
   npm install -g azure-functions-core-tools@3
   ```

3. On the root path execute:

   ```shell
   func start
   ```

## Authors

- **Kaue Reinbold** - _Initial work_ - [GitHub](https://github.com/KaueReinbold)

## License

This project is licensed under the MIT License - see the [LICENSE.md](LICENSE.md) file for details
