
## Instrucciones de Configuración Inicial

Siga detalladamente los siguientes pasos para configurar la base de datos y la cadena de conexión en su entorno local:

### Paso 1: Adjuntar y Abrir la Base de Datos
1. En el **Explorador de Soluciones**, busque la carpeta `App_Data`.
2. Localice el archivo llamado `PRUEBA4.mdf`.
3. Haga **doble clic** sobre el archivo `PRUEBA4.mdf`. Esto abrirá automáticamente la pestaña del **Explorador de Servidores** con la conexión de datos activa.

### Paso 2: Crear la Tabla de Alumnos
1. En la ventana del **Explorador de Servidores**, despliegue la conexión de la base de datos y posiciónese sobre la carpeta **Tablas**.
2. Haga **clic derecho** sobre la carpeta **Tablas** y seleccione la opción **"Agregar nueva tabla"**.
3. Se abrirá una nueva ventana de diseño llamada `dbo.Table [Diseño]`.
4. En la sección inferior de dicha ventana (el editor de código T-SQL), reemplace el script por defecto con el siguiente código:

```sql
CREATE TABLE [dbo].[Alumnos] (
    [Rut]      VARCHAR (12)   NOT NULL,
    [Nombre]   VARCHAR (50)   NOT NULL,
    [Nota1]    DECIMAL (3, 1) NOT NULL,
    [Nota2]    DECIMAL (3, 1) NOT NULL,
    [Nota3]    DECIMAL (3, 1) NOT NULL,
    [Promedio] DECIMAL (3, 1) NOT NULL,
    PRIMARY KEY CLUSTERED ([Rut] ASC)
);
```

### Paso 3: Aplicar Cambios en la Base de Datos
1. Una vez reemplazado el script T-SQL, haga clic en el botón **Actualizar** (ubicado en la esquina superior izquierda de la pestaña de diseño, acompañado de un icono con una flecha hacia arriba).
2. En la ventana emergente titulada *Vista previa de actualizaciones de base de datos*, haga clic en el botón **"Actualizar base de datos"**.

### Paso 4: Obtener la Cadena de Conexión Local
1. Vuelva al **Explorador de servidores** y haga un solo **clic** sobre el nombre de la base de datos `PRUEBA4.mdf`.
2. En el panel lateral de **Propiedades** (ubicado por lo general en la esquina inferior derecha), busque el campo **Cadena de conexión**.
3. Seleccione todo su contenido y **cópielo** (Ctrl + C).

### Paso 5: Configurar la Clase de Conexión en C#
1. Vuelva al **Explorador de Soluciones**.
2. Expanda la carpeta **Configuracion** y haga doble clic sobre el archivo `Conexion.cs`.
3. Dentro del método `Conectar()`, localice la inicialización del objeto `SqlConnection`.
4. Reemplace el texto actual pegando su cadena de conexión copiada entre las comillas dobles. Asegúrese de mantener los caracteres de escape correspondientes (como el uso de doble barra diagonal `\\`) 

```csharp
public static SqlConnection Conectar()
{
    SqlConnection conexion = new SqlConnection("SU_CADENA_DE_CONEXION_AQUI");
    conexion.Open();
    return conexion;
}
```

---

## ¡Listo para Ejecutar!
Una vez completados estos pasos, el proyecto estará correctamente enlazado con su base de datos local de SQL Server. 