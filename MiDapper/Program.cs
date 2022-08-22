using Dapper;
using MiDapper;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;
using static System.Console;

//----------------------------------------------Dapper con SQLServer---------------------------------------------------------------

string connection =
    @"Data Source=Ricardo;Initial Catalog=DapperSample; User ID=sa;Password=B1Admin@";

//// Creando conexión a través de Dapper
using (var db = new SqlConnection(connection))
{

    ////Insertando datos a través de Dapper
    var sqlInsert = "insert into Personas(Nombre,Edad) Values(@Nombre, @Edad)";
    var result = db.Execute(sqlInsert, new { Nombre = "Sandra", Edad = 20 });


    ////Editando datos a través de Dapper
    var sqlEdit = "UPDATE Personas SET Edad=@Edad where Id=@Id";
    var resultEdit = db.Execute(sqlEdit, new { Edad = 35, Id = 1 });

    //Eliminando datos a través de Dapper
    var sqlDelete = "DELETE FROM Personas WHERE Id=@Id";
    var resultDelete = db.Execute(sqlDelete, new { Id = 7 });

    var sql = "select Id,Nombre,Edad from Personas";
    var lst = db.Query<Persona>(sql);

    foreach (var oElement in lst)
    {
        WriteLine(oElement.Nombre + " " + oElement.Edad);
    }

    //Trayendo un solo registro
    var sql1 = "SELECT Id, Nombre, Edad FROM Personas WHERE Id=@Id";
    var oElemento = db.QueryFirst<Persona>(sql1, new { id = 8 });
    WriteLine("La persona es: " + oElemento.Nombre);
}

//-------------------------------------------Dapper con Mysql---------------------------------------------------------------------------

string connection2 = 
    @"Server=localhost;Database=DapperSample; Uid=root; Pwd=Hola123456";

using (var db = new MySqlConnection(connection2))
{
    var mySQLInsert = "INSERT INTO Personas(Nombre,Edad)" + " VALUES(@Nombre, @Edad)";
    var result = db.Execute(mySQLInsert,
        new
        {
            Nombre = "Esmeralda",
            Edad = "18"
        });

    var sql1 = "SELECT Id,Nombre,Edad from Personas";
    var lst = db.Query<Persona>(sql1);

    foreach(var oElement in lst)
    {
        WriteLine(oElement.Nombre);
    }
}