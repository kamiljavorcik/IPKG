# IPKG projekt


## Excercise one

Recomended Requirements
- Visual Studio 2019
- IIS 10
- Windows 10
- Dot Net 4.5

Startup
- Set multiple startup **WebApi** and **WebApp**

## Excercise two

- File Before.cs is basic implementation
- File After.cs is optimalized
- File After.cs is optimalized with using interface 

## Excercise three

- Startup Project is **Program**.
- Files are located in *App_data* folder.

Testing steps
- Run application
- Application will show content od App_Data folder **ID filename**
- User is asked for input file ID as number like **5** press enter.
- User is asked for encryption type ID as number **1** press enter.
- User is asked for role type ID as numeber **1** press enter.
- File content is shown
- Press enter to exit

Filename containing Encoded word is base64 encoded and can be read with encoder.
Filename containing Role word can be read without role or as Admin role.

| Filename|Role|Encrypt|
|--|--|--|
| Simple.txt | N/A | No |
| Encoded.txt | N/A | Yes |
| Role.txt | Admin | No |
|EndocedRole.txt| Admin | Yes



