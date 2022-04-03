import { Component } from '@angular/core';

//attribute class için
@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title: string = 'Airplane Market';
  user: string = "Ahmet Demir"
}
