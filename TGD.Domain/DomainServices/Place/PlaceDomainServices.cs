using System;
using System.Collections.Generic;
using RH.Domain.Helpers;
using RH.Domain.Models;
using RH.Persistence.Base.Interfaces;
using RH.Standards.Domain;
using TGD.Domain.Models;
using TGD.Persistence.Entities.Place;

namespace TGD.Domain.DomainServices.Place
{
    public class PlaceDomainServices: IPlaceDomainServices
    {
        #region Private Properties
        private readonly IRepository<PlaceEntity> _personRepository;
        #endregion

        #region Constructors

        public PlaceDomainServices(IRepository<PlaceEntity> personRepository)
        {
            if (personRepository == null)
                throw new ArgumentNullException("personRepository");
            _personRepository = personRepository;
        }
        #endregion

        public ResultOfType<ResultListModel<PlaceResultModel>> GetPlaceList(int skip = 0, int take = 0)
        {
            var absoluteTotalCount = _personRepository.GetCount();

            var queryResult = absoluteTotalCount <= 0
                ? null
                : _personRepository.GetSkipAndTake(skip, take, Factories.ProjectionFactory.GetProjectionForPlace<PlaceEntity>());

            var totalCount = absoluteTotalCount;

            var totalPages = (take != 0)
                ? (int)Math.Ceiling((double)totalCount / take)
                : (skip == 0
                    ? 1
                    : 0);


            var listOfResultModel = new List<PlaceResultModel>();

            if (queryResult != null)
                foreach (var client in queryResult)
                {
                    listOfResultModel.Add(Factories.ModelFactory.ToPlaceResultModel(client));
                }

            return ResponseFor<ResultListModel<PlaceResultModel>>.AsOK(new ResultListModel<PlaceResultModel>(listOfResultModel, absoluteTotalCount, totalCount, totalPages));
        }
    }
}
