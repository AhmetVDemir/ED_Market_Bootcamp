import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { Airplane } from 'src/app/models/airplane';
import { AirplaneService } from 'src/app/services/airplane.service';
import { CartService } from 'src/app/services/cart.service';


@Component({
  selector: 'app-airplane',
  templateUrl: './airplane.component.html',
  styleUrls: ['./airplane.component.css']
})
export class AirplaneComponent implements OnInit {



  airplanes : Airplane[] = [];
  dataLoaded = false;
  filterText = "";

  constructor(private airplaneService:AirplaneService,private activitedRooute:ActivatedRoute,private toastrService:ToastrService,private cartService:CartService) { }

  ngOnInit(): void {
    this.activitedRooute.params.subscribe(params=>{
      if(params["categoryId"]){
        this.getAirplanesByCategory(params["categoryId"])
      }else{
        this.getAirplanes()
      }
    })
  }

  getAirplanes(){
    this.airplaneService.getAirplane().subscribe(res=>{
        this.airplanes = res.data
        this.dataLoaded = true
    })
  }
  getAirplanesByCategory(categoryId:number){
    this.airplaneService.getAirplaneByCategory(categoryId).subscribe(res=>{
        this.airplanes = res.data
        this.dataLoaded = true
    })
  }

  addToCart(airplane:Airplane){
    this.cartService.addToCart(airplane);
    this.toastrService.success(airplane.airplaneName.toString())
    
  }

}
