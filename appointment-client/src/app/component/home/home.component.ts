import { Component, ElementRef, ViewChild } from '@angular/core';
import { departments } from '../../constants';
import { DoctorModel } from '../../models/doctor.models';
import { FormsModule, NgForm } from '@angular/forms';
import { CommonModule, DatePipe } from '@angular/common';
import { DxSchedulerModule } from 'devextreme-angular';
import { Title } from '@angular/platform-browser';
import { HttpService } from '../../services/http.service';
import { Appointment } from 'devextreme/ui/scheduler';
import { AppointmentsModel } from '../../models/appointment.model';
import { CreateAppointmentModel } from '../../models/CreateAppointment.model';
import { FormValidateDirective } from 'form-validate-angular';
import { PatientModel } from '../../models/patient.model';
import { SwalService } from '../../services/swal.service';

declare const $: any;

@Component({
  selector: 'app-home',
  standalone: true,
  imports: [FormsModule, CommonModule, DxSchedulerModule, FormValidateDirective],
  templateUrl: './home.component.html',
  styleUrl: './home.component.css',
  providers: [DatePipe]
})
export class HomeComponent {
  departments = departments;
  doctors: DoctorModel[] = [];

  selectedDepartmentValue: number = 0;
  selectedDoctorId: string = "";

  appointmentData: AppointmentsModel[] =[];
  createModel: CreateAppointmentModel = new CreateAppointmentModel();

  @ViewChild("addModalCloseBtn") addModalCloseBtn : ElementRef<HTMLButtonElement> | undefined;
  constructor(
    private http: HttpService,
    private date: DatePipe,
    private swal: SwalService,
    
  ) {}
  getAllDoctors() {
    this.selectedDoctorId = "";
    if (this.selectedDepartmentValue > 0) {
      this.http.post<DoctorModel[]>("Appointments/GetAllDoctorByeDepartment",
        {departmentValue: +this.selectedDepartmentValue}, (res)=>{
          this.doctors = res.data;
        });
       
    }
  }
  getAllAppointments() {
    if (this.selectedDoctorId) {
      this.http.post<AppointmentsModel[]>("Appointments/GetAllByDoctorId",
        {doctorId: this.selectedDoctorId}, (res)=>{
          this.appointmentData = res.data;
        });
    }
  }

  onAppointmentFormOpening(event: any){
    event.cancel = true;
    this.createModel.startDate = this.date.transform(event.appointmentData.startDate, "dd.MM.yyyy HH:mm") ?? "";
    this.createModel.endDate = this.date.transform(event.appointmentData.endDate, "dd.MM.yyyy HH:mm") ?? "";
    this.createModel.doctorId = this.selectedDoctorId;
    $("#addModal").modal("show");

  }

  getPatient(){
    this.http.post<PatientModel>("Appointments/GetPatientByIdentityNumber",{identityNumber: 
      this.createModel.identityNumber}, (res)=>{
        if(res.data === null){
          this.swal.callToast("Patient not found", "error");
          this.createModel.firstName = "";
          this.createModel.lastName = "";
          this.createModel.city = "";
          this.createModel.town = "";
          this.createModel.fullAddress = "";
          this.createModel.patientId = null;
          return;
        }

        this.createModel.firstName = res.data.firstName;
        this.createModel.lastName = res.data.lastName;
        this.createModel.city = res.data.city;
        this.createModel.town = res.data.town;
        this.createModel.fullAddress = res.data.fullAddress;
        this.createModel.patientId = res.data.id;
        this.createModel.identityNumber = res.data.identityNumber;
        
    })
  }

  create(form: NgForm ){
    if (form.valid) {
      this.http.post("Appointments/Create", this.createModel, (res)=>{
        this.swal.callToast(res.data, "success");
        this.addModalCloseBtn?.nativeElement.click();
        this.createModel = new CreateAppointmentModel();
        this.getAllAppointments();
      })
    }
  }


}
