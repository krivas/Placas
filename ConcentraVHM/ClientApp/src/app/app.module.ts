import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { LoginFormComponent } from './login-form/login-form.component';
import { RegisterFormComponent } from './register-form/register-form.component';
import { AddHeaderInterceptor } from '../Interceptors/AddHeaderInterceptor';
import { CrudsModule } from './cruds/cruds.module';


@NgModule({
  declarations: [
    AppComponent,
    LoginFormComponent,
    RegisterFormComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot([
      { path: 'login', component: LoginFormComponent ,pathMatch: 'full'},
      { path: 'register', component: RegisterFormComponent }
    ]),
    CrudsModule
  ],
  providers: [  { provide: HTTP_INTERCEPTORS, useClass: AddHeaderInterceptor, multi: true }],
  bootstrap: [AppComponent]
})
export class AppModule { }

