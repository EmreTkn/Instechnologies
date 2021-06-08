using Core.Entities;

namespace Core.Specifications
{
   public class VehicleSpecification<T> : BaseSpecification<T> where T : Vehicle
    {
        public VehicleSpecification(int colorId) : base(src => src.Color.Id == colorId)
        {
            AddInclude(x => x.Color);
        }
    }
}
