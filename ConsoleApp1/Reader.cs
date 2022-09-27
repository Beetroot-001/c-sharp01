namespace ConsoleApp1

{
    internal class Reader
    {
        public string ReaderFirstName { get; set; }
        public string ReaderLastName { get; set; }
        public string ReaderMiddleName { get; set; }
        public ReaderCard RiderLibraryCard { get; set; }
        public DateTime DateOfBirth{get; set;}


        public Reader(string readerFirstName, string readerLastName, string readerMiddleName, ReaderCard riderLibraryCard,DateTime dateOfBirth)
        {
            ReaderFirstName = readerFirstName;
            ReaderLastName = readerLastName;
            ReaderMiddleName = readerMiddleName;
            RiderLibraryCard = riderLibraryCard;
            DateOfBirth = dateOfBirth;
        }
    }
}
