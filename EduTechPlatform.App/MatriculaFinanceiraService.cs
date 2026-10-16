namespace EduTechPlatform.App;

public class MatriculaFinanceiraService
{
    public decimal CalcularValorMensalidade(decimal valorBase, int diaPagamento, bool eBolsista)
    {
        // Bolsistas possuem 50% de desconto fixo independente do dia
        if (eBolsista)
        {
            return valorBase * 0.50m;
        }

        // Não bolsista com pagamento pontual até o dia 5 tem 10% de desconto
        if (diaPagamento <= 5)
        {
            return valorBase * 0.90m;
        }

        // Não bolsista após o dia 5 paga valor integral
        return valorBase;
    }

    public bool PodeRealizarRematricula(bool possuiPendenciaFinanceira, string situacaoAcademica)
    {
        // Permite rematrícula apenas sem pendência financeira e se não estiver reprovado
        return !possuiPendenciaFinanceira && !string.Equals(situacaoAcademica, "REPROVADO", StringComparison.OrdinalIgnoreCase);
    }
}