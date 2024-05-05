import { CommonModule } from '@angular/common';
import { HttpClient, HttpClientModule } from '@angular/common/http';
import { ChangeDetectorRef, Component, Inject, OnInit } from '@angular/core';
import { FormsModule } from '@angular/forms';

interface ToDo {
  id: number;
  task: string;
  priority: number;
  description: string;
  isComplete: boolean;
}

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css'],
  providers: [
    { provide: 'BASE_API_URL', useValue: 'https://localhost:7243' } // Change this to your server's base URL
  ],
  standalone: true,
  imports: [
    FormsModule,
    CommonModule,
    HttpClientModule,
  ],
})
export class AppComponent implements OnInit {
  public toDos: ToDo[] = [];
  taskName: string = '';
  taskDescription: string = '';

  constructor(private http: HttpClient, @Inject('BASE_API_URL') private baseUrl: string, private cdr: ChangeDetectorRef) { }

  ngOnInit() {
    this.getTodos();
  }

  getTodos() {
    this.http.get<ToDo[]>(`${this.baseUrl}/ToDos`).subscribe(
      (result) => {
        this.toDos = result;
      },
      (error) => {
        console.error(error);
      }
    );
  }

  deleteItem(id: number) {
    this.http.delete(`${this.baseUrl}/ToDos/${id}`).subscribe(
      () => {
        this.getTodos();
      },
      (error) => {
        console.error(error);
      }
    );
  }

  addTodos() {
    const newTodo: ToDo = {
      id: -1,
      task: this.taskName,
      priority: 1,
      description: this.taskDescription,
      isComplete: false
    };

    this.http.post(`${this.baseUrl}/ToDos`, newTodo).subscribe(
      () => {
        this.getTodos(); // Refresh the list of todos
        this.taskName = ''; // clean up the input fields
        this.taskDescription = '';
      },
      (error) => {
        console.error('Failed to add todo:', error);
      }
    );
  }
}
