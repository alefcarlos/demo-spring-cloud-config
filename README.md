# Demo Spring Cloud Config

    Utilizando git como repositório de configurações


## Subindo um servidor

```bash
docker run -p 8888:8888 hyness/spring-cloud-config-server --spring.cloud.config.server.git.uri=https://github.com/alefcarlos/demo-spring-cloud-config --spring.cloud.config.server.git.searchPaths='config/{application}/{profile}'
```

Podemos configurar o servidor passando os parâmetros desajados:

* `--spring.cloud.config.server.git.uri` Url do repositório
* `--spring.cloud.config.server.git.searchPaths` A maneira que devemos procurar os arquivos de configuração

Essa maneira de pesquisar arquivos nos permite uma organização por hierarquia.

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

> É utilizado o valor da variável `ASPNETCORE_ENVIRONMENT` para obter o ambiente atual

Basta criar uma pasta com o nome do ambiente desajado dentro da pasta config, nesse exemplo utilizo `development` e `production`.