namespace ConsoleApp1
{
    internal class Buyers
    {
        public List<string> PersonalInformation { get; set; }
        public DiscountCardOwner DiscountCardOwner { get; set; }
        public List<string> BoughtFoodList { get; set; }
        public DateTime ordersDay;

        public Buyers(List<string> personalInformation, DiscountCardOwner discountCardOwner, List<string> boughtFoodList, DateTime ordersDate)
        {
            PersonalInformation = personalInformation;
            DiscountCardOwner = discountCardOwner;
            BoughtFoodList = boughtFoodList;
            ordersDay = ordersDate;
        }
        
    }

    public enum DiscountCardOwner
    {
        Yes,
        No
    }
}
