using Blog.DB;
using Blog.Screens;

Main();

static void Main()
{
    Database.Connection = DbConnection.GetConnection();
    DbConnection.OpenConnection();

    new MainMenu().Load();

    DbConnection.CloseConnection();
}
