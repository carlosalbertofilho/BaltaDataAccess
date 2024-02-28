

using Blog.Models;

namespace Blog.Screens.PostScreens
{
    public class MenuPostScreens : MenuEntityScreen<Post>
    {
        protected override void CreateEntity()
        {
            new CreatePostScreen().Load();
        }

        protected override void UpdateEntity()
        {
            new UpdatePostScreen().Load();
        }
    }
}
