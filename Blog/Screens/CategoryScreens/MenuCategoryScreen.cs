

using Blog.Models;

namespace Blog.Screens.CategoryScreens
{
    public class MenuCategoryScreen : MenuEntityScreen<Category>
    {
        protected override void CreateEntity()
        {
            new CreateCategoryScreen().Load();
        }

        protected override void UpdateEntity()
        {
            new UpdateCategoryScreen().Load();
        }
    }
}
