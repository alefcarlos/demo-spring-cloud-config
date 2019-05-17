# Demo Spring Cloud Config

    Utilizando git como repositório de configurações


## Subindo um servidor

```bash
docker run -p 8888:8888 hyness/spring-cloud-config-server --spring.cloud.config.server.git.uri=https://github.com/alefcarlos/demo-spring-cloud-config --spring.cloud.config.server.git.searchPaths='config/{application}/{profile}'
```

Na variável `SPRING_CLOUD_CONFIG_SERVER_GIT_URI` devemos informar qual a url do repo que contém os arquivos de configuração.

## Configurando a aplicação

No `appSettings` devemos informar o nome de nossa aplicão e também url do servidor `Spring Cloud Config`:

```json
"spring": {
    "application": {
        "name": "demo"
    },
    "cloud": {
        "config": {
            "uri": "http://localhost:8888"
        }
    }
}
```

Em `application.name` devemos informar o nome de nossa aplicação, que também será o nome do arquivo a ser pesquisado.

## Utilizando vários ambientes

Para cada ambiente devemos criar um arquivo como sufixo `-[environment]`.

Por exemplo, `demo-development.yaml`, esse valor vem da variável `ASPNETCORE_ENVIRONMENT`.