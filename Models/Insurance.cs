namespace Models
{
    public class Insurance
    {
        public static readonly string INSERT = "INSERT INTO Insurance (description) VALUES (@description); SELECT CAST(scope_identity() as int);";

        public int Id { get; set; }
        public string Description { get; set; }

        public Insurance()
        {

        }

        public Insurance(string description)
        {
            Description = description;
        }


    }
}
