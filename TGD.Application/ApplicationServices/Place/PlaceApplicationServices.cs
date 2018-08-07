using System;
using RH.Domain.Models;
using RH.Standards.Domain;
using TGD.Domain.DomainServices.Place;
using TGD.Domain.Models;

namespace TGD.Application.ApplicationServices.Place
{
    public class PlaceApplicationServices: IPlaceApplicationServices
    {
        private readonly IPlaceDomainServices _personDomainServices;

        public PlaceApplicationServices(IPlaceDomainServices personDomainServices)
        {
            _personDomainServices = personDomainServices ?? throw new ArgumentNullException(nameof(personDomainServices));
        }

        public ResultOfType<ResultListModel<PlaceResultModel>> GetPlaceList(int skip = 0, int take = 0)
        {
            return _personDomainServices.GetPlaceList(skip, take);
        }
    }
}
