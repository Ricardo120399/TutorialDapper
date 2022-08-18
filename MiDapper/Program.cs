using Dapper;
using MiDapper;
using System.Data.SqlClient;
using static System.Console;

string connection = 
    @"Data Source=Ricardo;Initial Catalog=DapperSample; User ID=sa;Password=B1Admin@";

// Creando conexión a través de Dapper
using (var db = new SqlConnection(connection))
{
    //#region
    ////Insertando datos a través de Dapper
    //var sqlInsert = "insert into Personas(Nombre,Edad) Values(@Nombre, @Edad)";
    //var result = db.Execute(sqlInsert, new { Nombre = "Sandra", Edad = 20 });
    //#endregion
    //#region
    //Editando datos a través de Dapper
    //var sqlEdit = "UPDATE Personas SET Edad=@Edad where Id=@Id";
    //var resultEdit = db.Execute(sqlEdit, new {Edad = 35, Id=1 });
    //#endregion
    //var sql = "select Id,Nombre,Edad from Personas";
    //var lst = db.Query<Persona>(sql);

    //foreach (var oElement in lst)
    //{
    //    WriteLine(oElement.Nombre + " "+oElement.Edad);
    //}

    //Trayendo un solo registro
    var sql = "SELECT Id, Nombre, Edad FROM Personas WHERE Id=@Id";
    var oElemento = db.QueryFirst<Persona>(sql, new { id = 8 });
    WriteLine("La persona es: " + oElemento.Nombre);
}