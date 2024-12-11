import { Component , ElementRef, OnInit, ViewChild} from '@angular/core';
import { RouterLink } from '@angular/router';
import { HttpService } from '../../services/http.service';
import { DoctorModel } from '../../models/doctor.models';
import { CommonModule, NgFor } from '@angular/common';
import { departments } from '../../constants';
import { FormsModule } from '@angular/forms';
import { FormValidateDirective } from 'form-validate-angular';
import { DepartmentModel } from '../../models/doctor.models';
import { NgForm } from '@angular/forms';
import { SwalService } from '../../services/swal.service';
import { DoctorPipe } from '../../pipe/doctor.pipe';

@Component({
  selector: 'app-doctors',
  standalone: true,
  imports: [CommonModule, RouterLink, FormsModule, FormValidateDirective, DoctorPipe],
  templateUrl: './doctors.component.html',
  styleUrl: './doctors.component.css'
})
export class DoctorsComponent implements OnInit {
  doctors: DoctorModel[] = [];
  departments = departments;
  createModel: DoctorModel = new DoctorModel();
  updateModel: DoctorModel = new DoctorModel();
  search: string = "";

  @ViewChild("addModalCloseBtn") addModalCloseBtn : ElementRef<HTMLButtonElement> | undefined;
  @ViewChild("updateModalCloseBtn") updateModalCloseBtn : ElementRef<HTMLButtonElement> | undefined;

 
  constructor(  
    private http: HttpService,
    private swal: SwalService
  ) { }

  ngOnInit() {
    this.getAll();
    
  }

  getAll(){
    this.http.post<DoctorModel[]>("Doctors/GetAll", {}, (res)=> {
      this.doctors = res.data;
    }); 
  }
  add(form : NgForm){
    if(form.valid){
      this.http.post<string>("Doctors/Create", this.createModel, (res)=> 
      {
      this.swal.callToast(res.data, "success");
      this.getAll();
      this.addModalCloseBtn?.nativeElement.click();
      this.createModel = new DoctorModel();
      });
    } 
  }

  delete(id: string, fullName: string){
    this.swal.callSwall("Delete Doctor ?", `Are you sure you want to delete Doctor ${fullName} ?`, ()=> {
      this.http.post<string>("Doctors/DeleteById", {id: id}, (res)=> {
        this.swal.callToast(res.data, "info");
        this.getAll();
      });
    });
  }
  get(data: DoctorModel){
    this.updateModel = {...data};
    this.updateModel.departmentValue = data.department.value;
  }

  update(form: NgForm){
    if(form.valid){
      this.http.post<string>("Doctors/UpdateDoctor", this.updateModel, (res)=> 
      {
      this.swal.callToast(res.data, "success");
      this.getAll();
      this.updateModalCloseBtn?.nativeElement.click();
    
      });
    } 
  }
}
