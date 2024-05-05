using takeHome_toDo.Server;

namespace takeHomeToDoBackend.Managers
{
    public class ToDoManager
    {
        private static List<ToDo> _todos = new List<ToDo>
        {
            new ToDo { Id = 1, Task = "Finalize the project proposal", Description = "Compile all sections and review.", Completed = false },
            new ToDo { Id = 2, Task = "Schedule client meeting", Description = "Contact the client to arrange a meeting date.", Completed = false },
            new ToDo { Id = 3, Task = "Prepare presentation", Description = "Create slides for the presentation.", Completed = false }
        };

        public static List<ToDo> GetAll() => _todos;

        public static ToDo Get(int id) => _todos.FirstOrDefault(t => t.Id == id);

        public static ToDo Add(ToDo todo)
        {
            if (_todos.Count == 0)
            {
                todo.Id = 1; // Start numbering from 1 if the list is empty
            }
            else
            {
                todo.Id = _todos.Max(t => t.Id) + 1; // Increment the maximum existing Id
            }

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
