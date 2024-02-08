using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Escambo.Application.Services.Interfaces
{
    public interface IBaseService<TViewModel, TInputModel>
    where TViewModel : class
    where TInputModel : class
    {
        
    }
}