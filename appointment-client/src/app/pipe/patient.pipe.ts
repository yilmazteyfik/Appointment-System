import { Pipe, PipeTransform } from '@angular/core';
import { PatientModel } from '../models/patient.model';

@Pipe({
  name: 'patient'
})
export class PatientPipe implements PipeTransform {

  transform(value: PatientModel[], search: string): PatientModel[] {
    if (!search) {return value;}

    return value.filter(x=> 
      x.fullName.toLocaleLowerCase().includes(search.toLocaleLowerCase()) ||
      x.fullAddress.toLocaleLowerCase().includes(search.toLocaleLowerCase()) ||
      x.city.toLocaleLowerCase().includes(search.toLocaleLowerCase()) ||
      x.town.toLocaleLowerCase().includes(search.toLocaleLowerCase()) ||
      x.identityNumber.toString().includes(search)
    )
  }

}
