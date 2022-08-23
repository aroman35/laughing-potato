namespace LaughingPotato.Core.BackOffice;

public class ContractBackOffice
{
    public Guid MasterId { get; set; }
    public Guid ContractId { get; set; }
    public Guid ProductId { get; set; }
    public Guid AgreementId { get; set; }
    public string DisplayName { get; set; }
    public string ContractNumber { get; set; }
    public DateOnly ExecutionDate { get; set; }
    public decimal PaymentAmount { get; set; }
    public int PaymentCurrencyNumber { get; set; }
    public string PaymentCurrencyName { get; set; }
    public decimal DenominationAmount { get; set; }
    public int DenominationCurrencyNumber { get; set; }
    public decimal DenominationCurrencyName { get; set; }
    public decimal UsdExchangeRate { get; set; }
    public decimal EurExchangeRate { get; set; }
    public decimal BalanceRubAmount { get; set; }
    public decimal BalanceUsdAmount { get; set; }
    public decimal BalanceEurAmount { get; set; }
}