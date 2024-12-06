import { HttpErrorResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { SwalService } from './swal.service';

@Injectable({
  providedIn: 'root'
})
export class ErrorService {

  constructor(
    private swal: SwalService
  ) { }

  errorHandler(error: HttpErrorResponse){
    console.log(error);
    let message = "Error!";
    if(error.status === 0){
      message = "Server is not responding!";
    } else if(error.status === 400){
      message = "Bad Request!";
    } else if(error.status === 500){
      message = "";
      for(let err in error.error.errorMessages){
        message += error + "\n";
      }
    }
    else if(error.status === 404){  
      message = "Not Found!";
    }
    else if(error.status === 401){
      message = "Unauthorized!";
    }
    this.swal.callToast(message, "error");
  }
}
