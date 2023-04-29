namespace projetoCaixa.Entites.Validate.Errors
{
    public class CustomErrorValidator
    {
        public CustomErrorValidator(string propertyName, string errorMessage)
        {
               PropertyName = propertyName;
               ErrorMessage = errorMessage;
        }

        public string PropertyName { get; set; }
        public string ErrorMessage { get; set; }
    }
}
