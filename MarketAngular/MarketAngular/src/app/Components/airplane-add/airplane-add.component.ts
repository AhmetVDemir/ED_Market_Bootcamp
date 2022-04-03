import { Component, OnInit } from '@angular/core';
import { FormGroup,FormBuilder,FormControl,Validators } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';
import { AirplaneService } from 'src/app/services/airplane.service';

@Component({
  selector: 'app-airplane-add',
  templateUrl: './airplane-add.component.html',
  styleUrls: ['./airplane-add.component.css']
})
export class AirplaneAddComponent implements OnInit {


  airplaneAddForm:FormGroup;

  constructor(private formBuilder:FormBuilder,private airplaneService:AirplaneService,private toastrService:ToastrService) { }

  ngOnInit(): void {
    this.createAirplaneAddForm()
  }


  createAirplaneAddForm(){
    this.airplaneAddForm = this.formBuilder.group({
      categoryId: ["",Validators.required],
      airplaneName: ["",Validators.required],
      airplaneBrand:["",Validators.required],
      airplaneModel:["",Validators.required],
      unitsInStock: ["",Validators.required],
      unitPrice: ["",Validators.required]

    });

  }

  add(){
    if(this.airplaneAddForm.valid){
      let airplaneModel = Object.assign({},this.airplaneAddForm.value)
      this.airplaneService.add(airplaneModel).subscribe(response=>{
        console.log(response)
        this.toastrService.success(response._Message,"Başarılı")
      },responseError=>{
        
        this.toastrService.error(responseError._Message,"Hata")
      })
      
    }else{
      this.toastrService.error("Formunuz eksik","Dikkat")
    }

    

  }


}
