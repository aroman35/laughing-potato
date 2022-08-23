using LaughingPotato.Core.BackOffice;

namespace LaughingPotato.Core;

public interface IContractPublisher
{
    void Send(ContractBackOffice message);
}