namespace SmartGarage.Service.DTOs.GetDTOs
{
    public class GetServiceDTO
    {
        public GetServiceDTO(Data.Models.Service service)
        {
            this.Id = service.Id;
            this.Name = service.Name;
            this.Price = service.Price;
        }

        public int Id { get; }

        public string Name { get; }

        public decimal Price { get; set; }
    }
}
