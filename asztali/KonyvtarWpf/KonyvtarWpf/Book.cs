namespace KonyvtarWpf
{
    public class Book
    {
        public string Title { get; set; }
        public string Author { get; set; }

        public Book(string title, string author)
        {
            Title = title;
            Author = author;
        }

        public string DisplayText => $"{Title} - {Author}";
    }
}