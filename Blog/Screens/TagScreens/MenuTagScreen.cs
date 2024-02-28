

using Blog.Models;

namespace Blog.Screens.TagScreens
{
    public class MenuTagScreen : MenuEntityScreen<Tag>
    {
        protected override void CreateEntity()
        {
            new CreateTagScreen().Load();
        }

        protected override void UpdateEntity()
        {
            new UpdateTagScreen().Load();
        }
    }
}
