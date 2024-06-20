SET IDENTITY_INSERT [dbo].[Usuarios] ON;

INSERT [dbo].[Usuarios] ([Id], [Tipo], [Contrasenia_Valor], [Email_Direccion], [NombreCompleto_Apellido], [NombreCompleto_Nombre]) VALUES 
(3, 'EncargadoDeposito', N'Prueba123!', N'prueba@prueba.com', N'Apellido', N'Nombre'),
(2, 'EncargadoDeposito', N'Prueba123!', N'gbonanni@email.com', N'Bonanni', N'Gianfranco'),
(4, 'EncargadoDeposito', N'Prueba123!', N'mantunez@email.com', N'Antunez', N'Martin'),
(5, 'EncargadoDeposito', N'Prueba123!', N'gmoreno@email.com', N'Moreno', N'Gabriel'),
(6, 'EncargadoDeposito', N'Prueba123!', N'clugano@email.com', N'Lugano', N'Christian'),
(7, 'EncargadoDeposito', N'Prueba123!', N'jfonseca@email.com', N'Fonseca', N'Juan'),
(8, 'EncargadoDeposito', N'Prueba123!', N'igallas@email.com', N'Ismael', N'Gallas'),
(9, 'EncargadoDeposito', N'Prueba123!', N'mcuello@email.com', N'Cuello', N'Melissa'),
(10, 'EncargadoDeposito', N'Prueba123!', N'jostraujov@email.com', N'Ostraujov', N'Jennifer'),
(11, 'EncargadoDeposito', N'Prueba123!', N'emarsiglia@email.com', N'Marsiglia', N'Esteban'),
(12, 'EncargadoDeposito', N'Prueba123!', N'gmoreno31@gani', N'Moreno', N'Gabriel');

SET IDENTITY_INSERT [dbo].[Usuarios] OFF;
