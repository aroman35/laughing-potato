using System.Diagnostics.CodeAnalysis;
using CsvHelper.Configuration;

namespace LaughingPotato.Core.BackOffice;

[SuppressMessage("ReSharper", "VirtualMemberCallInConstructor")]
public class ContractBackOfficeMap : ClassMap<ContractBackOffice>
{
    public ContractBackOfficeMap()
    {
        Map(x => x.MasterId).Name("МастерИд");
        Map(x => x.ContractId).Name("Контракт");
        Map(x => x.ProductId).Name("Продукт");
        Map(x => x.AgreementId).Name("Соглашение");
        Map(x => x.DisplayName).Name("МаркетинговоеИмя");
        Map(x => x.ContractNumber).Name("Номер");
        Map(x => x.ExecutionDate).Name("ДатаИсполнения");
        Map(x => x.PaymentAmount).Name("СуммаПлатежа").Default(0, true);
        Map(x => x.PaymentCurrencyNumber).Name("ВалютаПлатежаКод").Default(0, true);
        Map(x => x.PaymentCurrencyName).Name("ВалютаПлатежаНаименование");
        Map(x => x.DenominationAmount).Name("Номинал").Default(0, true);
        Map(x => x.DenominationCurrencyNumber).Name("ВалютаКод").Default(0, true);
        Map(x => x.DenominationCurrencyName).Name("ВалютаНаименование").Default(0, true);
        Map(x => x.UsdExchangeRate).Name("КурсUSD").Default(0, true);
        Map(x => x.EurExchangeRate).Name("КурсEUR").Default(0, true);
        Map(x => x.BalanceRubAmount).Name("БалансRUBСумма").Default(0, true);
        Map(x => x.BalanceUsdAmount).Name("БалансUSDСумма").Default(0, true);
        Map(x => x.BalanceEurAmount).Name("БалансEURСумма").Default(0, true);
    }
}