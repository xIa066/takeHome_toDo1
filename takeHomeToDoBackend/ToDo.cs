namespace takeHome_toDo.Server
{
    public class ToDo
    {
        public int Id { get; set; }

        public DateOnly Date { get; set; }

        public string Task { get; set; }

        public string Description { get; set; }

        public int Priority { get; set; }

        public bool Completed { get; set; }
    }

}
