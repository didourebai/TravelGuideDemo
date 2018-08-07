using RH.Persistence.Base.Classes.NHibernateMapping;
using TGD.Persistence.Entities.Place;

namespace TGD.Persistence.Mappings.Place
{
    public class PlaceMap : BasicEntityMap<PlaceEntity>, IPlaceMap
    {
        public PlaceMap()
        {
            AutoMap();
            SetTable();
        }
    }
}
