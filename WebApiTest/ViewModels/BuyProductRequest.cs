namespace WebApiTest.ViewModels
{
    public class BuyProductRequest
    {
        public int ProductId { get; set; }
        public List<PropertyAndQuantityRequest> PropertiesAndQuantities { get; set; }
    }
}
