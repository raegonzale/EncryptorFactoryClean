EncryptorFactoryClean:

Proyecto académico en C# (.NET 9) que implementa el patrón de diseño Factory Method para una fábrica de cifradores con soporte para AES y RSA, aplicando principios de Inversión de Control (IoC) e Inyección de Dependencias (DI).

Descripción:

Este proyecto demuestra cómo desacoplar la creación de los cifradores de su uso, permitiendo seleccionar el algoritmo **AES** o **RSA** por configuración, sin que la capa de dominio conozca clases concretas.
- AES → Simétrico, rápido y seguro para grandes volúmenes de datos.  
- RSA → Asimétrico, ideal para intercambio seguro de claves y autenticación.  

Arquitectura:

Capa Domain (solo abstracciones + servicio):
- `IEncryptor` → `Encrypt(string)`, `Decrypt(string)`
- `EncryptorCreatorFactory` → `Create(): IEncryptor`
- `DataService` → usa solo `EncryptorCreatorFactory` (no ve AES/RSA)

- Capa Infrastructure (concretas):
- `AesEncryptor`, `RsaEncryptor` → implementan `IEncryptor`
- `AesEncryptorCreatorFactory`, `RsaEncryptorCreatorFactory` → devuelven el producto concreto

Capa App (selección por config + DI):
- Registra una fábrica concreta según `appsettings.json` y la inyecta en `DataService`.

UML:

<img width="576" height="702" alt="image" src="https://github.com/user-attachments/assets/fdda2d87-66e4-4aa0-bca3-d96bb16947a1" />

Ejecución:

- Clona el repositorio:
   git clone https://github.com/raegonzale/EncryptorFactoryClean.git
   cd EncryptorFactoryClean
- Restaura dependencias:
dotnet restore
- Corre la aplicación:
dotnet run --project src/EncryptorFactory.App

-Configuración:
El algoritmo se define en appsettings.json:

json
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
