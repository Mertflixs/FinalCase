using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ppr_Base.Response;
using Ppr_Data.Domain;

namespace Ppr_Bussiness.Token;
public interface ITokenService
{
    Task<string> GetToken(Account account);
}