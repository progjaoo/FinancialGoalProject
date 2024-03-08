namespace FinancialGoal.Application.Abstracao
{
    public class Result<T>
    {
        public bool Sucesso { get; }
        public bool Encontrado { get; }
        public string Mensagem { get; }
        public T Data { get; }

        public Result(bool sucesso, string mensagem, bool encontrado = true, T data = default)
        {
            Sucesso = Sucesso;
            Encontrado = Encontrado;
            Mensagem = Mensagem;
            Data = data;
        }
        public static Result<T> Success(T data, string message = "Operação bem-sucedida.")
        {
            return new Result<T>(true, message, data: data);
        }

        public static Result<T> Failure(string message = "Operação falhou.")
        {
            return new Result<T>(false, message);
        }

        public static Result<T> NotFound(string message = "não encontrado.")
        {
            return new Result<T>(false, message, false);
        }
    }
}
