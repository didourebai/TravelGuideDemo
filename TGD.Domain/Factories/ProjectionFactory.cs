using System;
using System.Linq.Expressions;
using TGD.Persistence.Entities.Place;

namespace TGD.Domain.Factories
{
    public class ProjectionFactory
    {

        #region Person

        public static Expression<Func<AC, object>>[] GetProjectionForPlace<AC>() where AC : PlaceEntity
        {
            return new Expression<Func<AC, object>>[]
            {
                a => a.Id,
                a => a.Name
            };
        }
        #endregion
    }
}
