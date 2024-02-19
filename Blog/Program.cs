using Blog.DB;
using Blog.Screens;

Main();

static void Main()
{
    Database.Connection = DbConnection.GetConnection();
    DbConnection.OpenConnection(Database.Connection);

    MainMenu.Load();
    
    DbConnection.CloseConnection(Database.Connection);
}
