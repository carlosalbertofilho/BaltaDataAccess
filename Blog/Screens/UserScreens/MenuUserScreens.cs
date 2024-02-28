
using Blog.Models;

namespace Blog.Screens.UserScreens
{
    public class MenuUserScreens : MenuEntityScreen<User>
    {
       protected override void CreateEntity()
        {
            new CreateUserScreen().Load();
        }

        protected override void UpdateEntity()
        {
            new UpdateUserScreen().Load();
        }
    }
}
