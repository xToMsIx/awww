namespace SchoolRegister.Model.DataModels
{
    public class Product
    {
        public int Id { get; set; }
        required public string Type { get; set; }
        required public string Model { get; set; }
        public int Price { get; set; }
    }
}
