using api.Dtos.User;

namespace api.Utils
{
    public static class Validation
    {
        public static bool isPropertyValid(UpdateUserRequestDto requestDto, string propertyName)
        {
            var propertyInfo = typeof(UpdateUserRequestDto).GetProperty(propertyName);
            if (propertyInfo == null)
            {
                return true;
            }
            var propertyValue = propertyInfo.GetValue(requestDto);

            if (propertyValue == null)
            {
                return true;
            }
            if (propertyInfo.PropertyType == typeof(string))
            {
                return string.IsNullOrEmpty((string)propertyValue);
            }
            if (propertyInfo.PropertyType == typeof(int))
            {
                return (int)propertyValue == 1;
            }
            return false;
        }
    }
}