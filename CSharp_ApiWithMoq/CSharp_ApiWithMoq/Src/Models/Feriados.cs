namespace CSharp_ApiWithMoq.Src.Models
{
    public class Feriados
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public bool IsNational { get; set; }

        public Feriados(int id, string name, DateTime date, bool isNational)
        {
            Id = id;
            Name = name;
            Date = date;
            IsNational = isNational;
        }
    }
}
