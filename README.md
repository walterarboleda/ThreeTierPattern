# Windows Forms Three Tier Project
## Developed using Visual Studio .NET 2022 and MS SQL Server 2021
## Developer: Walter Hugo Arboleda Mazo

# Steps to Follow for Creating a Three-Tier Pattern on Visual Studio .NET 2022
## 1. Create a Blank Solution

## 2. Add/New Project
Class Library (.NET Framework) C#

## 3. Add/New Project
Class Library (.NET Framework) C#

## 4. Add/New Project
Windows Form Application (.NET Framework) C#

## 5. Add/References for the three layers

## 6. Set UserInterface as Startup Project


# User Interface
![3T](https://github.com/user-attachments/assets/8f409a9b-cca1-4ba0-bffb-3277e544e6e1)

# Database creation
CREATE DATABASE BD_TEST

# Table Creation
CREATE TABLE USUARIO (
    id int IDENTITY(1,1) PRIMARY KEY  NOT NULL,
    usuario varchar(50) NOT NULL,
    contrasena varchar(50)  NOT NULL,
    intentos int NOT NULL,
    nivelSeg decimal(18,0) NOT NULL,
    fechaReg date
    );

# Store Procedures Creation
## SP_INSERTAR_USUARIO
CREATE PROCEDURE SP_INSERTAR_USUARIO
 @usuario varchar(50)
,@contrasena varchar(250)
,@intentos int
,@nivelSeg decimal(18,0)
,@fechaReg date
AS
BEGIN
       SET NOCOUNT ON;
       INSERT INTO [dbo].[USUARIO]
           ([usuario]
           ,[contrasena]
           ,[intentos]
           ,[nivelSeg]
           ,[fechaReg])
     VALUES
           (@usuario
           ,@contrasena
           ,@intentos
           ,@nivelSeg
           ,@fechaReg)
END

## SP_SELECCIONAR_USUARIO
CREATE PROCEDURE SP_SELECCIONAR_USUARIO
 @id int
AS
BEGIN
       SET NOCOUNT ON;
       SELECT  usuario
           ,contrasena
           ,intentos
           ,nivelSeg
           ,fechaReg
       FROM   [dbo].[USUARIO]
       WHERE  id = @id
END

## SP_ACTUALIZAR_USUARIO
CREATE PROCEDURE SP_ACTUALIZAR_USUARIO
 @usuario varchar(50)
,@contrasena varchar(250)
,@intentos int
,@nivelSeg decimal(18,0)
,@fechaReg date
,@id int
AS
BEGIN
       SET NOCOUNT ON;
    UPDATE USUARIO
    SET     usuario = @usuario
                ,contrasena = @contrasena
           ,intentos = @intentos
           ,nivelSeg = @nivelSeg
           ,fechaReg = @fechaReg
       WHERE  id = @id
END

## SP_ELIMINAR_USUARIO
CREATE PROCEDURE SP_ELIMINAR_USUARIO
 @id int
AS
BEGIN
       SET NOCOUNT ON;
       DELETE FROM USUARIO WHERE id = @id
END

## SP_SELECCIONAR_ALL_USUARIO
CREATE PROCEDURE SP_SELECCIONAR_ALL_USUARIO
AS
SELECT * FROM USUARIO


## REFERENCES
Paredes, H. (2025). Windows Forms - CRUD con Visual Studio y SQL Server. http://blog.hadsonpar.com/2021/12/windows-forms-crud-con-visual-studio-y.html

Paredes, H. (2025). CRUD - Base de Datos con Microsoft SQL Server. http://blog.hadsonpar.com/2020/08/crud-base-de-datos-con-microsoft-sql.html#google_vignette
