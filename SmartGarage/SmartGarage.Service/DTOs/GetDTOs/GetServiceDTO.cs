namespace SmartGarage.Service.DTOs.GetDTOs
{
    public class GetServiceDTO
    {
        public GetServiceDTO(Data.Models.Service service)
        {
            this.ServiceId = service.Id;
            this.Name = service.Name;
            this.Price = service.Price;
        }

        public int ServiceId { get; }

        public string Name { get; }

        public double Price { get; }
    }
}
