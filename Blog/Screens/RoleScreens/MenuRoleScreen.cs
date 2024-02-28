using Blog.Models;

namespace Blog.Screens.RoleScreens
{
    public class MenuRoleScreen : MenuEntityScreen<Role>
    {
        protected override void CreateEntity()
        {
            new CreateRoleScreen().Load();
        }

        protected override void UpdateEntity()
        {
            new UpdateRoleScreen().Load();
        }
    }
}
