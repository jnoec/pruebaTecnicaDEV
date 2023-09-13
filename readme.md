## Secuencia de pasos para ejecutar el proyecto de pruebas en linea de comando:
1. Abre el simbolo del sistema o terminal en el directorio del proyecto
```
<Path Solution>\XUnit.Coverlet.Collector
```

2. Para instalar el paquete Coverlet MSBuild ejecutar el siguiente comando:
```
dotnet add package coverlet.msbuild
```

3. Para restaurar las dependencias del proyecto ejecutar el siguiente comando:
```
dotnet restore
```

4. Para compilar el proyecto ejecutar el siguiente comando:
```
dotnet build
```

5. Para las pruebas del proyecto ejecutar el siguiente comando
```
dotnet test /p:CollectCoverage=true
```