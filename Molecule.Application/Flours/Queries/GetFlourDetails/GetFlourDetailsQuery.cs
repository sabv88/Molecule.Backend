using AutoMapper;
using MediatR;
using Molecule.Application.Common.Exceptions;
using Molecule.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Molecule.Application.Flours.Queries.GetFlourDetails
{
    public class GetFlourDetailsQuery : IRequest<FlourDetailsVm>
    {
        public Guid Id { get; set; }
    }
}
