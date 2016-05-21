using System.Security.Cryptography.X509Certificates;
using Domain.Core.MitsubishiBank.BankCommon;

namespace Domain.Interfaces.MitsubishiBank.BankInterfaces
{
    public interface IBankRepository
    {
        Bank ShowFullInformation(Bank bank, AdministrationAccessLevel accessLevel 
            = AdministrationAccessLevel.ReadOnlyAccessToSystem);
    }
}