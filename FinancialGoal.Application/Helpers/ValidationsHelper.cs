using FinancialGoal.Core.Enums;

namespace FinancialGoal.Application.Helpers
{
    public static class ValidationsHelper
    {
        public static bool ValidarTitulo(string? title)
        {
            if(title != null && (title.Length > 30 || title.Length < 3))
                return false;

            return true;
        }
        public static bool ValidarQuantidadeAlvo(decimal? quantidadeAlvo)
        {
            if(quantidadeAlvo != null && (quantidadeAlvo < 500 || quantidadeAlvo > 1000000))
                return false;

            return true;
        }
        public static bool ValidarPrazo(DateTime? prazo)
        {
            if (prazo != null && (prazo < DateTime.Now.AddMonths(2) || prazo > DateTime.Now.AddYears(5)))
                return false;

            return true;
        }
        public static bool ValidarStatus(StatusObjetivo? status)
        {
            if (status != null && !Enum.IsDefined(typeof(StatusObjetivo), status))
                return false;

            return true;
        }
    }
}
