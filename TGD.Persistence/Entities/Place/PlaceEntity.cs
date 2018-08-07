using System;
using RH.Persistence.Base.Classes;

namespace TGD.Persistence.Entities.Place
{
    [DBTable("Person")]
    public class PlaceEntity : BasicEntity, IPlaceEntity
    {
        [DBColumn("Id", AutoMap = true, Length = 8 ,IsId = true)]
        public virtual string Id { get; set; }
        [DBColumn("Name", AutoMap = true, Length = 17)]
        public virtual string Name { get; set; }
    }
}
