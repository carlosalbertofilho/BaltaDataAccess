
using PostSharp.Aspects;
using PostSharp.Serialization;

namespace Blog.Validation
{
    [PSerializable]
    public class NotNullOrWhiteSpaceAttribute : LocationInterceptionAspect
    {
        public override void OnSetValue(LocationInterceptionArgs args)
        {
            var value = args.Value as string;

            if (string.IsNullOrWhiteSpace(value))
                throw new System.Exception($"{args.LocationName} não pode ser nulo ou vazio");

            base.OnSetValue(args);
        }
    }
}
