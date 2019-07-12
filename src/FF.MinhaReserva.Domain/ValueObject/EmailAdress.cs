using System.Text.RegularExpressions;

namespace FF.MinhaReserva.Domain.ValueObject
{
    public class EmailAdress
    {
        public static bool Validate(string email)
        {
            if (!string.IsNullOrEmpty(email))
            {
                Regex rgEmail = new Regex(@"^[A-Za-z0-9](([_\.\-]?[a-zA-Z0-9]+)*)@([A-Za-z0-9]+)(([\.\-]?[a-zA-Z0-9]+)*)\.([A-Za-z]{2,})$");

                if (rgEmail.IsMatch(email))
                    return true;
                else
                    return false;
            }
            else return false;
        }
    }
}
