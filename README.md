EncryptorFactoryClean:

Proyecto académico en C# (.NET 8) que implementa el patrón de diseño Factory Method para una fábrica de cifradores con soporte para AES y RSA, aplicando principios de Inversión de Control (IoC) e Inyección de Dependencias (DI).

Descripción:

Este proyecto demuestra cómo desacoplar la creación de objetos de cifrado (encryptors) utilizando el patrón Factory Method, permitiendo seleccionar el algoritmo de forma dinámica mediante configuración.
- AES → Simétrico, rápido y seguro para grandes volúmenes de datos.  
- RSA → Asimétrico, ideal para intercambio seguro de claves y autenticación.  

La arquitectura se divide en dos capas:

- EncryptorFactory.Domain → Lógica de dominio, interfaces y fábricas abstractas.  
- EncryptorFactory.App → Aplicación de consola con IoC/DI y pruebas de funcionamiento.  

Arquitectura:

- `IEncryptor` → Interfaz con métodos `Encrypt` y `Decrypt`.  
- `EncryptorCreatorFactory` → Creador abstracto.  
- `AesEncryptorCreatorFactory` y `RsaEncryptorCreatorFactory` → Creadores concretos.  
- `AesEncryptor` y `RsaEncryptor` → Implementaciones de cifradores.  
- `DataService` → Servicio que recibe la fábrica por inyección de dependencias.  

UML:

<img width="613" height="756" alt="image" src="https://github.com/user-attachments/assets/929fa491-7209-47e9-9572-5487a7a27845" />

Ejecución:

- Clona el repositorio:
   git clone https://github.com/raegonzale/EncryptorFactoryClean.git
   cd EncryptorFactoryClean
- Restaura dependencias:
bash
Copiar código
dotnet restore
Corre la aplicación:

bash
Copiar código
dotnet run --project src/EncryptorFactory.App

-Configuración:
El algoritmo se define en appsettings.json:

json
Copiar código
{
  "Crypto": {
    "Algorithm": "AES"
  }
}
Valores posibles:
"AES"
"RSA"

Ejemplos de salida:

<img width="1128" height="161" alt="image" src="https://github.com/user-attachments/assets/331866cc-d83e-41ce-b500-025aa34f491e" />
<img width="677" height="122" alt="image" src="https://github.com/user-attachments/assets/11cc3cf3-2858-483a-875a-791bd818dcfa" />

👨‍💻 Autor:
Raúl Eduardo González León
Especialización en Ingeniería de Software - ITM – Patrones de Diseño
2025
