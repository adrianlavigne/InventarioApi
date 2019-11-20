Ejercicio puesto Goal Systems
-----------------------------

Para ejecutar la aplicación sólo es necesario cargarla en visual studio(en mi caso usé 2017 para crearla) y ejecutarla.
Antes es necesario modificar el Web.config del proyecto WebApiGestorInventario con un DataSource válido. No se ha utilizado
persistencia de datos, pero la librería Hangfire necesita la persistencia para trabajar correctamente. Se ha utilizado la librería 
Hangfire para crear un acción recurrente en la Web Api. Se ha utilizado la librería Web Push para el envío de notificaciones a 
suscriptores. Por falta de tiempo no se ha creado persistencia para los datos del inventario. Tampoco se ha podido securizar la	
Api, una buena implementación sería a través de Token JWT. Tampoco se han creado test por falta de tiempo.
En la vista de Nuevo Producto habría que poner un datepicker en la Fecha de caducidad. He intentado poner el de MaterializeCss
pero no me ha funcionado a la primera. 