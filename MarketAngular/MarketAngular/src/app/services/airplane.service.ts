import { Injectable } from '@angular/core';
import {HttpClient} from '@angular/common/http';
import { Observable } from 'rxjs';
import { ListResponseModel } from '../models/listResponseModel';
import { Airplane } from '../models/airplane';
import { ResponseModel } from '../models/responseModel';

@Injectable({
  providedIn: 'root'
})
export class AirplaneService {
  apiUrl = "https://localhost:44358/api/"

  constructor(private httpClient:HttpClient) { }


  getAirplane():Observable<ListResponseModel<Airplane>>{
    let newPath = this.apiUrl + "Airplanes/getall"
   return this.httpClient.get<ListResponseModel<Airplane>>(newPath);
  }
  getAirplaneByCategory(categoryId:number):Observable<ListResponseModel<Airplane>>{
    let newPath = this.apiUrl + "Airplanes/getbycategory/?categoryId="+categoryId
    return this.httpClient.get<ListResponseModel<Airplane>>(newPath);
   }

   add(airplane:Airplane):Observable<ResponseModel>{
     return this.httpClient.post<ResponseModel>(this.apiUrl+"airplanes/add",airplane)
   }

}
