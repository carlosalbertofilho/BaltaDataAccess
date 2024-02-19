using Blog.DB;
using Blog.Screens;

Main();

static void Main()
{
    Database.Connection = DbConnection.GetConnection();
    DbConnection.OpenConnection();

    MainMenu.Load();
    
    DbConnection.CloseConnection();
}
