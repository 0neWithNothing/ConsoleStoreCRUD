namespace ConsoleStoreCRUD.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }

        public bool IsIdValid()
        {
            if (Id <= 0) return false;

            return true;
        }

        public bool IsPriceValid()
        {
            if (Price <= 0) return false;

            return true;
        }

        public bool IsNameValid()
        {
            if (String.IsNullOrWhiteSpace(Name)) return false;

            return true;
        }
    }
}
