import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { AuthGuard } from 'src/Services/auth.guard';
import { CounterComponent } from './counter/counter.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { FormsModule } from '@angular/forms';



@NgModule({
  declarations: [
    NavMenuComponent,
    HomeComponent,
    CounterComponent
  ],
  imports: [
    CommonModule,
    FormsModule,
    RouterModule.forChild([
      { path: '', component: HomeComponent, canActivate:[AuthGuard]  },
      { path: 'counter', component: CounterComponent,canActivate: [AuthGuard] }
  ])]
})
export class CrudsModule { }
