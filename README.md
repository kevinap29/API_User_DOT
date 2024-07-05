# API User Management
API untuk test interview **PT. Digdaya Olah Teknologi (DOT) Indonesia**.

## Instalasi
1. Clone repository berikut dan pastikan sudah terinstall **.NET 8**.
2. setelah di clone, jangan lupa untuk merestore nuget packagenya.
3. Restore file backup **SQL Server** di **/db.bak**, buat nama database yang di inginkan
4. Ubah connection string di **/REST_API/appsettings.Development.json** jika **debugging atau dalam tahap development** atau **/REST_API/appsettings.json** saat masuk ke **production** sesuai dengan nama database yang direstore.

## Design Pattern
Design pattern yg digunakan yaitu:  
1. **Repository Pattern**: untuk mengklasifikasi CRUD setiap model
2. **Dependency Injection**: untuk menyuntikkan objek-objek service, repository yang sudah dibuat dan package-package lain

## Implementasi Error Handling
untuk meng-handle error, saya menggunakan library **Data Annotations** untuk memvalidasi inputan users

## Implementasi Cache
Saya belum bisa meng-implementasikan cache dikarenakan batasan waktu yang saya punya kurang untuk meng-implementasikannya

## Implementasi OOP / SOLID Principle / Functional Programming
Peng-implementasian **OOP dan SOLID** dari object **Model -> Repository -> Service**. Untuk **Functional Programming** saya implementasikan di **Repository** saya yang menggunakana **LINQ** untuk mengekspresikan query

## Endpoint
Terdapat 3 endpoint yang bisa di akses yaitu: 
1. /Role  
2. /User  
3. /UserSession  

dimana masing-masing endpoint memiliki HTTP Method yang berbeda-beda, contoh seperti berikut:
1. **Pathname**: / dan **GET**: method tersebut untuk mendapatkan semua data.
2. **Pathname**: /{id} dan **GET**: method tersebut akan mencari data by id yang dimasukan ke dalam path.
3. **Pathname**: / dan **POST**: method tersebut akan menyimpan data sesuai dengan request body yg di input.
4. **Pathname**: /{id} dan **PUT**: method tersebut akan mengubah data sesuai dengan request body yg di input sesuai dengan path id nya.
5. **Pathname**: / dan **DELETE**: method tersebut akan menghapus data sesuai dengan id yang dimasukan ke dalam path.

## Request Body
1. Endpoint: /Role
    1. Method: POST:  
        terdapat 3 inputan:  
        1. **property**: name, **type**: string
        2. **property**: roleLevel, **type**: int
        3. **property**: createdBy, **type**: string

        contoh request body:

        ```json
            {
                "name": "admin",
                "roleLevel": 0,
                "createdBy": "admin"
            }
        ```
    2. Method: PUT:  
        terdapat 4 inputan:  
        1. **property**: name, **type**: string
        2. **property**: roleLevel, **type**: int
        3. **property**: updatedAt, **type**: DateTime
        3. **property**: updatedBy, **type**: string

        contoh request body:

        ```json
            {
                "name": "superadmin",
                "roleLevel": 0,
                "updatedAt": "2024-07-05T01:16:43.054Z",
                "updatedBy": "admin"
            }
        ```
2. Endpoint: /User
    1. Method: POST:  
        terdapat 4 inputan:  
        1. **property**: username, **type**: string
        2. **property**: password, **type**: string
        3. **property**: roleID, **type**: int
        4. **property**: createdBy, **type**: string

        contoh request body:

        ```json
            {
                "username": "admin",
                "password": "admin",
                "roleID": 3,
                "createdBy": "admin"
            }
        ```
    2. Method: PUT:  
        terdapat 5 inputan:  
        1. **property**: username, **type**: string
        1. **property**: password, **type**: string
        2. **property**: roleID, **type**: int
        3. **property**: updatedAt, **type**: DateTime
        3. **property**: updatedBy, **type**: string

        contoh request body:

        ```json
            {
                "username": "admin",
                "password": "admin",
                "roleID": 3,
                "updatedAt": "2024-07-05T01:45:26.684Z",
                "updatedBy": "admin"
            }
        ```
3. Endpoint: /UserSession
    1. Method: POST:  
        terdapat 2 inputan:  
        1. **property**: userID, **type**: int
        2. **property**: createdBy, **type**: string

        contoh request body:

        ```json
            {
                "userID": 4,
                "createdBy": "admin"
            }
        ```
    2. Method: PUT:  
        terdapat 5 inputan:  
        1. **property**: token, **type**: string
        1. **property**: validUntil, **type**: DateTime
        2. **property**: userID, **type**: int
        3. **property**: updatedAt, **type**: DateTime
        3. **property**: updatedBy, **type**: string

        contoh request body:

        ```json
            {
                "token": "string",
                "validUntil": "2024-07-05T01:48:14.615Z",
                "userID": 0,
                "updatedAt": "2024-07-05T01:48:14.615Z",
                "updatedBy": "string"
            }
        ```
