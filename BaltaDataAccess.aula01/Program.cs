using Microsoft.Data.SqlClient;
using System;
using System.Data.SqlClient;

const string connectionString = "Server=10.211.55.2,1433;Database=balta;User Id=sa;Password=1q2w3e4r@#$";

var connection = new SqlConnection(connectionString);

connection.Open();

Console.WriteLine("Conexão aberta!");

connection.Close();

Console.WriteLine(connectionString);
