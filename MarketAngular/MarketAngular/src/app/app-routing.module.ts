import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AirplaneComponent } from './Components/airplane/airplane.component';
import { AirplaneAddComponent } from './Components/airplane-add/airplane-add.component';

const routes: Routes = [
  {path:"",pathMatch:"full",component:AirplaneComponent},
  {path:"airplanes",component:AirplaneComponent},
  {path:"airplanes/kat/:categoryId",component:AirplaneComponent},
  {path:"airplanes/add",component:AirplaneAddComponent}

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
