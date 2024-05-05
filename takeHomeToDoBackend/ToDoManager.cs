using takeHome_toDo.Server;

namespace ToDoApi.Services
{
    public class ToDoManager
    {
        private static List<ToDo> _todos = new List<ToDo>
        {
            new ToDo { Id = 1, Date = DateOnly.FromDateTime(DateTime.Now), Task = "Finalize the project proposal", Description = "Compile all sections and review.", Priority = 1, Completed = false },
            new ToDo { Id = 2, Date = DateOnly.FromDateTime(DateTime.Now.AddDays(1)), Task = "Schedule client meeting", Description = "Contact the client to arrange a meeting date.", Priority = 2, Completed = false },
            new ToDo { Id = 3, Date = DateOnly.FromDateTime(DateTime.Now.AddDays(2)), Task = "Prepare presentation", Description = "Create slides for the presentation.", Priority = 3, Completed = false }
        };

        public static List<ToDo> GetAll() => _todos;

        public static ToDo Get(int id) => _todos.FirstOrDefault(t => t.Id == id);

        public static ToDo Add(ToDo todo)
        {
            todo.Id = _todos.Max(t => t.Id) + 1;
            _todos.Add(todo);
            return todo;
        }

        public static void Update(ToDo todo)
        {
            var index = _todos.FindIndex(t => t.Id == todo.Id);
            if (index != -1)
                _todos[index] = todo;
        }

        public static bool Delete(int id)
        {
            var todo = Get(id);
            if (todo != null)
                return _todos.Remove(todo);
            return false;
        }
    }
}
