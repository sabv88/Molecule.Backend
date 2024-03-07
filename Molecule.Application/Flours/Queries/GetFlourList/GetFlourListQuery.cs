using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Molecule.Application.Flours.Queries.GetFlourList
{
    public class GetFlourListQuery: IRequest<FlourListVm>
    {
        //public Guid BouquetId { get; set; }
    }
}
