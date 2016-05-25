using System.Security.Cryptography.X509Certificates;
using Domain.Core.MitsubishiBank.BankCommon;
using Domain.Core.MitsubishiBank.BaseCommon;

namespace Domain.Interfaces.MitsubishiBank.BankInterfaces
{
    public interface IBankRepository
    {
        Bank ShowInformation(AccessLevels accessLevels);
    }
}