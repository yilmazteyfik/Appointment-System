import { Component } from '@angular/core';
import { Route, Router, RouterLink } from '@angular/router';  
import { AuthService } from '../../../services/auth.service';

@Component({
  selector: 'app-navbar',
  imports: [RouterLink],
  standalone: true,
  templateUrl: './navbar.component.html',
  styleUrl: './navbar.component.css'
})
export class NavbarComponent {
  constructor(
    private router : Router,
    private authService : AuthService
  ) {}
  signOut(){
    localStorage.removeItem('token');
    this.router.navigateByUrl('/login');
  }
  getName(){
    return this.authService.tokenDecode.name;
  }
}
