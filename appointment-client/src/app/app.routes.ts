import { Routes } from '@angular/router';
import { NotFoundComponent } from './component/not-found/not-found.component';
import { LoginComponent } from './component/login/login.component';
import { LayoutsComponent } from './component/layouts/layouts.component';
import { HomeComponent } from './component/home/home.component';
import { inject } from '@angular/core';
import { AuthService } from './services/auth.service';
import { DoctorsComponent } from './component/doctors/doctors.component';
import { PatientsComponent } from './component/patients/patients.component';

export const routes: Routes = [
    {
        path: "login",
        component: LoginComponent
    },
    {
        path: "",
        component: LayoutsComponent,
        canActivateChild: [()=> inject(AuthService).isAuthenticated()],
        children: [
            {
                path: "",
                component: HomeComponent
            },
            {
                path: "doctors",
                component: DoctorsComponent
            },
            {
                path: "patients",
                component: PatientsComponent
            },
        ]    
    },
    {
        path: "**",
        component: NotFoundComponent
    }
];
