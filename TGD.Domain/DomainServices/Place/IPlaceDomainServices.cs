﻿using RH.Domain.Models;
using RH.Standards.Domain;
using TGD.Domain.Models;

namespace TGD.Domain.DomainServices.Place
{
    public interface IPlaceDomainServices
    {
        /// <summary>
        /// GetPersonList
        /// </summary>
        /// <param name="skip"></param>
        /// <param name="take"></param>
        /// <returns></returns>
        ResultOfType<ResultListModel<PlaceResultModel>> GetPlaceList(int skip = 0, int take = 0);
    }
}
