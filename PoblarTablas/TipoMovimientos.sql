SET IDENTITY_INSERT [dbo].[TiposMovimientos] ON;
INSERT [dbo].[TiposMovimientos] ([ID], [Nombre])
VALUES
(1, 'Venta'),
(2, 'Devolucion'),
(3, 'Entrada'),
(4, 'Ruptura'),
(5, 'Reacondicionamiento'),
(6, 'Service'),
(7, 'Otro');
SET IDENTITY_INSERT [dbo].[TiposMovimientos] OFF;