import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from 'src/Services/AuthService';
import { Location } from '@angular/common';

@Component({
  selector: 'app-nav-menu',
  templateUrl: './nav-menu.component.html',
  styleUrls: ['./nav-menu.component.css']
})
export class NavMenuComponent {
  isExpanded = false;
  showNavMenu: boolean=false;

  constructor(private authService:AuthService,private router:Router,private location:Location){}

  ngOnInit(): void {
    const url=this.location.path().toString().toLocaleLowerCase();

    if (url.includes('register') || url.includes('login'))
      this.showNavMenu=false;
    else 
       this.showNavMenu=true;
       console.log(url)
       console.log(url.includes('register'));
  }
  collapse() {
    this.isExpanded = false;
  }

  toggle() {
    this.isExpanded = !this.isExpanded;
  }
  logout()
  {
    this.authService.logout();
    this.router.navigate(['/login'])

  }
}

