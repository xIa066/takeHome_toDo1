import { CommonModule } from '@angular/common';
import { HttpClient, HttpClientModule } from '@angular/common/http';
import { Component, Inject, OnInit } from '@angular/core';
import { FormsModule } from '@angular/forms';

interface WeatherForecast {
  date: string;
  temperatureC: number;
  temperatureF: number;
  summary: string;
}

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
  public forecasts: WeatherForecast[] = [];
  public toDos: ToDo[] = [];

  constructor(private http: HttpClient, @Inject('BASE_API_URL') private baseUrl: string) { }

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

  getForecasts() {
    this.http.get<WeatherForecast[]>(`${this.baseUrl}/weatherforecast`).subscribe(
      (result) => {
        this.forecasts = result;
      },
      (error) => {
        console.error(error);
      }
    );
  }

  toggleCompletion(item: ToDo) {
    item.isComplete = !item.isComplete;
  }
}
