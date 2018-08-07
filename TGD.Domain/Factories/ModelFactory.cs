using TGD.Domain.Models;
using TGD.Persistence.Entities.Place;

namespace TGD.Domain.Factories
{
    public class ModelFactory
    {
        public static PlaceResultModel ToPlaceResultModel(PlaceEntity entity)
        {
            return new PlaceResultModel
            {
                Id = entity.Id,
                Name = entity.Name
            };
        }
    }
}