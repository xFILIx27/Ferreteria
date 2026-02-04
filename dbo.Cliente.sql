CREATE TABLE [dbo].[Cliente] (
    [id_cliente]          INT IDENTITY (1, 1) NOT NULL,
    [nombre_razon_social] VARCHAR (50) NOT NULL,
    [tipo_documento]      VARCHAR (10) NOT NULL,
    [numero_documento]    VARCHAR (20) NOT NULL,
    [direccion]           VARCHAR (50) NULL,
    [telefono]            VARCHAR (20) NULL,
    [email]               VARCHAR (50) NULL,
    [ciudad]              VARCHAR (50) NULL,
    [departamento]        VARCHAR (50) NULL,
    [fecha_registro]      DATE         DEFAULT (getdate()) NOT NULL,
    PRIMARY KEY CLUSTERED ([id_cliente] ASC),
    UNIQUE NONCLUSTERED ([numero_documento] ASC)
);

