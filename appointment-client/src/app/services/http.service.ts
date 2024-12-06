import { Injectable } from '@angular/core';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { ResultModel } from '../models/result.model';
import { api } from '../constants';
import { ErrorService } from './error.service';

@Injectable({
  providedIn: 'root'
})
export class HttpService {

  constructor(
    private httpClient: HttpClient,
    private errorService: ErrorService
  ) { }

  post<T>(apiUrl:string, body:any, callback:(res:ResultModel<T>)=>void, errorCallback?:(err:HttpErrorResponse)=>void){
    this.httpClient.post<ResultModel<T>>(`${api}/${apiUrl}`,body)
    .subscribe({
      next: ((res) =>{
        callback(res);
      }),
      error: ((err:HttpErrorResponse)=>{
        this.errorService.errorHandler(err);
        if(errorCallback !== undefined){
          errorCallback(err);
        }
      })
    })
  }
}
